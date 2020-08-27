using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetConnectFailed : UIWindowBase
{
    private ConstDelegate.NetErrorCallBack callBack;

    public override void OnOpen()
    {
        base.OnOpen();
        if (null != objs && objs.Length > 0)
            callBack = objs[0] as ConstDelegate.NetErrorCallBack;
    }

    public void ClickRetry()
    {
        UIManager.CloseUIWindow(this);
        if (callBack != null)
        {
            callBack.Invoke(0);
        }
    }

    public void ClickGotIt()
    {
        UIManager.CloseUIWindow(this);
        if (callBack != null)
        {
            callBack.Invoke(1);
        }
    }
}