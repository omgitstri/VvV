using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSplash : MonoBehaviour
{
    /* Script that is used to toggle the damage splash screen effect using an animator */

    Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    // Splash effect on damage
    public void Splash() {
        if (anim != null) {
            anim.SetTrigger("splash");
        }
    }

    // Splash on death
    public void DeathSplash() {
        if (anim != null) {
            anim.SetTrigger("dead");
        }
    }
}
