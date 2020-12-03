using DCETRuntime;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace DCETEditor
{
	[InitializeOnLoad]
    public static class GenCoreHotfix
	{
		public const string LuaDir = "./Lua/";
		public const string LuaTxtExtensionName = ".lua.txt";
		public const string LuaExtensionName = ".lua";

		private const string ScriptAssembliesDir = "Library/ScriptAssemblies";
        private const string CodeDir = "Assets/Res/Code/";

		public const string DllName = "Unity.DCET.Core.Hotfix";
		private const string DllDir = "./Packages/DCET.Core/Hotfix";
		private const string OutDirName = "Core";

		static GenCoreHotfix()
		{
			if (CopyDll(DllName) && Define.IsLua)
			{
				CompileLua(DllName, DllDir, OutDirName, null, true);
			}
		}
		
		public static bool CopyDll(string dllName)
		{
			var result = FileHelper.CopyFile(Path.Combine(ScriptAssembliesDir, $"{dllName}.dll"), Path.Combine(CodeDir, $"{dllName}.dll.bytes"), true);
			
			result = result || FileHelper.CopyFile(Path.Combine(ScriptAssembliesDir, $"{dllName}.pdb"), Path.Combine(CodeDir, $"{dllName}.pdb.bytes"), true);

			if (result)
			{
				Log.Info($"复制{dllName}.dll, {dllName}.pdb到Res/Code完成");
				AssetDatabase.Refresh();
			}

			return result;
		}

		public static void CompileLua(string dllName, string dllDir, string outDirName, List<string> referencedLuaAssemblies, bool isModule)
		{
			LuaCompiler.Compile(dllName, dllDir, outDirName, referencedLuaAssemblies, isModule);
			FileHelper.ReplaceExtensionName(LuaCompiler.outDir + outDirName, LuaExtensionName, LuaTxtExtensionName);
			ABNameEditor.SetFolderLuaABName(LuaCompiler.outDir + outDirName);
			AssetDatabase.Refresh();
		}

		[MenuItem("Lua/Append the all lua file of the selected folder with \".txt\"")]
		public static void AppendSelectedFolder()
		{
			var assetGUIDs = Selection.assetGUIDs;

			foreach (var guid in assetGUIDs)
			{
				var assetPath = AssetDatabase.GUIDToAssetPath(guid);

				if (Directory.Exists(assetPath))
				{
					var outDirName = assetPath.Substring(assetPath.LastIndexOf("/") + 1);

					FileHelper.ReplaceExtensionName(LuaCompiler.outDir + outDirName, LuaExtensionName, LuaTxtExtensionName);
				}
			}

			AssetDatabase.Refresh();
		}

		[MenuItem("Lua/Replace the all \".lua.txt\" file of the selected folder with \".lua\"")]
		public static void ReplaceSelectedFolder()
		{
			var assetGUIDs = Selection.assetGUIDs;

			foreach (var guid in assetGUIDs)
			{
				var assetPath = AssetDatabase.GUIDToAssetPath(guid);

				if (Directory.Exists(assetPath))
				{
					var outDirName = assetPath.Substring(assetPath.LastIndexOf("/") + 1);

					FileHelper.ReplaceExtensionName(LuaCompiler.outDir + outDirName, LuaTxtExtensionName, LuaExtensionName);
				}
			}

			AssetDatabase.Refresh();
		}
	}
}