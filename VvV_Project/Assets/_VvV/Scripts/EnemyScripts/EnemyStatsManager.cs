using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// - - - - - SCRIPT TO MANAGE ENEMY STATS - - - - - 
public class EnemyStatsManager : MonoBehaviour {

    /// Handlers
    private EnemyMovementState enemyMovement;



    public void PowerUp(EnemyStats eStats) {
        // Increase RegenSpeed, AttackSpeed, MoveSpeed, & AggroRange according to Regen count
        eStats.regen += 1; // int regen

        // eStats.regSpd += or *= or something else entirely; // Regen speed
        // eStats.atkSpd += ; // Attack speed
        // eStats.moveSpd += ; // Move speed
        // eStats.aggroRng += ; // Aggro range
        // eStats.lostRngDur += ; // Lost Range Duration

        Debug.Log("The powerup function needs to be filled!");
    }
}
