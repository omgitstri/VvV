using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///      Teleport object with script to attached to to set destinatio
/// </summary>

public class TeleportThisToSetDestination : MonoBehaviour
{

	public void TeleportHere(Transform destination)
	{
		transform.position = destination.position;

		//Transform thisTarget.position = destination.position;
	}

	
}