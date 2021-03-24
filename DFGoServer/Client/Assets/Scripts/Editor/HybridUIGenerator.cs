using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Text;
using Gear;
using ICSharpCode.NRefactory.Ast;
using TMPro;

/*
V1.0	取消了根节点也输出到OnLoaded方法中的问题，根节点用不到，无需生成
V2.0	1、加入了Destroy方法的生成
		2、生成完毕后，编辑器面板会自动关闭
V2.1	修复添加了UICustomNodeIgnore的节点也输出到Destroy方法中的问题
V2.2	节点在Destroy方法中的生成顺序改为倒序
V2.3	打开HybridUI之后，会查找要生成的lua文件是否存在，如果存在，那么读取其中的配置作为初始化直接显示到编辑器的界面中
V2.4	增加IsPlaySound选项，默认值为true
V2.5	1、增加OnLoaded方法调用父类OnLoaded方法
		2、从变体继承下来的节点不参与生成
		3、增加允许填写自定义父类名字
V2.6	增加变体继承下来的面板生成ctor构造方法
V2.7	解决变体继承情况下，新增节点的子节点无法生成的问题
V2.8	增加NumberImage组件
V2.9	增加AnimateSprite组件
V2.10	增加RollText组件
V2.11	增加LinkImageText组件
V3.0	增加生成UI名字定义枚举
*/
namespace HybridUI.Generator
{
	public enum HybridUIParentConsts
	{
		BASEUI,
		UGUIOBJECT,
		TOGGLE,
		BUTTON,
		STANDALONENODE,
		CUSTOM,
	}
	public enum HybridUILayerConsts
	{
		BUBBLE,
		TITLE,
		SKIPFONT,
		TOUCH,
		BOTTOM,
		HOME,
		CENTER_LOW2,
		CENTER_LOW1,
		CENTER,
		CENTER_HIGH1,
		CENTER_HIGH2,
		NPCTALK,
		TOP,
		STORY,
		NOTICE,
		LOADING,
	}

	public class HybridUIClassDefine
	{
		public string superClassName = "";
		public HybridUIParentConsts parentType;
		public string prefabName = "";
		public string className = "";
		public string Output()
		{
			string template = "--Created by HybridUI V3.0\n_G.{0} = class(" + superClassName + "){1}";
			string tempPanelNameDefine = "";
			if (parentType == HybridUIParentConsts.BASEUI || parentType == HybridUIParentConsts.CUSTOM)
			{
				tempPanelNameDefine = string.Format("\n\nUIPanelName.{0} = \"{1}\"", prefabName, prefabName);
			}
			return string.Format(template, className, tempPanelNameDefine);
		}
	}

	public class HybridUIFunctionBase
	{
		public string prefabName = "";
		public string className = "";
		public string functionName = "";
		public List<string> functionParams = new List<string>();
		public string functionContent = "";
		public virtual string Output()
		{
			string template = "function {0}:{1}({2})\n\t{3}\nend";
			return string.Format(template, className, functionName, string.Join(", ", functionParams.ToArray()), functionContent);
		}
	}

	public class HybridUIFunction_ctor : HybridUIFunctionBase
	{
		public HybridUILayerConsts layer;
		public string layerName = "";
		public HybridUIFunction_ctor()
		{
			functionName = "ctor";
		}
		public override string Output()
		{
			string template = "self.prefabName = '{0}'\n\tself.parentNodeName = _G.UILayerConsts.{1}";
			functionContent = string.Format(template, prefabName, layerName);
			return base.Output();
		}
	}

	public class HybridUINodeData
	{
		public string className = "";
		public string prefabName = "";
		public string nodeName = "";
		public bool isRoot = false;
		public string componentName = "";
		public HybridUINodeData parentNodeData;
		public Transform transform;

		public string GetNodeName()
		{
			string parentNodeName = parentNodeData != null ? parentNodeData.GetNodeName() : "";
			if (isRoot)
			{
				return "";
			}
			if (string.IsNullOrEmpty(parentNodeName))
			{
				return nodeName;
			}
			return parentNodeName + "." + nodeName;
		}

		public string GetParentNodeCombineName()
		{
			string parentNodeName = parentNodeData != null ? parentNodeData.GetParentNodeCombineName() : "";
			if (isRoot)
			{
				return "";
			}
			if (string.IsNullOrEmpty(parentNodeName))
			{
				return nodeName;
			}
			return parentNodeName + "/" + nodeName;
		}

