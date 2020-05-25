using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPickup : MonoBehaviour
{
    public UnityEvent pickUpEvent = null;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Entity_Tracker.Instance.collectedPart = true;
            gameObject.SetActive(false);

            pickUpEvent.Invoke();
        }
    }
}
