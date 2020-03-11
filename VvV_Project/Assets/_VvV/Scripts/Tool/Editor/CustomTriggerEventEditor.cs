using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[CustomEditor(typeof(CustomTriggerEvent))]
public class CustomTriggerEventEditor : Editor
{
    CustomTriggerEvent editObject = null;
    string enter = "Activate Enter";
    string exit = "Activate Exit";
    string stay = "Activate Stay";

    private void OnEnable()
    {
        editObject = (CustomTriggerEvent)target;

        if (GUILayout.Button(enter))
        {
            if (editObject.ToggleOnTriggerEnter)
            {
                enter = "Activate Enter";
            }
            else
            {
                enter = "Deactivate Enter";
            }
        }

        if (GUILayout.Button(exit))
        {
            if (editObject.ToggleOnTriggerExit)
            {
                exit = "Activate Exit";
            }
            else
            {
                exit = "Deactivate Exit";
            }
        }

        if (GUILayout.Button(stay))
        {
            if (editObject.ToggleOnTriggerStay)
            {
                stay = "Activate Stay";
            }
            else
            {
                stay = "Deactivate Stay";
            }
        }
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        EditorGUILayout.BeginHorizontal(GUILayout.Width(Screen.width * 2 / 3));
        {
            if (GUILayout.Button(enter))
            {
                if (editObject.ToggleOnTriggerEnter)
                {
                    editObject.ToggleOnTriggerEnter = false;
                    enter = "Activate Enter";
                }
                else
                {
                    editObject.ToggleOnTriggerEnter = true;
                    enter = "Deactivate Enter";
                }
            }

            if (GUILayout.Button(exit))
            {
                if (editObject.ToggleOnTriggerExit)
                {
                    editObject.ToggleOnTriggerExit = false;
                    exit = "Activate Exit";
                }
                else
                {
                    editObject.ToggleOnTriggerExit = true;
                    exit = "Deactivate Exit";
                }
            }

            if (GUILayout.Button(stay))
            {
                if (editObject.ToggleOnTriggerStay)
                {
                    editObject.ToggleOnTriggerStay = false;
                    stay = "Activate Stay";
                }
                else
                {
                    editObject.ToggleOnTriggerStay = true;
                    stay = "Deactivate Stay";
                }
            }
        }
        EditorGUILayout.EndHorizontal();



        if (editObject.ToggleOnTriggerEnter)
        {
            //EditorGUILayout.PropertyField(editObject);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(editObject._OnTriggerEnter)));
        }



        if (editObject.ToggleOnTriggerExit)
        {
            //EditorGUILayout.PropertyField(editObject);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(editObject._OnTriggerExit)));
        }


        if (editObject.ToggleOnTriggerStay)
        {
            //EditorGUILayout.PropertyField(editObject);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(editObject._OnTriggerStay)));
        }

        serializedObject.ApplyModifiedProperties();
    }
}
