using System.Collections;
using System.Collections.Generic;
using Data.Request;
using Newtonsoft.Json;
using UnityEngine;

public class CellTipABSystem : ISystem
{

    private RecordExtra.StringPrefData CellTipAB;
    public override void InitSystem()
    {
        CellTipAB = new RecordExtra.StringPrefData(PrefKeys.CellTipAB,"X");
        OnCompleted();
    }
    

    public string GetUserRewardLib()
    {
        if (CellTipAB == null || CellTipAB.Value.Equals("X"))
        {
            UserEnterGame();
        }
        return CellTipAB.Value;
    }
    
    /// <summary>
    /// 设置一个词库的ab，如果这个词库已经被设置了，则不会被再设置
    /// </summary>
    /// <param name="testAB"></param>
    public void SetRewardAB(string testAB)
    {
        if (CellTipAB != null && CellTipAB.Value.Equals("X") && (testAB.Equals("A") || testAB.Equals("B")))
        {
            CellTipAB.Value = testAB;
        }
    }
    
    public void DebugSetRewardAB(string testAB)
    {
        if (CellTipAB != null && (testAB.Equals("A") || testAB.Equals("B")))
        {
            CellTipAB.Value = testAB;
        }
    }
    
    /// <summary>
    /// 如果读条完毕，但是玩家还没有被设置AB，则直接设置一个随机AB
    /// </summary>
    public void UserEnterGame()
    {
        if (CellTipAB.Value.Equals("X"))
        {
            SetRewardAB("B");
            return;
            int id = UnityEngine.Random.Range(0, 1001);
            if (id <= 500)
            {
                SetRewardAB("A");
            }
            else
            {
                SetRewardAB("B");
            }
        }
    }

    public bool CellTipEnable => GetUserRewardLib().Equals("A");
}
