using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeightTable", menuName ="Create Weight Table")]
public class WeightTableScriptableObject : ScriptableObject
{
    public List<EnemyWeights> enemyWeights;

    [System.Serializable]
    public class EnemyWeights
    {
        [HideInInspector] public string name;
        public EnemyScriptableObject enemyType;
        public float weight;
    }


    private void OnEnable()
    {
        foreach (var item in enemyWeights)
        {
            item.name = item.enemyType?.name;
        }
    }

    [ContextMenu("debug")]
    public void PrintSelection()
    {
        Debug.Log(PickFromWeight().name);
    }

    public float ReturnTotalWeight()
    {
        float totalWeight = 0;

        for (int i = 0; i < enemyWeights.Count; i++)
        {
            if (enemyWeights[i].weight >= 0)
            {
                totalWeight += enemyWeights[i].weight;
            }
        }

        return totalWeight;
    }

    public GameObject PickFromWeight()
    {
        GameObject selected = null;

        float totalWeight = 0;
        float rand = Random.value;
        float percentage = 0;

        for (int i = 0; i < enemyWeights.Count; i++)
        {
            if (enemyWeights[i].weight >= 0)
            {
                totalWeight += enemyWeights[i].weight;
            }
        }

        for (int i = 0; i < enemyWeights.Count; i++)
        {
            if (enemyWeights[i].weight >= 0)
            {
                percentage += enemyWeights[i].weight / totalWeight;
            }

            if (rand <= percentage && enemyWeights[i].weight >= 0)
            {
                selected = enemyWeights[i].enemyType.prefab;
                return selected;
            }
        }
        return selected;
    }

}
