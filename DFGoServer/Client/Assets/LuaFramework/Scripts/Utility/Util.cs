using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using LuaInterface;
using LuaFramework;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LuaFramework
{
	public class Util
	{
		private static List<string> luaPaths = new List<string>();

		private static List<RaycastResult> touchRaycastResultList = new List<RaycastResult>();
		public static int Int(object o)
		{
			return Convert.ToInt32(o);
		}

		public static float Float(object o)
		{
			return (float)Math.Round(Convert.ToSingle(o), 2);
		}

		public static long Long(object o)
		{
			return Convert.ToInt64(o);
		}

		public static int Random(int min, int max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static float Random(float min, float max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static string Uid(string uid)
		{
			int position = uid.LastIndexOf('_');
			return uid.Remove(0, position + 1);
		}

		public static long GetTime()
		{
			TimeSpan ts = new TimeSpan(DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0).Ticks);
			return (long)ts.TotalMilliseconds;
		}

		/// <summary>
		/// 搜索子物体组件-GameObject版
		/// </summary>
		public static T Get<T>(GameObject go, string subnode) where T : Component
		{
			if (go != null)
			{
				Transform sub = go.transform.Find(subnode);
				if (sub != null) return sub.GetComponent<T>();
			}
			return null;
		}

		/// <summary>
		/// 搜索子物体组件-Transform版
		/// </summary>
		public static T Get<T>(Transform go, string subnode) where T : Component
		{
			if (go != null)
			{
				Transform sub = go.Find(subnode);
				if (sub != null) return sub.GetComponent<T>();
			}
			return null;
		}

		/// <summary>
		/// 搜索子物体组件-Component版
		/// </summary>
		public static T Get<T>(Component go, string subnode) where T : Component
		{
			return go.transform.Find(subnode).GetComponent<T>();
		}

		/// <summary>
		/// 添加组件
		/// </summary>
		public static T Add<T>(GameObject go) where T : Component
		{
			if (go != null)
			{
				T[] ts = go.GetComponents<T>();
				for (int i = 0; i < ts.Length; i++)
				{
					if (ts[i] != null) GameObject.Destroy(ts[i]);
				}
				return go.gameObject.AddComponent<T>();
			}
			return null;
		}

		/// <summary>
		/// 添加组件
		/// </summary>
		public static T Add<T>(Transform go) where T : Component
		{
			return Add<T>(go.gameObject);
		}

		/// <summary>
		/// 查找子对象
		/// </summary>
		public static GameObject Child(GameObject go, string subnode)
		{
			return Child(go.transform, subnode);
		}

		/// <summary>
		/// 查找子对象
		/// </summary>
		public static GameObject Child(Transform go, string subnode)
		{
			Transform tran = go.Find(subnode);
			if (tran == null) return null;
			return tran.gameObject;
		}
		/// <summary>
		/// 深度查找子对象
		/// </summary>
		public static Transform FindChildDeep(Transform go, string subnode)
		{
			if (subnode.Equals(go.name))
			{
				return go;
			}
			int count = go.childCount;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					Transform result = FindChildDeep(go.GetChild(i), subnode);
					if (result != null)
					{
						return result;
					}
				}
			}
			return null;
		}

		public static void SetChildrenActive(Transform go, bool active, Transform ignoreTSF = null)
		{
			int count = go.childCount;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					Transform temp = go.GetChild(i);
					if (temp != ignoreTSF)
					{
						temp.gameObject.SetActive(active);
					}
				}
			}
		}

		public static void SetLayerAndChildren(Transform go, int layerIndex)
		{
			go.gameObject.layer = layerIndex;
			int count = go.childCount;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					SetLayerAndChildren(go.GetChild(i), layerIndex);
				}
			}
		}

		// 设置所有子控件上面的 Renderer 的层级
		public static void SetRenderOrder(Transform tsf, int orderIdx)
		{
			Renderer[] renders = tsf.GetComponentsInChildren<Renderer>(true);
			foreach (Renderer render in renders)
			{
				render.sortingOrder += orderIdx;
			}
		}

		public static void SetRenderOrderWithParent(Transform tsf)
		{
			int orderIdx = GetParentOrder(tsf);

			Renderer[] renders = tsf.GetComponentsInChildren<Renderer>(true);
			foreach (Renderer render in renders)
			{
				render.sortingOrder = orderIdx;
			}
		}

		// 获取父  Renderer 的层级
		public static int GetParentOrder(Transform tsf)
		{
			Canvas cav = tsf.GetComponentInParent<Canvas>();
			if (cav)
			{
				return cav.sortingOrder;
			}

			return 0;
		}

		// 给当前组件添加层级
		public static void SetOrder(Transform tsf, int orderIdx)
		{
			UICustomGraphicRaycaster gy = tsf.GetComponent<UICustomGraphicRaycaster>();
			if (gy == null)
			{
				gy = tsf.gameObject.AddComponent<UICustomGraphicRaycaster>();
			}

			Canvas cav = tsf.GetComponent<Canvas>();
			if (cav == null)
			{
				cav = tsf.gameObject.AddComponent<Canvas>();
			}

			cav.overrideSorting = true;
			cav.sortingOrder = orderIdx;

		}

		// 共享骨骼
		public static void ShareSkeletonInstance(SkinnedMeshRenderer targetSkin, SkinnedMeshRenderer tempSkin, GameObject target)
		{
			Transform[] newBones = new Transform[tempSkin.bones.Length];
			for (int i = 0; i < tempSkin.bones.Length; ++i)
			{
				GameObject bone = tempSkin.bones[i].gameObject;
				// 目标的SkinnedMeshRenderer.bones保存的只是目标mesh相关的骨骼,要获得目标全部骨骼,可以通过查找的方式.
				newBones[i] = FindChildDeep(target.transform, bone.name);
			}
			targetSkin.bones = newBones;
		}
		//获取一个UI对象的实际尺寸，如果是深度查找，那么就找出最大的实际尺寸
		public static Vector2 GetRectTransformPreferredSize(RectTransform rect, bool isDeep = false, float currWidth = 0f, float currHeight = 0f)
		{
			currWidth = Mathf.Max(currWidth, rect.sizeDelta.x);
			currHeight = Mathf.Max(currHeight, rect.sizeDelta.y);
			int count = rect.childCount;
			if (isDeep && count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					Vector2 v = GetRectTransformPreferredSize(rect.GetChild(i) as RectTransform, true, currWidth, currHeight);
					currWidth = Mathf.Max(currWidth, v.x);
					currHeight = Mathf.Max(currHeight, v.y);
				}
			}
			return new Vector2(currWidth, currHeight);
		}
		/// <summary>
		/// 取平级对象
		/// </summary>
		public static GameObject Peer(GameObject go, string subnode)
		{
			return Peer(go.transform, subnode);
		}

		/// <summary>
		/// 取平级对象
		/// </summary>
		public static GameObject Peer(Transform go, string subnode)
		{
			Transform tran = go.parent.Find(subnode);
			if (tran == null) return null;
			return tran.gameObject;
		}

		/// <summary>
		/// 计算字符串的MD5值
		/// </summary>
		public static string md5(string source)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			byte[] data = System.Text.Encoding.UTF8.GetBytes(source);
			byte[] md5Data = md5.ComputeHash(data, 0, data.Length);
			md5.Clear();

			string destString = "";
			for (int i = 0; i < md5Data.Length; i++)
			{
				destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
			}
			destString = destString.PadLeft(32, '0');
			return destString;
		}

		/// <summary>
		/// 计算文件的MD5值
		/// </summary>
		public static string md5file(string file)
		{
			try
			{
				FileStream fs = new FileStream(file, FileMode.Open);
				System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] retVal = md5.ComputeHash(fs);
				fs.Close();

				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < retVal.Length; i++)
				{
					sb.Append(retVal[i].ToString("x2"));
				}
				return sb.ToString();
			}
			catch (Exception ex)
			{
				throw new Exception("md5file() fail, error:" + ex.Message);
			}
		}

		/// <summary>
		/// 清除所有子节点
		/// </summary>
		public static void ClearChild(Transform go)
		{
			if (go == null) return;
			for (int i = go.childCount - 1; i >= 0; i--)
			{
				GameObject.Destroy(go.GetChild(i).gameObject);
			}
		}

		public static void ClearChildImmediate(Transform go)
		{
			if (go == null) return;
			for (int i = go.childCount - 1; i >= 0; i--)
			{
				GameObject.DestroyImmediate(go.GetChild(i).gameObject);
			}
		}

		/// <summary>
		/// 清理内存
		/// </summary>
		public static void ClearMemory()
		{
			//GC.Collect();
			//Resources.UnloadUnusedAssets();
			ApplicationLua mgr = ApplicationKernel.GetApplicationLua();
			if (mgr != null) mgr.LuaGC();
		}

		/// <summary>
		/// 取得数据存放目录
		/// </summary>
		public static string DataPath
		{
			get
			{
				string game = AppConst.AppName.ToLower();
				if (Application.isMobilePlatform)
				{
					return Application.persistentDataPath + "/" + game + "/";
				}
				if (PlatformUtil.IsRunInEditor())
				{
					return Application.dataPath + "/" + AppConst.AssetDir + "/";
				}
				if (Application.platform == RuntimePlatform.OSXEditor)
				{
					int i = Application.dataPath.LastIndexOf('/');
					return Application.dataPath.Substring(0, i + 1) + game + "/";
				}
				return "c:/" + game + "/";
			}
		}

		/// <summary>
		/// 取得行文本
		/// </summary>
		public static string GetFileText(string path)
		{
			return File.ReadAllText(path);
		}

		/// <summary>
		/// 网络可用
		/// </summary>
		public static bool NetAvailable
		{
			get
			{
				return Application.internetReachability != NetworkReachability.NotReachable;
			}
		}

		/// <summary>
		/// 是否是无线
		/// </summary>
		public static bool IsWifi
		{
			get
			{
				return Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
			}
		}

		/// <summary>
		/// 应用程序内容路径
		/// </summary>
		public static string AppContentPath()
		{
			string path = string.Empty;
			switch (Application.platform)
			{
				case RuntimePlatform.Android:
					path = "jar:file://" + Application.dataPath + "!/assets/";
					break;
				case RuntimePlatform.IPhonePlayer:
					path = Application.dataPath + "/Raw/";
					break;
				default:
					path = Application.dataPath + "/" + AppConst.AssetDir + "/";
					break;
			}
			return path;
		}

		public static void Log(string str)
		{
			Debug.Log(str);
		}

		public static void LogWarning(string str)
		{
			Debug.LogWarning(str);
		}

		public static void LogError(string str)
		{
			Debug.LogError(str);
		}


		/// <summary>
		/// 执行Lua方法
		/// </summary>
		public static object[] CallMethod(string module, string func, params object[] args)
		{
			ApplicationLua luaMgr = ApplicationKernel.GetApplicationLua();
			if (luaMgr == null) return null;
			return luaMgr.CallFunction(module + "." + func, args);
		}

		public static void CallLuaFunction(string className, string funcName, string paramStr)
		{
			ApplicationLua luaMgr = ApplicationKernel.GetApplicationLua();
			if (luaMgr == null) return;
			luaMgr.CallLuaFunction(className, funcName, paramStr);
		}

		/// <summary>
		/// 颜色转换, "#RRGGBB" or "#RRGGBBAA" 转换成 Color(r,g,b,a)
		/// </summary>
		public static Color HtmlStringToColor(string colorstr, Color def)
		{
			Color nowColor;
			if (!ColorUtility.TryParseHtmlString(colorstr, out nowColor))
			{
				if (def != null)
				{
					nowColor = def;
				}
				else
				{
					nowColor = Color.white;
				}
			}
			return nowColor;
		}

		/// <summary>
		/// 颜色转换,  Color(r,g,b,a) 转换成 "#RRGGBBAA"
		/// </summary>
		public static string ColorToHtmlString(Color color)
		{
			return ColorUtility.ToHtmlStringRGBA(color);
		}

		public static Dictionary<string, PlayableBinding> GetPlayableOutputsDict(PlayableDirector director)
		{
			Dictionary<string, PlayableBinding> bindingDict = new Dictionary<string, PlayableBinding>();
			foreach (PlayableBinding pb in director.playableAsset.outputs)
			{
				if (!bindingDict.ContainsKey(pb.streamName))
				{
					bindingDict.Add(pb.streamName, pb);
				}
			}
			return bindingDict;
		}

		public static UIDrawModelData GetUIDrawModelData(UIDrawModelPanelVO panelVO, int charType, int modelId)
		{
			for (int i = 0; i < panelVO.modelDatas.Count; i++)
			{
				UIDrawModelData data = panelVO.modelDatas[i];
				if (data.charType == charType && data.modelId == modelId)
				{
					return data;
				}
			}
			return null;
		}

		public static bool CheckTouchOnGameObject(Vector2 position, GameObject touchGameObject)
		{
			PointerEventData eventData = new PointerEventData(EventSystem.current);
			eventData.position = position;
			touchRaycastResultList.Clear();
			EventSystem.current.RaycastAll(eventData, touchRaycastResultList);
			for (int i = 0; i < touchRaycastResultList.Count; i++)
			{
				if (touchRaycastResultList[i].gameObject == touchGameObject)
				{
					return true;
				}
			}
			touchRaycastResultList.Clear();
			return false;
		}

		public static void EnableCameraDepthTextureMode(Camera cam, DepthTextureMode mode)
		{
			if (cam == null)
			{
				return;
			}
			cam.depthTextureMode |= mode;
		}

		public static AnimationState GetAnimationState(Animation animation, string name)
		{
			return animation[name];
		}
	}
}