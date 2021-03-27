using UnityEngine;
using System.Collections;
using LuaInterface;
using System.Collections.Generic;
using UnityEngine.UI;
using LuaFramework;

public class GLuaComponent : MonoBehaviour
{
	//Lua表
	public LuaTable table;

	// 按钮回调
	private Dictionary<string, LuaFunction> buttons = new Dictionary<string, LuaFunction>();


	//添加LUA组件  
	public static LuaTable Add(GameObject go, LuaTable tableClass)
	{
		LuaFunction fun = tableClass.GetLuaFunction("New");
		if (fun == null)
			return null;

		object ret = fun.Invoke<LuaTable, object>(tableClass);
		if (ret == null)
			return null;

		GLuaComponent cmp = go.AddComponent<GLuaComponent>();
		cmp.table = (LuaTable)ret;
		//将当前GameObject赋值过去
		LuaFunction setGameObjectFunc = cmp.table.GetLuaFunction("SetGameObject");
		setGameObjectFunc.Call<LuaTable, GameObject>(cmp.table, go);
		cmp.CallAwake();

		return cmp.table;
	}

	//获取lua组件
	public static LuaTable Get(GameObject go, LuaTable table)
	{
		GLuaComponent[] cmps = go.GetComponents<GLuaComponent>();
		foreach (GLuaComponent cmp in cmps)
		{
			string mat1 = table.ToString();
			string mat2 = cmp.table.GetMetaTable().ToString();
			if (mat1 == mat2)
			{
				return cmp.table;
			}
		}
		return null;
	}

	void CallAwake()
	{
		if (table == null)
			return;
		LuaFunction fun = table.GetLuaFunction("Awake");
		if (fun != null)
			fun.Call(table, gameObject);
	}

	void Start()
	{
		if (table == null)
			return;
		LuaFunction fun = table.GetLuaFunction("Start");
		if (fun != null)
			fun.Call(table, gameObject);
	}

	void OnDisable()
	{
		if (table == null)
			return;
		LuaFunction fun = table.GetLuaFunction("OnDisable");
		if (fun != null)
			fun.Call(table, gameObject);
	}

	/// <summary>
	/// 添加单击事件
	/// </summary>
	public void AddClick(GameObject go, string funName)
	{
		if (go == null || funName == string.Empty)
			return;
		if (table == null)
			return;
		LuaFunction luafunc = table.GetLuaFunction(funName);
		if (luafunc == null)
			return;

		buttons.Add(go.name, luafunc);
		go.GetComponent<Button>().onClick.AddListener(
			delegate ()
			{
				luafunc.Call(table, go);
			}
		);
	}

	/// <summary>
	/// 删除单击事件
	/// </summary>
	/// <param name="go"></param>
	public void RemoveClick(GameObject go)
	{
		if (go == null) return;
		LuaFunction luafunc = null;
		if (buttons.TryGetValue(go.name, out luafunc))
		{
			luafunc.Dispose();
			luafunc = null;
			buttons.Remove(go.name);
		}
	}

	/// <summary>
	/// 清除单击事件
	/// </summary>
	public void ClearClick()
	{
		foreach (var de in buttons)
		{
			if (de.Value != null)
			{
				de.Value.Dispose();
			}
		}
		buttons.Clear();
	}

	//-----------------------------------------------------------------
	protected void OnDestroy()
	{
		if (table == null)
			return;
		LuaFunction fun = table.GetLuaFunction("OnDestroy");
		if (fun != null)
			fun.Call(table);

		ClearClick();

//		Debug.Log("~" + name + " was destroy!");
	}
}
