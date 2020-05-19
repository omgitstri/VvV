using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu (fileName = "Data", menuName = "ScriptableObjects/Stats")]
[System.Serializable]
public class EnemyStats {
    [Header("Enemy Stats")]
    public int regen = 0;
    public int hp = 1;
    public float deathPercentage = 0.25f;
    public float deathPercentageTimer = 5f;
    [Space]
    public float dropPartPercentage = 0.1f;
    [Space]
    public float minRegenSpeed = 1;
    public float maxRegenSpeed = 5;
    public float atkSpeed = 2;
    public float attRange = 4;
    public float crawlSpeed = 1;
    public float moveSpeed = 2;
    public float aggroRange = 10;
    public float lostRangDuration = 0;
    [Space]
    public bool isCrawling = false;
    [Space]
    public bool isMaxed = false;

    public Transform currentTransform = null;

    public float powerUpCooldown = 4;
    public bool cooldown = false;
}
