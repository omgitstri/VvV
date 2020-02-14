using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRotation : MonoBehaviour
{

    public Vector3 rotation = Vector3.zero;
    private bool triggered = false;
    private float timer = 0;

    void Update()
    {

        if (triggered)
        {
            timer += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotation), timer);
        }
    }

    [ContextMenu("Test Trigger")]
    public void PlayTrigger()
    {
        triggered = true;
    }
}
