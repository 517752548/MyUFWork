using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(GameUUButton))]
[CanEditMultipleObjects]
public class GameUUButtonEditor : ButtonEditor
{
	private SerializedProperty isCDable;
    private SerializedProperty cdSeconds;
    private SerializedProperty redDot;
    private SerializedProperty glowEffect;

    protected override void OnEnable()
    {
        isCDable = serializedObject.FindProperty("isCDable");
        cdSeconds = serializedObject.FindProperty("cdSeconds");
        redDot = serializedObject.FindProperty("redDot");
        glowEffect = serializedObject.FindProperty("glowEffect");
        base.OnEnable();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        isCDable.boolValue = EditorGUILayout.Toggle("isCDable", isCDable.boolValue);
        cdSeconds.floatValue = EditorGUILayout.FloatField("cdSeconds", cdSeconds.floatValue);
		redDot.objectReferenceValue = EditorGUILayout.ObjectField("redDot", redDot.objectReferenceValue, typeof(GameObject), true);
        glowEffect.objectReferenceValue = EditorGUILayout.ObjectField("glowEffect", glowEffect.objectReferenceValue, typeof(GameObject), true);
        serializedObject.ApplyModifiedProperties();
		base.OnInspectorGUI();
    }
}
