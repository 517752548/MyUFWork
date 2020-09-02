using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using Scripts_Game.Controllers.Cup;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.UI;

public class DailyWinDialog : UIWindowBase
{
    public Transform flyCoinPos;
    public CupCollectProgressBar cupBar;
    public Button continueBtn;

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
        RewardCup();
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
    
    private void RewardCup()
    {
        int cup = (int) objs[0];
        RewardMgr.RewardInventory(InventoryType.Cup, cup, RewardSource.DailyWin);
        cupBar.Show();
        cupBar.startBar.Show(cup);
    }

    public void OnFirstAniOver()
    {
        SetContinueBtn(false);
        cupBar.Fly(() => { SetContinueBtn(true); });
    }
    
    private void SetContinueBtn(bool enable)
    {
        continueBtn.interactable = enable;
        var cg = continueBtn.transform.GetChild(0).GetComponent<CanvasGroup>();
        cg.interactable = enable;
        cg.blocksRaycasts = enable;
        //cg.alpha
        cg.DOFade(enable ? 1f : 0f, 0.2f);
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
        AppEngine.SAdManager.ShowInterstitialByCondition(AdManager.InterstitialCallPlace.DailyLevelComplete,
            show =>
            {
                UIManager.CloseUIWindow(this);
                CommandBinder.DispatchBinding(GameEvent.RubyFly,
                    new RubyFlyCommand.RubyFlyData(RubyType.stack, flyCoinPos.position, 20));
                TimersManager.SetTimer(1.5f, () =>
                {
                    DailyChallengeEventDialog _DailyChallengeEventDialog = GameObject.FindObjectOfType<DailyChallengeEventDialog>();
                    if (_DailyChallengeEventDialog)
                    {
                        _DailyChallengeEventDialog.DoFlyAnimator();
                    }
                });
            });
    }

}
