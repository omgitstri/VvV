using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointSystem : MonoBehaviour
{
    private void OnTransformChildrenChanged()
    {
        RenameChildren();
    }

    public void RenameChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).name = i.ToString();
        }
    }
}