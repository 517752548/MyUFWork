#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class ReSetImage
{
	//替换资源文件夹中全部Prefab的字体
	[MenuItem("LetUs/UI Tools/ReSetImage")]
	public static void ReSet()
	{
		List<Text> textList = new List<Text>();

		//获取UI文件夹下所有Prefab的GUID
		string[] ids = AssetDatabase.FindAssets("t:Prefab", new string[] { "Assets/Res/UI" });
		string tmpPath;
		
		int textCount = 0;

		Debug.Log("---------开始查找--------------");

		for (int i = 0; i < ids.Length; i++)
		{
			//tmpObj = null;
			//tmpArr = null;

			//根据GUID获取路径
			tmpPath = AssetDatabase.GUIDToAssetPath(ids[i]);
			if (!string.IsNullOrEmpty(tmpPath))
			{
				//根据路径获取Prefab(GameObject)
				GameObject tmpObj = AssetDatabase.LoadAssetAtPath(tmpPath, typeof(GameObject)) as GameObject;
				if (tmpObj != null)
				{
					//获取Prefab及其子物体孙物体···的所有Text组件
					Image[] tmpArr = tmpObj.GetComponentsInChildren<Image>(true);
					if (tmpArr != null && tmpArr.Length > 0)
					{
						for (int j = 0; j < tmpArr.Length; j++)
						{
							Image _img = tmpArr[j];
							if(_img != null && _img.sprite != null && _img.sprite.texture != null )
							{
								//Debug.Log("_img.sprite.texture.name----------->" + _img.sprite.texture.name.ToString());

								if (_img.sprite.texture.name == "touming")
								{
									Debug.Log("_img.sprite.texture.name=========================>" + _img.sprite.texture.name.ToString());
									_img.color = Color.clear;
									_img.sprite = null;

									
									textCount++;

									EditorUtility.SetDirty(tmpObj);
								}
							}							
						}
					}
				}
			}
		}
		

		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		
		Debug.Log("<color=green> 当前ProJect共有：Prefab </color>" + ids.Length + "<color=green> 个</color><color=red> 删除 透明 图 </color>" + textCount + "<color=red> 个</color>");
	}
}
#endif