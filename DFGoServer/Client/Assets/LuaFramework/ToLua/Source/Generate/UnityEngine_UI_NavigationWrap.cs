﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_UI_NavigationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.Navigation), null);
		L.RegFunction("Equals", new LuaCSFunction(Equals));
		L.RegFunction("New", new LuaCSFunction(_CreateUnityEngine_UI_Navigation));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("mode", new LuaCSFunction(get_mode), new LuaCSFunction(set_mode));
		L.RegVar("selectOnUp", new LuaCSFunction(get_selectOnUp), new LuaCSFunction(set_selectOnUp));
		L.RegVar("selectOnDown", new LuaCSFunction(get_selectOnDown), new LuaCSFunction(set_selectOnDown));
		L.RegVar("selectOnLeft", new LuaCSFunction(get_selectOnLeft), new LuaCSFunction(set_selectOnLeft));
		L.RegVar("selectOnRight", new LuaCSFunction(get_selectOnRight), new LuaCSFunction(set_selectOnRight));
		L.RegVar("defaultNavigation", new LuaCSFunction(get_defaultNavigation), null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_UI_Navigation(IntPtr L)
	{
		UnityEngine.UI.Navigation obj = new UnityEngine.UI.Navigation();
		ToLua.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)ToLua.CheckObject(L, 1, TypeTraits<UnityEngine.UI.Navigation>.type);
			UnityEngine.UI.Navigation arg0 = StackTraits<UnityEngine.UI.Navigation>.Check(L, 2);
			bool o = obj.Equals(arg0);
			LuaDLL.lua_pushboolean(L, o);
			ToLua.SetBack(L, 1, obj);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Navigation.Mode ret = obj.mode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectOnUp(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Selectable ret = obj.selectOnUp;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index selectOnUp on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectOnDown(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Selectable ret = obj.selectOnDown;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index selectOnDown on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectOnLeft(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Selectable ret = obj.selectOnLeft;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index selectOnLeft on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectOnRight(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Selectable ret = obj.selectOnRight;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index selectOnRight on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defaultNavigation(IntPtr L)
	{
		try
		{
			ToLua.PushValue(L, UnityEngine.UI.Navigation.defaultNavigation);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Navigation.Mode arg0 = (UnityEngine.UI.Navigation.Mode)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.UI.Navigation.Mode>.type);
			obj.mode = arg0;
			ToLua.SetBack(L, 1, obj);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index mode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectOnUp(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Selectable arg0 = (UnityEngine.UI.Selectable)ToLua.CheckObject<UnityEngine.UI.Selectable>(L, 2);
			obj.selectOnUp = arg0;
			ToLua.SetBack(L, 1, obj);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index selectOnUp on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectOnDown(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Selectable arg0 = (UnityEngine.UI.Selectable)ToLua.CheckObject<UnityEngine.UI.Selectable>(L, 2);
			obj.selectOnDown = arg0;
			ToLua.SetBack(L, 1, obj);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index selectOnDown on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectOnLeft(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Selectable arg0 = (UnityEngine.UI.Selectable)ToLua.CheckObject<UnityEngine.UI.Selectable>(L, 2);
			obj.selectOnLeft = arg0;
			ToLua.SetBack(L, 1, obj);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index selectOnLeft on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectOnRight(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Navigation obj = (UnityEngine.UI.Navigation)o;
			UnityEngine.UI.Selectable arg0 = (UnityEngine.UI.Selectable)ToLua.CheckObject<UnityEngine.UI.Selectable>(L, 2);
			obj.selectOnRight = arg0;
			ToLua.SetBack(L, 1, obj);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index selectOnRight on a nil value");
		}
	}
}
