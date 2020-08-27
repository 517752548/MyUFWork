using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// 普通关卡的存档
/// </summary>
public class DailyLevelProgressData
{
    public List<DailyQuestionEntity> Questions;

    /// <summary>
    /// key answer   value 存档   普通关卡的词库 00101A
    /// </summary>
    public Dictionary<string, string> levelData;

    /// <summary>
    /// key answer   value 被提示的个数
    /// </summary>
    public Dictionary<string, int> wordHints;

    public Dictionary<string, bool> wordUseHint2;

    public Dictionary<int, Dictionary<int, KeyValuePair<int, int>>> flyMap;

    public DailyLevelProgressData()
    {
        Questions = new List<DailyQuestionEntity>();
        levelData = new Dictionary<string, string>();
        wordHints = new Dictionary<string, int>();
        wordUseHint2 = new Dictionary<string, bool>();
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
        }
    }

    public bool IsMatchCurLevel(List<DailyQuestionEntity> level)
    {
        if (levelData.Count > 0)
        {
            string answer = "";
            char[] arr = level[0].Answer.ToUpper().Trim().ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != ' ')
                    answer += arr[i];
            }
            return levelData.ContainsKey(answer);
        }

        return true;
    }
}