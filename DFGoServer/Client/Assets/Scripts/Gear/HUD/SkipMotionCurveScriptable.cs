using UnityEngine;
using System.Collections.Generic;

public class SkipMotionCurveScriptable : ScriptableObject
{

	[SerializeField]
	public List<SkipMotionCurveData> curveDataList;

	public void AddCurveData(SkipMotionCurveData data)
	{
		curveDataList.Add(data);
	}

	public SkipMotionCurveData GetCurveData(string typeName)
	{
		if (curveDataList == null)
		{
			return null;
		}
		for (int i = 0; i < curveDataList.Count; i++)
		{
			if (curveDataList[i].typeName == typeName)
			{
				return curveDataList[i];
			}
		}
		return null;
	}
}
