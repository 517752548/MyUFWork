using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ETModel
{
	public class AddressableLoaderAsync : Component
	{

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			base.Dispose();
		}

		public ETTask<T> LoadAsync<T>(string assetName)
		{
			ETTaskCompletionSource<T> tcs = new ETTaskCompletionSource<T>();
			AsyncOperationHandle<T> asset = Addressables.LoadAssetAsync<T>(assetName);
			asset.Completed += op =>
			{
				tcs.SetResult(asset.Result);
			};
			return tcs.Task;
		}

		public ETTask Init()
		{
			ETTaskCompletionSource tcs = new ETTaskCompletionSource();
			AsyncOperationHandle initasync = Addressables.InitializeAsync();
			initasync.Completed += op =>
			{
				tcs.SetResult();
			};
			return tcs.Task;
		}
		
		public ETTask<long> GetDownLoadSize()
		{
			ETTaskCompletionSource<long> tcs = new ETTaskCompletionSource<long>();
			AsyncOperationHandle<long> update = Addressables.GetDownloadSizeAsync("A");
			update.Completed += download =>
			{
				tcs.SetResult(download.Result);
			};
			return tcs.Task;
		}
		
		public AsyncOperationHandle DownLoadRes()
		{
			AsyncOperationHandle initasync = Addressables.DownloadDependenciesAsync("A");
			return initasync;
		}
	}
}
