using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Gear;
#if UNITY_EDITOR
using UnityEditor;
#endif
using LuaFramework;

public class GResManager : MonoBehaviour, ITicker
{
	public delegate void OnCompleteDelegate();
	public delegate void OnErrorDelegate();
	public delegate void OnLoadItemCompleteDelegate();
	public delegate void OnLoadAssetCompleteDelegate(Object obj);
	public delegate void OnLoadAllAssetCompleteDelegate(Object[] objs);
	public delegate void OnLoadPrefabCompleteDelegate(GameObject gameObject);
	public delegate void OnLoadTexture2DCompleteDelegate(Texture2D texture2D);
	public delegate void OnLoadSpriteCompleteDelegate(Sprite sprite);
	public delegate void OnLoadAllSpriteInAtlasCompleteDelegate(AtlasInfo atlasInfo);
	public delegate void OnLoadAnimationClipCompleteDelegate(AnimationClip clip);
	public delegate void OnLoadScriptableObjectCompleteDelegate(ScriptableObject scriptableObject);
	public delegate void OnLoadMeshCompleteDelegate(Mesh mesh);
	public delegate void OnLoadMaterialCompleteDelegate(Material mat);
	public delegate void OnLoadAudioClipCompleteDelegate(AudioClip audio);
	public delegate void OnLoadFontCompleteDelegate(Font font);
	public const string ASSETBUNDLE_FOLDER = "AssetBundles";
	public const string VARIANT = ".ab";
	public const string ASSET_PATH_PREFIX = "Assets/Res/";
	private AssetBundleManifest assetBundleManifest;
	class LoadingAssetBundleRequest
	{
		public string assetBundleName;
		public OnLoadItemCompleteDelegate onComplete;
	}
	private List<string> loadingAssetBundleNames;
	private Dictionary<string, List<LoadingAssetBundleRequest>> loadingBundleRequests;
	private Dictionary<string, string[]> dependenciesCache;
	private Dictionary<string, LoadedAssetBundle> loadedAssetBundles;
	//bundle和文件的对应表
	private Dictionary<string, string> bundleTable = new Dictionary<string, string>();
	private static GResManager _instance;

	class AppConfigJSONData
	{
		public bool hot_update_enabled = false;
		public string hot_update_cdn_prefix = "";
	}
	private AppConfigJSONData appConfigData;
	private bool initialized = false;
	public static GResManager GetInstance()
	{
		return LuaHelper.GetResManager();
	}

	public void Init()
	{
		LoadBundlesTable();

		loadingAssetBundleNames = new List<string>();
		loadingBundleRequests = new Dictionary<string, List<LoadingAssetBundleRequest>>();
		dependenciesCache = new Dictionary<string, string[]>();
		loadedAssetBundles = new Dictionary<string, LoadedAssetBundle>();

		LoadManifest();
		LoadAndWarmUpShaderBundle();
		initialized = true;
		//StartCoroutine("CheckLoading");
	}

	public void LoadBundlesTable()
	{
		//解析bundle和文件的对应表
		if (!PlatformUtil.IsRunInEditor())
		{
			string[] files = File.ReadAllLines(Util.DataPath + "bundles_table.txt");
			for (int i = 0; i < files.Length; i++)
			{
				string file = files[i];
				string[] fs = file.Split('|');
				if (string.IsNullOrEmpty(fs[0]))
					continue;
				bundleTable[fs[0]] = fs[1];
			}
		}
	}

	public void LoadManifest()
	{
		if (PlatformUtil.IsRunInEditor())
		{
			return;
		}
		string path = GetAssetBundlePath(PlatformUtil.GetPlatformName(), false);
		AssetBundle ab = AssetBundle.LoadFromFile(path);
		assetBundleManifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

		ab.Unload(false);
		ab = null;
	}

