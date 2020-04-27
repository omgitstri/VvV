using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///	 UI Functions associated to the Battery fill status
/// </summary>

public class HUDBatteryBar : MonoBehaviour
{
    ///  Variables
    [SerializeField] private Slider batterySlider = null;
    [SerializeField] private Gradient gradientColour = null;
    [SerializeField] private Image fill = null;

    ///***  Section
    #region		<-- TOP
    /// CommentEmpty

    #endregion		<-- BOTTOM


    private void Awake()
    {

        ///***  Fetch self components
        #region		<-- TOP
        if (batterySlider == null)
        {
            batterySlider = GetComponent<Slider>();
        }

        if (fill == null)
        {
            fill = GetComponentInChildren<Image>();
        }

        #endregion		<-- BOTTOM


    }


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