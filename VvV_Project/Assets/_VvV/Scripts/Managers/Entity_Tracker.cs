using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Tracker : MonoBehaviour
{
    private static Entity_Tracker _instance;
    public static Entity_Tracker Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject(nameof(Entity_Tracker)).AddComponent<Entity_Tracker>();
                //DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }

    public Transform PlayerEntity { get; private set; } = null;

    public void SetPlayer(Transform _transform)
    {
        PlayerEntity = _transform;
    }

    public List<Transform> InteractableEntity { get; private set; } = new List<Transform>();

    public void AddInteractable(Transform _transform)
    {
        InteractableEntity.Add(_transform);
    }

    public List<Transform> EnemyEntities { get; private set; } = new List<Transform>();
    public void AddEnemy(Transform _transform)
    {
        EnemyEntities.Add(_transform);

    }

    public List<Transform> GetAIReference()
    {
        var tempList = new List<Transform>();
        tempList.AddRange(InteractableEntity);
        tempList.Add(PlayerEntity);
        return tempList;
    }

    public Transform enemyPart { get; private set; } = null;

    public void RegisterEnemyPart(Transform _parts)
    {
        enemyPart = _parts;
    }

    public Gun playerGun { get; private set; } = null;

    public void RegisterGun(Gun _gun)
    {
        playerGun = _gun;
    }

    public bool collectedPart { get; set; } = false;
}
