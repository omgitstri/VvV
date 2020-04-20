using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymEnemy_AttackLerp : MonoBehaviour
{
    public Transform start, stop;
    public List<Transform> middle = new List<Transform>();
    public float a;
    [SerializeField] List<Vector3> radius = new List<Vector3>();
    [SerializeField]
    [Header("Modify power with dmg var in GymEnemyAttack_CubeLerp")]
    public List<IndividualCube> attackCubes = new List<IndividualCube>();

    [ContextMenu(nameof(start))]
    private void Start()
    {

        Test();
    }

    [ContextMenu("Test")]
    public void Test()
    {
        foreach (var item in GetComponentsInChildren<GymEnemyAttack_CubeLerp>())
        {
            item.enabled = false;
            item.transform.localPosition = Vector3.zero;
        }

        foreach (var item in GetComponentsInChildren<IndividualCube>())
        {
            item.transform.GetChild(0).gameObject.SetActive(true);
        }

        foreach (var item in attackCubes)
        {
            var cube = item.transform.GetComponentInChildren<GymEnemyAttack_CubeLerp>();
            //cube.enabled = true;

            item.transform.GetChild(0).gameObject.SetActive(false);

            cube.startPos = cube.transform.position;
            cube.start = start;
            cube.stop = stop;
            cube.root = this;
            cube.middle.Clear();
            cube.middle.AddRange(middle);
        }
    }

        public List<GymEnemyAttack_CubeLerp> cubes = new List<GymEnemyAttack_CubeLerp>();
    [ContextMenu(nameof(StartAttack))]
    public void rawr()
    {
        foreach (var item in attackCubes)
        {
            cubes.Add(item.GetComponentInChildren<GymEnemyAttack_CubeLerp>());
        }
        foreach (var item in cubes)
        {
            item.enabled = true;
            item.attack = true;
        }

        StartCoroutine(nameof(StartAttack));
    }
    private IEnumerator StartAttack()
    {
        float elapsedTime = 0f;
        float _waitTime = 1f;
        while (elapsedTime < _waitTime)
        {
            elapsedTime += Time.deltaTime;
            a = elapsedTime;
            yield return null;
        }
        a = 1;

        foreach (var item in cubes)
        {
            item.attack = false;
            item.reverse = true;
        }

        elapsedTime = 0f;
        while (elapsedTime < _waitTime)
        {
            elapsedTime += Time.deltaTime;
            a = elapsedTime;
            yield return null;
        }

        a = 1;

        foreach (var item in cubes)
        {
            item.attack = false;
            item.reverse = false;
        }
    }
}
