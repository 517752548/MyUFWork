using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailDeleteDialog : UIWindowBase
{
   private ConstDelegate.PlayerSelect select;
    public override void OnOpen()
    {
        base.OnOpen();
        select = objs[0] as ConstDelegate.PlayerSelect;
    }

    public void Yes()
    {
        select?.Invoke(true);
        select = null;
        UIManager.CloseUIWindow(this);
    }

    public void No()
    {
        select?.Invoke(false);
        select = null;
        UIManager.CloseUIWindow(this);
    }
}
