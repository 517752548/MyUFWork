using DCETRuntime;
using System.Collections.Generic;
using UnityEditor;

namespace DCETEditor
{
	[InitializeOnLoad]
	public class GenConfigHotfix
	{
		public const string DllName = "Unity.DCET.Config.Hotfix";
		private const string DllDir = "./Packages/DCET.Config/Hotfix";
		private const string OutDirName = "Config";
		private static List<string> ReferencedLuaAssemblies = new List<string>() { GenCoreHotfix.DllName };

		static GenConfigHotfix()
		{
			if (GenCoreHotfix.CopyDll(DllName) && Define.IsLua)
			{
				GenCoreHotfix.CompileLua(DllName, DllDir, OutDirName, ReferencedLuaAssemblies, true);
			}
		}
	}
}
