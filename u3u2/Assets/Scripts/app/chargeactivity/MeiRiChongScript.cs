using System;
using System.Collections.Generic;
using app.jiangli;
using app.net;
using app.reward;
using app.utils;
using UnityEngine;

public class MeiRiChongScript
{
    public MeiRiChongZhiUI UI;

    public List<MeiRiChongItemUI> itemList;
    public List<List<RewardItem>> rewardItemList;
    private List<GoodActivityRewardInfos> activityDaylist;
    /// <summary>
    /// 列表 ，一屏显示的对象个数
    /// </summary>
    private int numInViewPort = 3;
    private int heightPerItem = 86;

    public MeiRiChongScript(MeiRiChongZhiUI ui)
    {
        UI = ui;
        itemList = new List<MeiRiChongItemUI>();
        UI.chargeBtn.AddClickCallBack(clickCharge);
        //每日
        //targetinfo,列表
        //整体进度看：curnum,neednum
        //每日进度：CAN_GIVE_KEY = "7";HAS_GIVE_KEY = "8";
        //每一天的名用DESC_KEY
        
    }

    public void setData(GoodActivityInfo activityinfo)
    {
        //结束时间
        DateTime dt = new DateTime(1970, 1, 1);
        dt = dt.AddMilliseconds(activityinfo.endTime);
        UI.endTime.text = "活动结束时间:"+dt.ToString("yyyy-MM-dd HH:mm:ss");
        //规则
        UI.ruleText.text = activityinfo.desc;
        //列表内容
        activityDaylist = GoodActivityRewardInfos.GetRewardItems(activityinfo);

        int chargeProcess = 0;
        UI.defaultDayItem.gameObject.SetActive(false);
        if (rewardItemList==null)
        {
            rewardItemList = new List<List<RewardItem>>();
        }
        int passedIndex = 0;
        for (int i = 0; i < activityDaylist.Count; i++)
        {
            if (i>=itemList.Count)
            {
                MeiRiChongItemUI item = GameObject.Instantiate(UI.defaultDayItem);
                item.gameObject.SetActive(true);
                item.transform.SetParent(UI.grid.transform);
                item.transform.localScale = Vector3.one;
                itemList.Add(item);
                item.lingquBtn.AddClickCallBack(clickLingqu);
            }
            itemList[i].gameObject.SetActive(true);
            itemList[i].dayText.text = activityDaylist[i].desc;
            RewardData rewardData = new RewardData();
            //rewardData.ParseReward(list[i].rewardData);
            
            if (i >= rewardItemList.Count)
            {
                List<RewardItem> rewarditem = new List<RewardItem>();
                for (int j = 0; j < itemList[i].commonItemList.Count; j++)
                {
                    rewarditem.Add(new RewardItem(itemList[i].commonItemList[j]));
                }
                rewardItemList.Add(rewarditem);
            }
            rewardData.Parse(activityDaylist[i].rewardData, rewardItemList[i]);

            if (activityDaylist[i].hasGiveKey)
            {
                itemList[i].yilingquImg.gameObject.SetActive(true);
                itemList[i].lingquBtn.gameObject.SetActive(false);
                passedIndex = i+1;
            }
            else
            {
                itemList[i].yilingquImg.gameObject.SetActive(false);
                itemList[i].lingquBtn.gameObject.SetActive(true);
                if (activityDaylist[i].canGiveKey)
                {
                    //itemList[i].lingquBtn.interactable = true;
                    itemList[i].lingquBtnText.text = "可领取";
                    itemList[i].lingquBtn.ClearClickCallBack();
                    itemList[i].lingquBtn.AddClickCallBack(clickLingqu);
                    ColorUtil.DeGray(itemList[i].lingquBtn);
                }
                else
                {
                    ColorUtil.Gray(itemList[i].lingquBtn);
                    //itemList[i].lingquBtn.interactable = false;
                    itemList[i].lingquBtn.ClearClickCallBack();
                    itemList[i].lingquBtnText.text = "未达到";
                }
            }
            if (activityDaylist[i].hasGiveKey || activityDaylist[i].canGiveKey)
            {
                chargeProcess = activityDaylist[i].currNum;
            }
        }
        //进度
        UI.jindu.text = "进度：" + (chargeProcess <= 0 ? "未充值" : (chargeProcess + "/" + activityDaylist[activityDaylist.Count - 1].needNum));

        for (int i = activityDaylist.Count; i < itemList.Count; i++)
        {
            itemList[i].gameObject.SetActive(false);
        }
        int tempnum = (activityDaylist.Count - passedIndex > numInViewPort ? passedIndex : (activityDaylist.Count - numInViewPort));
        UI.grid.transform.localPosition = new Vector3(0, tempnum * heightPerItem, 0);
    }

    public void clickLingqu(GameObject go)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].lingquBtn.gameObject==go)
            {
                GoodactivityCGHandler.sendCGGoodActivityGetBonus(activityDaylist[i].activityId,activityDaylist[i].targetId);
                break;
            }
        }
    }

    public void clickCharge()
    {
        LinkParse.Ins.linkToFunc(FunctionIdDef.CHONGZHI);
    }

    public void Destroy()
    {
        for (int i = 0; rewardItemList!=null&&i < rewardItemList.Count; i++)
        {
            for (int j=0;j<rewardItemList[i].Count;j++)
            {
                rewardItemList[i][j].Destroy();
            }
            rewardItemList[i].Clear();
        }
        if(activityDaylist!=null)activityDaylist.Clear();
        activityDaylist = null;
    }
}
