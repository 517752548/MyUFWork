using System.Collections.Generic;
using app.model;
using app.net;
using UnityEngine;
using UnityEngine.UI;

namespace app.onlineReward
{
    class OnlineRewardScript
    {

        public Vector3[] rewardItemPositions = new[] {new Vector3(124.15f,-64.1f,0),new Vector3(152.1f,-192.8f,0),new Vector3(65f,-296.6f,0),
        new Vector3(-70.5f,-296f,0),new Vector3(-151.27f,-191.7f,0),new Vector3(-126.9f,-61.08f,0)};
        private MeiRiZaiXianUI zaixianUI;
        private GameObject rewardItem;
         
        private List<ZaiXianItemUI> mZaiXianItemUI; 
        private List<OnlineItemScript> mScripts;

        public OnlineRewardModel onlineRewardModel;

        private GameUUButton rewardButton;
        //private Text timeText;

        private bool isInit = false;

        public OnlineRewardScript(MeiRiZaiXianUI zaixianUI)
        {
            if (!zaixianUI)
            {
                return;
            }
            this.zaixianUI = zaixianUI;
            Init();
           
        }

        private void Init()
        {
            onlineRewardModel = OnlineRewardModel.Ins;
            EventCore.addRMetaEventListener(onlineRewardModel.GetFinalEventType(OnlineRewardModel.ONLINE_REWARD_UPDATE), OnlineRewardUpdate);
            EventCore.addRMetaEventListener(onlineRewardModel.GetFinalEventType(OnlineRewardModel.UPDATE_ON_TIMER), OnTimer);
            
            rewardButton = zaixianUI.objRewardButton.GetComponent<GameUUButton>();
            rewardButton.AddClickCallBack(OnclickReward);
            //timeText = zaixianUI.objRemainTime.GetComponentInChildren<Text>();
            CreateComponent();
        }

        private void CreateComponent()
        {
            mZaiXianItemUI = new List<ZaiXianItemUI>();
            GameObject go = zaixianUI.ZaixinItemUI.gameObject;
            ZaiXianItemUI itemUI = go.GetComponent<ZaiXianItemUI>();
            mZaiXianItemUI.Add(itemUI);
            GameObject creatObj;
            for (int i = 0; i < rewardItemPositions.Length; i++)
            {
                creatObj = GameObject.Instantiate(go.gameObject);
                creatObj.transform.SetParent(go.transform.parent);
                creatObj.transform.localPosition = rewardItemPositions[i];
                creatObj.transform.localScale = Vector3.one;
                itemUI = creatObj.GetComponent<ZaiXianItemUI>();
                mZaiXianItemUI.Add(itemUI);
            }
        }

        public void SetData()
        {
            if(mScripts == null)
            {
                mScripts = new List<OnlineItemScript>();
            }
            else
            {
                mScripts.Clear();
            }
            for (int i = 0; i < mZaiXianItemUI.Count ; i++)
            {
                OnlineItemScript itemScript = new OnlineItemScript(mZaiXianItemUI[i]);
                mScripts.Add(itemScript);
                itemScript.SetData(onlineRewardModel.giftinfo.getRewardInfo()[i],i + 1);
            }
        }

        public void OnlineRewardUpdate(RMetaEvent data)
        {
            if (!isInit)
            {
                isInit = true;
                SetData();
            }
            RefreshItems();
            SetArrowOrientation(onlineRewardModel.giftinfo.getRewardId());
            if (onlineRewardModel.giftinfo.getCdTime() > 0)
            {
                zaixianUI.objRewardButton.SetActive(false);
                zaixianUI.objRemainTime.SetActive(true);
            }
            else
            {
                zaixianUI.objRemainTime.SetActive(false);
                zaixianUI.objRewardButton.SetActive(true);
            }
        }

        private void SetArrowOrientation(int index)
        {
            if (index < 1 || index > mZaiXianItemUI.Count)
            {
                return;
            }
            if (zaixianUI.tfArrowRoot)
            {
                Vector3 orientation = mZaiXianItemUI[index - 1].commonItem.transform.position -
                                      zaixianUI.tfArrowRoot.position;
                zaixianUI.tfArrowRoot.up = -orientation.normalized;
            }
            
        }

        private void OnclickReward()
        {
            OnlinegiftCGHandler.sendCGReceiveOnlinegift();
        }

        private string FormatTime(int time)
        {
            float second = time/(float)1000;
            return string.Format("{0:00}:{1:00}:{2:00} 后领取", Mathf.FloorToInt(second / 3600), Mathf.FloorToInt((second % 3600) / 60), second % 60);
        }

        private void RefreshItems()
        {
            for (int i = 0; i < mScripts.Count; i++)
            {
                mScripts[i].Refresh(onlineRewardModel.giftinfo.getRewardId());
            }
        }

        public void OnTimer(RMetaEvent rMeta)
        {
            RTimer  timer = rMeta.data as RTimer;
            zaixianUI.remainTimeText.text = FormatTime(timer.getLeftTime());
        }

        

        public void Destroy()
        {
            EventCore.removeRMetaEventListener(onlineRewardModel.GetFinalEventType(OnlineRewardModel.ONLINE_REWARD_UPDATE), OnlineRewardUpdate);
            EventCore.removeRMetaEventListener(onlineRewardModel.GetFinalEventType(OnlineRewardModel.UPDATE_ON_TIMER), OnTimer);
            
            GameObject.DestroyImmediate(zaixianUI.gameObject, true);
            zaixianUI = null;
        }
    }
}
