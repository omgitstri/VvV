using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damagable : MonoBehaviour
{
    public float getDamageParent = 1f;


    public virtual void GetDamaged(float dmg)
    {
        print("Parent of GetDamage()");
    }
    
}
