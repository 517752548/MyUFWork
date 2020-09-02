using System;
using BetaFramework;
using Scripts_Game.Managers;
using UnityEngine;
using Object = UnityEngine.Object;

public class HomeMessageState : BaseThemeMessageState
{
    protected HomeFsmManager HomeFsmManager => stateMachine as HomeFsmManager;
    protected HomeThemeRoot HomeRoot => (stateMachine as HomeFsmManager)?.homeRoot;
    
    class HomeMsg : BaseThemeMsg
    {
        public const int Unknown = 10;
    }

    protected override int CheckToShowMessage()
    {
        if (Const.AutoPlay)
        {
            return HomeMsg.none;
        }
        if (DataManager.FastRaceData.CanGetReward)
        {
            return HomeMsg.TournamentReward;
        }

        if (AppEngine.SyncManager.Data.ClassicLevel.IsChanged
            && AppEngine.SyncManager.Data.ClassicLevel.Value == 17)
        {
            AppEngine.SyncManager.Data.ClassicLevel.ResetLastValue();
            return HomeMsg.Rate;
        }

        if (AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().ShowFRWelcomePanel())
        {
            return HomeMsg.FastRace;
        }

        if (DataManager.businessGiftData.inited && DataManager.businessGiftData.needshowpanel == 1 && !DataManager.businessGiftData.AllGiftBuyed() && DataManager.businessGiftData.LevelEnough() && DataManager.businessGiftData.cutdownTime.Subtract(AppEngine.STimeHeart.RealTime).TotalSeconds > 0)
        {
            return HomeMsg.BusinessGiftPanel;
        }

        if (AppEngine.SSystemManager.GetSystem<EliteSystem>().CanShowNew() && DataManager.ProcessData.showEliteSystem == false)
        {
            DataManager.ProcessData.showEliteSystem = true;
            return HomeMsg.EliteNewLevel;
        }
        AppEngine.SyncManager.Data.ClassicLevel.ResetLastValue();
        return base.CheckToShowMessage();
    }

    protected override void ShowMessage()
    {
        switch (msgType)
        {
            case HomeMsg.Rate:
                UIManager.OpenUIAsync(ViewConst.prefab_OldRateDialog, OpenType.Stack, OnUIClosed);
                break;
            case HomeMsg.TournamentReward:
                AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().GetReward((ok) =>
                {
                    if (ok)
                    {
                        FastRaceDialog dialog = Object.FindObjectOfType<FastRaceDialog>();
                        if (dialog)
                        {
                            dialog.Close();
                        }

                        DataManager.FastRaceData.CanGetReward = false;
                        CommonRewardData _commonRewardData = new CommonRewardData();
                        _commonRewardData.boxType = RewardBoxType.FastRace;
                        _commonRewardData.RewardSource = RewardSource.FastRaceReward;
                        if (DataManager.FastRaceData.rewardID == (int)BatItem.Coin)
                        {
                            _commonRewardData.coin = DataManager.FastRaceData.rewardNum;
                        }
                        else if (DataManager.FastRaceData.rewardID == (int)BatItem.Hint1)
                        {
                            _commonRewardData.hint1 = DataManager.FastRaceData.rewardNum;
                        }
                        else if (DataManager.FastRaceData.rewardID == (int)BatItem.Hint2)
                        {
                            _commonRewardData.hint2 = DataManager.FastRaceData.rewardNum;
                        }
                        else if (DataManager.FastRaceData.rewardID == (int)BatItem.Hint3)
                        {
                            _commonRewardData.hint3 = DataManager.FastRaceData.rewardNum;
                        }
                        else if (DataManager.FastRaceData.rewardID == (int)BatItem.Hint4)
                        {
                            _commonRewardData.hint4 = DataManager.FastRaceData.rewardNum;
                        }
                        _commonRewardData.callback = () =>
                        {
                            Action callback = () => { OnUIClosed(null); };
                            TimersManager.SetTimer(0.5f,
                                () => { UIManager.OpenUIAsync(ViewConst.prefab_WeekRankListDialog, null, callback); });
                        };
                        UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, null, _commonRewardData);
                    }
                    else
                    {
                        DataManager.FastRaceData.CanGetReward = false;
                        OnUIClosed(null);
                    }
                });
                break;
            case HomeMsg.FastRace:
                UIManager.OpenUIAsync(ViewConst.prefab_WeekendPropagandaDialog, OpenType.Stack, OnUIClosed);
                break;
            case HomeMsg.EliteNewLevel:
                Action<bool> act = bo =>
                {
                    if (bo)
                    {
                        OnCompleted();
                        UIManager.OpenUIAsync(ViewConst.prefab_HappinessSelectLevelDialog);
                        HomeRootFsmManager.CheckRefresh(HomeRootTab.activity);
                    }
                    else
                    {
                        OnCompleted();
                    }
                };
                UIManager.OpenUIAsync(ViewConst.prefab_EliteLevelStartDialog,null,act);
                break;
            case HomeMsg.BusinessGiftPanel:
                UISimpleCallBack closeback = (ui) =>
                {
                    OnCompleted();
                };
                DataManager.businessGiftData.needshowpanel = 2;
                if (DataManager.businessGiftData.shopItem.Length == 1)
                {
                    UIManager.OpenUIAsync(ViewConst.prefab_ShopLimitBagOneDialog, OpenType.Stack, closeback);
                }
                else
                {
                    UIManager.OpenUIAsync(ViewConst.prefab_ShopLimitBagTwoDialog, OpenType.Stack, closeback);
                }
                break;
            default:
                base.ShowMessage();
                break;
        }
    }

    public override void Leave()
    {
        base.Leave();
    }

    public override void HandleEvent(string eventName)
    {
        base.HandleEvent(eventName);
    }
}