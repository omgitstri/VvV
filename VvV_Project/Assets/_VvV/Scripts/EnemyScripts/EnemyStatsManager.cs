using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// - - - - - SCRIPT TO MANAGE ENEMY STATS - - - - - 
public class EnemyStatsManager : MonoBehaviour {

    /// Handlers
    private EnemyMovementState enemyMovement;
    [SerializeField] private float pwrUpMulti = 0.15f;
    [SerializeField] private float maxStat = 3f; 

    public void PowerUp(EnemyStats eStats) {
        // Increase RegenSpeed, AttackSpeed, MoveSpeed, & AggroRange according to Regen count
        eStats.regen += 1; // int regen

        if (eStats.moveSpd >= maxStat) {
            eStats.moveSpd = maxStat;
            eStats.isMaxed = true;
        }

        if (!eStats.isMaxed) {
            eStats.regSpd += pwrUpMulti; // Regen speed
            eStats.atkSpd -= pwrUpMulti; // Attack speed
            eStats.moveSpd += pwrUpMulti; // Move speed
            eStats.aggroRng += pwrUpMulti; // Aggro range
            eStats.lostRngDur += pwrUpMulti; // Lost Range Duration
        }
    }
}
