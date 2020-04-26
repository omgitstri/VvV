using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///	 UI Functions associated to the Battery fill status
/// </summary>

public class BatteryBar : MonoBehaviour
{
	///  Variables
	[SerializeField]
	private Slider batterySlider = null;
	[SerializeField]
	private Gradient gradientColour = null;
	[SerializeField]
	private Image fill = null;


	///***  Function
	///  Associated to the EMP Bar
	#region <-- TOP 
	///  Receive max health and value
	public void SetMaxEMPCharge(float incomingValue)
	{
		batterySlider.maxValue = incomingValue;
		batterySlider.value = incomingValue;

		fill.color = gradientColour.Evaluate(batterySlider.normalizedValue);
	}

	///  Fetching the Slider
	public void SetEMPCharge(float incomingValue)
	{
		batterySlider.value = incomingValue;

		fill.color = gradientColour.Evaluate(batterySlider.normalizedValue);
	}

	#endregion <-- BOTTOM

}