#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.UI;

public class ReSetFontHeight
{
	[MenuItem("LetUs/UI Tools/ReSetFontHeight")]
	static private void ReSet()
	{
		bool success = false;

		Debug.Log("---------开始查找--------------");

		EditorUtility.DisplayProgressBar("Progress", "Replace Font...", 0);

		//获取Asset文件夹下所有Prefab的GUID
		string[] sdirs = { "Assets/Res/UI" };
		var asstIds = AssetDatabase.FindAssets("t:Prefab", sdirs);

		int count = 0;

		for (int i = 0; i < asstIds.Length; i++)
		{
			string path = AssetDatabase.GUIDToAssetPath(asstIds[i]);
			var pfb = AssetDatabase.LoadAssetAtPath<GameObject>(path);
			//var pfb = PrefabUtility.InstantiatePrefab(pfbFile) as GameObject;//不涉及增删节点,不用实例化

			Debug.Log(path, pfb);

			//获取Prefab及其子物体孙物体···的所有Text组件
			var texts = pfb.GetComponentsInChildren<Text>(true);
			foreach (Text _tempText in texts)
			{
				if (_tempText.font.fontNames[0] == "Alibaba PuHuiTi")
				{
					RectTransform tsf = _tempText.rectTransform;

					if (_tempText.fontSize == 14)
					{
						if (tsf.rect.height < 22)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 22);
							Debug.Log("---------->>>---设置高度:--22-------", pfb);
						}
					}
					else if (_tempText.fontSize == 16)
					{
						if (tsf.rect.height < 24)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 24);
							Debug.Log("---------->>>---设置高度:--24-------", pfb);
						}
					}
					else if (_tempText.fontSize == 18)
					{
						if (tsf.rect.height < 28)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 28);
							Debug.Log("---------->>>---设置高度:--28-------", pfb);
						}
					}
					else if (_tempText.fontSize == 20)
					{
						if (tsf.rect.height < 30)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 30);
							Debug.Log("---------->>>---设置高度:--30-------", pfb);
						}
					}
					else if (_tempText.fontSize == 22)
					{
						if (tsf.rect.height < 32)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 32);
							Debug.Log("---------->>>---设置高度:--32-------", pfb);
						}
					}
					else if (_tempText.fontSize == 24)
					{
						if (tsf.rect.height < 36)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 36);
							Debug.Log("---------->>>---设置高度:--36-------", pfb);
						}
					}
					else if (_tempText.fontSize == 28)
					{
						if (tsf.rect.height < 40)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 40);
							Debug.Log("---------->>>---设置高度:--40-------", pfb);
						}
					}
					else if (_tempText.fontSize == 30)
					{
						if (tsf.rect.height < 44)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 44);
							Debug.Log("---------->>>---设置高度:--44-------", pfb);
						}
					}
					else if (_tempText.fontSize == 32)
					{
						if (tsf.rect.height < 46)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 46);
							Debug.Log("---------->>>---设置高度:--46-------", pfb);
						}
					}
					else if (_tempText.fontSize == 42)
					{
						if (tsf.rect.height < 60)
						{
							tsf.sizeDelta = new Vector2(tsf.sizeDelta.x, 60);
							Debug.Log("---------->>>---设置高度:--60-------", pfb);
						}
					}
				}
			}

			PrefabUtility.SavePrefabAsset(pfb);
			
			EditorUtility.DisplayProgressBar("Replace Font Progress", pfb.name, count / (float)asstIds.Length);
		}

		EditorUtility.ClearProgressBar();
	}
}
#endif