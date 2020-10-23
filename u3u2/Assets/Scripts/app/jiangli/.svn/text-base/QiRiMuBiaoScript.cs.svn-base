using System.Collections.Generic;
using app.db;
using app.model;
using app.net;
using UnityEngine;

namespace app.jiangli
{
    class QiRiMuBiaoScript
    {
        private QiRiMuBiaoUI qirimubiaoUI;

        private List<QiRiMuBiaoItemScript> mItemScripts;

        private List<QuestTemplate> questList; 

        private int currentSelectDay = 0;

        public QiRiMuBiaoScript(QiRiMuBiaoUI qirimubiaoUiv)
        {
            this.qirimubiaoUI = qirimubiaoUiv;
            mItemScripts = new List<QiRiMuBiaoItemScript>();
            qirimubiaoUI.tbg.TabChangeHandler = selectDay;
            qirimubiaoUI.itemUI.gameObject.SetActive(false);

            QuestModel.Ins.addChangeEvent(QuestModel.UPDATEQUESTLIST, UpdateQiRiMuBiao);
            PlayerModel.Ins.addChangeEvent(PlayerModel.UPDATE_LOGIN_DAYS, UpdateQiRiMuBiao);
        }
        /// <summary>
        /// 选择一天
        /// </summary>
        /// <param name="dayindex"></param>
        private void selectDay(int dayindex)
        {
            currentSelectDay = dayindex;
            //这一天的所有任务id
            List<int> questidList = Day7TargetTemplateDB.Instance.GetQuestIdListByDay(dayindex + 1);
            int questcount = questList.Count;
            int index = 0;
            for (int i = 0; i < questcount; i++)
            {
                if (questidList.Contains(questList[i].Id))
                {
                    if (index >= mItemScripts.Count)
                    {
                        //需要创建新的item
                        if (index == 0)
                        {
                            QiRiMuBiaoItemScript itemScript = new QiRiMuBiaoItemScript(qirimubiaoUI.itemUI);
                            mItemScripts.Add(itemScript);
                        }
                        else
                        {
                            GameObject obj = GameObject.Instantiate(qirimubiaoUI.itemUI.gameObject);
                            QiRiMuBiaoItemUI ui = obj.GetComponent<QiRiMuBiaoItemUI>();
                            obj.transform.SetParent(qirimubiaoUI.grid.transform);
                            obj.transform.localScale = Vector3.one;
                            mItemScripts.Add(new QiRiMuBiaoItemScript(ui));
                        }
                    }
                    mItemScripts[index].itemUI.gameObject.SetActive(true);
                    mItemScripts[index].SetData(questList[i]);
                    index++;
                }
            }
            //多余的隐藏
            for (int i=index;i<mItemScripts.Count;i++)
            {
                mItemScripts[i].itemUI.gameObject.SetActive(false);
            }
        }

        public void UpdateQiRiMuBiao(RMetaEvent e = null)
        {
            questList = QuestTemplateDB.Instance.GetQuestTplList(QuestDefine.QuestType.QIRIMUBIAO);
            List<int> currentRewardDays = QuestModel.Ins.hasQiRiMuBiaoRewardDay();
            if (e!=null)
            {
                //通过事件调用的，刷新当前天
                qirimubiaoUI.tbg.SetIndexWithCallBack(currentSelectDay);
            }
            else 
            {
                //初始化调用的，如果有可以领取的天，连接到能领取的 最小的天
                if (currentRewardDays.Count > 0)
                {
                    qirimubiaoUI.tbg.SetIndexWithCallBack(currentRewardDays[0]);
                }
                else
                {//显示 第一天
                    qirimubiaoUI.tbg.SetIndexWithCallBack(0);
                }
            }
            //更新每一天的红点
            for (int i = 0; i < qirimubiaoUI.tbg.toggleList.Count; i++)
            {
                 qirimubiaoUI.tbg.toggleList[i].redDotVisible = currentRewardDays.Contains(i);
            }
        }

        public void Destroy()
        {
            QuestModel.Ins.removeChangeEvent(QuestModel.UPDATEQUESTLIST, UpdateQiRiMuBiao);
            PlayerModel.Ins.removeChangeEvent(PlayerModel.UPDATE_LOGIN_DAYS, UpdateQiRiMuBiao);

            GameObject.DestroyImmediate(qirimubiaoUI.gameObject, true);
            qirimubiaoUI = null;
        }

    }
}
