using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilitySystem : ISystem
{
    public Dictionary<string,ProbabilityPool_Data> probabilityDict = new Dictionary<string, ProbabilityPool_Data>();
    public override void InitSystem()
    {
        ProbabilityPool probabilities = PreLoadManager.GetPreLoadConfig<ProbabilityPool>(ViewConst.asset_ProbabilityPool_ProbabilityPool);
        for (int i = 0; i < probabilities.dataList.Count; i++)
        {
            probabilityDict.Add(probabilities.dataList[i].ID,probabilities.dataList[i]);
        }
        base.InitSystem();
    }


    /// <summary>
    /// 获取概率
    /// </summary>
    /// <returns></returns>
    public int GetProbability(string proID)
    {
        if (probabilityDict.ContainsKey(proID))
        {
            int max = probabilityDict[proID].GetMax();
            int randomIndex = Random.Range(1, max + 1);
            int LevelIndex = probabilityDict[proID].P1;
            if (randomIndex <= LevelIndex)
            {
                return 1;
            }
            LevelIndex += probabilityDict[proID].P2;
            if (randomIndex <= LevelIndex)
            {
                return 2;
            }
            LevelIndex += probabilityDict[proID].P3;
            if (randomIndex <= LevelIndex)
            {
                return 3;
            }
            LevelIndex += probabilityDict[proID].P4;
            if (randomIndex <= LevelIndex)
            {
                return 4;
            }
            LevelIndex += probabilityDict[proID].P5;
            if (randomIndex <= LevelIndex)
            {
                return 5;
            }
            LevelIndex += probabilityDict[proID].P6;
            if (randomIndex <= LevelIndex)
            {
                return 6;
            }
            LevelIndex += probabilityDict[proID].P7;
            if (randomIndex <= LevelIndex)
            {
                return 7;
            }
            LevelIndex += probabilityDict[proID].P8;
            if (randomIndex <= LevelIndex)
            {
                return 8;
            }

        }
        return 0;
    }
}
