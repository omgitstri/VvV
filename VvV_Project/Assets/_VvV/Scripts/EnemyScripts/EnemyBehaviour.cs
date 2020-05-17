using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;


public class EnemyBehaviour : MonoBehaviour
{
    //[SerializeField] private float chaseDistance = 10f;
    [SerializeField] private float losePlayer = 0f;
    [ColorUsage(true, true)]
    public Color attackColor = new Color();

    public bool isVisible = false;

    public Transform currentTarget { get; private set; } = null;
    private NavMeshAgent navMeshAgent = null;
    private List<Transform> entities = new List<Transform>();
    private Transform player = null;
    private EnemyStats eStats = null;
    public float attackCooldown = 1f;
    private Enemy_AttackManager enemyAttack = null;
    private CreateAdjacencyGraph graph = null;

    public List<float> distances = new List<float>();

    public List<IndividualCube> remainingCubes = new List<IndividualCube>();
    public float maxCubes = 0;
    float deathTimer = 1f;

    public AudioSource source;
    public bool isAggro = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        eStats = transform.root.GetComponent<EnemyStatsContainer>().eStats;
        enemyAttack = transform.root.GetComponent<Enemy_AttackManager>();
        graph = transform.root.GetComponent<CreateAdjacencyGraph>();
    }

    private void Start()
    {
        losePlayer = eStats.lostRangDuration;
        player = Entity_Tracker.Instance.PlayerEntity;
        entities = new List<Transform>(Entity_Tracker.Instance.GetAIReference());
        currentTarget = player;
        attackCooldown = eStats.atkSpeed;
        navMeshAgent.SetDestination(currentTarget.position);
        deathTimer = eStats.deathPercentageTimer;
    }

    void Update()
    {
        if ((float)remainingCubes.Count / maxCubes <= eStats.deathPercentage)
        {
            if (deathTimer < 0)
            {
                graph.RespawnAll();

                deathTimer = eStats.deathPercentageTimer;
            }
            else
            {
                deathTimer -= Time.deltaTime;
            }
        }

        ChaseTarget();
        AttackTarget();
    }

    [ContextMenu(nameof(Setup))]
    public void Setup()
    {
        remainingCubes.Clear();
        remainingCubes.AddRange(GetComponentsInChildren<IndividualCube>());
        maxCubes = remainingCubes.Count;
    }

    private void ChaseTarget()
    {

        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.position) <= eStats.aggroRange)
            {
                //Debug.Log("player");
                currentTarget = player;
                losePlayer = eStats.lostRangDuration;
                if (!isAggro)
                {
                    isAggro = true;
                    SoundFX sfx = GetComponent<SoundFX>();
                    sfx.PlaySound(sfx.chosenSource, Toolbox.GetInstance.GetSound().eAggro, true, 0.4f, 0.5f, 0.90f, 1.10f);
                }


            }
            else if (losePlayer < 0)
            {
                currentTarget = ReturnClosestTarget();

                if (isAggro)
                {
                    isAggro = false;
                }
            }
            else
            {
                losePlayer -= Time.deltaTime * 2f;
            }
        }

        if (currentTarget != null)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(currentTarget.position);

        }
        else
        {
            navMeshAgent.isStopped = true;
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            GetComponent<EnemyMovementState>().EnemyIdle();
        }

        else if (GetComponent<EnemyMovementState>().currentMoveState == EnemyMovementState.MoveState.Crawl)
        {
            GetComponent<EnemyMovementState>().EnemyCrawl();
        }

        else
        {
            GetComponent<EnemyMovementState>().EnemyWalk();
        }
    }


    private Transform ReturnClosestTarget()
    {
        float shortestDistance = 1000000;
        Transform currentTransform = null;

        for (int i = 0; i < entities.Count; i++)
        {
            float currentDistance = Vector3.Distance(entities[i].position, transform.position);

            if (entities[i].gameObject.activeSelf)
            {
                if (currentDistance < shortestDistance)
                {
                    shortestDistance = currentDistance;
                    currentTransform = entities[i];
                }
            }
        }
        return currentTransform;
    }

    public void AttackTarget()
    {
        if (Application.isPlaying == true)
        {
            // distance
            if (Vector3.Distance(currentTarget.position, transform.position) <= eStats.attRange)
            {
                if (attackCooldown <= 0)
                {
                    //enemyAttack.stop.position = Entity_Tracker.Instance.PlayerEntity.position + Vector3.up * 0.5f;
                    enemyAttack.stop.position = currentTarget.position + Vector3.up * 0.5f;
                    enemyAttack.StartAttacking();
                    attackCooldown = eStats.atkSpeed + 500;
                }
                else
                {
                    attackCooldown -= Time.deltaTime;
                }
            }
            else
            {
                if (attackCooldown > eStats.atkSpeed)
                {
                    attackCooldown = eStats.atkSpeed;
                }
                else if (attackCooldown < eStats.atkSpeed)
                {
                    attackCooldown += Time.deltaTime;
                }
            }

            foreach (var item in enemyAttack.selectedIndividualCubes)
            {
                if (item.transform.GetChild(0).TryGetComponent(out MeshRenderer mesh))
                {
                    mesh.material.SetColor("_Emission", Color.Lerp(Color.black, attackColor, (eStats.atkSpeed - attackCooldown) / eStats.atkSpeed));
                }
            }
        }
    }

    public void SetVisibility(bool _toggle)
    {
        isVisible = _toggle;
    }

}