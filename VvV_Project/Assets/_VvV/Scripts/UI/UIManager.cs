using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEditor;

/// <summary>
///	 Objectives for the Alpha Level
/// </summary>

public class UIManager : MonoBehaviour
{
    ///***  Variables
    [Header("Objective bool check")]
    public bool batteryActive = false;
    public bool serverActive = false;
    public bool electricityActive = false;
    public bool empActive = false;

    //[Header("Battery Feedback")]
    //public bool testBatteryUI = false;
    //public HUDBatteryBar batteryUI = null;
    //public float maxBatteryCharge = 100f;
    //public float currentBatteryCharge = 0f;
    ////private float batteryChargeOverTime = 0f;
    //private float handOffBatteryCharge = 0f;

    [Header("Health Feedback")]
    public bool testPlayerHealthUI = false;
    [SerializeField]
    private Transform playerPrefab = null;
    public Slider healthUI = null;
    private UIPlayerHealth healthUIScript = null;
    //private GameObject healthUIGO = null;
    public float playerMaxHealthChild = 5f;
    public float currentPlayerHealthChild = 5f;
    public int damageTest = 1;
    public BlinkUIHealth blinkUIHealth = null;
    public PlayerDamagable damageDeltScript;
    public int somethingDamage = 0;

    private void Awake()
    {
       
    }

    void Start()
    {
        ///  Awake Declarations
        #region			<-- TOP
        /// Linked to Battery functions
        //batteryUI.SetMaxEMPCharge(maxBatteryCharge);

        /// Linked to Player functions
        //if (playerPrefab == null)
        //{
        //    playerPrefab = Entity_Tracker.Instance.PlayerEntity;
        //}

        //if (playerPrefab != null) {
        //    healthUIScript = playerPrefab.GetComponent<PlayerHUD>().hudGO.GetComponent<UIPlayerHealth>();
        //    //healthUIScript.SetMaxPlayerHealth(playerMaxHealthChild);
        //}


        //healthUIScript.gameObject.SetActive(false);
        #endregion		<-- BOTTOM
        
    }

    void Update()
    {
        /// Functions for testing UI
        //DeleteFunctionsAfterBuildingTestingIsComplete();
        DeleteFunctionsAfterPlayerHPTestingIsComplete();
    }


    /////***  GAME OBJECTIVES TEST: Activate bool with keycode for UI tests
    //#region			<-- TOP
    ///// Turn on Test: for building
    //private void DeleteFunctionsAfterBuildingTestingIsComplete()
    //{
    //    if (testBatteryUI == true)
    //    {
    //        ///  Activate all Objectives via bool
    //        if (Input.GetKeyDown(KeyCode.Alpha1))
    //        {
    //            batteryActive = !batteryActive;
    //            serverActive = !serverActive;
    //            electricityActive = !electricityActive;
    //            empActive = !empActive;
    //        }

    //        ///  Test: the Charge
    //        if (Input.GetKeyDown(KeyCode.Alpha2))
    //        {
    //            empActive = !empActive;
    //        }

    //        ///  Test: the Charge
    //        if (Input.GetKeyDown(KeyCode.Alpha3))
    //        {
    //            batteryActive = !batteryActive;
    //        }

    //        ///  Test: the Charge
    //        if (Input.GetKeyDown(KeyCode.Alpha4))
    //        {
    //            serverActive = !serverActive;
    //        }

    //        ///  Test: the Charge
    //        if (Input.GetKeyDown(KeyCode.Alpha5))
    //        {
    //            electricityActive = !electricityActive;
    //        }

    //        TestBatteryCharging();
    //    }

    //}
    //#endregion		<-- BOTTOM

    //public void BatteryIsMaxed()
    //{
    //    if (maxBatteryCharge == currentBatteryCharge)
    //    {
    //        // Change text to EMP Ready when it reaches 100%
    //    }
    //}


    /////***  BATTERY TEST: charge and color change
    //#region			<-- TOP
    //public void TestBatteryCharging()
    //{
    //    batteryUI.SetEMPCharge(currentBatteryCharge);

    //    if (Input.GetKeyDown(KeyCode.Alpha9) && batteryActive == true)
    //    {
    //        ChargingBattery(10f);
    //    }

    //    if (Input.GetKey(KeyCode.Alpha0) && batteryActive == true)
    //    {
    //        ChargeBatteryByTime();
    //        ChargingBattery(handOffBatteryCharge);
    //    }
    //}

    /////***  Battery charge logic        /// Practicing parameters
    //public void ChargingBattery(float iCharge)
    //{
    //    currentBatteryCharge += iCharge;
    //}

    /////  Test: battery charge
    //public void ChargeBatteryByTime()
    //{
    //    currentBatteryCharge++;
    //}
    //#endregion		<-- BOTTOM


    ///***  PLAYER HEALTH TEST: display and blinking
    public void DeleteFunctionsAfterPlayerHPTestingIsComplete()
    {
        if (testPlayerHealthUI == true)
        {
            /// Add bypass functions here
            //TestPlayerHealthUI();
        }
    }


    public void UpdatePlayerHP(int playerHP)
    {
        //currentPlayerHealthChild = playerPrefab.GetComponent<PlayerDamagable>().currentHitPoint;
        //healthUIScript.SetPlayerHealth(currentPlayerHealthChild);
    }

    //public void TestPlayerHealthUI()
    //{
    //    healthUIScript.SetPlayerHealth(currentPlayerHealthChild);

    //    ///  Test: the Charge
    //    if (Input.GetKeyDown(KeyCode.Alpha9))
    //    {
    //        TestHealthDamage(damageTest);
    //        healthUI.gameObject.SetActive(true);

    //    }

    //    ///  Test: the Charge
    //    if (Input.GetKey(KeyCode.Alpha0))
    //    {
    //        TestHealthDamage(playerMaxHealthChild);
    //        healthUI.gameObject.SetActive(true);

    //    }
    //}

    //public void TestHealthDamage(float damagesent)
    //{
    //    healthUI.gameObject.SetActive(false);
    //    currentPlayerHealthChild = currentPlayerHealthChild - damagesent;


    //        damageDeltScript.GetDamaged(damageTest);
    //        blinkUIHealth.BlinkingSlider(healthUI.gameObject, 1f);
    //        blinkUIHealth.isBlinking = true;

    //    if (currentPlayerHealthChild <= 0)
    //    {
    //        PlayerIsDead();

    //    }
    //}

    //public void PlayerIsDead()
    //{

    //    print("DeadUI");
    //}


}