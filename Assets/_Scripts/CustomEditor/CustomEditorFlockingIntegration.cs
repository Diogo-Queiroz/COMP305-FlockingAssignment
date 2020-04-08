using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using EditorGUIUtility = UnityEditor.Experimental.Networking.PlayerConnection.EditorGUIUtility;

[CustomEditor(typeof(IntegrationFlockingBehaviour))]
public class CustomEditorFlockingIntegration : Editor
{
    public override void OnInspectorGUI()
    {
        IntegrationFlockingBehaviour integration = (IntegrationFlockingBehaviour) target;

        if (integration.behavious == null || integration.behavious.Length == 0)
        {
            EditorGUILayout.HelpBox("No Behaviours Array", MessageType.Warning);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
        }
        else
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Number", GUILayout.MinWidth(60f));
            GUILayout.MaxWidth(60f);
            EditorGUILayout.LabelField("Behaviours", GUILayout.MinWidth(60f));
            EditorGUILayout.LabelField("Scalars", GUILayout.MinWidth(60f));
            GUILayout.MaxWidth(60f);
            EditorGUILayout.EndHorizontal();

            EditorGUI.BeginChangeCheck();
            for (int i = 0; i < integration.behavious.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(60f));
                GUILayout.MaxWidth(60f);
                integration.behavious[i] = (Behaviour)EditorGUILayout.ObjectField(
                    integration.behavious[i],
                    typeof(Behaviour), false, 
                    GUILayout.MinWidth(60f));
                integration.scalars[i] = EditorGUILayout.FloatField(
                    integration.scalars[i],
                    GUILayout.MinWidth(60f),
                    GUILayout.MaxWidth(60f));
                EditorGUILayout.EndHorizontal();
            }

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(integration);
            }
        }

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Behavior"))
        {
            AddBehaviour(integration);
            EditorUtility.SetDirty(integration);
        }
        if (integration.behavious != null && integration.behavious.Length > 0)
        {
            if (GUILayout.Button("Remove Behaviour"))
            {
                RemoveBehaviour(integration);
                EditorUtility.SetDirty(integration);
            }
        }
        EditorGUILayout.EndHorizontal();

    }

    void AddBehaviour(IntegrationFlockingBehaviour integration)
    {
        int temp = (integration.behavious != null) ? integration.behavious.Length : 0;
        Behaviour[] newBehavious = new Behaviour[temp + 1];
        float[] newScalars = new float[temp + 1];
        for (int i = 0; i < temp; i++)
        {
            newBehavious[i] = integration.behavious[i];
            newScalars[i] = integration.scalars[i];
        }

        newScalars[temp] = 1f;
        integration.behavious = newBehavious;
        integration.scalars = newScalars;
    }

    void RemoveBehaviour(IntegrationFlockingBehaviour integration)
    {
        int temp = integration.behavious.Length;
        if (temp == 1)
        {
            integration.behavious = null;
            integration.scalars = null;
            return;
        }
        Behaviour[] newBehavious = new Behaviour[temp - 1];
        float[] newScalars = new float[temp - 1];
        for (int i = 0; i < temp - 1; i++)
        {
            newBehavious[i] = integration.behavious[i];
            newScalars[i] = integration.scalars[i];
        }
        integration.behavious = newBehavious;
        integration.scalars = newScalars;
    }
}
