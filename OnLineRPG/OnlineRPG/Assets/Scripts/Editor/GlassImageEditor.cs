using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEditor;
[CustomEditor(typeof(GlassImage), true)]
[CanEditMultipleObjects]
public class GlassImageEditor : ImageEditor
{
    SerializedProperty m_blurSize;
    SerializedProperty m_vibrancy;
    SerializedProperty m_hui;
    protected override void OnEnable()
    {
        base.OnEnable();
        m_blurSize = serializedObject.FindProperty("blurSize");
        m_vibrancy = serializedObject.FindProperty("vibrancy");
        m_hui = serializedObject.FindProperty("hui");
    }



    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(m_Color);
        RaycastControlsGUI();
        TypeGUI();
        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(m_blurSize);
        EditorGUILayout.PropertyField(m_vibrancy);
        EditorGUILayout.PropertyField(m_hui);

        serializedObject.ApplyModifiedProperties();
    }
}
