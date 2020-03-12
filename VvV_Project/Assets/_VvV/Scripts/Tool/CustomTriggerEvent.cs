using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CustomTriggerEvent : MonoBehaviour
{
    public bool ToggleOnTriggerEnter = false;
    public bool ToggleOnTriggerExit = false;
    public bool ToggleOnTriggerStay = false;

    [Space]

    public UnityEvent _OnTriggerEnter;
    public UnityEvent _OnTriggerExit;
    public UnityEvent _OnTriggerStay;

    private void OnValidate()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ToggleOnTriggerEnter)
        {
            _OnTriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ToggleOnTriggerExit)
        {
            _OnTriggerExit.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (ToggleOnTriggerStay)
        {
            _OnTriggerStay.Invoke();
        }
    }
}
