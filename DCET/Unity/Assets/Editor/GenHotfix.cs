using DCETRuntime;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DCETEditor
{
	[InitializeOnLoad]
	public class GenHotfix
	{
		private const string DllName = "Unity.DCET.Hotfix";
		private const string OutDirName = "Hotfix";
		private static string DllDir = Application.dataPath + "/Hotfix";
		private static List<string> ReferencedLuaAssemblies = new List<string>()
		{
			GenCoreHotfix.DllName,
			GenConfigHotfix.DllName,
			GenMessageHotfix.DllName,
			GenFairyGUIHotfix.DllName,
			GenBehaviorTreeHotfix.DllName
		};

		static GenHotfix()
		{
			if (GenCoreHotfix.CopyDll(DllName) && Define.IsLua)
			{
				GenCoreHotfix.CompileLua(DllName, DllDir, OutDirName, ReferencedLuaAssemblies, false);
			}
		}
	}
}
