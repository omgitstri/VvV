using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GymEnemy_AttackClosest : MonoBehaviour
{
    [SerializeField] private bool normalizedMovement = false;
    [SerializeField] private List<Transform> entities = new List<Transform>();
    public float chaseDistance = 2f;
    [SerializeField] private Transform player = null;
    [SerializeField] private float speed = 5f;
    float losePlayer = 2f;

    public Transform currentTarget { get; private set; }

    private void Start()
    {
        currentTarget = FindClosestTarget();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= chaseDistance)
        {
            currentTarget = player;
            losePlayer = 2f;
        }
        else if (losePlayer < 0)
        {
            currentTarget = FindClosestTarget();
        }
        else
        {
            losePlayer -= Time.deltaTime;
        }

        if (currentTarget != null && Vector3.Distance(currentTarget.position, transform.position) > 0.01f)
        {
            if (normalizedMovement)
            {
                transform.position += (currentTarget.position - transform.position).normalized * speed * Time.deltaTime;
            }
            else
            {
                transform.position += (currentTarget.position - transform.position) * speed * Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, chaseDistance);
    }

    private Transform FindClosestTarget()
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