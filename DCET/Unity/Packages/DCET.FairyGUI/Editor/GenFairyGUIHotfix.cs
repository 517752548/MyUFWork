using DCETRuntime;
using System.Collections.Generic;
using UnityEditor;

namespace DCETEditor
{
	[InitializeOnLoad]
	public class GenFairyGUIHotfix
	{
		public const string DllName = "Unity.DCET.FairyGUI.Hotfix";
		private const string DllDir = "./Packages/DCET.FairyGUI/Hotfix";
		private const string OutDirName = "FairyGUI";
		private static List<string> ReferencedLuaAssemblies = new List<string>() { GenCoreHotfix.DllName };

		static GenFairyGUIHotfix()
		{
			if (GenCoreHotfix.CopyDll(DllName) && Define.IsLua)
			{
				GenCoreHotfix.CompileLua(DllName, DllDir, OutDirName, ReferencedLuaAssemblies, true);
			}
		}
	}
}
