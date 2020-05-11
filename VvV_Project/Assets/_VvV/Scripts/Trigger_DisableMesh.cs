using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///      Disable Mesh of product on Start
/// </summary>

public class Trigger_DisableMesh : MonoBehaviour
{
    // Variables
    public MeshRenderer rend;
    public bool disableMesh = true;


    void Start()
    {
        if (disableMesh == true)
        {
            rend = GetComponent<MeshRenderer>();
            rend.enabled = false;
        }


    }

}