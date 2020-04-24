using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///	 Objectives for the Alpha Level
/// </summary>

public class UIManager : MonoBehaviour
{
    ///***  Variables
    public float maxBatteryCharge = 1f;
    public float currentBatteryCharge = 0f;
    public float batteryChargeOverTime = 0f;

    public BatteryBar batteryBar = null;

    public bool batteryActive = false;
    public bool serverActive = false;
    public bool electricityActive = false;
    public bool empActive = false;

    private float handOffBatteryCharge = 0f;

    #region			<-- TOP
    ///


    #endregion		<-- BOTTOM

    void Start()
    {
        ///  Start Declarations
        #region			<-- TOP

        batteryBar.SetMaxEMPCharge(maxBatteryCharge);
        #endregion		<-- BOTTOM
    }

    void Update()
    {
        ///  Update Declarations
        #region			<-- TOP

        ///
        AllBuildingsActive();
        BatteryBuildingsActive();
        ElectricityBuildingsActive();
        ServerBuildingsActive();
        EMPBuildingsActive();

        TestBuildingStatus();
        #endregion		<-- BOTTOM
    }


    ///***  ALPHA TESTING AREA
    ///  Temp setup for in-game testing and bypassing statements
    #region <-- TOP 

    ///  Bool activate Test
    public void AllBuildingsActive()
    {
        ///  Testing the Charge
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BoolOnjective();
        }
    }

    ///  Bool building activate state
    public void BatteryBuildingsActive()
    {
        ///  Testing the Charge
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BatteryOnjective();
        }
    }

    ///  Bool building activate state
    public void ElectricityBuildingsActive()
    {
        ///  Testing the Charge
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ElectricityOnjective();
        }
    }

    ///  Bool building activate state
    public void ServerBuildingsActive()
    {
        ///  Testing the Charge
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ServerOnjective();
        }
    }

    ///  Bool building activate state
    public void EMPBuildingsActive()
    {
        ///  Testing the Charge
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            EmpOnjective();
        }
    }

    public void BoolOnjective()
    {
        batteryActive = !batteryActive;
        serverActive = !serverActive;
        electricityActive = !electricityActive;
        empActive = !empActive;
    }

    public void BatteryOnjective()
    {
        batteryActive = !batteryActive;
    }


    public void ServerOnjective()
    {
        serverActive = !serverActive;
    }


    private void ElectricityOnjective()
    {
        electricityActive = !electricityActive;
    }

    public void EmpOnjective()
    {
        empActive = !empActive;
    }


    ///  Testing the battery charge
    public void ChargingBattery(float iCharge)
    {
        currentBatteryCharge += iCharge;
    }

    ///  Testing battery charge
    public void ChargeBatteryByTime()
    {
        ///  Testing the Charge
        currentBatteryCharge++;
    }

    ///  Setting up bypass statements for alpha testing
    public void TestBuildingStatus()
    {
        batteryBar.SetEMPCharge(currentBatteryCharge);

        ///  Testing the Charge
        if (Input.GetKeyDown(KeyCode.Alpha9) && batteryActive == true)
        {
            ChargingBattery(10f);
            print(currentBatteryCharge);
        }

        ///  Testing the Charge
        if (Input.GetKey(KeyCode.Alpha0) && batteryActive == true)
        {
            ChargeBatteryByTime();
            ChargingBattery(handOffBatteryCharge);
        }

    }

    #endregion <-- BOTTOM

}