using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChase : MonoBehaviour
{
    public TempEnemy enemy;
    public Demowaypoint demowaypoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == EntityTracker.Instance.FindEntity( Entity.PlayerEntity))
        {
            demowaypoint.enabled = false;
            enemy.enabled = true;
            Destroy(gameObject);
        }
    }
}
