using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	/// <summary>
	///	 
	/// </summary>

public class OnStartUp : MonoBehaviour
{
	//**** Variables
	[Header("Grey Colour Material")]
	[SerializeField]
	private Material disabledColour;
	public List<GameObject> disabledColourOnStartUp;

	[Header("Disabled Mesh")]
	[SerializeField]
	private Material changeMaterial;
	public List<GameObject> changeMaterialOnStartUp;


	void Start()
	{
		OnStartDeclaration();
		OnStartFunction();
	}

	void Update()
	{
		OnUpdateFunction();

	}


	//**** OnFrame Functions
	#region <-- TOP
	//-- One Time Functions
	void OnStartDeclaration()
	{
		
	}

	void OnStartFunction()
	{
		ChangeColourOnStartUp();
	}

	void OnUpdateFunction()
	{
		
	}


	//-- Change Material reference
	void ChangeColourOnStartUp()
	{
		foreach (var obj in disabledColourOnStartUp)
			obj.GetComponent<Renderer>().material = disabledColour;
			
	}
	#endregion <-- BOTTOM
}