using UnityEngine;
using BetaFramework;
using EventUtil;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class HomeRootFsmManager : StateMachine
{
    public const string HRFSMtoHome = "HRFSMtoHome";
    public const string HRFSMtoShop = "HRFSMtoShop";
    public const string HRFSMtoDecoration = "HRFSMtoDecoration";
    public const string HRFSMtoActivity = "HRFSMtoActivity";
    public const string HRFSMtoRank = "HRFSMtoRank";
    /// <summary>
    /// 执行完任务调用,当前状态机已经空闲
    /// </summary>
    public const string Event_Idle = "Event_Idle";
    private HomeRootBaseState home, shop, decoration, activity, rank;
    public HomeRoot homeRoot;
    private Queue<(HomeRootTab, string)> eventQueue;
    public void Init(HomeRoot homeRoot)
    {
        this.homeRoot = homeRoot;
        eventQueue = new Queue<(HomeRootTab, string)>();
        home = CreateState<HomeRootHomeState>();
        shop = CreateState<HomeRootShopState>();
        decoration = CreateState<HomeRootDecorationState>();
        activity = CreateState<HomeRootActivityState>();
        rank = CreateState<HomeRootRankState>();

        InitStateMachine();
    }
    protected override void OnInit()
    {
        base.OnInit();
        AddHeadState(home);
    }

    private void RefreshState(HomeRootTab tab, string evt)
    {
        //查看当前root
        if (homeRoot.GetCurrentShowRoot().IsIdle() == false)
        {
            //当前root正在忙碌
            Debug.LogError($"当前页签 ${homeRoot.GetCurrentShowRoot()} 正在忙");
            eventQueue.Enqueue((tab, evt));
            return;
        }
        // if (currentState != idle)
        // {
        //     Debug.LogError($"homeroot 正在忙{currentState}");
        //     eventQueue.Enqueue((tab, evt));
        //     return;
        // }
        if (string.Equals(evt, Event_Idle))
        {//查看队列
            if (eventQueue.Count > 0)
            {
                var topItem = eventQueue.Dequeue();
                tab = topItem.Item1;
                evt = topItem.Item2;
            }
            else
            {
                // Debug.LogError("eventqueue 是空");
                return;
            }
        }
        switch (tab)
        {
            case HomeRootTab.home:
                {
                    homeRoot.MoveTo(tab, false);
                    homeRoot.GetHomeUi<HomeThemeRoot>().HomeFsmManager.TriggerEvent(evt);
                    break;
                }
            case HomeRootTab.shop:
                // Debug.LogError($"成功发送 {tab} 消息");
                homeRoot.MoveTo(tab, false);
                homeRoot.GetHomeUi<ShopThemeRoot>().fsmManager.TriggerEvent(evt);
                break;
            case HomeRootTab.decoration:
                homeRoot.MoveTo(tab, false);
                homeRoot.GetHomeUi<DecorationThemeRoot>().fsmManager.TriggerEvent(evt);
                break;
            case HomeRootTab.activity:
                homeRoot.MoveTo(tab, false);
                homeRoot.GetHomeUi<ActivityThemeRoot>().fsmManager.TriggerEvent(evt);
                break;
            case HomeRootTab.rank:
                homeRoot.MoveTo(tab, false);
                homeRoot.GetHomeUi<RankThemeRoot>().fsmManager.TriggerEvent(evt);
                break;
            case HomeRootTab.root:
                TriggerEvent(evt);
                break;
            default: break;
        }
    }

    public override void TriggerEvent(string eventName)
    {
        base.TriggerEvent(eventName);
        switch (eventName)
        {
            case HRFSMtoHome:
                {
                    currentState?.Finish();
                    SetState(home);
                    break;
                }
            case HRFSMtoDecoration:
                {
                    currentState?.Finish();
                    SetState(decoration);
                    break;
                }
            case HRFSMtoShop:
                {
                    currentState?.Finish();
                    SetState(shop);
                    break;
                }
            case HRFSMtoActivity:
                {
                    currentState?.Finish();
                    SetState(activity);
                    break;
                }
            case HRFSMtoRank:
                {
                    currentState?.Finish();
                    SetState(rank);
                    break;
                }
        }
    }

    public void Enter()
    {
        StartRun();
        EventDispatcher.AddEventListener<HomeRootTab, string>(GlobalEvents.TriggerHomeRootFsm, RefreshState);
    }

    public void Leave()
    {
        EventDispatcher.RemoveEventListener<HomeRootTab, string>(GlobalEvents.TriggerHomeRootFsm, RefreshState);
    }

    /// <summary>
    /// 检测刷新，看看当前是否有弹板或引导
    /// </summary>
    /// <param name="tab">哪个页签 shop\home\rank ...</param>
    public static void CheckRefresh(HomeRootTab tab = HomeRootTab.home)
    {
        EventDispatcher.TriggerEvent(GlobalEvents.TriggerHomeRootFsm, tab, HomeFsmManager.Event_CheckRefresh);
    }
    /// <summary>
    /// 向root状态机发消息
    /// /// </summary>
    /// <param name="tab">要切换的页签</param>
    /// <param name="evt">事件名 如 Event_CheckRefresh,Event_Popup,Event_CompleteCurState</param>
    public static void GiveMessage(string evt = HomeFsmManager.Event_CheckRefresh, HomeRootTab tab = HomeRootTab.home)
    {
        EventDispatcher.TriggerEvent(GlobalEvents.TriggerHomeRootFsm, tab, evt);
    }
    public static void GoIdle()
    {
        EventDispatcher.TriggerEvent(GlobalEvents.TriggerHomeRootFsm, HomeRootTab.home, Event_Idle);
    }
}