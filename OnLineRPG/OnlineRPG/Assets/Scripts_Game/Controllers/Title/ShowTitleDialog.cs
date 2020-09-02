using BetaFramework;
using EventUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ShowTitleDialog : UIWindowBase
{
    TitleReceiveData data;

    private List<TitleShowItem> list = new List<TitleShowItem>();

    public Transform parentContent;
    public PageView pageView;
    public ShowPetNavigation showPetNavigation;
    public override void OnOpen()
    {
        base.OnOpen();
        TitleData.isBrowsing = true;
        data = objs[0] as TitleReceiveData;
        initItemView();
    }

    private void initItemView()
    {
        Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_TitleShowItem).Completed += op =>
        {
            var title_data = TitleData.configList;
            Dictionary<int, TitleReceiveData> dictionary = TitleData.titleDic;
            bool islock = false;
            foreach (var item in title_data)
            {
                var obj = Instantiate(op.Result);
                TitleShowItem titleShowItem = obj.GetComponent<TitleShowItem>();
                titleShowItem.BindListener(this);
                islock = !dictionary.ContainsKey(item.id);
                titleShowItem.SetData(item, islock);
                titleShowItem.SetButtonStatus();
                obj.transform.SetParent(parentContent, false);
                list.Add(titleShowItem);
            }
            pageView.ContentChildCountChanged();
            showPetNavigation.bindNavigation();
            LoadSelectTitlePanel();
        };
    }
    //定位到选中item
    private void LoadSelectTitlePanel()
    {
        for (int i = 0; i < list.Count; i++)
        {
            var view = list[i];
            if (data.id== view.id)
            {
                showPetNavigation.pageTo(i);
            }
        }
    }
    public void callBackTitleStatus()
    {
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SetButtonStatus();
            }
        }
    }
    public void CloseWindow()
    {
        TitleData.isBrowsing = false;
        HomeRootFsmManager.GoIdle();
        EventDispatcher.TriggerEvent(GlobalEvents.RefreshTitleDialog);
        UIManager.CloseUIWindow(this);
    }
}
