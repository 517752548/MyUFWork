using System.Collections.Generic;
using app.db;
using app.net;
using app.reward;
using app.tips;
using app.utils;
using UnityEngine;

public class QiRiMuBiaoItemScript
{
    public QiRiMuBiaoItemUI itemUI;
    private RewardItem mRewardItemRight;
    public QuestTemplate questinfodata;
    private List<RewardItem> mRewardItems;


    public QiRiMuBiaoItemScript(QiRiMuBiaoItemUI itemUI)
    {
        this.itemUI = itemUI;
        itemUI.recieveButton.AddClickCallBack(OnClickReward);
    }

    public void SetData(QuestTemplate questinfodatav)
    {
        this.questinfodata = questinfodatav;
        if (mRewardItemRight == null)
        {
            mRewardItemRight = new RewardItem(itemUI.rightItem);
        }
        if (mRewardItems == null)
        {
            mRewardItems = new List<RewardItem>();
        }
        mRewardItems.Clear();
        mRewardItems.Add(mRewardItemRight);

        SetItemData();
        SetButtonInfo();
    }

    private void SetItemData()
    {
        if (questinfodata.showRewardId!=0)
        {
            RewardData rewardData = new RewardData();
            ShowRewardTemplate showrewardTPL = ShowRewardTemplateDB.Instance.getTemplate(questinfodata.showRewardId);
            rewardData.Parse(showrewardTPL,mRewardItems);
        }
        itemUI.textDescrip.text = questinfodata.desc;
        itemUI.rightButton.ClearClickCallBack();
        itemUI.rightButton.AddClickCallBack(OnclickInfo);
    }

    private void SetButtonInfo()
    {
        QuestInfoData questdata = QuestModel.Ins.GetQuestInfoById(questinfodata.Id);
        if (questdata != null)
        {
            if (questdata.questStatus == (int)QuestDefine.QuestStatus.FINISHED)
            {
                //已完成
                itemUI.objHaveRecieve.SetActive(true);
                itemUI.recieveButton.gameObject.SetActive(false);
            }
            else
            {
                itemUI.objHaveRecieve.SetActive(false);
                itemUI.recieveButton.gameObject.SetActive(true);
                if (questdata.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
                {
                    //可完成
                    if (!itemUI.recieveButton.IsInteractable())
                    {
                        itemUI.recieveButton.interactable = true;
                        ColorUtil.DeGray(itemUI.recieveButton);
                    }
                }
                else
                {
                    //没完成
                    if (itemUI.recieveButton.IsInteractable())
                    {
                        itemUI.recieveButton.interactable = false;
                        ColorUtil.Gray(itemUI.recieveButton);
                    }
                }
                itemUI.recieveButton.enabled = (questdata.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH);
            }
        }
        else
        {
            //还没有收到任务数据
            itemUI.recieveButton.gameObject.SetActive(true);
            itemUI.objHaveRecieve.SetActive(false);
            //itemUI.recieveButton.gameObject.SetActive(false);
            itemUI.recieveButton.interactable = false;
            ColorUtil.Gray(itemUI.recieveButton);
            itemUI.recieveButton.enabled = false;
        }
    }

    private void OnClickReward()
    {
        QuestInfoData questdata = QuestModel.Ins.GetQuestInfoById(questinfodata.Id);
        if (questdata != null)
        {
            if (questdata.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
            {
                HumanCGHandler.sendCGDay7TaskFinish(questinfodata.Id);
            }
        }
    }

    private void OnclickInfo(GameObject go)
    {
        if (go == itemUI.rightButton.gameObject)
        {
            if (mRewardItemRight.rewarddata.type == RewardType.ITEM)
            {
                ItemTips.Ins.ShowTips(mRewardItemRight.rewarddata.id);
            }
        }
            
    }
}
