using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDistribution : MonoBehaviour
{
    [SerializeField] private int points = 500;

    [System.Serializable]
    public class EnemyWeights
    {
        [HideInInspector] public string name;
        public EnemyTypeEnum enemyType;
        public float weight;
        public int cost;
    }

    private void OnValidate()
    {
        if (enemyWeights.Count > 0)
        {
            foreach (var item in enemyWeights)
            {
                item.name = item.enemyType.ToString();
            }
        }
    }

    public List<EnemyWeights> enemyWeights;

    [ContextMenu("debug")]
    public void PrintSelection()
    {
        print(PickFromWeight().ToString());
    }

    public EnemyTypeEnum PickFromWeight()
    {
        EnemyTypeEnum selected = EnemyTypeEnum.EnemyA;

        float rand = Random.value;
        float percentage = 0;
        float totalWeight = 0;

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
            
            if(rand <= percentage && enemyWeights[i].weight >= 0)
            {
                selected = enemyWeights[i].enemyType;
                return selected;
            }
        }
        return selected;
    }
}
