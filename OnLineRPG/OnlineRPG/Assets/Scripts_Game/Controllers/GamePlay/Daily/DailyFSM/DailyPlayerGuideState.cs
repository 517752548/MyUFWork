using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DailyPlayerGuideState : BasePlayerGuideState
{
    enum DailyGuide
    {
        none
    }

    DailyGuide guide = DailyGuide.none;

    public override bool CheckCondition()
    {
        guide = CheckToShowGuide();
        return guide != DailyGuide.none;
    }

    private DailyGuide CheckToShowGuide()
    {
        return DailyGuide.none;
    }

    public override void Enter()
    {
        base.Enter();
        if (guide == DailyGuide.none)
        {
            guide = CheckToShowGuide();
            if (guide == DailyGuide.none)
            {
                OnCompleted();
                return;
            }
        }
        switch (guide)
        {
            case DailyGuide.none:
                break;
        }
    }

    public override void Leave()
    {
        if (guide != DailyGuide.none)
        {
            guide = DailyGuide.none;
            CloseCurrentGuide();
        }
        base.Leave();
    }

    private void OnGuideClickGot()
    {
        guide = DailyGuide.none;
        OnCompleted();
    }

    private void OnGuideClose()
    {
        if (guide != DailyGuide.none)
        {
            guide = DailyGuide.none;
            OnCompleted();
        }
    }

    public override void HandleEvent(string eventName)
    {
        base.HandleEvent(eventName);
    }
}
