using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] GameObject _prefab = null;

    public void DropPart()
    {
        if (Entity_Tracker.Instance.enemyPart == null
            && GetComponent<EnemyStatsContainer>().eStats.dropPartPercentage > Random.value)
        {
            var go = Instantiate(_prefab);
            go.transform.position = transform.position;
        }
    }
}
