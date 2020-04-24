using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackManager : MonoBehaviour
{
    public Transform start, stop;
    public List<Transform> middle = new List<Transform>();
    [HideInInspector] public float a;
   // [SerializeField] List<Vector3> radius = new List<Vector3>();
    [SerializeField]
    [Header("Modify power with dmg var in GymEnemyAttack_CubeLerp")]
    public List<IndividualCube> attackCubes = new List<IndividualCube>();
    private EnemyStats eStats = null;


    private void Awake()
    {
        eStats = GetComponent<EnemyStatsContainer>().eStats;
    }

    private void Start()
    {
        SetupCube();
    }

    [ContextMenu(nameof(SetupCube))]
    public void SetupCube()
    {
        // Disable AttackCubes
        foreach (var item in GetComponentsInChildren<GymEnemyAttack_CubeLerp>(true))
        {
            //item.enabled = false;
            item.transform.localPosition = Vector3.zero;
        }

        // Enable VisualCubes
        foreach (var item in GetComponentsInChildren<IndividualCube>())
        {
            item.transform.GetChild(0).gameObject.SetActive(true);
        }

        // Enable AttackCubes
        foreach (var item in attackCubes)
        {
            var cube = item.transform.GetComponentInChildren<GymEnemyAttack_CubeLerp>(true);
            //cube.enabled = true;

            //item.transform.GetChild(0).gameObject.SetActive(false);

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
    public void StartAttacking()
    {
        cubes.Clear();

        foreach (var item in attackCubes)
        {
            if (!item.killed)
                cubes.Add(item.GetComponentInChildren<GymEnemyAttack_CubeLerp>(true));
        }
        foreach (var item in cubes)
        {
            item.gameObject.SetActive(true);
            item.attack = true;
        }

        foreach (var item in attackCubes)
        {
            if (!item.killed)
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

        //SetupCube();
        StartCoroutine(nameof(StartAttack));
    }
    private IEnumerator StartAttack()
    {
        float elapsedTime = 0f;
        float _waitTime = eStats.atkSpd * 0.5f;
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
            item.gameObject.SetActive(false);
        }

        foreach (var item in attackCubes)
        {
            item.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
