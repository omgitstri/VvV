using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : Damagable
{
    private float delay = 0;
    [SerializeField]private Hitpoints hitpoints = null;
    public int damageable = 15;

    public void Start() {
        hitpoints = GetComponent<Hitpoints>();
    }

    public override void GetDamaged(float dmg)
    {
        if (hitpoints!= null && damageable > 0) {
            damageable -= 1;
            hitpoints.GetDamaged(dmg);

            if (damageable <= 0) { damageable = 0; } 
        }

        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        delay = 2f;

        StartCoroutine(Invul());

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

    public IEnumerator Invul() {
        yield return new WaitForSeconds(2f);
        damageable = 15;
    }
}
