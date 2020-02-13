using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomTriggerEvent : MonoBehaviour
{
    public UnityEvent _onTriggerEnter = null;
    public UnityEvent _onTriggerStay = null;
    public UnityEvent _onTriggerExit = null;

    [HideInInspector] public bool TriggerEnter = false;
    [HideInInspector] public bool TriggerStay = false;
    [HideInInspector] public bool TriggerExit = false;

    private void OnValidate()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(TriggerEnter)
        {
            _onTriggerEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (TriggerStay)
        {
            _onTriggerStay.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (TriggerExit)
        {
            _onTriggerExit.Invoke();
        }
    }
}
