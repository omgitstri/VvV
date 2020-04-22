using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymRegenEnemy : Damagable
{
    [SerializeField] private List<CreateAdjacencyGraph> graph = new List<CreateAdjacencyGraph>();

    public override void GetDamaged(int dmg)
    {
        //base.GetDamaged();

        StartCoroutine(nameof(RegenTrigger));
    }

    public IEnumerator RegenTrigger()
    {
        int i = 0;
        while (i < graph.Count)
        {
            graph[i].RegenManager();
            i++;
            yield return new WaitForSeconds(Random.Range(0, 2));
        }
    }

    private void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }
}
