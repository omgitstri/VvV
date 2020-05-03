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
    //[SerializeField]
    //private Gradient gradientColour = null;
    [SerializeField]
    private Image fill = null;
    [SerializeField]
    private Image invulnable = null;
    private float currentAmount = 1;

    private PlayerDamagable playerDamagable = null;
    private float invulnerabilityTime = 0;

    ///***  Function
    ///  Associated to the EMP Bar
    #region <-- TOP 
    private void Awake()
    {
        playerDamagable = GetComponentInParent<PlayerDamagable>();
    }


    private void Start()
    {
        StartCoroutine(nameof(HealthBarStatus));
        invulnerabilityTime = playerDamagable.GetInvulnerableTime();
    }

    IEnumerator HealthBarStatus()
    {
        while (true)
        {
            if (playerDamagable.GetInvulnerableDelay() < 0)
            {
                currentAmount = playerDamagable.HealthPercentage();
            }
            else
            {
                invulnable.fillAmount = Mathf.Lerp(playerDamagable.HealthPercentage(), currentAmount, playerDamagable.GetInvulnerableDelay() / playerDamagable.GetInvulnerableTime());
            }
            HealthBarColor();
            HealthBarValue();
            yield return null;
        }
    }

    private void HealthBarValue()
    {
        fill.fillAmount = playerDamagable.HealthPercentage();
    }

    private void HealthBarColor()
    {
        if (playerDamagable.GetInvulnerableDelay() < 0)
        {
            if (playerDamagable.HealthPercentage() < 0.3f)
            {
                fill.color = Color.red;
            }
            else if (playerDamagable.HealthPercentage() < 0.7f)
            {
                fill.color = Color.yellow;
            }
            else
            {
                fill.color = Color.green;
            }
        }
        else
        {
            fill.color = Color.gray;
        }
    }


    #endregion		<-- BOTTOM


}