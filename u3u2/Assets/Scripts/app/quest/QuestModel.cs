using System.Collections.Generic;
using app.baotu;
using app.chubao;
using app.db;
using app.model;
using app.net;
using app.npc;
using app.state;
using app.story;
using app.zone;
using app.report;
using UnityEngine;
using app.tongtianta;

public class QuestModel : AbsModel
{
    public const string UPDATEQUESTLIST = "updateQuestList";
    public const string UPDATE_QIRI_MUBIAO_QUEST = "UPDATE_QIRI_MUBIAO_QUEST";
    public const string MOVE_ACCEPT_TASK = "MOVE_ACCEPT_TASK";
    #region 任务列表

    private Dictionary<int, QuestInfoData> commonQuestDic;

    public Dictionary<int, QuestInfoData> CommonQuestDic
    {
        get { return commonQuestDic; }
    }
    /// <summary>
    /// 收到 主线任务 列表，消息中只有主线任务
    /// </summary>
    /// <param name="msg"></param>
    public void setCommonQuestList(GCCommonQuestList msg)
    {
        QuestInfoData questinfo = null;
        bool isaddtask = false;
        List<QuestInfoData> notMainQuest = new List<QuestInfoData>();
        if (CommonQuestDic == null)
        {
            commonQuestDic = new Dictionary<int, QuestInfoData>();
        }
        else
        {
            foreach (KeyValuePair<int, QuestInfoData> pair in CommonQuestDic)
            {
                QuestTemplate questData = QuestTemplateDB.Instance.getTemplate(pair.Value.questId);

                if (!IsMainOrSubQuest(questData))
                {
                    notMainQuest.Add(pair.Value);
                }
            }
            //判断 是否有新增的 主线或支线任务
            for (int i = 0; i < msg.getQuestInfos().Length; ++i)
            {
                if(!CommonQuestDic.ContainsKey(msg.getQuestInfos()[i].questId))
                {
                    questinfo = msg.getQuestInfos()[i];
                    isaddtask = true;
                    break;
                }
            }
            CommonQuestDic.Clear();
        }
        for (int i = 0; i < msg.getQuestInfos().Length; i++)
        {
            if (!CommonQuestDic.ContainsKey(msg.getQuestInfos()[i].questId))
            {
                CommonQuestDic.Add(msg.getQuestInfos()[i].questId, msg.getQuestInfos()[i]);
            }
            //ClientLog.Log("任务列表：" + msg.getQuestInfos()[i].questId + "  : " + msg.getQuestInfos()[i].questStatus);
        }
        for (int i = 0; i < notMainQuest.Count; i++)
        {
            if (!commonQuestDic.ContainsKey(notMainQuest[i].questId))
            {
                commonQuestDic.Add(notMainQuest[i].questId, notMainQuest[i]);
            }
        }

        //更新npc身上的任务
        UpdateNpcQuest();
        //更新任务列表
        dispatchChangeEvent(UPDATEQUESTLIST, null);
        if (isaddtask)
        {
            dispatchChangeEvent(MOVE_ACCEPT_TASK, questinfo);
        }
    }

    public void updateQuest(GCQuestUpdate msg)
    {//添加任务不使用更新消息，更新消息只更新状态
        updateOneQuest(msg.getQuestInfo());
    }

    public void updateOneQuest(QuestInfoData questinfo)
    {
        QuestInfoData questData;
        CommonQuestDic.TryGetValue(questinfo.questId, out questData);
        if (questinfo.questStatus == (int)QuestDefine.QuestStatus.FINISHED ||
            questinfo.questStatus == (int)QuestDefine.QuestStatus.GIVEUP)
        {
            QuestTemplate qtpl = QuestTemplateDB.Instance.getTemplate(questinfo.questId);
            if (questinfo.questStatus == (int)QuestDefine.QuestStatus.FINISHED)
            {
                if (qtpl.questType != (int) (QuestDefine.QuestType.QIRIMUBIAO))
                {
                    EffectUtil.Ins.PlayEffect("common_renwuwancheng", LayerConfig.MainUI, false, null,
                        new Vector3(0, 160, 0));
                }
            }
            if (qtpl != null)
            {
                if (qtpl.questType == (int)(QuestDefine.QuestType.QIRIMUBIAO))
                {
                    //七日目标任务完成后 不删除
                    if (questData != null)
                    {
                        CommonQuestDic[questinfo.questId] = questinfo;
                        //ClientLog.Log("增加任务：" + msg.getQuestInfo().questId + "  : " + msg.getQuestInfo().questStatus);
                    }
                    else
                    {
                        commonQuestDic.Add(questinfo.questId, questinfo);                        
                    }
                }
                else
                {
                    deleteQuest(questinfo.questId);
                }
            }
            //ClientLog.Log("删除任务：" + msg.getQuestInfo().questId);
        }
        else
        {
            if (questData != null)
            {
                CommonQuestDic[questinfo.questId] = questinfo;
                //ClientLog.Log("增加任务：" + msg.getQuestInfo().questId + "  : " + msg.getQuestInfo().questStatus);
            }
            else
            {
                commonQuestDic.Add(questinfo.questId, questinfo);
            }
        }
        //检查任务是否已经完成
        checkAutoQuestFinish();
        //更新npc身上的任务
        UpdateNpcQuest();
        //更新任务列表
        dispatchChangeEvent(UPDATEQUESTLIST, null);
        if (questData == null)
        {
            dispatchChangeEvent(MOVE_ACCEPT_TASK, questinfo);
        }
    }