		public bool IsStandaloneNode()
		{
			if (transform.GetComponent<UICustomStandaloneNode>() != null)
			{
				return true;
			}
			return false;
		}

		public string GetStandaloneNodeName()
		{
			if (componentName == HybridUIUtil.COMPONENT_NAME_STANDALONE_NODE)
			{
				string UpperNodeName = nodeName.Substring(0, 1).ToUpper() + nodeName.Substring(1);
				return prefabName + UpperNodeName;
			}
			return componentName;
		}

		public string Output()
		{
			if (string.IsNullOrEmpty(componentName))
			{
				return "";
			}
			//处理下StandaloneNode
			if (IsStandaloneNode())
			{
				componentName = GetStandaloneNodeName();
			}
			string template = "self.{0} = {1}.New({2})";
			string findNodeStr = "";
			if (isRoot)
			{
				findNodeStr = "self.transform";
			}
			else
			{
				findNodeStr = "self.transform:Find('" + GetParentNodeCombineName() + "')";
			}
			string tempNodeName = GetNodeName();
			tempNodeName = string.IsNullOrEmpty(tempNodeName) ? nodeName : tempNodeName;
			string result = string.Format(template, tempNodeName, componentName, findNodeStr);
			return result;
		}

		public string OutputForDestroy()
		{
			if (string.IsNullOrEmpty(componentName))
			{
				return "";
			}
			string tempNodeName = GetNodeName();
			tempNodeName = string.IsNullOrEmpty(tempNodeName) ? nodeName : tempNodeName;
			return string.Format("self.{0}:Destroy()", tempNodeName);
		}

		public string OutputForSetNil()
		{
			if (string.IsNullOrEmpty(componentName))
			{
				return "";
			}
			string tempNodeName = GetNodeName();
			tempNodeName = string.IsNullOrEmpty(tempNodeName) ? nodeName : tempNodeName;
			return string.Format("self.{0} = nil", tempNodeName);
		}
	}

	public class HybridUIFunction_OnLoaded : HybridUIFunctionBase
	{
		public GameObject panel;
		public List<HybridUINodeData> nodeDataList = new List<HybridUINodeData>();
		public List<HybridUINodeData> standaloneDataList = new List<HybridUINodeData>();
		public HybridUIFunction_OnLoaded()
		{
			functionName = "OnLoaded";
		}

		public void Init()
		{
			ParseGameObject(panel.transform, true);
		}

		private void ParseGameObject(Transform tf, bool isRoot, HybridUINodeData parent = null)
		{
			//变体继承下来的不生成
			if (PrefabUtility.HasPrefabInstanceAnyOverrides(panel, true))
			{
				if (!isRoot && PrefabUtility.IsAddedGameObjectOverride(tf.gameObject) == false && HybridUIUtil.HasParentIsAddedGameObjectOverride(tf) == false)
					return;
			}
			//查看自身的组件
			HybridUINodeData data = new HybridUINodeData();
			data.className = className;
			data.prefabName = prefabName;
			data.nodeName = tf.gameObject.name;
			data.isRoot = isRoot;
			data.componentName = GetGameObjectComponentName(tf);
			data.parentNodeData = parent;
			data.transform = tf;
			if (!isRoot)
			{
				nodeDataList.Add(data);
			}
			if (data.IsStandaloneNode()) //挑选出StandaloneNode，用来后续生成处理用
			{
				bool hasResult = false;
				foreach (HybridUINodeData item in standaloneDataList)
				{
					if (data.GetStandaloneNodeName() == item.GetStandaloneNodeName())
					{
						hasResult = true;
						break;
					}
				}
				if (!hasResult)
					standaloneDataList.Add(data);
			}
			int childCount = tf.childCount;
			if (isRoot || IsFindComponentChildren(data.componentName))
			{
				for (int i = 0; i < childCount; i++)
				{
					Transform childTF = tf.GetChild(i);
					ParseGameObject(childTF, false, data);
				}
			}
		}

