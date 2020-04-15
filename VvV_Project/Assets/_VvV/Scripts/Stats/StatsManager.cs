using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// - - - - - SCRIPT TO MANAGE ENEMY STATS - - - - - 
public class StatsManager : MonoBehaviour {

    public List<GameObject> enemyList = new List<GameObject>();
    public int x = 0;

    // Call AddEnemy(enemy); from SpawnManager/Director script
    public void AddEnemy(GameObject go) {
        enemyList.Add(go);
        go.name = "Enemy " + x;
        x++;
    }

    // Call Remove(enemy) if required (should not be in VvV's case)
    public void RemoveEnemy(GameObject enemy) {
        enemyList.Remove(enemy);
    }



    public void PowerUp(Stats stats) {
        // Increase RegenSpeed, AttackSpeed, MoveSpeed, & AggroRange according to Regen count
        stats.regen += 1;
    }


}
