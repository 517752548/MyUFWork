
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


/// <summary>
/// 扩展标签。(标签从外到内包含顺序<href><color>，<image>独立)
/// 标签格式：
///     <href param=[点击参数]>[超链接显示内容]</href>
///     <image name=[图片名称]/>  PS:图片通过AtlasSpriteManager.Instance.GetSprite函数进行加载
/// </summary>


#if UNITY_EDITOR

/// <summary>
/// RichLable的编辑页面。
/// </summary>
[CustomEditor(typeof(RichLabel))]
[ExecuteInEditMode]
public class RichLabelEditor : Editor
{
	/// <summary>
	/// 选中RichLable组件时。
	/// </summary>
	void OnEnable()
	{
		m_TextProperty = serializedObject.FindProperty("m_Text");
		m_OnHrefClickProperty = serializedObject.FindProperty("m_HrefClickEvent");
		m_UnderLineHeightProperty = serializedObject.FindProperty("m_UnderLineHeight");
	}

	/// <summary>
	/// 绘制面板。
	/// </summary>
	public override void OnInspectorGUI()
	{
		RichLabel rl = target as RichLabel;
		string txt = m_TextProperty.stringValue;
		EditorGUILayout.PropertyField(m_TextProperty);
		EditorGUILayout.Space();
		EditorGUILayout.PropertyField(m_OnHrefClickProperty);
		EditorGUILayout.PropertyField(m_UnderLineHeightProperty);
		serializedObject.ApplyModifiedProperties();

		//文本有变则重新生成显示
		if (txt.CompareTo(m_TextProperty.stringValue) != 0)
		{
			rl.Rebuild();
		}
	}

	/// <summary>
	/// 文本属性。
	/// </summary>
	private SerializedProperty m_TextProperty;

	/// <summary>
	/// 超链接点击事件。
	/// </summary>
	private SerializedProperty m_OnHrefClickProperty;

	/// <summary>
	/// 下划线高度。
	/// </summary>
	private SerializedProperty m_UnderLineHeightProperty;
}

#endif
