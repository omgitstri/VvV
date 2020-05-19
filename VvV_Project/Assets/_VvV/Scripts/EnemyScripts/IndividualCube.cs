using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualCube : MonoBehaviour
{
    //refactor
    public Vector3 voxelLocalPosition;

    private Collider myCollider = null;
    public Renderer visualMesh { get; private set; } = null;
    public EnemyAttackCube_Intepolation attackMesh { get; private set; } = null;
    private Rigidbody physicMesh = null;
    public bool killed { get; private set; } = false;

    private EnemyBehaviour enemyBehaviour = null;

    List<IndividualCube> neighbours = new List<IndividualCube>();

    public IndividualCube frontCube;
    public IndividualCube backCube;
    public IndividualCube leftCube;
    public IndividualCube rightCube;
    public IndividualCube topCube;
    public IndividualCube bottomCube;

    private const float minimumDelay = 0f;
    private const float maximumDelay = 3f;

    public int visit;
    public int layer;

    public bool hit;


    private void Awake()
    {
        visualMesh = transform.GetChild(0).GetComponent<Renderer>();
        physicMesh = transform.GetChild(1).GetComponent<Rigidbody>();
        attackMesh = transform.GetChild(2).GetComponent<EnemyAttackCube_Intepolation>();
        attackMesh.parent = this;
        myCollider = GetComponent<Collider>();
        enemyBehaviour = transform.root.GetComponent<EnemyBehaviour>();
    }

    void Start()
    {
        physicMesh.gameObject.SetActive(false);

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
        if (!killed)
        {
            //GetComponentInParent<CreateAdjacencyGraph>().alive = false;
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

            Invoke(nameof(DeactivateCube), Random.Range(0, 2f));
        }
    }

    public void SetNeighboursToWeakPoint(int layer, Material mat)
    {
        neighbours = ExpandNeighbours(layer);
        foreach (IndividualCube neighbour in neighbours)
        {
            neighbour.transform.GetChild(0).GetComponent<Renderer>().material = mat;
            //neighbour.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            neighbour.gameObject.tag = "WeakPoint";
        }
    }

    public void UnsetNeighboursToWeakPoint(int layer, Material mat)
    {
        neighbours = ExpandNeighbours(layer);
        foreach (IndividualCube neighbour in neighbours)
        {
            neighbour.transform.GetChild(0).GetComponent<Renderer>().material = mat;
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
                if (neighbour.CompareTag("WeakPoint"))
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

    public IEnumerator RegenAction()
    {
        if (killed == true)
        {

            physicMesh.isKinematic = true;
            if (physicMesh.TryGetComponent<Collider>(out Collider col))
            {
                col.enabled = false;
            }
            float elapsedTime = 0f;
            float waitTime = Random.Range(minimumDelay, maximumDelay);
            Vector3 initPos = physicMesh.transform.localPosition;

            neighbours.Clear();


            hit = false;

            while (elapsedTime < waitTime)
            {
                physicMesh.transform.position = Vector3.Slerp(initPos, transform.position, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;

                // Yield here
                yield return null;
            }
            // Make sure we got there
            physicMesh.transform.SetParent(this.transform);
            physicMesh.transform.localPosition = Vector3.zero;
            physicMesh.velocity = Vector3.zero;
            physicMesh.isKinematic = false;
            physicMesh.Sleep();

            if (physicMesh.TryGetComponent<Collider>(out Collider col2))
            {
                col2.enabled = true;
            }
            physicMesh.gameObject.SetActive(false);
            myCollider.enabled = true;
            visualMesh.enabled = true;
            killed = false;
            enemyBehaviour.remainingCubes.Add(this);
            StopAllCoroutines();
        }
    }

    public IEnumerator DelaySetKinematic()
    {
        yield return new WaitForSeconds(4f);
        physicMesh.isKinematic = true;
        //physicMesh.GetComponent<Collider>().enabled = false;
    }

    public void DeactivateCube()
    {
        if (!killed)
        {
            myCollider.enabled = false;
            visualMesh.enabled = false;
            physicMesh.gameObject.SetActive(true);
            physicMesh.isKinematic = false;
            attackMesh.gameObject.SetActive(false);

            if (transform.GetComponentInParent<TriggerCrawl>() != null)
            {
                transform.GetComponentInParent<TriggerCrawl>().Crawl();
            }

            physicMesh.transform.SetParent(null);
            StartCoroutine(nameof(DelaySetKinematic));
            killed = true;
            enemyBehaviour.remainingCubes.Remove(this);
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
