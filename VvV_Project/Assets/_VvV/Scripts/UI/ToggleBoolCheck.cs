using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///      
/// </summary>

public class ToggleBoolCheck : MonoBehaviour
{
    // Variables
    // [Header("SectionTitle")]	[Tooltip("HighlightInfo")]
    public UIManager uiHandler;
    private Toggle setParent = null;

    [Header("Toggle is liked to bool event")]
    public bool linkedToEMP = false;
    //private bool toggleEMP = false;

    public bool linkedToBattery = false;
    //private bool toggleBattery = false;

    public bool linkedToServer = false;
    //private bool toggleServer = false;

    public bool linkedToElectricity = false;
    //private bool toggleElectricity = false;

    void Start()
    {
        ///***  Start declaration
        #region			<-- TOP

        setParent = GetComponent<Toggle>();

        /// UIManager bool Handler
        //toggleEMP = uiHandler.empActive;
        //toggleBattery = uiHandler.batteryActive;
        //toggleServer = uiHandler.electricityActive;
        //toggleElectricity = uiHandler.electricityActive;

        #endregion		<-- BOTTOM
    }


    void Update()
    {
        if(uiHandler != null)
        {
            ObjectiveEMPToggle();
            ObjectiveBatteryToggle();
            ObjectiveServerToggle();
            ObjectiveElectricityToggle();
        }
    }


    ///***  Section
    #region		<-- TOP
    /// Toggle game Objectives
    public void ObjectiveEMPToggle()
    {
        if (linkedToEMP == true)
        {
            setParent.isOn = uiHandler.empActive;
        }
    }

    public void ObjectiveBatteryToggle()
    {
        if (linkedToBattery == true)
        {
            setParent.isOn = uiHandler.batteryActive;
        }
    }

    public void ObjectiveServerToggle()
    {
        if (linkedToServer == true)
        {
            setParent.isOn = uiHandler.serverActive;
        }
    }

    public void ObjectiveElectricityToggle()
    {
        if (linkedToElectricity == true)
        {
            setParent.isOn = uiHandler.electricityActive;
        }
    }
    #endregion		<-- BOTTOM



}