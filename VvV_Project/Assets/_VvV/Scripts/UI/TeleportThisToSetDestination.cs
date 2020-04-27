using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
///      Teleport object with script to attached to to set destinatio
/// </summary>

public class TeleportThisToSetDestination : MonoBehaviour
{
    public void TeleportHere(Transform destination)
    {
        if (TryGetComponent(out NavMeshAgent nav))
        {
            nav.Warp(destination.position);
        }
        else
        {
            transform.position = destination.position;
        }
        //Transform thisTarget.position = destination.position;
    }


}