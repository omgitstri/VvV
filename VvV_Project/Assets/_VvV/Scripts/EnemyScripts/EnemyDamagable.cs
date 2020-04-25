using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagable : Damagable
{
    private IndividualCube individualCube = null;
    Camera cam = null;
    Collider col = null;

    private void Start()
    {
        cam = Entity_Tracker.Instance.PlayerEntity.GetComponentInChildren<Camera>();
        if (TryGetComponent<IndividualCube>(out IndividualCube cube))
        {
            individualCube = cube;
        }
        col = GetComponent<Collider>();
    }

    //private void Update()
    //{
    //    if (individualCube.killed == false
    //        && cam.WorldToViewportPoint(transform.position).x > 0.4
    //        && cam.WorldToViewportPoint(transform.position).x < 0.6
    //        && cam.WorldToViewportPoint(transform.position).y > 0.4
    //        && cam.WorldToViewportPoint(transform.position).y < 0.6)
    //    {
    //        if (col.enabled == false)
    //        {
    //            col.enabled = true;
    //        }
    //    }
    //    else if(col == true)
    //    {
    //        col.enabled = false;
    //    }
    //}

    public override void GetDamaged(int dmg)
    {
        //base.Hit();
        if (transform.CompareTag("WeakPoint"))
        {
            //transform.root.GetComponent<CreateAdjacencyGraph>().RegenManager();
            individualCube.DestroyParent();
        }

        if (transform.CompareTag("Enemy"))
        {
            //Have fun~ ( ￣ 3￣)y▂ξ

            individualCube.MarkAsHit(2);

            if (transform.root.TryGetComponent<CreateAdjacencyGraph>(out CreateAdjacencyGraph weakPoint))
            {
                weakPoint.DestroyHit();

                weakPoint.GetWeakPoint().CheckDetached();
                weakPoint.DestroyDetached();
            }

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
