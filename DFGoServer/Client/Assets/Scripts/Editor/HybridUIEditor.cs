using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using HybridUI.Generator;
using System.IO;
using System.Collections.Generic;

namespace HybridUI.Generator
{
	public class HybridUIStandaloneNodePreviewData
	{
		public string className = "";
		public string previewCode = "";
	}
	public class HybridUIEditor : EditorWindow
	{
		//是否初始化查找过，第一次打开的时候会根据className去遍历项目中model目录的文件夹查找对应的lua文件，查找一次后这个值变为true，目的是找到已有的lua文件读取里面的已经生成过的配置信息
		bool isInitSearched = false;
		bool isSearchedLuaSuccess = false;
		string luaFilePath = "";

		GameObject prefab;
		string prefabName = "";
		string className = "";

		int currentParent = (int)HybridUIParentConsts.BASEUI;
		string customParentName = "";
		int currentSelectLayer = (int)HybridUILayerConsts.CENTER;
		bool isLoadAsync = true;
		bool isNeverDelete = false;
		bool isImmediatelyDelete = true;
		bool isTween = false;
		bool isFullScreen = false;
		bool isScreenBlur = false;
		bool isPlaySound = true;
		string previewCode = "";
		Vector2 scroll;
		string inputPrefabName = null;
		List<HybridUINodeData> standaloneDataList = null;
		List<HybridUIStandaloneNodePreviewData> standalonePreviewCodeList = null;

		//在硬盘中查找className所对应的已经存在的文件的内容
		string FindExistedLuaFileContent()
		{
			if (string.IsNullOrEmpty(className))
			{
				return "";
			}
			string fullPath = Path.Combine(Application.dataPath, "Scripts/lua/module");
			fullPath = fullPath.Replace('/', '\\');
			if (!Directory.Exists(fullPath))
			{
				return "";
			}
			DirectoryInfo dir = new DirectoryInfo(fullPath);
			FileInfo[] files = dir.GetFiles("*.lua", SearchOption.AllDirectories);
			foreach (FileInfo item in files)
			{
				string luaFileName = Path.GetFileNameWithoutExtension(item.Name);
				if (luaFileName.Equals(className))
				{
					luaFilePath = item.FullName;
					return System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(item.FullName));
				}
			}
			return "";
		}

