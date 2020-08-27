using BetaFramework;
using Scripts_Game.Controllers.Home.Elements;
using UnityEngine;

public class HomeGotBlogCardState : HomeState
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
        if (DataManager.PlayerData.KnowledgeCards.IsChanged && AppEngine.SyncManager.Data.ClassicLevel.IsChanged)
        {
            var pack = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>()
                .GetClassicPackage(AppEngine.SyncManager.Data.ClassicLevel.LastValue);
            HomeRoot.GetHomeUi<HomeThemeRoot>()._HomeAnimatorController.FlyBlogCard(pack._CardEntity.Image, () =>
            {
                DataManager.PlayerData.KnowledgeCards.ResetLastValue();
                HomeRoot.GetHomeUi<BlogEnter>().PlayHitAni(OnCompleted);
            });
        }
        else
            OnCompleted();
    }
}