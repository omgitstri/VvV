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

    public override void GetDamaged(int dmg)
    {
        if (currentHitPoint > 0 && invulnerableDelay <= 0)
        {
            currentHitPoint -= dmg;
            invulnerableDelay = invulnerableTime;
        }
    }

    private void Update()
    {
        if (invulnerableDelay > 0)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else if(invulnerableDelay < 0 && currentHitPoint > 0)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.gray);
            GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        else
        { 
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.black);
            GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        }

        invulnerableDelay -= Time.deltaTime;
    }
}
