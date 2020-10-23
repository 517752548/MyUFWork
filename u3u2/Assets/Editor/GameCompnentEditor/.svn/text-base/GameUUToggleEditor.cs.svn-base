using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(GameUUToggle))]
[CanEditMultipleObjects]
public class GameUUToggleEditor : ToggleEditor
{
    SerializedProperty redDot;
    SerializedProperty glowEffect;

    protected override void OnEnable()
    {
        redDot = serializedObject.FindProperty("redDot");
        glowEffect = serializedObject.FindProperty("glowEffect");
        base.OnEnable();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
		redDot.objectReferenceValue = EditorGUILayout.ObjectField("redDot", redDot.objectReferenceValue, typeof(GameObject), true);
        glowEffect.objectReferenceValue = EditorGUILayout.ObjectField("glowEffect", glowEffect.objectReferenceValue, typeof(GameObject), true);
        serializedObject.ApplyModifiedProperties();
        base.OnInspectorGUI();
    }
}
