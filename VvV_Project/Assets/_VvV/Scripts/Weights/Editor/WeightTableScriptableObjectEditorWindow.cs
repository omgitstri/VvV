using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeightTableScriptableObjectEditorWindow : EditorWindow
{
    [SerializeField] private WeightTableScriptableObject weightTable = null;
    Vector2 scroll;

    [MenuItem("VvV/Balancing/Weight Table")]
    public static void ShowWindow()
    {
        var window = GetWindow<WeightTableScriptableObjectEditorWindow>();
        window.titleContent.text = "Weight Table";
        window.minSize = new Vector2(250, 200);
    }

    private void OnGUI()
    {
        scroll = GUILayout.BeginScrollView(scroll);
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Enemy Data", GUILayout.Width((Screen.width / 2) - 20));
                EditorGUILayout.LabelField("Weight", GUILayout.Width((Screen.width / 4) - 20));
                EditorGUILayout.LabelField("Percentage", GUILayout.Width((Screen.width / 4) - 20));
            }
            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < weightTable.enemyWeights.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                {
                    weightTable.enemyWeights[i].enemyType = (EnemyScriptableObject)EditorGUILayout.ObjectField(weightTable.enemyWeights[i].enemyType, typeof(EnemyScriptableObject), false, GUILayout.Width((Screen.width / 2) - 20));
                    weightTable.enemyWeights[i].weight = EditorGUILayout.FloatField(weightTable.enemyWeights[i].weight, GUILayout.Width((Screen.width / 4) - 20));

                    EditorGUILayout.LabelField((weightTable.enemyWeights[i].weight / weightTable.ReturnTotalWeight()).ToString(), GUILayout.Width((Screen.width / 4) - 20));
                    if (GUILayout.Button("X"))
                    {
                        weightTable.enemyWeights.RemoveAt(i);
                        break;
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        GUILayout.EndScrollView();

        if (GUILayout.Button("Add Element"))
        {
            weightTable.enemyWeights.Add(new WeightTableScriptableObject.EnemyWeights());
        }

        EditorUtility.SetDirty(weightTable);
    }
}
