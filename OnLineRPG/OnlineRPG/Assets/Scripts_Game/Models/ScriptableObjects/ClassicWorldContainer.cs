using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ClassicWorldContainer : BaseSheet<ClassicWorldEntity>
{
    public string ABTestBISymbel;
    
    private int MaxLevel = 0;
    public void Load()
    {
        //第一关从1开始,这样subworld那第一关进度是0
        int levelIndex = 1;
        for (int i = 0; i < dataList.Count; i++)
        {
            levelIndex = dataList[i].WordLoad(levelIndex);
        }

        MaxLevel = levelIndex;
    }

    /// <summary>
    /// 有没有这一关卡
    /// </summary>
    /// <param name="index"></param>
    public bool HasLevel(int index)
    {
        if (index <= MaxLevel)
        {
            return true;
        }
        return false;
    }


    /// <summary>
    /// 根据当前关卡的绝对值获取对应关卡的world subworld 和 关卡文件
    /// </summary>
    /// <param name="level"></param>
    /// <param name="worldEntity"></param>
    /// <param name="subWorldEntity"></param>
    /// <param name="levelName"></param>
    public bool GetLevelInfo(int level, out ClassicWorldEntity worldEntity, out ClassicSubWorldEntity subWorldEntity, 
        out ClassicPackage packageEntity, out int levelID)
    {
        for (int i = 0; i < dataList.Count; i++)
        {
            for (int j = 0; j < dataList[i].SubWorldList.Count; j++)
            {
                if (dataList[i].SubWorldList[j].GetLevelIdDict().ContainsKey(level))
                {
                    worldEntity = dataList[i];
                    subWorldEntity = dataList[i].SubWorldList[j];
                    levelID = dataList[i].SubWorldList[j].GetLevelIdDict()[level];
                    packageEntity = dataList[i].SubWorldList[j].Packages.Find(pack => pack.ContainsLevel(level));
                    return true;
                }
            }
        }
        worldEntity = null;
        subWorldEntity = null;
        packageEntity = null;
        levelID = -1;
        return false;
    }
}
