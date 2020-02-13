using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemyHitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EntityTracker.Instance.FindEntity(Entity.PlayerEntity))
        {

        }
    }
}
