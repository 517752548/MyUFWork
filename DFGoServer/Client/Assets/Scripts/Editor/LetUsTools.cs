using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class AssetBundlesMenuItems
{
	[MenuItem("LetUs/AssetBundles/Set Texture Settings/Atlas Texture")]
	static public void SetAtlasTextureSettings()
	{
		BuildScript.IterAssets("Res/Atlas", new string[] { ".meta" }, delegate (FileInfo item, AssetImporter importer, string defAbName)
		{
			TextureImporter texImporter = importer as TextureImporter;
			if (texImporter != null)
			{
				BuildScript.SetPlatformIconTextureSettings(texImporter);
				AssetDatabase.ImportAsset(texImporter.assetPath);
			}
		});
		BuildScript.IterAssets("Res/HUD", new string[] { ".meta" }, delegate (FileInfo item, AssetImporter importer, string defAbName)
		{
			TextureImporter texImporter = importer as TextureImporter;
			if (texImporter != null)
			{
				BuildScript.SetPlatformIconTextureSettings(texImporter);
				AssetDatabase.ImportAsset(texImporter.assetPath);
			}
		});
		AssetDatabase.RemoveUnusedAssetBundleNames();
		AssetDatabase.Refresh();
	}


	[MenuItem("LetUs/AssetBundles/Set Texture Settings/Icon Folder")]
	static public void SetIconTextureSettings()
	{
		BuildScript.SetIconTextureSettings();
	}

	[MenuItem("LetUs/AssetBundles/Set Texture Settings/UI Folder")]
	static public void SetUITextureSettings()
	{
		BuildScript.SetUITextureSettings();
	}

	[MenuItem("LetUs/AssetBundles/Set Texture Settings/Effect Folder")]
	static public void SetEffectTextureSettings()
	{
		BuildScript.IterAssets("Res/Effect", new string[] { ".meta" }, delegate (FileInfo item, AssetImporter importer, string defAbName)
		{
			//特效过滤
			if (item.Directory.FullName.IndexOf("nocompress") > 0)
			{
				return;
			}
			if (item.Directory.FullName.IndexOf("UI") > 0)
			{
				return;
			}
			TextureImporter texImporter = importer as TextureImporter;
			if (texImporter != null)
			{
				BuildScript.SetPlatformTextureSettings(texImporter, 128);
				AssetDatabase.ImportAsset(texImporter.assetPath);
			}
		});
		AssetDatabase.RemoveUnusedAssetBundleNames();
		AssetDatabase.Refresh();
	}
	[MenuItem("LetUs/AssetBundles/Set Texture Settings/Scene Folder")]
	static public void SetSceneTextureSettings()
	{
		BuildScript.IterAssets("Res/Scene/Content", new string[] { ".meta" }, delegate (FileInfo item, AssetImporter importer, string defAbName)
		{
			TextureImporter texImporter = importer as TextureImporter;
			if (texImporter != null)
			{
				BuildScript.SetPlatformTextureSettings(texImporter, 1024);
				AssetDatabase.ImportAsset(texImporter.assetPath);
			}
		});
		AssetDatabase.RemoveUnusedAssetBundleNames();
		AssetDatabase.Refresh();
	}
	[MenuItem("LetUs/AssetBundles/Hybrid Build AssetBundles")]
	static public void HybridBuildAssetBundles()
	{
		BuildScript.HybridBuildAssetBundles(BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression);
	}

	[MenuItem("LetUs/AssetBundles/Hybrid Force Rebuild AssetBundles")]
	static public void HybridForceRebuildAssetBundles()
	{
		BuildScript.HybridBuildAssetBundles(BuildAssetBundleOptions.ForceRebuildAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression);
	}

	[MenuItem("LetUs/AssetBundles/Build EXE(Windows)")]
	static public void BuildEXE()
	{
		BuildScript.BuildEXE();
	}

	[MenuItem("LetUs/AssetBundles/Build APK(Android)/Build Debug")]
	static public void BuildAPK_Debug()
	{
		BuildScript.BuildAPK(true);
	}
	[MenuItem("LetUs/AssetBundles/Build APK(Android)/Build Release")]
	static public void BuildAPK_Release()
	{
		BuildScript.BuildAPK(false);
	}
	[MenuItem("LetUs/AssetBundles/Build IPA(iOS)/Build Debug")]
	static public void BuildIPA_Debug()
	{
		BuildScript.BuildIPA(true);
	}
	[MenuItem("LetUs/AssetBundles/Build IPA(iOS)/Build Release")]
	static public void BuildIPA_Release()
	{
		BuildScript.BuildIPA(false);
	}


}
/*
public class GraphicsSettingsIncludedShaders
{
	[MenuItem("LetUs/Auto Set Included Shaders")]
	static public void AutoGraphicsSettingsIncludedShaders()
	{
		DirectoryInfo dataDir = new DirectoryInfo(Application.dataPath);
		FileInfo[] mats = dataDir.GetFiles("*.mat", SearchOption.AllDirectories);
		Dictionary<string, string> usedShaders = new Dictionary<string, string>();
		foreach (FileInfo matFileInfo in mats)
		{
			string path = "Assets" + matFileInfo.FullName.Remove(0, Application.dataPath.Length);
			string[] deps = AssetDatabase.GetDependencies(path);
			foreach (string dep in deps)
			{
				FileInfo f = new FileInfo(dep);
				if (f.Extension.Equals(".shader"))
				{
					if (!usedShaders.ContainsKey(f.Name))
					{
						usedShaders.Add(f.Name, f.FullName);
					}
				}
			}
		}
		List<Shader> shaderRefs = new List<Shader>();
		foreach (string shaderName in usedShaders.Keys)
		{
			string fullPath;
			if (usedShaders.TryGetValue(shaderName, out fullPath))
			{
				string shaderPath = "Assets" + fullPath.Remove(0, Application.dataPath.Length);
				Shader shader = AssetDatabase.LoadMainAssetAtPath(shaderPath) as Shader;
				shaderRefs.Add(shader);
			}
		}
		SerializedObject graphicsSettings = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/GraphicsSettings.asset")[0]);
		SerializedProperty it = graphicsSettings.GetIterator();
		SerializedProperty dataPoint;
		while (it.NextVisible(true))
		{
			if (it.name == "m_AlwaysIncludedShaders")
			{
				it.ClearArray();

				for (int i = 0; i < shaderRefs.Count; i++)
				{
					it.InsertArrayElementAtIndex(i);
					dataPoint = it.GetArrayElementAtIndex(i);
					dataPoint.objectReferenceValue = shaderRefs[i];
				}

				graphicsSettings.ApplyModifiedProperties();
			}
		}
	}
}
*/
public class UIToolsMenuItems
{


