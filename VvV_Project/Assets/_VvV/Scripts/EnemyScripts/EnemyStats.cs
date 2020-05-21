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
    public float minRegenSpeed = 1;  // Starting/minimum regeneration speed upon death
    public float maxRegenSpeed = 5;  // Maximum regeneration speed upon death
    public float atkSpeed = 2;       // Overall attack speed of the enemy
    public float attRange = 4;       // Attack Range
    public float crawlSpeed = 1;     // The speed at which they move while crawling
    public float moveSpeed = 2;      // ^^ while walking
    public float aggroRange = 10;    // Range at which the enemy becomes aggressive to the player
    public float lostRangDuration = 0;
    [Space]
    public bool isCrawling = false;
    [Space]
    public bool isMaxed = false;

    public Transform currentTransform = null;

    public float powerUpCooldown = 4;
    public bool cooldown = false;
}