	public void InitAppConfigJSON(OnCompleteDelegate onComplete)
	{
		GTextLoader loader = new GTextLoader();
		loader.Url = GFileManager.GetInstance().GetAppConfigJSONPath();
		loader.OnLoadComplete = delegate (GBaseLoader l)
		{
			string json = loader.Text;
			if (!string.IsNullOrEmpty(json))
			{
				appConfigData = JsonUtility.FromJson<AppConfigJSONData>(json);
			}
			else
			{
				appConfigData = new AppConfigJSONData();
			}
			if (onComplete != null)
			{
				onComplete();
			}
		};
		loader.OnLoadError = delegate (GBaseLoader l)
		{
			appConfigData = new AppConfigJSONData();
			if (onComplete != null)
			{
				onComplete();
			}
		};
		loader.Load();

	}

	public bool GetHotUpdateEnabled()
	{
		return appConfigData.hot_update_enabled;
	}

	private void LoadAndWarmUpShaderBundle()
	{
		if (!PlatformUtil.IsRunInEditor())
		{
			ShaderVariantCollection svc = LoadShaderVariantCollection("Shader/CustomShaderVariants.shadervariants");
			if (svc != null && !svc.isWarmedUp)
			{
				svc.WarmUp();
			}
		}
	}

	//加载一个bundle的依赖
	private void LoadDependencies(string assetBundleName)
	{
		if (!assetBundleManifest)
		{
			return;
		}
		string[] dependencies = GetDependencies(assetBundleName);
		if (dependencies == null)
		{
			return;
		}
		if (dependencies.Length == 0)
		{
			return;
		}
		for (int i = 0; i < dependencies.Length; i++)
		{
			//逐个加载依赖
			LoadAssetBundleInternal(dependencies[i]);
		}
	}

