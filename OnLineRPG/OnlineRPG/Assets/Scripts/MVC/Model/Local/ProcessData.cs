using System;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Managers;
using UnityEngine;

public class ProcessData
{
    public void Initilize()
    {
        isRestore = true;
        TimersManager.SetTimer(3, () =>
        {
            isRestore = false;
        });
    }

    public bool firstGoToGameScene = false;
    public bool cancelFirstGoToGameScene = false;
    public bool firstOpenKnowledge = true;
    public string tempFBInfo = "";
    public bool showDailyGuide = false;
    public bool voiceMicPressDown = false;
	/// <summary>
	/// 等待授权期间使用
	/// </summary>
    public bool GuideShown_GuideVoice2NotShow = false;
    //上线5s之内的购买都应该是restore
    public bool isRestore = false;

    public GameMode _GameMode = GameMode.Classic;

    public BaseWord CanShowRateRewardWord = null;
    public bool CanShowRateRewardStep2 = false;
    public bool IgnoreBackInterstitial = false;
    public bool playDailyOpenAnim = true;
#if UNITY_EDITOR
    public int oldRank = -1;
#else
    public int oldRank = -1;
#endif
    
    public bool NotShowWorldUnlock = false;
    public RewardSource advideosource = RewardSource.closeShopAD;

}