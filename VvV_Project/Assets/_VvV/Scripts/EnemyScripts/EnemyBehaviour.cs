using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

[ExecuteAlways]

public class EnemyBehaviour : MonoBehaviour
{
    //[SerializeField] private float chaseDistance = 10f;
    [SerializeField] private float losePlayer = 0f;

    public Transform currentTarget { get; private set; } = null;
    private NavMeshAgent navMeshAgent = null;
    private List<Transform> entities = new List<Transform>();
    private Transform player = null;
    private EnemyStats eStats = null;
    private float attackCooldown = 1f;
    private GymEnemy_AttackLerp enemyAttack = null;

    [Space]

    [SerializeField] private bool customColorDisplay = true;
    [SerializeField] private Color gizmoColor = new Color(1f, 0f, 0f, 0.2f);


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        eStats = transform.root.GetComponent<EnemyStatsContainer>().eStats;
        enemyAttack = transform.root.GetComponent<GymEnemy_AttackLerp>();
    }

    private void Start()
    {
        losePlayer = eStats.lostRngDur;
        player = Entity_Tracker.Instance.PlayerEntity;
        entities = new List<Transform>(Entity_Tracker.Instance.InteractableEntity);
        currentTarget = player;
        attackCooldown = eStats.atkSpd;
    }

    void Update()
    {
        ChaseTarget();
        AttackTarget();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        if (customColorDisplay == true)
        {
            Gizmos.DrawSphere(transform.position, eStats.aggroRng);
        }
    }




    private void ChaseTarget()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.position) <= eStats.aggroRng)
            {
                //Debug.Log("player");
                currentTarget = player;
                losePlayer = eStats.lostRngDur;
            }
            else if (losePlayer < 0)
            {
                currentTarget = ReturnClosestTarget();
            }
            else
            {
                losePlayer -= Time.deltaTime;
            }
        }

        if (currentTarget != null && Vector3.Distance(currentTarget.position, transform.position) > 0.01f)
        {
            navMeshAgent.SetDestination(currentTarget.position);
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
            if (Vector3.Distance(currentTarget.position, transform.position) <= eStats.attRng)
            {
                if (attackCooldown <= 0)
                {
                    enemyAttack.StartAttacking();
                    Debug.Log("player");
                    attackCooldown = eStats.atkSpd;
                }
                else
                {
                    attackCooldown -= Time.deltaTime;
                }
            }
        }

    }

}