using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu (fileName = "Data", menuName = "ScriptableObjects/Stats")]
[System.Serializable]
public class EnemyStats {
    [Header("Enemy Stats")]
    public int regen = 0;
    public int hp = 1;
    [Space]
    public float minRegenSpeed = 1;
    public float maxRegSpeed = 5;
    public float atkSpd = 3;
    public float attRng = 2;
    public float crawlSpd = 1;
    public float moveSpd = 2;
    public float aggroRng = 10;
    public float lostRngDur = 2;
    [Space]
    public bool isCrawling = false;
    [Space]
    public bool isMaxed = false;

}
