using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using EventUtil;
using UnityEngine;

public class EventItemUI : BaseHomeUI
{
    public Transform ItemContent;
    private GameObject EliteItemPrefab;

    private void Start()
    {
        EventDispatcher.AddEventListener(GlobalEvents.EliteConfigLoad,OnLoadEliteConfig);
        OnLoadEliteConfig();
    }

    /// <summary>
    /// 开局先执行一次  之后的监听回调
    /// </summary>
    private void OnLoadEliteConfig()
    {
        if (AppEngine.SSystemManager.GetSystem<EliteSystem>().CanShowEliteUI())
        {
            if (EliteItemPrefab == null)
            {
                ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_EliteItem, op =>
                {
                    EliteItemPrefab = Instantiate(op,ItemContent,false);
                    childHomeUIs.Add(EliteItemPrefab.GetComponent<BaseHomeUI>());
                    
                });
            }
            
        }
        else
        {
            if (EliteItemPrefab != null)
            {
                Destroy(EliteItemPrefab);
            }
        }
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnShow()
    {
        base.OnShow();
    }
    
}
