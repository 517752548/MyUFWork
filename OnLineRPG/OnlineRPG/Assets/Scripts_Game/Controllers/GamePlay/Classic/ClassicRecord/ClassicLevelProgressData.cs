﻿using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// 普通关卡的存档
/// </summary>
public class ClassicLevelProgressData
{
    public int LevelID = -1;
    /// <summary>
    /// key answer   value 存档   普通关卡的词库 00101A
    /// </summary>
    public Dictionary<string, string> levelData;

    /// <summary>
    /// key answer   value 被提示的个数
    /// </summary>
    public Dictionary<string, int> wordHints;

    public Dictionary<string, bool> wordUseHint2;

    public Dictionary<string, string> cellsState;
    public bool BeeUsed = false;
    public int BeeUsedCount = 0;
    
    public int RateRewardWordIndex = -1;
    public int RateRewardWordSeq = -1;

    public Dictionary<int, Dictionary<int, KeyValuePair<int, int>>> flyMap;
    
    public ClassicLevelProgressData()
    {
        levelData = new Dictionary<string, string>();
        wordHints = new Dictionary<string, int>();
        wordUseHint2 = new Dictionary<string, bool>();
        cellsState = new Dictionary<string, string>();
        flyMap = new Dictionary<int, Dictionary<int, KeyValuePair<int, int>>>();
    }


    public void CacheMemary(List<BaseWord> words)
    {
        for (int i = 0; i < words.Count; i++)
        {
            levelData[words[i].Answer] = words[i].StateInfo;
            wordHints[words[i].Answer] = words[i].HintCount;
            if (words[i].IsKeyboardHintUsed)
            {
                if (wordUseHint2.ContainsKey(words[i].Answer))
                {
                    wordUseHint2[words[i].Answer] = true;
                }
                else
                {
                    wordUseHint2.Add(words[i].Answer, true);
                }
            }
            cellsState[words[i].Answer] = words[i].CellsState;
        }
    }
}