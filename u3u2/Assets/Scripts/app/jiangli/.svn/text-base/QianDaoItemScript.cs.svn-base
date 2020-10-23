using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using app.item;
using app.net;
using app.reward;
using UnityEngine;
using app.tips;


public class QianDaoItemScript
{
    public QianDaoItemUI UI;
    private RewardItem rewardItem;
    private RewardData mRewarddata;


    public QianDaoItemScript(QianDaoItemUI ui)
    {
        UI = ui;
        UI.btn.SetClickCallBack(ItemOnClick);
        UI.btn.gameObject.SetActive(false);
    }

    public void AddListener()
    {
        UI.toggle.interactable = true;
        UI.toggle.SetValueChangedCallBack(changeToggle);
        UI.btn.gameObject.SetActive(false);
    }

    public void RemoveListener()
    {
        UI.toggle.ClearClickCallBack();
        UI.toggle.isOn = false;
        UI.toggle.interactable = false;
        UI.btn.gameObject.SetActive(true);
    }

    public void Yijingqiandao()
    {
        UI.toggle.ClearClickCallBack();
        UI.toggle.isOn = true;
        UI.toggle.interactable = false;
        UI.btn.gameObject.SetActive(true);
    }

    private void changeToggle(bool state)
    {
        if (state)
        {
            OnlinegiftCGHandler.sendCGDaliyGiftSign();
            GuideManager.Ins.RemoveGuide(GuideIdDef.QianDao);
        }
    }

    public void setData(int day, RewardInfoData rewardinfo)
    {
        UI.tianshu.text = day + "天";
        if (rewardinfo != null)
        {
            mRewarddata = new RewardData();
            if (rewardItem == null)
            {
                rewardItem = new RewardItem(UI.item);
            }
            mRewarddata.ParseDefaultItem(rewardinfo.rewardStr, rewardItem);
        }
    }

    private void ItemOnClick(GameObject go)
    {
        if (rewardItem.rewarddata.type == RewardType.ITEM)
        {
            ItemTips.Ins.ShowTips(rewardItem.rewarddata.id);
        }
    }

}
