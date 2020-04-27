using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///      
/// </summary>

public class UIPlayerHealth : MonoBehaviour
{
    //// Variables
    public Slider healthSlider = null;
    [SerializeField]
    private Gradient gradientColour = null;
    [SerializeField]
    private Image fill = null;

    ///***  Function
    ///  Associated to the EMP Bar
    #region <-- TOP 
    ///  Set max health and value
    public void SetMaxPlayerHealth(float incomingValue)
    {
        healthSlider.maxValue = incomingValue;
        healthSlider.value = incomingValue;

        fill.color = gradientColour.Evaluate(healthSlider.normalizedValue);
    }


    ///  Fetching the Slider
    public void SetPlayerHealth(float incomingValue)
    {
        healthSlider.value = incomingValue;

        fill.color = gradientColour.Evaluate(healthSlider.normalizedValue);
    }
    #endregion		<-- BOTTOM


}