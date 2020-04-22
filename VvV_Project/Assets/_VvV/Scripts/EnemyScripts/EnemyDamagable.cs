using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagable : Damagable
{
    private IndividualCube individualCube = null;

    private void Start()
    {
        if (TryGetComponent<IndividualCube>(out IndividualCube cube))
        {
            individualCube = cube;
        }
    }

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
    private void OnBecameVisible()
    {
        //Debug.Log("visible");
        GetComponent<BoxCollider>().enabled = true;
    }

    private void OnBecameInvisible()
    {
        //Debug.Log("invisible");
        GetComponent<BoxCollider>().enabled = false;
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
