﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_UI_ScrollRect_ScrollbarVisibilityWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility));
		L.RegVar("Permanent", new LuaCSFunction(get_Permanent), null);
		L.RegVar("AutoHide", new LuaCSFunction(get_AutoHide), null);
		L.RegVar("AutoHideAndExpandViewport", new LuaCSFunction(get_AutoHideAndExpandViewport), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(IntToEnum));
		L.EndEnum();
		TypeTraits<UnityEngine.UI.ScrollRect.ScrollbarVisibility>.Check = CheckType;
		StackTraits<UnityEngine.UI.ScrollRect.ScrollbarVisibility>.Push = Push;
	}

	static void Push(IntPtr L, UnityEngine.UI.ScrollRect.ScrollbarVisibility arg)
	{
		ToLua.Push(L, arg);
	}

	static Type TypeOf_UnityEngine_UI_ScrollRect_ScrollbarVisibility = typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility);

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(TypeOf_UnityEngine_UI_ScrollRect_ScrollbarVisibility, L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Permanent(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.UI.ScrollRect.ScrollbarVisibility.Permanent);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AutoHide(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHide);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AutoHideAndExpandViewport(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tointeger(L, 1);
		UnityEngine.UI.ScrollRect.ScrollbarVisibility o = (UnityEngine.UI.ScrollRect.ScrollbarVisibility)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}
