using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class ClassicWorldEntity : ScriptableObject
{
    public int ID;
    public string Name;
//    public Sprite ImageStart;
    public int WorldState;
//    public Sprite ImageEnd;
    public string StoryEnd;
    public string SubWorldListString;
    public string HomeImage;
    public string HomeSmall;
    public string HomeMusic;
    public string BGMusic;
    private List<ClassicSubWorldEntity> _SubWorldList;
    private int startLevel = 0;
    private int endLevel = 0;
    public List<ClassicSubWorldEntity> SubWorldList
    {
        get
        {
            if (_SubWorldList == null)
            {
                _SubWorldList = JsonConvert.DeserializeObject<List<ClassicSubWorldEntity>>(SubWorldListString);
                if (_SubWorldList == null)
                {
                    _SubWorldList = new List<ClassicSubWorldEntity>();
                }
            }

            return _SubWorldList;
        }
    }

    public ClassicSubWorldEntity GetSubworld(int id)
    {
        return SubWorldList.Find(sw => sw.ID == id);
    }

    public int WordLoad(int index)
    {
        int levelIndex = index;
        startLevel = index;
        if (WorldState == 0)
        {
            levelIndex = levelIndex + 40;
        }
        else
        {
            for (int i = 0; i < SubWorldList.Count; i++)
            {
                levelIndex = SubWorldList[i].SubWorldLoad(levelIndex);
            } 
        }
        
        endLevel = levelIndex - 1;
        
        return levelIndex;
    }

    /// <summary>
    /// 获取关卡区间
    /// </summary>
    /// <returns></returns>
    public int[] GetLevelRegion()
    {
        return new[] {startLevel, endLevel};
    }
    
    public bool ContainLevel(int level)
    {
        if (startLevel <= level && endLevel >= level)
        {
            return true;
        }

        return false;
    }
}