		public override string Output()
		{
			List<string> nodeDataStringList = new List<string>();
			nodeDataStringList.Add(string.Format("{0}.superclass.{1}(self)", className, functionName));
			foreach (HybridUINodeData item in nodeDataList)
			{
				string nodeDataOutput = item.Output();
				if (!string.IsNullOrEmpty(nodeDataOutput))
				{
					nodeDataStringList.Add(nodeDataOutput);
				}
			}
			functionContent += string.Join("\n\t", nodeDataStringList.ToArray());
			return base.Output();
		}

		private string GetGameObjectComponentName(Transform tf)
		{
			if (tf.GetComponent<UICustomStandaloneNode>() != null)
			{
				UICustomStandaloneNode sn = tf.GetComponent<UICustomStandaloneNode>();
				if (string.IsNullOrEmpty(sn.className))
				{
					return HybridUIUtil.COMPONENT_NAME_STANDALONE_NODE;
				}
				else
				{
					return sn.className;
				}
			}
			if (tf.GetComponent<UICustomNodeIgnore>() != null)
			{
				return "";
			}
			if (tf.GetComponent<UICustomNode>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_NODE;
			}
			if (tf.GetComponent<LinkImageText>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_LINKIMAGETEXT;
			}
			if (tf.GetComponent<UICustomNumberImage>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_NUMBERIMAGE;
			}
			if (tf.GetComponent<AnimateSprite>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_ANIMATESPRITE;
			}
			if (tf.GetComponent<RollText>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_ROLLTEXT;
			}
			if (tf.GetComponent<CircleList>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_CIRCLELIST;
			}
			if (tf.GetComponent<UICustomScrollList>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_SCROLLLIST;
			}
			if (tf.GetComponent<UICustomScrollFlowList>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_SCROLLFLOWLIST;
			}
			if (tf.GetComponent<UICustomScrollLoopList>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_SCROLLLOOPLIST;
			}
			if (tf.GetComponent<ScrollRect>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_SCROLLLIST;
			}
			if (tf.GetComponent<InputField>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_INPUTFIELD;
			}
			if (tf.GetComponent<UICustomProgressBar>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_PROGRESSBAR;
			}
			if (tf.GetComponent<UICustomComboBox>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_COMBOBOX;
			}
			if (tf.GetComponent<Toggle>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_TOGGLE;
			}
			if (tf.GetComponent<Slider>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_SLIDER;
			}
			if (tf.GetComponent<Button>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_BUTTON;
			}
			if (tf.GetComponent<Text>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_TEXT;
			}
			if (tf.GetComponent<TextMeshProUGUI>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_TEXTMeshProUGUI;
			}
			if (tf.GetComponent<Image>() != null)
			{
				return HybridUIUtil.COMPONENT_NAME_UGUIOBJECT;
			}
			return HybridUIUtil.COMPONENT_NAME_UGUIOBJECT;
		}

		private bool IsFindComponentChildren(string componentName)
		{
			if (string.IsNullOrEmpty(componentName))
			{
				return false;
			}
			switch (componentName)
			{
				case HybridUIUtil.COMPONENT_NAME_NODE_IGNORE:
					return false;
				case HybridUIUtil.COMPONENT_NAME_STANDALONE_NODE:
					return false;
				case HybridUIUtil.COMPONENT_NAME_NODE:
					return true;
				case HybridUIUtil.COMPONENT_NAME_CIRCLELIST:
					return false;
				case HybridUIUtil.COMPONENT_NAME_SCROLLFLOWLIST:
					return false;
				case HybridUIUtil.COMPONENT_NAME_SCROLLLOOPLIST:
					return false;
				case HybridUIUtil.COMPONENT_NAME_SCROLLLIST:
					return false;
				case HybridUIUtil.COMPONENT_NAME_INPUTFIELD:
					return false;
				case HybridUIUtil.COMPONENT_NAME_PROGRESSBAR:
					return false;
				case HybridUIUtil.COMPONENT_NAME_NUMBERIMAGE:
					return false;
				case HybridUIUtil.COMPONENT_NAME_ANIMATESPRITE:
					return false;
				case HybridUIUtil.COMPONENT_NAME_LINKIMAGETEXT:
					return false;
				case HybridUIUtil.COMPONENT_NAME_ROLLTEXT:
					return false;
				case HybridUIUtil.COMPONENT_NAME_COMBOBOX:
					return false;
				case HybridUIUtil.COMPONENT_NAME_TOGGLE:
					return false;
				case HybridUIUtil.COMPONENT_NAME_SLIDER:
					return false;
				case HybridUIUtil.COMPONENT_NAME_BUTTON:
					return false;
				case HybridUIUtil.COMPONENT_NAME_TEXT:
					return false;
				case HybridUIUtil.COMPONENT_NAME_TEXTMeshProUGUI:
					return false;
				case HybridUIUtil.COMPONENT_NAME_UGUIOBJECT:
					return true;
			}
			return false;
		}
	}

