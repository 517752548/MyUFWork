using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EditorGameLevel : ScriptableObject
{
    public string word;
    public string answers;
    public string validWords;

    public string answerLayout;
    public int StarTag;
}

public class ItemLayout
{
    public List<ItemInfo> itemDataList = new List<ItemInfo>();
}

public class ItemInfo
{
    [JsonProperty("a")]
    public int type;

    [JsonProperty("b")]
    public int row;

    [JsonProperty("c")]
    public int col;
}

public class GameLevel
{
    /// <summary>
    /// 概率库的id
    /// </summary>
	[JsonProperty("p")]
	public int probability;
	[JsonProperty("s")]
	public string subject;
	[JsonProperty("a")]
	public List<AnswerInfo> answers;
}

public class AnswerInfo
{
	[JsonProperty("d")]
	public string desciption;
	[JsonProperty("a")]
	public string answer;
	[JsonProperty("c")]
	public int beginColumn;
	[JsonProperty("sc")]
	public int specialColumn;
    /// <summary>
    /// 优先级
    /// </summary>
    [JsonProperty("p")]
    public int priority;
    /// <summary>
    /// 最大飞入数,这个答案能被填充几个
    /// </summary>
	[JsonProperty("h")]
	public int hint;
    /// <summary>
    /// 词的分类
    /// </summary>
	[JsonProperty("cat")]
	public int category;

	public AnswerInfo() {
		category = -1;
		specialColumn = -1;
		hint = -1;
	}
}

public class SubWordLayout
{
    [JsonProperty("a")]
    public List<LevelLayout> Layouts = new List<LevelLayout>();
}

public class LevelLayout : IComparer<LevelLayout>
{
    //关卡值
    [JsonProperty(PropertyName = "a", Order = 1)]
    public int level;

    //letter
    [JsonProperty(PropertyName = "b", Order = 2)]
    public string letter;

    //row
    [JsonProperty(PropertyName = "c", Order = 3)]
    public byte row;

    //col

    [JsonProperty(PropertyName = "d", Order = 4)]
    public byte col;

    [JsonProperty(PropertyName = "e", Order = 5)]
    public string[] answers;

    public LevelLayout()
    {
    }

    public int Compare(LevelLayout x, LevelLayout y)
    {
        if (x == null || y == null)
            return 0;

        return x.level - y.level;
    }
}

public class ButterflySubWordLayout
{
    [JsonProperty("a")]
    public List<ButterflyLevelLayout> Layouts = new List<ButterflyLevelLayout>();
}

public class ButterflyLevelLayout : LevelLayout
{
    public ButterflyLevelLayout(LevelLayout layout)
    {
        if (layout != null)
        {
            this.level = layout.level;
            this.letter = layout.letter;
            this.row = layout.row;
            this.col = layout.col;
            this.answers = layout.answers;
        }
    }

    [JsonProperty(PropertyName = "f", Order = 6)]
    public List<ItemInfo> itemDataList;

    [JsonProperty(PropertyName = "g", Order = 7)]
    public int move;

    [JsonProperty(PropertyName = "h", Order = 8)]
    public int target;

    [JsonProperty(PropertyName = "i", Order = 9)]
    public int rate;

    [JsonProperty(PropertyName = "j", Order = 10)]
    public int lowestRate;

    [JsonProperty(PropertyName = "k", Order = 11)]
    public int generateCount;

    [JsonProperty(PropertyName = "l", Order = 12)]
    public int maxCount;

    public void ConvertToThis(LevelLayout levelLayout)
    {
        this.level = levelLayout.level;
        this.letter = levelLayout.letter;
        this.row = levelLayout.row;
        this.col = levelLayout.col;
        this.answers = levelLayout.answers;
    }
}