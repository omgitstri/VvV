﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///	 Objectives for the Alpha Level
/// </summary>

public class LevelObjective : MonoBehaviour
{
	//**** Variables
	public float maxBatteryCharge = 1f;
	public float currentBatteryCharge = 0f;
	public float batteryChargeOverTime = 0f;

	[SerializeField]
	private BatteryBar batteryBar;

	[SerializeField]
	private bool batteryActive = false;
	[SerializeField]
	private bool serverActive = false;
	[SerializeField]
	private bool electricityActive = false;
	[SerializeField]
	public bool empActive = false;

	private float handOffBatteryCharge;


	void Start()
	{
		OnStartDeclaration();
		OnStartFunction();
	}

	void Update()
	{
		OnUpdateFunction();
	}


	//**** OnFrame Call Functions
	#region <-- TOP
	//-- One Time Functions
	void OnStartDeclaration()
	{
		batteryBar.SetMaxEMPCharge(maxBatteryCharge);
	}

	void OnStartFunction()
	{

	}

	void OnUpdateFunction()
	{
		AllBuildingsActive();
		TestBuildingStatus();
	}

	#endregion <-- BOTTOM


	//**** ALPHA TESTING AREA
	//-- Temp setup for in-game testing and bypassing statements		//-- To delete afterwards
	#region <-- TOP 

	//-- Bool building activate state
	void AllBuildingsActive()
	{
		//-- Testing the Charge
		if (Input.GetKeyDown(KeyCode.Q))
		{
			BoolOnjective();
		}
	}

	//-- Bool building activate state
	void BatteryBuildingsActive()
	{
		//-- Testing the Charge
		if (Input.GetKeyDown(KeyCode.W))
		{
			BatteryOnjective();
		}
	}

	//-- Bool building activate state
	void ElectricityBuildingsActive()
	{
		//-- Testing the Charge
		if (Input.GetKeyDown(KeyCode.E))
		{
			ElectricityOnjective();
		}
	}

	//-- Bool building activate state
	void ServerBuildingsActive()
	{
		//-- Testing the Charge
		if (Input.GetKeyDown(KeyCode.R))
		{
			ServerOnjective();
		}
	}

	//-- Bool building activate state
	void EMPBuildingsActive()
	{
		//-- Testing the Charge
		if (Input.GetKeyDown(KeyCode.T))
		{
			EmpOnjective();
		}
	}

	private void BoolOnjective()
	{
		batteryActive = !batteryActive;
		serverActive = !serverActive;
		electricityActive = !electricityActive;
		empActive = !empActive;
	}

	private void BatteryOnjective()
	{
		batteryActive = !batteryActive;
	}


	private void ServerOnjective()
	{
		serverActive = !serverActive;
	}


	private void ElectricityOnjective()
	{
		electricityActive = !electricityActive;
	}
	
	private void EmpOnjective()
	{
		empActive = !empActive;
	}


	//-- Testing the battery charge
	void ChargingBattery(float iCharge)
	{
		currentBatteryCharge += iCharge;
	}

	//-- Testing battery charge
	void ChargeBatteryByTime()
	{
		//-- Testing the Charge
		currentBatteryCharge++;
	}

	//-- Setting up bypass statements for alpha testing
	void TestBuildingStatus()
	{
		batteryBar.SetEMPCharge(currentBatteryCharge);

		//-- Testing the Charge
		if (Input.GetKeyDown(KeyCode.Alpha1) && batteryActive == true)
		{
			ChargingBattery(10f);
			print(currentBatteryCharge);
		}

		//-- Testing the Charge
		if (Input.GetKey(KeyCode.Alpha2) && batteryActive == true)
		{
			ChargeBatteryByTime();
			ChargingBattery(handOffBatteryCharge);
			print(currentBatteryCharge);
		}

	}

	#endregion <-- BOTTOM

}