	public class HybridUIFunction_UIConfig : HybridUIFunctionBase
	{
		public string returnContent = "";

		public HybridUIFunction_UIConfig(string _className, string _functionName, string _returnContent)
		{
			className = _className;
			functionName = _functionName;
			returnContent = _returnContent;
		}

		public override string Output()
		{
			string template = "return {0}";
			functionContent = string.Format(template, returnContent);
			return base.Output();
		}
	}

	public class HybridUIFunction_Destroy : HybridUIFunctionBase
	{
		public HybridUIParentConsts parentType;
		private List<HybridUINodeData> nodeDataList;
		public HybridUIFunction_Destroy(List<HybridUINodeData> _nodeDataList)
		{
			nodeDataList = _nodeDataList;
			functionName = "Destroy";
		}

		public override string Output()
		{
			string template = "{0}.superclass.{1}(self)";
			string nodeDataOutput;
			HybridUINodeData item;
			List<string> nodeDataStringList = new List<string>();
			if (parentType == HybridUIParentConsts.BASEUI)
			{
				nodeDataStringList.Add(string.Format(template, className, functionName));
			}
			for (int i = nodeDataList.Count - 1; i >= 0; i--)
			{
				item = nodeDataList[i];
				nodeDataOutput = item.OutputForDestroy();
				if (!string.IsNullOrEmpty(nodeDataOutput))
				{
					nodeDataStringList.Add(nodeDataOutput);
				}
			}
			for (int i = nodeDataList.Count - 1; i >= 0; i--)
			{
				item = nodeDataList[i];
				nodeDataOutput = item.OutputForSetNil();
				if (!string.IsNullOrEmpty(nodeDataOutput))
				{
					nodeDataStringList.Add(nodeDataOutput);
				}
			}
			if (parentType != HybridUIParentConsts.BASEUI || parentType == HybridUIParentConsts.CUSTOM)
			{
				nodeDataStringList.Add(string.Format(template, className, functionName));
			}
			functionContent = string.Join("\n\t", nodeDataStringList.ToArray());
			return base.Output();
		}
	}

	public class HybridUIGenerator
	{
		public string className = "";
		public string prefabName = "";
		public HybridUIParentConsts parentType;
		public string customParentName = "";
		public HybridUILayerConsts layer;
		public bool isLoadAsync = true;
		public bool isNeverDelete = false;
		public bool isImmediatelyDelete = true;
		public bool isTween = false;
		public bool isFullScreen = false;
		public bool isScreenBlur = false;
		public bool isPlaySound = true;
		public GameObject panel;
		public List<HybridUINodeData> standaloneDataList = new List<HybridUINodeData>();
		public HybridUIClassDefine classDefine;
		public HybridUIFunction_ctor func_ctor;
		public HybridUIFunction_OnLoaded func_onloaded;
		public List<HybridUIFunction_UIConfig> func_uiconfigs = new List<HybridUIFunction_UIConfig>();
		public HybridUIFunction_Destroy func_destroy;
		public void Init()
		{
			classDefine = new HybridUIClassDefine();
			classDefine.superClassName = parentType == HybridUIParentConsts.CUSTOM ? customParentName : HybridUIUtil.parentOptions[(int)parentType];
			classDefine.parentType = parentType;
			classDefine.prefabName = prefabName;	
			classDefine.className = className;

			func_ctor = new HybridUIFunction_ctor();
			func_ctor.className = className;
			func_ctor.prefabName = prefabName;
			func_ctor.layer = layer;
			func_ctor.layerName = HybridUIUtil.GetLayerName(layer);

			func_onloaded = new HybridUIFunction_OnLoaded();
			func_onloaded.className = className;
			func_onloaded.prefabName = prefabName;
			func_onloaded.panel = panel;
			func_onloaded.Init();
			standaloneDataList = func_onloaded.standaloneDataList;

			func_uiconfigs.Add(new HybridUIFunction_UIConfig(className, "IsLoadAsync", HybridUIUtil.GetBoolStr(isLoadAsync)));
			func_uiconfigs.Add(new HybridUIFunction_UIConfig(className, "IsNeverDelete", HybridUIUtil.GetBoolStr(isNeverDelete)));
			func_uiconfigs.Add(new HybridUIFunction_UIConfig(className, "IsImmediatelyDelete", HybridUIUtil.GetBoolStr(isImmediatelyDelete)));
			func_uiconfigs.Add(new HybridUIFunction_UIConfig(className, "IsTween", HybridUIUtil.GetBoolStr(isTween)));
			func_uiconfigs.Add(new HybridUIFunction_UIConfig(className, "IsFullScreen", HybridUIUtil.GetBoolStr(isFullScreen)));
			func_uiconfigs.Add(new HybridUIFunction_UIConfig(className, "IsScreenBlur", HybridUIUtil.GetBoolStr(isScreenBlur)));
			func_uiconfigs.Add(new HybridUIFunction_UIConfig(className, "IsPlaySound", HybridUIUtil.GetBoolStr(isPlaySound)));

			func_destroy = new HybridUIFunction_Destroy(func_onloaded.nodeDataList);
			func_destroy.parentType = parentType;
			func_destroy.className = className;
			func_destroy.prefabName = prefabName;
		}