	[MenuItem("LetUs/UI Tools/Sprite AssetBundle Checker")]
	static public void SpriteAssetBundleChecker()
	{
		// Get all the GUIDs (identifiers in project) of the Sprites in the Project
		string[] guids = AssetDatabase.FindAssets("t:sprite");

		// Dictionary to store the tags and bundle names
		Dictionary<string, string> dict = new Dictionary<string, string>();
		foreach (string guid in guids)
		{
			string path = AssetDatabase.GUIDToAssetPath(guid);
			Debug.Log(path);
			TextureImporter ti = TextureImporter.GetAtPath(path) as TextureImporter;

			// If the tag is not in the dictionary, add it
			if (!dict.ContainsKey(ti.spritePackingTag))
			{
				dict.Add(ti.spritePackingTag, ti.assetBundleName);
			}
			else
			{
				// If the tag is associated with another bundle name, show an error
				if (dict[ti.spritePackingTag] != ti.assetBundleName)
					Debug.LogWarning("Sprite : " + ti.assetPath + " should be packed in " + dict[ti.spritePackingTag]);
			}
		}
	}
	[MenuItem("LetUs/UI Tools/Find Unused Texture")]
	static public void FindUnusedTexture()
	{
		FindUnUnUsedUITexture.Scan();
	}

	[MenuItem("LetUs/UI Tools/Check Bundle Reference")]
	static public void CheckBundleRef()
	{
		CheckBundleRefEdtior editor = (CheckBundleRefEdtior)EditorWindow.GetWindow(typeof(CheckBundleRefEdtior));
		editor.Show();
	}
}

