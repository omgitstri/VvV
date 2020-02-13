using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockOn : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    private bool lockOn = false;

    private void Start()
    {
        if (TargetManager.Instance != null && lockOn)
        {
            target = TargetManager.Instance.GetCurrentTarget();
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position, Vector3.up), 5f * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, Vector3.up), 5f * Time.deltaTime);
        }
    }

    [ContextMenu("next")]
    public void Next()
    {
        target = TargetManager.Instance.GetNextTarget(target);
    }

    [ContextMenu("previous")]
    public void Previous()
    {
        target = TargetManager.Instance.GetPreviousTarget(target);
    }
}
