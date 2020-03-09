using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GymEnemy_AttackClosest : MonoBehaviour
{
    [SerializeField] private List<Transform> entities = new List<Transform>();
    public float chaseDistance = 2f;
    [SerializeField] private Transform player = null;
    [SerializeField] private float speed = 5f;

    private Transform currentTarget = null;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= chaseDistance)
        {
            currentTarget = player;
        }
        else
        {
            currentTarget = FindClosestTarget();
        }


        transform.position += (currentTarget.position - transform.position) * speed * Time.deltaTime;

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