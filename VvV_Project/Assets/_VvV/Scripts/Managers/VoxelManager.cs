using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelManager : MonoBehaviour
{
    public int LifeCycle { get; private set; }
    private int iteration = 0;

    private bool GridUpdating = false;
    private Grid[,,] neighbourArray;
    private Grid target;

    [SerializeField] int x = 5;
    [SerializeField] int y = 5;
    [SerializeField] int z = 5;
    [SerializeField] GameObject prefab = null;

    private void Start()
    {
        //instantiate cube
        neighbourArray = new Grid[x, y, z];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                for (int k = 0; k < z; k++)
                {
                    var go = Instantiate<GameObject>(prefab);
                    go.name = string.Join("_", i, j, k);

                    neighbourArray[i, j, k] = go.GetComponent<Grid>();
                    neighbourArray[i, j, k].SetManager(this, i, j, k);

                    go.transform.SetParent(this.transform);
                    go.transform.localPosition = new Vector3(i, j, k);
                }
            }
        }


        //set random weak point
        target = neighbourArray[Random.Range(0, x), Random.Range(0, y), Random.Range(0, z)];
    }

    private void Update()
    {
        if (GridUpdating)
        {
            if (iteration >= neighbourArray.Length)
            {
                iteration = 0;
                GridUpdating = false;
                GridComplete();
            }

            int completedGrid = 0;
            int totalGrid = 0;

            foreach (var item in neighbourArray)
            {
                if (item != null && item.lifeCycleUpdated)
                {
                    completedGrid++;
                }

                if (item != null)
                {
                    totalGrid++;
                }
            }


            if (completedGrid == totalGrid)
            {
                GridComplete();
            }

            iteration++;
        }
    }

    public void RemoveFromNeighbour(Vector3Int _index)
    {
        if (neighbourArray[_index.x, _index.y, _index.z] == target)
        {
            foreach (var item in neighbourArray)
            {
                if (item != null)
                {
                    item.gameObject.SetActive(false);
                   // Destroy(item.gameObject);
                }
            }
        }
        else
        {
            Destroy(neighbourArray[_index.x, _index.y, _index.z].gameObject);
            neighbourArray[_index.x, _index.y, _index.z] = null;
            GridUpdate();
        }
    }

    public void GridUpdate()
    {
        LifeCycle++;
        target.GridUpdate();
    }

    public void GridUpdateNeighbours(Vector3Int _index)
    {

        GridUpdating = true;
        neighbourArray[_index.x, _index.y, _index.z]?.GridUpdate();

        //x
        if (_index.x + 1 < x) { neighbourArray[_index.x + 1, _index.y, _index.z]?.GridUpdate(); }
        if (_index.x - 1 >= 0) { neighbourArray[_index.x - 1, _index.y, _index.z]?.GridUpdate(); }

        //y                                                                 
        if (_index.y + 1 < y) { neighbourArray[_index.x, _index.y + 1, _index.z]?.GridUpdate(); }
        if (_index.y - 1 >= 0) { neighbourArray[_index.x, _index.y - 1, _index.z]?.GridUpdate(); }

        //z                                                                 
        if (_index.z + 1 < z) { neighbourArray[_index.x, _index.y, _index.z + 1]?.GridUpdate(); }
        if (_index.z - 1 >= 0) { neighbourArray[_index.x, _index.y, _index.z - 1]?.GridUpdate(); }

    }

    public void GridComplete()
    {
        foreach (var item in neighbourArray)
        {
            if (item != null)
            {
                item.GridUpdateComplete();
            }
        }
    }


}