using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform currentTarget { get; private set; } = null;
    [SerializeField] private float chaseDistance = 10f;
    [SerializeField] private float losePlayer = 2f;
    [SerializeField] private bool customColorDisplay = false;
    [SerializeField] [Range(0f,1f)] private float colorR = 2f;
    [SerializeField] [Range(0f, 1f)] private float colorG = 2f;
    [SerializeField] [Range(0f, 1f)] private float colorB = 2f;
    [SerializeField] [Range(0f, 1f)] private float colorA = 2f;

    private NavMeshAgent navMeshAgent = null;
    private List<Transform> entities = new List<Transform>();
    private Transform player = null;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        player = Entity_Tracker.Instance.PlayerEntity;
        entities = new List<Transform>(Entity_Tracker.Instance.InteractableEntity);
        currentTarget = player;
    }

    void Update()
    {
        ChaseTarget();
    }

    private void OnDrawGizmos()
    {
        if (customColorDisplay == true)
            Gizmos.color = new Color(colorR, colorG, colorB, colorA);
        else
            Gizmos.color = new Color(1, 0, 0, 0.2f);

        Gizmos.DrawSphere(transform.position, chaseDistance);

    }

    private void ChaseTarget()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.position) <= chaseDistance)
            {
                //Debug.Log("player");
                currentTarget = player;
                losePlayer = 2f;
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
}