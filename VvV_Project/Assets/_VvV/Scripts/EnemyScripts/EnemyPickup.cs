using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Entity_Tracker.Instance.RegisterEnemyPart(transform);
    }
}
