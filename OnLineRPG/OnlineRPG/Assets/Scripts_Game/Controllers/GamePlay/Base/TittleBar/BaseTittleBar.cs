using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class BaseTittleBar : GameEntity
{
    private bool canClick = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickSetting()
    {
        if(!canClick)
            return;
        TimersManager.SetTimer(0.5f, () =>
        {
            canClick = true;
        });
        UIManager.OpenUIAsync(ViewConst.prefab_ClassicSettingDialog);
    }
}
