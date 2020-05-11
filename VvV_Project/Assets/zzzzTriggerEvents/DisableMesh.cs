using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///      Disable this.gameObject Mesh on Start
/// </summary>

public class DisableMesh : MonoBehaviour
{
    // Variables
    public bool disableMeshOnStart = true;
    private MeshRenderer rend;


    void Awake()
    {
        if (disableMeshOnStart == true)
        {
            rend = GetComponent<MeshRenderer>();
            rend.enabled = false;
        }
    }
}