    public void deleteQuest(int questId)
    {
        QuestInfoData questData;
        CommonQuestDic.TryGetValue(questId, out questData);
        if (questData != null)
        {
            CommonQuestDic.Remove(questId);
        }
        QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questId);
        bool hasStoryId = false;
        if (qt.questType == (int)QuestDefine.QuestType.MAIN && qt.storyId != 0)
        {
            //有对话剧情
            hasStoryId = true;
            JuQingManager.Ins.StartJuQing(qt.storyId,qt.videoStoryId);
        }
        if (!hasStoryId&&
            qt.questType == (int)QuestDefine.QuestType.MAIN && qt.videoStoryId != 0)
        {
            //没有对话剧情,有动画剧情
            StoryManager.ins.EnterStory(qt.videoStoryId);
        }
        //删除一个任务后，更新任务列表
        //dispatchChangeEvent("updateQuest", null);
        //更新npc身上的任务

        if (questId == 10001)//ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.GUIDE_QUESTID)
        {//任务引导没完成之前，每个任务都需要引导
            GuideManager.Ins.StartGuide(GuideIdDef.QuestNavigat);
        }
    }

    public void AcceptQuestSuccess(GCAcceptQuest msg)
    {
        QuestTemplate questTpl = QuestTemplateDB.Instance.getTemplate(msg.getQuestId());
        if (questTpl.questType == 1)
        {
            DataReport.Instance.Game_MainLineQuestAccept(questTpl.Id);
        }
    }

    public void FinishQuestSuccess(GCFinishQuest msg)
    {
    }

    /// <summary>
    /// 获得一个任务的数据
    /// </summary>
    /// <param name="questId"></param>
    /// <returns></returns>
    public QuestInfoData GetQuestInfoById(int questId)
    {
        QuestInfoData questData=null;
        if (CommonQuestDic!=null) CommonQuestDic.TryGetValue(questId, out questData);
        return questData;
    }
    /// <summary>
    /// 根据任务类型 获得 任务
    /// </summary>
    /// <param name="questtype"></param>
    /// <returns></returns>
    public QuestInfoData GetQuestInfoByType(QuestDefine.QuestType questtype, QuestDefine.QuestStatus queststatus)
    {
        QuestInfoData questinfodata = null;
        foreach (KeyValuePair<int, QuestInfoData> pair in commonQuestDic)
        {
            QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(pair.Key);
            if (qt.questType == (int)questtype && pair.Value.questStatus == (int)(queststatus))
            {
                questinfodata = pair.Value;
                break;
            }
        }
        return questinfodata;
    }
    /// <summary>
    /// 根据任务类型 获得 任务列表
    /// </summary>
    /// <param name="questtype"></param>
    /// <returns></returns>
    public List<QuestInfoData> GetQuestListByType(QuestDefine.QuestType questtype)
    {
        List<QuestInfoData> questinfodata = new List<QuestInfoData>();
        foreach (KeyValuePair<int, QuestInfoData> pair in commonQuestDic)
        {
            QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(pair.Key);
            if (qt.questType == (int)questtype)
            {
                questinfodata.Add(pair.Value);
            }
        }
        return questinfodata;
    }
    /// <summary>
    /// 获得任务是否为 挑战npc的任务
    /// </summary>
    /// <param name="qt"></param>
    /// <returns></returns>
    public static bool IsQuestFightNpc(QuestTemplate qt)
    {
        if (qt.specialDestination[0].type == 1 && qt.specialDestination[0].param1st == "2")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 任务的排序
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int SortQuestList(QuestInfoData a, QuestInfoData b)
    {
        QuestTemplate qta = QuestTemplateDB.Instance.getTemplate(a.questId);
        QuestTemplate qtb = QuestTemplateDB.Instance.getTemplate(b.questId);
        //由大到小，有排序id在没排序id的前面
        if (qta.questType > qtb.questType)
        {
            return 1;
        }
        return 0;
    }
    /// <summary>
    /// 获得 七日目标 任务是否有奖励可以领取
    /// </summary>
    /// <returns></returns>
    public List<int> hasQiRiMuBiaoRewardDay()
    {
        //有能领取奖励的天
        List<int> rewarddays = new List<int>();
        int minHasRewardDay = int.MaxValue;
        int loginDay = PlayerModel.Ins.HasLoginDays;
        for (int i=0;i<7;i++)
        {
            List<int> questidList = Day7TargetTemplateDB.Instance.GetQuestIdListByDay(i + 1);
            List<QuestInfoData> questlist = GetQuestListByType(QuestDefine.QuestType.QIRIMUBIAO);
            for (int j = 0; j < questlist.Count; j++)
            {
                if (questlist[j].questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
                {
                    if (questidList.Contains(questlist[j].questId))
                    {
                        if (loginDay>=(i+1))
                        {
                            if (!rewarddays.Contains(i))
                            {
                                rewarddays.Add(i);
                            }
                            if (i < minHasRewardDay)
                            {
                                minHasRewardDay = i;
                            }
                        }
                    }
                }
            }
        }
        if (rewarddays.Count>0)
        {
            int lastday = rewarddays[rewarddays.Count - 1];
            rewarddays[0] = ((minHasRewardDay == int.MaxValue) ? 0 : minHasRewardDay);
            if (!rewarddays.Contains(lastday))
            {
                rewarddays.Add(lastday);
            }
        }
        return rewarddays;
    }

    #endregion 


    #region npc身上的任务

    /// <summary>
    /// 更新npc身上的任务列表
    /// </summary>
    public void UpdateNpcQuest()
    {
        //更新任务控制的npc的显示
        ZoneNPCManager.Ins.UpdateNpcVisible();
        //清空npc身上的任务
        ZoneNPCManager.Ins.ClearAllNpcQuest();
        foreach (KeyValuePair<int, QuestInfoData> pair in CommonQuestDic)
        {
            QuestTemplate questData = QuestTemplateDB.Instance.getTemplate(pair.Value.questId);
            switch (pair.Value.questStatus)
            {
                case (int)QuestDefine.QuestStatus.ACCEPTED:
                    //已接
                    if (IsQuestFightNpc(questData))
                    {
                        //任务为：与npc战斗
                        string[] pathArr = LinkParse.Ins.Parse(questData.pathStr);
                        if (pathArr != null && int.Parse(pathArr[0]) == LinkTypeDef.FindNPC)
                        {
                            int npcid = int.Parse(pathArr[2]);
                            AddQuestToNPC(pair.Value, npcid);
                        }
                    }
                    else
                    {
                        AddQuestToNPC(pair.Value, questData.endNpc);
                    }
                    break;
                case (int)QuestDefine.QuestStatus.CAN_FINISH:
                    //可交付
                    AddQuestToNPC(pair.Value, questData.endNpc);
                    break;
                case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                    //可接
                    AddQuestToNPC(pair.Value, questData.startNpc);
                    break;
                case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                    //不可接
                    AddQuestToNPC(pair.Value, questData.startNpc);
                    break;
                default:
                    ClientLog.Log("pair.Value.questStatus！" + pair.Value.questStatus);
                    break;
            }
        }
    }

    private void AddQuestToNPC(QuestInfoData questInfoData, int npcid)
    {
        if (npcid != 0)
        {
            //检查是否是战斗NPC
            ZoneNPC zoneNpc = ZoneNPCManager.Ins.GetNpc(npcid);
            if (zoneNpc != null)
            {
                zoneNpc.AddQuest(questInfoData.questId);
            }
        }
    }

    #endregion


    #region 自动做任务寻路

    /// <summary>
    /// 自动做的任务数据
    /// </summary>
    public int AutoQuestId { get; set; }
    /// <summary>
    /// 等待
    /// </summary>
    private RTimer waitingTimer;
    private ChuBaoModel chubaoModel;
    private BaoTuModel baotuModel;
    private static QuestModel _ins;
    public static QuestModel Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new QuestModel();
            }
            return _ins;
        }
    }
    /// <summary>
    /// 检查任务是否已经完成
    /// </summary>
    private void checkAutoQuestFinish()
    {
        if (AutoQuestId == 0)
        {
            if (!TongTianTaModel.IsGuajiing)
            {
                StopAutoQuest();
            }
            return;
        }
        QuestInfoData questinfodata = GetQuestInfoById(AutoQuestId);
        QuestTemplate qtpl = QuestTemplateDB.Instance.getTemplate(AutoQuestId);
        if (qtpl == null)
        {
            //任务数据不存在
            StopAutoQuest();
            return;
        }
        switch (qtpl.questType)
        {
            case (int)QuestDefine.QuestType.MAIN:
            case (int)QuestDefine.QuestType.SUBMAIN:
            case(int)QuestDefine.QuestType.XIANSHISHAGUAI:
            case (int)QuestDefine.QuestType.XIANSHINPC:
                if (questinfodata == null || (questinfodata.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
                    || (questinfodata.questStatus == (int)QuestDefine.QuestStatus.FINISHED))
                {
                    StopAutoQuest();
                }
                break;
            case (int)QuestDefine.QuestType.JIUGUAN:
            case (int)QuestDefine.QuestType.YUNLIANG:
            case (int)QuestDefine.QuestType.HUAN:
                if (questinfodata == null)
                {
                    StopAutoQuest();
                }
                break;
            case (int)QuestDefine.QuestType.CHUBAOANLIANG:
                if (chubaoModel == null) { chubaoModel = ChuBaoModel.Ins; }
                if (chubaoModel.hasFinishedChuBao)
                {
                    //今日已经完成除暴任务
                    StopAutoQuest();
                }
                break;
            case (int)QuestDefine.QuestType.BAOTU:
                if (baotuModel == null) { baotuModel = BaoTuModel.Ins; }
                if (baotuModel.hasFinishedBaoTu)
                {
                    //今日已经完成除暴任务
                    StopAutoQuest();
                }
                break;
            case (int)QuestDefine.QuestType.BANGPAI:
                if (CorpsTaskModel.instance.haveFinishCorpsTask)
                {
                    StopAutoQuest();
                }
                break;
        }
    }

    public void StartAutoQuest(QuestInfoData questinfo)
    {
        if (ZoneModel.ins.CheckCanMoveFreely())
        {
            stopWaitTimer();
            AutoMaticManager.Ins.CurAutoMaticType = AutoMaticManager.AutoMaticType.AutoQuest;
            AutoQuestId = questinfo.questId;
            QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questinfo.questId);
            LinkParse.Ins.doLink(qt.pathStr);
        }
    }

    public void StopAutoQuest()
    {
        stopWaitTimer();
        AutoMaticManager.Ins.CurAutoMaticType = AutoMaticManager.AutoMaticType.None;
        AutoQuestId = 0;
        LinkParse.Ins.ClearLink();
        EffectUtil.Ins.RemoveEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME);
    }

    public void DoUpdate()
    {
        if (AutoMaticManager.Ins.CurAutoMaticType == AutoMaticManager.AutoMaticType.AutoQuest &&
            AutoQuestId != 0)
        {
            //正在自动做任务
            QuestInfoData questinfodata = GetQuestInfoById(AutoQuestId);
            QuestTemplate qtpl = QuestTemplateDB.Instance.getTemplate(AutoQuestId);
            if (qtpl == null)
            {
                StopAutoQuest();
            }
            switch (qtpl.questType)
            {
                case (int)QuestDefine.QuestType.MAIN:
                    checkAutoQuestContinue(questinfodata, qtpl);
                    break;
                case (int)QuestDefine.QuestType.SUBMAIN:
                    break;
                case (int)QuestDefine.QuestType.JIUGUAN:
                case (int)QuestDefine.QuestType.YUNLIANG:
                case (int)QuestDefine.QuestType.HUAN:
                    checkAutoQuestContinue(questinfodata, qtpl);
                    break;
                case (int)QuestDefine.QuestType.CHUBAOANLIANG:
                case (int)QuestDefine.QuestType.BAOTU:
                case (int)QuestDefine.QuestType.BANGPAI:
                case (int)QuestDefine.QuestType.XIANSHISHAGUAI:
                case (int)QuestDefine.QuestType.XIANSHINPC:
                    checkAutoQuestContinue(questinfodata, qtpl);
                    if (questinfodata == null)
                    {
                        if (waitingTimer == null)
                        {
                            waitingTimer = TimerManager.Ins.createTimer(1000, 3000, null, onTimerEnd);
                            waitingTimer.start();
                            //ClientLog.LogError("开始倒计时!");
                        }
                        else
                        {
                            if (!waitingTimer.IsRunning)
                            {
                                //上一个 除暴、宝图 任务已经完成，自动切换到下一个
                                QuestInfoData nextQuest = GetQuestInfoByType((QuestDefine.QuestType)(qtpl.questType), QuestDefine.QuestStatus.ACCEPTED);
                                if (nextQuest != null)
                                {
                                    StartAutoQuest(nextQuest);
                                }
                                //ClientLog.LogError("上一个 除暴、宝图 任务已经完成，自动切换到下一个!");
                                waitingTimer = null;
                            }
                        }
                    }
                    break;
            }
        }
    }

    private void onTimerEnd(RTimer rtimer)
    {
        waitingTimer.stop();
    }

    private void stopWaitTimer()
    {
        if (waitingTimer != null)
        {
            waitingTimer.stop();
            waitingTimer = null;
        }
    }

    /// <summary>
    /// 检查是否继续自动做任务
    /// </summary>
    /// <param name="questinfodata"></param>
    /// <param name="qtpl"></param>
    private void checkAutoQuestContinue(QuestInfoData questinfodata, QuestTemplate qtpl)
    {
        if (questinfodata != null)
        {
            ZoneCharacter player = ZoneCharacterManager.ins.self;
            if (player != null && player.displayModel != null
                && (player.curBehavType == ZoneCharacterBehavType.NONE || player.curBehavType == ZoneCharacterBehavType.IDLE)
                && StateManager.Ins.getCurState().state == StateDef.zoneState)
            {
                if (questinfodata.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED &&
                    LinkParse.Ins.CurLinkType == 0)
                {
                    QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questinfodata.questId);
                    string[] pathArr = LinkParse.Ins.Parse(qt.pathStr);
                    if (pathArr != null && pathArr.Length > 1)
                    {
                        switch (int.Parse(pathArr[0]))
                        {
                            case LinkTypeDef.FindMonster:
                                //ClientLog.LogError("重新开始自动任务,其他类型不需要重新开始，否则会在等待玩家操作的时候一直 重新开始!");
                                //重新开始自动任务,其他类型不需要重新开始，否则会在等待玩家操作的时候一直 重新开始
                                StartAutoQuest(questinfodata);
                                break;
                        }
                    }
                }
                if (questinfodata.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
                {
                    if ((qtpl.questType == (int)QuestDefine.QuestType.JIUGUAN)
                        || (qtpl.questType == (int)QuestDefine.QuestType.CHUBAOANLIANG)
                        || (qtpl.questType == (int)QuestDefine.QuestType.BAOTU)
                        || (qtpl.questType == (int)QuestDefine.QuestType.HUAN)
                        )//|| (qtpl.questType == (int)QuestDefine.QuestType.YUNLIANG)
                    {
                        //自动完成的酒馆、除暴、宝图 任务，再引导到npc那儿去
                        //ClientLog.LogError("自动完成的酒馆、除暴、宝图 任务，再引导到npc那儿去!");
                        LinkParse.Ins.doLink(LinkTypeDef.FindNPC + "-" + qtpl.endNpcMapId + "-" + qtpl.endNpc);
                    }
                }
            }
        }
        if (questinfodata == null && LinkParse.Ins.CurLinkType != 0)
        {
            //停止超链接，下一个等待接收的任务还没来呢
            LinkParse.Ins.ClearLink();
        }
    }

    #endregion

    private bool IsMainOrSubQuest(QuestTemplate questData)
    {
        return (questData.questType == (int)QuestDefine.QuestType.MAIN || (questData.questType == (int)QuestDefine.QuestType.SUBMAIN));
    }

    public bool HasMainOrSubQuest()
    {
        List<QuestInfoData> mainList = GetQuestListByType(QuestDefine.QuestType.MAIN);
        List<QuestInfoData> submainList = GetQuestListByType(QuestDefine.QuestType.SUBMAIN);
        return mainList.Count > 0 || submainList.Count > 0;
    }

    public override void Destroy()
    {
        _ins = null;
        if (commonQuestDic != null)
        {
            commonQuestDic.Clear();
            commonQuestDic = null;
        }
    }
}
