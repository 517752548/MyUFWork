using System.Collections;
using System.Collections.Generic;
using app.item;
using UnityEngine;
using app.model;
using app.net;
using app.reward;
using app.utils;
using app.zone;

namespace app.activity
{
    /// <summary>
    /// 活动类型
    /// </summary>
    public enum ActivityType
    {
        NONE,
        //日常活动
        RICHANG,
        //限时活动
        XIANSHI,
        //即将开启
        JIJIANGOPEN
    }

    public class ActivityListView : BaseWnd
    {
        //[Inject(ui = "ActivityPanelUI")]
        //public GameObject ui;
        public HuoDongPanelUI UI;

        public ActivityModel activityModel;
        /// <summary>
        /// 活动列表
        /// </summary>
        private List<ActivityListItemScript> list;
        /// <summary>
        /// 奖励列表
        /// </summary>
        private List<RewardItem> rewardItemList;
        private List<HuoDongRewardItem> rewardList;
        
        private Coroutine mCreateActivityListCoroutine = null;
        /// <summary>
        /// 每个元素的宽度
        /// </summary>
        private int itemPerWidth = 204;

        public ActivityListView()
        {
            uiName = "ActivityPanelUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            
            activityModel = ActivityModel.Ins;
            activityModel.addChangeEvent(ActivityModel.UPDATE_ACTIVITYlIST, setData);
            
            UI = ui.AddComponent<HuoDongPanelUI>();
            UI.Init();
            UI.huodongTBG.TabChangeHandler = selectTBG;


            UI.closeBtn.SetClickCallBack(clickclose);

            UI.shuaxinText.text = LangConstant.HUODONGMEISHI + " " + ColorUtil.getColorText(ColorUtil.GREEN, "00:00") + " " + LangConstant.SHUAXIN;
            UI.huodongTBG.toggleList[0].redDotVisible = false;
            UI.huodongTBG.toggleList[1].redDotVisible = false;
        }

        private void clickclose()
        {
            hide();
        }

