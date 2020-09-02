using System;
using UnityEngine.UI;
using BetaFramework ;
using UnityEngine;

public class FBSignInFailedDialog : UIWindowBase
{

    public override void OnOpen()
    {
        base.OnOpen();
        GC.Collect();
        Resources.UnloadUnusedAssets();
    }

    public void ClickClose()
    {
        if (!ResponseClick)
        {
            return;
        }
        AppEngine.SSDKManager.facebookSdk.OnLoginClick();
        UIManager.CloseUIWindow(this);
    }
}