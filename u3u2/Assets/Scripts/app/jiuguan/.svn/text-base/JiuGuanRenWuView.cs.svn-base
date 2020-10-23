using System.Collections.Generic;
using System.Linq;
using app.bag;
using app.db;
using app.human;
using app.net;
using app.reward;
using app.role;
using UnityEngine;
using UnityEngine.UI;
using app.tips;


namespace app.jiuguan
{
    public class JiuGuanRenWuView : BaseWnd
    {
        //[Inject(ui = "JiuGuanRenWuUI")]
        //public GameObject ui;

        public JiuGuanRenWuModel jiuguanrenwuModel;
        public BagModel bagModel;

        private JiuGuanRenWuUI UI;
        private List<JiuGuanRenWuItemUI> questUIList;
        private List<BackupPubTaskInfo> questDatalist;
        private List<List<Image>> starList;
        private List<List<Image>> starhuiList;
        private List<List<CommonItemUI>> rewardItemUIList;
        private List<List<RewardItem>> rewardItemList;
        
        private MoneyItemScript mShuaxinCost = null;
        private MoneyItemScript mManxingCost = null;
        
        public JiuGuanRenWuView()
        {
            uiName = "JiuGuanRenWuUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            
            jiuguanrenwuModel = JiuGuanRenWuModel.Ins;
            jiuguanrenwuModel.addChangeEvent(JiuGuanRenWuModel.updateJiuGuanRenWuPanel, updatePanel);
            jiuguanrenwuModel.addChangeEvent(JiuGuanRenWuModel.updateOneJiuGuanRenWu, updatePanel);
            bagModel = BagModel.Ins;
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateShuaXinBtn);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateShuaXinBtn);
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateManXingBtn);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateManXingBtn);
            
            UI = ui.AddComponent<JiuGuanRenWuUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickClose);
            UI.shuaxinBtn.SetClickCallBack(clickShuaxin);
            UI.manxingBtn.SetClickCallBack(clickManxing);
            UI.shuomingBtn.SetClickCallBack(clickShuoming);
            questUIList = UI.renwuList;
            starList= new List<List<Image>>();
            starhuiList = new List<List<Image>>();
            rewardItemUIList = new List<List<CommonItemUI>>();
            rewardItemList = new List<List<RewardItem>>();

            for (int i=0;i<questUIList.Count;i++)
            {
                starList.Add(questUIList[i].starGrid.GetComponentsInChildren<Image>().ToList());
                starhuiList.Add(questUIList[i].starhuiGrid.GetComponentsInChildren<Image>().ToList());

                rewardItemUIList.Add(questUIList[i].itemList);
                List<RewardItem> list = new List<RewardItem>();
                for (int j=0;j<rewardItemUIList[i].Count;j++)
                {
                    list.Add(new RewardItem(rewardItemUIList[i][j]));
                }
                rewardItemList.Add(list);
                //EventTriggerListener.Get(questUIList[i].renwuBtn.gameObject).onClick = clickRenWuBtn;
                questUIList[i].renwuBtn.SetClickCallBack(clickRenWuBtn);
            }
            
            mShuaxinCost = new MoneyItemScript(UI.shuaxinCost);
            mShuaxinCost.setEmpty();
            mManxingCost = new MoneyItemScript(UI.manxingCost);
            mManxingCost.setEmpty();
        }

        private void clickShuaxin()
        {
            MoneyCheck.Ins.Check(mShuaxinCost.CurrencyType,mShuaxinCost.CurrencyValue,sureHandler);
        }

        private void sureHandler(RMetaEvent e)
        {
            PubtaskCGHandler.sendCGPubtaskRefreshNew(0);
        }

        public void clickManxing()
        {
            MoneyCheck.Ins.Check(mManxingCost.CurrencyType, mManxingCost.CurrencyValue, suremanxingHandler);
        }

        private void suremanxingHandler(RMetaEvent e)
        {
            PubtaskCGHandler.sendCGPubtaskRefreshNew(1);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            updatePanel();
            app.main.GameClient.ins.OnBigWndShown();
        }

        public void updatePanel(RMetaEvent e=null)
        {
            UI.leftTimes.text = jiuguanrenwuModel.PanelData.getFinishTimes() + " / " + jiuguanrenwuModel.PanelData.getTotalTimes();
            int publevel = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.PUB_LEVEL);
            UI.jiuguanLevel.text = publevel.ToString();
            PubLevelTemplate plt = null;
            if (publevel > 0)
            {
                plt = PubLevelTemplateDB.Instance.getTemplate(publevel);
            }
            if (plt!=null)
            {
                UI.jiuguanExp.LabelType = ProgressBarLabelType.CurrentAndMax;
                UI.jiuguanExp.setLongPercent(plt.exp, Human.Instance.PropertyManager.getLongProp(RoleBaseStrProperties.PUB_EXP));
                setQuestList(jiuguanrenwuModel.PanelData.getBackupPubTaskInfos().ToList());

                updateShuaXinBtn();
                updateManXingBtn();
            }
        }

        public void updateShuaXinBtn(RMetaEvent e=null)
        {
            if (mShuaxinCost == null) return;
            int id = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PUB_TASK_REFRESH_ITEMID);
            if (bagModel.getHasNum(id) > 0)
            {
                mShuaxinCost.setItemData(id,1);
            }
            else
            {
                int goldnum = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PUB_TASK_REFRESH_GOLD_NUM);
                mShuaxinCost.SetMoney(CurrencyTypeDef.GOLD, goldnum, true, false);
            }
        }

        public void updateManXingBtn(RMetaEvent e = null)
        {
            if (mManxingCost == null) return;
            int id = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PUB_TASK_MANXING_GOLD_ID);
            int goldnum = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PUB_TASK_MANXING_GOLD_NUM);
            mManxingCost.SetMoney(id, goldnum, true, false);

        }

        private void setQuestList(List<BackupPubTaskInfo> questlistv)
        {
            questDatalist = questlistv;
            if (questDatalist==null)
            {
                UI.renwuItemGrid.gameObject.SetActive(false);
                return;
            }
            UI.renwuItemGrid.gameObject.SetActive(true);
            for (int i=0;i<questUIList.Count;i++)
            {
                questUIList[i].gameObject.SetActive(false);
            }
            for (int i=0;questDatalist!=null&&i<questDatalist.Count;i++)
            {
                QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questDatalist[i].questId);
                questUIList[i].title.text = qt.title;
                questUIList[i].content.text = qt.desc;
                questUIList[i].gameObject.SetActive(true);
                //星数
                int starnum = questDatalist[i].star;
                for (int j = 0; j < starList[i].Count; j++)
                {
                    if (j < starnum)
                    {
                        starList[i][j].gameObject.SetActive(true);
                    }
                    else
                    {
                        starList[i][j].gameObject.SetActive(false);
                    }
                }
                for (int j = 0; j < starhuiList[i].Count; j++)
                {
                    if (j < JiuGuanRenWuModel.Ins.CurMaxPubStar)
                    {
                        starhuiList[i][j].gameObject.SetActive(true);
                    }
                    else
                    {
                        starhuiList[i][j].gameObject.SetActive(false);
                    }
                }
                
                //奖励
                RewardData reward = new RewardData();
                reward.Parse(questDatalist[i].rewardInfo.rewardStr, rewardItemList[i]);
                //任务状态
                string str="";
                switch (questDatalist[i].status)
                {
                    case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                        str = "接受任务";
                        questUIList[i].renwuBtn.gameObject.SetActive(true);
                        questUIList[i].rejectedTips.SetActive(false);
                        break;
                    case (int)QuestDefine.QuestStatus.ACCEPTED:
                        str = "放弃任务";
                        questUIList[i].renwuBtn.gameObject.SetActive(true);
                        questUIList[i].rejectedTips.SetActive(false);
                        break;
                    case (int)QuestDefine.QuestStatus.CAN_FINISH:
                        str = "完成任务";
                        questUIList[i].renwuBtn.gameObject.SetActive(true);
                        questUIList[i].rejectedTips.SetActive(false);
                        break;
                    case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                        str = "不可接";
                        questUIList[i].renwuBtn.gameObject.SetActive(true);
                        questUIList[i].rejectedTips.SetActive(false);
                        break;
                    case (int)QuestDefine.QuestStatus.FINISHED:
                        str = "已完成";
                        questUIList[i].renwuBtn.gameObject.SetActive(true);
                        questUIList[i].rejectedTips.SetActive(false);
                        break;
                    case (int)QuestDefine.QuestStatus.GIVEUP:
                        str = "已放弃";
                        questUIList[i].renwuBtn.gameObject.SetActive(false);
                        questUIList[i].rejectedTips.SetActive(true);
                        break;
                    default:
                        str = "";
                        questUIList[i].renwuBtn.gameObject.SetActive(false);
                        questUIList[i].rejectedTips.SetActive(false);
                        break;
                }
                Text text = questUIList[i].renwuBtn.GetComponentInChildren<Text>();
                if(text!=null)text.text = str;
            }
        }

        private void clickRenWuBtn(GameObject go)
        {
            int index = getRenWuIndex(go);
            if (index==-1)
            {
                return;
            }
            //任务状态
            switch (questDatalist[index].status)
            {
                case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                    //"接受任务";
                    PubtaskCGHandler.sendCGPubtaskAccept(questDatalist[index].questId);
                    WndManager.Ins.close(GlobalConstDefine.JiuGuanRenWuView_Name);
                    break;
                case (int)QuestDefine.QuestStatus.ACCEPTED:
                    //"放弃任务";
                    PubtaskCGHandler.sendCGGiveUpPubtask();
                    break;
                case (int)QuestDefine.QuestStatus.CAN_FINISH:
                    //"完成任务";
                    PubtaskCGHandler.sendCGFinishPubtask();
                    break;
                case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                    //"不可接";
                    break;
                default:
                    break;
            }
        }

        private int getRenWuIndex(GameObject renwubtn)
        {
            for (int i = 0; i < questUIList.Count; i++)
            {
                if (renwubtn == questUIList[i].renwuBtn.gameObject)
                {
                    return i;
                }
            }
            return -1;
        }

        private void clickClose()
        {
            hide();
        }

        private void clickShuoming()
        {
            PopInfoWnd.Ins.ShowInfo("1.每日可完成10次任务\n2.每日00:00点重置酒馆任务\n3.酒馆最高等级5级\n4.酒馆等级为1和2级时,任务最高星数为3星\n5.酒馆等级为3和4级时,任务最高星数为4星\n6.酒馆等级为5级时,任务最高星数为5星\n7.每次只能领取1个任务", null, TextAnchor.MiddleLeft, 480);
        }
        
        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
        }
        
        public override void Destroy()
        {
            jiuguanrenwuModel.removeChangeEvent(JiuGuanRenWuModel.updateJiuGuanRenWuPanel, updatePanel);
            jiuguanrenwuModel.removeChangeEvent(JiuGuanRenWuModel.updateOneJiuGuanRenWu, updatePanel);
            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateShuaXinBtn);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateShuaXinBtn);
            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateManXingBtn);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateManXingBtn);
            if (mShuaxinCost != null)
            {
                mShuaxinCost.Destroy();
                mShuaxinCost = null;
            }
            if (mManxingCost != null)
            {
                mManxingCost.Destroy();
                mManxingCost = null;
            }
            base.Destroy();
            UI = null;
        }
    }

}
