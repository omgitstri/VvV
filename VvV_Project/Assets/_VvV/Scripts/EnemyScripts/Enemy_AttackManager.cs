using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackManager : MonoBehaviour {
    public Transform start, stop;
    public List<Transform> middle = new List<Transform>();
    [HideInInspector] public float a;
    // [SerializeField] List<Vector3> radius = new List<Vector3>();
    [SerializeField]
    [Header("Modify power with dmg var in GymEnemyAttack_CubeLerp")]
    public List<IndividualCube> allIndividualCubes = new List<IndividualCube>();
    public List<IndividualCube> selectedIndividualCubes = new List<IndividualCube>();
    public List<GymEnemyAttack_CubeLerp> attackCubes = new List<GymEnemyAttack_CubeLerp>();
    private EnemyStats eStats = null;
    [Space]
    private SoundFX sfx = null;
    [SerializeField]private AudioSource audioSource = null;



    private void Awake() {
        eStats = GetComponent<EnemyStatsContainer>().eStats;
        sfx = GetComponent<SoundFX>();
    }

    private void Start() {
        InitManager();

    }

    [ContextMenu(nameof(InitManager))]

    public void InitManager() {
        allIndividualCubes.Clear();
        allIndividualCubes.AddRange(GetComponentsInChildren<IndividualCube>());

        attackCubes.Clear();

        SetupCube();
    }

    public void SetupCube() {
        // Enable AttackCubes
        foreach (var item in selectedIndividualCubes) {
            attackCubes.Add(item.GetComponentInChildren<GymEnemyAttack_CubeLerp>(true));
            item.visualMesh.gameObject.SetActive(true);

            item.attackMesh.startPos = item.attackMesh.transform.position;
            item.attackMesh.start = start;
            item.attackMesh.stop = stop;
            item.attackMesh.root = this;
            item.attackMesh.middle.Clear();
            item.attackMesh.middle.AddRange(middle);
        }
    }

    public List<GymEnemyAttack_CubeLerp> cubes = new List<GymEnemyAttack_CubeLerp>();

    [ContextMenu(nameof(StartAttack))]
    public void StartAttacking() {
        cubes.Clear();
        if (audioSource != null) {
            sfx.PlaySound(audioSource, Toolbox.GetInstance.GetSound().eAttack, true);
        }
        foreach (var item in selectedIndividualCubes) {
            if (!item.killed)
                cubes.Add(item.attackMesh);
        }
        foreach (var item in cubes) {
            item.gameObject.SetActive(true);
            item.attack = true;

            ////visual mesh
            //item.transform.parent.GetChild(0).gameObject.SetActive(false);

            //item.startPos = item.transform.position;
            //item.start = start;
            //item.stop = stop;
            //item.root = this;
            //item.middle.Clear();
            //item.middle.AddRange(middle);
        }

        foreach (var item in selectedIndividualCubes) {
            if (!item.killed) {
                var cube = item.attackMesh;
                //cube.enabled = true;

                item.visualMesh.gameObject.SetActive(false);

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
    private IEnumerator StartAttack() {
        float elapsedTime = 0f;
        float _waitTime = eStats.atkSpd * 0.5f;
        while (elapsedTime < _waitTime) {
            elapsedTime += Time.deltaTime;
            a = elapsedTime;
            yield return null;
        }

        a = 1;

        foreach (var item in cubes) {
            item.attack = false;
            item.reverse = true;
        }

        elapsedTime = 0f;
        while (elapsedTime < _waitTime) {
            elapsedTime += Time.deltaTime;
            a = elapsedTime;
            yield return null;
        }

        a = 1;

        foreach (var item in cubes) {
            item.attack = false;
            item.reverse = false;
            item.gameObject.SetActive(false);
        }

        foreach (var item in selectedIndividualCubes) {
            item.visualMesh.gameObject.SetActive(true);
            //if (item.transform.GetChild(0).TryGetComponent(out MeshRenderer mesh))
            //{
            //    mesh.material.SetColor("_Emission", Color.black);
            //}
        }
    }
}
