using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using HybridUI.Generator;

public class HybridUITools
{
	[MenuItem("Assets/Create/[UIEditor]HybridUI", false, 140)]
	public static void CreateHybridUI()
	{
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);

		if (!string.IsNullOrEmpty(path) && (path.IndexOf("Res/UI") >= 0) && Path.GetExtension(path).Equals(".prefab"))
		{
			string prefabName = Path.GetFileNameWithoutExtension(path);
			HybridUIEditor hybridEditor = (HybridUIEditor)EditorWindow.GetWindow(typeof(HybridUIEditor));
			hybridEditor.Show();
		}
	}

	[MenuItem("Assets/Create/[UIEditor]HybridUI", true)]
	static private bool VCreateHybridUI()
	{
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		return !string.IsNullOrEmpty(path) && (path.IndexOf("Res/UI") >= 0) && (Path.GetExtension(path).Equals(".prefab"));
	}

	[MenuItem("GameObject/UI/[UIEditor]HybridUI", false, 2200)]
	public static void CreateHybridUIOnHierarchy()
	{
		HybridUIEditor hybridEditor = (HybridUIEditor)EditorWindow.GetWindow(typeof(HybridUIEditor));
		hybridEditor.Show();
	}
}
