using System;
using System.Collections.Generic;
using app.db;
using app.fuben;
using app.mozufuben;
using app.net;
using app.zone;
using UnityEngine;
using UnityEngine.UI;
using app.ringtask;
using app.utils;
using app.confirm;

namespace app.quest
{
    class QuestView : BaseWnd
    {
        //[Inject(ui = "questUI")]
        //public GameObject ui;
        public QuestUI UI;

        public QuestModel questModel;

        //任务类型
        private List<QuestMainToggleScript> mainToggleScriptList;
        //任务列表
        private List<QuestChildToggleScript> childToggleScriptList;

        //当前选择的任务数据
        private QuestInfoData currentQuestData;
        public QuestInfoData CurrentQuestData
        {
            get { return currentQuestData; }
            set { currentQuestData = value; }
        }

        public QuestView()
        {
            uiName = "questUI";
        }

        public override void initWnd()
        {
            base.initWnd();

            questModel = QuestModel.Ins;
            questModel.addChangeEvent(QuestModel.UPDATEQUESTLIST, updatePanel);

            UI = ui.AddComponent<QuestUI>();
            UI.Init();

            UI.CloseButton.SetClickCallBack(ClickClose);
            UI.tabButtonGroup.TabChangeHandler = changeTab;
            UI.tabButtonGroup.toggleList[1].gameObject.SetActive(false);


            /// <summary>
            /// 原始的两个，后面需要都用这个对象去实例化一个，这个不能删
            /// </summary>
            UI.QuestMainToggle.gameObject.SetActive(false);
            UI.QuestChildToggle.gameObject.SetActive(false);
            //放弃任务
            UI.GiveUpQuestButton.gameObject.SetActive(false);
            UI.GiveUpQuestButton.SetClickCallBack(GiveUpQuest);
            //马上去做任务
            UI.DoItButton.SetClickCallBack(doItButton);
            //任务类型的GameUUToggle列表
            int questTypeNum = Enum.GetNames(typeof(QuestDefine.QuestType)).GetLength(0) - 1;
            mainToggleScriptList = new List<QuestMainToggleScript>();
            UI.mainTabButtonGroup.ClearToggleList();
            for (int i = 0; i < questTypeNum; i++)
            {
                if ((i+1)==(int)QuestDefine.QuestType.QIRIMUBIAO)
                {//过滤七日目标任务
                    continue;
                }
                GameUUToggle toggle = GetOneMainQuestToggle();
                toggle.gameObject.SetActive(true);
                QuestMainToggleScript qmts = new QuestMainToggleScript(toggle);
                qmts.SetData((i + 1));
                mainToggleScriptList.Add(qmts);
                UI.mainTabButtonGroup.AddToggle(toggle);
                toggle.transform.SetParent(UI.toggleGrid.transform);
                toggle.transform.localScale = Vector3.one;
                toggle.transform.SetAsLastSibling();
            }
            UI.childTabButtonGroup.TabChangeHandler = SelectQuest;
            UI.childTabButtonGroup.ReSelected = true;

            UI.mainTabButtonGroup.TabChangeHandler = clickMainToggle;
            UI.mainTabButtonGroup.AllTabCloseHandler = allTabCloseHandler;
            //UI.mainTabButtonGroup.SetIndexWithCallBack(0);
            UI.tabButtonGroup.SetIndexWithCallBack(0);
        }

        private void allTabCloseHandler()
        {
            for (int i = 0; i < childToggleScriptList.Count; i++)
            {
                childToggleScriptList[i].UI.gameObject.SetActive(false);
            }
            clearInfo();
        }

        private void changeTab(int tabIndex)
        {
            updatePanel();
        }

