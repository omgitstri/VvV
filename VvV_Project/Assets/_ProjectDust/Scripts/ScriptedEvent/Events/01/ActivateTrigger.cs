using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public Collider trigger;

    void Start()
    {
        trigger.enabled = false;
    }

    [ContextMenu("Test Triggr")]
    public void PlayTrigger()
    {
        trigger.enabled = true;
    }
}
