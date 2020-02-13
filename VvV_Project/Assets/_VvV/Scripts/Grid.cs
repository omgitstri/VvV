using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private VoxelManager cm;
    public Vector3Int index { get; private set; }

    public bool lifeCycleUpdated { get; private set; }
    public int currentLifeCycle { get; private set; }

    public void GridUpdate()
    {
        if (!this.lifeCycleUpdated)
        {
            this.currentLifeCycle++;
            this.lifeCycleUpdated = true;
            cm.GridUpdateNeighbours(this.index);
        }
    }

    public void GridUpdateComplete()
    {
        if (this.currentLifeCycle < cm.LifeCycle)
        {
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
        else
        {
            this.lifeCycleUpdated = false;
        }
    }

    private void Update()
    {
        if (this.lifeCycleUpdated && GetComponentInChildren<Renderer>().material.GetColor("_BaseColor") != Color.red)
            GetComponentInChildren<Renderer>().material.SetColor("_BaseColor", Color.red);
        else if (!this.lifeCycleUpdated && GetComponentInChildren<Renderer>().material.GetColor("_BaseColor") != Color.white)
            GetComponentInChildren<Renderer>().material.SetColor("_BaseColor", Color.white);
    }

    private void OnTriggerEnter(Collider other)
    {
        RemoveSelf();
    }

    private void OnMouseEnter()
    {
        GetComponentInChildren<Renderer>().material.SetColor("_BaseColor", Color.green);
    }

    private void OnMouseExit()
    {
        GetComponentInChildren<Renderer>().material.SetColor("_BaseColor", Color.white);
    }

    private void OnMouseDown()
    {
        RemoveSelf();
    }

    private void RemoveSelf()
    {
        cm.RemoveFromNeighbour(new Vector3Int(this.index.x, this.index.y, this.index.z));
    }

    public void SetManager(VoxelManager _manager, int _x, int _y, int _z)
    {
        this.cm = _manager;
        this.index = new Vector3Int(_x, _y, _z);

    }
}