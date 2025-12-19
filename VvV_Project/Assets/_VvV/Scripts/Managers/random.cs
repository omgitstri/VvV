using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   
/// </summary>

public class random : MonoBehaviour
{
	// Variables
	public GameObject something23455465 = null;

	void Start()
	{
		something23455465 = Entity_Tracker.Instance.InteractableEntity[0].gameObject;
		Bypasssomething();
	}

	public void Bypasssomething()
	{
		Collider other = something23455465.GetComponent<Collider>();

		OnTriggerEnter(other);
	}


	private void OnTriggerEnter(Collider somethingelse)
	{
		Debug.Log(somethingelse.gameObject.name);
	}

}