using System.Collections.Generic;
using System.Linq;

public class ClassicWordLib : WordLib
{
    public int worldCount;
    public List<World> worldlist;

    public SubWorld GetSubWorldByIndex(int worldIndex, int subWorldIndex)
    {
        for (int i = 0; i < worldlist.Count; i++)
        {
            if (worldlist[i].index == worldIndex)
                return worldlist[i].GetSubWorldByIndex(subWorldIndex);
        }

        return null;
    }

    public GameLevel GetGameLevel(int worldIndex, int subWorldIndex, int levelIndex)
    {
        SubWorld subWorld = GetSubWorldByIndex(worldIndex, subWorldIndex);
        return subWorld == null ? null : subWorld.GetGameLevel(levelIndex);
    }

    public int GetWorldCount()
    {
        return worldlist.Count;
    }

    public int GetSubWorldCount()
    {
        return worldlist.Sum(t => t.subworldlist.Count);
    }

    public int GetGameLevelCount(int worldIndex, int subWorldIndex)
    {
        SubWorld subWorld = GetSubWorldByIndex(worldIndex, subWorldIndex);
        return subWorld == null ? 0 : subWorld.GetLevelCount();
    }

    public World GetWorldByIndex(int index)
    {
        return worldlist.Count > index ? worldlist[index] : null;
    }
}

//子世界信息
[System.Serializable]
public class SubWorldInfo
{
    public string worldName;
    public string mapColor;
    public string MapNum;
}

//子世界结构
//[System.Serializable]
public class SubWorld
{
    //记录当前第几个
    public int index;

    public List<GameLevel> gamelevellist = new List<GameLevel>();

    public SubWorld()
    {
    }

    public SubWorld(SubWordLayout subWordLayout)
    {
        //for (int i = 0; i < subWordLayout.Layouts.Count; i++)
        //{
        //    GameLevel answerLayout = new GameLevel(subWordLayout.Layouts[i]);
        //    gamelevellist.Add(answerLayout);
        //}
    }

    public int GetLevelCount()
    {
        return gamelevellist.Count;
    }

    public GameLevel GetGameLevel(int levelIndex)
    {
        return levelIndex < gamelevellist.Count ? gamelevellist[levelIndex] : null;
    }

    //最长字母
    private int m_MaxLetterLength = 0;

    public int MaxLetterLength
    {
        get
        {
            if (m_MaxLetterLength == 0)
            {
                for (int i = 0; i < gamelevellist.Count; i++)
                {
                    //int letterlen = gamelevellist[i].letter.Length;
                    //if (letterlen > m_MaxLetterLength)
                        //m_MaxLetterLength = letterlen;
                }
            }
            return m_MaxLetterLength;
        }
    }
}

//大世界结构
[System.Serializable]
public class World
{
    public int index;
    public List<SubWorld> subworldlist = new List<SubWorld>();

    public SubWorld GetSubWorldByIndex(int index)
    {
        return index < subworldlist.Count ? subworldlist[index] : null;
    }

    public int GetSubWordCount()
    {
        return subworldlist.Count;
    }

    public int GetLevelCount()
    {
        int levelCount = 0;
        for (int i = 0; i < subworldlist.Count; i++)
        {
            levelCount += subworldlist[i].GetLevelCount();
        }

        return levelCount;
    }
}

//经典玩法结构
[System.Serializable]
public class ClassicGameLevel : GameLevel
{
    public string bonusWords;
    public int cellType;
    public int starTag;
}