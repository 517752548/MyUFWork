using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class ClassicEnterAnimationState : BaseEnterAnimationState
{
    public override void Enter()
    {
        base.Enter();
    }

    protected override IEnumerator EnterAnim()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.GetEntity<BaseSkillManager>().Appear();
        GameManager.GetEntity<ClassicCellManager>().PlayPreviewAni(() =>
        {
            int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
            ClassicLevelEntity   _classicLevelEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetClassicLevel(level);
            if (_classicLevelEntity.IsHardLevel)
            {
                UIManager.OpenUIAsync(ViewConst.prefab_ChallengeRabbit, (ui, para) =>
                {
                    TimersManager.SetTimer(0.8f, () =>
                    {
                        ui.Close();
                        OnCompleted();
                    });
                
                });
            }
            else
            {
                OnCompleted();
            }
            
            
        });
        yield return new WaitForSeconds(1.5f);
        //OnCompleted();
    }

    public override void Leave()
    {
        base.Leave();
    }
}
