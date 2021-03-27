﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UIDrawModelDataWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIDrawModelData), typeof(System.Object));
		L.RegFunction("New", new LuaCSFunction(_CreateUIDrawModelData));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("charType", new LuaCSFunction(get_charType), new LuaCSFunction(set_charType));
		L.RegVar("modelId", new LuaCSFunction(get_modelId), new LuaCSFunction(set_modelId));
		L.RegVar("textureSize", new LuaCSFunction(get_textureSize), new LuaCSFunction(set_textureSize));
		L.RegVar("cameraPos", new LuaCSFunction(get_cameraPos), new LuaCSFunction(set_cameraPos));
		L.RegVar("cameraEulerAngles", new LuaCSFunction(get_cameraEulerAngles), new LuaCSFunction(set_cameraEulerAngles));
		L.RegVar("cameraPosGap", new LuaCSFunction(get_cameraPosGap), new LuaCSFunction(set_cameraPosGap));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUIDrawModelData(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UIDrawModelData obj = new UIDrawModelData();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UIDrawModelData.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_charType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			int ret = obj.charType;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index charType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_modelId(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			int ret = obj.modelId;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index modelId on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textureSize(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			int ret = obj.textureSize;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index textureSize on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraPos(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			UnityEngine.Vector3 ret = obj.cameraPos;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index cameraPos on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraEulerAngles(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			UnityEngine.Vector3 ret = obj.cameraEulerAngles;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index cameraEulerAngles on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraPosGap(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			UnityEngine.Vector3 ret = obj.cameraPosGap;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index cameraPosGap on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_charType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			int arg0 = (int)LuaDLL.luaL_checkinteger(L, 2);
			obj.charType = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index charType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_modelId(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			int arg0 = (int)LuaDLL.luaL_checkinteger(L, 2);
			obj.modelId = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index modelId on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textureSize(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			int arg0 = (int)LuaDLL.luaL_checkinteger(L, 2);
			obj.textureSize = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index textureSize on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cameraPos(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.cameraPos = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index cameraPos on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cameraEulerAngles(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.cameraEulerAngles = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index cameraEulerAngles on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cameraPosGap(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIDrawModelData obj = (UIDrawModelData)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.cameraPosGap = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index cameraPosGap on a nil value");
		}
	}
}
