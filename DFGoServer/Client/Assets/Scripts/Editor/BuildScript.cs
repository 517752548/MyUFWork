using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using LuaFramework;
using UnityEditor.Build.Reporting;
using System;
using Hybrid.Bundles;
using Gear;
using System.Text;

public class BuildScript : Editor
{
	public const string AB_VARIANT = "ab";
	public const string BUNDLE_FOLDER = "AssetBundles";
	public const string SCRIPTING_DEFINE_SYMBOLS_RELEASE_WINDOWS = "USE_RELEASE_WINDOWS";
	public const string SCRIPTING_DEFINE_SYMBOLS_RELEASE_ANDROID = "USE_RELEASE_ANDROID";
	public const string SCRIPTING_DEFINE_SYMBOLS_RELEASE_IOS = "USE_RELEASE_IOS";

	public static bool isBuildDebug = false;
	public delegate void OnIterAssetFile(FileInfo info, AssetImporter importer, string defAbName);

	public static List<string> GetFilesPathList(string folder, string ext, string[] _igroneFilesExt)
	{
		List<string> result = new List<string>();
		string[] igroneFilesExt = _igroneFilesExt;
		string PREFAB_FOLDER_NAME = folder;
		string fullPath = Path.Combine(Application.dataPath, PREFAB_FOLDER_NAME);
		fullPath = fullPath.Replace('/', '\\');
		string[] fullPathSplits = fullPath.Split(Path.DirectorySeparatorChar);
		if (!Directory.Exists(fullPath))
		{
			return null;
		}
		DirectoryInfo dir = new DirectoryInfo(fullPath);
		FileInfo[] files = dir.GetFiles("*" + ext, SearchOption.AllDirectories);
		foreach (FileInfo item in files)
		{
			string itemFullName = item.FullName;
			//如果有忽略的文件，跳过
			bool hasIgrone = false;
			for (int i = 0; i < igroneFilesExt.Length; i++)
			{
				if (itemFullName.EndsWith(igroneFilesExt[i]))
				{
					hasIgrone = true;
				}
			}
			if (hasIgrone)
			{
				continue;
			}
			string[] splitFullName = itemFullName.Split(Path.DirectorySeparatorChar);
			ArrayList list = new ArrayList();
			for (int i = fullPathSplits.Length; i < splitFullName.Length - 1; i++)
			{
				list.Add(splitFullName[i]);
			}
			string importerPath = "Assets/" + PREFAB_FOLDER_NAME + "/" + string.Join("/", (string[])list.ToArray(typeof(string))) + "/" + item.Name;
			importerPath = importerPath.Replace("//", "/");
			result.Add(importerPath);
		}
		return result;
	}

	public static void IterAssets(string folder, string[] _igroneFilesExt, OnIterAssetFile onIterAssetFile)
	{
		string[] igroneFilesExt = _igroneFilesExt;
		string PREFAB_FOLDER_NAME = folder;
		string fullPath = Path.Combine(Application.dataPath, PREFAB_FOLDER_NAME);
		fullPath = fullPath.Replace('/', '\\');
		string[] fullPathSplits = fullPath.Split(Path.DirectorySeparatorChar);
		if (!Directory.Exists(fullPath))
		{
			return;
		}

		DirectoryInfo dir = new DirectoryInfo(fullPath);
		FileInfo[] files = dir.GetFiles("*", SearchOption.AllDirectories);
		int currIndex = 0;
		foreach (FileInfo item in files)
		{
			currIndex++;
			EditorUtility.DisplayProgressBar("Progress", "请等待", (float)(currIndex / files.Length));
			string itemFullName = item.FullName;
			//如果有忽略的文件，跳过
			bool hasIgrone = false;
			for (int i = 0; i < igroneFilesExt.Length; i++)
			{
				if (itemFullName.EndsWith(igroneFilesExt[i]))
				{
					hasIgrone = true;
				}
			}
			if (hasIgrone)
			{
				continue;
			}
			string[] splitFullName = itemFullName.Split(Path.DirectorySeparatorChar);
			ArrayList list = new ArrayList();
			for (int i = fullPathSplits.Length; i < splitFullName.Length - 1; i++)
			{
				list.Add(splitFullName[i]);
			}
			string abName = string.Join("_", (string[])list.ToArray(typeof(string))) + '_' + Path.GetFileNameWithoutExtension(item.Name);
			string importerPath = "Assets/" + PREFAB_FOLDER_NAME + "/" + string.Join("/", (string[])list.ToArray(typeof(string))) + "/" + item.Name;
			importerPath = importerPath.Replace("//", "/");
			AssetImporter importer = AssetImporter.GetAtPath(importerPath);
			if (importer)
			{
				abName = abName.ToLower();
				if (abName.IndexOf(' ') >= 0)
				{
					Debug.LogError("发现有AssetBundleName中有非法字符:" + importerPath);
				}
				if (onIterAssetFile != null)
				{
					onIterAssetFile(item, importer, abName);
				}
			}
		}
		EditorUtility.ClearProgressBar();

	}

