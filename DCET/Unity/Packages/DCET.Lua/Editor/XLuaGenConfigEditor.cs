using DCETRuntime;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace DCETEditor
{
	public class XLuaGenConfigEditor : EditorWindow
	{
		[SerializeField]
		public List<string> assemblyNames;
		[SerializeField]
		public List<string> blackTypes;

		private SerializedObject serializedObject;
		private SerializedProperty assemblyNamesProperty;
		private SerializedProperty blackTypesProperty;
		private XLuaGenConfigData xLuaGenConfigData = new XLuaGenConfigData();

		[MenuItem("Tools/Start Gen Config")]
		public static void ShowWindow()
		{
			GetWindow<XLuaGenConfigEditor>();
		}

		public void Awake()
		{
			if (File.Exists(XLuaGenConfig.path))
			{
				xLuaGenConfigData = MongoHelper.FromJson<XLuaGenConfigData>(File.ReadAllText(XLuaGenConfig.path));

				if(xLuaGenConfigData != null)
				{
					assemblyNames = xLuaGenConfigData.assemblyNames;
					blackTypes = xLuaGenConfigData.blackTypes;
				}
			}
		}

		protected void OnEnable()
		{
			serializedObject = new SerializedObject(this);
			assemblyNamesProperty = serializedObject.FindProperty("assemblyNames");
			blackTypesProperty = serializedObject.FindProperty("blackTypes");
		}

		public void OnGUI()
		{
			serializedObject.Update();

			EditorGUI.BeginChangeCheck();

			EditorGUILayout.PropertyField(assemblyNamesProperty, new GUIContent("程序集"), true);
			EditorGUILayout.PropertyField(blackTypesProperty, new GUIContent("黑名单"), true);

			if (EditorGUI.EndChangeCheck())
			{
				serializedObject.ApplyModifiedProperties();
				xLuaGenConfigData.assemblyNames = assemblyNames;
				xLuaGenConfigData.blackTypes = blackTypes;
				File.WriteAllText(XLuaGenConfig.path, MongoHelper.ToJson(xLuaGenConfigData));
				AssetDatabase.Refresh();
			}
		}
	}
}
