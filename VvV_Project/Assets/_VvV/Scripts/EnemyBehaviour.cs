using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float aggroRadius = 3f;
    private Transform target = null;

    private List<Transform> availableTargets = new List<Transform>();

    void Start()
    {
        availableTargets.Clear();
        availableTargets.AddRange(Entity_Tracker.Instance.GetAIReference());
    }

    void Update()
    {
        
    }

    private Transform ReturnClosestReference()
    {
        Transform closestTarget = null;
        for (int i = 0; i < availableTargets.Count; i++)
        {
            float currentDistance = 10000f;

            float comparedDistance = Vector3.Distance(availableTargets[i].position, transform.position);

            if (comparedDistance < currentDistance)
            {
                closestTarget = availableTargets[i];
            }
        }

        return closestTarget;
    }
}
