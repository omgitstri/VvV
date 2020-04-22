using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsContainer : MonoBehaviour {
    public EnemyStats eStats;
    public Entity_Register entityReg;

    void Awake() {
        //statsManager = Toolbox.GetInstance().GetStats();

        AddToCount();
    }

    public void AddToCount() {
        entityReg = GetComponent<Entity_Register>();
        //GameObject go = this.gameObject;
        //statsManager.AddEnemy(go);

    }

    // Call this function when the enemy regens to keep count & power it up;
    public void Regen() {
        Toolbox.GetInstance.GetStats().PowerUp(eStats);
    }
}
