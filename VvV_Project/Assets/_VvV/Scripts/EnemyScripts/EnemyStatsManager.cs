using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// - - - - - SCRIPT TO MANAGE ENEMY STATS - - - - - 
public class EnemyStatsManager : MonoBehaviour
{

    /// Handlers
    private EnemyMovementState enemyMovement;
    [SerializeField] private float pwrUpMulti = 0.20f;
    [SerializeField] private int maxStat = 10;



    public void PowerUp(EnemyStats eStats)
    {
        if (eStats.cooldown == false)
        {
            eStats.cooldown = true;

            // Increase RegenSpeed, AttackSpeed, MoveSpeed, & AggroRange according to Regen count
            eStats.regen += 1; // int regen

            if (eStats.currentTransform.localScale.x < 2f)
            {

                eStats.currentTransform.localScale = eStats.currentTransform.localScale + (Vector3.one * 0.1f);
            }

            if (eStats.regen >= maxStat)
            {
                eStats.regen = maxStat;
                eStats.isMaxed = true;
            }

            if (!eStats.isMaxed)
            {
                eStats.minRegenSpeed += pwrUpMulti; // Regen speed
                                                    //eStats.atkSpd -= pwrUpMulti; // Attack speed
                eStats.moveSpd += pwrUpMulti; // Move speed
                                              //eStats.aggroRng += pwrUpMulti; // Aggro range
                                              //eStats.lostRngDur += pwrUpMulti; // Lost Range Duration
            }

        }
    }
}
