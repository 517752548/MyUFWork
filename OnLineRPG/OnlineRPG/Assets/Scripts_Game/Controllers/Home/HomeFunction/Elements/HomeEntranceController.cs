using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using DG.Tweening;
using Scripts_Game.Controllers.Home;
using UnityEngine;

public class HomeEntranceController : BaseEntranceCtrl
{
    
    // public override void Init(HomeThemeRoot _homeRoot)
    // {
    //     base.Init(_homeRoot);
    // }
    
    protected override void UpdateBtnWeight(ref BaseEntranceBtn btn)
    {
        base.UpdateBtnWeight(ref btn);
        if (btn is FastRaceGameButton)
        {
            btn.Weight = DataManager.FastRaceData.RepFastRaceConfigPacketData == null ? 
                 9 : DataManager.FastRaceData.RepFastRaceConfigPacketData.order;
        }
        else if (btn is DailyOneWordEnter)
        {
            btn.Weight = 1;
        }
    }

    public override void OnShow()
    {
        base.OnShow();
        //SortBtns();
    }

}