        private void GiveUpQuest()
        {
            QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(currentQuestData.questId);
            switch (qt.questType)
            {
                case (int) (QuestDefine.QuestType.JIUGUAN):
                    PubtaskCGHandler.sendCGGiveUpPubtask();
                    break;
                case (int) (QuestDefine.QuestType.CHUBAOANLIANG):
                    ThesweeneytaskCGHandler.sendCGGiveUpThesweeneytask();
                    break;
                case (int) (QuestDefine.QuestType.BAOTU):
                    TreasuremapCGHandler.sendCGGiveUpTreasuremap();
                    break;
                case (int) (QuestDefine.QuestType.YUNLIANG):
                    ForagetaskCGHandler.sendCGGiveUpForagetask();
                    break;
                case (int) (QuestDefine.QuestType.BANGPAI):
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, "是否确认放弃该帮派任务，放弃后不会返还任务次数。", delegate(RMetaEvent e)
                    {
                        CorpstaskCGHandler.sendCGGiveUpCorpstask();
                    }, null);
                    break;
                case (int) (QuestDefine.QuestType.XIANSHINPC):
                    TimelimitCGHandler.sendCGGiveUpTlNpc();
                    break;
                case (int) (QuestDefine.QuestType.XIANSHISHAGUAI):
                    TimelimitCGHandler.sendCGGiveUpTlMonster();
                    break;
                case (int)(QuestDefine.QuestType.PUTONGMOZU):
                    SiegedemonCGHandler.sendCGGiveUpSiegedemontask(MoZuFubenModel.Ins.MoZuFuBenType_NORMAL);
                    break;
                case (int)(QuestDefine.QuestType.KUNNANMOZU):
                    SiegedemonCGHandler.sendCGGiveUpSiegedemontask(MoZuFubenModel.Ins.MoZuFuBenType_HARD);
                    break;
                case (int)(QuestDefine.QuestType.HUAN):
                    //放弃环任务
                    string tishi = StringUtil.Assemble(LangConstant.HUAN_GIVE_UP, new string[1] { (RingTaskModel.Ins.RingTaskInfo.getGiveUpTotalTimes() - RingTaskModel.Ins.RingTaskInfo.getGiveUpTimes()).ToString() });
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, tishi, OkGiveUpHuan, null);
                    break;
                default:
                    QuestCGHandler.sendCGGiveUpQuest(currentQuestData.questId);
                    break;
            }
            if (currentQuestData != null && QuestModel.Ins.AutoQuestId == currentQuestData.questId)
            {
                QuestModel.Ins.StopAutoQuest();
            }
        }

        private void OkGiveUpHuan(RMetaEvent e)
        {
            RingtaskCGHandler.sendCGGiveUpRingtask();
        }

        private void doItButton()
        {
            Text txt = UI.DoItButtonText;
            if (txt != null)
            {
                QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(currentQuestData.questId);
                switch (txt.text)
                {
                    case "接受任务":
                        if (qt.questType == (int)QuestDefine.QuestType.HUAN)
                        {
                            RingtaskCGHandler.sendCGRingtaskAccept();
                        }
                        else
                        {
                            QuestCGHandler.sendCGAcceptQuest(currentQuestData.questId);
                        }
                        break;
                    case "完成任务":
                        if (ZoneModel.ins.CheckCanMoveFreely())
                        {
                            //停止自动寻路
                            AutoMaticManager.Ins.StopAutoMatic();
                            LinkParse.Ins.doLink(LinkTypeDef.FindNPC + "-" + qt.endNpcMapId + "-" + qt.endNpc);
                        }
                        break;
                    case "马上去做":
                        if (app.fuben.FubenModel.IsInFuBen())
                        {
                            ZoneBubbleManager.ins.BubbleSysMsg("副本中不能使用任务导航");
                            return;
                        }
                        questModel.StartAutoQuest(currentQuestData);
                        break;
                    case "放弃任务":
                        GiveUpQuest();
                        break;
                }
            }
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            updatePanel();
            app.main.GameClient.ins.OnBigWndShown();
        }

        private void clickMainToggle(int tab)
        {
            updatePanel();
        }

        /// <summary>
        /// 选择任务类型 后 刷新当前任务列表
        /// </summary>
        /// <param name="t"></param>
        private void updateQuestList()
        {
            if (childToggleScriptList == null)
            {
                childToggleScriptList = new List<QuestChildToggleScript>();
            }
            //检查任务类型下是否有任务，没有则隐藏任务类型Toggle
            for (int i = 0; i < mainToggleScriptList.Count; i++)
            {
                mainToggleScriptList[i].UI.gameObject.SetActive(true);
            }
            int siblingIndex = 2 + (UI.mainTabButtonGroup.index != -1 ? UI.mainTabButtonGroup.index : 0);
            UI.childTabButtonGroup.ClearToggleList();

            //先全部放到最后面
            for (int i = 0; i < childToggleScriptList.Count; i++)
            {
                if (childToggleScriptList[i].UI)
                {
                    childToggleScriptList[i].UI.gameObject.SetActive(false);
                    childToggleScriptList[i].UI.transform.SetAsLastSibling();
                }
            }
            List<int> statusList = new List<int>();
            if (UI.tabButtonGroup.index == 0)
            {//已接
                statusList.Add((int)QuestDefine.QuestStatus.ACCEPTED);
                statusList.Add((int)QuestDefine.QuestStatus.CAN_FINISH);
            }
            else
            {//未接
                statusList.Add((int)QuestDefine.QuestStatus.CAN_ACCEPT);
                statusList.Add((int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT);
            }
            //检查每个任务类型下是否有任务
            Dictionary<int, int> questNumPerType = new Dictionary<int, int>();
            //当前任务类型下的任务计数
            int j = 0;
            foreach (KeyValuePair<int, QuestInfoData> pair in questModel.CommonQuestDic)
            {
                if (statusList.IndexOf((int)pair.Value.questStatus) == -1)
                {
                    continue;
                }
                QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(pair.Value.questId);
                if (questNumPerType.ContainsKey(qt.questType))
                {
                    questNumPerType[qt.questType]++;
                }
                else
                {
                    questNumPerType.Add(qt.questType, 1);
                }
                if (qt.questType == GetCurrentQuestType())
                {
                    //当前选择的 大类（即 任务类型）
                    QuestChildToggleScript qmts;
                    if (j < childToggleScriptList.Count)
                    {
                        qmts = childToggleScriptList[j];
                    }
                    else
                    {
                        qmts = new QuestChildToggleScript(GetOneChildQuestToggle());
                        qmts.UI.gameObject.SetActive(true);
                        childToggleScriptList.Add(qmts);
                    }
                    qmts.SetData(pair.Value);
                    UI.childTabButtonGroup.AddToggle(qmts.UI);
                    qmts.UI.transform.SetParent(UI.toggleGrid.transform);
                    qmts.UI.transform.localScale = Vector3.one;
                    qmts.UI.transform.SetSiblingIndex(siblingIndex + j + 1);
                    j++;
                }
            }
            //检查任务类型下是否有任务，没有则隐藏任务类型Toggle
            for (int i = 0; i < mainToggleScriptList.Count; i++)
            {
                if (mainToggleScriptList[i].Questtype == (int)(QuestDefine.QuestType.MAIN)) { continue; }
                bool visi = false;
                if (questNumPerType.ContainsKey(mainToggleScriptList[i].Questtype))
                {
                    visi = questNumPerType[mainToggleScriptList[i].Questtype] > 0;
                }
                mainToggleScriptList[i].UI.gameObject.SetActive(visi);
            }
            if (j > 0)
            {
                //当前类型下，有任务
                if (UI.childTabButtonGroup.index != -1 && UI.childTabButtonGroup.index < j)
                {
                    UI.childTabButtonGroup.SetIndexWithCallBack(UI.childTabButtonGroup.index);
                }
                else
                {
                    UI.childTabButtonGroup.SetIndexWithCallBack(0);
                }
            }
            else
            {
                clearInfo();
            }
            //隐藏多余的
            //if (childToggleScriptList.Count > j)
            //{
            //    for (int i = j; i < childToggleScriptList.Count; i++)
            //    {
            //        childToggleScriptList[i].setEmpty();
            //    }
            //}
        }

        public void updatePanel(RMetaEvent e = null)
        {
            if (!ui.activeSelf)
            {
                return;
            }
            if (e != null)
            {
                UI.mainTabButtonGroup.UnSelectAll();
            }
            updateQuestList();
        }

        /// <summary>
        /// 选中任务 显示任务信息
        /// </summary>
        /// <param name="t"></param>
        private void SelectQuest(int index)
        {
            QuestInfoData questData = childToggleScriptList[index].Questdata;
            if (questData == null)
            {
                clearInfo();
                return;
            }
            CurrentQuestData = questData;
            QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questData.questId);
            UI.QuestTitleText.text = qt.title;
            UI.QuestDescText.text = qt.desc;
            UI.DoItButton.gameObject.SetActive(true);
            Text txt = UI.DoItButtonText;
            switch (questData.questStatus)
            {
                case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                    if (txt != null) txt.text = "接受任务";
                    UI.GiveUpQuestButton.gameObject.SetActive(false);
                    break;
                case (int)QuestDefine.QuestStatus.ACCEPTED:
                    if (txt != null) txt.text = "马上去做";
                    if (qt.questType == (int)QuestDefine.QuestType.JIUGUAN
                        || qt.questType == (int)QuestDefine.QuestType.CHUBAOANLIANG
                        || qt.questType == (int)QuestDefine.QuestType.BAOTU
                        || qt.questType == (int)QuestDefine.QuestType.YUNLIANG
                        || qt.questType == (int)QuestDefine.QuestType.BANGPAI
                        ||qt.questType == (int)QuestDefine.QuestType.XIANSHINPC
                        || qt.questType == (int)QuestDefine.QuestType.XIANSHISHAGUAI
                        || qt.questType == (int)QuestDefine.QuestType.PUTONGMOZU
                        || qt.questType == (int)QuestDefine.QuestType.KUNNANMOZU
                        || qt.questType == (int)QuestDefine.QuestType.HUAN)
                    {
                        UI.GiveUpQuestButton.gameObject.SetActive(true);
                    }
                    break;
                case (int)QuestDefine.QuestStatus.CAN_FINISH:
                    if (txt != null) txt.text = "完成任务";
                    UI.GiveUpQuestButton.gameObject.SetActive(true);
                    break;
            }
        }

        private void clearInfo()
        {
            UI.QuestTitleText.text = "";
            UI.QuestDescText.text = "";
            UI.DoItButton.gameObject.SetActive(false);
            UI.GiveUpQuestButton.gameObject.SetActive(false);
        }

        private int GetCurrentQuestType()
        {
            if (UI.mainTabButtonGroup.index >= 0 && UI.mainTabButtonGroup.index < mainToggleScriptList.Count)
            {
                return mainToggleScriptList[UI.mainTabButtonGroup.index].Questtype;
            }
            return (int)(QuestDefine.QuestType.MAIN);
        }

        private GameUUToggle GetOneMainQuestToggle()
        {
            GameUUToggle go = GameObject.Instantiate(UI.QuestMainToggle);
            return go;
        }

        private GameUUToggle GetOneChildQuestToggle()
        {
            GameUUToggle go = GameObject.Instantiate(UI.QuestChildToggle);
            return go;
        }

        private void ClickClose()
        {
            hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            //currentQuestData = null;
            app.main.GameClient.ins.OnBigWndHidden();
        }

        public override void Destroy()
        {
            questModel.removeChangeEvent(QuestModel.UPDATEQUESTLIST, updatePanel);
            base.Destroy();
            UI = null;
        }

    }

    #region 任务类型Toggle
    class QuestMainToggleScript
    {
        private GameUUToggle ui;

        private int questtype;

        public QuestMainToggleScript(GameUUToggle uiv)
        {
            UI = uiv;
        }

        public int Questtype
        {
            get { return questtype; }
        }

        public GameUUToggle UI
        {
            get { return ui; }
            set { ui = value; }
        }

        public void SetData(int questtypev)
        {
            questtype = questtypev;
            string str = QuestDefine.GetQuestTypeName(questtype);
            UI.gameObject.SetActive(true);
            //设置任务类型标题
            Text txt = UI.GetComponentInChildren<Text>();
            if (txt != null)
            {
                txt.text = str;
            }
        }
    }
    #endregion

    #region 单个任务的Toggle
    class QuestChildToggleScript
    {
        private GameUUToggle ui;

        private QuestInfoData questdata;

        public QuestChildToggleScript(GameUUToggle uiv)
        {
            ui = uiv;
        }

        public QuestInfoData Questdata
        {
            get { return questdata; }
        }

        public GameUUToggle UI
        {
            get { return ui; }
        }

        public void SetData(QuestInfoData questData)
        {
            if (questdata == null)
            {
                setEmpty();
            }
            questdata = questData;
            QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questData.questId);
            //设置任务标题
            UI.gameObject.SetActive(true);
            Text txt = UI.GetComponentInChildren<Text>();
            if (txt != null)
            {
                ///环任务设置名称
                if (qt.questType == (int)QuestDefine.QuestType.HUAN)
                {
                    txt.text = qt.title + "(" + ((RingTaskModel.Ins.RingTaskInfo.getFinishTimes()-1) % RingTaskModel.g_onehuancount+1) + "/" +
                               RingTaskModel.g_onehuancount + ")";
                }
                else
                {
                    txt.text = qt.title;
                }
                
            }
            
        }

        public void setEmpty()
        {
            questdata = null;
            if (UI != null)
            {
                UI.gameObject.SetActive(false);
            }
        }
    }
    #endregion

}


