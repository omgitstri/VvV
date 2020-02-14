using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RenameCube : MonoBehaviour
{
    public string oldString;
    public string newString;
    IndividualCube[] children;

    [ContextMenu("FindReplace")]
    void Replace()
    {
        children = GetComponentsInChildren<IndividualCube>();
        for (int i = 0; i < children.Length; i++)
        {
            children[i].transform.name = children[i].transform.name.Replace(oldString, newString);
        }
    }

    [ContextMenu("RenameCubeByPosition")]
    void RenameCubeByPosition()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).name = "enemy_"+ transform.GetChild(i).localPosition.x + "_" + transform.GetChild(i).localPosition.y + "_" + transform.GetChild(i).localPosition.z;
        }
    }
}
