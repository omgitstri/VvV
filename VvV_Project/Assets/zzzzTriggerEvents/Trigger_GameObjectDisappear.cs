using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///		The idea is to make the startpoint disapear when the player looks away. Like in star trek, when they enter the holodeck, the door disappear
///		NOTE: we might need to cutout a hole for the Entrance Zone
///	</summary>

public class Trigger_GameObjectDisappear : MonoBehaviour
{
    // Variables
    [SerializeField]
    private bool destroyInstead = false;
    [SerializeField]
    private GameObject entrance = null;
    private bool leftZone = false;


    void Start()
    {
        //entrance = GetComponent<>();
        
        //if (meshCover.enabled == true)
        //{
        //	meshCover = GetComponent<MeshRenderer>();
        //	meshCover.enabled = false;
        //}
    }

    void Update()
    {
        Trigger_DoorDisappear();
    }

    private void Trigger_DoorDisappear()
    {
        //if ( leftZone == true && Renderer.OnBecameInvisible() == false)
        //{
        // if (destroyInstead == false)
        // {
        //      disable entrance;
        // }
        //
        // else
        // {
        //      destroy entrance;
        // }
        // 
        // (we might need something to cover)
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other == player)
        //{
        //	leftZone = true;
        //}

    }


}