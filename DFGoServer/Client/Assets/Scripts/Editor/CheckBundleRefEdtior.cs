using UnityEngine;
using System.Collections.Generic;
using LuaFramework;
using LuaInterface;
using System;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class CheckBundleRefEdtior : EditorWindow
{
	AssetBundleManifest assetBundleManifest;
	Vector2 scrollPos;
	Dictionary<string, List<string>> uiTextureResultMap = new Dictionary<string, List<string>>();
	List<string> uiTextureResultList = new List<string>();
	public string[] DEP_UI_BUNDLE_IGNORE = new string[] {
		"redpoint","rewardslot","slotpanel","baseslot"
	};
	private void OnGUI()
	{
		if (GUILayout.Button("[Step 1] : Analysis Bundle Dependence", GUILayout.Height(100)))
		{
			LoadManifest();
			AnalysisUITextureBundle();
		}
		DrawUITextureBundleResult();
	}

	void LoadManifest()
	{
		string path = PlatformUtil.GetPlatformName();
		AssetBundle ab = AssetBundle.LoadFromFile(Path.Combine(GResManager.GetInstance().GetAssetBundleStreamingAssetsPath(), path));
		assetBundleManifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

		ab.Unload(false);
		ab = null;
	}

	void AnalysisUITextureBundle()
	{
		if (assetBundleManifest == null)
		{
			return;
		}
		uiTextureResultMap.Clear();
		string[] allAssetBundles = assetBundleManifest.GetAllAssetBundles();
		for (int i = 0; i < allAssetBundles.Length; i++)
		{
			string bundleName = allAssetBundles[i];
			if (bundleName.StartsWith("ui_"))
			{
				string uiName = bundleName.Substring(bundleName.IndexOf("ui_") + "ui_".Length, bundleName.LastIndexOf(GResManager.VARIANT) - "ui_".Length);
				string[] deps = assetBundleManifest.GetAllDependencies(bundleName);

				for (int j = 0; j < deps.Length; j++)
				{
					string dep = deps[j];

					if (dep.StartsWith("ui_texture_"))
					{
						string uiDepName = dep.Substring(dep.IndexOf("ui_texture_") + "ui_texture_".Length, dep.LastIndexOf(GResManager.VARIANT) - "ui_texture_".Length);
						bool hasIgnore = false;
						foreach (string ignore in DEP_UI_BUNDLE_IGNORE)
						{
							if (ignore.Equals(uiDepName))
							{
								hasIgnore = true;
								break;
							}
						}
						if (!hasIgnore && !uiDepName.Equals(uiName))
						{
							List<string> result;
							if (!uiTextureResultMap.TryGetValue(uiName, out result))
							{
								result = new List<string>();
								uiTextureResultMap[uiName] = result;
							}
							if (result != null)
							{
								result.Add(uiDepName);
							}
						}
					}
				}
			}
		}
		foreach (string k in uiTextureResultMap.Keys)
		{
			List<string> v = uiTextureResultMap[k];
			string tabStr = "";
			for (int i = 0; i < 9 - Mathf.FloorToInt(k.Length / 4); i++)
			{
				tabStr += "\t";
			}
			string s = string.Format("{0}{1}【{2}】", k, tabStr, string.Join("】【", v.ToArray()));
			uiTextureResultList.Add(s);
		}
		string newPath = EditorUtility.SaveFilePanel("Save File To", "", "Output_CheckBundleRef", "txt");
		if (!string.IsNullOrEmpty(newPath))
		{
			byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(string.Join("\n", uiTextureResultList.ToArray()));
			File.WriteAllBytes(newPath, byteArray);
		}
	}

	void DrawUITextureBundleResult()
	{
		scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
		foreach (string s in uiTextureResultList)
		{
			EditorGUILayout.LabelField(s);
		}
		EditorGUILayout.EndScrollView();
	}
}