        private void clickRewardItem(GameObject go)
        {
            for (int i = 0; i < rewardItemList.Count; i++)
            {
                if (rewardItemList[i].UI.gameObject == go)
                {
                    int huoyuedu = activityModel.HuoyueduRewardList.getActivityUIRewardInfoList()[i].vitalityNum;
                    if (!activityModel.IsRewardCanGet(huoyuedu))
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.JIANGLI_YI_LINGQU);
                    }
                    else
                    {
                        if (activityModel.ActivityInfo.getTotalActivityVitality() >= huoyuedu)
                        {
                            ActivityuiCGHandler.sendCGAcitvityUiReward(huoyuedu);
                        }
                        else
                        {
                            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.JIANGLI_CANNOT_LINGQU);
                        }
                    }
                    break;
                }
            }
        }

        private bool canGetReward(GameObject go)
        {
            for (int i = 0; i < rewardItemList.Count; i++)
            {
                if (rewardItemList[i].UI.gameObject == go)
                {
                    int huoyuedu = activityModel.HuoyueduRewardList.getActivityUIRewardInfoList()[i].vitalityNum;
                    if (!activityModel.IsRewardCanGet(huoyuedu))
                    {
                        return false;
                    }
                    else
                    {
                        if (activityModel.ActivityInfo.getTotalActivityVitality() >= huoyuedu)
                        {
                            return true;
                        }
                        //else
                        //{
                            return false;
                        //}
                    }
                    //break;
                }
            }
            return false;
        }

        private void selectTBG(int tab)
        {
            switch (tab)
            {
                case 0: //日常
                    updateList();
                    break;
                case 1: //限时
                    updateList();
                    break;
                case 2: //即将开启
                    updateList();
                    break;
            }
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            ShowGlowEffects();
            //updateList();
            UI.huodongTBG.SetIndexWithCallBack(0);
            app.main.GameClient.ins.OnBigWndShown();
        }
        
        private void ShowGlowEffects()
        {
            if (rewardList != null)
            {
                int len = rewardList.Count;
                for (int i = 0; i < len; i++)
                {
                    if (rewardList[i].item.glowEffect != null)
                    {
                        rewardList[i].item.glowEffect.SetActive(true);
                    }
                }
            }
        }
        
        private void HideGlowEffects()
        {
            if (rewardList != null)
            {
                int len = rewardList.Count;
                for (int i = 0; i < len; i++)
                {
                    if (rewardList[i].item.glowEffect != null)
                    {
                        rewardList[i].item.glowEffect.SetActive(false);
                    }
                }
            }
        }
        
        public override void hide(RMetaEvent e = null)
        {
            if (mCreateActivityListCoroutine != null)
            {
                UI.StopCoroutine(mCreateActivityListCoroutine);
                mCreateActivityListCoroutine = null;
            }
            HideGlowEffects();
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
        }
        
        public void setData(RMetaEvent e = null)
        {
            updateList();
        }

        private void updateList()
        {
            if (activityModel.ActivityInfo == null)
            {
                ClientLog.LogError("ActivityListView.updateList时，GCActivityUiInfo为空！");
                return;
            }
            
            if (activityModel.HuoyueduRewardList == null)
            {
                ClientLog.LogError("ActivityListView.updateList时，GCActivityUiRewardInfo为空！");
                return;
            }
            
            if (activityModel.HuoyueduRewardList.getActivityUIRewardInfoList() == null)
            {
                ClientLog.LogError("ActivityListView.updateList时，GCActivityUiRewardInfo.getActivityUIRewardInfoList()为空！");
                return;
            }
            
            if (rewardList == null)
            {
                rewardList = new List<HuoDongRewardItem>();
            }

            if (rewardItemList == null)
            {
                rewardItemList = new List<RewardItem>();
            }
            
            ActivityUIRewardInfo[] rewardinfolist = activityModel.HuoyueduRewardList.getActivityUIRewardInfoList();
            float maxVitality = 109.6f;

            int len = rewardinfolist.Length;
            for (int i = 0; i < len; i++)
            {
                if (i >= rewardList.Count)
                {
                    HuoDongRewardItem rewardItem = GameObject.Instantiate(UI.rewardItem);
                    rewardItem.gameObject.transform.SetParent(UI.rewardItem.transform.parent);
                    rewardItem.gameObject.transform.localScale = UI.rewardItem.transform.localScale;
                    rewardItem.gameObject.transform.localPosition = UI.rewardItem.transform.localPosition;
                    rewardList.Add(rewardItem);
                    rewardItemList.Add(new RewardItem(rewardItem.item));
                }
                if (canGetReward(rewardList[i].item.gameObject))
                {
                    //可领取奖励
                    rewardItemList[i].setClickFor(CommonItemClickFor.OnlyCallBack);
                    EventTriggerListener.Get(rewardList[i].item.gameObject).onClick = clickRewardItem;
                }
                else
                {
                    rewardItemList[i].setClickFor(CommonItemClickFor.ShowTips);
                    EventTriggerListener.Get(rewardList[i].item.gameObject).onClick = null;
                }

                rewardList[i].huoyue.text = ColorUtil.getColorText(ColorUtil.GREEN, rewardinfolist[i].vitalityNum.ToString()) + "活跃";
                RewardData rewarddata = new RewardData();
                rewarddata.ParseReward(rewardinfolist[i].rewardInfo.rewardStr);
                RewardItemData itemdata = rewarddata.getDefaultRewardItemData();
                if (itemdata != null)
                {
                    rewardItemList[i].setRewardData(itemdata);
                }
                else
                {
                    rewardItemList[i].setEmpty();
                }

                rewardList[i].gameObject.SetActive(true);
                
                int huoyuedu = activityModel.HuoyueduRewardList.getActivityUIRewardInfoList()[i].vitalityNum;
                if (activityModel.IsRewardCanGet(huoyuedu))
                {
                    if (activityModel.ActivityInfo.getTotalActivityVitality() >= huoyuedu)
                    {
                        if (rewardList[i].item.glowEffect==null)
                        {
                            GameObject glowEffect = SourceManager.Ins.createObjectFromAssetBundle(PathUtil.Ins.GetEffectPath("common_xuanzhong02"));
                            glowEffect.transform.SetParent(rewardList[i].item.transform);
                            glowEffect.transform.localScale = new Vector3(100, 100, 100);
                            glowEffect.transform.localPosition = new Vector3(0, 0, -10);
                            GameObjectUtil.SetLayer(glowEffect, rewardList[i].item.gameObject.layer);
                            if (isShown)
                            {
                                glowEffect.SetActive(true);
                            }
                            rewardList[i].item.glowEffect = glowEffect;   
                        }
                        else
                        {
                            if (isShown)
                            {
                                rewardList[i].item.glowEffect.SetActive(true);
                            }
                        }
                    }
                    else
                    {
                        if (rewardList[i].item.glowEffect != null)
                        {
                            GameObject.DestroyImmediate(rewardList[i].item.glowEffect, true);
                            rewardList[i].item.glowEffect = null;
                        }
                    }
                }
                else
                {
                    if (rewardList[i].item.glowEffect != null)
                    {
                        GameObject.DestroyImmediate(rewardList[i].item.glowEffect, true);
                        rewardList[i].item.glowEffect = null;
                    }
                }

               // maxVitality = Mathf.Max(rewardinfolist[i].vitalityNum, maxVitality);
                //UI.jinduBar.MaxValue = Mathf.Max(rewardinfolist[i].vitalityNum, UI.jinduBar.MaxValue);
            }

            for (int i = len; i < rewardList.Count; i++)
            {
                rewardList[i].gameObject.SetActive(false);
            }

            //UI.jinduBar.Value = activityModel.ActivityInfo.getTotalActivityVitality();

            //RectTransform barTrans = UI.jinduBar.forGround.GetComponent<RectTransform>();
            float barWidth = UI.jinduBar.progressBarWidth;

            float lastRewardItemX = 0;
            float itemSpace = (barWidth / (float)(rewardList.Count * 2 + 1)) * 2.0f;
            for (int i = 0; i < len; i++)
            {
                Vector3 pos = rewardList[i].gameObject.transform.localPosition;
                pos.x = itemSpace * (i + 1);
                rewardList[i].gameObject.transform.localPosition = pos;
                lastRewardItemX = pos.x;
            }

            float xSizePerVitality = lastRewardItemX / maxVitality;
            int totalActivityVitality = activityModel.ActivityInfo.getTotalActivityVitality();
            //if (totalActivityVitality > maxVitality)
            //{
            //    UI.jinduBar.Percent = 1;
            //}
            //else
            //{
              //  UI.jinduBar.Percent = (xSizePerVitality * (float)totalActivityVitality) / barWidth;
           // }
            
            UI.jinduBar.Percent = totalActivityVitality / maxVitality;

            float barRightSide = barWidth * UI.jinduBar.Percent + UI.jinduBar.transform.localPosition.x;
            Vector3 dotPos = UI.jinduDot.transform.localPosition;
            dotPos.x = barRightSide;
            UI.jinduDot.transform.localPosition = dotPos;
            UI.jinduDotText.text = totalActivityVitality.ToString();
            
            if (mCreateActivityListCoroutine != null)
            {
                UI.StopCoroutine(mCreateActivityListCoroutine);
                mCreateActivityListCoroutine = null;
            }
            if (UI.isActiveAndEnabled)
            {
                mCreateActivityListCoroutine = UI.StartCoroutine(CreateActivityList());
            }
            else
            {
                CreateActivityList();
            }
        }
        
        private IEnumerator CreateActivityList()
        {
            ActivityUIInfo[] totalList = activityModel.ActivityInfo.getActivityList();
            int type = UI.huodongTBG.index + 1;
            //筛选该类型的活动
            List<ActivityUIInfo> infoList = new List<ActivityUIInfo>();
            for (int i = 0; i < totalList.Length; i++)
            {
                if (totalList[i].activityType == type)
                {
                    infoList.Add(totalList[i]);
                }
            }

            ///日常活动需要增加显示即将开启活动///
            //if ((int)ActivityType.RICHANG==type)
            //{
            //    for (int i = 0; i < totalList.Length; i++)
            //    {
            //        if (totalList[i].activityType == (int)ActivityType.JIJIANGOPEN)
            //        {
            //            infoList.Add(totalList[i]);
            //        }
            //    }
            //}
            if (list == null)
            {
                list = new List<ActivityListItemScript>();
            }
            UI.defaultHuoDongItem.gameObject.SetActive(false);
            int kejuIndex = -1;
            int jingjichangIndex = -1;
            int lvyexianzongIndex = -1;
            int jiuguanIndex = -1;
            int cangbaotuIndex = -1;
            int yunliangIndex = -1;
            int chubaoIndex = -1;
            int ringtaskIndex = -1;

            for (int i = 0; i < infoList.Count; i++)
            {
                if (i >= list.Count)
                {
                    HuoDongListItem item = GameObject.Instantiate(UI.defaultHuoDongItem);
                    item.gameObject.SetActive(true);
                    item.gameObject.transform.SetParent(UI.itemListParent.transform);
                    item.gameObject.transform.localScale = Vector3.one;
                    ActivityListItemScript itemScript = new ActivityListItemScript(item);
                    list.Add(itemScript);
                }
                list[i].UI.gameObject.SetActive(true);
                list[i].setData(infoList[i]);
                if (infoList[i].activityId==ActivityIdDef.KEJU)
                {
                    kejuIndex = i;
                }
                if (infoList[i].activityId == ActivityIdDef.JINGJICHANG)
                {
                    jingjichangIndex = i;
                }
                if (infoList[i].activityId == ActivityIdDef.LVYE)
                {
                    lvyexianzongIndex = i;
                }
                if (infoList[i].activityId == ActivityIdDef.JIUGUANRENWU)
                {
                    jiuguanIndex = i;
                }
                if (infoList[i].activityId == ActivityIdDef.CANGBAOTU)
                {
                    cangbaotuIndex = i;
                }
                if (infoList[i].activityId == ActivityIdDef.YUNLIANG)
                {
                    yunliangIndex = i;
                }
                if (infoList[i].activityId == ActivityIdDef.CHUBAO)
                {
                    chubaoIndex = i;
                }
                if (infoList[i].activityId == ActivityIdDef.RINGTASK)
                {
                    ringtaskIndex = i;
                }
                yield return 0;
            }
            for (int i = infoList.Count; i < list.Count; i++)
            {
                list[i].UI.gameObject.SetActive(false);
            }
            int scrollIndex = 0;
            switch (GuideManager.Ins.CurrentGuideId)
            {
                case GuideIdDef.KeJu:scrollIndex = kejuIndex;break;
                case GuideIdDef.JingJiChang: scrollIndex = jingjichangIndex; break;
                case GuideIdDef.LvYeXianZong: scrollIndex = lvyexianzongIndex; break;
                case GuideIdDef.JiuGuan: scrollIndex = jiuguanIndex; break;
                case GuideIdDef.CangBaoTu: scrollIndex = cangbaotuIndex; break;
                case GuideIdDef.YunLiang: scrollIndex = yunliangIndex; break;
                case GuideIdDef.ChuBao: scrollIndex = chubaoIndex; break;
                case GuideIdDef.RingTask: scrollIndex = ringtaskIndex; break;
            }
            UI.itemListParent.transform.localPosition = new Vector3(-scrollIndex * itemPerWidth,0,0);

            if (-1 != kejuIndex)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.KeJu, 2, list[kejuIndex].UI.canjia.gameObject);
            }
            if (-1 != jingjichangIndex)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.JingJiChang, 2, list[jingjichangIndex].UI.canjia.gameObject, true, 500);
            }
            if (-1 != lvyexianzongIndex)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.LvYeXianZong, 2, list[lvyexianzongIndex].UI.canjia.gameObject, true, 500);
            }
            if (-1 != jiuguanIndex)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.JiuGuan, 2, list[jiuguanIndex].UI.canjia.gameObject, true, 200);
            }
            if (-1 != cangbaotuIndex)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.CangBaoTu, 2, list[cangbaotuIndex].UI.canjia.gameObject, true, 200);
            }
            if (-1 != yunliangIndex)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.YunLiang, 2, list[yunliangIndex].UI.canjia.gameObject, true, 200);
            }
            if (-1 != chubaoIndex)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.ChuBao, 2, list[chubaoIndex].UI.canjia.gameObject, true, 200);
            }
            if (-1 != ringtaskIndex)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.RingTask, 2, list[ringtaskIndex].UI.canjia.gameObject, false, 300);
            }

            mCreateActivityListCoroutine = null;
        }

        public override void Destroy()
        {
            if (activityModel != null)
            {
                activityModel.removeChangeEvent(ActivityModel.UPDATE_ACTIVITYlIST, setData);
            }

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Destroy();
                }
                list.Clear();
                list = null;
            }
            if (rewardList != null && rewardItemList!=null)
            {
                for (int i = 0; i < rewardItemList.Count; i++)
                {
                    rewardItemList[i].Destroy();
                }
                rewardItemList.Clear();
                rewardItemList = null;
            }
            //for (int i = 0; i < rewardList.Count; i++)
            //{
            //    rewardList[i].Destroy();
            //}

            base.Destroy();
            UI = null;
        }

    }
}
