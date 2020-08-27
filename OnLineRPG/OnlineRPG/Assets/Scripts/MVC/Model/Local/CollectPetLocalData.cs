using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CollectPetLocalData {

	public bool m_IsShowNew;
	public bool m_IsLock;//是否被解锁
	public int m_CurrentPieces;//当前碎片数量

	private string localstr;
	public CollectPetLocalData(string localstr)
	{
		this.localstr = localstr;

	}

	public CollectPetLocalData(bool m_IsShowNew,bool m_IsLock,int m_CurrentPieces)
	{
		this.m_IsShowNew = m_IsShowNew;
		this.m_IsLock = m_IsLock;
		this.m_CurrentPieces = m_CurrentPieces;
	}

	public CollectPetLocalData()
	{
		m_IsShowNew = false;
		m_IsLock = true;
		m_CurrentPieces = 0;
	}
	public bool LoadSuccessful()
	{
		// 数据是这样的"1,2,3,4,5"
		string[] onepetlocaldatastr = localstr.Split(',');
		try
		{
			for (int i = 0; i < onepetlocaldatastr.Length; i++)
			{
				m_IsShowNew = onepetlocaldatastr[0].Equals("1");
				m_IsLock = onepetlocaldatastr[1].Equals("1");
				m_CurrentPieces = int.Parse(onepetlocaldatastr[2]);
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
		builder.Append(m_IsShowNew ? "1" : "0");
		builder.Append(",");
		builder.Append(m_IsLock ? "1" : "0");
		builder.Append(",");
		builder.Append(m_CurrentPieces);
		return builder.ToString();
	}
}
