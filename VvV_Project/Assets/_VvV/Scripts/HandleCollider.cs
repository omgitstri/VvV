using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   
/// </summary>

public class HandleCollider : MonoBehaviour
{
    // Variables
    public Transform myObject;
    Rigidbody[] childRigidbodys;
    

    public void DestroyColliders()
    {
        childRigidbodys = myObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in childRigidbodys)
        {
            rigidbody.isKinematic = true;
        }
    }
}