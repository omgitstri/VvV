using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Physics.Authoring;

public class IndividualCube : MonoBehaviour
{
    //refactor
    public Vector3 voxelLocalPosition;
    private Collider myCollider = null;
    private Renderer visualMesh = null;
    private Rigidbody physicMesh = null;
    private bool destroyed = false;

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

    public bool hit;

    //instantiate prefab
    [SerializeField] private GameObject instantiateCube = null;

    void Start()
    {
        visualMesh = transform.GetChild(0).GetComponent<Renderer>();
        physicMesh = transform.GetChild(1).GetComponent<Rigidbody>();
        physicMesh.gameObject.SetActive(false);
        myCollider = GetComponent<Collider>();

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
            neighbour.DeactivateNeighbours();
        }
    }

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

    public void DeactivateNeighbours()
    {
        if (!destroyed)
        {
            GetComponentInParent<CreateAdjacencyGraph>().alive = false;
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

            DeactivateCube();
        }
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
        transform.root.GetComponent<CreateAdjacencyGraph>().DestroyAll();
        //Destroy(transform.root.gameObject);
    }

    public void MarkAsHit(int layersOfNei)
    {
        List<IndividualCube> nei = ExpandNeighbours(layersOfNei);

        if (nei.Count > 0)
        {
            foreach (IndividualCube neighbour in nei)
            {
                if (neighbour.CompareTag( "WeakPoint"))
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

    public IEnumerator Regen()
    {
        float elapsedTime = 0f;
        float waitTime = Random.Range(0f, 5f);
        Vector3 initPos = physicMesh.transform.localPosition;
        neighbours.Clear();
        //physicMesh.transform.localPosition = Vector3.zero;
        physicMesh.isKinematic = true;

        hit = false;

        while (elapsedTime < waitTime)
        {
            physicMesh.transform.position = Vector3.Slerp(initPos, transform.position, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        // Make sure we got there
        physicMesh.transform.localPosition = Vector3.zero;
        physicMesh.transform.SetParent(this.transform);

        physicMesh.gameObject.SetActive(false);
        myCollider.enabled = true;
        visualMesh.enabled = true;
        StopCoroutine(nameof(Regen));
    }

    public void DeactivateCube()
    {
        if (!destroyed)
        {
            myCollider.enabled = false;
            visualMesh.enabled = false;
            physicMesh.gameObject.SetActive(true);
            physicMesh.isKinematic = false;
            physicMesh.AddExplosionForce(100, Vector3.one, 10);


            if (transform.GetComponentInParent<TriggerCrawl>() != null)
            {
                transform.GetComponentInParent<TriggerCrawl>().Crawl();
            }

            physicMesh.transform.SetParent(null);

            //if (instantiateCube != null && !destroyed)
            //{
            //    instantiateCube = Instantiate<GameObject>(instantiateCube);
            //    instantiateCube.transform.SetPositionAndRotation(transform.position, transform.rotation);
            //    Destroy(instantiateCube, Random.Range(0f, 3f));
            //    destroyed = true;
            //}
        }
    }

    //private void OnDestroy()
    //{
    //    if (transform.GetComponentInParent<TriggerCrawl>() != null)
    //    {
    //        transform.GetComponentInParent<TriggerCrawl>().Crawl();
    //    }

    //    if (instantiateCube != null)
    //    {
    //        instantiateCube = Instantiate<GameObject>(instantiateCube, transform);
    //        instantiateCube.transform.SetPositionAndRotation(transform.position, transform.rotation);
    //        //instantiateCube.transform.localScale = Vector3.one;
    //        instantiateCube.transform.SetParent(null);
    //        Destroy(instantiateCube, Random.Range(0f, 3f));
    //    }
    //}
}
