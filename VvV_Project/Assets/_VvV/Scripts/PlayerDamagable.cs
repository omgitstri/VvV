using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : Damagable
{
    private float delay = 0;

    public override void GetDamaged()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        delay = 2f;
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
}
