using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ClassicSubWorldEntity //: ScriptableObject
{
    public int ID;
    public string Name;
    public int RewardID;
    public List<ClassicPackage> Packages;

    //private List<int> LevelIDs;
    private Dictionary<int, int> LevelIdDict;
    public int StartLevelIndex { get; private set; }
    public int EndLevelIndex { get; private set; }


    public Dictionary<int, int> GetLevelIdDict()
    {
        if(LevelIdDict == null)
            LevelIdDict = new Dictionary<int, int>();
        return LevelIdDict;
    }
    
    public int SubWorldLoad(int index)
    {
        int levelIndex = index;
        StartLevelIndex = levelIndex;
        LevelIdDict = new Dictionary<int, int>();
        Packages.ForEach(pack =>
        {
            pack.StartLevelIndex = levelIndex;
            pack.LevelIDs.ForEach(level =>
            {
                LevelIdDict.Add(levelIndex, level);
                levelIndex++;
            });
            pack.EndLevelIndex = levelIndex;
            LevelIdDict.Add(levelIndex, pack.CardLevelID);
            levelIndex++;
        });
        EndLevelIndex = levelIndex - 1;
        return levelIndex;
    }
}

public class ClassicPackage
{
    public int ID;
    public string Des1, Des2;
    public int CardPieceMode;
    public string CardID;
    public int CardLevelID;
    public List<int> LevelIDs;
    
    public int StartLevelIndex { get; set; }
    public int EndLevelIndex { get; set; }
    
    public KnowledgeCardEntity _CardEntity { get; set; }

    public bool ContainsLevel(int levelIndex)
    {
        return levelIndex >= StartLevelIndex && levelIndex <= EndLevelIndex;
    }
    
    public bool ContainsLevelID(int levelId)
    {
        return LevelIDs.Contains(levelId) || CardLevelID == levelId;
    }

    public int PieceCount => LevelIDs.Count + 1;

    public int GetLevelSerialNum(int levelID)//从1开始的碎片序号
    {
        return levelID - StartLevelIndex + 1;
        if (levelID == CardLevelID)
            return LevelIDs.Count + 1;
        for (int i = 0; i < LevelIDs.Count; i++)
        {
            if (LevelIDs[i] == levelID)
                return i + 1;
        }

        return -1;
    }
}