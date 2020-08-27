using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class DailyCreatSceneState : BaseCreatSceneState
{

    public override void Enter()
    {
        base.Enter();
        CreatScene();
    }
    
    private void CreatScene()
    {
        Debug.LogError("创建场景");
        //fsmManager.m_baseGameManager.GetEntity<DailyTittleBar>().Init();
        GameManager.GetEntity<DailyCellManager>().Init();
        GameManager.GetEntity<DailySkillManager>().Init();
        GameManager.BanClick(true);
        OnCompleted();
    }
    
    public override void Leave()
    {
        base.Leave();
    }
}