	public static void SetIconTextureSettings()
	{
		IterAssets("Res/Icon", new string[] { ".meta" }, delegate (FileInfo item, AssetImporter importer, string defAbName)
		{
			string dir = Path.GetDirectoryName(item.FullName) + "\\" + Path.GetFileNameWithoutExtension(item.FullName);
			string lowerDir = dir.ToLower();
			string _lowerDir = lowerDir.Replace("\\", "_");
			string abName = _lowerDir.Substring(_lowerDir.IndexOf("res_") + "res_".Length);

			if (_lowerDir.IndexOf("icon") >= 0)
			{
				TextureImporter texImporter = importer as TextureImporter;
				//不处理类型为“Lightmap”的Texture
				if ("Lightmap" != texImporter.textureType.ToString())
				{
					//修改 PackingTag
					texImporter.spritePackingTag = "";

					SetPlatformIconTextureSettings(texImporter);

					AssetDatabase.ImportAsset(texImporter.assetPath);
				}
			}

		});
		AssetDatabase.RemoveUnusedAssetBundleNames();
		AssetDatabase.Refresh();
	}

	public static void SetUITextureSettings()
	{

		IterAssets("Res/UI", new string[] { ".meta" }, delegate (FileInfo item, AssetImporter importer, string defAbName)
		{
			string dir = Path.GetDirectoryName(item.FullName);
			string lowerDir = dir.ToLower();
			string _lowerDir = lowerDir.Replace("\\", "_").Replace("/", "_");
			string abName = "";
			if (_lowerDir.IndexOf("ui_texture") >= 0)
			{
				abName = _lowerDir.Substring(_lowerDir.IndexOf("ui_texture"));
				TextureImporter texImporter = importer as TextureImporter;
				//不处理类型为“Lightmap”的Texture
				if ("Lightmap" != texImporter.textureType.ToString())
				{
					//修改 PackingTag
					texImporter.spritePackingTag = abName;

					SetPlatformUITextureSettings(texImporter);

					AssetDatabase.ImportAsset(texImporter.assetPath);
				}
			}

		});
		AssetDatabase.RemoveUnusedAssetBundleNames();
		AssetDatabase.Refresh();
	}

	public static void SetPlatformIconTextureSettings(TextureImporter texImporter)
	{
		//修改Texture Type
		texImporter.textureType = TextureImporterType.Sprite;
		//修改Aniso Level
		texImporter.anisoLevel = 9;
		//修改Read/Write enabled 
		//texImporter.isReadable = false;
		//修改Generate Mip Maps
		texImporter.mipmapEnabled = false;

		TextureImporterPlatformSettings tt_def = texImporter.GetDefaultPlatformTextureSettings();
		tt_def.textureCompression = TextureImporterCompression.CompressedLQ;
		tt_def.maxTextureSize = 2048;
		tt_def.crunchedCompression = false;
		texImporter.SetPlatformTextureSettings(tt_def);

		TextureImporterPlatformSettings tt_standalone = new TextureImporterPlatformSettings
		{
			name = "Standalone",
			maxTextureSize = 2048,
			format = texImporter.DoesSourceTextureHaveAlpha() ? TextureImporterFormat.RGBA32 : TextureImporterFormat.RGB24,
			overridden = true,
		};
		texImporter.SetPlatformTextureSettings(tt_standalone);

		TextureImporterPlatformSettings tt_android = new TextureImporterPlatformSettings
		{
			name = "Android",
			maxTextureSize = 2048,
			format = texImporter.DoesSourceTextureHaveAlpha() ? TextureImporterFormat.ETC2_RGBA8 : TextureImporterFormat.ETC2_RGB4,
			textureCompression = TextureImporterCompression.CompressedLQ,
			crunchedCompression = false,
			overridden = true,
			androidETC2FallbackOverride = AndroidETC2FallbackOverride.UseBuildSettings,
		};
		texImporter.SetPlatformTextureSettings(tt_android);

		TextureImporterPlatformSettings tt_ios = new TextureImporterPlatformSettings
		{
			name = "iPhone",
			maxTextureSize = 2048,
			format = texImporter.DoesSourceTextureHaveAlpha() ? TextureImporterFormat.ASTC_4x4 : TextureImporterFormat.ASTC_RGB_4x4,
			textureCompression = TextureImporterCompression.CompressedHQ,
			crunchedCompression = false,
			overridden = true,
		};
		texImporter.SetPlatformTextureSettings(tt_ios);

		TextureImporterSettings tis = new TextureImporterSettings();
		texImporter.ReadTextureSettings(tis);
		tis.spriteMeshType = SpriteMeshType.FullRect;
		texImporter.SetTextureSettings(tis);
	}
	public static void SetPlatformUITextureSettings(TextureImporter texImporter)
	{
		SetPlatformIconTextureSettings(texImporter);
		TextureImporterSettings tis = new TextureImporterSettings();
		texImporter.ReadTextureSettings(tis);
		tis.spriteMeshType = SpriteMeshType.Tight;
		texImporter.SetTextureSettings(tis);
	}

