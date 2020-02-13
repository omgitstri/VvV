using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    public GameObject door;
    private void OnDestroy()
    {
        Destroy(door);
    }
}
