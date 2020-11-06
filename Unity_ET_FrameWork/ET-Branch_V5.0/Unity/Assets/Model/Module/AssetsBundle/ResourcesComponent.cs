using System.Collections.Generic;
using NPOI.SS.Formula.Functions;
using UnityEngine.AddressableAssets;

namespace ETModel
{
	
	public class ResourcesComponent : Component
	{
		private Dictionary<string,UnityEngine.Object> preloadBundle = new Dictionary<string, UnityEngine.Object>();
		public override void Dispose()
		{

		}

		
		public async ETTask PreloadBundle(string assetBundleName)
		{
			UnityEngine.Object bundle = await LoadBundleAsync<UnityEngine.Object>(assetBundleName);
			this.preloadBundle.Add(assetBundleName,bundle);
		}

		public T GetPreloadObject<T>(string assetname) where T:UnityEngine.Object
		{
			Log.Info(assetname);
			return preloadBundle[assetname] as T;
		}

		public void UnloadBundle(string assetBundleName)
		{
			//Addressables.Release(assetBundleName);
		}
		
		/// <summary>
		/// 异步加载assetbundle
		/// </summary>
		/// <param name="assetBundleName"></param>
		/// <returns></returns>
		public async ETTask<T> LoadBundleAsync<T>(string assetBundleName)
		{
			return await Addressables.LoadAssetAsync<T>(assetBundleName).Task;
		}

	}
}