	public static void SetPlatformTextureSettings(TextureImporter texImporter, int limitMaxTextureSize = 1024)
	{
		if (texImporter.textureType != TextureImporterType.Default && texImporter.textureType != TextureImporterType.NormalMap)
		{
			return;
		}
		int targetMaxTextureSize = 0;
		int originalMaxTextureSize = 0;
		TextureImporterFormat originalPlatformTextureFmt;
		if (texImporter.GetPlatformTextureSettings("Standalone", out originalMaxTextureSize, out originalPlatformTextureFmt))
		{
			targetMaxTextureSize = originalMaxTextureSize;
		}
		else
		{
			targetMaxTextureSize = texImporter.GetDefaultPlatformTextureSettings().maxTextureSize;
		}
		targetMaxTextureSize = Mathf.Clamp(targetMaxTextureSize, 0, limitMaxTextureSize);
		TextureImporterPlatformSettings tt_standalone = new TextureImporterPlatformSettings
		{
			name = "Standalone",
			maxTextureSize = targetMaxTextureSize,
			format = (texImporter.DoesSourceTextureHaveAlpha() || texImporter.textureType == TextureImporterType.NormalMap) ? TextureImporterFormat.RGBA32 : TextureImporterFormat.RGB24,
			overridden = true,
		};
		texImporter.SetPlatformTextureSettings(tt_standalone);

		TextureImporterPlatformSettings tt_android = new TextureImporterPlatformSettings
		{
			name = "Android",
			maxTextureSize = targetMaxTextureSize,
			format = texImporter.DoesSourceTextureHaveAlpha() ? TextureImporterFormat.ETC2_RGBA8 : TextureImporterFormat.ETC2_RGB4,
			textureCompression = TextureImporterCompression.CompressedLQ,
			crunchedCompression = false,
			overridden = true,
			androidETC2FallbackOverride = AndroidETC2FallbackOverride.UseBuildSettings,
		};
		texImporter.SetPlatformTextureSettings(tt_android);

		TextureImporterPlatformSettings tt_ios = new TextureImporterPlatformSettings
		{
			name = "iPhone",
			maxTextureSize = targetMaxTextureSize,
			format = texImporter.DoesSourceTextureHaveAlpha() ? TextureImporterFormat.ASTC_4x4 : TextureImporterFormat.ASTC_RGB_4x4,
			textureCompression = TextureImporterCompression.CompressedHQ,
			crunchedCompression = false,
			overridden = true,
		};
		texImporter.SetPlatformTextureSettings(tt_ios);
	}

	static void ClearAllLuaFiles()
	{
		string osPath = Application.streamingAssetsPath;

		if (Directory.Exists(osPath))
		{
			string[] files = Directory.GetFiles(osPath, "Lua*.unity3d");

			for (int i = 0; i < files.Length; i++)
			{
				File.Delete(files[i]);
			}
		}

		string path = osPath + "/Lua";

		if (Directory.Exists(path))
		{
			Directory.Delete(path, true);
		}

		path = Application.streamingAssetsPath + "/Lua";

		if (Directory.Exists(path))
		{
			Directory.Delete(path, true);
		}

		path = Application.dataPath + "/temp";

		if (Directory.Exists(path))
		{
			Directory.Delete(path, true);
		}

		path = Application.dataPath + "/Resources/Lua";

		if (Directory.Exists(path))
		{
			Directory.Delete(path, true);
		}

		path = Application.persistentDataPath + "/Lua";

		if (Directory.Exists(path))
		{
			Directory.Delete(path, true);
		}
	}

