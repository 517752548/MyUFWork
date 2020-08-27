using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class WorldMap : UIWindowBase
{
    public Transform content;
    public Transform centPos;

    public ScrollRect _ScrollRect;


    private DateTime timecd;
    private bool canGoToTarget = false;
    private bool animGoToTarget = false;
    WorldMapItem _worldMapItem = null;

    public override void OnOpen()
    {
        base.OnOpen();
        _ScrollRect.enabled = false;
        timecd = DateTime.Now;
        CreatMap();
    }

    private async void CreatMap()
    {
        ClassicWorldContainer classicWorldContainer =
            AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetClassicWorldContainer();
        int index = 0;
        AsyncOperationHandle<GameObject> worldMapHandler =
            Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_WorldMapItem);
        await worldMapHandler.Task;
        GameObject worldMapItem = null;
        bool showBottom = true;

        for (int i = classicWorldContainer.dataList.Count - 1; i >= 0; i--)
        {
            worldMapItem = Instantiate(worldMapHandler.Result, content, false);
            if (i == 0)
            {
                showBottom = false;
            }
            else
            {
                showBottom = true;
            }

            bool locked = worldMapItem.GetComponent<WorldMapItem>()
                .SetData(classicWorldContainer.dataList[i], showBottom);
            if (locked)
            {
                index++;
            }
            else
            {
                if (_worldMapItem == null)
                    _worldMapItem = worldMapItem.GetComponent<WorldMapItem>();
            }
        }

        StartCoroutine(MoveToTargetPos(_worldMapItem));
    }


    public IEnumerator MoveToTargetPos(WorldMapItem _worldMapItem)
    {
        if (_worldMapItem != null)
        {
            if (canGoToTarget)
            {
                canGoToTarget = false;
                yield return MoveToTarget();
            }
            else
            {
                animGoToTarget = true;
            }
        }
    }

    private IEnumerator MoveToTarget()
    {
        yield return new WaitForEndOfFrame();
        float ydistance = _worldMapItem.transform.position.y - centPos.position.y;
        float targety = content.transform.position.y - ydistance;
        content.DOMoveY(targety, 0f);
        yield return new WaitForSeconds(0.1f);
        _ScrollRect.enabled = true;
    }

    public void MoveScrollView()
    {
        canGoToTarget = true;
        if (animGoToTarget)
        {
            StartCoroutine(MoveToTarget());
        }
    }

    public void CloseClick()
    {
        UIManager.CloseUIWindow(this);
    }
}