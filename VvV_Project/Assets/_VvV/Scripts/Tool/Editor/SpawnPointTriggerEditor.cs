using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnPointTrigger))]
public class SpawnPointTriggerEditor : Editor
{
    SpawnPointTrigger editObject = null;

    private void OnEnable()
    {
        editObject = (SpawnPointTrigger)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
        foreach (Transform item in editObject.transform)
        {
            item.position = Handles.PositionHandle(item.position, item.rotation);
        }
    }
}
