using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPDamagable : Damagable
{
    private int totalHit = 3;
    [SerializeField] GameObject text;

    public override void GetDamaged()
    {
        if (totalHit > 0)
        {
            totalHit -= 1;
        }
        else
        {
            if (TryGetComponent<Renderer>(out Renderer render))
            {
                text.SetActive(true);
                render.material.SetColor("_BaseColor", Color.green);
            }
        }
    }
}
