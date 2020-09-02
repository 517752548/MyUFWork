using BetaFramework;
using Scripts_Game.Controllers.Home.Elements;
using UnityEngine;

public class HomeChampionBoxState : HomeState
{
    public override bool CheckCondition()
    {
        return true;
    }

    public override void Enter()
    {
        base.Enter();
        OnCompleted();
        // if (HomeRoot.CurrentWorld.WorldState == 0 &&
        //     AppEngine.SSystemManager.GetSystem<ChampionChallengeSystem>().SectionLevelProgress.IsChanged)
        // {

        //     HomeRoot.GetHomeUi<HomeSceneController>()._HomeAnimatorController.FlyLevel(() =>
        //     {
        //         HomeRoot.GetHomeUi<ChampionBoxPanel>().PlayProgressAni(OnCompleted);
        //     });
        // }
        // else
        //     OnCompleted();
    }
}