using UnityEngine;
namespace LuaFramework
{
	public class AppConst
	{
		//下面这部分在构造中进行动态判断
		//Lua代码AssetBundle模式
		public static bool LuaBundleMode;
		//end

		public const string AppName = "letus";               //应用程序名称
		public const string LuaTempDir = "Lua/";                    //临时目录
		public const string ExtName = ".unity3d";                   //素材扩展名
		public const string AssetDir = "StreamingAssets";           //素材目录 

		public static string FrameworkRoot
		{
			get
			{
				return Application.dataPath + "/" + "LuaFramework";
			}
		}

		static AppConst()
		{
			if (PlatformUtil.IsRunInEditor())
			{
				LuaBundleMode = false;
			}
			else
			{
				LuaBundleMode = true;
			}

		}
	}
}