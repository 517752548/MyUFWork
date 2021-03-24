using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using LuaInterface;
using System;

namespace LuaFramework
{
	public static class LuaHelper
	{

		/// <summary>
		/// getType
		/// </summary>
		/// <param name="classname"></param>
		/// <returns></returns>
		public static System.Type GetType(string classname)
		{
			Assembly assb = Assembly.GetExecutingAssembly();  //.GetExecutingAssembly();
			System.Type t = null;
			t = assb.GetType(classname); ;
			if (t == null)
			{
				t = assb.GetType(classname);
			}
			return t;
		}

		/// <summary>
		/// 对象池管理器
		/// </summary>
		public static ObjectPoolManager GetObjectPoolManager()
		{
			return ApplicationKernel.GetObjectPoolManager();
		}
		/// <summary>
		/// Lua管理器
		/// </summary>
		public static ApplicationLua GetLuaManager()
		{
			return ApplicationKernel.GetApplicationLua();
		}

		/// <summary>
		/// 资源管理器
		/// </summary>
		public static GResManager GetResManager()
		{
			return ApplicationKernel.GetResManager();
		}

		public static UnityEngine.UI.Navigation GetButtonNavigationNone()
		{
			UnityEngine.UI.Navigation nav = new UnityEngine.UI.Navigation();
			nav.mode = UnityEngine.UI.Navigation.Mode.None;
			return nav;
		}

		//获得游戏运行的时候唯一的版本号，这个是打版本的时候自动生成的
		public static string GetRuntimeBuildVersion()
		{
			return ApplicationKernel.runtimeBuildVersion;
		}
		/// <summary>
		/// pbc/pblua函数回调
		/// </summary>
		/// <param name="func"></param>
		public static void OnCallLuaFunc(LuaByteBuffer data, LuaFunction func)
		{
			if (func != null) func.Call(data);
			Debug.LogWarning("OnCallLuaFunc length:>>" + data.buffer.Length);
		}

		/// <summary>
		/// cjson函数回调
		/// </summary>
		/// <param name="data"></param>
		/// <param name="func"></param>
		public static void OnJsonCallFunc(string data, LuaFunction func)
		{
			Debug.LogWarning("OnJsonCallback data:>>" + data + " lenght:>>" + data.Length);
			if (func != null) func.Call(data);
		}
	}
}