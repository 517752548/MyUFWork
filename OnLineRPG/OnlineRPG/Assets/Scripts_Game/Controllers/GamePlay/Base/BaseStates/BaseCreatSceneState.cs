using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class BaseCreatSceneState : BaseFSMState
{

    public override void Enter()
    {
        base.Enter();
        GameManager.GetEntity<BaseKeyBoard>().Init();
        GameManager.GetEntity<ClassicVoiceKeyboard>().Init();
    }

    public override void Leave()
    {
        base.Leave();
        GameManager.ShowGameADVideo();
    }
}