		public string Output()
		{
			List<string> result = new List<string>();
			result.Add(classDefine.Output());
			if (parentType == HybridUIParentConsts.BASEUI || parentType == HybridUIParentConsts.CUSTOM)
			{
				result.Add(func_ctor.Output());
			}
			result.Add(func_onloaded.Output());
			if (parentType == HybridUIParentConsts.BASEUI)
			{
				List<string> uiconfigs = new List<string>();
				foreach (HybridUIFunction_UIConfig config in func_uiconfigs)
				{
					result.Add(config.Output());
				}
			}
			result.Add(func_destroy.Output());
			return string.Join("\n\n", result.ToArray());
		}
	}

	public class HybridUIUtil
	{
		public const string COMPONENT_NAME_NODE_IGNORE = "NodeIgnore";
		public const string COMPONENT_NAME_STANDALONE_NODE = "StandaloneNode";
		public const string COMPONENT_NAME_NODE = "Node";
		public const string COMPONENT_NAME_CIRCLELIST = "CircleList";
		public const string COMPONENT_NAME_SCROLLFLOWLIST = "ScrollFlowList";
		public const string COMPONENT_NAME_SCROLLLOOPLIST = "ScrollLoopList";
		public const string COMPONENT_NAME_SCROLLLIST = "ScrollList";
		public const string COMPONENT_NAME_INPUTFIELD = "InputField";
		public const string COMPONENT_NAME_PROGRESSBAR = "ProgressBar";
		public const string COMPONENT_NAME_NUMBERIMAGE = "NumberImage";
		public const string COMPONENT_NAME_ANIMATESPRITE = "AnimateSprite";
		public const string COMPONENT_NAME_ROLLTEXT = "RollText";
		public const string COMPONENT_NAME_LINKIMAGETEXT = "LinkImageText";
		public const string COMPONENT_NAME_COMBOBOX = "ComboBox";
		public const string COMPONENT_NAME_TOGGLE = "Toggle";
		public const string COMPONENT_NAME_SLIDER = "Slider";
		public const string COMPONENT_NAME_BUTTON = "Button";
		public const string COMPONENT_NAME_TEXT = "Text";
		public const string COMPONENT_NAME_TEXTMeshProUGUI = "TextMeshProUGUI";
		public const string COMPONENT_NAME_UGUIOBJECT = "UGUIObject";
		public static string[] parentOptions = new string[] {
											"BaseUI",
											"UGUIObject",
											"Toggle",
											"Button",
											"StandaloneNode",
											"User Custom..."
		};

		public static string[] layerOptions = new string[] { "BUBBLE",
											"TITLE",
											"SKIPFONT",
											"TOUCH",
											"BOTTOM",
											"HOME",
											"CENTER_LOW2",
											"CENTER_LOW1",
											"CENTER",
											"CENTER_HIGH1",
											"CENTER_HIGH2",
											"NPCTALK",
											"TOP",
											"STORY",
											"NOTICE",
											"LOADING" };

