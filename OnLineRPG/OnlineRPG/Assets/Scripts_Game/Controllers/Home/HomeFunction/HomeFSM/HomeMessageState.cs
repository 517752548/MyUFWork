using System;
using BetaFramework;
using Scripts_Game.Managers;
using UnityEngine;
using Object = UnityEngine.Object;

public class HomeMessageState : HomeState
{
    enum HomeMsg
    {
        none,
        Rate,
        TournamentReward,
        FastRace,
    }

    private HomeMsg msg = HomeMsg.none;

    public override bool CheckCondition()
    {
        msg = CheckToShowMessage();
        return msg != HomeMsg.none;
    }

    private HomeMsg CheckToShowMessage()
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
        

        AppEngine.SyncManager.Data.ClassicLevel.ResetLastValue();
        return HomeMsg.none;
    }

    public override void Enter()
    {
        base.Enter();
        ShowMessage();
    }

    private void ShowMessage()
    {
        switch (msg)
        {
            case HomeMsg.Rate:
                UIManager.OpenUIAsync(ViewConst.prefab_OldRateDialog, OpenType.Stack, OnUIClosed);
                break;
            case HomeMsg.TournamentReward:
                //TODO 展示锦标赛奖励弹板
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
            default:
                OnCompleted();
                break;
        }
    }

    public override void Leave()
    {
        base.Leave();
    }

    private void OnUIClosed(UIWindowBase UI)
    {
        OnCompleted();
    }

    public override void HandleEvent(string eventName)
    {
        base.HandleEvent(eventName);
    }
}