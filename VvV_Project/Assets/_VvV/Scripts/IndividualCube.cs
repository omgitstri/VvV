using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualCube : MonoBehaviour
{
    public Vector3 voxelPosition;

    List<GameObject> neighbours = new List<GameObject>();

    public GameObject frontCube;
    public GameObject backCube;
    public GameObject leftCube;
    public GameObject rightCube;
    public GameObject topCube;
    public GameObject bottomCube;

    //public bool detached;

    public int visit;
    public int layer;

    List<GameObject> expNei = new List<GameObject>();

    public bool hit;

    //instantiate prefab
    [SerializeField] private GameObject instantiateCube = null;

    // Start is called before the first frame update
    void Start()
    {
        //detached = false;
        visit = 0;
        layer = 0;
        hit = false;
        //transform.rotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> GetNeighbours()
    {
        neighbours.Clear();
        if(frontCube != null)
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
        foreach (GameObject neighbour in neighbours)
        {
            neighbour.GetComponent<IndividualCube>().DestroyCube();
        }
    }

    public void AddRigidbodyToNeighbours()
    {
        //gameObject.AddComponent<Rigidbody>();
        neighbours = GetNeighbours();
        foreach (GameObject neighbour in neighbours)
        {
            neighbour.AddComponent<Rigidbody>();
        }
    }

    public void CheckDetached()
    {
        visit++;
        //print(visit);
        neighbours = GetNeighbours();
        if(neighbours.Count > 0)
        {
            foreach (GameObject neighbour in neighbours)
            {
                if(neighbour.GetComponent<IndividualCube>().visit != visit)
                {
                    neighbour.GetComponent<IndividualCube>().CheckDetached();
                }
            }
        }
    }

    public void DestroyCube()
    {
        if (frontCube != null)
        {
            frontCube.GetComponent<IndividualCube>().backCube = null;
        }
        if (backCube != null)
        {
            backCube.GetComponent<IndividualCube>().frontCube = null;
        }
        if (leftCube != null)
        {
            leftCube.GetComponent<IndividualCube>().rightCube = null;
        }
        if (rightCube != null)
        {
            rightCube.GetComponent<IndividualCube>().leftCube = null;
        }
        if (topCube != null)
        {
            topCube.GetComponent<IndividualCube>().bottomCube = null;
        }
        if (bottomCube != null)
        {
            bottomCube.GetComponent<IndividualCube>().topCube = null;
        }
        //transform.root.GetComponent<CreateAdjacencyGraph>().Children.Remove(voxelPosition);
        Destroy(gameObject);
    }

    public void SetNeighboursToWeakPoint(int layer, Material mat)
    {
        neighbours = ExpandNeighbours(layer);
        foreach (GameObject neighbour in neighbours)
        {
            neighbour.GetComponent<Renderer>().material = mat;
            //neighbour.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            neighbour.gameObject.tag = "WeakPoint";
        }
    }

    public void UnsetNeighboursToWeakPoint(int layer, Material mat)
    {
        neighbours = ExpandNeighbours(layer);
        foreach (GameObject neighbour in neighbours)
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
        List<GameObject> nei = ExpandNeighbours(layersOfNei);
        //print(nei.Count);
        if (nei.Count > 0)
        {
            foreach (GameObject neighbour in nei)
            {
                //print(neighbour.name);
                //neighbour.GetComponent<IndividualCube>().layer = 0;
                if(neighbour.tag == "WeakPoint")
                {
                    DestroyParent();
                }
                neighbour.GetComponent<IndividualCube>().hit = true;
            }
        }
    }

    public List<GameObject> ExpandNeighbours(int layersOfNei)
    {
        List<GameObject> curr = new List<GameObject>();
        //if (layer < 1)
        //{
        //layer++;
            curr.Add(gameObject);

        //}
         
        if (layersOfNei == 0)
        {
            return curr;
        }
        neighbours = GetNeighbours();
        foreach (GameObject neighbour in neighbours)
        {
            //if (neighbour.GetComponent<IndividualCube>().layer != layer)
            //{
                List<GameObject> recurse = neighbour.GetComponent<IndividualCube>().ExpandNeighbours(layersOfNei - 1);

                foreach (GameObject go in recurse)
                {
                    curr.Add(go);
                }
            //}
        }
        return curr;

        /*
        print("In");
        if (layer != layersOfNei)
        {
            layer++;
            print(layer);
            expNei.Add(gameObject);
            neighbours = GetNeighbours();
            if (neighbours.Count > 0)
            {
                foreach (GameObject neighbour in neighbours)
                {
                    if (neighbour.GetComponent<IndividualCube>().layer != layer)
                    {
                        neighbour.GetComponent<IndividualCube>().ExpendNeighbours(layersOfNei);
                    }
                }
            }
        }

        layer = 0;
        List<GameObject> temp = new List<GameObject>();
        temp = expNei;
        expNei.Clear();
        return temp;*/
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
            instantiateCube.transform.localScale = Vector3.one;
            instantiateCube.transform.SetParent(null);
            Destroy(instantiateCube, Random.Range(0f, 3f));
        }
    }
}
