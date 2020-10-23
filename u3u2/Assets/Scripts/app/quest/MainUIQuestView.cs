using System.Collections.Generic;
using app.baotu;
using app.chubao;
using app.db;
using app.jiuguan;
using app.mozufuben;
using app.net;
using app.utils;
using app.yunliang;
using app.zone;
using UnityEngine;
using UnityEngine.UI;
using app.team;
using app.report;
using app.ringtask;

public class MainUIQuestView
{
    private MainUIQuestUI UI;
    private bool lastQuestToggleIsOn = false;
    private bool mTabJustChangedToTeamToggle = false;
    private List<GameUUButton> questItemList;
    private List<Text> questTextList;
    private List<Image> questZhanList;

    /// <summary>
    /// int:questId，GameObject：quest显示对象
    /// </summary>
    private Dictionary<GameObject, int> questObjDic;

    public QuestModel questModel;
    public BaoTuModel baotuModel;
    public ChuBaoModel chubaoModel;
    public JiuGuanRenWuModel jiuguanModel;
    public YunLiangModel yunliangModel;
    //移动任务导航滚动条的计时器
    private RTimer rtimer;
    //需要移动任务导航滚动条的任务
    private QuestInfoData movequestinfo;

    public MainUIQuestView(MainUIQuestUI mainui)
    {
        UI = mainui;

        questModel = QuestModel.Ins;
        baotuModel = BaoTuModel.Ins;
        chubaoModel = ChuBaoModel.Ins;
        jiuguanModel = JiuGuanRenWuModel.Ins;
        yunliangModel = YunLiangModel.Ins;

        questModel.addChangeEvent(QuestModel.UPDATEQUESTLIST, updateQuestList);
        questModel.addChangeEvent(QuestModel.MOVE_ACCEPT_TASK, movequest);
        EventCore.addRMetaEventListener(GuideManager.Ins.StartGuideEvent, showGuide);
        EventCore.addRMetaEventListener(GuideManager.Ins.EndGuideEvent, showGuide);
        UI.questTabButtonGroup.TabChangeHandler = TabChangeHandler;
        lastQuestToggleIsOn = true;
        UI.questTabButtonGroup.SetIndexWithCallBack(0);
        //UI.questTabButtonGroup.gameObject.GetComponent<ToggleGroup>().NotifyToggleOn(UI.questToggle);
        EventTriggerListener.Get(UI.questToggle.gameObject).onClick = clickQuestToggle;
        EventTriggerListener.Get(UI.teamToggle.gameObject).onClick = clickTeamToggle;

        /// <summary>
        /// 原始的一个QuestItem，后面需要都用这个对象去实例化一个，这个不能删
        /// </summary>
        UI.questItem.gameObject.SetActive(false);
        questItemList = new List<GameUUButton>();
        questTextList = new List<Text>();
        questZhanList = new List<Image>();
        questObjDic = new Dictionary<GameObject, int>();
        updateQuestList();
    }

    private void TabChangeHandler(int currentTabIndex)
    {
        if (currentTabIndex != 0)
        {
            lastQuestToggleIsOn = UI.questToggle.isOn;
        }

        if (currentTabIndex == 0)
        {
            UI.questScroll.SetActive(true);
            UpdateTeamPanelVisible();
            mTabJustChangedToTeamToggle = false;

        }
        else if (currentTabIndex == 1)
        {
            UI.questScroll.SetActive(false);
            UpdateTeamPanelVisible();
            mTabJustChangedToTeamToggle = true;
        }
    }

    private void clickQuestToggle(GameObject go)
    {
        DataReport.Instance.Game_SetEvent("c_touch", "mainui", FunctionIdDef.RENWU.ToString());

        if (lastQuestToggleIsOn && UI.questToggle.isOn)
        {
//任务页签开启，并且点击了
            WndManager.open(GlobalConstDefine.QuestView_Name);
        }
        lastQuestToggleIsOn = UI.questToggle.isOn;
    }

