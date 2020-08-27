using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class ClassicPopupState : BasePopupState
{
    enum GameMsg
    {
        none,
        BusGiftPanel
    }

    private GameMsg msg = GameMsg.none;

    public override bool CheckCondition()
    {
        if (Const.AutoPlay)
        {
            return false;
        }
        return base.CheckCondition();
    }

    public override void Enter()
    {
        base.Enter();
        ShowMessage();
        
    }

    private void ShowMessage()
    {
        switch (msg)
        {
            case GameMsg.BusGiftPanel:
                UICallBack closeback = OnUiClose;
                break;
        }
    }

    private void OnUiClose(UIWindowBase UI, params object[] objs)
    {
        Complete();
    }

    public override void Leave()
    {
        base.Leave();
    }
}