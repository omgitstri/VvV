using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Collider)), DisallowMultipleComponent]
public class SpawnPointTrigger : MonoBehaviour
{
    public List<SpawnPointEntity> spawnPointEntities = new List<SpawnPointEntity>();

    [SerializeField] private LayerMask layerMask = ~0;

    [SerializeField] private bool spawnAllEnemies = false;
    private enum EEnemyDistance { Closest, Furthest };

    [SerializeField] private EEnemyDistance spawnEnemy = EEnemyDistance.Closest;
    public float minValidDistance = 0f;
    public float maxValidDistance = 2f;

    public UnityEvent _onTriggerEnter = null;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;

        foreach (Transform child in transform)
        {
            if (!child.TryGetComponent(out SpawnPointEntity entity))
            {
                child.gameObject.AddComponent<SpawnPointEntity>();
            }
        }

        spawnPointEntities.Clear();
        spawnPointEntities.AddRange(GetComponentsInChildren<SpawnPointEntity>());
    }

    private void OnTransformChildrenChanged()
    {
        GetComponent<Collider>().isTrigger = true;
        foreach (Transform child in transform)
        {
            if (!child.TryGetComponent(out SpawnPointEntity entity))
            {
                child.gameObject.AddComponent<SpawnPointEntity>();
            }
        }

        spawnPointEntities.Clear();
        spawnPointEntities.AddRange(GetComponentsInChildren<SpawnPointEntity>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (layerMask == (layerMask | 1 << other.gameObject.layer))
        {
            Debug.Log("test");
            TeleportEnemy();
            _onTriggerEnter.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {

    }


    private void TeleportEnemy()
    {
        var activeSpawnPoints = new List<Transform>();
        var distances = new List<float>();
        var enemyIndex = -1;
        var tempDistance = 0f;


        for (int i = 0; i < spawnPointEntities.Count; i++)
        {
            spawnPointEntities[i].Recalculate();

            if (spawnPointEntities[i].activeSpawnPoint)
            {
                activeSpawnPoints.Add(spawnPointEntities[i].transform);
                distances.Add(Vector3.Distance(spawnPointEntities[i].transform.position, Entity_Tracker.Instance.PlayerEntity.position));
            }
        }

        switch (spawnEnemy)
        {
            case EEnemyDistance.Closest:
                tempDistance = 100000f;

                for (int i = 0; i < Entity_Tracker.Instance.EnemyEntities.Count; i++)
                {
                    if (Vector3.Distance(Entity_Tracker.Instance.PlayerEntity.position, Entity_Tracker.Instance.EnemyEntities[i].position) < tempDistance
                        && !Entity_Tracker.Instance.EnemyEntities[i].GetComponent<EnemyBehaviour>().isVisible)
                    {
                        tempDistance = Vector3.Distance(Entity_Tracker.Instance.PlayerEntity.position, Entity_Tracker.Instance.EnemyEntities[i].position);
                        enemyIndex = i;
                    }
                }
                break;
            case EEnemyDistance.Furthest:
                tempDistance = 0f;

                for (int i = 0; i < Entity_Tracker.Instance.EnemyEntities.Count; i++)
                {
                    if (Vector3.Distance(Entity_Tracker.Instance.PlayerEntity.position, Entity_Tracker.Instance.EnemyEntities[i].position) > tempDistance
                        && !Entity_Tracker.Instance.EnemyEntities[i].GetComponent<EnemyBehaviour>().isVisible)
                    {
                        tempDistance = Vector3.Distance(Entity_Tracker.Instance.PlayerEntity.position, Entity_Tracker.Instance.EnemyEntities[i].position);
                        enemyIndex = i;
                    }
                }
                break;
            default:
                break;
        }


        //find and return closest/furthest enemy
        //warp
        if (enemyIndex > -1)
        {
            if (Entity_Tracker.Instance.EnemyEntities[enemyIndex].TryGetComponent(out NavMeshAgent agent))
            {
                if (activeSpawnPoints.Count > 0)
                {
                    agent.Warp(activeSpawnPoints[Random.Range(0, activeSpawnPoints.Count - 1)].position);
                }
            }
        }

    }
}
