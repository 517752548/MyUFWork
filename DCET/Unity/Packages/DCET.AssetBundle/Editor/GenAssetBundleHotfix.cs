using DCETRuntime;
using System.Collections.Generic;
using UnityEditor;

namespace DCETEditor
{
	[InitializeOnLoad]
	public class GenAssetBundleHotfix
	{
		public const string DllName = "Unity.DCET.AssetBundle.Hotfix";
		private const string DllDir = "./Packages/DCET.AssetBundle/Hotfix";
		private const string OutDirName = "AssetBundle";
		private static List<string> ReferencedLuaAssemblies = new List<string>() { GenCoreHotfix.DllName };

		static GenAssetBundleHotfix()
		{
			if (GenCoreHotfix.CopyDll(DllName) && Define.IsLua)
			{
				GenCoreHotfix.CompileLua(DllName, DllDir, OutDirName, ReferencedLuaAssemblies, true);
			}
		}
	}
}
