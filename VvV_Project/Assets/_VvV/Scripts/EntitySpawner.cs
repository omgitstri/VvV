using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
    private Vector3 min = Vector3.zero;
    private Vector3 max = Vector3.zero;

    private void Start()
    {
        min = transform.GetComponent<Collider>().bounds.min;
        max = transform.GetComponent<Collider>().bounds.max;
    }

    private void Update()
    {
        SpawnEnemyInstance();
    }

    private void SpawnEnemyInstance()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var go = Instantiate<GameObject>(enemyPrefab);
            go.transform.position = RandomMinMax();
        }
    }

    private Vector3 RandomMinMax()
    {
        Vector3 enemyScale = enemyPrefab.transform.localScale / 2;

        return new Vector3(Random.Range(min.x + enemyScale.x, max.x - enemyScale.x), 0, Random.Range(min.z + enemyScale.z, max.z - enemyScale.z));
    }
}