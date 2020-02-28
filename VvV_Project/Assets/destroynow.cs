using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroynow : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, Random.Range(0, 3));
    }
}
