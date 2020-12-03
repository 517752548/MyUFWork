using DCETRuntime;
using System.Collections.Generic;
using UnityEditor;

namespace DCETEditor
{
	[InitializeOnLoad]
	public class GenBehaviorTreeHotfix
	{
		public const string DllName = "Unity.DCET.BehaviorTree.Hotfix";
		private const string DllDir = "./Packages/DCET.BehaviorTree/Hotfix";
		private const string OutDirName = "BehaviorTree";
		private static List<string> ReferencedLuaAssemblies = new List<string>() { GenCoreHotfix.DllName };

		static GenBehaviorTreeHotfix()
		{
			if (GenCoreHotfix.CopyDll(DllName) && Define.IsLua)
			{
				GenCoreHotfix.CompileLua(DllName, DllDir, OutDirName, ReferencedLuaAssemblies, true);
			}
		}
	}
}
