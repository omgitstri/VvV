using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsContainer : MonoBehaviour
{
    public EnemyStats eStats;
    public Entity_Register entityReg;

    void Awake()
    {
        //statsManager = Toolbox.GetInstance().GetStats();

        AddToCount();
        eStats.currentTransform = transform;
    }

    private void Start()
    {
        eStats.powerUpCooldown = 4;
    }

    private void Update()
    {
        if (eStats.cooldown)
        {
            if (eStats.powerUpCooldown <= 0)
            {
                eStats.powerUpCooldown = 4;
                eStats.cooldown = false;
            }
            else
            {
                eStats.powerUpCooldown -= Time.deltaTime;
            }
        }
    }

    public void AddToCount()
    {
        entityReg = GetComponent<Entity_Register>();
        //GameObject go = this.gameObject;
        //statsManager.AddEnemy(go);

    }

    // Call this function when the enemy regens to keep count & power it up;
    public void Regen()
    {
        Toolbox.GetInstance.GetStats().PowerUp(eStats);
    }
}
