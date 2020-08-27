using System;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class WordLibraryDailyData
{
	private Dictionary<string, int> dataCache; 
	public void Init()
	{
		dataCache = new Dictionary<string, int>();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="aCategoryId"></param>
	/// <param name="defaultValue"></param>
	/// <returns>是数组索引下标，值从0开始</returns>
	public int GetQuestionEntityBeginIndex(int aCategoryId, int defaultValue = 0)
	{
		string key = string.Format("{0}QEB_{1}", PrefKeys.WordLibraryDailyPrefix, aCategoryId);
		if (dataCache.ContainsKey(key)) {
			return dataCache[key];
		} else {
			dataCache[key] = Record.GetInt(key, defaultValue);
		}
		return dataCache[key];
	}

	public void SetQuestionEntityBeginIndex(int aCategoryId,int value)
	{
		string key = string.Format("{0}QEB_{1}", PrefKeys.WordLibraryDailyPrefix, aCategoryId);
		bool needSet = true;
		if (dataCache.ContainsKey(key)) {
			if (dataCache[key] == value) {
				needSet = false;
			}
		}
		if (needSet) {
			dataCache[key] = value;
			Record.SetInt(key, value);
		}
	}

	public int GetQuestionEntityMaxIndex(int aCategoryId, int defaultValue = 0)
	{
		string key = string.Format("{0}QEM_{1}", PrefKeys.WordLibraryDailyPrefix, aCategoryId);
		if (dataCache.ContainsKey(key)) {
			return dataCache[key];
		} else {
			dataCache[key] = Record.GetInt(key, defaultValue);
		}
		return dataCache[key];
	}

	public void AddQuestionEntityMaxIndexAdAddd(int aCategoryId, int value, int defaultValue = 0)
	{
		int aNowMax = GetQuestionEntityMaxIndex(aCategoryId, defaultValue);
		int setedValue = aNowMax + value;
		string key = string.Format("{0}QEM_{1}", PrefKeys.WordLibraryDailyPrefix, aCategoryId);
		bool needSet = true;
		if (dataCache.ContainsKey(key)) {
			if (dataCache[key] == setedValue) {
				needSet = false;
			}
		}
		if (needSet) {
			dataCache[key] = setedValue;
			Record.SetInt(key, setedValue);
		}
	}

	//最后一个文件允许不足文件个数
	public int GetQuestionEntitnLastFileCount(int aCategoryId, int defaultValue = 0)
	{
		string key = string.Format("{0}QELFC_{1}", PrefKeys.WordLibraryDailyPrefix, aCategoryId);
		if (dataCache.ContainsKey(key)) {
			return dataCache[key];
		} else {
			dataCache[key] = Record.GetInt(key, defaultValue);
		}
		return dataCache[key];
	}

	public void SetQuestionEntityLastFileCount(int aCategoryId, int value)
	{
		string key = string.Format("{0}QELFC_{1}", PrefKeys.WordLibraryDailyPrefix, aCategoryId);
		bool needSet = true;
		if (dataCache.ContainsKey(key)) {
			if (dataCache[key] == value) {
				needSet = false;
			}
		}
		if (needSet) {
			dataCache[key] = value;
			Record.SetInt(key, value);
		}
	}
}
