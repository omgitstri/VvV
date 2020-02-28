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
            var individualCube = hitInfo.transform.GetComponent<IndividualCube>();
            var adjacencyGraph = hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>();

            if (hitInfo.transform.tag == "WeakPoint")
            {
                if (line != null)
                {
                    line.SetPositions(new Vector3[2] { cam.transform.position + cam.transform.right * 0.2f, hitInfo.point });
                }
                individualCube.DestroyParent();
            }

            if (hitInfo.transform.tag == "Enemy")
            {
                if (line != null)
                {
                    line.SetPositions(new Vector3[2] { cam.transform.position + cam.transform.right * 0.2f, hitInfo.point });
                }
                //Have fun~ ( ￣ 3￣)y▂ξ

                IndividualCube weakPoint = null;
                weakPoint = adjacencyGraph.GetWeakPoint();

                weakPoint.MarkAsHit(2);
                adjacencyGraph.DestroyHit();

                weakPoint.CheckDetached();
                adjacencyGraph.DestroyDetached();
            }
        }
        if (line != null)
        {
            line.SetPositions(new Vector3[2] { cam.transform.position + cam.transform.right * 0.2f, cam.transform.forward * maxDistance });
        }
        Destroy(line, 0.2f);
    }
}
