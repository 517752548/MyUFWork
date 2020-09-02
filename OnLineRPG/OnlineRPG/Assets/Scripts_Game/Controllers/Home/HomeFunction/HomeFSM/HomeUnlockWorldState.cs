using BetaFramework;
using UnityEngine;

public class HomeUnlockWorldState : HomeState
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
        //if (HomeRoot.CurrentWorld.WorldState == 1)
        {
            if (DataManager.PlayerData.CurClassicWorldID.Value > 0)
            {
                if (DataManager.PlayerData.CurClassicWorldID.Value != HomeRoot.CurrentWorld.ID)
                {
                    DataManager.PlayerData.CurClassicWorldID.Value = HomeRoot.CurrentWorld.ID;
                    if (DataManager.ProcessData.NotShowWorldUnlock)
                    {
                        DataManager.ProcessData.NotShowWorldUnlock = false;
                        OnWorldUnlock();
                        return;
                    }
                
                    UIManager.OpenUIAsync(ViewConst.prefab_EpisodeUnlockDialog, OpenType.Over, 
                        ui => { OnWorldUnlock(); }, null, null,
                        HomeRoot.CurrentWorld.Name, HomeRoot.CurrentWorld.HomeSmall, null);
                
                    return;
                }
            }
            else
            {
                DataManager.PlayerData.CurClassicWorldID.Value = HomeRoot.CurrentWorld.ID;
            }
            //AppEngine.SSystemManager.GetSystem<ChampionChallengeSystem>().OnNewWorldUpdated();
        }
        OnCompleted();
    }

    private void OnWorldUnlock()
    {
        HomeRoot._bgcontroller.ChangeBG(HomeRoot.CurrentWorld.HomeImage);
        OnCompleted();
    }
}