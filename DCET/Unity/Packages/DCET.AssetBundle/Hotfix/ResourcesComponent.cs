using DCETRuntime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DCET
{
	[ObjectSystem]
	public class ResourcesComponentAwakeSystem : AwakeSystem<ResourcesComponent>
	{
		public override void Awake(ResourcesComponent self)
		{
			self.Awake();
		}
	}

	public class ResourcesComponent : Entity
	{
		public static AssetBundleManifest AssetBundleManifestObject { get; set; }

		private readonly Dictionary<string, Dictionary<string, UnityEngine.Object>> resourceCache = new Dictionary<string, Dictionary<string, UnityEngine.Object>>();

		private readonly Dictionary<string, ABInfo> bundles = new Dictionary<string, ABInfo>();

		public void Awake()
		{
			if (Define.IsAsync)
			{
				LoadOneBundle("StreamingAssets");
				AssetBundleManifestObject = (AssetBundleManifest)GetAsset("StreamingAssets", "AssetBundleManifest");
			}
		}

		public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			base.Dispose();

			foreach (var abInfo in bundles)
			{
				abInfo.Value.Dispose();
			}

			bundles.Clear();
			resourceCache.Clear();
		}

		public UnityEngine.Object GetAsset(string bundleName, string prefab)
		{
			Dictionary<string, UnityEngine.Object> dict;
			if (!resourceCache.TryGetValue(AssetBundleHelper.BundleNameToLower(bundleName), out dict))
			{
				throw new Exception($"not found asset: {bundleName} {prefab}");
			}

			UnityEngine.Object resource;

			if (!dict.TryGetValue(prefab, out resource))
			{
				throw new Exception($"not found asset: {bundleName} {prefab}");
			}

			return resource;
		}

		public AssetBundle GetAssetBundle(string abName)
		{
			ABInfo abInfo;
			if (!bundles.TryGetValue(AssetBundleHelper.BundleNameToLower(abName), out abInfo))
			{
				throw new Exception($"not found bundle: {abName}");
			}
			return abInfo.AssetBundle;
		}

		public void UnloadBundle(string assetBundleName)
		{
			assetBundleName = AssetBundleHelper.BundleNameToLower(assetBundleName);

			string[] dependencies = DependenciesHelper.GetSortedDependencies(assetBundleName);

			//Log.Debug($"-----------dep unload {assetBundleName} dep: {dependencies.ToList().ListToString()}");
			foreach (string dependency in dependencies)
			{
				UnloadOneBundle(dependency);
			}
		}

		private void UnloadOneBundle(string assetBundleName)
		{
			assetBundleName = AssetBundleHelper.BundleNameToLower(assetBundleName);

			ABInfo abInfo;
			if (!bundles.TryGetValue(assetBundleName, out abInfo))
			{
				throw new Exception($"not found assetBundle: {assetBundleName}");
			}

			//Log.Debug($"---------- unload one bundle {assetBundleName} refcount: {abInfo.RefCount - 1}");

			--abInfo.RefCount;

			if (abInfo.RefCount > 0)
			{
				return;
			}


			bundles.Remove(assetBundleName);
			resourceCache.Remove(assetBundleName);
			abInfo.Dispose();
			//Log.Debug($"cache count: {this.cacheDictionary.Count}");
		}

		/// <summary>
		/// 同步加载assetbundle
		/// </summary>
		/// <param name="assetBundleName"></param>
		/// <returns></returns>
		public void LoadBundle(string assetBundleName)
		{
			assetBundleName = assetBundleName.ToLower();
			string[] dependencies = DependenciesHelper.GetSortedDependencies(assetBundleName);
			//Log.Debug($"-----------dep load {assetBundleName} dep: {dependencies.ToList().ListToString()}");
			foreach (string dependency in dependencies)
			{
				if (string.IsNullOrEmpty(dependency))
				{
					continue;
				}
				LoadOneBundle(dependency);
			}
		}

		public void AddResource(string bundleName, string assetName, UnityEngine.Object resource)
		{
			Dictionary<string, UnityEngine.Object> dict;
			if (!resourceCache.TryGetValue(AssetBundleHelper.BundleNameToLower(bundleName), out dict))
			{
				dict = new Dictionary<string, UnityEngine.Object>();
				resourceCache[bundleName] = dict;
			}

			dict[assetName] = resource;
		}

		public void LoadOneBundle(string assetBundleName)
		{
			//Log.Debug($"---------------load one bundle {assetBundleName}");
			ABInfo abInfo;
			if (bundles.TryGetValue(assetBundleName, out abInfo))
			{
				++abInfo.RefCount;
				return;
			}

			if (Define.IsAsync)
			{
				string p = Path.Combine(PathHelper.AppHotfixResPath, assetBundleName);

				AssetBundle assetBundle;

				if (File.Exists(p))
				{
					assetBundle = AssetBundle.LoadFromFile(p);
				}
				else
				{
					p = Path.Combine(PathHelper.AppResPath, assetBundleName);
					assetBundle = AssetBundle.LoadFromFile(p);
				}

				if (assetBundle == null)
				{
					throw new Exception($"assets bundle not found: {assetBundleName}");
				}

				if (!assetBundle.isStreamedSceneAssetBundle)
				{
					// 异步load资源到内存cache住
					UnityEngine.Object[] assets = assetBundle.LoadAllAssets();

					foreach (UnityEngine.Object asset in assets)
					{
						AddResource(assetBundleName, asset.name, asset);
					}
				}

				abInfo = EntityFactory.CreateWithParent<ABInfo, string, AssetBundle>(this, assetBundleName, assetBundle);
				bundles[assetBundleName] = abInfo;
			}
			else
			{
				var assetPaths = AssetDatabaseHelper.GetAssetPathsFromAssetBundle(assetBundleName);

				if (assetPaths != null)
				{
					foreach (string s in assetPaths)
					{
						string assetName = Path.GetFileNameWithoutExtension(s);
						UnityEngine.Object resource = AssetDatabaseHelper.LoadAssetAtPath(s);
						AddResource(assetBundleName, assetName, resource);
					}
				}

				abInfo = EntityFactory.CreateWithParent<ABInfo, string, AssetBundle>(this, assetBundleName, null);
				bundles[assetBundleName] = abInfo;
			}
		}

		/// <summary>
		/// 异步加载assetbundle
		/// </summary>
		/// <param name="assetBundleName"></param>
		/// <returns></returns>
		public async Task LoadBundleAsync(string assetBundleName)
		{
			assetBundleName = assetBundleName.ToLower();
			string[] dependencies = DependenciesHelper.GetSortedDependencies(assetBundleName);
			// Log.Debug($"-----------dep load {assetBundleName} dep: {dependencies.ToList().ListToString()}");
			foreach (string dependency in dependencies)
			{
				if (string.IsNullOrEmpty(dependency))
				{
					continue;
				}
				await LoadOneBundleAsync(dependency);
			}
		}

		public async Task LoadOneBundleAsync(string assetBundleName)
		{
			ABInfo abInfo;

			if (bundles.TryGetValue(assetBundleName, out abInfo))
			{
				++abInfo.RefCount;
				return;
			}

			if (Define.IsAsync)
			{
				string p = Path.Combine(PathHelper.AppHotfixResPath, assetBundleName);

				AssetBundle assetBundle = null;
				
				if (!File.Exists(p))
				{
					p = Path.Combine(PathHelper.AppResPath, assetBundleName);
				}

				using (AssetsBundleLoaderAsync assetsBundleLoaderAsync = EntityFactory.Create<AssetsBundleLoaderAsync>(Domain))
				{
					assetBundle = await assetsBundleLoaderAsync.LoadAsync(p);
				}

				if (assetBundle == null)
				{
					throw new Exception($"assets bundle not found: {assetBundleName}");
				}

				if (!assetBundle.isStreamedSceneAssetBundle)
				{
					// 异步load资源到内存cache住
					UnityEngine.Object[] assets;

					using (AssetsLoaderAsync assetsLoaderAsync = EntityFactory.Create<AssetsLoaderAsync, AssetBundle>(Domain, assetBundle))
					{
						assets = await assetsLoaderAsync.LoadAllAssetsAsync();
					}

					foreach (UnityEngine.Object asset in assets)
					{
						AddResource(assetBundleName, asset.name, asset);
					}
				}

				abInfo = EntityFactory.CreateWithParent<ABInfo, string, AssetBundle>(this, assetBundleName, assetBundle);
				bundles[assetBundleName] = abInfo;
			}
			else
			{
				var assetPaths = AssetDatabaseHelper.GetAssetPathsFromAssetBundle(assetBundleName);

				if (assetPaths != null)
				{
					foreach (string s in assetPaths)
					{
						string assetName = Path.GetFileNameWithoutExtension(s);
						UnityEngine.Object resource = AssetDatabaseHelper.LoadAssetAtPath(s);
						AddResource(assetBundleName, assetName, resource);
					}
				}

				abInfo = EntityFactory.CreateWithParent<ABInfo, string, AssetBundle>(this, assetBundleName, null);
				bundles[assetBundleName] = abInfo;
			}
		}

		public string DebugString()
		{
			StringBuilder sb = new StringBuilder();

			foreach (ABInfo abInfo in bundles.Values)
			{
				sb.Append($"{abInfo.Name}:{abInfo.RefCount}\n");
			}

			return sb.ToString();
		}
	}
}