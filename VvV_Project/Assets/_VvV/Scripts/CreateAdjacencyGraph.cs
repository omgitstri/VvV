﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateAdjacencyGraph : MonoBehaviour
{
    public Dictionary<Vector3, IndividualCube> Children = new Dictionary<Vector3, IndividualCube>();

    public List<IndividualCube> allCubes { get; private set; } = new List<IndividualCube>();


    private IndividualCube weakPoint = null;

    [SerializeField] private Material white = null;
    [SerializeField] private Material red = null;

    public int direction;
    public int distance;

    //test
    public int attackCount = 20;
    [ContextMenu(nameof(GetAttackCubes))]
    public void GetAttackCubes()
    {
        var temp = new List<IndividualCube>();
        for (int i = 0; i < attackCount; i++)
        {
            var rand = Random.Range(0, allCubes.Count - 1);
            if (!temp.Contains(allCubes[rand]))
            {
                temp.Add(allCubes[Random.Range(0, allCubes.Count - 1)]);
            }
            else
            {
                i -= 1;
            }
        }

        if (TryGetComponent<GymEnemy_AttackLerp>(out GymEnemy_AttackLerp comp))
        {
            comp.attackCubes.Clear();
            comp.attackCubes.AddRange(temp);

        }
    }


    void Start()
    {
        InitAllCubes();

        CreateDictionary(transform);
        CreateAG();
        //InvokeRepeating(nameof(WeakPointFreeWalking), 0f, 0.3f);
    }

    float timer = 0;
    public bool alive = true;

    private void Update()
    {
        if (timer <= 0 && alive)
        {
            WeakPointFreeWalking();
            timer = Random.Range(0f, 0.3f);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void SetupAdjacency()
    {
        CreateDictionary(transform);
        CreateAG();
    }

    [ContextMenu(nameof(InitSetupAdjacency))]
    void InitSetupAdjacency()
    {
        CreateDictionary(transform);
        CreateAG();
    }

    [ContextMenu(nameof(InitAllCubes))]
    void InitAllCubes()
    {
        allCubes.AddRange(GetComponentsInChildren<IndividualCube>());
        weakPoint = allCubes[Random.Range(0, allCubes.Count)];
    }


    void CreateAG()
    {
        //---------Assign neighbours
        foreach (KeyValuePair<Vector3, IndividualCube> kvp in Children)
        {
            Vector3 currCubeKey = kvp.Key;
            Vector3 frontCubeKey = currCubeKey + Vector3.forward;
            Vector3 backCubeKey = currCubeKey + Vector3.back;
            Vector3 leftCubeKey = currCubeKey + Vector3.left;
            Vector3 rightCubeKey = currCubeKey + Vector3.right;
            Vector3 topCubeKey = currCubeKey + Vector3.up;
            Vector3 bottomCubeKey = currCubeKey + Vector3.down;

            if (Children.ContainsKey(frontCubeKey))
            {
                kvp.Value.frontCube = Children[frontCubeKey];
            }
            if (Children.ContainsKey(backCubeKey))
            {
                kvp.Value.backCube = Children[backCubeKey];
            }
            if (Children.ContainsKey(leftCubeKey))
            {
                kvp.Value.leftCube = Children[leftCubeKey];
            }
            if (Children.ContainsKey(rightCubeKey))
            {
                kvp.Value.rightCube = Children[rightCubeKey];
            }
            if (Children.ContainsKey(topCubeKey))
            {
                kvp.Value.topCube = Children[topCubeKey];
            }
            if (Children.ContainsKey(bottomCubeKey))
            {
                kvp.Value.bottomCube = Children[bottomCubeKey];
            }
        }
    }

    void CreateDictionary(Transform curr)
    {
        if (curr.childCount == 0)
        {
            return;
        }

        for (int i = 0; i < curr.childCount; i++)
        {
            var individualCube = curr.GetChild(i).GetComponent<IndividualCube>();

            //-----------Recursion
            if (curr.GetChild(i).childCount > 0)
            {
                Transform newCurr = curr.GetChild(i);
                CreateDictionary(newCurr);
            }

            //---------Turn its name into a Vecter3
            if (individualCube != null)
            {
                string name = curr.GetChild(i).name;
                string[] result = name.Split(new char[] { '_' });
                int x = int.Parse(result[result.Length - 3]);
                int y = int.Parse(result[result.Length - 2]);
                int z = int.Parse(result[result.Length - 1]);

                individualCube.voxelLocalPosition = new Vector3(x, y, z);
                Vector3 key = individualCube.voxelLocalPosition;
                IndividualCube child = individualCube;

                Children.Add(key, child);
            }
        }
    }

    [ContextMenu(nameof(DestroyDetached))]
    public void DestroyDetached()
    {
        foreach (KeyValuePair<Vector3, IndividualCube> kvp in Children)
        {
            if (kvp.Value != null && kvp.Value.visit != weakPoint.visit)
            {
                //Children.Remove(kvp.Key);
                kvp.Value.DeactivateNeighbours();
            }
        }
    }

    public void DestroyHit()
    {
        foreach (KeyValuePair<Vector3, IndividualCube> kvp in Children)
        {
            if (kvp.Value != null &&
                kvp.Value.hit == true &&
                kvp.Value.CompareTag("Enemy"))
            {
                kvp.Value.DeactivateNeighbours();
            }
        }
    }

    public void DestroyAll()
    {
        foreach (var child in allCubes)
        {
            if (child != null)
            {
                child.DeactivateCube();
            }
        }
    }

    public IndividualCube GetWeakPoint()
    {
        if (weakPoint != null)
        {
            return weakPoint;
        }
        else
        {
            return null;
        }
    }

    public void WeakPointFreeWalking()
    {
        IndividualCube destination = null;

        switch (direction)
        {
            case 1:
                destination = weakPoint.frontCube;
                break;
            case 2:
                destination = weakPoint.backCube;
                break;
            case 3:
                destination = weakPoint.leftCube;
                break;
            case 4:
                destination = weakPoint.rightCube;
                break;
            case 5:
                destination = weakPoint.topCube;
                break;
            case 6:
                destination = weakPoint.bottomCube;
                break;
        }

        weakPoint.transform.GetChild(0).GetComponent<Renderer>().material = white;
        weakPoint.gameObject.tag = "Enemy";
        weakPoint.UnsetNeighboursToWeakPoint(2, white);

        if (distance > 0 && destination != null)
        {
            weakPoint = destination;

            distance--;
        }
        else
        {
            distance = Random.Range(3, 8);
            List<int> neighbourIndex = weakPoint.GetNeighbourIndices();
            List<IndividualCube> neighbours = weakPoint.GetNeighbours();
            int randIndex = Random.Range(0, neighbours.Count);
            weakPoint = neighbours[randIndex];
            direction = neighbourIndex[randIndex];

        }

        weakPoint.transform.GetChild(0).GetComponent<Renderer>().material = red;
        weakPoint.gameObject.tag = "WeakPoint";
        weakPoint.SetNeighboursToWeakPoint(2, red);

    }

    [ContextMenu(nameof(Regen))]
    public void Regen()
    {
        Children.Clear();
        InitSetupAdjacency();
        var cubes = new List<IndividualCube>();

        cubes.AddRange(GetComponentsInChildren<IndividualCube>());

        foreach (var item in cubes)
        {
            item.visit = 0;
            item.StartCoroutine(nameof(Regen));
        }
        alive = true;
    }


#if UNITY_EDITOR
    [SerializeField] GameObject prefab = null;
    [ContextMenu(nameof(CreateChild))]
    public void CreateChild()
    {
        var cubes = new List<IndividualCube>();

        cubes.AddRange(GetComponentsInChildren<IndividualCube>());

        foreach (var item in cubes)
        {
            //var go = Instantiate<GameObject>(prefab, item.transform);
            var go = (GameObject)PrefabUtility.InstantiatePrefab(prefab, item.transform);
            go.transform.localPosition = Vector3.zero;
        }
    }
#endif
}