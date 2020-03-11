using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	/// <summary>
	///	 
	/// </summary>

public class AlterDisplayText : MonoBehaviour
{
	//**** Variables
	public Text displayText;


	void Start()
	{
		displayText = GetComponent<Text>();
	}


	//-- Convert Percentage to Text		//-- Add "* 100* to value if value is not normalized
	public void ImageToTextPercentage(string iText)
	{
		displayText.text = iText;
	}

}