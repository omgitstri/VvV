using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSplash : MonoBehaviour
{
    Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void Splash() {
        if (anim != null) {
            anim.SetTrigger("splash");
        }
    }

    public void DeathSplash() {
        if (anim != null) {
            anim.SetTrigger("dead");
        }
    }
}
