using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IndividualCube>() != null)
        {
            if (other.transform.tag == "WeakPoint")
            {
                other.transform.GetComponent<IndividualCube>().DestroyParent();
            }

            if (other.transform.tag == "Enemy")
            {
                other.transform.GetComponent<IndividualCube>().DestroyParent();
                return;
                //Have fun~ ( ￣ 3￣)y▂ξ
                //hitInfo.transform.gameObject.GetComponent<IndividualCube>().AddRigidbodyToNeighbours();
                //print(hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>().weekPoint.GetComponent<IndividualCube>().voxelPosition);

                GameObject weakPoint = null;
                weakPoint = other.transform.root.GetComponent<CreateAdjacencyGraph>().GetWeakPoint();

                other.transform.GetComponent<IndividualCube>().MarkAsHit(2);
                weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyHit();

                //hitInfo.transform.GetComponent<IndividualCube>().DestroyCube();
                //Destroy(hitInfo.transform.gameObject);

                weakPoint.GetComponent<IndividualCube>().CheckDetached();
                weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyDetached();
            }
        }

        //if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, currentGun.range))
        //{
        //    GameObject hitEffect = Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        //    Destroy(hitEffect, 2f);

        //    if (hitInfo.transform.tag == "WeakPoint")
        //    {
        //        hitInfo.transform.GetComponent<IndividualCube>().DestroyParent();
        //    }

        //    if (hitInfo.transform.tag == "Enemy")
        //    {
        //        //Have fun~ ( ￣ 3￣)y▂ξ
        //        //hitInfo.transform.gameObject.GetComponent<IndividualCube>().AddRigidbodyToNeighbours();
        //        //print(hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>().weekPoint.GetComponent<IndividualCube>().voxelPosition);

        //        GameObject weakPoint = null;
        //        weakPoint = hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>().GetWeakPoint();

        //        hitInfo.transform.GetComponent<IndividualCube>().MarkAsHit(2);
        //        weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyHit();

        //        //hitInfo.transform.GetComponent<IndividualCube>().DestroyCube();
        //        //Destroy(hitInfo.transform.gameObject);

        //        weakPoint.GetComponent<IndividualCube>().CheckDetached();
        //        weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyDetached();
        //    }
        //}
    }
}
