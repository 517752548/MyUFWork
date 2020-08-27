using System;
using BetaFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFSMManager : StateMachine
{
    public const string Event_PlayAni = "PlayAni";
    public const string Event_PlayAniEnd = "PlayAniEnd";
    public const string Event_Popup = "Popup";
    public const string Event_PopupClose = "PopupClose";
    public const string Event_GuideClose = "GuideClose";
    public const string Event_GuideClose_Hint = "HintGuideClose";
    public const string Event_GuideClose_First = "FirstWordGuideClose";
    public const string Event_GuideClose_RateReward = "RateRewradGuideClose";

    protected BaseFSMState state_createScene, state_enterAni, state_guide, state_playing, state_exitAni, state_win;
    protected BaseCountState state_popup, state_aniPlay;

    public BaseGameManager GameManager { get; private set; }
    
    public virtual void Init(BaseGameManager m_baseGameManager)
    {
        this.GameManager = m_baseGameManager;
        InstantiateState();
        InitStateMachine();
    }

    protected abstract void InstantiateState();

    protected override void OnInit()
    {
        base.OnInit();

        AddHeadState(state_createScene);

        LinkState(state_createScene, state_enterAni);

        LinkState(state_enterAni, state_playing);

        LinkState(state_playing, state_guide);
        LinkState(state_playing, state_popup);
        LinkState(state_playing, state_aniPlay);
        LinkState(state_guide, state_aniPlay);
        //LinkState(state_guide, state_playing); 
        LinkState(state_popup, state_playing);
        LinkState(state_aniPlay, state_playing);
        LinkState(state_playing, state_exitAni);
        
        LinkState(state_exitAni, state_win);
    }

    public override void TriggerEvent(string eventName)
    {
        //LoggerHelper.Exception(new NotImplementedException("event " + eventName));
        base.TriggerEvent(eventName);
        switch(eventName)
        {
            case Event_PlayAni:
                if (currentState == state_aniPlay)
                {
                    state_aniPlay.AddCount();
                }
                else if (CurNextContain(state_aniPlay))
                {
                    SetState(state_aniPlay);
                }
                break;
            case Event_PlayAniEnd:
                if (currentState == state_aniPlay)
                {
                    state_aniPlay.ReduceCount();
                }
                break;
            case Event_Popup:
                if (currentState == state_popup)
                {
                    state_popup.AddCount();
                }
                else if (CurNextContain(state_popup))
                {
                    SetState(state_popup);
                }
                break;
            case Event_PopupClose:
                if (currentState == state_popup)
                {
                    state_popup.ReduceCount();
                }
                break;
            case Event_GuideClose:
                if (currentState == state_guide)
                {
                    Next();
                }
                break;
        }
    }

    public virtual void StartGame()
    {
        StartRun();
    }

    public virtual void EndGame()
    {
        SetState(state_exitAni);
    }

    public bool IsInPlayingState { get { return currentState == state_playing; } }
    
    public bool IsInGuideState { get { return currentState == state_guide; } }
}
