using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamagableHACK : Damagable
{

    public GameObject sphere = null;
    public List<Rigidbody> rbList = new List<Rigidbody>();

    private void Start()
    {

        rbList.AddRange(transform.GetComponentsInChildren<Rigidbody>());
        
    }

    public override void GetDamaged(float dmg)
    {
        GetComponent<Collider>().enabled = false;
        foreach (var item in rbList)
        {
            item.isKinematic = false;
        }

        sphere.SetActive(true);
    }
}
