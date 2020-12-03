using DCETRuntime;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace DCETEditor
{
	[InitializeOnLoad]
    public static class GenCoreHotfix
	{
		public const string LuaDir = "./Lua/";
		public const string LuaTxtExtensionName = ".lua.txt";
		public const string LuaExtensionName = ".lua";

		private const string ScriptAssembliesDir = "Library/ScriptAssemblies";
        private const string CodeDir = "Assets/Bundles/Code/";

        public static string[,] dllInfo = new[,]
        {
	        { "Unity.Hotfix", "./Assets/Hotfix", "HotFix" }, 
	        { "Unity.HotfixView", "./Assets/HotfixView", "HotFixView" },
	        { "Unity.Model", "./Assets/Model", "Model" },
	        { "Unity.ModelView", "./Assets/ModelView", "ModelView" },
        };
		// public const string DllName = "Unity.Hotfix";
		// private const string DllDir = "./Assets/Hotfix";
		// private const string OutDirName = "HotFix";

		static GenCoreHotfix()
		{
			for (int i = 0; i < dllInfo.GetLength(0); i++)
			{
				if (CopyDll(dllInfo[i,0]) && Define.IsLua)
				{
					CompileLua(dllInfo[i,0], dllInfo[i,1], dllInfo[i,2], null, true);
				}
			}
			// if (CopyDll(DllName) && Define.IsLua)
			// {
			// 	CompileLua(DllName, DllDir, OutDirName, null, true);
			// }
		}
		
		public static bool CopyDll(string dllName)
		{
			var result = FileHelper.CopyFile(Path.Combine(ScriptAssembliesDir, $"{dllName}.dll"), Path.Combine(CodeDir, $"{dllName}.dll.bytes"), true);
			
			result = result || FileHelper.CopyFile(Path.Combine(ScriptAssembliesDir, $"{dllName}.pdb"), Path.Combine(CodeDir, $"{dllName}.pdb.bytes"), true);

			if (result)
			{
				UnityEngine.Debug.Log($"复制{dllName}.dll, {dllName}.pdb到Res/Code完成");
				AssetDatabase.Refresh();
			}

			return result;
		}

		public static void CompileLua(string dllName, string dllDir, string outDirName, List<string> referencedLuaAssemblies, bool isModule)
		{
			LuaCompiler.Compile(dllName, dllDir, outDirName, referencedLuaAssemblies, isModule);
			FileHelper.ReplaceExtensionName(LuaCompiler.outDir + outDirName, LuaExtensionName, LuaTxtExtensionName);
			//ABNameEditor.SetFolderLuaABName(LuaCompiler.outDir + outDirName);
			AssetDatabase.Refresh();
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