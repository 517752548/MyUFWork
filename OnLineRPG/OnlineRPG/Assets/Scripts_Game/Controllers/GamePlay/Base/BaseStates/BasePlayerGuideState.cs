using BetaFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasePlayerGuideState : BaseFSMState
{
    public override bool CheckCondition()
    {
        return false;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Leave()
    {
        base.Leave();
    }

    protected override void OnCompleted()
    {
        base.OnCompleted();
        stateMachine.TriggerEvent(BaseFSMManager.Event_PlayAni);
        Timer.Schedule(stateMachine, 0.5f, () => { stateMachine.TriggerEvent(BaseFSMManager.Event_PlayAniEnd); });
        //TimersManager.SetTimer(0.5f, () => { stateMachine.TriggerEvent(BaseFSMManager.Event_PlayAniEnd); });
    }

    protected void CloseCurrentGuide()
    {
        var ui = UIManager.UIStackManager.GetLastUI(UIType.Guide);
        ui.windowStatus = UIWindowBase.WindowStatus.Opened;
        UIManager.CloseUIWindow(ui);
    }
}
