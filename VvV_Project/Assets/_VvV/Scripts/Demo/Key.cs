using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyDoor door;

    private void OnTriggerEnter(Collider other)
    {
        door.unlocked = true;
        Destroy(gameObject);
    }
}
