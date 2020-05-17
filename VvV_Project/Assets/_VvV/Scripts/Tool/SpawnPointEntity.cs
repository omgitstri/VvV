using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SpawnPointEntity : MonoBehaviour
{
    public bool activeSpawnPoint = false;
    private SpawnPointTrigger manager = null;
    [SerializeField] private bool inRange = false;
    [SerializeField] private bool isInvisible = false;

    private void Awake()
    {
        manager = GetComponentInParent<SpawnPointTrigger>();

        if (!manager.spawnPointEntities.Contains(this))
        {
            manager.spawnPointEntities.Add(this);
        }

        if(TryGetComponent(out MeshRenderer meshRenderer))
        {

        }
        else
        {
            gameObject.AddComponent<MeshRenderer>();
        }
    }

    public void Recalculate()
    {
        var distance = Vector3.Distance(Entity_Tracker.Instance.PlayerEntity.position, transform.position);

        if (distance < manager.maxValidDistance &&
            distance > manager.minValidDistance)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        CheckActive();
    }

    [ContextMenu(nameof(CheckActive))]
    private void CheckActive()
    {
        var boolList = new List<bool>();
        boolList.Add(inRange);
        boolList.Add(isInvisible);

        for (int i = 0; i < boolList.Count; i++)
        {
            if (!boolList[i])
            {
                activeSpawnPoint = false;
                break;
            }
            activeSpawnPoint = true;
        }
    }

    private void OnBecameInvisible()
    {
        isInvisible = true;
    }

    private void OnBecameVisible()
    {
        isInvisible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log(isInvisible);
        }
    }
}
