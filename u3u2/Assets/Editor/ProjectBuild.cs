﻿using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;

class ProjectBuild : Editor
{

    //在这里找出你当前工程所有的场景文件，假设你只想把部分的scene文件打包 那么这里可以写你的条件判断 总之返回一个字符串数组。
    static string[] GetBuildScenes()
    {
        List<string> names = new List<string>();
        foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)
        {
            if (e == null)
                continue;
            if (e.enabled)
                names.Add(e.path);
        }
        return names.ToArray();
    }
    
    
    static void BuildForAndroid()
    {
        string projectName = BuildFunction.projectName;
        string projectVersion = BuildFunction.projectVersion;
        string outputFile = BuildFunction.outputFile;


		string serverlist = "http://patch.ts.wywlwx.com.cn/serverlist.xml";
		PlayerSettings.productName="梦回天书";
		PlayerSettings.applicationIdentifier = "com.u3u2.main";
		PlayerSettings.Android.bundleVersionCode=52;
//		setIcon ("Assets/Icon/default.png");
		setIcon("Assets/Icon/mi.png");
        switch (projectName)
        {
            case "anysdk":
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "ANYSDK");
                break;
            case "uc":
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "UC");
				PlayerSettings.productName="天书OL";
				PlayerSettings.applicationIdentifier = "com.gamedo.tianshuOL.uc";
				
				setIcon("Assets/Icon/uc.png");
                break;
            case "wingloong":
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "WINGLOONG");
				serverlist = "http://patch.ts.wywlwx.com.cn/serverlistzz.xml";
				break;
            case "zz":
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "ZZ");
				serverlist = "http://patch.ts.wywlwx.com.cn/serverlistzz.xml";
                break;
            case "mi":
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "MI");
                PlayerSettings.applicationIdentifier = "com.gamedo.menghuitianshu.mi";
				setIcon("Assets/Icon/mi.png");
                break;
             case "tsz":
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "TSZ");
				PlayerSettings.applicationIdentifier = "com.gamedo.menghuitianshu.qihoo";
				setIcon("Assets/Icon/mi.png");
                break;
			case "oppo":
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "OPPO");
				PlayerSettings.applicationIdentifier = "com.gamedo.menghuitianshu.nearme.gamecenter";
				break;
			case "vivo":
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "VIVO");
				PlayerSettings.applicationIdentifier = "com.gamedo.menghuitianshu.vivo";
				break;
			case "baidu":
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "BAIDU");
				PlayerSettings.applicationIdentifier = "com.gamedo.menghuitianshu.baidu";
				setIcon("Assets/Icon/baidu.png");
				break;
            case "yj":
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "YJ");
                break;
			case "huawei":
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "HUAWEI");
				PlayerSettings.applicationIdentifier = "com.gamedo.menghuitianshu.huawei";
				break;
            case "ysdk":
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "YSDK");
                PlayerSettings.applicationIdentifier = "com.tencent.tmgp.menghuitianshu";
		setIcon("Assets/Icon/ysdk.png");
		PlayerSettings.productName="天书奇谈";
                break;
            default:
				
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "");
                break;
        }

        PlayerSettings.Android.keystorePass = "1234qwerQWER";
        PlayerSettings.Android.keyaliasPass = "1234qwerQWER";

        PlayerSettings.bundleVersion = projectVersion;

        StreamWriter ws = File.CreateText(Application.dataPath + "/StreamingAssets/config/versionConfig.xml");
        ws.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        ws.WriteLine("<config>");
        ws.WriteLine("    <db_md5></db_md5>");
        ws.WriteLine("    <app_version>" + projectVersion + "</app_version>");
        ws.WriteLine("</config>");
        ws.Flush();
        ws.Close();
        
        ws = File.CreateText(Application.dataPath + "/StreamingAssets/config/config.xml");
        ws.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        ws.WriteLine("<config>");
		ws.WriteLine("    <server_list>"+serverlist+"</server_list>");
        ws.WriteLine("    <reyun_appid>b23b88f7c83cf5c821caee1e7fc09ab7</reyun_appid><!--reyun的产品唯一Id-->");
        ws.WriteLine("    <reyun_channel>devTest1Client</reyun_channel><!--reyun的渠道设置-->");
        ws.WriteLine("    <!--是否动态更新脚本只在非debug模式下生效，安卓默认是1，ios默认是0-->");
        ws.WriteLine("    <!--<external_scripts>0</external_scripts>-->");
        ws.WriteLine("    <!--是否动态更新美术资源只在非debug模式下生效，安卓默认是1，ios默认是1-->");
        ws.WriteLine("    <!--<external_arts>0</external_arts>-->");
        ws.WriteLine("    <!--是否启用debug模式，debug模式下使用本地资源和脚本-->");
        ws.WriteLine("    <debug>0</debug>");
        ws.WriteLine("</config>");
        ws.Flush();
        ws.Close();
        
        /*
		if (Directory.Exists (Application.dataPath + "/Plugins/sdk/")) {
			Directory.Delete (Application.dataPath + "/Plugins/sdk/", true);
		}
		if (File.Exists (Application.dataPath + "/Plugins/sdk.meta")) {
			File.Delete (Application.dataPath + "/Plugins/sdk.meta");
		}

		string projectName = BuildFunction.projectName;
		if (projectName != "wingloong") {
			Debug.Log ("拷贝" + projectName + "文件夹");
			BuildFunction.CopyDirectory("../sdks/android/" + projectName, Application.dataPath+"/Plugins/sdk/" + projectName);
		}
		*/
        
        AssetDatabase.Refresh();

        Debug.Log("开始打包");
        BuildPipeline.BuildPlayer(GetBuildScenes(), outputFile, BuildTarget.Android, BuildOptions.None);
        Debug.Log("打包结束");
    }
	static void setIcon(string iconDir)
	{
//		string iconDir = "Assets/Icon/icon_mi/";
//		string iconPaths = Directory.GetFiles(iconDir, "*.png", SearchOption.AllDirectories);
//		string iconDir;
//		string[] iconPaths;
		Texture2D[] icons = new Texture2D[6];
		int[] sizes = new int[]{192, 144, 96, 72, 48, 36};
		for(int i=0;i<icons.Length;i++) 
		{ 
			icons[i] = AssetDatabase.LoadAssetAtPath<Texture2D>(iconDir);
			icons [i].Resize (sizes[i], sizes[i]);
		}
		//icons [0].width = icons[0].height = 192;
		//icons [1].width = icons[1].height = 144;
		//icons [2].width = icons[2].height = 96;
		//icons [3].width = icons[3].height = 72;
		//icons [4].width = icons[4].height = 48;
		//icons [5].width = icons[5].height = 36;
//		for(int i=0;i<icons.Length;i++) 
//		{ 
//			icons[i] = AssetDatabase.LoadAssetAtPath<Texture2D>(iconPaths[i]);
//		}
		BuildTargetGroup targetGroup = BuildTargetGroup.Android;
		PlayerSettings.SetIconsForTargetGroup(targetGroup,icons);
	}
}
