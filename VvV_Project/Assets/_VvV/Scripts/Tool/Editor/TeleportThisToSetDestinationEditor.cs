using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TeleportThisToSetDestination))]
public class TeleportThisToSetDestinationEditor : Editor
{
    TeleportThisToSetDestination editObject = null;

    private void Awake()
    {
        editObject = (TeleportThisToSetDestination)target;
    }

    private void OnSceneGUI()
    {
        editObject.teleportPoint = Handles.DoPositionHandle(editObject.teleportPoint, Quaternion.identity);
        Handles.Label(editObject.teleportPoint + Vector3.left * 0.5f, nameof(editObject.teleportPoint));


        Handles.color = Color.red;
        Handles.DrawDottedLine(editObject.transform.position, editObject.teleportPoint, 5f);
    }
    
}
