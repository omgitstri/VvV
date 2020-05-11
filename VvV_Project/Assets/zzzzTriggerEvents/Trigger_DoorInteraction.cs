using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///      This swings doors open
/// </summary>

public class Trigger_DoorInteract : MonoBehaviour
{
	// Variables
	// [Header("SectionTitle")]	[Tooltip("HighlightInfo")]
	[SerializeField]
	private GameObject player = null;
	[SerializeField]
	private GameObject door1 = null;
	[SerializeField]
	private GameObject door2 = null;

	void Start()
	{


	}

	///***  Section
	private void OnTriggerEnter(Collider other)
	{
		//if (other == player && Input.GetKey(KeyCode.E))
		//{
		//	OpenDoorZone;
		//}
	}



}