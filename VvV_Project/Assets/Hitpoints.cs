using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoints : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField]private float hp = 100f;

    private void Update() {
        if (hp <= 0) {
            hp = 0;
            Death();
        }
    }

    private void Regenerate() {
        int recRate = 1;
        hp += recRate;
    }

    private void Heal(float heal) {
        hp += heal; 
    }

    public void GetDamaged(float dmg) {
        hp -= dmg;
    }
   
    private void Death() {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.black);
        GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }
}
