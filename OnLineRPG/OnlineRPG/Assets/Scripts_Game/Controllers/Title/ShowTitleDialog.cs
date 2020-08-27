using BetaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ShowTitleDialog : UIWindowBase
{
    TitleReceiveData data;
    TitleData titledata;
    private List<TitleShowItem> list = new List<TitleShowItem>();

    public Transform parentContent;
    public PageView pageView;
    public ShowPetNavigation showPetNavigation;
    public override void OnOpen()
    {
        base.OnOpen();
        data = objs[0] as TitleReceiveData;


        titledata = AppEngine.SyncManager.Data.Titles.Value;
        initItemView();
    }

    private void initItemView()
    {
        Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_TitleShowItem).Completed += op =>
        {
            TitleConfig title_data = WebConfigMgr.Get<TitleConfig>();
            Dictionary<int, int> dictionary = titledata.titleDic;
            foreach (var item in title_data.data)
            {
                var obj = Instantiate(op.Result);
                TitleShowItem titleShowItem = obj.GetComponent<TitleShowItem>();
                titleShowItem.BindListener(this);
                foreach (var owend in dictionary.Keys)
                {
                    if (item.id == owend)
                    {
                        titleShowItem.SetData(data, false);
                    }
                    else
                    {
                        titleShowItem.SetData(data, true);
                    }
                }
                titleShowItem.SetButtonStatus();
                obj.transform.SetParent(parentContent, false);
                list.Add(titleShowItem);
            }
            pageView.ContentChildCountChanged();
            showPetNavigation.bindNavigation();
            LoadSelectPetPanel();
        };
    }
    //定位到选中item
    private void LoadSelectPetPanel()
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
    public void callBackPetStatus()
    {
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SetButtonStatus();
            }
        }
    }
}