    private GameUUButton GetOneQuestItem()
    {
        return GameObject.Instantiate(UI.questItem);
    }

    private void SetQuestItemInfo(GameObject questItem, QuestInfoData questinfo, Text txt, Image zhanimage)
    {
        QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questinfo.questId);
        if (txt != null)
        {
            string str = "";
            switch (questinfo.questStatus)
            {
                case (int) QuestDefine.QuestStatus.CAN_FINISH:
                    str = ColorUtil.getColorText(ColorUtil.ORANGE, qt.title);
                    if (qt.questType == (int) QuestDefine.QuestType.JIUGUAN
                        || qt.questType == (int) QuestDefine.QuestType.CHUBAOANLIANG
                        || qt.questType == (int) QuestDefine.QuestType.BAOTU
                        || qt.questType == (int) QuestDefine.QuestType.YUNLIANG
                        || qt.questType == (int) QuestDefine.QuestType.BANGPAI
                        || qt.questType == (int)QuestDefine.QuestType.HUAN)
                    {
                        str += QuestDefine.GetQuestStatusName(questinfo.questStatus);
                    }
                    str += "\n" + qt.finishDesc;
                    break;
                case (int) QuestDefine.QuestStatus.ACCEPTED:
                    str = ColorUtil.getColorText(ColorUtil.ORANGE, qt.title);
                    if (qt.questType == (int) QuestDefine.QuestType.JIUGUAN)
                    {
                        str += "(" + jiuguanModel.PanelData.getFinishTimes() + "/" +
                               jiuguanModel.PanelData.getTotalTimes() + ")";
                    }
                    if (qt.questType == (int) QuestDefine.QuestType.CHUBAOANLIANG)
                    {
                        str += "(" + chubaoModel.PanelData.getFinishTimes() + "/" +
                               chubaoModel.PanelData.getTotalTimes() + ")";
                    }
                    if (qt.questType == (int) QuestDefine.QuestType.BAOTU)
                    {
                        str += "(" + baotuModel.PanelData.getFinishTimes() + "/" + baotuModel.PanelData.getTotalTimes() +
                               ")";
                    }
                    if (qt.questType == (int) QuestDefine.QuestType.YUNLIANG)
                    {
                        str += "(" + yunliangModel.PanelData.getFinishTimes() + "/" +
                               yunliangModel.PanelData.getTotalTimes() + ")";
                    }
                    if (qt.questType == (int) QuestDefine.QuestType.BANGPAI)
                    {
                        if (CorpsTaskModel.instance.openCorpsTaskPanel != null)
                        {
                            str += "(" + CorpsTaskModel.instance.openCorpsTaskPanel.getFinishTimes() + "/" +
                                   CorpsTaskModel.instance.openCorpsTaskPanel.getTotalTimes() + ")";
                        }
                    }
                    if (qt.questType == (int)QuestDefine.QuestType.PUTONGMOZU
                        || qt.questType == (int)QuestDefine.QuestType.KUNNANMOZU)
                    {
                        if (MoZuFubenModel.Ins.MozuData != null)
                        {
                            for (int i=0;i<MoZuFubenModel.Ins.MozuData.getQuestPanelInfo().Length;i++)
                            {
                                QuestPanelInfo qi = MoZuFubenModel.Ins.MozuData.getQuestPanelInfo()[i];
                                if (qi.questType==qt.questType)
                                {
                                    str += "(" + qi.finishTimes + "/" +qi.totalTimes + ")";
                                    break;
                                }
                            }
                        }
                    }
                    if (qt.questType == (int)QuestDefine.QuestType.HUAN)
                    {
                        //环任务接受描述
                        str = "第" + ((RingTaskModel.Ins.RingTaskInfo.getFinishTimes()-1) / RingTaskModel.g_onehuancount+1) + "轮" + str;
                        str = ColorUtil.getColorText(ColorUtil.ORANGE, str);
                        str += "(" + ((RingTaskModel.Ins.RingTaskInfo.getFinishTimes()-1)%RingTaskModel.g_onehuancount+1) + "/" +
                               RingTaskModel.g_onehuancount + ")";
                    }
                    str += "\n" + qt.finishDesc;
                    str += "(" + questinfo.destGotNum + "/" + questinfo.destReqNum + ")";
                    break;
                case (int) QuestDefine.QuestStatus.CAN_ACCEPT:
                    str = ColorUtil.getColorText(ColorUtil.ORANGE, qt.title) +
                          QuestDefine.GetQuestStatusName(questinfo.questStatus);
                    str += "\n" + qt.finishDesc;
                    break;
                case (int) QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                    str = ColorUtil.getColorText(ColorUtil.RED, qt.title);
                    str += "\n" + qt.requireDesc;
                    break;
                default:
                    break;
            }

            //战斗标示
            if (zhanimage != null)
            {
                zhanimage.gameObject.SetActive(QuestDefine.IsFightQuest(qt.specialDestination[0]));
            }
            txt.text = str;
        }
        else
        {
            ClientLog.LogError("txt is null!!!");
        }
    }

    /// <summary>
    /// 更新正在做的任务列表
    /// </summary>
    public void updateQuestList(RMetaEvent e = null)
    {
        int k = 0;
        List<KeyValuePair<int, QuestInfoData>> infos =
            new List<KeyValuePair<int, QuestInfoData>>(questModel.CommonQuestDic);
        infos.Sort(delegate(KeyValuePair<int, QuestInfoData> x, KeyValuePair<int, QuestInfoData> y)
        {
            QuestTemplate xTpl = QuestTemplateDB.Instance.getTemplate(x.Value.questId);
            QuestTemplate yTpl = QuestTemplateDB.Instance.getTemplate(y.Value.questId);
            return xTpl.questType.CompareTo(yTpl.questType);

        });

        for (int i = 0; i < infos.Count; i++)
        {
            QuestTemplate qtpl = QuestTemplateDB.Instance.getTemplate(infos[i].Value.questId);
            if (qtpl.questType == (int) QuestDefine.QuestType.QIRIMUBIAO)
            {
                //过滤七日目标任务
                continue;
            }
            switch (infos[i].Value.questStatus)
            {
                case (int) QuestDefine.QuestStatus.ACCEPTED:
                case (int) QuestDefine.QuestStatus.CAN_FINISH:
                case (int) QuestDefine.QuestStatus.CAN_ACCEPT:
                case (int) QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                    GameUUButton questitem;
                    Text txt;
                    Image zhanImage = null;
                    if (k < questItemList.Count)
                    {
                        questitem = questItemList[k];
                        questitem.gameObject.SetActive(true);
                        txt = questTextList[k];
                        zhanImage = questZhanList[k];
                    }
                    else
                    {
                        questitem = GetOneQuestItem();
                        questItemList.Add(questitem);
                        questitem.gameObject.SetActive(true);
                        txt = questitem.GetComponentInChildren<Text>();
                        zhanImage = questitem.transform.Find("Image").GetComponent<Image>();
                        questZhanList.Add(zhanImage);
                        if (txt == null)
                        {
                            ClientLog.LogError("!!!!~~~~~~~txt is null~");
                        }
                        questTextList.Add(txt);
                    }
                    questitem.transform.SetParent(UI.questGrid.transform);
                    SetQuestItemInfo(questitem.gameObject, infos[i].Value, txt, zhanImage);
                    questitem.transform.localScale = Vector3.one;
                    questitem.transform.SetAsLastSibling();

                    questitem.SetClickCallBack(clickQuestItem);
                    questObjDic[questitem.gameObject] = infos[i].Value.questId;

                    k++;
                    break;
            }
        }
        //GuideManager.Ins.StartGuide(GuideIdDef.QuestNavigat);
        //GuideManager.Ins.ShowGuide(GuideIdDef.QuestNavigat, 1, questItemList[0].gameObject);
        //销毁多余的
        if (questItemList.Count > k)
        {
            for (int i = k; i < questItemList.Count; i++)
            {
                GameObject.DestroyImmediate(questItemList[i].gameObject, true);
                questItemList[i] = null;
                questTextList[i] = null;
                questZhanList[i] = null;
            }
            questTextList.RemoveRange(k, questItemList.Count - k);
            questItemList.RemoveRange(k, questItemList.Count - k);
            questZhanList.RemoveRange(k, questZhanList.Count - k);
        }
    }

    private void movequest(RMetaEvent e = null)
    {
        QuestInfoData questinfo = e.data as QuestInfoData;
        if (questinfo != null)
        {
            this.movequestinfo = questinfo;
        }
        if (rtimer == null)
        {
            rtimer = TimerManager.Ins.createTimer(100, 200, null, MoveAcceptQuest);
            rtimer.start();
        }
        else if(!rtimer.IsRunning)
        {
            rtimer.Reset(100,300);
            rtimer.Restart();
        }
    }

