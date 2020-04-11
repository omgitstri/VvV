using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : Damagable
{
    private float delay = 0;
    [SerializeField]private Hitpoints hitpoints = null;

    [Header("*Set Total Damageable to 15")]
    public int damageable = 0;
    [Range(0, 100)]
    [SerializeField] private int totalDamageable = 15;
    [Header("*Set InvulDelay to 0.06f && InvulTime to 1f")]


    [Range(0f, 5f)]
    public float invulDelay;
    [Range(0f, 5f)]
    public float invulTime;

    public void Start() {
        hitpoints = GetComponent<Hitpoints>();
        damageable = totalDamageable;
    }

    public override void GetDamaged(float dmg)
    {
        if (hitpoints!= null && damageable > 0) {
            damageable -= 1;
            hitpoints.GetDamaged(dmg);

            // If the damageable count has reached zero, trigger invincibility immediately - this is to prevent overkill from enemies
            if (damageable <= 0) {
                damageable = 0;
                StartCoroutine(StartInvul());
            } 
        }

        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        delay = 2f;

        StartCoroutine(StartInvul());

    }

    private void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.gray);
            GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
    }

    // Coroutine to manage Invulnerability state
    public IEnumerator StartInvul() {
        yield return new WaitForSeconds(invulDelay); //InvulDelay is the delay after getting hit that leads to invincibility
        Invul();

        yield return new WaitForSeconds(invulTime); //InvulTime is the delay from invincibility & back to normal state
        RestoreNormal();
    }

    //Function activating the hit invincibility
    public void Invul() {
        gameObject.layer = 31;
    }


    //Function restoring the player back to normal state
    public void RestoreNormal() {
        damageable = totalDamageable;
        gameObject.layer = 0;
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.gray);
        GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
    }
}
