using LuaInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class JProxy
{
	public static AndroidJavaObject GetCurrentActivity()
	{
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		return jo;
	}

	public static AndroidJavaClass GetJavaClass(string className)
	{
		AndroidJavaClass jc = new AndroidJavaClass(className);
		return jc;
	}

	public static AndroidJavaObject GetStatic(AndroidJavaObject jo, string fieldName)
	{
		if (jo == null)
		{
			return null;
		}
		return jo.GetStatic<AndroidJavaObject>(fieldName);
	}

	public static AndroidJavaObject Get(AndroidJavaObject jo, string fieldName)
	{
		if (jo == null)
		{
			return null;
		}
		return jo.Get<AndroidJavaObject>(fieldName);
	}

	public static void Call(AndroidJavaObject jo, string funcName, LuaTable luaTable)
	{
		if (jo == null)
		{
			return;
		}
		jo.Call(funcName, luaTable.ToArray());
	}
}
