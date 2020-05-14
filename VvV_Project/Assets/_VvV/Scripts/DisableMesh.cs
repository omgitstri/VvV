using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///      Disable this.gameObject Mesh on Start
/// </summary>

public class DisableMesh : MonoBehaviour
{
    // Variables
    public bool onAwake = true;
    private MeshRenderer rend;


    void Awake()
    {
        DisableMeshOnStart();
    }

    public void DisableMeshOnStart()
    {
        if (onAwake == true)
        {
            rend = GetComponent<MeshRenderer>();
            rend.enabled = false;
        }
    }
}