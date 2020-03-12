using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	/// <summary>
	///	 
	/// </summary>

public class StructureHp : MonoBehaviour
{
	//**** Variables
	public float maxHP = 10f;
	public float currentHp = 10f;
	public float damageReceived = 5f;
	public List<GameObject> disabledColourOnStartUp;

	[SerializeField]
	private Material disabledColour;


	void Start()
	{
		OnStartDeclaration();
	}

	void Update()
	{
		OnUpdateFunction();
	}


	//**** OnFrame Call Functions
	//-- Call Functions for Start(), Update(), Awake(), etc.
	#region <-- TOP

	//-- Declaring Functions
	void OnStartDeclaration()
	{
		BuildingHp();
	}

	//-- Single Start() Functions
	void OnUpdateFunction()
	{
		TestDamage();
	}

	#endregion <-- BOTTOM

	//-- Enemy check
	public void OnCollisionEnter(Collider other)
	{
		if (other.GetComponent<CreateAdjacencyGraph>())
		{
			GetComponent<StructureHp>().TestDamage();
		}
	}
	

	//**** __Summary
	//-- __Summary
	#region <-- TOP

	//-- __Summary
	void BuildingHp()
	{
		currentHp = 10f;
	}

	//-- __Summary
	public void TestDamage()
	{
		//if (Input.GetKeyDown(KeyCode.Alpha9) && currentHp >= 0F)
		//{
			currentHp -= damageReceived;
		//}

		DisableColour();
	}
	void DisableColour()
	{
		if (currentHp <= 0)
		{
			foreach (var obj in disabledColourOnStartUp)
				obj.GetComponent<Renderer>().material = disabledColour;
		}
	}

	#endregion <-- BOTTOM
}