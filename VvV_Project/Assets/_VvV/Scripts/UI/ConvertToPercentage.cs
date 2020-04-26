using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	/// <summary>
	///	 This script should be attached to the Text Object and Assigned via "On Value Changed"
	///	 Drag/Drop Text Object into "None" field. Select function under "Dynamic float"
	/// </summary>


public class ConvertToPercentage : MonoBehaviour
{
	///***  Variables
	private Text percentValue;


	void Start()
	{
		percentValue = GetComponent<Text>();
	}


	///  Convert Percentage to Text		///  Add "* 100* to value if value is not normalized
	public void ImageToTextPercentage(float iValue)
	{
		percentValue.text = Mathf.RoundToInt(iValue) + "%";
	}

}