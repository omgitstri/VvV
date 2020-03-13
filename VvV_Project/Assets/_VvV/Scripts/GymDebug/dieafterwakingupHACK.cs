using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieafterwakingupHACK : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 0.125f);
    }
}
