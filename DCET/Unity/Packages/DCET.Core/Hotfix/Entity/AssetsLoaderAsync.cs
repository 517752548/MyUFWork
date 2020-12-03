using System.Threading.Tasks;
using UnityEngine;

namespace DCET
{
	[ObjectSystem]
	public class AssetsLoaderAsyncAwakeSystem : AwakeSystem<AssetsLoaderAsync, AssetBundle>
	{
		public override void Awake(AssetsLoaderAsync self, AssetBundle a)
		{
			self.Awake(a);
		}
	}

	[ObjectSystem]
	public class AssetsLoaderAsyncUpdateSystem : UpdateSystem<AssetsLoaderAsync>
	{
		public override void Update(AssetsLoaderAsync self)
		{
			self.Update();
		}
	}

	public class AssetsLoaderAsync : Entity
	{
		private AssetBundle assetBundle;

		private AssetBundleRequest request;

		private TaskCompletionSource<bool> tcs;

		public void Awake(AssetBundle ab)
		{
			assetBundle = ab;
		}

		public void Update()
		{
			if (!request.isDone)
			{
				return;
			}

			var t = tcs;
			t.SetResult(true);
		}

		public override void Dispose()
		{
			if (IsDisposed)
		{
				return;
			}
			base.Dispose();

			assetBundle = null;
			request = null;
		}

		public async Task<UnityEngine.Object[]> LoadAllAssetsAsync()
		{
			await InnerLoadAllAssetsAsync();
			return request.allAssets;
		}

		private Task InnerLoadAllAssetsAsync()
		{
			tcs = new TaskCompletionSource<bool>();
			request = assetBundle.LoadAllAssetsAsync();
			return tcs.Task;
		}
	}
}
