using UnityEngine;
using UnityEditor;
using LuaInterface;
using LuaFramework;

public class ApplicationLua : MonoBehaviour
{
	private LuaState lua;
	private LuaLoader loader;
	private LuaLooper loop = null;

	private static ApplicationLua _instance;

	public static ApplicationLua GetInstance()
	{
		if (_instance == null)
		{
			_instance = new ApplicationLua();

		}
		return _instance;
	}

	public void Init()
	{
		loader = new LuaLoader();
		lua = new LuaState();
		this.OpenLibs();
		lua.LuaSetTop(0);

		LuaBinder.Bind(lua);
		DelegateFactory.Init();
		LuaCoroutine.Register(lua, this);
	}

	public void InitStart()
	{
		InitLuaPath();
		InitLuaBundle();
		this.lua.Start();    //启动LUAVM
		this.StartMain();
		this.StartLooper();
	}


	void StartLooper()
	{
		loop = gameObject.AddComponent<LuaLooper>();
		loop.luaState = lua;
	}

	//cjson 比较特殊，只new了一个table，没有注册库，这里注册一下
	protected void OpenCJson()
	{
		lua.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
		lua.OpenLibs(LuaDLL.luaopen_cjson);
		lua.LuaSetField(-2, "cjson");

		lua.OpenLibs(LuaDLL.luaopen_cjson_safe);
		lua.LuaSetField(-2, "cjson.safe");
	}


	#region luaide 调试库添加
	//如果项目中没有luasocket 请打开
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Socket_Core(System.IntPtr L)
	{
		return LuaDLL.luaopen_socket_core(L);
	}

	protected void OpenLuaSocket()
	{
		LuaConst.openLuaSocket = true;
		lua.BeginPreLoad();
		lua.RegFunction("socket.core", LuaOpen_Socket_Core);
		lua.EndPreLoad();
	}
	#endregion


	void StartMain()
	{
		if (loader.beZip)
		{
			DoFile("bootstrap/LuaBundles.lua");
			LuaTable table = lua.GetTable("LuaBundles");
			if (table != null)
			{
				object[] list = table.ToArray();

				for (int i = 0; i < list.Length; i++)
				{
					Debugger.Log("varTable[{0}], is {1}", i, list[i]);
					loader.AddBundle(list[i].ToString());
				}
				table.Dispose();
			}
		}

		lua.DoFile("bootstrap/GameMain.lua");

		LuaFunction main = lua.GetFunction("GameMain");
		main.Call();
		main.Dispose();
		main = null;
	}

	/// <summary>
	/// 初始化加载第三方库
	/// </summary>
	void OpenLibs()
	{
		lua.OpenLibs(LuaDLL.luaopen_pb);
		lua.OpenLibs(LuaDLL.luaopen_lpeg);
#if !LUAC_5_3
		lua.OpenLibs(LuaDLL.luaopen_bit);
#endif
		lua.OpenLibs(LuaDLL.luaopen_socket_core);

		//#region luaide socket 开启
		if (PlatformUtil.IsRunInEditor())
		{
			this.OpenLuaSocket();
		}
		//#endregion


		this.OpenCJson();
	}

	/// <summary>
	/// 初始化Lua代码加载路径
	/// </summary>
	void InitLuaPath()
	{
		if (!PlatformUtil.IsRunInEditor())
		{
			lua.AddSearchPath(Util.DataPath);
		}
	}

	/// <summary>
	/// 初始化LuaBundle
	/// </summary>
	void InitLuaBundle()
	{
		if (loader.beZip)
		{
			loader.AddBundle("lua.unity3d");
			loader.AddBundle("lua_jit.unity3d");
			loader.AddBundle("lua_system.unity3d");
			loader.AddBundle("lua_system_reflection.unity3d");
			loader.AddBundle("lua_system_injection.unity3d");
			loader.AddBundle("lua_unityengine.unity3d");
			loader.AddBundle("lua_misc.unity3d");
			loader.AddBundle("lua_cjson.unity3d");
			loader.AddBundle("lua_lpeg.unity3d");
			loader.AddBundle("lua_socket.unity3d");
			loader.AddBundle("lua_bootstrap.unity3d");
		}
	}

	public LuaState GetMainLuaState()
	{
		return lua;
	}

	public void DoFile(string filename)
	{
		lua.DoFile(filename);
	}

	// Update is called once per frame
	public object[] CallFunction(string funcName, params object[] args)
	{
		if (lua == null)
			return null;
		LuaFunction func = lua.GetFunction(funcName);
		if (func != null)
		{
			return func.LazyCall(args);
		}
		return null;
	}

	public void CallLuaFunction(string className, string funcName, string paramStr)
	{
		if (lua == null)
			return;
		LuaTable table = lua.GetTable(className);
		if (table != null)
		{
			LuaFunction func = table.GetLuaFunction(funcName);
			func.Call<LuaTable, string>(table, paramStr);
		}
	}

	public void LuaGC()
	{
		lua.LuaGC(LuaGCOptions.LUA_GCCOLLECT);
	}

	public void Close()
	{
		loop.Destroy();
		loop = null;

		lua.Dispose();
		lua = null;
		loader = null;
	}
}