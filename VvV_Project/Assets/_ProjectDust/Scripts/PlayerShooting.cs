using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Camera cam;
    public float maxDistance = 200f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        RaycastHit hitInfo;
        LineRenderer line = gameObject.AddComponent<LineRenderer>();
        if (line != null)
        {
            line.positionCount = 2;
            line.startWidth = 0.02f;
            line.endWidth = 0.02f;
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, maxDistance))
        {
            if (hitInfo.transform.tag == "WeakPoint")
            {
                if (line != null)
                {
                    line.SetPositions(new Vector3[2] { cam.transform.position + cam.transform.right * 0.2f, hitInfo.point });
                }
                hitInfo.transform.GetComponent<IndividualCube>().DestroyParent();
            }

            if (hitInfo.transform.tag == "Enemy")
            {
                if (line != null)
                {
                    line.SetPositions(new Vector3[2] { cam.transform.position + cam.transform.right * 0.2f, hitInfo.point });
                }
                //Have fun~ ( ￣ 3￣)y▂ξ
                //hitInfo.transform.gameObject.GetComponent<IndividualCube>().AddRigidbodyToNeighbours();
                //print(hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>().weekPoint.GetComponent<IndividualCube>().voxelPosition);

                GameObject weakPoint = null;
                weakPoint = hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>().GetWeakPoint();

                hitInfo.transform.GetComponent<IndividualCube>().MarkAsHit(2);
                weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyHit();

                //hitInfo.transform.GetComponent<IndividualCube>().DestroyCube();
                //Destroy(hitInfo.transform.gameObject);

                weakPoint.GetComponent<IndividualCube>().CheckDetached();
                weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyDetached();
            }
        }
        if (line != null)
        {
            line.SetPositions(new Vector3[2] { cam.transform.position + cam.transform.right * 0.2f, cam.transform.forward * maxDistance });
        }
        Destroy(line, 0.2f);
    }
}
