using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu (fileName = "Data", menuName = "ScriptableObjects/Stats")]
[System.Serializable]
public class EnemyStats {
    [Header("Enemy Stats")]
    public int regen = 0;
    public int hp = 0;
    [Space]
    public float regSpd = 0;
    public float atkSpd = 0;
    public float moveSpd = 0;
    public float aggroRng = 0;
    public float lostRngDur = 0;
}
