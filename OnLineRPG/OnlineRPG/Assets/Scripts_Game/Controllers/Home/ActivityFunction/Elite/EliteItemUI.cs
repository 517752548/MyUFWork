using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;

public class EliteItemUI : BaseHomeUI
{
    public GameObject New;
    public TextMeshProUGUI tittle;
    public TextMeshProUGUI des;
    public GameObject lockobj;
    private EliteWorld eliteWorld;

    private void Start()
    {
        eliteWorld = AppEngine.SSystemManager.GetSystem<EliteSystem>().GetLastSubWorld();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        //tittle.text = string.Format("The {0}ST Turn!",AppEngine.SSystemManager.GetSystem<EliteSystem>().GetTotalSubworld());
        des.text = string.Format("Vol.{0} has been released",
            AppEngine.SSystemManager.GetSystem<EliteSystem>().GetTotalSubworld());
        int currentLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        if (AppEngine.SSystemManager.GetSystem<EliteSystem>().GetUnLockLevel() <= currentLevel)
        {
            lockobj.SetActive(false);
        }
        else
        {
            lockobj.SetActive(true);
        }
        if (AppEngine.SSystemManager.GetSystem<EliteSystem>().CanShowNew())
        {
            New.SetActive(true);
        }
        else
        {
            New.SetActive(false);
        }
        
    }

    public void ClickItem()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_MagazineListDialog);
    }
}
