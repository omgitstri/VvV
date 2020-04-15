using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsContainer : MonoBehaviour
{
    public Stats stats;
    public StatsManager statsManager = null;

    void Start() {
        statsManager = Toolbox.GetInstance().GetStats();
        AddToCount();
    }

    public void AddToCount() {
        GameObject go = this.gameObject;
        statsManager.AddEnemy(go);
    }


    // Call this function when the enemy regens to keep count & power it up;
    public void Regen() {
        Debug.Log("Regen'd!");
        statsManager.PowerUp(stats);
    }
}