		public static string GetLayerName(HybridUILayerConsts layer)
		{
			return layerOptions[(int)layer];
		}

		public static string GetBoolStr(bool value)
		{
			return value ? "true" : "false";
		}

		public static HybridUIParentConsts GetParentConstsInLuaFile(string content)
		{
			Regex reg = new Regex("class\\((.+)\\)");
			Match match = reg.Match(content);
			string value = match.Groups[1].Value;
			if (!string.IsNullOrEmpty(value))
			{
				for (int i = 0; i < parentOptions.Length; i++)
				{
					string item = parentOptions[i];
					if (item.Equals(value))
					{
						return (HybridUIParentConsts)i;
					}
				}
			}
			return HybridUIParentConsts.CUSTOM;
		}

		public static string GetCustomParentNameInLuaFile(string content)
		{
			Regex reg = new Regex("class\\((.+)\\)");
			Match match = reg.Match(content);
			string value = match.Groups[1].Value;
			if (!string.IsNullOrEmpty(value))
			{
				return value;
			}
			return "";
		}

		public static HybridUILayerConsts GetLayerConstsInLuaFile(string content)
		{
			Regex reg = new Regex("UILayerConsts\\.(.+)");
			Match match = reg.Match(content);
			string value = match.Groups[1].Value;
			if (!string.IsNullOrEmpty(value))
			{
				for (int i = 0; i < layerOptions.Length; i++)
				{
					string item = layerOptions[i];
					if (item.Equals(value))
					{
						return (HybridUILayerConsts)i;
					}
				}
			}
			return HybridUILayerConsts.CENTER;
		}

		private static string GetFuncReturnInLuaFile(string funcName, string content)
		{
			Regex reg = new Regex(funcName + "\\(\\)\n*\t*return\\s+(\\w+)\n*end");
			Match match = reg.Match(content);
			string value = match.Groups[1].Value;
			return value;
		}

		public static bool GetIsLoadAsyncValueInLuaFile(string content)
		{
			string value = GetFuncReturnInLuaFile("IsLoadAsync", content);
			if (!string.IsNullOrEmpty(value))
			{
				return value == "true" ? true : false;
			}
			return true;
		}

		public static bool GetIsNeverDeleteValueInLuaFile(string content)
		{
			string value = GetFuncReturnInLuaFile("IsNeverDelete", content);
			if (!string.IsNullOrEmpty(value))
			{
				return value == "true" ? true : false;
			}
			return false;
		}

		public static bool GetIsImmediatelyDeleteValueInLuaFile(string content)
		{
			string value = GetFuncReturnInLuaFile("IsImmediatelyDelete", content);
			if (!string.IsNullOrEmpty(value))
			{
				return value == "true" ? true : false;
			}
			return true;
		}

		public static bool GetIsTweenValueInLuaFile(string content)
		{
			string value = GetFuncReturnInLuaFile("IsTween", content);
			if (!string.IsNullOrEmpty(value))
			{
				return value == "true" ? true : false;
			}
			return false;
		}

		public static bool GetIsFullScreenValueInLuaFile(string content)
		{
			string value = GetFuncReturnInLuaFile("IsFullScreen", content);
			if (!string.IsNullOrEmpty(value))
			{
				return value == "true" ? true : false;
			}
			return false;
		}

		public static bool GetIsScreenBlurValueInLuaFile(string content)
		{
			string value = GetFuncReturnInLuaFile("IsScreenBlur", content);
			if (!string.IsNullOrEmpty(value))
			{
				return value == "true" ? true : false;
			}
			return false;
		}

		public static bool GetIsPlaySoundValueInLuaFile(string content)
		{
			string value = GetFuncReturnInLuaFile("IsPlaySound", content);
			if (!string.IsNullOrEmpty(value))
			{
				return value == "true" ? true : false;
			}
			return false;
		}

		public static bool HasParentIsAddedGameObjectOverride(Transform tsf)
		{
			if (tsf.parent != null)
			{
				bool parentResult = PrefabUtility.IsAddedGameObjectOverride(tsf.parent.gameObject);
				if (parentResult)
				{
					return true;
				}
				else
				{
					return HasParentIsAddedGameObjectOverride(tsf.parent);
				}
			}
			return false;
		}
	}
}