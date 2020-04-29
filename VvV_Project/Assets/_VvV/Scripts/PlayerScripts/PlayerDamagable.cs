using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : Damagable
{

    [SerializeField] private int currentHitPoint = 5;
    [SerializeField] private int maxHitPoint = 5;

    [SerializeField] private float invulnerableDelay = 0;
    [SerializeField] private float invulnerableTime = 3;


    private void Start()
    {
        currentHitPoint = maxHitPoint;
    }

    public float HealthPercentage()
    {
        return (float)currentHitPoint / (float)maxHitPoint;
    }

    public float GetInvulnerableDelay()
    {
        return invulnerableDelay;
    }

    public float GetInvulnerableTime()
    {
        return invulnerableTime;
    }

    public override void GetDamaged(int dmg)
    {

        Toolbox.GetInstance.GetUI().UpdatePlayerHP(currentHitPoint);
        if (currentHitPoint > 0 && invulnerableDelay <= 0)
        {
            currentHitPoint -= dmg;
            invulnerableDelay = invulnerableTime;
        }
    }

    private void Update()
    {
        //triggered damage 
        if (invulnerableDelay > 0)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        //reset vulnerability
        else if(invulnerableDelay < 0 && currentHitPoint > 0)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.gray);
            GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        //dead
        else
        { 
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.black);
            GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        }

        invulnerableDelay -= Time.deltaTime;
        PlayerDeath();
    }

    private void PlayerDeath() {

        if (currentHitPoint <= 0) {
            Toolbox.GetInstance.GetScene().ReloadScene();
        }

    }
}
