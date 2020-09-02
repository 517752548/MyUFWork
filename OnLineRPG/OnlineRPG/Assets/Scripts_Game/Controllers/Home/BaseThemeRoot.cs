using System;
using BetaFramework;
using Scripts_Game.Managers;
using Object = UnityEngine.Object;

public class BaseThemeRoot : BaseHomeUI {
    public BaseThemeFsmManager fsmManager;

    public virtual bool IsIdle()
    {
        return fsmManager.IsIdle();
    }

    public override void OnShow()
    {
        fsmManager.OnUIShow();
        base.OnShow();
    }

    public override void OnHidden()
    {
        base.OnHidden();
        fsmManager.OnUIHide();
    }

    public override void OnEnter()
    {
        fsmManager.OnEnter();
        base.OnEnter();
    }

    public override void OnLeave()
    {
        base.OnLeave();
        fsmManager.OnLeave();
    }
}

public class BaseThemeFsmManager : StateMachine
{
    public const string Event_CheckRefresh = "checkRefresh";
    public const string Event_Popup = "Popup";
    public const string Event_PopupClose = "PopupClose";
    public const string Event_GuideClose = "GuideClose";

    protected BaseState start, guide, idle, message;
    private BaseThemePopupState popup;

    public override void InitStateMachine()
    {
        popup = CreateState<BaseThemePopupState>();
        base.InitStateMachine();
    }

    protected override void OnInit()
    {
        base.OnInit();
        AddHeadState(start);
        LinkState(start, idle);
        LinkState(idle, guide);
        LinkState(guide, popup);
        LinkState(guide, idle);
        LinkState(idle, message);
        LinkState(message, idle);
        LinkState(idle, popup);
        LinkState(popup, idle);
    }

    public override void Next()
    {
        bool fromIdle = currentState == idle;
        base.Next();
        if (fromIdle && currentState == idle)
            HomeRootFsmManager.GoIdle();
    }

    public virtual bool IsIdle()
    {
        return IsCurrentState(idle);
    }

    public virtual void OnUIShow()
    {
        currentState = null;
    }
    
    public virtual void OnUIHide()
    {
        
    } 
    
    public virtual void OnEnter()
    {
        
    }
    
    public virtual void OnLeave()
    {
        
    }

    public override void TriggerEvent(string eventName)
    {
        base.TriggerEvent(eventName);
        switch(eventName)
        {
            case Event_CheckRefresh:
                if (IsCurrentState(idle))
                    idle.Complete();
                break;
            case Event_Popup:
                if (currentState == popup)
                {
                    popup.AddCount();
                }
                else if (CurNextContain(popup))
                {
                    currentState.Finish();
                    SetState(popup);
                }
                break;
            case Event_PopupClose:
                if (currentState == popup)
                {
                    popup.ReduceCount();
                }
                break;
        }
    }
}

public class BaseThemePopupState : BaseState
{
    private int count = 0;
    
    public override bool CheckCondition()
    {
        if (Const.AutoPlay)
        {
            return false;
        }
        return false;
    }
    
    public override void Enter()
    {
        count = 0;
        base.Enter();
        AddCount();
    }

    public override void Leave()
    {
        base.Leave();
        count = 0;
    }

    public virtual void AddCount()
    {
        count++;
    }

    public virtual void ReduceCount()
    {
        count--;
        if (count == 0)
        {
            OnCompleted();
        }
    }
}

public class BaseThemeMessageState : BaseState
{
    protected class BaseThemeMsg
    {
        public const int none = 0;
        public const int Rate = 1;
        public const int TournamentReward = 2;
        public const int FastRace = 3;
        public const int BusinessGiftPanel = 4;
        public const int EliteNewLevel = 5;
    }

    protected int msgType = 0;

    public override bool CheckCondition()
    {
        msgType = CheckToShowMessage();
        return msgType != BaseThemeMsg.none;
    }

    protected virtual int CheckToShowMessage()
    {
        if (Const.AutoPlay)
        {
            return BaseThemeMsg.none;
        }
        if (DataManager.FastRaceData.CanGetReward)
        {
            return BaseThemeMsg.TournamentReward;
        }

        if (AppEngine.SyncManager.Data.ClassicLevel.IsChanged
            && AppEngine.SyncManager.Data.ClassicLevel.Value == 17)
        {
            AppEngine.SyncManager.Data.ClassicLevel.ResetLastValue();
            return BaseThemeMsg.Rate;
        }

        if (AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().ShowFRWelcomePanel())
        {
            return BaseThemeMsg.FastRace;
        }

        if (DataManager.businessGiftData.inited 
            && DataManager.businessGiftData.needshowpanel == 1 
            && !DataManager.businessGiftData.AllGiftBuyed() 
            && DataManager.businessGiftData.LevelEnough() 
            && DataManager.businessGiftData.cutdownTime.Subtract(AppEngine.STimeHeart.RealTime).TotalSeconds > 0)
        {
            return BaseThemeMsg.BusinessGiftPanel;
        }

        return BaseThemeMsg.none;
    }

    public override void Enter()
    {
        base.Enter();
        ShowMessage();
    }

    protected virtual void ShowMessage()
    {
        switch (msgType)
        {
            case BaseThemeMsg.Rate:
                UIManager.OpenUIAsync(ViewConst.prefab_OldRateDialog, OpenType.Stack, OnUIClosed);
                break;
            case BaseThemeMsg.TournamentReward:
                //展示锦标赛奖励弹板
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
            case BaseThemeMsg.FastRace:
                UIManager.OpenUIAsync(ViewConst.prefab_WeekendPropagandaDialog, OpenType.Stack, OnUIClosed);
                break;
            case BaseThemeMsg.BusinessGiftPanel:
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
                OnCompleted();
                break;
        }
    }

    protected void OnUIClosed(UIWindowBase UI)
    {
        OnCompleted();
    }
}