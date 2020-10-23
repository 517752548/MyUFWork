using UnityEngine;
using System.Collections;
using app.db;
using app.reward;
using System.Collections.Generic;
using app.net;
using app.danrenfuben;
using app.utils;

public class FubenJiangliItemScript 
{
    public QiRiMuBiaoItemUI UI;
    public PlotDungeonTemplate template;
    FubenJiangliView jiangliView;

    private bool canClick = false;
    public FubenJiangliItemScript(QiRiMuBiaoItemUI UI,FubenJiangliView jiangliView)
    {
        this.UI = UI;
        this.jiangliView = jiangliView;
        UI.recieveButton.SetClickCallBack(OnClickReward);
        UI.rightButton.gameObject.SetActive(false);
    }

    public void SetTemplate(PlotDungeonTemplate template)
    {
        this.template = template;
     //     public Text textDescrip;
    //public CommonItemUINoClick rightItem;
    //public GameUUButton rightButton;
    //public GameUUButton recieveButton;
    //public GameObject objHaveRecieve;
        UI.textDescrip.text = template.showRewardName;
        ShowRewardTemplate rewardTemlate = ShowRewardTemplateDB.Instance.getTemplate(template.showDailyRewardId);
        RewardItem rewardItem = new RewardItem(UI.rightItem);
        RewardData rewardData = new RewardData();

        List<RewardItem> rewardItems = new List<RewardItem>();
        rewardItems.Add(rewardItem);
        rewardData.Parse(rewardTemlate,rewardItems);
    }

    public void RefreshData()
    {
        PlotDungeonInfo info = jiangliView.GetDungeonInfo(template.hardFlag,template.plotDungeonLevel);
        switch(info.plotDungeonStatus)
        {
            	/** 剧情副本状态,0-不可领取,1-可领取但未领取,2-已领取 */
		//public int plotDungeonStatus;
            case 0:
                UI.recieveButton.gameObject.SetActive(true);
                ColorUtil.Gray(UI.recieveButton);
                canClick = false;
                UI.objHaveRecieve.gameObject.SetActive(false);
                break;
            case 1:
                UI.recieveButton.gameObject.SetActive(true);
                ColorUtil.DeGray(UI.recieveButton);
                canClick = true;
                UI.objHaveRecieve.gameObject.SetActive(false);
                break;
            case 2:
               // ColorUtil.Gray(UI.recieveButton);
                UI.recieveButton.gameObject.SetActive(false);
                canClick = false;
                UI.objHaveRecieve.gameObject.SetActive(true);
                break;
        }
    }

    private void OnClickReward()
    {
        if (canClick)
        {
            PlotdungeonCGHandler.sendCGGetDailyPlotDungeonReward(template.hardFlag, (template.plotDungeonLevel / DanrenFubenView.LEVELS_PER_LEVEL) + 1);
        }
 
    }

    public void Destroy()
    {
        jiangliView = null;
        template = null;
        if (UI != null)
        {
            GameObject.DestroyImmediate(UI.gameObject);
            UI = null;
        }
    }


}
