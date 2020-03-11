﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagable : Damagable
{
    private IndividualCube individualCube = null;

    private void Start()
    {
        individualCube = GetComponent<IndividualCube>();
    }

    public override void GetDamaged()
    {
        //base.Hit();
        if (transform.CompareTag("WeakPoint"))
        {
            individualCube.DestroyParent();
        }

        if (transform.CompareTag("Enemy"))
        {
            //Have fun~ ( ￣ 3￣)y▂ξ
            var weakPoint = transform.root.GetComponent<CreateAdjacencyGraph>();

            individualCube.MarkAsHit(2);
            weakPoint.DestroyHit();

            weakPoint.GetWeakPoint().CheckDetached();
            weakPoint.DestroyDetached();
        }

    }
}



        //if (transform.CompareTag("WeakPoint"))
        //{
        //    individualCube.DestroyParent();
        //}

        //if (transform.CompareTag("Enemy"))
        //{
        //    //Have fun~ ( ￣ 3￣)y▂ξ
        //    IndividualCube weakPoint = null;
        //    weakPoint = transform.root.GetComponent<CreateAdjacencyGraph>().GetWeakPoint();

        //    individualCube.MarkAsHit(2);
        //    weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyHit();

        //    weakPoint.GetComponent<IndividualCube>().CheckDetached();
        //    weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyDetached();
        //}