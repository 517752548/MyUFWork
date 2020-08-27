using System.Collections;
using System.Collections.Generic;
using Bag;
using BetaFramework;
using Scripts_Game.Controllers.Home.Elements;
using UnityEngine;

public class HomeGuideState : HomeState
{
    enum HomeGuide
    {
        none,
        BlogEnter,
        DailyEnter,
        Bee,
    }

    private HomeGuide guide = HomeGuide.none;
    
    public override bool CheckCondition()
    {
        guide = CheckToShowGuide();
        return guide != HomeGuide.none;
    }

    private HomeGuide CheckToShowGuide()
    {
        if (Const.AutoPlay)
        {
            return HomeGuide.none;
        }
        if (!AppEngine.SyncManager.Data.GuideBlogEnter.Value 
            && DataManager.PlayerData.KnowledgeCards.Value.allCards.Count >= 1 && AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value >= 14)
        {
            AppEngine.SyncManager.Data.GuideBlogEnter.Value = true;
            return HomeGuide.BlogEnter;
        }
        //每日挑战的引导暂时去掉
        // if (AppEngine.SyncManager.Data.ClassicLevel.Value >= Const.DailyUnlockLevel &&
        //     !AppEngine.SyncManager.Data.GuideDailyEnter.Value)
        // {
        //     return HomeGuide.DailyEnter;
        // }
        if (!AppEngine.SyncManager.Data.GuideBeeReward.Value 
            && AppEngine.SyncManager.Data.Bee.Value > 0)
        {
            AppEngine.SyncManager.Data.GuideBeeReward.Value = true;
            return HomeGuide.Bee;
        }
        
        return HomeGuide.none;
    }

    public override void Enter()
    {
        base.Enter();
        ShowGuide();
    }

    private void ShowGuide()
    {
        switch (guide)
        {
            case HomeGuide.BlogEnter:
                ShowBlogEnterGuide();
                break;
            case HomeGuide.DailyEnter:
                ShowDailyEnterGuide();
                break;
            case HomeGuide.Bee:
                ShowBeeGuide();
                break;
            default:
                OnCompleted();
                break;
        }
    }

    private void ShowBlogEnterGuide()
    {
        var target = new UILayerTarget(){target = HomeRoot.GetHomeUi<BlogEnter>().GetComponent<RectTransform>(), hasRaycaster = true};
        UIManager.OpenUIAsync(ViewConst.prefab_BlogEnterGui, null, 
            new GuideParam(target, OnGuideClickGot, OnGuideClose, null));
    }

    private void ShowDailyEnterGuide()
    {
        //var target = new UILayerTarget(){target = HomeRoot.GetHomeUi<DailyController>().GetComponent<RectTransform>(), hasRaycaster = true};
        // UIManager.OpenUIAsync(ViewConst.prefab_KnowledgeEnterGuideDialog, null, 
        //     new GuideParam(target, OnGuideClickGot, OnGuideClose, null));
        OnCompleted();
    }
    
    private void ShowBeeGuide()
    {
        var target = new UILayerTarget(){target = HomeRoot.GetHomeUi<LevelPlayButton>().beeCountBar.GetComponent<RectTransform>(), hasRaycaster = false};
        UIManager.OpenUIAsync(ViewConst.prefab_BeeHomeBtnGui, null, 
            new GuideParam(target, OnGuideClickGot, OnGuideClose, null));
    }

    public override void Leave()
    {
        base.Leave();
    }
    
    private void OnGuideClickGot()
    {
        //CheckGuide();
    }

    private void OnGuideClose()
    {
        OnCompleted();
    }
    
    private void OnUIClosed(UIWindowBase UI)
    {
        OnCompleted();
    }

    public override void Finish()
    {
        base.Finish();
        UIManager.CloseUIWindow(UIManager.UIStackManager.GetLastUI(UIType.Guide));
    }

    public override void HandleEvent(string eventName)
    {
        base.HandleEvent(eventName);
        
        switch(eventName)
        {
            case HomeFsmManager.Event_GuideClose:
                UIManager.CloseUIWindow(UIManager.UIStackManager.GetLastUI(UIType.Guide));
                break;
        }
    }
}