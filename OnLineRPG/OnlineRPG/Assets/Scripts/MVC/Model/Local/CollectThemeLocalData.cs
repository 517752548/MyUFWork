using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CollectThemeLocalData
{
	public bool m_IsLock;
	public bool m_IsShowNew;
	public bool m_IsFinish;
	public int m_RareCount;
	public int m_NormalCount;
	
	private string localstr;
	public CollectThemeLocalData(string localstr)
	{
		this.localstr = localstr;

	}

	public CollectThemeLocalData()
	{
	}

	public bool LoadSuccessful()
	{
		// 数据是这样的"1,2,3,4,5"
		string[] onepetlocaldatastr = localstr.Split(',');
		try
		{
			for (int i = 0; i < onepetlocaldatastr.Length; i++)
			{
				m_IsLock = onepetlocaldatastr[0].Equals("1");
				m_IsShowNew = onepetlocaldatastr[1].Equals("1");
				m_IsFinish = onepetlocaldatastr[2].Equals("1");
				m_RareCount = int.Parse(onepetlocaldatastr[3]);
				m_NormalCount = int.Parse(onepetlocaldatastr[4]);
			}
		}
		catch (Exception e)
		{
			Debug.LogException(e);
			return false;
		}

		return true;
	}


	public string GetSaveStr()
	{
		StringBuilder builder = new StringBuilder();
		builder.Append(m_IsLock ? "1" : "0");
		builder.Append(",");
		builder.Append(m_IsShowNew ? "1" : "0");
		builder.Append(",");
		builder.Append(m_IsFinish ? "1" : "0");
		builder.Append(",");
		builder.Append(m_RareCount);
		builder.Append(",");
		builder.Append(m_NormalCount);
		return builder.ToString();
	}
}
