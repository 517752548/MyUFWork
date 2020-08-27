using BetaFramework;
using Scripts_Game.Controllers.Home.Elements;
using UnityEngine;

public class HomeFREffectState : HomeState
{
    public override bool CheckCondition()
    {
        return true;
    }

    public override void Enter()
    {
        base.Enter();
        if (Const.AutoPlay)
        {
            OnCompleted();
            return;
        }
        if (DataManager.FastRaceData.showButtonEffect)
        {
            FastRaceGameButton button =  ((HomeRoot) MainSceneDirector.Instance.GetUIRoot(GameUI.Home)).GetHomeUi<FastRaceGameButton>();
            if (button)
            {
                button.ShowStarEffect();
            }
        }
        OnCompleted();

        DataManager.FastRaceData.showButtonEffect = false;
    }
}