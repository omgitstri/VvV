using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///      
/// </summary>

public class ObjectiveToggleBoolCheck : MonoBehaviour
{
    // Variables
    // [Header("SectionTitle")]	[Tooltip("HighlightInfo")]
    [SerializeField]
    private UIManager uIHandler = null;
    private Toggle setParent = null;
    private Text textChild = null;

    [Header("Toggle is liked to bool event")]
    public LinkedObjective linkedObjective;
    public enum LinkedObjective
    {
        None,
        EMPActive,
        BatteryActive,
        ServerActive,
        ElectricityActive
    };


    void Start()
    {
        ///***  Start declaration
        #region			<-- TOP

        setParent = GetComponent<Toggle>();
        textChild = GetComponentInChildren<Text>();

        #endregion		<-- BOTTOM
    }


    void Update()
    {
        if (uIHandler != null)
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
        if (linkedObjective == LinkedObjective.EMPActive)
        {
            setParent.isOn = uIHandler.empActive;

            textChild.text = "EMP";
        }
    }

    public void ObjectiveBatteryToggle()
    {
        if (linkedObjective == LinkedObjective.BatteryActive)
        {
            setParent.isOn = uIHandler.batteryActive;
            textChild.text = "Battery";
        }
    }

    public void ObjectiveServerToggle()
    {
        if (linkedObjective == LinkedObjective.ServerActive)
        {
            setParent.isOn = uIHandler.serverActive;
            textChild.text = "Server";
        }
    }

    public void ObjectiveElectricityToggle()
    {
        if (linkedObjective == LinkedObjective.ElectricityActive)
        {
            setParent.isOn = uIHandler.electricityActive;
            textChild.text = "Electricity";
        }
    }
    #endregion		<-- BOTTOM

}