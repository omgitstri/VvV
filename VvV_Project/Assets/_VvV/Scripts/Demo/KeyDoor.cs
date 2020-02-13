using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool unlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if(unlocked)
        {
            Destroy(gameObject);
        }
    }
}