	static string CreateStreamDir(string dir)
	{
		dir = Application.streamingAssetsPath + "/" + dir;

		if (!File.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}

		return dir;
	}


	public static void CopyLuaBytesFiles(string sourceDir, string destDir, bool appendext = true, string searchPattern = "*.lua", SearchOption option = SearchOption.AllDirectories)
	{
		if (!Directory.Exists(sourceDir))
		{
			return;
		}

		string[] files = Directory.GetFiles(sourceDir, searchPattern, option);
		int len = sourceDir.Length;

		if (sourceDir[len - 1] == '/' || sourceDir[len - 1] == '\\')
		{
			--len;
		}

		for (int i = 0; i < files.Length; i++)
		{
			string str = files[i].Remove(0, len);
			str = str.Replace("\\", "/");
			string dest = destDir + str;
			if (appendext) dest += ".bytes";
			string dir = Path.GetDirectoryName(dest);
			Directory.CreateDirectory(dir);
			bool byteMode = true;
			switch (EditorUserBuildSettings.activeBuildTarget)
			{
				case BuildTarget.StandaloneWindows:
				case BuildTarget.StandaloneWindows64:
				case BuildTarget.Android:
					byteMode = false;
					break;
				case BuildTarget.iOS:
				case BuildTarget.StandaloneOSX:
					byteMode = false;
					break;
			}

			if (byteMode)
			{
				EncodeLuaFile(files[i], dest);
			}
			else
			{
				File.Copy(files[i], dest, true);
			}
		}
	}

