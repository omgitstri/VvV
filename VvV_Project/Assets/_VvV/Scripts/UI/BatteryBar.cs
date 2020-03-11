using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///	 UI Functions associated to the Battery fill status
/// </summary>

public class BatteryBar : MonoBehaviour
{
	//**** Variables
	[SerializeField]
	private Slider batterySlider;
	[SerializeField]
	private Gradient gradientColour;
	[SerializeField]
	private Image fill;


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
		
	}

	void OnUpdateFunction()
	{
		
	}


	//-- Summary
	void EmptyFunctionDeclaration()
	{
		
	}
	#endregion <-- BOTTOM


	//**** Function
	//-- Associated to the EMP Bar
	#region <-- TOP 
	//-- Set max health and value
	public void SetMaxEMPCharge(float iEmpCharge)
	{
		batterySlider.maxValue = iEmpCharge;
		batterySlider.value = iEmpCharge;

		fill.color = gradientColour.Evaluate(batterySlider.normalizedValue);
	}

	//-- Fetching the Slider
	public void SetEMPCharge(float iEmpCharge)
	{
		batterySlider.value = iEmpCharge;

		fill.color = gradientColour.Evaluate(batterySlider.normalizedValue);
	}

	#endregion <-- BOTTOM

}