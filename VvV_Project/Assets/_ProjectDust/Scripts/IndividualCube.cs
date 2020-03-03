using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualCube : MonoBehaviour
{
    public Vector3 voxelPosition;

    List<IndividualCube> neighbours = new List<IndividualCube>();

    public IndividualCube frontCube;
    public IndividualCube backCube;
    public IndividualCube leftCube;
    public IndividualCube rightCube;
    public IndividualCube topCube;
    public IndividualCube bottomCube;

    //public bool detached;

    public int visit;
    public int layer;

    List<GameObject> expNei = new List<GameObject>();

    public bool hit;

    //instantiate prefab
    [SerializeField] private GameObject instantiateCube = null;

    void Start()
    {
        visit = 0;
        layer = 0;
        hit = false;
    }

    public List<IndividualCube> GetNeighbours()
    {
        neighbours.Clear();
        if (frontCube != null)
        {
            neighbours.Add(frontCube);
        }
        if (backCube != null)
        {
            neighbours.Add(backCube);
        }
        if (leftCube != null)
        {
            neighbours.Add(leftCube);
        }
        if (rightCube != null)
        {
            neighbours.Add(rightCube);
        }
        if (topCube != null)
        {
            neighbours.Add(topCube);
        }
        if (bottomCube != null)
        {
            neighbours.Add(bottomCube);
        }
        return neighbours;
    }

    public List<int> GetNeighbourIndices()
    {
        List<int> indices = new List<int>();
        if (frontCube != null)
        {
            indices.Add(1);
        }
        if (backCube != null)
        {
            indices.Add(2);
        }
        if (leftCube != null)
        {
            indices.Add(3);
        }
        if (rightCube != null)
        {
            indices.Add(4);
        }
        if (topCube != null)
        {
            indices.Add(5);
        }
        if (bottomCube != null)
        {
            indices.Add(6);
        }
        return indices;
    }


    public void DestroyNeighbours()
    {
        //Destroy(gameObject);
        neighbours = GetNeighbours();
        foreach (IndividualCube neighbour in neighbours)
        {
            neighbour.DestroyCube();
        }
    }

    //public void AddRigidbodyToNeighbours()
    //{
    //    //gameObject.AddComponent<Rigidbody>();
    //    neighbours = GetNeighbours();
    //    foreach (IndividualCube neighbour in neighbours)
    //    {
    //        neighbour.gameObject.AddComponent<Rigidbody>();
    //    }
    //}

    [ContextMenu(nameof(CheckDetached))]
    public void CheckDetached()
    {
        visit++;
        //print(visit);
        neighbours = GetNeighbours();
        if (neighbours.Count > 0)
        {
            foreach (IndividualCube neighbour in neighbours)
            {
                if (neighbour.visit != visit)
                {
                    neighbour.CheckDetached();
                }
            }
        }
    }

    public void DestroyCube()
    {
        if (frontCube != null)
        {
            frontCube.backCube = null;
        }
        if (backCube != null)
        {
            backCube.frontCube = null;
        }
        if (leftCube != null)
        {
            leftCube.rightCube = null;
        }
        if (rightCube != null)
        {
            rightCube.leftCube = null;
        }
        if (topCube != null)
        {
            topCube.bottomCube = null;
        }
        if (bottomCube != null)
        {
            bottomCube.topCube = null;
        }
        //transform.root.GetComponent<CreateAdjacencyGraph>().Children.Remove(voxelPosition);
        Destroy(gameObject);
        //transform.GetComponent<Rigidbody>().isKinematic = false;
        //transform.SetParent(null);
    }

    public void SetNeighboursToWeakPoint(int layer, Material mat)
    {
        neighbours = ExpandNeighbours(layer);
        foreach (IndividualCube neighbour in neighbours)
        {
            neighbour.GetComponent<Renderer>().material = mat;
            //neighbour.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            neighbour.gameObject.tag = "WeakPoint";
        }
    }

    public void UnsetNeighboursToWeakPoint(int layer, Material mat)
    {
        neighbours = ExpandNeighbours(layer);
        foreach (IndividualCube neighbour in neighbours)
        {
            neighbour.GetComponent<Renderer>().material = mat;
            //neighbour.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            neighbour.gameObject.tag = "Enemy";
        }
    }

    public void DestroyParent()
    {
        Destroy(transform.root.gameObject);
    }

    public void MarkAsHit(int layersOfNei)
    {
        List<IndividualCube> nei = ExpandNeighbours(layersOfNei);

        if (nei.Count > 0)
        {
            foreach (IndividualCube neighbour in nei)
            {
                if (neighbour.tag == "WeakPoint")
                {
                    DestroyParent();
                }
                neighbour.hit = true;
            }
        }
    }

    public List<IndividualCube> ExpandNeighbours(int layersOfNei)
    {
        List<IndividualCube> curr = new List<IndividualCube>();

        curr.Add(this);

        if (layersOfNei == 0)
        {
            return curr;
        }
        neighbours = GetNeighbours();
        foreach (IndividualCube neighbour in neighbours)
        {
            List<IndividualCube> recurse = neighbour.ExpandNeighbours(layersOfNei - 1);

            foreach (IndividualCube individualCubes in recurse)
            {
                curr.Add(individualCubes);
            }
        }
        return curr;
    }

    private void OnDestroy()
    {
        if (transform.GetComponentInParent<TriggerCrawl>() != null)
        {
            transform.GetComponentInParent<TriggerCrawl>().Crawl();
        }

        if (instantiateCube != null)
        {
            instantiateCube = Instantiate<GameObject>(instantiateCube, transform);
            instantiateCube.transform.SetPositionAndRotation(transform.position, transform.rotation);
            //instantiateCube.transform.localScale = Vector3.one;
            instantiateCube.transform.SetParent(null);
            Destroy(instantiateCube, Random.Range(0f, 3f));
        }
    }
}
