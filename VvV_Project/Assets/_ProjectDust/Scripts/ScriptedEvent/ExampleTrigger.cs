using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTrigger : MonoBehaviour
{
    public void ExampleFunction()
    {
        print("TriggerExample" + name);
        transform.position += Vector3.up;
    }
}