/// <summary>
    /// 移动到新接任务处
    /// </summary>
    /// <param name="e"></param>
    private void MoveAcceptQuest(RTimer r)
    {
        if (movequestinfo == null)
        {
            return;
        }
        bool isexisted = false;
        int index = 0;
        int count = 0;
        foreach (GameObject go in questObjDic.Keys)
        {
            if (go != null)
            {
                if (questObjDic[go] == movequestinfo.questId)
                {
                    isexisted = true;
                }
                if(!isexisted)
                {
                    ++index;
                }
                ++count;
            }
        }
        if (count <= 3)
        {
            return;
        }
        if (!isexisted)
        {
            return;
        }

        float y = GetMovePosition(count, index, 275f, 100f);

        UI.questGrid.transform.localPosition = new Vector3(UI.questGrid.transform.localPosition.x, y, UI.questGrid.transform.localPosition.z);
    }

    /// <summary>
    /// 获取移动到列表中某一成员位置处
    /// </summary>
    /// <param name="count">列表成员总数量</param>
    /// <param name="index">选中成员下标从0开始</param>
    /// <param name="showhight">显示列表的高度或宽度</param>
    /// <param name="onehight">每一成员所占高度或宽度</param>
    /// <returns></returns>
    public static float GetMovePosition(int count, int index, float showhight, float onehight,float startposition=0f)
    {
        ///列表总显示高度或宽度小于总显示高度或宽度///
        if (count * onehight <= showhight)
        {
            return startposition;
        }
        else
        {
            ///当前位置到结束的位置大于总显示的高度或宽度///
            if ((count - index) * onehight >= showhight)
            {
                return startposition + index * onehight;
            }
            else
            {
                ///剩余显示高度或宽度小于总显示高度或宽度，需要移动缺少的高度或宽度///
                return startposition + index * onehight - (showhight - (count - index) * onehight);
            }
        }
    }

    private void clickQuestItem(GameObject go)
    {
        int questid=-1;
        questObjDic.TryGetValue(go, out questid);
        if (GuideManager.Ins.CurrentGuideId==GuideIdDef.QuestNavigat&&
            questid == 10004)//ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.GUIDE_QUESTID)
        {
            GuideCGHandler.sendCGFinishGuide((int)GuideIdDef.QuestNavigat);
        }
        if (app.fuben.FubenModel.IsInFuBen())
        {
            ZoneBubbleManager.ins.BubbleSysMsg("副本中不能使用任务导航");
            return;
        }
        
        if (questid != -1)
        {
            QuestInfoData questinfo = questModel.GetQuestInfoById(questid);
            QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questid);
            //停止自动寻路
            AutoMaticManager.Ins.StopAutoMatic();
            switch (questinfo.questStatus)
            {
                case (int)QuestDefine.QuestStatus.ACCEPTED:
                    //自动去做任务
                    questModel.StartAutoQuest(questinfo);
                    break;
                case (int)QuestDefine.QuestStatus.CAN_FINISH:
                    if (ZoneModel.ins.CheckCanMoveFreely())
                    {
                        LinkParse.Ins.doLink(LinkTypeDef.FindNPC + "-" + qt.endNpcMapId + "-" + qt.endNpc);
                    }
                    break;
                case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                    if (ZoneModel.ins.CheckCanMoveFreely())
                    {
                        LinkParse.Ins.doLink(LinkTypeDef.FindNPC + "-" + qt.startNpcMapId + "-" + qt.startNpc);
                    }
                    break;
                default:
                    break;
            }
        }
    }


    public void UpdateTeamPanelVisible()
    {
        if (UI.questTabButtonGroup.index == 1)
        {
            if (TeamModel.ins.myTeamMemberList != null)
            {
                UI.teammembers.SetActive(true);
                UI.noTeamPanel.SetActive(false);
                UI.autoMatchTeamPanel.SetActive(false);
            }
            else if (TeamModel.ins.teamApplyAuto != null && TeamModel.ins.teamApplyAuto.getIsAuto() == 1)
            {
                UI.teammembers.SetActive(false);
                UI.noTeamPanel.SetActive(false);
                UI.autoMatchTeamPanel.SetActive(true);
            }
            else
            {
                UI.teammembers.SetActive(false);
                UI.noTeamPanel.SetActive(true);
                UI.noTeamButton.SetClickCallBack(clickNoTeamBtn);
                UI.autoMatchTeamPanel.SetActive(false);

            }
        }
        else
        {
            UI.teammembers.SetActive(false);
            UI.noTeamPanel.SetActive(false);
            UI.autoMatchTeamPanel.SetActive(false);
        }
    }

    private void clickNoTeamBtn(GameObject go)
    {
        clickTeamToggle(go);
    }

    private void clickTeamToggle(GameObject go)
    {
        DataReport.Instance.Game_SetEvent("c_touch", "mainui", FunctionIdDef.DUIWU.ToString());

        if (!mTabJustChangedToTeamToggle || UI.noTeamPanel.activeSelf)
        {
            LinkParse.Ins.linkToFunc(FunctionIdDef.DUIWU);
          //  WndManager.open(GlobalConstDefine.TeamMainView_Name);
        }

        mTabJustChangedToTeamToggle = false;
    }

    public void Destroy()
    {
        EventCore.removeRMetaEventListener(GuideManager.Ins.StartGuideEvent, showGuide);
        EventCore.removeRMetaEventListener(GuideManager.Ins.EndGuideEvent, showGuide);

        questModel.removeChangeEvent(QuestModel.UPDATEQUESTLIST, updateQuestList);
        questModel.removeChangeEvent(QuestModel.MOVE_ACCEPT_TASK, movequest);
        if (UI != null)
        {
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }
        if (rtimer!=null)
        {
            rtimer.stop();
            rtimer = null;
        }
    }

    public void showGuide(RMetaEvent e)
    {
        if (e != null && e.data != null && ((GuideIdDef)e.data == GuideIdDef.QuestNavigat))
        {
            //if (e.type==GuideManager.Ins.EndGuideEvent)
            //{
            //    EventCore.removeRMetaEventListener(GuideManager.Ins.StartGuideEvent, showGuide);
            //    EventCore.removeRMetaEventListener(GuideManager.Ins.EndGuideEvent, showGuide);
            //    return;
            //}
            if (questItemList != null && questItemList.Count > 0)
            {
                if (!ZoneUI.ins.UI.questUI.questObj.gameObject.activeInHierarchy)
                {
                    ZoneUI.ins.clickShowQuest(null);
                }
                GuideManager.Ins.ShowGuide(GuideIdDef.QuestNavigat, 1, questItemList[0].gameObject);
            }
        }
    }

}
