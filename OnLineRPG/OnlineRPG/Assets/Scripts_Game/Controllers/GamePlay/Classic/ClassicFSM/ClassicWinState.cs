using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class ClassicWinState : BaseWinState
{

    public override void Enter()
    {
        base.Enter();
        UIManager.OpenUIAsync(ViewConst.prefab_ClassicWinDialog);
    }

    public override void Leave()
    {
        base.Leave();
    }
}
