using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class ClassicCreatSceneState : BaseCreatSceneState
{

    public override void Enter()
    {
        base.Enter();
        CreatScene();
    }
    

    private void CreatScene()
    {
        int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        GameManager.GetEntity<ClassicTittleBar>().Init();
        GameManager.GetEntity<ClassicCellManager>().Init();
        GameManager.GetEntity<ClassicSkillManager>().Init();
        GameManager.GetEntity<ClassicQuestionRate>().Init(level);
        OnCompleted();
    }
    
    public override void Leave()
    {
        base.Leave();
    }
}
