using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "AnimateFrameData", menuName = "AnimateFrameDataAsset", order = 1)]
public class AnimateFrameData : ScriptableObject
{
	public static string SCRIPTABLE_PATH = "Config/FaceAnimateFrameData/FaceAnimateFrameData.asset";
	[SerializeField]
	public List<AnimateFrameInfo> frameInfoList;

	private Dictionary<string, AnimateFrameInfo> dict;

	public AnimateFrameInfo GetFrameInfoByName(string name)
	{
		if (frameInfoList == null)
		{
			return null;
		}
		if (dict == null)
		{
			dict = new Dictionary<string, AnimateFrameInfo>();
			for (int i = 0; i < frameInfoList.Count; i++)
			{
				if (!dict.ContainsKey(frameInfoList[i].name))
				{
					dict.Add(frameInfoList[i].name, frameInfoList[i]);
				}
			}
		}
		AnimateFrameInfo info;
		if (dict.TryGetValue(name, out info))
		{
			return info;
		}
		return null;
	}
}

[Serializable]
public class AnimateFrameInfo
{
	[SerializeField]
	public string name;
	[SerializeField]
	public float duration;

	public AnimateFrameInfo(string _name, float _duration)
	{
		name = _name;
		duration = _duration;
	}
}
