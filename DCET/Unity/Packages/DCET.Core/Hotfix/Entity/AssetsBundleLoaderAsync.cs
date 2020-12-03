using System.Threading.Tasks;
using UnityEngine;

namespace DCET
{
	[ObjectSystem]
	public class AssetsBundleLoaderAsyncSystem : UpdateSystem<AssetsBundleLoaderAsync>
	{
		public override void Update(AssetsBundleLoaderAsync self)
		{
			self.Update();
		}
	}

	public class AssetsBundleLoaderAsync : Entity
	{
		private AssetBundleCreateRequest request;

		private TaskCompletionSource<AssetBundle> tcs;

		public void Update()
		{
			if (!request.isDone)
			{
				return;
			}

			TaskCompletionSource<AssetBundle> t = tcs;
			t.SetResult(request.assetBundle);
		}

		public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}
			base.Dispose();
		}

		public Task<AssetBundle> LoadAsync(string path)
		{
			tcs = new TaskCompletionSource<AssetBundle>();
			request = AssetBundle.LoadFromFileAsync(path);
			return tcs.Task;
		}
	}
}
