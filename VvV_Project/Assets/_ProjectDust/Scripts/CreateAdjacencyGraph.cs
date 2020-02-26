using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAdjacencyGraph : MonoBehaviour
{
    public Dictionary<Vector3, GameObject> Children;

    public GameObject weakPoint;

    public Material white;
    public Material red;
    //public string test = "found";

    public int direction;
    public int distance;
    // Start is called before the first frame update
    void Start()
    {
        Children = new Dictionary<Vector3, GameObject>();
        CreateDictionary(transform);
        CreateAG();
        InvokeRepeating(nameof(WeakPointFreeWalking), 0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetupAdjacency()
    {
        //Children = new Dictionary<Vector3, GameObject>();
        CreateDictionary(transform);
        CreateAG();
    }

    [ContextMenu("Create Adjacency Graph")]
    void InitSetupAdjacency()
    {
        Children = new Dictionary<Vector3, GameObject>();
        CreateDictionary(transform);
        CreateAG();
    }

    void CreateAG()
    {
        //---------Assign neighbours
        foreach (KeyValuePair<Vector3, GameObject> kvp in Children)
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
                kvp.Value.GetComponent<IndividualCube>().frontCube = Children[frontCubeKey];
            }
            if (Children.ContainsKey(backCubeKey))
            {
                kvp.Value.GetComponent<IndividualCube>().backCube = Children[backCubeKey];
            }
            if (Children.ContainsKey(leftCubeKey))
            {
                kvp.Value.GetComponent<IndividualCube>().leftCube = Children[leftCubeKey];
            }
            if (Children.ContainsKey(rightCubeKey))
            {
                kvp.Value.GetComponent<IndividualCube>().rightCube = Children[rightCubeKey];
            }
            if (Children.ContainsKey(topCubeKey))
            {
                kvp.Value.GetComponent<IndividualCube>().topCube = Children[topCubeKey];
            }
            if (Children.ContainsKey(bottomCubeKey))
            {
                kvp.Value.GetComponent<IndividualCube>().bottomCube = Children[bottomCubeKey];
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
            //-----------Recursion
            if (curr.GetChild(i).childCount > 0)
            {
                Transform newCurr = curr.GetChild(i);
                CreateDictionary(newCurr);
            }

            //---------Turn its name into a Vecter3
            if (curr.GetChild(i).GetComponent<IndividualCube>() != null)
            {
                string name = curr.GetChild(i).name;
                string[] result = name.Split(new char[] { '_' });
                int x = int.Parse(result[result.Length - 3]);
                int y = int.Parse(result[result.Length - 2]);
                int z = int.Parse(result[result.Length - 1]);

                curr.GetChild(i).GetComponent<IndividualCube>().voxelPosition = new Vector3(x, y, z);
                Vector3 key = curr.GetChild(i).GetComponent<IndividualCube>().voxelPosition;
                GameObject child = curr.GetChild(i).gameObject;

                /*print(key);
                if (child == null)
                {
                    print("null");
                }*/

                Children.Add(key, child);

                /*print("Length" + result.Length);
                for(int j = 0; j < result.Length; j++)
                {
                    print(result[j]);
                }*/
            }
        }
    }

    public void DestroyDetached()
    {
        foreach (KeyValuePair<Vector3, GameObject> kvp in Children)
        {
            if (kvp.Value != null && kvp.Value.GetComponent<IndividualCube>().visit != weakPoint.GetComponent<IndividualCube>().visit)
            {
                //Children.Remove(kvp.Key);
                kvp.Value.GetComponent<IndividualCube>().DestroyCube();
            }
        }
    }

    public void DestroyHit()
    {
        foreach (KeyValuePair<Vector3, GameObject> kvp in Children)
        {
            if (kvp.Value != null && kvp.Value.GetComponent<IndividualCube>().hit == true && kvp.Value.tag == "Enemy")
            {
                kvp.Value.GetComponent<IndividualCube>().DestroyCube();
            }
        }
    }

    public GameObject GetWeakPoint()
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
        GameObject destination = null;

        switch (direction)
        {
            case 1:
                destination = weakPoint.GetComponent<IndividualCube>().frontCube;
                break;
            case 2:
                destination = weakPoint.GetComponent<IndividualCube>().backCube;
                break;
            case 3:
                destination = weakPoint.GetComponent<IndividualCube>().leftCube;
                break;
            case 4:
                destination = weakPoint.GetComponent<IndividualCube>().rightCube;
                break;
            case 5:
                destination = weakPoint.GetComponent<IndividualCube>().topCube;
                break;
            case 6:
                destination = weakPoint.GetComponent<IndividualCube>().bottomCube;
                break;

        }

        weakPoint.GetComponent<Renderer>().material = white;
        weakPoint.gameObject.tag = "Enemy";
        weakPoint.GetComponent<IndividualCube>().UnsetNeighboursToWeakPoint(2, white);

        if (distance > 0 && destination != null)
        {
            /*if (direction == 1 && weakPoint.GetComponent<IndividualCube>().frontCube != null)
            {
                weakPoint = weakPoint.GetComponent<IndividualCube>().frontCube;
            }*/
            weakPoint = destination;

            distance--;
        }
        else
        {
            distance = Random.Range(3, 8);
            List<int> neighbourIndex = weakPoint.GetComponent<IndividualCube>().GetNeighbourIndices();
            List<GameObject> neighbours = weakPoint.GetComponent<IndividualCube>().GetNeighbours();
            int randIndex = Random.Range(0, neighbours.Count);
            weakPoint = neighbours[randIndex];
            direction = neighbourIndex[randIndex];

        }

        weakPoint.GetComponent<Renderer>().material = red;
        weakPoint.gameObject.tag = "WeakPoint";
        weakPoint.GetComponent<IndividualCube>().SetNeighboursToWeakPoint(2, red);

    }
}
