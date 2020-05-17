using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackManager : MonoBehaviour
{
    public Transform start, stop;
    public List<Transform> middle = new List<Transform>();
    public List<IndividualCube> allIndividualCubes = new List<IndividualCube>();
    public List<IndividualCube> selectedIndividualCubes = new List<IndividualCube>();
    //public List<GymEnemyAttack_CubeLerp> totalAttackCubes = new List<GymEnemyAttack_CubeLerp>();
    public List<GymEnemyAttack_CubeLerp> activeAttackCubes = new List<GymEnemyAttack_CubeLerp>();

    [SerializeField] private AudioSource audioSource = null;

    [HideInInspector] public float a;

    private EnemyStats eStats = null;
    private SoundFX sfx = null;



    private void Awake()
    {
        eStats = GetComponent<EnemyStatsContainer>().eStats;
        sfx = GetComponent<SoundFX>();
    }

    private void Start()
    {
        InitManager();
    }

    [ContextMenu(nameof(InitManager))]
    public void InitManager()
    {
        if (allIndividualCubes.Count <= 0)
        {
            allIndividualCubes.Clear();
            allIndividualCubes.AddRange(GetComponentsInChildren<IndividualCube>());
        }
        SetupCube();
    }

    public void SetupCube()
    {
        //totalAttackCubes.Clear();
        foreach (var item in selectedIndividualCubes)
        {
            //totalAttackCubes.Add(item.GetComponentInChildren<GymEnemyAttack_CubeLerp>(true));
            item.visualMesh.gameObject.SetActive(true);
            item.attackMesh.parent = item;
            item.attackMesh.startPos = item.attackMesh.parent.transform.position;
            item.attackMesh.start = start;
            item.attackMesh.stop = stop;
            item.attackMesh.root = this;
            item.attackMesh.middle.Clear();
            item.attackMesh.middle.AddRange(middle);
        }
    }

    [ContextMenu(nameof(StartAttack))]
    public void StartAttacking()
    {
        if (audioSource != null)
        {
            sfx.PlaySound(audioSource, Toolbox.GetInstance.GetSound().eAttack, true, 0.15f, 0.40f, 0.75f, 1f);
        }

        activeAttackCubes.Clear();
        foreach (var item in selectedIndividualCubes)
        {
            if (!item.killed)
            {
                activeAttackCubes.Add(item.attackMesh);

                item.attackMesh.gameObject.SetActive(true);
                item.attackMesh.attack = true;

                item.visualMesh.gameObject.SetActive(false);

                item.attackMesh.startPos = item.attackMesh.parent.transform.position;
                item.attackMesh.start = start;
                item.attackMesh.stop = stop;
                item.attackMesh.root = this;
                item.attackMesh.middle.Clear();
                item.attackMesh.middle.AddRange(middle);
            }
        }

        StartCoroutine(nameof(StartAttack));
    }
    private IEnumerator StartAttack()
    {
        float elapsedTime = 0f;
        float _waitTime = eStats.atkSpeed * 0.5f;

        //attack
        while (elapsedTime < _waitTime)
        {
            elapsedTime += Time.deltaTime;

            a = (elapsedTime + 0.001f) / _waitTime;
            yield return null;
        }

        a = 1;

        //reverse
        foreach (var item in activeAttackCubes)
        {
            item.lastPosition = item.transform.position;
            item.attack = false;
            item.reverse = true;
        }

        elapsedTime = 0f;
        while (elapsedTime < _waitTime)
        {
            elapsedTime += Time.deltaTime;
            a = (elapsedTime + 0.001f) / _waitTime;
            yield return null;
        }

        a = 1;


        //completed
        foreach (var item in selectedIndividualCubes)
        {
            item.attackMesh.attack = false;
            item.attackMesh.reverse = false;
            item.attackMesh.transform.SetParent(item.attackMesh.parent.transform);
            item.attackMesh.transform.localPosition = Vector3.zero;
            item.attackMesh.gameObject.SetActive(false);

            item.visualMesh.gameObject.SetActive(true);
        }
        GetComponent<EnemyBehaviour>().attackCooldown = eStats.atkSpeed;
    }

}
