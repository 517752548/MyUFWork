using BetaFramework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FastBundle.Editor;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.Experimental.AssetBundlePatching;
using UnityEngine.Purchasing.Security;

public class FrameworkMenuTool : EditorWindow
{
    private const string k_MenuItemLocation = "Framework";
    private const string k_AssetBundlesMenu = "AssetBundles";
    private const string k_OnLineAssetBundlesBuilderMenu = "生成在线bundle表";
    private const string k_AssetBundlesSimulateMenu = "Simulation Mode";
    private const string k_LocalizationMenu = "Localization";
    private const string k_LocalizationUpdateMenu = "UpdateLocalization";
    private const string k_ExcelMenu = "Excel Data Editor";
    private const string k_PersistentDataPath = "Open PersistentDataPath";
    

    [MenuItem(k_MenuItemLocation + "/" + k_LocalizationMenu + "/" + k_LocalizationUpdateMenu)]
    private static void OpenLanguageEditorWindow()
    {
        EditorWindow.GetWindow(typeof(LanguageEditor));
    }

    [MenuItem(k_MenuItemLocation + "/" + k_ExcelMenu)]
    private static void OpenExcelEditorWindow()
    {        
		EditorWindow.GetWindow<ExcelWindow>();
    }
    

    [MenuItem(k_MenuItemLocation + "/" + k_PersistentDataPath)]
    private static void OpenPersistentDataPath()
    {
        System.Diagnostics.Process.Start(Application.persistentDataPath);
        System.Diagnostics.Process.Start(Application.persistentDataPath + "Caches/");
    }
    
//    [MenuItem(k_MenuItemLocation + "/test")]
//    private static void Test()
//    {
//       int info = LevelData.GetAbsLevelIndex(2,1,3);
//        Debug.LogError(info);
//       int[] info2 = LevelData.GetAbsLevelInfo(3);
//       Debug.LogError(string.Format("{0}-{1}-{2}",info2[0],info2[1],info2[2]));
//    }

    [MenuItem ("Framework/Bundle/ClearAllBundles")]  
    public static void ClearAllBundles ()
    {
        Caching.ClearCache();
//        FileTool.DeleteDirectory(Application.dataPath.Substring(0,Application.dataPath.LastIndexOf('/')) + "/AssetBundles");
//        FileTool.DeleteDirectory(Application.streamingAssetsPath + "/AssetBundles");
        AssetDatabase.Refresh();
    }  

    [MenuItem ("Framework/Bundle/RecreatViewConst.cs")]  
    public static void AddressablesFileConfig()
    {
        AddressablesBundleBuildScript.CreatConfig();
    }
		
    [MenuItem ("Framework/Bundle/Addressables")]  
    public static void AddressablesFileSelect()
    {  
        AddressablesBundleBuildScript.AddFileToAddressables();
    }
    
    [MenuItem ("Framework/Bundle/HotUpdateAddressables")]  
    public static void AddressablesFileSelectHotUpdate()
    {  
        AddressablesBundleBuildScript.AddFileToAddressablesHotUpdate();
    }
    
	[MenuItem("Framework/Bundle/UpdateWordLibrary")]
	public static void WordLibrary() {
		AddressablesBundleBuildScript.UpdateWordLibrary();
	}
    
	[MenuItem("Framework/Bundle/DeleteServerData")]
	public static void MoveToStreaming() {
		if (EditorApplication.isCompiling) {
			return;
		}
        string path = Application.dataPath.Replace("Assets", "ServerData");
        Debug.LogError(path);
        Directory.Delete(path,true);
        Directory.CreateDirectory(path);
		AssetDatabase.Refresh();
	}
    [MenuItem("Framework/Image/CopyIosToAndroid")]
    public static void ChangeAndroidImageType()
    {
        Debug.LogWarning("开始");
        UnityEngine.Object[] selectedAsset = Selection.GetFiltered(typeof(Texture), SelectionMode.DeepAssets);
        for (int i = 0; i < selectedAsset.Length; i++)
        {
            Texture2D tex = selectedAsset[i] as Texture2D;
            TextureImporter ti = (TextureImporter) TextureImporter.GetAtPath(AssetDatabase.GetAssetPath(tex));
            int size = 1024;
            TextureImporterFormat format = TextureImporterFormat.ASTC_RGBA_6x6;
            TextureImporterPlatformSettings platformTextureSettings = new TextureImporterPlatformSettings();
            platformTextureSettings.name = "Android";
            platformTextureSettings.overridden = true;
            platformTextureSettings.maxTextureSize = size;
            platformTextureSettings.format = format;
            ti.SetPlatformTextureSettings(platformTextureSettings);
            //ti.SetPlatformTextureSettings("Android", size, format);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(tex));
        }
    }
    
    [MenuItem("Framework/Image/FormatKnowledgeCrads")]
    public static void FormatKnowledgeCrads()
    {
        Debug.LogWarning("开始");
        UnityEngine.Object[] selectedAsset = Selection.GetFiltered(typeof(Texture), SelectionMode.DeepAssets);
        for (int i = 0; i < selectedAsset.Length; i++)
        {
            Texture2D tex = selectedAsset[i] as Texture2D;
            TextureImporter ti = (TextureImporter) TextureImporter.GetAtPath(AssetDatabase.GetAssetPath(tex));
            int size = 1024;
            TextureImporterFormat format = TextureImporterFormat.ASTC_RGBA_8x8;
            TextureImporterPlatformSettings platformTextureSettings = new TextureImporterPlatformSettings();
            platformTextureSettings.name = "Android";
            platformTextureSettings.overridden = true;
            platformTextureSettings.maxTextureSize = size;
            platformTextureSettings.format = format;
            ti.SetPlatformTextureSettings(platformTextureSettings);
            TextureImporterPlatformSettings platformTextureSettingsios = new TextureImporterPlatformSettings();
            platformTextureSettingsios.name = "iOS";
            platformTextureSettingsios.overridden = true;
            platformTextureSettingsios.maxTextureSize = size;
            platformTextureSettingsios.format = format;
            ti.SetPlatformTextureSettings(platformTextureSettingsios);
            //ti.SetPlatformTextureSettings("Android", size, format);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(tex));
        }
    }
}