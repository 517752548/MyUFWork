﻿using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class HomeFsmManager : BaseThemeFsmManager
{   
    public HomeThemeRoot homeRoot;

    private HomeState unlockWorld, sign;
    private HomeState subworld, fans, refresh, champion, blogCard,fastrace;
    
    public void Init (HomeThemeRoot homeRoot)
    {
        this.homeRoot = homeRoot;
        start = CreateState<HomeStartState>();
        guide = CreateState<HomeGuideState>();
        idle = CreateState<HomeIdleState>();
        unlockWorld = CreateState<HomeUnlockWorldState>();
        sign = CreateState<HomeSignState>();
        message = CreateState<HomeMessageState>();
        
        subworld = CreateState<HomeSubWorldBoxState>();
        fans = CreateState<HomeFansBoxState>();
        refresh = CreateState<HomeRefreshUIState>();
        champion = CreateState<HomeChampionBoxState>();
        blogCard = CreateState<HomeGotBlogCardState>();
        fastrace = CreateState<HomeFREffectState>();
        InitStateMachine();
    }

    protected override void OnInit()
    {
        base.OnInit();
        BreakLinkState(start, idle);
        LinkState(start, subworld);
        LinkState(subworld, fans);
        LinkState(fans, blogCard);
        LinkState(blogCard, unlockWorld);
        LinkState(unlockWorld, fastrace);
        LinkState(fastrace,refresh);
        LinkState(refresh, champion);
        LinkState(champion, idle);
        LinkState(idle, sign);
        LinkState(sign, idle);

        autoStart = false;
    }

    public override void OnEnter()
    {
        EventUtil.EventDispatcher.AddEventListener<string>(GlobalEvents.OpenUI, OnOpenUI);
        EventUtil.EventDispatcher.AddEventListener<string>(GlobalEvents.CloseUI, OnCloseUI);
    }
    
    public override void OnLeave()
    {
        EventUtil.EventDispatcher.RemoveEventListener<string>(GlobalEvents.OpenUI, OnOpenUI);
        EventUtil.EventDispatcher.RemoveEventListener<string>(GlobalEvents.CloseUI, OnCloseUI);
    }

    private void RefreshState()
    {
        TriggerEvent(Event_CheckRefresh);
    }
    
    private void OnOpenUI(string uiname)
    {
        if (uiname == ViewConst.prefab_KnowledgeCardDialog)
        {
            TriggerEvent(Event_Popup);
        }
    }

    private void OnCloseUI(string uiname)
    {
        if (uiname == ViewConst.prefab_KnowledgeCardDialog)
        {
            TriggerEvent(Event_PopupClose);
        }
    }

    public void BanClick(bool ban)
    {
        homeRoot.SetGraphicRaycasterEnable(!ban);
    }

    public override void TriggerEvent(string eventName)
    {
        base.TriggerEvent(eventName);
    }
    
}

public class HomeState : BaseState
{
    protected HomeFsmManager HomeFsmManager => stateMachine as HomeFsmManager;
    protected HomeThemeRoot HomeRoot => (stateMachine as HomeFsmManager)?.homeRoot;
}
