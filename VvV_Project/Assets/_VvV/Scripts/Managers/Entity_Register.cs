using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Register : MonoBehaviour
{
    private enum EEntities { Player, EMP, Enemy, EnemyPart};

    [SerializeField] private EEntities entityType = EEntities.Enemy;

    private void Awake()
    {
        switch (entityType)
        {
            case EEntities.Player:
                Entity_Tracker.Instance.SetPlayer(this.transform);
                break;
            case EEntities.EMP:
                Entity_Tracker.Instance.AddInteractable(this.transform);
                break;
            case EEntities.Enemy:
                Entity_Tracker.Instance.AddEnemy(this.transform);
                break;
            case EEntities.EnemyPart:
                Entity_Tracker.Instance.RegisterEnemyPart(this.transform);
                break;
            default:
                break;
        }
    }
}
