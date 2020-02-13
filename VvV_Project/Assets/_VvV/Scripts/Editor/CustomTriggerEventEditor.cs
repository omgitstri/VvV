using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[CustomEditor(typeof(CustomTriggerEvent))]
public class CustomTriggerEventEditor : Editor
{
    CustomTriggerEvent editObject = null;

    private void OnEnable()
    {
        editObject = (CustomTriggerEvent)target;
    }


    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        EditorGUILayout.BeginHorizontal();
        {
            ToggleButton(nameof(editObject.TriggerEnter), ref editObject.TriggerEnter);

            ToggleButton(nameof(editObject.TriggerStay), ref editObject.TriggerStay);

            ToggleButton(nameof(editObject.TriggerExit), ref editObject.TriggerExit);
        }
        EditorGUILayout.EndHorizontal();


        if (editObject.TriggerEnter)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(CustomTriggerEvent._onTriggerEnter)));
        }

        if (editObject.TriggerStay)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(CustomTriggerEvent._onTriggerStay)));
        }

        if (editObject.TriggerExit)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(CustomTriggerEvent._onTriggerExit)));
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void ToggleButton(string _label, ref bool _bool)
    {
        if (_bool)
        {
            if (GUILayout.Button("Disable " + _label))
            {
                _bool = false;
            }
        }
        else
        {
            if (GUILayout.Button("Enable " + _label))
            {
                _bool = true;
            }
        }
    }
}