	private void LoadAssetBundleInternal(string assetBundleName, OnLoadItemCompleteDelegate onLoadItemComplete = null)
	{
		LoadedAssetBundle bundle = null;
		loadedAssetBundles.TryGetValue(assetBundleName, out bundle);
		//已经加载过了，增加一个引用
		if (bundle != null)
		{
			bundle.AddReference();
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete();
			}
			return;
		}
		//正在加载中
		LoadingAssetBundleRequest request = new LoadingAssetBundleRequest();
		request.assetBundleName = assetBundleName;
		request.onComplete = onLoadItemComplete;
		List<LoadingAssetBundleRequest> requests = null;
		if (loadingBundleRequests.TryGetValue(assetBundleName, out requests))
		{
			requests.Add(request);
			return;
		}
		//添加到加载列表中
		requests = new List<LoadingAssetBundleRequest>();
		requests.Add(request);
		loadingBundleRequests.Add(assetBundleName, requests);
		loadingAssetBundleNames.Add(assetBundleName);
		//开始加载
		GBaseLoader bundleLoader = GetAssetBundleLoader(assetBundleName);
		bundleLoader.Url = GetAssetBundlePath(assetBundleName);
		bundleLoader.Name = assetBundleName;
		bundleLoader.IsAsync = true;
		bundleLoader.OnLoadComplete += delegate (GBaseLoader l)
		{
			string curLoadedAssetBundleName = l.Name;
			loadedAssetBundles.TryGetValue(curLoadedAssetBundleName, out bundle);
			if (bundle == null)
			{
				//添加到已经加载的列表中
				loadedAssetBundles.Add(curLoadedAssetBundleName, new LoadedAssetBundle(l.AssetBundle, 0));
				GFileManager.GetInstance().WriteBundleToStorageAndUpdateBundleInfo(curLoadedAssetBundleName, l as GAssetBundleLoader);
			}
		};
		bundleLoader.Load();
	}

	//IEnumerator CheckLoading()
	//{
	//	while (true)
	//	{

	//		yield return new WaitForSecondsRealtime(0.02f);
	//	}
	//}

	void Update()
	{
		if (!initialized)
			return;

		for (int i = loadingAssetBundleNames.Count - 1; i >= 0; i--)
		{
			string assetBundleName = loadingAssetBundleNames[i];
			LoadedAssetBundle bundle = GetLoadedAssetBundle(assetBundleName);
			if (bundle != null)
			{
				//loading 中的已经加载完成了
				//从加载中的列表中清空，并且判断回调
				List<LoadingAssetBundleRequest> loadingList = null;
				if (loadingBundleRequests.TryGetValue(assetBundleName, out loadingList))
				{
					loadingBundleRequests.Remove(assetBundleName);
					for (int index = 0; index < loadingList.Count; index++)
					{
						LoadingAssetBundleRequest request = loadingList[index];
						if (loadedAssetBundles.ContainsKey(assetBundleName))
						{
							AddLoadedAssetBundleReference(assetBundleName);
						}
						if (request.onComplete != null)
						{
							request.onComplete();
						}
					}
				}
				loadingAssetBundleNames[i] = string.Empty;
			}
		}
		//删除不用的
		for (int i = loadingAssetBundleNames.Count - 1; i >= 0; i--)
		{
			if (string.IsNullOrEmpty(loadingAssetBundleNames[i]))
			{
				loadingAssetBundleNames.RemoveAt(i);
			}
		}
	}

	public void OnTick()
	{

	}

	public void OnLateTick()
	{

	}

	//判断一个assetbundle是否正在加载中
	private bool IsAssetBundleLoading(string assetBundleName)
	{
		if (loadingAssetBundleNames == null)
			return false;
		if (string.IsNullOrEmpty(assetBundleName))
			return false;
		for (int i = 0; i < loadingAssetBundleNames.Count; i++)
		{
			string loadingName = loadingAssetBundleNames[i];
			if (string.IsNullOrEmpty(loadingName))
			{
				continue;
			}
			if (loadingName.Equals(assetBundleName))
			{
				return true;
			}
		}
		return false;
	}

	private LoadedAssetBundle GetLoadedAssetBundle(string assetBundleName)
	{
		//先检查自身是否加载完成，因为如果自身都还没完成，那说明肯定没加载完成呢，可以减少对于下面依赖判断的次数
		LoadedAssetBundle loadedBundle = null;
		loadedAssetBundles.TryGetValue(assetBundleName, out loadedBundle);
		if (loadedBundle == null)
		{
			return null;
		}
		//检查依赖 如果有依赖，那么依次检查是否加载完
		string[] dependencies = GetDependencies(assetBundleName);
		if (dependencies != null && dependencies.Length > 0)
		{
			for (int depIndex = 0; depIndex < dependencies.Length; depIndex++)
			{
				LoadedAssetBundle dependentBundle = null;
				loadedAssetBundles.TryGetValue(dependencies[depIndex], out dependentBundle);
				if (dependentBundle == null)
				{
					return null;
				}
			}
		}
		return loadedBundle;
	}

	public AssetBundle LoadAssetBundle(string name)
	{
		if (PlatformUtil.IsRunInEditor())
		{
			return null;
		}
		//先加载依赖的内容 同步加载
		string[] deps = GetDependencies(name);
		GBaseLoader depLoader;
		for (int i = 0; i < deps.Length; i++)
		{
			string dep = deps[i];
			LoadedAssetBundle depBundle = null;
			if (loadedAssetBundles.TryGetValue(dep, out depBundle))
			{
				depBundle.AddReference();
			}
			else
			{
				depLoader = GetAssetBundleLoader(dep);
				depLoader.Url = GetAssetBundlePath(dep);
				depLoader.Name = dep;
				depLoader.IsAsync = false;
				depLoader.AutoDispose = false;
				depLoader.Load();
				loadedAssetBundles.Add(depLoader.Name, new LoadedAssetBundle(depLoader.AssetBundle, 1));
				GFileManager.GetInstance().WriteBundleToStorageAndUpdateBundleInfo(dep, depLoader as GAssetBundleLoader);
				depLoader.Dispose();
			}
		}
		LoadedAssetBundle bundle = null;
		if (loadedAssetBundles.TryGetValue(name, out bundle))
		{
			bundle.AddReference();
			return bundle.assetBundle;
		}
		else
		{
			GBaseLoader loader = GetAssetBundleLoader(name);
			loader.Url = GetAssetBundlePath(name);
			loader.Name = name;
			loader.IsAsync = false;
			loader.AutoDispose = false;
			loader.Load();
			AssetBundle asset = loader.AssetBundle;
			loadedAssetBundles.Add(name, new LoadedAssetBundle(asset, 1));
			GFileManager.GetInstance().WriteBundleToStorageAndUpdateBundleInfo(name, loader as GAssetBundleLoader);
			loader.Dispose();
			return asset;
		}
	}

	public void LoadAssetBundleAsync(string name, OnLoadItemCompleteDelegate onLoadItemComplete = null)
	{
		LoadDependencies(name);
		LoadAssetBundleInternal(name, onLoadItemComplete);
	}

	public void UnloadAssetBundle(string assetPath)
	{
		if (PlatformUtil.IsRunInEditor())
		{
			return;
		}
		if (string.IsNullOrEmpty(assetPath))
		{
			return;
		}
		string abName = GetAssetBundleNameByAssetPath(assetPath);
		if (string.IsNullOrEmpty(abName))
		{
			return;
		}
		UnloadAssetBundleInternal(abName);
		UnloadDependencies(abName);
	}

	private void UnloadAssetBundleInternal(string assetBundleName)
	{
		LoadedAssetBundle bundle = GetLoadedAssetBundle(assetBundleName);
		if (bundle == null)
			return;

		if (bundle.DeleteReference() <= 0)
		{
			if (IsAssetBundleLoading(assetBundleName))
			{
				return;//如果当前AB处于Async Loading过程中，卸载会崩溃，只减去引用计数即可
			}
			bundle.Unload();
			loadedAssetBundles.Remove(assetBundleName);
			if (assetBundleName.StartsWith("ui_texture_") || assetBundleName.StartsWith("puzzle_texture"))
			{
				//如果这个卸载的bundle是ui_texture_开头的，那么移除AtlasManger里的
				AtlasManager.GetInstance().RemoveAtlas(assetBundleName);
			}
		}
	}

	private void UnloadDependencies(string assetBundleName)
	{
		string[] dependencies = GetDependencies(assetBundleName);
		if (dependencies == null)
		{
			return;
		}
		for (int i = 0; i < dependencies.Length; i++)
		{
			UnloadAssetBundleInternal(dependencies[i]);
		}
	}

	public void LoadAssetAsync(string assetPath, OnLoadAssetCompleteDelegate onLoadItemComplete = null, bool autoLoadDependencies = true)
	{
		if (PlatformUtil.IsRunInEditor())
		{
#if UNITY_EDITOR
			UnityEngine.Object target = AssetDatabase.LoadMainAssetAtPath(string.Concat(ASSET_PATH_PREFIX, assetPath));
			if (target != null)
			{
				EnterFrameTimer.SetTimeOut(1, delegate ()
				{
					if (onLoadItemComplete != null)
					{
						onLoadItemComplete(target);
					}
				});
				return;
			}
			Debug.LogWarning("资源无法通过编辑器模式加载:" + string.Concat(ASSET_PATH_PREFIX, assetPath));
			return;
#endif
		}
		else
		{
			string abName = GetAssetBundleNameByAssetPath(assetPath);
			if (string.IsNullOrEmpty(abName))
			{
				return;
			}
			string assetName = Path.GetFileNameWithoutExtension(assetPath);
			LoadAssetBundleAsync(abName, delegate ()
			{
				LoadedAssetBundle loadedBundle = null;
				if (loadedAssetBundles.TryGetValue(abName, out loadedBundle))
				{
					GAssetLoader loader = new GAssetLoader();
					loader.assetBundle = loadedBundle.assetBundle;
					loader.assetName = assetName;
					loader.OnLoadComplete += delegate (GBaseLoader l)
					{
						if (onLoadItemComplete != null)
						{
							onLoadItemComplete(l.Content as UnityEngine.Object);
						}
					};

					loader.Load();
				}
			});
		}
	}


	public Object LoadAsset(string assetPath, bool autoLoadDependencies = true)
	{
		if (PlatformUtil.IsRunInEditor())
		{
#if UNITY_EDITOR
			UnityEngine.Object target = AssetDatabase.LoadMainAssetAtPath(string.Concat(ASSET_PATH_PREFIX, assetPath));
			if (target != null)
			{
				return target;
			}
			Debug.LogWarning("资源无法通过编辑器模式加载:" + string.Concat(ASSET_PATH_PREFIX, assetPath));
			return null;
#else
			return null;
#endif
		}
		else
		{
			string abName = GetAssetBundleNameByAssetPath(assetPath);
			if (string.IsNullOrEmpty(abName))
			{
				return null;
			}
			string assetName = Path.GetFileNameWithoutExtension(assetPath);
			AssetBundle ab = LoadAssetBundle(abName);
			if (ab == null)
			{
				return null;
			}
			GAssetLoader loader = new GAssetLoader();
			loader.isAsync = false;
			loader.assetBundle = ab;
			loader.assetName = assetName;
			UnityEngine.Object con = loader.GetAsset<UnityEngine.Object>();
			loader.Dispose();
			return con;
		}
	}

	public void LoadAllAssetAsync(string assetPath, OnLoadAllAssetCompleteDelegate onLoadItemComplete = null, bool autoLoadDependencies = true)
	{
		if (PlatformUtil.IsRunInEditor())
		{
#if UNITY_EDITOR
			UnityEngine.Object[] targets = AssetDatabase.LoadAllAssetsAtPath(string.Concat(ASSET_PATH_PREFIX, assetPath));
			if (targets != null)
			{
				EnterFrameTimer.SetTimeOut(1, delegate ()
				{
					if (onLoadItemComplete != null)
					{
						onLoadItemComplete(targets);
					}
				});
				return;
			}
			Debug.LogWarning("资源无法通过编辑器模式加载:" + string.Concat(ASSET_PATH_PREFIX, assetPath));
			return;
#endif
		}
		else
		{
			string abName;
			if (assetPath.StartsWith("ui_texture_") || assetPath.StartsWith("puzzle_texture"))
			{
				//如果是直接取UGUI自动图集中的一个图片，那么anName就还是assetPath也就是ui_texture_xxx
				abName = assetPath;
			}
			else
			{
				abName = GetAssetBundleNameByAssetPath(assetPath);
			}
			if (string.IsNullOrEmpty(abName))
			{
				return;
			}
			string assetName = Path.GetFileNameWithoutExtension(assetPath);
			LoadAssetBundleAsync(abName, delegate ()
			{
				LoadedAssetBundle loadedBundle = null;
				if (loadedAssetBundles.TryGetValue(abName, out loadedBundle))
				{
					GAllAssetLoader loader = new GAllAssetLoader();
					loader.assetBundle = loadedBundle.assetBundle;
					loader.OnLoadComplete += delegate (GBaseLoader l)
					{
						if (onLoadItemComplete != null)
						{
							onLoadItemComplete(loader.GetAllAssets<UnityEngine.Object>());
						}
					};

					loader.Load();
				}
			});
		}
	}


	public Object[] LoadAllAsset(string assetPath, bool autoLoadDependencies = true)
	{
		if (PlatformUtil.IsRunInEditor())
		{
#if UNITY_EDITOR
			UnityEngine.Object[] targets = AssetDatabase.LoadAllAssetsAtPath(string.Concat(ASSET_PATH_PREFIX, assetPath));
			if (targets != null)
			{
				return targets;
			}
			Debug.LogWarning("资源无法通过编辑器模式加载:" + string.Concat(ASSET_PATH_PREFIX, assetPath));
			return null;
#else
			return null;
#endif
		}
		else
		{
			string abName;
			if (assetPath.StartsWith("ui_texture_") || assetPath.StartsWith("puzzle_texture"))
			{
				//如果是直接取UGUI自动图集中的一个图片，那么anName就还是assetPath也就是ui_texture_xxx
				abName = assetPath;
			}
			else
			{
				abName = GetAssetBundleNameByAssetPath(assetPath);
			}
			if (string.IsNullOrEmpty(abName))
			{
				return null;
			}
			string assetName = Path.GetFileNameWithoutExtension(assetPath);
			AssetBundle ab = LoadAssetBundle(abName);
			if (ab == null)
			{
				return null;
			}
			GAllAssetLoader loader = new GAllAssetLoader();
			loader.isAsync = false;
			loader.assetBundle = ab;
			UnityEngine.Object[] objArray = loader.GetAllAssets<UnityEngine.Object>();
			loader.Dispose();
			return objArray;
		}
	}

	public ShaderVariantCollection LoadShaderVariantCollection(string assetPath)
	{
		Object obj = LoadAsset(assetPath);
		return obj as ShaderVariantCollection;
	}

	public void LoadPrefabAsync(string assetPath, OnLoadPrefabCompleteDelegate onLoadItemComplete = null, bool autoLoadDependencies = true)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete(obj as GameObject);
			}
		});
	}

	public GameObject LoadPrefab(string assetPath)
	{
		Object obj = LoadAsset(assetPath);
		return obj as GameObject;
	}

	public Sprite LoadSprite(string assetPath)
	{
		Object obj = LoadAsset(assetPath);
		if (obj)
		{
			Sprite sp = obj as Sprite;
			if (sp == null)
			{
				Texture2D tex = obj as Texture2D;
				if (tex)
				{
					sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
				}
			}
			return sp;
		}

		return null;
	}

	public Sprite LoadSpriteWithBorder(string assetPath, Vector4 border)
	{
		Object obj = LoadAsset(assetPath);
		if (obj)
		{
			Sprite sp = obj as Sprite;
			if (sp == null)
			{
				Texture2D tex = obj as Texture2D;
				if (tex)
				{
					sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100, 1, SpriteMeshType.FullRect, border);
				}
			}
			return sp;
		}

		return null;
	}

	public void LoadSpriteAsync(string assetPath, OnLoadSpriteCompleteDelegate onLoadItemComplete = null)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				Sprite sp = obj as Sprite;
				if (sp == null)
				{
					Texture2D tex = obj as Texture2D;
					if (tex)
					{
						sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

					}
				}

				onLoadItemComplete(sp);
			}
		});
	}

	public void LoadSpriteAsyncWithBorder(string assetPath, Vector4 border, OnLoadSpriteCompleteDelegate onLoadItemComplete = null)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				Sprite sp = obj as Sprite;
				if (sp == null)
				{
					Texture2D tex = obj as Texture2D;
					if (tex)
					{
						sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100, 1, SpriteMeshType.FullRect, border);

					}
				}

				onLoadItemComplete(sp);
			}
		});
	}

	public Sprite LoadSpriteInAtlas(string assetPath, string atlasPath, string spriteName)
	{
		if (PlatformUtil.IsRunInEditor())
		{
			return LoadSprite(assetPath);
		}
		AtlasInfo atlasInfo = LoadAllSpriteInAtlas(atlasPath);
		spriteName = Path.GetFileNameWithoutExtension(spriteName); //spriteName不需要扩展名
		return atlasInfo.GetSprite(spriteName);
	}

	public void LoadSpriteInAtlasAsync(string assetPath, string atlasPath, string spriteName, OnLoadSpriteCompleteDelegate onLoadItemComplete = null)
	{
		if (PlatformUtil.IsRunInEditor())
		{
			LoadSpriteAsync(assetPath, onLoadItemComplete);
			return;
		}
		LoadAllSpriteInAtlasAsync(atlasPath, delegate (AtlasInfo atlasInfo)
		{
			spriteName = Path.GetFileNameWithoutExtension(spriteName);//spriteName不需要扩展名
			Sprite sp = atlasInfo.GetSprite(spriteName);
			if (sp != null)
			{
				if (onLoadItemComplete != null)
				{
					onLoadItemComplete(sp);
				}
			}
		});
	}

	public AtlasInfo LoadAllSpriteInAtlas(string assetPath)
	{
		AtlasInfo atlas = AtlasManager.GetInstance().GetAtlas(assetPath);
		if (atlas != null)
		{
			//增加引用
			AddLoadedAssetBundleReference(assetPath);
			return atlas;
		}
		Object[] objs = LoadAllAsset(assetPath);
		if (objs != null && objs.Length > 0)
		{
			atlas = AtlasManager.GetInstance().GetAtlas(assetPath);
			if (atlas == null)
			{
				List<Sprite> sps = new List<Sprite>();
				Texture2D tex;
				//缓存进AtlasManager
				atlas = new AtlasInfo();
				atlas.texturePath = assetPath;
				for (int i = 0; i < objs.Length; i++)
				{
					Object o = objs[i];
					Sprite sp = o as Sprite;
					if (sp != null)
					{
						sps.Add(sp);
					}
					else
					{
						tex = o as Texture2D;
						if (tex != null)
						{
							atlas.texture = tex;
						}
					}
				}
				atlas.AddSprites(sps.ToArray());
				AtlasManager.GetInstance().AddAtlas(assetPath, atlas);
			}
			return atlas;
		}
		return null;
	}

	public void LoadAllSpriteInAtlasAsync(string assetPath, OnLoadAllSpriteInAtlasCompleteDelegate onLoadItemComplete = null)
	{
		AtlasInfo atlas = AtlasManager.GetInstance().GetAtlas(assetPath);
		if (atlas != null)
		{
			//增加引用
			AddLoadedAssetBundleReference(assetPath);
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete(atlas);
			}
			return;
		}
		LoadAllAssetAsync(assetPath, delegate (Object[] objs)
		{
			if (onLoadItemComplete != null)
			{
				if (objs != null && objs.Length > 0)
				{
					atlas = AtlasManager.GetInstance().GetAtlas(assetPath);
					if (atlas == null)
					{
						List<Sprite> sps = new List<Sprite>();
						Texture2D tex;
						//缓存进AtlasManager
						atlas = new AtlasInfo();
						atlas.texturePath = assetPath;
						for (int i = 0; i < objs.Length; i++)
						{
							Object o = objs[i];
							Sprite sp = o as Sprite;
							if (sp != null)
							{
								sps.Add(sp);
							}
							else
							{
								tex = o as Texture2D;
								if (tex != null)
								{
									atlas.texture = tex;
								}
							}
						}
						atlas.AddSprites(sps.ToArray());
						AtlasManager.GetInstance().AddAtlas(assetPath, atlas);
					}
					onLoadItemComplete(atlas);
				}
			}
		});
	}

	public void LoadTexture2DAsync(string assetPath, OnLoadTexture2DCompleteDelegate onLoadItemComplete = null)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete(obj as Texture2D);
			}
		});
	}

	public Texture2D LoadTexture2D(string assetPath)
	{
		Object obj = LoadAsset(assetPath);
		if (obj)
		{
			return obj as Texture2D;
		}

		return null;
	}

	public void LoadAnimationClipAsync(string assetPath, OnLoadAnimationClipCompleteDelegate onLoadItemComplete = null)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete(obj as AnimationClip);
			}
		});
	}

	public AnimationClip LoadAnimationClip(string assetPath)
	{
		Object obj = LoadAsset(assetPath);
		return obj as AnimationClip;
	}

	public ScriptableObject LoadScriptableObject(string assetPath)
	{
		Object obj = LoadAsset(assetPath);
		if (obj)
		{
			return obj as ScriptableObject;
		}

		return null;
	}

	public void LoadScriptableObjectAsync(string assetPath, OnLoadScriptableObjectCompleteDelegate onLoadItemComplete = null)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete(obj as ScriptableObject);
			}
		});
	}

	public void LoadMeshAsync(string assetPath, OnLoadMeshCompleteDelegate onLoadItemComplete = null)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete(obj as Mesh);
			}
		});
	}

	public void LoadMaterialAsync(string assetPath, OnLoadMaterialCompleteDelegate onLoadItemComplete = null)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete(obj as Material);
			}
		});
	}

	public Material LoadMaterial(string assetPath)
	{
		Object obj = LoadAsset(assetPath);
		return obj as Material;
	}

	public void LoadAudioClipAsync(string assetPath, OnLoadAudioClipCompleteDelegate onLoadItemComplete = null)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete(obj as AudioClip);
			}
		});
	}

	public void LoadFontAsync(string assetPath, OnLoadFontCompleteDelegate onLoadItemComplete = null)
	{
		LoadAssetAsync(assetPath, delegate (Object obj)
		{
			if (onLoadItemComplete != null)
			{
				onLoadItemComplete(obj as Font);
			}
		});
	}

	private string[] GetDependencies(string assetBundleName)
	{
		if (assetBundleManifest == null)
		{
			return null;
		}

		assetBundleName += VARIANT;

		string[] dependencies = null;
		//判断从依赖缓存中取出依赖列表
		if (!dependenciesCache.TryGetValue(assetBundleName, out dependencies))
		{
			dependencies = assetBundleManifest.GetAllDependencies(assetBundleName);
			for (int i = 0; i < dependencies.Length; i++)
			{
				dependencies[i] = dependencies[i].Replace(VARIANT, "");
			}
			dependenciesCache.Add(assetBundleName, dependencies);
		}
		return dependencies;
	}

	public string GetAssetBundleStreamingAssetsPath()
	{
		return Application.streamingAssetsPath + "/" + ASSETBUNDLE_FOLDER + "/" + PlatformUtil.GetPlatformName();
	}

	public string GetAssetBundleStoragePath()
	{
		if (PlatformUtil.IsWindowsPlayer())
		{
			return Util.DataPath;
		}
		return Util.DataPath;
	}

	public string GetAssetBundlesCDNPath()
	{
		return appConfigData.hot_update_cdn_prefix;
	}

	public GBaseLoader GetAssetBundleLoader(string assetBundleName)
	{
		assetBundleName += VARIANT;
		GFileBundleInfo bundleInfo = GFileManager.GetInstance().GetBundleInfo(assetBundleName);
		if (bundleInfo != null)
		{
			if (bundleInfo.location == BundleStorageLocation.CDN)
			{
				return new GAssetBundleLoader();
			}
			return new GAssetBundleFromFileLoader();
		}
		return new GAssetBundleFromFileLoader();
	}

	public string GetAssetBundlePath(string assetBundleName, bool autoCompletionExts = true)
	{
		string s = "";

		if (autoCompletionExts)
			assetBundleName += VARIANT;

		GFileBundleInfo bundleInfo = GFileManager.GetInstance().GetBundleInfo(assetBundleName);
		if (bundleInfo != null)
		{
			if (bundleInfo.location == BundleStorageLocation.STREAMINGASSETS)
			{
				s = GetAssetBundleStreamingAssetsPath();
			}
			else if (bundleInfo.location == BundleStorageLocation.STORAGE)
			{
				s = GetAssetBundleStoragePath();
			}
			else if (bundleInfo.location == BundleStorageLocation.CDN)
			{
				s = GetAssetBundlesCDNPath();
			}
		}
		else
		{
			s = GetAssetBundleStreamingAssetsPath();
		}
		s = Path.Combine(s, assetBundleName);
		return s;
	}

	public string GetAssetBundleNameByAssetPath(string path)
	{
		string abName;
		if (!bundleTable.TryGetValue(path, out abName))
		{
			Debug.LogWarning(string.Format("通过{0}查找的AssetBundle不存在", path));
		}
		return abName;
	}

	public void AddLoadedAssetBundleReference(string assetBundleName)
	{
		//增加引用
		LoadedAssetBundle bundle = null;
		loadedAssetBundles.TryGetValue(assetBundleName, out bundle);
		//已经加载过了，增加一个引用
		if (bundle != null)
		{
			bundle.AddReference();
		}
	}
}

public class LoadedAssetBundle
{
	public AssetBundle assetBundle;
	public int referencedCount;

	public LoadedAssetBundle(AssetBundle assetBundle, int referencedCount)
	{
		this.assetBundle = assetBundle;
		this.referencedCount = referencedCount;
	}

	public int AddReference()
	{
		return ++referencedCount;
	}

	public int DeleteReference()
	{
		return --referencedCount;
	}

	public void Unload()
	{
		referencedCount = 0;
		if (assetBundle == null)
		{
			return;
		}
		assetBundle.Unload(false);
		assetBundle = null;
	}
}
