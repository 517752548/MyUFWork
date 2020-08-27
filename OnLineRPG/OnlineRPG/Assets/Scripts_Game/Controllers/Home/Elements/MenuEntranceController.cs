﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using DG.Tweening;
using Scripts_Game.Controllers.Home;
 using Scripts_Game.Controllers.Home.Elements;
 using UnityEngine;

public class MenuEntranceController : BaseEntranceCtrl
{
    // public override void Init(HomeThemeRoot _homeRoot)
    // {
    //     base.Init(_homeRoot);
    // }

    protected override void UpdateBtnWeight(ref BaseEntranceBtn btn)
    {
        base.UpdateBtnWeight(ref btn);
        if (btn is BlogEnter)
        {
            btn.Weight = 10;
        }
    }

    public override void OnShow()
    {
        base.OnShow();
        //SortBtns();
    }


}