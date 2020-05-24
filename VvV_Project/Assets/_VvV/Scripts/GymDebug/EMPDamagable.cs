using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPDamagable : Damagable
{
    [SerializeField] LerpGeneric pipe = null;
    [SerializeField] float _invulnerable = 5f;
    float invulnerable = 5f;
    bool damaged = false;

    private void Start()
    {
        invulnerable = _invulnerable;
    }

    private void Update()
    {
        if (damaged)
        {
            invulnerable -= Time.deltaTime;
            if (invulnerable <= 0)
            {
                damaged = false;
                invulnerable = _invulnerable;
            }
        }
    }

    public override void GetDamaged(int dmg)
    {
        if (!damaged)
        {
            pipe.a -= 5f;
            damaged = true;
        }
    }
}
