using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Managers;
using UnityEngine;

public class DailyWinDialog : UIWindowBase
{
    public Transform flyCoinPos;

    private int dailyRewardCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public override void OnOpen()
    {
        AppEngine.SSoundManager.BgmPause();
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_DailyWin);
        TimersManager.SetTimer(3, () =>
        {
            AppEngine.SSoundManager.BgmUnPause();
        });
        KeyEventManager.Instance.AddBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
        var cnfig = AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserPropConfig();
        for (int i = 0; i < cnfig.dataList.Count; i++)
        {
            if (cnfig.dataList[i].ID == "Daily")
            {
                dailyRewardCoin = cnfig.dataList[i].DefaultCount;
            }
        }
        TimersManager.SetTimer(2, () =>
        {
            UIManager.OpenUIAsync(ViewConst.prefab_DailyChallengeEventDialog);
            RewardMgr.RewardInventory(InventoryType.Coin, dailyRewardCoin, RewardSource.DailyWin);
        });
        RewardItem();
        CheckGuide();
    }


    private void RewardItem()
    {
        DailyRewardData dailyabconfig = AppEngine.SSystemManager.GetSystem<DailySystem>().GetDailyRewardConfig().GetDailyRewardMonthReward();
        int currentStar = AppEngine.SyncManager.Data.Stars.Value;
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            count += dailyabconfig.stars[i];
            if (count == currentStar)
            {
                RewardMgr.RewardInventoryWithSudId(InventoryType.Pet, dailyabconfig.pets[i], RewardSource.DailyStepReward0 + i);
                RewardMgr.RewardInventory(InventoryType.Coin, dailyabconfig.coins[i], RewardSource.DailyStepReward0 + i);
            }
        }
    }

    private void CheckGuide()
    {
        if (AppEngine.SyncManager.Data.Stars.Value > 0 
            && AppEngine.SSystemManager.GetSystem<GuideSystem>().GuideShown_DailyEnter.Value 
            && !AppEngine.SSystemManager.GetSystem<GuideSystem>().GuideShown_DailyReward.Value)
        {
            DataManager.ProcessData.showDailyGuide = true;
            AppEngine.SSystemManager.GetSystem<GuideSystem>().GuideShown_DailyReward.Value = true;
        }
    }
    public void ClickClaim()
    {
        
    }

}
