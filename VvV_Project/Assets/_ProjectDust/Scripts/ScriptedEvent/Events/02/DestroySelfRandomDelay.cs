using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfRandomDelay : MonoBehaviour
{
    [ContextMenu("TestTrigger")]
    public void PlayTrigger()
    {
        Destroy(gameObject, Random.Range(0f, 1f));
    }
}
