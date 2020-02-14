using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] private EventManager manager = null;

    [SerializeField] private bool onTriggerEnter = false;
    [SerializeField] private bool onTriggerExit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (onTriggerEnter)
            {
                manager.StartCoroutine(manager.StartEvent());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (onTriggerExit)
            {
                manager.StartCoroutine(manager.StartEvent());
            }
        }
    }
}