	public static void EncodeLuaFile(string srcFile, string outFile)
	{
		if (!srcFile.ToLower().EndsWith(".lua"))
		{
			File.Copy(srcFile, outFile, true);
			return;
		}
		string luaexe = string.Empty;
		string args = string.Empty;
		string exedir = string.Empty;
		string currDir = Directory.GetCurrentDirectory();
		bool isWin = Application.platform == RuntimePlatform.WindowsEditor;
		args = "-b -g " + srcFile + " " + outFile;
		if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows64)
		{
			luaexe = "luajit64.exe";
			exedir = "LuaEncoder/Luajit64/";
		}
		else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows)
		{
			if (IntPtr.Size == 4)
			{
				luaexe = "luajit32.exe";
				exedir = "LuaEncoder/Luajit/";
			}
			else if (IntPtr.Size == 8) //64位
			{
				luaexe = "luajit64.exe";
				exedir = "LuaEncoder/Luajit64/";
			}
		}
		else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
		{
			if (Application.platform == RuntimePlatform.OSXEditor)
			{
				luaexe = "./luajit";
				exedir = "LuaEncoder/luajit_mac/";
			}
		}
		else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)//TODO安卓这部分要兼容32位和64位，需要打两份，分别存储，都放到包里，然后在手机上游戏启动判断IntPtr.Size是4还是8，分别加载不同的luabytecode
		{
			if (Application.platform == RuntimePlatform.OSXEditor)
			{
				luaexe = "./luajit";
				exedir = "LuaEncoder/luajit_mac32/";
			}
			else
			{
				//目前只做32位的，如果需要上googleplay就需要打32位和64位两份了
				luaexe = "luajit32.exe";
				exedir = "LuaEncoder/Luajit/";
			}

		}
		Directory.SetCurrentDirectory(Path.Combine(Application.dataPath.Replace("Assets", ""), exedir));
		System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
		info.FileName = luaexe;
		info.Arguments = args;
		info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		info.UseShellExecute = isWin;
		info.ErrorDialog = true;
		Debug.Log(info.FileName + " " + info.Arguments);

		System.Diagnostics.Process pro = System.Diagnostics.Process.Start(info);
		pro.WaitForExit();
		if (Application.platform == RuntimePlatform.OSXEditor)
		{
			pro.Close();
		}
		Directory.SetCurrentDirectory(currDir);
	}

	static void GetAllDirs(string dir, List<string> list)
	{
		string[] dirs = Directory.GetDirectories(dir);
		list.AddRange(dirs);

		for (int i = 0; i < dirs.Length; i++)
		{
			GetAllDirs(dirs[i], list);
		}
	}

	static void BuildLuaBundle(List<AssetBundleBuild> abbList, string subDir, string sourceDir)
	{
		string[] files = Directory.GetFiles(sourceDir + subDir, "*.bytes");
		string bundleName = subDir == null ? "lua" : "lua" + subDir.Replace('/', '_');
		bundleName = bundleName.ToLower();

		AssetBundleBuild abb = new AssetBundleBuild();
		abb.assetBundleName = bundleName;
		abb.assetBundleVariant = "unity3d";
		abb.assetNames = files;
		abbList.Add(abb);
	}

	static List<string> paths = new List<string>();
	static List<string> files = new List<string>();

	static void Recursive(string path)
	{
		string[] names = Directory.GetFiles(path);
		string[] dirs = Directory.GetDirectories(path);
		foreach (string filename in names)
		{
			string ext = Path.GetExtension(filename);
			if (ext.Equals(".meta")) continue;
			files.Add(filename.Replace('\\', '/'));
		}
		foreach (string dir in dirs)
		{
			paths.Add(dir.Replace('\\', '/'));
			Recursive(dir);
		}
	}
	static void BuildVersionsFile(string resPath, string verionStr)
	{
		string newFilePath = resPath + "buildversion.txt";
		if (File.Exists(newFilePath)) File.Delete(newFilePath);
		FileStream fs = new FileStream(newFilePath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		sw.WriteLine(verionStr);
		sw.Close(); fs.Close();
	}
	static void BuildFileIndex(string resPath)
	{
		string newFilePath = resPath + "files.txt";
		if (File.Exists(newFilePath)) File.Delete(newFilePath);

		paths.Clear(); files.Clear();
		Recursive(resPath);

		FileStream fs = new FileStream(newFilePath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		for (int i = 0; i < files.Count; i++)
		{
			string file = files[i];
			if (file.EndsWith(".manifest") || file.EndsWith(".meta") || file.Contains(".DS_Store") || file.Contains(".vscode") || file.Contains(".svn")) continue;
			int startIndex = file.IndexOf("Assets/");
			GFileBundleInfo fbi = new GFileBundleInfo();
			fbi.name = file.Replace(resPath, string.Empty);
			fbi.byteSize = new FileInfo(file).Length;
			fbi.crcOrMD5Hash = Util.md5file(file);
			//TODO这里以后会改，如果在HybirdBundles中配置了这个bundle不是BASIC包的。那么他的location就不是STREAMINGASSETS应该是CDN
			//这样的话，GResManager加载的时候就能知道，这个文件本地目前没有
			//如果游戏过程中下载过，那么会改成STORAGE
			fbi.location = BundleStorageLocation.STREAMINGASSETS;
			fbi.package = BundlePackage.BASIC; //TODO今后会根据HybirdBundles中配置来赋值
			sw.WriteLine(fbi.Output());
		}
		sw.Close(); fs.Close();
	}

	static void BuildBundleIndex(string resPath, Dictionary<string, List<string>> abDict)
	{
		string newFilePath = resPath + "bundles_table.txt";
		if (File.Exists(newFilePath)) File.Delete(newFilePath);

		string prefix = "Assets/Res/";
		FileStream fs = new FileStream(newFilePath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		foreach (string key in abDict.Keys)
		{
			foreach (string path in abDict[key])
			{
				sw.WriteLine(path.Substring(path.IndexOf(prefix) + prefix.Length) + "|" + key);
			}
		}
		sw.Close(); fs.Close();
	}

	public static string CalcCSharpMD5()
	{
		List<string> folders = new List<string>();
		folders.Add("ThirdParty/DOTween");
		folders.Add("LuaFramework");
		folders.Add("Plugins");
		folders.Add("Scripts/Gear");
		paths.Clear(); files.Clear();
		foreach (string f in folders)
		{
			string absPath = Path.Combine(Application.dataPath, f);
			Recursive(absPath);
		}
		List<string> csharpFiles = new List<string>();
		foreach (string csf in files)
		{
			if (Path.GetExtension(csf).Equals(".cs"))
				csharpFiles.Add(csf);
		}
		csharpFiles.Sort();
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < csharpFiles.Count; i++)
		{
			string cs = csharpFiles[i];
			string content = File.ReadAllText(cs);
			sb.Append(content);
		}
		return Util.md5(sb.ToString());
	}

	public static void HybridBuildAssetBundles(BuildAssetBundleOptions buildOptions)
	{
		Caching.ClearCache();
		string currCSMD5 = CalcCSharpMD5();
		HybridBundlesBuildVersion buildVersions = null;
		switch (EditorUserBuildSettings.activeBuildTarget)
		{
			case BuildTarget.StandaloneWindows:
			case BuildTarget.StandaloneWindows64:
				buildVersions = AssetDatabase.LoadMainAssetAtPath("Assets/HybridBundlesBuildVersionDataWindows.asset") as HybridBundlesBuildVersion;
				break;
			case BuildTarget.Android:
				buildVersions = AssetDatabase.LoadMainAssetAtPath("Assets/HybridBundlesBuildVersionDataAndroid.asset") as HybridBundlesBuildVersion;
				break;
			case BuildTarget.iOS:
				buildVersions = AssetDatabase.LoadMainAssetAtPath("Assets/HybridBundlesBuildVersionDataIOS.asset") as HybridBundlesBuildVersion;
				break;
		}

		Version version = new Version(buildVersions.bundleVersion);
		int build = version.Build;
		if (currCSMD5.Equals(buildVersions.csharpMD5) == false)
			build++;
		//版本号在项目中的定义如下
		//Major表示游戏内容版本，一般游戏不同资料片这种大的内容更新情况下这个会变化								--手动改
		//Minor表示不同渠道，每个渠道会有一个固定的Minor，同一个渠道的Minor不会变化							--手动改
		//Build表示涉及到C#或必须更新整个安装包的版本,如果Build发生变化，那么需要重新下载安装包重新安装			--打包脚本自动改
		//Revision表示每次构建游戏的版本																	--打包脚本自动改
		//注：以上4个版本号如果只有Revision发生变化表示可以热更新
		Version newVersion = new Version(version.Major, version.Minor, build, version.Revision + 1);
		buildVersions.bundleVersion = newVersion.ToString();
		buildVersions.csharpMD5 = currCSMD5;
		EditorUtility.SetDirty(buildVersions);
		AssetDatabase.SaveAssets();

		AssetDatabase.Refresh();
		//要构建的Bundle列表
		List<AssetBundleBuild> abbList = new List<AssetBundleBuild>();
		ClearAllLuaFiles();

		CreateStreamDir(BUNDLE_FOLDER + "/" + PlatformUtil.GetPlatformName());
		Caching.ClearCache();

		string tempDir = Application.dataPath + "/temp/Lua";

		if (!File.Exists(tempDir))
		{
			Directory.CreateDirectory(tempDir);
		}

		//找出lua代码的所有目录，写入LuaBundles.lua中
		List<string> luaDirs = new List<string>();
		GetAllDirs(LuaConst.luaDir, luaDirs);
		List<string> luaBundleList = new List<string>();
		foreach (string luaDir in luaDirs)
		{
			if (luaDir.IndexOf("lua\\bootstrap") >= 0)
			{
				continue;
			}
			string dir = luaDir.Remove(0, LuaConst.luaDir.Length);
			luaBundleList.Add("lua" + dir.Replace('/', '_').Replace('\\', '_') + ".unity3d");
		}
		string luaBundleFilePath = LuaConst.luaDir + "/" + "bootstrap/LuaBundles.lua";
		if (File.Exists(luaBundleFilePath))
			File.Delete(luaBundleFilePath);

		FileStream fs = new FileStream(luaBundleFilePath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		sw.WriteLine("--自动生成，不要手写，用于启动游戏的时候确定加载哪些lua的bundles");
		sw.WriteLine("_G.LuaBundles={");
		foreach (string luaBundle in luaBundleList)
		{
			sw.WriteLine(string.Format("\t'{0}',", luaBundle));
		}
		sw.WriteLine("}");
		sw.Close(); fs.Close();
		//开始复制lua代码,复制到temp/Lua目录中，并且文件名后加.bytes
		Debug.Log("开始复制lua代码,复制到temp/Lua目录中，并且文件名后加.bytes");
		CopyLuaBytesFiles(LuaConst.luaDir, tempDir);
		CopyLuaBytesFiles(LuaConst.toluaDir, tempDir);

		AssetDatabase.Refresh();
		List<string> dirs = new List<string>();
		GetAllDirs(tempDir, dirs);

		for (int i = 0; i < dirs.Count; i++)
		{
			string str = dirs[i].Remove(0, tempDir.Length);
			BuildLuaBundle(abbList, str.Replace('\\', '/'), "Assets/temp/Lua");
		}

		BuildLuaBundle(abbList, null, "Assets/temp/Lua");
		AssetDatabase.RemoveUnusedAssetBundleNames();
		AssetDatabase.Refresh();
		AssetDatabase.SaveAssets();
		string output = string.Format("{0}/{1}/{2}/", Application.streamingAssetsPath, BUNDLE_FOLDER, PlatformUtil.GetPlatformName());
		if ((buildOptions & BuildAssetBundleOptions.ForceRebuildAssetBundle) == BuildAssetBundleOptions.ForceRebuildAssetBundle)
		{
			if (Directory.Exists(output))
			{
				Directory.Delete(output, true);
			}
			Directory.CreateDirectory(output);
		}
		AssetDatabase.Refresh();
		MyTreeAsset m_MyTreeAsset = AssetDatabase.LoadMainAssetAtPath(HybridBundlesConsts.DATA_PATH) as MyTreeAsset;
		//Initialize tree
		BaseTreeElementUtility.ListToTree(m_MyTreeAsset.treeElements);
		Dictionary<string, List<string>> abDict = new Dictionary<string, List<string>>();
		foreach (HybridBundlesTreeElement item in m_MyTreeAsset.treeElements)
		{
			if (item.depth == -1)
			{
				continue;
			}
			string fullPath = Application.dataPath + "/Res" + item.path;
			fullPath = fullPath.Replace('\\', '/');

			DirectoryInfo folder = new DirectoryInfo(fullPath);
			FileInfo[] files = folder.GetFiles();
			foreach (FileInfo file in files)
			{
				if (file.FullName.EndsWith(".manifest") || file.FullName.EndsWith(".meta") || file.FullName.Contains(".DS_Store") || file.FullName.Contains(".vscode") || file.FullName.Contains(".svn"))
				{
					continue;
				}
				string abname = HybridBundlesConsts.GetFolderBundleNameForEditor(item.path, item);
				abname = abname.Replace("{filename}", Path.GetFileNameWithoutExtension(file.Name).ToLower());
				abname = abname.Replace("{fileextension}", Path.GetExtension(file.Name).Replace(".", "").ToLower());
				List<string> assetList;
				if (!abDict.TryGetValue(abname, out assetList))
				{
					assetList = new List<string>();
					abDict[abname] = assetList;
				}
				string assetPath = file.FullName;
				assetPath = assetPath.Replace('\\', '/');
				assetPath = assetPath.Substring(assetPath.IndexOf(Application.dataPath) + Application.dataPath.Length);
				assetPath = "Assets" + assetPath;
				assetList.Add(assetPath);
			}
		}

		foreach (string key in abDict.Keys)
		{
			AssetBundleBuild abb = new AssetBundleBuild();
			abb.assetBundleName = key;
			abb.assetBundleVariant = AB_VARIANT;
			abb.assetNames = abDict[key].ToArray();
			abbList.Add(abb);
		}
		BuildPipeline.BuildAssetBundles(output, abbList.ToArray(), buildOptions, EditorUserBuildSettings.activeBuildTarget);
		BuildBundleIndex(output, abDict);
		Debug.Log("BuildVersion:" + buildVersions.bundleVersion);
		BuildVersionsFile(output, buildVersions.bundleVersion);
		BuildFileIndex(output);
		Directory.Delete(Application.dataPath + "/temp/", true);

		MoveManifestFilesToTempFolder();
		AssetDatabase.Refresh();
	}


	public static BuildPlayerOptions GetBuildPlayerOptions()
	{
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
		List<string> sceneStrList = new List<string>();
		//foreach (EditorBuildSettingsScene s in scenes)
		//{
		//	sceneStrList.Add(s.path);
		//	Debug.Log("Add [" + s.path + "] to build scene list");
		//}
		sceneStrList.Add(scenes[0].path);
		Debug.Log("Add [" + scenes[0].path + "] to build scene list");
		buildPlayerOptions.scenes = sceneStrList.ToArray();
		return buildPlayerOptions;
	}

	static void MoveManifestFilesToTempFolder()
	{
		string output = string.Format("{0}/{1}/{2}/", Application.streamingAssetsPath, BUNDLE_FOLDER, PlatformUtil.GetPlatformName());
		string tempFolder = Path.Combine(Application.dataPath.Replace("Assets", ""), "TempManifests");
		if (Directory.Exists(tempFolder))
		{
			Directory.Delete(tempFolder, true);
		}
		Directory.CreateDirectory(tempFolder);
		//把.manifest的文件从output文件夹移动到外面的临时文件夹中
		string[] manifestFilesPath = Directory.GetFiles(output, "*.manifest");
		foreach (string mffp in manifestFilesPath)
		{
			Directory.Move(mffp, Path.Combine(tempFolder, Path.GetFileName(mffp)));
		}
	}

	static void MoveManifestFilesToAssetBundlesFolder()
	{
		string output = string.Format("{0}/{1}/{2}/", Application.streamingAssetsPath, BUNDLE_FOLDER, PlatformUtil.GetPlatformName());
		string tempFolder = Path.Combine(Application.dataPath.Replace("Assets", ""), "TempManifests");
		if (!Directory.Exists(output))
			return;
		if (!Directory.Exists(tempFolder))
			return;
		string[] manifestFilesPath = Directory.GetFiles(tempFolder, "*.manifest");
		foreach (string mffp in manifestFilesPath)
		{
			Directory.Move(mffp, Path.Combine(output, Path.GetFileName(mffp)));
		}
		Directory.Delete(tempFolder, true);
	}

	public static void BuildEXE()
	{
		string oldScriptDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
		if (oldScriptDefineSymbols.IndexOf(SCRIPTING_DEFINE_SYMBOLS_RELEASE_WINDOWS) <= 0)
		{
			if (oldScriptDefineSymbols.EndsWith(";") == false)
			{
				oldScriptDefineSymbols += ";";
			}
			oldScriptDefineSymbols += SCRIPTING_DEFINE_SYMBOLS_RELEASE_WINDOWS;
		}
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, oldScriptDefineSymbols);

		BuildPlayerOptions buildPlayerOptions = GetBuildPlayerOptions();
		buildPlayerOptions.locationPathName = "Release/Windows/LetUs.exe";
		buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
		buildPlayerOptions.options = BuildOptions.Development | BuildOptions.AllowDebugging;
		BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildSummary summary = report.summary;
		MoveManifestFilesToAssetBundlesFolder();

		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("Build succeeded: " + summary.totalSize / 1024f / 1024f + " MB");
		}

		if (summary.result == BuildResult.Failed)
		{
			Debug.Log("Build failed");
		}
	}

	public static void BuildAPK(bool isDebug)
	{
		isBuildDebug = isDebug;
		string oldScriptDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);
		if (oldScriptDefineSymbols.IndexOf(SCRIPTING_DEFINE_SYMBOLS_RELEASE_ANDROID) <= 0)
		{
			if (oldScriptDefineSymbols.EndsWith(";") == false)
			{
				oldScriptDefineSymbols += ";";
			}
			oldScriptDefineSymbols += SCRIPTING_DEFINE_SYMBOLS_RELEASE_ANDROID;
		}
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, oldScriptDefineSymbols);

		EditorUserBuildSettings.androidBuildSubtarget = MobileTextureSubtarget.Generic;
		EditorUserBuildSettings.androidETC2Fallback = AndroidETC2Fallback.Quality32Bit;
		EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
		EditorUserBuildSettings.androidBuildType = isBuildDebug ? AndroidBuildType.Development : AndroidBuildType.Release;
		EditorUserBuildSettings.exportAsGoogleAndroidProject = false;

		BuildPlayerOptions buildPlayerOptions = GetBuildPlayerOptions();
		if (EditorUserBuildSettings.exportAsGoogleAndroidProject == false)
		{
			buildPlayerOptions.locationPathName = "Release/Android/LetUs.apk";
		}
		else
		{
			buildPlayerOptions.locationPathName = "Release/Android";
		}
		buildPlayerOptions.target = BuildTarget.Android;
		buildPlayerOptions.options = isBuildDebug ? BuildOptions.Development | BuildOptions.AllowDebugging | BuildOptions.ConnectWithProfiler : BuildOptions.None;
		BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildSummary summary = report.summary;
		MoveManifestFilesToAssetBundlesFolder();

		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("Build succeeded: " + summary.totalSize / 1024f / 1024f + " MB");
		}

		if (summary.result == BuildResult.Failed)
		{
			Debug.Log("Build failed");
		}
	}

	public static void BuildIPA(bool isDebug)
	{
		isBuildDebug = isDebug;
		string oldScriptDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);
		if (oldScriptDefineSymbols.IndexOf(SCRIPTING_DEFINE_SYMBOLS_RELEASE_IOS) <= 0)
		{
			if (oldScriptDefineSymbols.EndsWith(";") == false)
			{
				oldScriptDefineSymbols += ";";
			}
			oldScriptDefineSymbols += SCRIPTING_DEFINE_SYMBOLS_RELEASE_IOS;
		}
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, oldScriptDefineSymbols);

		BuildPlayerOptions buildPlayerOptions = GetBuildPlayerOptions();
		buildPlayerOptions.locationPathName = "Release/iOS/build_project";
		buildPlayerOptions.target = BuildTarget.iOS;
		buildPlayerOptions.options = BuildOptions.Development | BuildOptions.AllowDebugging | BuildOptions.ConnectWithProfiler;
		BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildSummary summary = report.summary;
		MoveManifestFilesToAssetBundlesFolder();

		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("Build succeeded: " + summary.totalSize / 1024f / 1024f + " MB");
		}

		if (summary.result == BuildResult.Failed)
		{
			Debug.Log("Build failed");
		}
	}
}

