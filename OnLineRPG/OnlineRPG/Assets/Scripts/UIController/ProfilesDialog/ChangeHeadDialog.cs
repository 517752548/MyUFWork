using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHeadDialog : UIWindowBase
{
    public GameObject ItemPrefab;

    public ToggleGroup toggleGroup;

    private Action<int> selectCallBack;
    private int curSelHeadIndex;

    public override void OnOpen()
    {
        //curSelHeadIndex = DataManager.PlayerData.HeadIndex.Value;
        selectCallBack = (Action<int>)objs[0];
        base.OnOpen();
        InitHeads();
    }

    private void InitHeads()
    {
//        for (int i=0; i<=DataManager.PlayerData.HeadCount; i++)
//        {
//            GameObject item = Instantiate(ItemPrefab);
//            HeadItem headItem = item.GetComponent<HeadItem>();
//            
//            if (i == 0)
//            {
//                byte[] bytes = null;
//                bool isFbLogined = !string.IsNullOrEmpty(DataManager.FireBaseData.FBUserID);
//                if (isFbLogined && Record.HasFile(PrefKeys.FaceBookImageCache))
//                {
//                    bytes = Record.LoadFileByBytes(PrefKeys.FaceBookImageCache);
//                }
//                headItem.InitFBImage(i, isFbLogined, bytes, toggleGroup, OnHeadChanged);
//            }
//            else
//            {
//                headItem.InitLocalHeadImage(i, DataManager.PlayerData.GetHeaderIcon(i - 1), toggleGroup, OnHeadChanged);
//            }
//        }
    }

    private void OnHeadChanged(int headIndex)
    {
        curSelHeadIndex = headIndex;
    }

    public override void OnClose()
    {
        base.OnClose();
//        if (curSelHeadIndex != DataManager.PlayerData.HeadIndex.Value)
//        {
//            selectCallBack(curSelHeadIndex);
//        }
    }
}
