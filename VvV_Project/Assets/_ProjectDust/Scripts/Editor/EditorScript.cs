using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    private Enemy enemy;
    private WaypointSystem waypoint;

    private void OnEnable()
    {
        enemy = target as Enemy;
        waypoint = enemy.GetWaypointSystem();
    }

    private void OnSceneGUI()
    {
        if (waypoint != null)
        {
            List<Vector3> pos = new List<Vector3>();

            for (int i = 0; i < waypoint.transform.childCount; i++)
            {
                pos.Add(waypoint.transform.GetChild(i).position);
            }
            Handles.DrawPolyLine(pos.ToArray());
        }
    }
}

[CustomEditor(typeof(WaypointSystem))]
public class WaypointSystemEditor : Editor
{
    private WaypointSystem waypoint;

    private void OnEnable()
    {
        waypoint = target as WaypointSystem;
    }

    private void OnSceneGUI()
    {
        List<Vector3> pos = new List<Vector3>();
        for (int i = 0; i < waypoint.transform.childCount; i++)
        {
            pos.Add(waypoint.transform.GetChild(i).position);
        }
        Handles.DrawPolyLine(pos.ToArray());
    }
}
