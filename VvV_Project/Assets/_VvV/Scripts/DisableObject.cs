using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   
/// </summary>

public class DisableObject : MonoBehaviour
{
	// Variables
	public bool onAwake = true;


    void Awake()
    {
        DisableObjectOnStart();
    }


    public void DisableObjectOnStart()
    {
        if (onAwake == true)
        {
            gameObject.SetActive(false);
        }
    }

}