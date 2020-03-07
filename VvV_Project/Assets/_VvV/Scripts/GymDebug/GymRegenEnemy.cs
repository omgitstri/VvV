using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymRegenEnemy : Damagable
{
    [SerializeField] private List<CreateAdjacencyGraph> graph = new List<CreateAdjacencyGraph>();

    public override void GetDamaged()
    {
        //base.GetDamaged();

        StartCoroutine(nameof(Regen));

        //for (int i = 0; i < graph.Count; i++)
        //{
        //    graph[i].Regen();
        //}
    }

    public IEnumerator Regen()
    {
        int i = 0;
        while (i < graph.Count)
        {
            i++;
            graph[i].Regen();

            yield return new WaitForSeconds(Random.Range(0, 2));
        }
    }

    private void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }
}
