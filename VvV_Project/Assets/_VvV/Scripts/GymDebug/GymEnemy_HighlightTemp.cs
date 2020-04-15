using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymEnemy_HighlightTemp : MonoBehaviour
{
    [SerializeField] private List<Transform> resetHighlights = new List<Transform>();
    [SerializeField] private List<Transform> highlights = new List<Transform>();
    [SerializeField] private List<Transform> enemies = new List<Transform>();

    void Update()
    {
        //highlight
        {
            highlights.Clear();

            foreach (var item in enemies)
            {
                if(item.TryGetComponent<EnemyBehaviour>(out var attackClosest))
                {
                    highlights.Add(attackClosest.currentTarget);
                }
            }

            foreach (var item in resetHighlights)
            {
                item.GetChild(0).gameObject.SetActive(false);
            }

            foreach (var item in highlights)
            {
                item.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
