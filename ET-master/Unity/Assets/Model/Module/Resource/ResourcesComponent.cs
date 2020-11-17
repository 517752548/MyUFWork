using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ET
{
	public class ResourcesComponentAwakeSystem: AwakeSystem<ResourcesComponent>
	{
		public override void Awake(ResourcesComponent self)
		{
			ResourcesComponent.Instance = self;
		}
	}
	

	public class ResourcesComponent : Entity
	{
		public static ResourcesComponent Instance;

		private Dictionary<string,TextAsset> allConfigs = new Dictionary<string, TextAsset>();
		public async ETTask LoadAllConfig()
		{
			HashSet<Type> types = Game.EventSystem.GetTypes(typeof(ConfigAttribute));

			foreach (Type type in types)
			{
				var config = await LoadBundleAsync<TextAsset>($"{type.Name.Replace("Category","")}.txt");
				allConfigs.Add(type.Name.Replace("Category",""),config);
			}
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();
		}

		public UnityEngine.Object GetAsset(string bundleName)
		{
			return allConfigs[bundleName];
		}

		public void UnloadBundle(string assetBundleName)
		{
			Addressables.Release(assetBundleName);
		}



		/// <summary>
		/// 异步加载assetbundle
		/// </summary>
		/// <param name="assetBundleName"></param>
		/// <returns></returns>
		public ETTask<T> LoadBundleAsync<T>(string assetBundleName)
		{
			var custom = new ETTaskCompletionSource<T>();
			Addressables.LoadAssetAsync<T>(assetBundleName).Completed += op =>
			{
				custom.SetResult(op.Result);
			};
			 return custom.Task;
		}


	}
}