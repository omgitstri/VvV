using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : MonoBehaviour
{
    [SerializeField] private WaypointSystem waypointSystem = null;
    //fix this later
    [SerializeField] private Transform player = null;
    [SerializeField] private LayerMask layerMask;
    private Vector3 initPos = Vector3.zero;
    private int posIndex = 0;
    bool playerInRange = false;
    RaycastHit hitInfo = new RaycastHit();
    List<MeshRenderer> meshRenderer = new List<MeshRenderer>();

    [Range(0, 1)]
    public float a = 0;

    void UpdateInitPos()
    {
        initPos = transform.position;
    }

    private void Start()
    {
    }
        
    void Update()
    {
        meshRenderer.Clear();
        meshRenderer.AddRange(GetComponentsInChildren<MeshRenderer>());
        a += Time.deltaTime;
        if (waypointSystem != null && !playerInRange)
        {
            //Patrol();
            LookAtTarget();
        }
        else
        {
            ChasePlayer();
        }

        Physics.Raycast(transform.transform.GetChild(1).position + transform.forward * 0.5f, player.position - transform.GetChild(1).position, out hitInfo, layerMask);
        
        if (hitInfo.transform != player)
        {
            foreach(MeshRenderer mesh in meshRenderer)
            {
                mesh.enabled = false;
            }
        }
        else
        {
            foreach (MeshRenderer mesh in meshRenderer)
            {
                mesh.enabled = true;
            }
        }
        Debug.DrawLine(transform.forward * 0.5f + transform.transform.GetChild(1).position , player.position + player.up * 0.5f);
        Debug.DrawRay(transform.forward * 0.5f + transform.transform.GetChild(1).position, player.position - transform.transform.GetChild(1).position);
    }

    public bool PlayerInRange()
    {
        playerInRange = true;
        return playerInRange;
    }

    public void ChasePlayer()
    {
        Vector3 temp = player.position;
        temp = new Vector3(temp.x, 0, temp.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((temp - transform.position).normalized, Vector3.up), 5 * Time.deltaTime);
    }

    void LookAtTarget()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((waypointSystem.transform.GetChild(posIndex).position - transform.position).normalized,Vector3.up), 5 * Time.deltaTime);
        //transform.LookAt(waypointSystem.transform.GetChild(posIndex));


        if(Vector3.Distance(transform.position, waypointSystem.transform.GetChild(posIndex).position) < 1f)
        {
            if(posIndex < waypointSystem.transform.childCount - 1)
            {
                posIndex++;
            }
            else
            {
                posIndex = 0;
            }
        }
    }

    void Patrol()
    {
        if (a < 1)
        {
            transform.position = Vector3.Lerp(initPos, waypointSystem.transform.GetChild(posIndex).position, a);
        }
        else
        {
            if (posIndex < waypointSystem.transform.childCount - 1)
            {
                posIndex++;
            }
            else
            {
                posIndex = 0;
            }
            a = 0;
            UpdateInitPos();
        }
    }

    public WaypointSystem GetWaypointSystem()
    {
        return waypointSystem;
    }
}