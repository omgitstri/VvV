using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LerpGeneric))]
public class LerpGenericEditor : Editor
{
    LerpGeneric editObject = null;

    private void OnEnable()
    {
        editObject = (LerpGeneric)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        switch (editObject.lerpType)
        {
            case LerpGeneric.EVariables.Float:
                editObject.lerpFloatA = EditorGUILayout.FloatField("From", editObject.lerpFloatA);
                editObject.lerpFloatB = EditorGUILayout.FloatField("To", editObject.lerpFloatB);
                break;
            case LerpGeneric.EVariables.Int:
                editObject.lerpIntA = EditorGUILayout.IntField("From", editObject.lerpIntA);
                editObject.lerpIntB = EditorGUILayout.IntField("To", editObject.lerpIntB);
                break;
            case LerpGeneric.EVariables.vector2:
                editObject.lerpVector2A = EditorGUILayout.Vector2Field("From", editObject.lerpVector2A);
                editObject.lerpVector2B = EditorGUILayout.Vector2Field("To", editObject.lerpVector2B);
                break;
            case LerpGeneric.EVariables.vector3:
                editObject.lerpVector3A = EditorGUILayout.Vector3Field("From", editObject.lerpVector3A);
                editObject.lerpVector3B = EditorGUILayout.Vector3Field("To", editObject.lerpVector3B);
                break;
            case LerpGeneric.EVariables.color:
                editObject.lerpColorA= EditorGUILayout.ColorField("From", editObject.lerpColorA);
                editObject.lerpColorB = EditorGUILayout.ColorField("To", editObject.lerpColorB);
                break;
            default:
                break;
        }

    }
}
