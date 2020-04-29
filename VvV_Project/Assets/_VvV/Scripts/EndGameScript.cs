using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGameScript : MonoBehaviour
{
    public LayerMask layerMask = ~0;
    public int targetCount = 2;
    [SerializeField] UnityEvent unityEvent = null;
    private List<Collider> triggeredColliders = new List<Collider>();
    private float intervals = 1f;
    private bool triggered = false;

    private void OnValidate()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void Update()
    {
        CheckCollidersInTrigger();
    }

    private void CheckCollidersInTrigger()
    {
        intervals -= Time.deltaTime;
        if (intervals <= 0)
        {
            triggeredColliders.Clear();
            triggeredColliders.AddRange(Physics.OverlapBox(GetComponent<Collider>().bounds.center, GetComponent<Collider>().bounds.extents, transform.rotation, layerMask));

            if (targetCount == triggeredColliders.Count && triggered == false)
            {
                unityEvent.Invoke();
                triggered = true;
            }
            intervals = 1f;
        }
    }
}
