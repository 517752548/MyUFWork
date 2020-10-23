using app.model;
using UnityEngine;
using app.db;
using app.net;
using app.yunliang;
using app.jiuguan;
using app.zone;
using app.report;
using app.activity;

public class ActivityListItemScript
{   
    //abcdefgh
    //ijklmnop
    //qrstuvwxyz
    public HuoDongListItem UI;

    private ActivityUIInfo activityInfo;
    private ActivityUITemplate activityTpl;
    
    private JiuGuanRenWuModel mJiuguanModel = null;
    private YunLiangModel mYunLiangModel = null;

    private RTimer mTimer;

    public ActivityListItemScript(HuoDongListItem ui)
    {
        UI = ui;
        UI.listbtn.SetClickCallBack(clickHuodong);
        UI.canjia.SetClickCallBack(clickCanJia);
    }

    private void clickHuodong()
    {
        ActivityInfoTips.Ins.ShowTips(activityTpl, activityInfo);
    }

    private void clickCanJia()
    {
        if (activityInfo != null && activityTpl != null)
        {
            ///即将开启弹tip///
            if ((int)ActivityType.JIJIANGOPEN == activityInfo.activityType)
            {
                GuideManager.Ins.RemoveGuide();
                clickHuodong();
                return;
            }
            DataReport.Instance.Game_SetEvent("c_touch", "activity", activityTpl.Id.ToString());
            string[] pathArr = LinkParse.Ins.Parse(activityTpl.hyperlink);
            if (pathArr != null && pathArr.Length > 1)
            {
                if (int.Parse(pathArr[0]) == LinkTypeDef.FindNPC)
                {
                    int npcId = int.Parse(pathArr[2]);
                    NpcTemplateVO npcTpl = NpcTemplateDB.Instance.getTemplate(npcId);
                    if (npcTpl.fuctionIdList != null && npcTpl.fuctionIdList.Contains(FunctionIdDef.JIUGUAN))
                    {
                        if (mJiuguanModel == null)
                        {
                            mJiuguanModel = JiuGuanRenWuModel.Ins;
                        }
                        QuestInfoData jiuguanQuestData = mJiuguanModel.currentQuestData;
                        if (jiuguanQuestData != null && (jiuguanQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED ||
                                 jiuguanQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH))
                        {
                            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.JIUGUAN_NO_COMPLETE);
                            GuideManager.Ins.RemoveGuide(GuideIdDef.JiuGuan);
                            return;
                        }
                    }
                    if (npcTpl.fuctionIdList != null && npcTpl.fuctionIdList.Contains(FunctionIdDef.YUNLIANG))
                    {
                        if (mYunLiangModel == null)
                        {
                            mYunLiangModel = YunLiangModel.Ins;
                        }
                        QuestInfoData yunliangQuestData = mYunLiangModel.currentQuestData;
                        if (yunliangQuestData != null && (yunliangQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED ||
                                 yunliangQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH))
                        {
                            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.YUNLIANG_NO_COMPLETE);
                            GuideManager.Ins.RemoveGuide(GuideIdDef.YunLiang);
                            return;
                        }
                    }
                    if (GuideManager.Ins.CurrentGuideId!=GuideIdDef.NONE)
                    {
                        GuideManager.Ins.switchMask(true);
                    }
                }
                if (int.Parse(pathArr[0]) == LinkTypeDef.LinkToFunc)
                {
                    if (int.Parse(pathArr[1]) == FunctionIdDef.KEJU)
                    {
                        GuideManager.Ins.switchMask(GuideIdDef.KeJu, true);
                    }
                    if (int.Parse(pathArr[1]) == FunctionIdDef.JINGJICHANG)
                    {
                        GuideManager.Ins.switchMask(GuideIdDef.JingJiChang, true);
                    }
                    if (int.Parse(pathArr[1]) == FunctionIdDef.RINGTASK)
                    {
                        GuideManager.Ins.switchMask(GuideIdDef.RingTask, true);
                    }
                }
                //停止自动寻路
                AutoMaticManager.Ins.StopAutoMatic();
                LinkParse.Ins.doLink(activityTpl.hyperlink);
                WndManager.Ins.close(GlobalConstDefine.ActivityListView_Name);
                
            }
        }
    }

    public void setData(ActivityUIInfo activityinfo)
    {
        activityInfo = activityinfo;
        activityTpl = ActivityUITemplateDB.Instance.getTemplate(activityInfo.activityId);

        bool isRecommond = activityInfo.specialType == 1;
        int recommondCoef = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.ACTIVITYUI_RECOMMOND_COEF);
        //推荐的活跃度需要乘以系数
        int numPer = isRecommond ? activityTpl.activityNumPerTime * recommondCoef : activityTpl.activityNumPerTime;
        
        UI.huodongName.text = activityTpl.name;

        int maxcount = PlayerModel.Ins.GetBehaviorMaxCount(activityTpl.behaviorId);
        if (maxcount==-1)
        {
            maxcount = activityTpl.activityTotalTime;
        }
     
        int gehuoyue = activityInfo.activityTimes * numPer;
        int maxhuoyue = activityTpl.activityTotalTime*numPer;
        if (gehuoyue > maxhuoyue)
        {
            gehuoyue = maxhuoyue;
        }
        if (activityinfo.activityId == ActivityIdDef.XIANSHIDATI || activityinfo.activityId == ActivityIdDef.XIANSHISHAGUAI
            || activityinfo.activityId == ActivityIdDef.XIANSHINPC)
        {
            UI.textTitle1.text = "活跃";
            UI.textContent1.text = activityTpl.activityNumPerTime == 0 ? LangConstant.NONE : (gehuoyue + "/" + maxhuoyue);
            UI.tfContent2.gameObject.SetActive(false);
            UI.tfDaojishi.gameObject.SetActive(true);
            if (activityinfo.cd > 0)
            {
                if (mTimer != null)
                {
                    mTimer.stop();
                    mTimer = null;
                }
                mTimer = TimerManager.Ins.createTimer(500, (int)activityinfo.cd, OnTimer, null);
                mTimer.start();
            }
            else
            {
                UI.textRemianTime.text = "00:00:00";
            }
        }
        else
        {
            UI.tfContent2.gameObject.SetActive(true);
            UI.tfDaojishi.gameObject.SetActive(false);
            UI.textContent1.text = activityTpl.activityTotalTime == 0 ? LangConstant.NOLIMIT :
                (activityInfo.activityTimes + "/" + maxcount);
            UI.textTitle1.text = "次数";
            UI.textTitle2.text = "活跃";
            UI.textContent2.text = activityTpl.activityNumPerTime == 0 ? LangConstant.NONE : (gehuoyue + "/" + maxhuoyue);
        }

        //UI.huodongTag.text = GetHuodongTagName(activityInfo.specialType);
        //UI.huodongTag_tuijian.SetActive(isRecommond);
        //UI.huodongTag_jieri.SetActive(activityInfo.specialType == 2);
        
        ///显示活动Tag///
        if (isRecommond)
        {
            PathUtil.Ins.SetSprite(UI.huodongTag, "tuijian", PathUtil.Ins.uiDependenciesPath, true);
        }
        else if (2 == activityInfo.specialType)
        {
            PathUtil.Ins.SetSprite(UI.huodongTag, "jieri", PathUtil.Ins.uiDependenciesPath, true);
        }
        else
        {
            PathUtil.Ins.SetSprite(UI.huodongTag, activityTpl.superScript, PathUtil.Ins.uiDependenciesPath, true);
        }
        
        UI.canjia.gameObject.SetActive(activityInfo.finishStatue == 0);
        if (activityInfo.activityId == ActivityIdDef.JINGJICHANG)
        {
            //竞技场 特殊处理,一直显示参加按钮
            UI.canjia.gameObject.SetActive(true);
        }
        UI.wanchengText.gameObject.SetActive(activityInfo.finishStatue == 1);
        PathUtil.Ins.SetActivityIcon(UI.icon, activityTpl.icon);
        //SourceLoader.Ins.load(PathUtil.Ins.GetUITexturePath(activityTpl.icon, PathUtil.TEXTURE_ACTIVITY_ICON), OnIconLoaded);

        ///即将开启的显示查看///
        if ((int)ActivityType.JIJIANGOPEN == activityinfo.activityType)
        {
            UI.m_canjia_name.text = "查看";
        }
        else
        {
            UI.m_canjia_name.text = "参加";
        }
    }
    private void OnTimer(RTimer timer)
    {
        int leftTime = timer.getLeftTime();
        UI.textRemianTime.text = TimeString.getTimeFormatMS(leftTime > 0 ? leftTime : 0);
    }
    /*
    private void OnIconLoaded(RMetaEvent e)
    {
        if (e.type == SourceLoader.LOAD_COMPLETE)
        {
            string iconPath = ((LoadInfo)(e.data)).urlPath;
            Texture2D t = SourceManager.Ins.GetAsset<Texture2D>(iconPath);
            UI.icon.texture = t;
        }
    }
    */

    public static string GetHuodongTagName(int specialtype)
    {
        string str = "";
        switch (specialtype)
        {
            case 0:
                str = "";
                break;
            case 1:
                str = LangConstant.TUIJIAN;
                break;
            case 2:
                str = LangConstant.JIERI;
                break;
        }
        return str;
    }

    public void Destroy()
    {
        if (mTimer != null)
        {
            mTimer.stop();
            mTimer = null;
        }
        GameObject.DestroyImmediate(UI.gameObject, true);
        UI = null;
        activityInfo=null;
        activityTpl=null;
    }
}

