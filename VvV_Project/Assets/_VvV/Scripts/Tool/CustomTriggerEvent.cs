using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CustomTriggerEvent : MonoBehaviour
{
    public bool ignoreRaycastLayer = true;
    public LayerMask layerMask = ~0;

    [HideInInspector] public bool ToggleOnTriggerEnter = false;
    [HideInInspector] public bool ToggleOnTriggerExit = false;
    [HideInInspector] public bool ToggleOnTriggerStay = false;

    [Space]

    [HideInInspector] public UnityEvent _OnTriggerEnter;
    [HideInInspector] public UnityEvent _OnTriggerExit;
    [HideInInspector] public UnityEvent _OnTriggerStay;

    private List<Transform> triggeredObjects = new List<Transform>();
    private List<Collider> triggeredColliders = new List<Collider>();
    private float intervals = 0.5f;

    //private void OnValidate()
    //{
    //    GetComponent<Collider>().isTrigger = true;
    //    if (ignoreRaycastLayer == true)
    //    {
    //        gameObject.layer = (1 << 1);
    //    }
    //}

    //private void Update()
    //{
    //    CheckCollidersInTrigger();
    //}

    //private void CheckCollidersInTrigger()
    //{
    //    intervals -= Time.deltaTime;
    //    if (intervals <= 0)
    //    {
    //        triggeredColliders.Clear();
    //        triggeredColliders.AddRange(Physics.OverlapBox(GetComponent<Collider>().bounds.center, GetComponent<Collider>().bounds.extents, transform.rotation, layerMask));

    //        if (triggeredColliders.Count <= 0)
    //        {
    //            triggeredObjects.Clear();
    //            foreach (var item in triggeredColliders)
    //            {
    //                triggeredObjects.Add(item.transform);
    //            }
    //            _OnTriggerExit.Invoke();

    //        }
    //        else if (triggeredObjects.Count > 0)
    //        {
    //            _OnTriggerEnter.Invoke();
    //        }
    //        intervals = 1f;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (ToggleOnTriggerEnter && layerMask == (layerMask | 1 << other.gameObject.layer))
        {
            if (!triggeredObjects.Contains(other.transform))
            {
                triggeredObjects.Add(other.transform);
            }

            _OnTriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ToggleOnTriggerExit/* && layerMask == (layerMask | 1 << other.gameObject.layer)*/)
        {
            if (triggeredObjects.Contains(other.transform))
            {
                triggeredObjects.Remove(other.transform);
            }

            if (/*triggeredObjects.Count <= 0 && */triggeredColliders.Count <= 0)
            {
                _OnTriggerExit.Invoke();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (ToggleOnTriggerStay && layerMask.value == 1 << other.gameObject.layer)
        {
            _OnTriggerStay.Invoke();
        }
    }
}
