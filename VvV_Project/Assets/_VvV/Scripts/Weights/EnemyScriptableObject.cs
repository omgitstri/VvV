using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData", menuName ="ScriptableData/Create New Enemy Data")]
public class EnemyScriptableObject : ScriptableObject
{
    public GameObject prefab = null;
    public int cost = 0;
}
