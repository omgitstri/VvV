using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomEventDamagable : Damagable
{
    [SerializeField] private UnityEvent OnHitTrigger = null;

    public override void GetDamaged(int dmg)
    {
        OnHitTrigger.Invoke();
    }
}
