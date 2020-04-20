using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRegen : Damagable
{
    [SerializeField] private List<CreateAdjacencyGraph> graph = new List<CreateAdjacencyGraph>();

    public override void GetDamaged(float dmg)
    {
        //base.GetDamaged();

        StartCoroutine(nameof(Regen));
    }

    public IEnumerator Regen()
    {
        int i = 0;
        while (i < graph.Count)
        {
            graph[i].Regen();
            i++;
            yield return new WaitForSeconds(Random.Range(0, 2));
        }
    }

    private void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }
}
