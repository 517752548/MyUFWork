using UnityEngine;

namespace DCET
{
	[ObjectSystem]
	public class ABInfoAwakeSystem : AwakeSystem<ABInfo, string, AssetBundle>
	{
		public override void Awake(ABInfo self, string abName, AssetBundle a)
		{
			self.AssetBundle = a;
			self.Name = abName;
			self.RefCount = 1;
		}
	}

	public class ABInfo : Entity
	{
		public string Name { get; set; }

		public int RefCount { get; set; }

		public AssetBundle AssetBundle;

		public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			base.Dispose();

			//Log.Debug($"desdroy assetbundle: {this.Name}");

			if (AssetBundle != null)
			{
				AssetBundle.Unload(true);
			}

			RefCount = 0;
			Name = "";
		}
	}
}
