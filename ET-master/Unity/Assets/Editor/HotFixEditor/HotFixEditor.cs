using System.Diagnostics;
using System.IO;

using UnityEditor;
using UnityEngine;

namespace ET
{
	public class HotFixEditor: Editor
	{
		[InitializeOnLoad]
		public class Startup
		{
			private const string ScriptAssembliesDir = "Library/ScriptAssemblies";
			private const string CodeDir = "Assets/Bundles/HotDll/";
			private const string HotfixDll = "Unity.Hotfix.dll";
			private const string HotfixPdb = "Unity.Hotfix.pdb";

			static Startup()
			{
				File.Copy(Path.Combine(ScriptAssembliesDir, HotfixDll), Path.Combine(CodeDir, "Hotfix.dll.bytes"), true);
				File.Copy(Path.Combine(ScriptAssembliesDir, HotfixPdb), Path.Combine(CodeDir, "Hotfix.pdb.bytes"), true);
				Log.Info($"复制Hotfix.dll, Hotfix.pdb到Res/Code完成");
				AssetDatabase.Refresh ();
			}
		}
	}
}