public class ReleasePreprocess
{
	[MenuItem("LetUs/Release Preprocess/Find Build Crash prefabs")]
	public static void FindCrashMissingPrefabs()
	{
		string[] allassetpaths = AssetDatabase.GetAllAssetPaths();
		EditorUtility.DisplayProgressBar("Bundle Crash Find", "Finding...", 0f);
		int len = allassetpaths.Length;
		int index = 0;
		foreach (var filePath in allassetpaths)
		{
			EditorUtility.DisplayProgressBar("Bundle Crash Find", filePath, (index + 0f) / (len + 0f));
			if (filePath.EndsWith(".prefab"))
			{
				GameObject fileObj = PrefabUtility.LoadPrefabContents(filePath);
				if (fileObj)
				{
					Component[] cps = fileObj.GetComponentsInChildren<Component>(true);
					foreach (var cp in cps)
					{
						if (cp)
						{
							PrefabInstanceStatus _type = PrefabUtility.GetPrefabInstanceStatus(cp.gameObject);
							if (_type == PrefabInstanceStatus.MissingAsset)
							{
								Debug.LogError("Crash Bundle Missing Prefab:Path=" + filePath + " Name:" + fileObj.name + " ComponentName:" + cp);
							}
						}
					}
				}
				PrefabUtility.UnloadPrefabContents(fileObj);
			}
			index++;
		}
		EditorUtility.ClearProgressBar();
	}

	[MenuItem("LetUs/Release Preprocess/Check Select Material")]
	public static void CleanSelectMaterial()
	{
		Material[] materials = Selection.GetFiltered<Material>(SelectionMode.Assets | SelectionMode.DeepAssets);
		foreach (var material in materials)
		{
			CleanOneMaterial(material);
		}
	}

	public static bool CleanOneMaterial(Material _material)
	{
		// 收集材质使用到的所有纹理贴图
		HashSet<string> textureGUIDs = CollectTextureGUIDs(_material);

		string materialPathName = Path.GetFullPath(AssetDatabase.GetAssetPath(_material));

		StringBuilder strBuilder = new StringBuilder();
		bool bChange = false;
		using (StreamReader reader = new StreamReader(materialPathName))
		{
			Regex regex = new Regex(@"\s+guid:\s+(\w+),");
			string line = reader.ReadLine();
			while (null != line)
			{
				if (line.Contains("m_Texture:"))
				{
					// 包含纹理贴图引用的行，使用正则表达式获取纹理贴图的guid
					Match match = regex.Match(line);
					if (match.Success)
					{
						string textureGUID = match.Groups[1].Value;
						if (textureGUIDs.Contains(textureGUID))
						{
							strBuilder.AppendLine(line);
						}
						else
						{
							// 材质没有用到纹理贴图，guid赋值为0来清除引用关系
							strBuilder.AppendLine(line.Substring(0, line.IndexOf("fileID:") + 7) + " 0}");
							bChange = true;
						}
					}
					else
					{
						strBuilder.AppendLine(line);
					}
				}
				else
				{
					strBuilder.AppendLine(line);
				}

				line = reader.ReadLine();
			}
		}

		if (bChange)
		{
			using (StreamWriter writer = new StreamWriter(materialPathName))
			{
				writer.Write(strBuilder.ToString());
			}
		}

		return true;
	}

	private static HashSet<string> CollectTextureGUIDs(Material _material)
	{
		HashSet<string> textureGUIDs = new HashSet<string>();
		for (int i = 0; i < ShaderUtil.GetPropertyCount(_material.shader); ++i)
		{
			if (ShaderUtil.ShaderPropertyType.TexEnv == ShaderUtil.GetPropertyType(_material.shader, i))
			{
				Texture texture = _material.GetTexture(ShaderUtil.GetPropertyName(_material.shader, i));
				if (null == texture)
				{
					continue;
				}

				string textureGUID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(texture));
				if (!textureGUIDs.Contains(textureGUID))
				{
					textureGUIDs.Add(textureGUID);
				}
			}
		}

		return textureGUIDs;
	}
}

public class StorageMenuItems
{
	[MenuItem("LetUs/Storage/Open Storage Folder")]
	public static void OpenStorageFolder()
	{
		string path = Application.persistentDataPath;
		EditorUtility.RevealInFinder(path);
	}
	
	[MenuItem("LetUs/Storage/Clear Storage File")]
	public static void ClearStorageFile()
	{
		string path = StorageUtil.GetStorageFilePath();
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}
}