		void OnGUI()
		{
			prefab = Selection.activeGameObject;
			if (prefab == null)
				return;
			if (inputPrefabName == null)
			{
				inputPrefabName = prefab.name;
			}
			inputPrefabName = EditorGUILayout.TextField("Prefab Name:", inputPrefabName, EditorStyles.textField);
			prefabName = inputPrefabName;
			className = inputPrefabName + "HybridUI";
			EditorGUILayout.LabelField("Class Name:", className, EditorStyles.textField);
			EditorGUILayout.Space();
			if (!isInitSearched)
			{
				string luaContent = FindExistedLuaFileContent();
				if (!string.IsNullOrEmpty(luaContent))
				{
					//解析获取值
					currentParent = (int)HybridUIUtil.GetParentConstsInLuaFile(luaContent);
					if (currentParent == (int)HybridUIParentConsts.CUSTOM)
					{
						customParentName = HybridUIUtil.GetCustomParentNameInLuaFile(luaContent);
					}
					currentSelectLayer = (int)HybridUIUtil.GetLayerConstsInLuaFile(luaContent);
					isLoadAsync = HybridUIUtil.GetIsLoadAsyncValueInLuaFile(luaContent);
					isNeverDelete = HybridUIUtil.GetIsNeverDeleteValueInLuaFile(luaContent);
					isImmediatelyDelete = HybridUIUtil.GetIsImmediatelyDeleteValueInLuaFile(luaContent);
					isTween = HybridUIUtil.GetIsTweenValueInLuaFile(luaContent);
					isFullScreen = HybridUIUtil.GetIsFullScreenValueInLuaFile(luaContent);
					isScreenBlur = HybridUIUtil.GetIsScreenBlurValueInLuaFile(luaContent);
					isPlaySound = HybridUIUtil.GetIsPlaySoundValueInLuaFile(luaContent);
					isSearchedLuaSuccess = true;
				}
				else
				{
					isSearchedLuaSuccess = false;
				}
				isInitSearched = true;
			}
			if (isSearchedLuaSuccess)
			{
				EditorGUILayout.HelpBox("已经设置并且应用了已经存在的" + className + ".lua" + "中的配置\n所在路径:" + luaFilePath, MessageType.Info);
			}
			else
			{
				EditorGUILayout.HelpBox("没有找到" + className + ".lua" + "文件，这次将是第一次生成此文件", MessageType.Warning);
			}
			currentParent = EditorGUILayout.Popup("Superclass Name：", currentParent, HybridUIUtil.parentOptions);
			if (currentParent == (int)HybridUIParentConsts.BASEUI)
			{
				EditorGUILayout.Space();
				currentSelectLayer = EditorGUILayout.Popup("UI所在层级：", currentSelectLayer, HybridUIUtil.layerOptions);
				EditorGUILayout.Space();
				isLoadAsync = EditorGUILayout.ToggleLeft("是否异步加载IsLoadAsync", isLoadAsync);
				isNeverDelete = EditorGUILayout.ToggleLeft("是否永不销毁IsNeverDelete", isNeverDelete);
				if (!isNeverDelete)
				{
					isImmediatelyDelete = EditorGUILayout.ToggleLeft("是否立即销毁（在关闭之后）IsImmediatelyDelete", isImmediatelyDelete);
				}
				else
				{
					isImmediatelyDelete = true;
				}
				isTween = EditorGUILayout.ToggleLeft("是否缓动打开关闭IsTween", isTween);
				isFullScreen = EditorGUILayout.ToggleLeft("是否是全屏界面IsFullScreen", isFullScreen);
				if (isFullScreen)
				{
					isScreenBlur = false;
				}
				else
				{
					isScreenBlur = EditorGUILayout.ToggleLeft("面板打开后场景是否模糊IsScreenBlur", isScreenBlur);
				}
				isPlaySound = EditorGUILayout.ToggleLeft("面板打开和关闭是否播放音效IsPlaySound", isPlaySound);
			}
			else if (currentParent == (int)HybridUIParentConsts.CUSTOM)
			{
				//自定义
				customParentName = EditorGUILayout.TextField("请填写自定义父类类名：", customParentName);
			}
			EditorGUILayout.BeginHorizontal();
			GUI.backgroundColor = string.IsNullOrEmpty(previewCode) ? Color.green : Color.white;
			if (GUILayout.Button("预览代码", GUILayout.Height(50)))
			{
				standaloneDataList = new List<HybridUINodeData>();
				HybridUIGenerator gen = new HybridUIGenerator();
				gen.className = className;
				gen.prefabName = prefabName;
				gen.parentType = (HybridUIParentConsts)currentParent;
				gen.customParentName = customParentName;
				gen.layer = (HybridUILayerConsts)currentSelectLayer;
				gen.isLoadAsync = isLoadAsync;
				gen.isNeverDelete = isNeverDelete;
				gen.isImmediatelyDelete = isImmediatelyDelete;
				gen.isTween = isTween;
				gen.isFullScreen = isFullScreen;
				gen.isScreenBlur = isScreenBlur;
				gen.isPlaySound = isPlaySound;
				gen.panel = prefab;
				gen.Init();
				standaloneDataList = gen.standaloneDataList;
				previewCode = gen.Output();

				if (standaloneDataList != null && standaloneDataList.Count > 0)
				{
					standalonePreviewCodeList = new List<HybridUIStandaloneNodePreviewData>();
					foreach (HybridUINodeData data in standaloneDataList)
					{
						string nodePath = data.GetParentNodeCombineName();
						GameObject p = prefab.transform.Find(nodePath).gameObject;
						HybridUIGenerator g = new HybridUIGenerator();
						g.className = data.GetStandaloneNodeName() + "HybridUI";
						g.prefabName = "";
						g.parentType = HybridUIParentConsts.STANDALONENODE;
						g.panel = p;
						g.Init();
						HybridUIStandaloneNodePreviewData d = new HybridUIStandaloneNodePreviewData();
						d.className = g.className;
						d.previewCode = g.Output();
						standalonePreviewCodeList.Add(d);

					}
				}
			}
			GUI.backgroundColor = Color.white;
			if (!string.IsNullOrEmpty(previewCode))
			{
				GUI.backgroundColor = Color.green;
				if (GUILayout.Button("保存", GUILayout.Height(50)))
				{
					string dir;
					if (isSearchedLuaSuccess)
					{
						dir = Path.GetDirectoryName(luaFilePath);
					}
					else
					{
						dir = Application.dataPath + "/Scripts/lua/module";
					}
					string newPath = EditorUtility.SaveFilePanel("Save File To", dir, className + ".lua", "lua");
					if (!string.IsNullOrEmpty(newPath))
					{
						byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(previewCode);
						File.WriteAllBytes(newPath, byteArray);
					}
					if (standalonePreviewCodeList != null && standalonePreviewCodeList.Count > 0)
					{
						foreach (HybridUIStandaloneNodePreviewData item in standalonePreviewCodeList)
						{
							newPath = EditorUtility.SaveFilePanel("Save File To", Path.GetFullPath(newPath), item.className + ".lua", "lua");
							if (!string.IsNullOrEmpty(newPath))
							{
								byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(item.previewCode);
								File.WriteAllBytes(newPath, byteArray);
							}
						}
					}
					this.Close();
				}
				GUI.backgroundColor = Color.white;
			}
			EditorGUILayout.EndHorizontal();
			if (!string.IsNullOrEmpty(previewCode))
			{
				scroll = EditorGUILayout.BeginScrollView(scroll);
				EditorGUILayout.TextArea(previewCode, GUILayout.ExpandHeight(true));
				EditorGUILayout.EndScrollView();
			}
			ShowStandaloneNodeContent();
		}

		void ShowStandaloneNodeContent()
		{
			if (standalonePreviewCodeList == null || standalonePreviewCodeList.Count == 0)
			{
				return;
			}
			foreach (HybridUIStandaloneNodePreviewData item in standalonePreviewCodeList)
			{
				EditorGUILayout.TextArea(item.previewCode, GUILayout.ExpandHeight(true));
			}
		}

	}
}