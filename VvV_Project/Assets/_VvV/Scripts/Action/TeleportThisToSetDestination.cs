using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
///      Teleport object with script to attached to to set destinatio
/// </summary>

public class TeleportThisToSetDestination : MonoBehaviour
{
    public Vector3 teleportPoint = Vector3.zero;


    public void TeleportHere()
    {
        if (TryGetComponent(out NavMeshAgent nav))
        {
            nav.Warp(teleportPoint);
        }
        else
        {
            transform.position = teleportPoint;
        }
    }
    public void TeleportTarget(Transform _target)
    {
        if (TryGetComponent(out NavMeshAgent nav))
        {
            nav.Warp(_target.position);
        }
        else
        {
            transform.position = _target.position;
        }
    }


}