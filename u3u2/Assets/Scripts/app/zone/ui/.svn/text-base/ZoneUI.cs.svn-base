using System;
using System.Collections.Generic;
using app.config;
using app.npc;
using app.relation;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using app.battle;
using app.db;
using app.human;
using app.model;
using app.net;
using app.pet;
using app.state;
using app.team;
using app.chat;
using app.tisheng;
using app.tongtianta;
using app.report;
using app.newguaji;

namespace app.zone
{
    /// <summary>
    /// 副本UI。
    /// </summary>
    public class ZoneUI : BaseUI
    {
        private static ZoneUI mIns;
        public static ZoneUI ins
        {
            get
            {
                if (mIns == null) { mIns = Singleton.GetObj(typeof(ZoneUI)) as ZoneUI; }
                return mIns;
            }
        }

        public MainUI UI;
        public PetModel petModel;
        public FunctionModel functionModel;
        public OnlineRewardModel onlineRewardModel;
        public ChatModel chatModel;
        public GoodActivityModel goodactivityModel;
        private MainUIQuestView mainuiQuestview;
        private ChatView chatView;
        private MainUIShiTuView shituView;
        private float mUpdateCoordTextTimeLeft;
        private TiShengView mTishengView;
        private List<MainUITeamMemberItem> mTeamMemberItems = new List<MainUITeamMemberItem>();
        private bool mNeedHideTeamMemberOperList = false;
        private string mRoleHeadIconPath = null;
        private string mPetHeadIconPath = null;
        private const int MaxMsgLen=20;
        private int textwidth = 250;
        private List<UGUIRichTextOptimized> chatTextList = new List<UGUIRichTextOptimized>();
        /// <summary>
        /// 当前是否正在显示ZoneUI
        /// </summary>
        public bool currentIsShowingUI = true;

        public ZoneUI()
        {
            uiName = "mainUIPanel";
            isShowingBtns = true;
            petModel = PetModel.Ins;
            functionModel = FunctionModel.Ins;
            onlineRewardModel = OnlineRewardModel.Ins;
            chatModel = ChatModel.Ins;
            goodactivityModel = GoodActivityModel.Ins;
        }

        public override void initUI()
        {
            base.initUI();
            UI = ui.AddComponent<MainUI>();

            UI.Init();
            UI.questUI.shousuoBtn.SetClickCallBack(clickShouSuo);
            UI.questUI.showBtn.SetClickCallBack(clickShowQuest);
            UI.questUI.exitTeamAutoMatchBtn.SetClickCallBack(OnExitTeamAutoMatchBtnClicked);
            UI.questUI.leaveTeamBtn.SetClickCallBack(OnLeaveTeamBtnClicked);
            UI.questUI.backToTeamBtn.SetClickCallBack(OnBackToTeamBtnClicked);
            UI.questUI.exitTeamBtn.SetClickCallBack(OnExitTeamBtnClicked);
            UI.mapBtn.SetClickCallBack(OnMapBtnClicked);
            UI.chatUI.shousuoToggle.ClickCallBack = clickChatShousuo;
            UI.chatUI.shezhi.SetClickCallBack(clickChatSetting);
            UI.expProgressBar.LabelType = ProgressBarLabelType.None;
            UI.userInfo.roleIcon.gameObject.SetActive(false);
            UI.userInfo.petIcon.gameObject.SetActive(false);
            UI.userInfo.m_guajiicon.gameObject.SetActive(false);
            //InputManager.Ins.AddListener(InputManager.CLICK_EVENT_TYPE, UI.chatUI.boxCollider.gameObject, ShowChatPanel);
            //EventTriggerListener.Get(UI.chatUI.boxCollider.gameObject).onClick = ShowChatPanel1;
            int len = UI.questUI.teamMemberItems.Count;
            for (int i = 0; i < len; i++)
            {
                mTeamMemberItems.Add(new MainUITeamMemberItem(UI.questUI.teamMemberItems[i]));
                EventTriggerListener.Get(UI.questUI.teamMemberItems[i].gameObject).onClick = ClickTeamMemberItems;
            }

            UI.bagua.SetClickCallBack(clickBaGua);
            UI.friendBtn.SetClickCallBack(clickFriend);

            InitUIPart(MAP_INFO, UI.mapUI.transform);
            InitUIPart(QUEST_INFO, UI.questUI.transform);
            InitUIPart(CHAT_INFO, UI.chatUI.transform);
            InitUIPart(USER_INFO, UI.userInfo.transform);
            InitUIPart(MAIN_BUTTONS, UI.mainuiButton.transform);
            InitUIPart(MAIN_UP_BUTTONS, UI.mainuiButton.topBtns.transform);
            InitUIPart(MAIN_LEFT_BUTTONS, UI.mainuiButton.leftBtns.transform);
            InitUIPart(EXP_BAR, UI.expProgressBar.transform);

            mainuiQuestview = new MainUIQuestView(UI.questUI);
            if (waitingShowPartList != null && waitingShowPartList.Count > 0)
            {
                showPart(waitingShowPartList);
                waitingShowPartList = null;
            }
            if (waitingHidePartList != null && waitingHidePartList.Count > 0)
            {
                hidePart(waitingHidePartList);
                waitingHidePartList = null;
            }
            EventTriggerListener.Get(UI.userInfo.petInfo.gameObject).onClick = openPetView;
            EventTriggerListener.Get(UI.userInfo.roleInfo.gameObject).onClick = openRoleView;
            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, OnSceneUpHandler);

            InputManager.Ins.AddListener(InputManager.CANCEL_STATIONARY_EVENT_TYPE, UI.gameObject, cancelRecord);
            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, stopRecord);

            InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, UI.chatUI.BangPailuyin.gameObject, startBangPaiRecord);
            InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, UI.chatUI.Duiwuluyin.gameObject, startDuiwuRecord);

            shituView = new MainUIShiTuView(UI.shituUI);
            shituView.UpdateShiTuInfo();

            if (mTishengView == null)
            {
                mTishengView = new TiShengView(UI.mainuiButton.tishengUI, UI.mainuiButton.topBtnGrid[3]);
                // UI.mainuiButton.tishengUI.gameObject.SetActive(false);
                // UI.mainuiButton.topBtnGrid[3].gameObject.SetActive(false);
            }

            petModel.addChangeEvent(PetModel.UPDATE_PET_PROP, updatePetInfo);
            petModel.addChangeEvent(PetModel.UPDATE_PET_LIST, updatePetInfo);
            petModel.addChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE, updatePetInfo);
            
            functionModel.addChangeEvent(FunctionModel.ADD_NEW_FUNC, AddNewFuncBtn);
            functionModel.addChangeEvent(FunctionModel.FUNC_INFO_UPDATE, UpdateFuncBtnInfo);

            onlineRewardModel.addChangeEvent(OnlineRewardModel.UPDATE_REDDOT_STATE, UpdateFuncRedDot);
            QuestModel.Ins.addChangeEvent(QuestModel.UPDATEQUESTLIST,updateJiangLiOFQiRiRedDot);
            PlayerModel.Ins.addChangeEvent(PlayerModel.UPDATE_LOGIN_DAYS, updateJiangLiOFQiRiRedDot);
            chatModel.addChangeEvent(ChatModel.APPEND_ONE_MSG, updateMsgContent);

            //TongTianTaModel.ins.addChangeEvent(TongTianTaModel.UPDATE_TOWERINFO,OnTowerInfoChanged);

            EventCore.addRMetaEventListener(GuideManager.Ins.StartGuideEvent, showGuide);
            EventCore.addRMetaEventListener(GuideManager.Ins.EndGuideEvent, showGuide);
            EventCore.addRMetaEventListener(JuQingManager.END_JUQING_EVENT, endJuQing);
            NewGuaJiModel.Ins.addChangeEvent(NewGuaJiModel.REFRESH_GUAJI_INFO, GuaJiInfo);

            goodactivityModel.addChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY2_RedDot, UpdateChargeActivityRedDot);

            ChatView = new ChatView(UI.chatPanelUI, HideChatPanel, startRecord);
            UI.chatPanelUI.gameObject.SetActive(false);

            //InputManager.Ins.AddListener(InputManager.SCALE_EVENT_TYPE,UI.gameObject,clickHideUI);
        }

        private void clickHideUI(RMetaEvent e = null)
        {
            if (StateManager.Ins.getCurState().state == StateDef.zoneState &&
                ZoneModel.ins.CheckMapType(MapType.NORMAL, ZoneModel.ins.mapTpl.Id)&&
                !GuideManager.Ins.isShowingGuide()&&!JuQingManager.Ins.IsPlayingJuQing&&
                !WndManager.Ins.hasWndShowing())
            {
                if (e == null)
                {
                    if (!currentIsShowingUI)
                    {
                        hideAll();
                    }
                    return;
                }

                if (currentIsShowingUI && InputManager.Ins.ScaleDelta < 0)
                {
                    currentIsShowingUI = false;
                    hideAll();
                }
                else if (!currentIsShowingUI && InputManager.Ins.ScaleDelta > 0)
                {
                    currentIsShowingUI = true;
                    showAll();
                }
            }
        }

        private void InitUIPart(string key, Transform value)
        {
            mUIPartsDic.Add(key, value);
            Vector3 pos = value.localPosition;
            mUIPartsShowPosDic.Add(key, pos);
            pos.y += UGUIConfig.ScreenHeight * 2;
            mUIPartsHidePosDic.Add(key, pos);
        }
        
        public override void Update()
        {
            base.Update();
            if (ZoneCharacterManager.ins.self != null && UI != null)
            {
                if (mUpdateCoordTextTimeLeft <= 0)
                {
                    mUpdateCoordTextTimeLeft = 0.5f;
                    int[] pixPos = ZoneUtil.ConvertUnityPos2PathTilePos(ZoneCharacterManager.ins.self.localPosition);
                    //Vector2 pixPos = ZoneUtil.ConvertUnityPos2LeftTopPixelPos(ZoneCharacterManager.ins.self.localPosition);
                    UI.mapUI.mapPosition.text = pixPos[0] + ", " + pixPos[1];
                }
                else
                {
                    mUpdateCoordTextTimeLeft -= Time.deltaTime;
                }
            }
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            this.setAsFirstSibling(UI.gameObject);
            
            UI.expProgressBar.forGround.rectTransform.anchoredPosition = new Vector3(0, -4, 0);
            UI.expGrid.spacing = new Vector2((UI.expProgressBar.progressBarWidth - 40.0f) / 10.0f, 0);

            Pet mainRole = Human.Instance.PetModel.getLeader();
            UI.expProgressBar.setLongPercent(mainRole.getExpLimit(), mainRole.getExp());
            
            UpdateFuncBtns();
            UpdateFuncRedDot();
            UpdateData();

            if (StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                if (!BattleCharacterManager.ins.isReadyToFight)
                {
                    hideAll();
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(ZoneUI.USER_INFO);
                    list.Add(ZoneUI.CHAT_INFO);
                    showPart(list);
                }
            }
            //OnTowerInfoChanged();
        }

        public void Init()
        {
            if (base.ui != null)
            {
                UI.Show();

                if (!currentIsShowingUI)
                {
                    clickHideUI();
                }
                // base.ui.SetActive(true);
                UpdateData();
            }
            else
            {
                preLoadUI();
            }
        }

        public void UpdateData()
        {
            UI.mapUI.mapName.text = ZoneModel.ins.mapTpl.name;
            updateMsgContent(null);
            UpdateTeamInfo();
            updatePetInfo();

            //checkNewFuncAndGuide();
        }

        private void clickChatSetting()
        {
            WndManager.open(GlobalConstDefine.ChatSettingView);
        }

        private void clickChatShousuo(UGUISwitchButton sb = null)
        {
            UI.chatUI.chatContentLayout.preferredHeight = sb.IsSelected ? 100 : 300;
            UI.chatUI.boxCollider.center = new Vector3(125, ((sb.IsSelected ? 100 : 300)/2), 0);
            UI.chatUI.boxCollider.size = new Vector2(250, sb.IsSelected ? 100 : 300);

            RectTransform rtf = UI.chatUI.chatContentImage.GetComponent<RectTransform>();
            if (rtf != null)
            {
                rtf.sizeDelta = new Vector2(rtf.sizeDelta.x, sb.IsSelected ? 90 : 290);
            }
        }

        public void updateMsgContent(RMetaEvent e)
        {
            if (e==null)
            {
                return;
            }
            if (UI != null && (e.data)!=null)
            {
                //string msgcontent=null;
                if (e.data is ChatMsgData)
                {
                    ChatMsgData chatdata = e.data as ChatMsgData;
                    if (chatModel.CanShowScopeMsg(chatdata.getScope()))
                    {
                        Color color = ChatScopeType.GetScopeColor(chatdata.getScope());
                        string scopeName = ChatScopeType.GetChatScopeName(chatdata.getScope());
                        Dictionary<string, string> scopeDic = UGUIRichTextOptimized.CreateTextElement("[" + scopeName + "]", 20,color);
                        Dictionary<string, string> roleNameDic = null;
                        if (!string.IsNullOrEmpty(chatdata.getFromRoleUUID()))
                        {
                            string rolenamestr = ""+ChatContentType.ROLE + ChatContentBase.SPLIT_SUB+ chatdata.getFromRoleUUID() + ChatContentBase.SPLIT_SUB+ chatdata.getFromRoleName();

                            //roleNameDic = UGUIRichTextOptimized.CreateTextElement(
                            //    "[" + chatdata.getFromRoleName() + "]", 20, color);
                            roleNameDic = UGUIRichTextOptimized.CreateTextElement("【" + chatdata.getFromRoleName() + "】",
                                20, Color.green, false, false, rolenamestr);
                        }
                        string msgstr = chatdata.getContent();
                        if (chatdata.getChatType()==1)
                        {
                            //语音
                            msgstr = RelationChatItemScript.getYuYinText(chatdata);
                        }
                        List<Dictionary<string, string>> list = chatModel.GetChatTextList(msgstr, 20, 
                            ChatScopeType.GetScopeColor(chatdata.getScope()));
                        if (roleNameDic != null) { list.Insert(0,roleNameDic); }
                        list.Insert(0, scopeDic);
                        UGUIRichTextOptimized richtext = null;
                        if (chatTextList.Count == MaxMsgLen)
                        {
                            richtext = chatTextList[0];
                            chatTextList.RemoveAt(0);
                        }
                        else
                        {
                            richtext = UGUIRichTextOptimized.Create(UI.chatUI.chatContentText.transform, "text");
                        }
                        chatTextList.Add(richtext);
                        richtext.SetContent(list, SourceManager.Ins.defaultFont, 20, ChatScopeType.GetScopeColor(chatdata.getScope()), false, null, true, textwidth, chatModel.onResized, chatModel.onClickHref);
                        richtext.gameObject.transform.SetAsFirstSibling();
                    }

                    if (chatdata != null && chatdata.getScope() != ChatScopeType.CHAT_SCOPE_PRIVATE)
                    {
                        //私聊不显示头顶冒泡
                        switch (StateManager.Ins.getCurState().state)
                        {
                            case StateDef.zoneState:
                                if (e != null && chatdata != null) ZoneCharacterManager.ins.showChatBubble(chatdata);
                                break;
                            case StateDef.battleState:
                                if (e != null && chatdata != null) BattleCharacterManager.ins.showChatBubble(chatdata);
                                break;
                        }
                    }
                }
                else if (e.data is NoticeTipsInfoData)
                {
                    if (chatModel.CanShowScopeMsg(ChatScopeType.CHAT_SCOPE_DEFAULT))
                    {
                        NoticeTipsInfoData chatdata = e.data as NoticeTipsInfoData;
                        string content = chatdata.content.TrimEnd(new char[]{'\n'});
                        Dictionary<string, string> scopeDic = UGUIRichTextOptimized.CreateTextElement("[系统]", 20, Color.green);
                        List<Dictionary<string, string>> list = chatModel.GetChatTextList(content, 20, Color.yellow);
                        list.Insert(0, scopeDic);

                        UGUIRichTextOptimized richtext = null;
                        if (chatTextList.Count == MaxMsgLen)
                        {
                            richtext = chatTextList[0];
                            chatTextList.RemoveAt(0);

                        }
                        else
                        {
                            richtext = UGUIRichTextOptimized.Create(UI.chatUI.chatContentText.transform, "text");
                        }
                        chatTextList.Add(richtext);
                        richtext.SetContent(list, SourceManager.Ins.defaultFont, 20, Color.yellow, false, null, true, textwidth, chatModel.onResized, chatModel.onClickHref);
                        richtext.gameObject.transform.SetAsFirstSibling();
                    }
                }
                else if (e.data is SysMsgInfoData)
                {
                    if (chatModel.CanShowScopeMsg(ChatScopeType.CHAT_SCOPE_DEFAULT))
                    {
                        SysMsgInfoData chatdata = e.data as SysMsgInfoData;
                        string content = chatdata.content.TrimEnd(new char[]{'\n'});
                        Dictionary<string, string> scopeDic = UGUIRichTextOptimized.CreateTextElement("[系统]", 20, Color.green);
                        List<Dictionary<string, string>> list = chatModel.GetChatTextList(content, 20, Color.yellow);
                        list.Insert(0, scopeDic);

                        UGUIRichTextOptimized richtext = null;
                        if (chatTextList.Count == MaxMsgLen)
                        {
                            richtext = chatTextList[0];
                            chatTextList.RemoveAt(0);
                        }
                        else
                        {
                            richtext = UGUIRichTextOptimized.Create(UI.chatUI.chatContentText.transform, "text");
                        }
                        chatTextList.Add(richtext);
                        richtext.SetContent(list, SourceManager.Ins.defaultFont, 20, Color.yellow, false, null, true, textwidth, chatModel.onResized, chatModel.onClickHref);
                        richtext.gameObject.transform.SetAsFirstSibling();
                    }
                }
                //if (chatMsgList == null)
                //{
                //    chatMsgList = new List<string>();
                //}
                //if (msgcontent!=null)
                //{
                //    chatMsgList.Add(msgcontent);
                //}
                //if (chatMsgList.Count > MaxMsgLen)
                //{
                //    chatMsgList.RemoveAt(0);
                //}
                //msgcontent = "";
                //系统消息
                //for (int i = 0; chatMsgList != null && i < chatMsgList.Count; i++)
                //{
                //    msgcontent = chatMsgList[i] + msgcontent;
                //}
                //UI.chatUI.chatContentText.text = msgcontent;
                if (chatTextList.Count>MaxMsgLen)
                {
                    chatTextList[0].Destroy();
                    chatTextList.RemoveAt(0);
                }
            }
        }

        public void ShowChatPanel1(GameObject go)
        {
            ShowChatPanel();
        }
        public void ShowChatPanel(RMetaEvent e=null)
        {
            if (!UGUIConfig.UICamera.isActiveAndEnabled)
            {
                return;
            }
            bool newcreate = false;
            if (ChatView == null)
            {
                ChatView = new ChatView(UI.chatPanelUI, HideChatPanel, startRecord);
                newcreate = true;
            }
            ChatView.showPanel(newcreate);
        }

        private void HideChatPanel(RMetaEvent e)
        {
            //InputManager.Ins.AddListener(InputManager.CLICK_EVENT_TYPE, UI.chatUI.chatRect.gameObject, ShowChatPanel);
        }

        private void clickFriend()
        {
            DataReport.Instance.Game_SetEvent("c_touch", "mainui", FunctionIdDef.HAOYOU.ToString());
            LinkParse.Ins.linkToFunc(FunctionIdDef.HAOYOU);
            GuideManager.Ins.switchMask(GuideIdDef.AddFriend, true);
        }

        public void updateRoleInfo(RMetaEvent e = null)
        {
            Pet mainRole = Human.Instance.PetModel.getLeader();

            if (StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                BatCharacter batMainRole = BattleCharacterManager.ins.mainRole;
                if (batMainRole != null)
                {
                    BattleManager.ins.UpdateMainRoleInfo(batMainRole);
                }
            }
            else
            {
                UI.userInfo.roleHp.MaxValue = mainRole.PropertyManager.getPetIntProp(PetBProperty.HP);
                UI.userInfo.roleHp.Value = mainRole.curHp;
                UI.userInfo.roleMp.MaxValue = mainRole.PropertyManager.getPetIntProp(PetBProperty.MP);
                UI.userInfo.roleMp.Value = mainRole.curMp;
                UI.userInfo.roleSp.MaxValue = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.SP_MAX);
                UI.userInfo.roleSp.Value = mainRole.curSp;
            }

            if (UI != null)
            {
                UI.userInfo.roleLevel.text = mainRole.getLevel().ToString();
                UI.expProgressBar.setLongPercent(mainRole.getExpLimit(), mainRole.getExp());
                PathUtil.Ins.SetHeadIcon(UI.userInfo.roleIcon, mainRole.getTpl().modelId);
            }
        }

        public void updatePetInfo(RMetaEvent e = null)
        {
            if (UI == null)
            {
                return;
            }
            if (e != null && e.type == petModel.GetFinalEventType(PetModel.UPDATE_PET_LIST))
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.UsePet, 2, UI.userInfo.petInfo.gameObject, false,300);
            }
            updateRoleInfo();

            Pet curPet = Human.Instance.PetModel.getChongWu(true);
            if (curPet == null)
            {
                curPet = Human.Instance.PetModel.getFirstChongWu();
                if (curPet == null)
                {
                    UI.userInfo.petInfo.SetActive(false);
                }
                else
                {
                    UI.userInfo.petLevel.text = "0";
                    UI.userInfo.petHp.Percent = 0;
                    UI.userInfo.petMp.Percent = 0;
                    UI.userInfo.petIcon.gameObject.SetActive(false);
                    UI.userInfo.petInfo.SetActive(true);
                    UI.userInfo.defaultPetHead.gameObject.SetActive(true);
                }
            }
            else
            {
                if (StateManager.Ins.getCurState().state == StateDef.battleState)
                {
                    BatCharacter batMainPet = BattleCharacterManager.ins.mainPet;
                    if (batMainPet != null)
                    {
                        BattleManager.ins.UpdateMainPetInfo(batMainPet);
                        curPet = Human.Instance.PetModel.getChongWu(true);
                    }
                }
                else
                {
                    UI.userInfo.petHp.MaxValue = curPet.PropertyManager.getPetIntProp(PetBProperty.HP);
                    UI.userInfo.petHp.Value = curPet.curHp;
                    UI.userInfo.petMp.MaxValue = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.SP_MAX);
                    UI.userInfo.petMp.Value = curPet.curMp;
                }
                UI.userInfo.petLevel.text = curPet.getLevel().ToString();
                //string headPath = PathUtil.Ins.GetUITexturePath(curPet.getTpl().modelId, PathUtil.TEXTUER_HEAD);
                //LoadPetHeadIcon(headPath);
                UI.userInfo.petInfo.SetActive(true);
                PathUtil.Ins.SetHeadIcon(UI.userInfo.petIcon, curPet.getTpl().modelId);
                //UI.userInfo.petIcon.gameObject.SetActive(true);
                UI.userInfo.defaultPetHead.gameObject.SetActive(false);
            }
            //骑宠按钮
            UI.mainuiButton.downBtnGrid[0].transform.parent.gameObject.SetActive(petModel.HaveQichong() && functionModel.IsFuncOpen(FunctionIdDef.QICHONG));
        }

        public Vector3 GetBagBtnWorldPos()
        {
            return UI.bagBtn.gameObject.transform.parent.transform.TransformPoint(UI.bagBtn.gameObject.transform.localPosition + new Vector3(-44, 45, 0));
        }

        public Vector3 GetBaGuaBtnWorldPos()
        {
            return UI.bagua.gameObject.transform.parent.transform.TransformPoint(UI.bagua.gameObject.transform.localPosition);
        }

        #region 更新主角和宠物信息
        /// <summary>
        /// 设置 主角信息
        /// </summary>
        /// <param name="roleHpPercent"></param>
        /// <param name="roleMpPercent"></param>
        /// <param name="roleSpPercent"></param>
        public void UpdateRoleInfo(float roleHpPercent, float roleMpPercent, float roleSpPercent)
        {
            if (UI == null)
            {
                return;
            }
            UI.userInfo.roleHp.MaxValue = 1f;
            UI.userInfo.roleHp.Percent = roleHpPercent;

            UI.userInfo.roleMp.MaxValue = 1f;
            UI.userInfo.roleMp.Percent = roleMpPercent;

            UI.userInfo.roleSp.MaxValue = 1f;
            UI.userInfo.roleSp.Percent = roleSpPercent;
        }

        /// <summary>
        /// 设置 宠物信息
        /// </summary>
        /// <param name="petHpPercent"></param>
        /// <param name="petMpPercent"></param>
        /// <param name="petSpPercent"></param>
        public void UpdatePetInfo(float petHpPercent, float petMpPercent, float petSpPercent)
        {
            if (UI == null)
            {
                return;
            }
            UI.userInfo.petHp.MaxValue = 1f;
            UI.userInfo.petHp.Percent = petHpPercent;

            UI.userInfo.petMp.MaxValue = 1f;
            UI.userInfo.petMp.Percent = petMpPercent;
        }

        #endregion

        #region 控制界面部分显示

        private Dictionary<string, Transform> mUIPartsDic = new Dictionary<string, Transform>();
        private Dictionary<string, Vector3> mUIPartsShowPosDic = new Dictionary<string, Vector3>();
        private Dictionary<string, Vector3> mUIPartsHidePosDic = new Dictionary<string, Vector3>();
        public const string MAP_INFO = "MAP_INFO";
        public const string QUEST_INFO = "QUEST_INFO";
        public const string CHAT_INFO = "CHAT_INFO";
        public const string USER_INFO = "USER_INFO";
        public const string MAIN_BUTTONS = "MAIN_BUTTONS";
        public const string MAIN_UP_BUTTONS = "MAIN_UP_BUTTONS";
        public const string MAIN_LEFT_BUTTONS = "MAIN_LEFT_BUTTONS";
        public const string EXP_BAR = "EXP_BAR";

        private List<string> waitingShowPartList;
        private List<string> waitingHidePartList;

        public void showAll()
        {
            if (mUIPartsDic.Count == 0)
            {
                return;
            }

            foreach (KeyValuePair<string, Transform> pair in mUIPartsDic)
            {
                //pair.Value.SetActive(true);
                pair.Value.localPosition = mUIPartsShowPosDic[pair.Key];
            }
            currentIsShowingUI = true;
            //if (!currentIsShowingUI)
            //{
            //    clickHideUI();
            //}
        }

        public void hideAll()
        {
            if (mUIPartsDic.Count == 0)
            {
                return;
            }

            foreach (KeyValuePair<string, Transform> pair in mUIPartsDic)
            {
                //pair.Value.SetActive(false);
                pair.Value.localPosition = mUIPartsHidePosDic[pair.Key];
            }
            currentIsShowingUI = false;
        }

        public void showPart(List<string> keys)
        {
            if (mUIPartsDic.Count == 0)
            {
                waitingShowPartList = keys;
                return;
            }
            if (!isShown)
            {
                show();
            }
            foreach (KeyValuePair<string, Transform> pair in mUIPartsDic)
            {
                //pair.Value.SetActive(keys.Contains(pair.Key));
                if (keys.Contains(pair.Key))
                {
                    pair.Value.localPosition = mUIPartsShowPosDic[pair.Key];
                }
                else
                {
                    pair.Value.localPosition = mUIPartsHidePosDic[pair.Key];
                }
            }
            //if (!currentIsShowingUI)
            //{
            //    clickHideUI();
            //}
        }

        public void hidePart(List<string> keys)
        {
            if (mUIPartsDic.Count == 0)
            {
                waitingHidePartList = keys;
                return;
            }
            foreach (KeyValuePair<string, Transform> pair in mUIPartsDic)
            {
                //pair.Value.SetActive(!keys.Contains(pair.Key));
                if (keys.Contains(pair.Key))
                {
                    pair.Value.localPosition = mUIPartsHidePosDic[pair.Key];
                }
                else
                {
                    pair.Value.localPosition = mUIPartsShowPosDic[pair.Key];
                }
            }
        }
        #endregion 

        #region 主屏按钮逻辑

        public bool isShowingBtns { get; private set; }

        public ChatView ChatView
        {
            get{return chatView;}
            set{chatView = value;}
        }

        private void clickBaGua()
        {
            if (isShowingBtns)
            {
                isShowingBtns = false;

                TweenUtil.KillTween(UI.mainuiButton.downBtns.transform);
                TweenUtil.KillTween(UI.mainuiButton.rightBtns.transform);
                TweenUtil.KillTween(UI.bagua.transform);

                float downBtnWidth = UI.mainuiButton.downBtns.GetComponent<RectTransform>().sizeDelta.x;
                float rightBtnHeight = UI.mainuiButton.rightBtns.GetComponent<RectTransform>().sizeDelta.y;
                TweenUtil.MoveTo(UI.mainuiButton.downBtns.transform, new Vector3(downBtnWidth, 0, 0), downBtnWidth * 0.0006f, null, downEnd, null, 0, Ease.Linear);
                TweenUtil.MoveTo(UI.mainuiButton.rightBtns.transform, new Vector3(0, -rightBtnHeight, 0), rightBtnHeight * 0.0006f, null, rightEnd, null, 0, Ease.Linear);
                TweenUtil.RotateTo(UI.bagua.transform, new Vector3(0, 0, -180), 0.2f, RotateMode.LocalAxisAdd);
            }
            else
            {
                isShowingBtns = true;
                downEnd();
                rightEnd();

                TweenUtil.KillTween(UI.mainuiButton.downBtns.transform);
                TweenUtil.KillTween(UI.mainuiButton.rightBtns.transform);
                TweenUtil.KillTween(UI.bagua.transform);

                float downBtnWidth = UI.mainuiButton.downBtns.GetComponent<RectTransform>().sizeDelta.x;
                float rightBtnHeight = UI.mainuiButton.rightBtns.GetComponent<RectTransform>().sizeDelta.y;
                TweenUtil.MoveTo(UI.mainuiButton.downBtns.transform, new Vector3(0, 0, 0), downBtnWidth * 0.001f, null, downEnd, null, 0, Ease.OutBack);
                TweenUtil.MoveTo(UI.mainuiButton.rightBtns.transform, new Vector3(0, 0, 0), rightBtnHeight * 0.001f, null, rightEnd, null, 0, Ease.OutBack);
                TweenUtil.RotateTo(UI.bagua.transform, new Vector3(0, 0, 180), 0.2f, RotateMode.LocalAxisAdd);
            }
        }

        private void downEnd()
        {
            UI.mainuiButton.downBtns.gameObject.SetActive(isShowingBtns);
        }
        private void rightEnd()
        {
            UI.mainuiButton.rightBtns.gameObject.SetActive(isShowingBtns);
        }

        private void clickShouSuo()
        {
            TweenUtil.MoveTo(UI.questUI.questMoveObj.transform, new Vector3(-40, 0, 0), 0.2f, null, hideEnd);
            UI.questUI.shousuoBtn.gameObject.SetActive(false);
            UI.questUI.showBtn.gameObject.SetActive(true);
        }

        private void hideEnd()
        {
            UI.questUI.questObj.SetActive(false);
        }

        public void clickShowQuest(GameObject go)
        {
            if (go!=null)
            {
                TweenUtil.MoveTo(UI.questUI.questMoveObj.transform, new Vector3(-260, 0, 0), 0.2f, null, showEnd);
            }
            else
            {
                UI.questUI.questMoveObj.transform.localPosition = new Vector3(-260, 0, 0);
            }
            showEnd();
        }

        private void showEnd()
        {
            UI.questUI.shousuoBtn.gameObject.SetActive(true);
            UI.questUI.showBtn.gameObject.SetActive(false);
            UI.questUI.questObj.SetActive(true);
        }
        #endregion

        #region 功能按钮

        private Dictionary<int, MainButtonUI> funcDic;
        private Mask downMask;
        private GameUUImageIgnoreRaycast downMaskImg;

        private void clickButton(GameObject go)
        {
            //下 右 上 左 奖励
            foreach (KeyValuePair<int, MainButtonUI> pair in funcDic)
            {
                if (pair.Value.btn.gameObject == go)
                {
                    DataReport.Instance.Game_SetEvent("c_touch", "mainui", pair.Key.ToString());
                    LinkParse.Ins.linkToFunc(pair.Key);
                    if (pair.Key == FunctionIdDef.JIANGLI)
                    {
                        GuideManager.Ins.switchMask(GuideIdDef.QianDao, true);
                        GuideManager.Ins.switchMask(GuideIdDef.LevelReward, true);
                    }
                    if (pair.Key == FunctionIdDef.HUODONG)
                    {
                        GuideManager.Ins.switchMask(GuideIdDef.KeJu, true);
                        GuideManager.Ins.switchMask(GuideIdDef.JingJiChang, true);
                        GuideManager.Ins.switchMask(GuideIdDef.LvYeXianZong, true);
                        GuideManager.Ins.switchMask(GuideIdDef.JiuGuan, true);
                        GuideManager.Ins.switchMask(GuideIdDef.CangBaoTu, true);
                        GuideManager.Ins.switchMask(GuideIdDef.YunLiang, true);
                        GuideManager.Ins.switchMask(GuideIdDef.ChuBao, true);
                        GuideManager.Ins.switchMask(GuideIdDef.RingTask, true);
                    }
                    if (pair.Key == FunctionIdDef.TOWER)
                    {
                        GuideManager.Ins.switchMask(GuideIdDef.TongTianTa, true);
                    }
                    break;
                }
            }
        }

        private void openPetView(GameObject go)
        {
            DataReport.Instance.Game_SetEvent("c_touch", "mainui", FunctionIdDef.PETSINFO.ToString());
            WndManager.open(GlobalConstDefine.PetInfoView_Name);
        }

        private void openRoleView(GameObject go)
        {
            DataReport.Instance.Game_SetEvent("c_touch", "mainui", FunctionIdDef.ROLEINFO.ToString());
            WndManager.open(GlobalConstDefine.RoleInfoView_Name);
        }

        public void UpdateFuncBtns()
        {
            if (UI == null)
            {
                return;
            }
            if (funcDic == null)
            {
                funcDic = new Dictionary<int, MainButtonUI>();
                //下面的按钮
                funcDic.Add(FunctionIdDef.QICHONG, UI.mainuiButton.downBtnGrid[0]);
                funcDic.Add(FunctionIdDef.XINFAJINENG, UI.mainuiButton.downBtnGrid[1]);
                funcDic.Add(FunctionIdDef.BANGPAI, UI.mainuiButton.downBtnGrid[2]);
                funcDic.Add(FunctionIdDef.QIANGHUA, UI.mainuiButton.downBtnGrid[3]);
                funcDic.Add(FunctionIdDef.DAZAO, UI.mainuiButton.downBtnGrid[4]);
                funcDic.Add(FunctionIdDef.XITONG, UI.mainuiButton.downBtnGrid[5]);
                //右侧的按钮
                funcDic.Add(FunctionIdDef.BEIBAO, UI.mainuiButton.rightBtnGrid[0]);
                //上侧的按钮
                funcDic.Add(FunctionIdDef.HUODONG, UI.mainuiButton.topBtnGrid[0]);
                funcDic.Add(FunctionIdDef.NEWGUAJI, UI.mainuiButton.topBtnGrid[1]);
                funcDic.Add(FunctionIdDef.PAIHANG, UI.mainuiButton.topBtnGrid[2]);
                funcDic.Add(FunctionIdDef.TISHENG, UI.mainuiButton.topBtnGrid[3]);
                //左侧的按钮
                funcDic.Add(FunctionIdDef.JIANGLI, UI.mainuiButton.leftBtnGrid[0]);
                funcDic.Add(FunctionIdDef.PAIMAIHANG, UI.mainuiButton.leftBtnGrid[1]);
                funcDic.Add(FunctionIdDef.VIP, UI.mainuiButton.leftBtnGrid[2]);
                //精彩活动2按钮(充值活动)
                funcDic.Add(FunctionIdDef.JINGCAIHUODONG2, UI.jingcaihuodongBtn);
                //仙葫
                funcDic.Add(FunctionIdDef.XIANHU, UI.xianhuBtn);
                //月卡
                funcDic.Add(FunctionIdDef.YUEKA, UI.yuekaBtn);
            }
            foreach (KeyValuePair<int, MainButtonUI> pair in funcDic)
            {
                pair.Value.btn.SetClickCallBack(clickButton);
                if (pair.Key != FunctionIdDef.JIANGLI)
                {
                    pair.Value.transform.parent.gameObject.SetActive(functionModel.IsFuncOpen(pair.Key));
                }
                if(pair.Key == FunctionIdDef.QICHONG)
                {
                    pair.Value.transform.parent.gameObject.SetActive(petModel.HaveQichong()&&functionModel.IsFuncOpen(pair.Key));
                }
            }
            UI.chatUI.openChatPanelBtn.ClearClickCallBack();
            UI.chatUI.openChatPanelBtn.SetClickCallBack(ShowChatPanel1);

            UI.isRecording.gameObject.SetActive(false);

            if (!ServerConfig.instance.IsPassedCheck)
            {
                UI.mainuiButton.leftBtnGrid[0].gameObject.SetActive(false);
                UI.mainuiButton.topBtnGrid[0].gameObject.SetActive(false);
                UI.mainuiButton.leftBtnGrid[2].gameObject.SetActive(false);
                UI.mainuiButton.topBtnGrid[3].gameObject.SetActive(false);
                UI.jingcaihuodongBtn.gameObject.SetActive(false);
            }

            //InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, UI.chatUI.BangPailuyin.gameObject, startBangRecord);
            //InputManager.Ins.AddListener(InputManager.UP_EVENT_TYPE, UI.chatUI.BangPailuyin.gameObject, stopRecord);
            //InputManager.Ins.AddListener(InputManager.CANCEL_STATIONARY_EVENT_TYPE, UI.chatUI.BangPailuyin.gameObject, cancelRecord);

            //InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, UI.chatUI.Duiwuluyin.gameObject, startDuiwuRecord);
            //InputManager.Ins.AddListener(InputManager.UP_EVENT_TYPE, UI.chatUI.Duiwuluyin.gameObject, stopRecord);
            //InputManager.Ins.AddListener(InputManager.CANCEL_STATIONARY_EVENT_TYPE, UI.chatUI.Duiwuluyin.gameObject, cancelRecord);
        }

        private void updateJiangLiOFQiRiRedDot(RMetaEvent e = null)
        {
            MainButtonUI btn;
            //签到、登陆奖励、在线奖励
            funcDic.TryGetValue(FunctionIdDef.JIANGLI, out btn);
            if (btn != null && btn.btn != null)
            {
                btn.btn.redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.QIANDAO) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.DENGLUJIANGLI) ||
                                        onlineRewardModel.HaveRedDot() || functionModel.IsFuncNeedRedDot(FunctionIdDef.JINGCAIHUODONG) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.ZAIXIANJIANGLI) ||
                                        QuestModel.Ins.hasQiRiMuBiaoRewardDay().Count > 0;
            }
        }

        private void UpdateFuncRedDot(RMetaEvent rMetaEvent = null)
        {
            if (functionModel == null)
            {
                return;
            }
            foreach (KeyValuePair<int, MainButtonUI> pair in funcDic)
            {
                if (pair.Value != null && pair.Value.btn != null)
                {
                    pair.Value.btn.redDotVisible = functionModel.IsFuncNeedRedDot(pair.Key);
                }
            }

            ///提升按钮的红点一直显示///
            funcDic[FunctionIdDef.TISHENG].btn.redDotVisible = true;

            if (UI != null && UI.questUI != null)
            {
                //任务
                if (UI.questUI.questToggle != null)
                {
                    UI.questUI.questToggle.redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.RENWU);
                }
                //队伍
                if (UI.questUI.teamToggle != null)
                {
                    UI.questUI.teamToggle.redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.DUIWU);
                }
            }

            MainButtonUI btn;
            //伙伴和骑宠
            funcDic.TryGetValue(FunctionIdDef.HUOBAN, out btn);
            if (btn != null && btn.btn != null)
            {
                btn.btn.redDotVisible = //functionModel.IsFuncNeedRedDot(FunctionIdDef.HUOBAN) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.QICHONG);
            }
            //打造、升星、镶嵌、合成
            funcDic.TryGetValue(FunctionIdDef.DAZAO, out btn);
            if (btn != null && btn.btn != null)
            {
                btn.btn.redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.DAZAO) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.SHENGXING) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.XIANGQIAN) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.HECHENG);
            }

            //强化、分解、重铸、洗炼、灌注、传承
            funcDic.TryGetValue(FunctionIdDef.QIANGHUA, out btn);
            if (btn != null && btn.btn != null)
            {
                btn.btn.redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.QIANGHUA) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.FENJIE) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.CHONGZHU) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.XILIAN) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.GUANZHU) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.CHUANCHENG);
            }

            //签到、登陆奖励、在线奖励
            funcDic.TryGetValue(FunctionIdDef.JIANGLI, out btn);
            if (btn != null && btn.btn != null)
            {
                btn.btn.redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.QIANDAO) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.DENGLUJIANGLI) ||
                                        onlineRewardModel.HaveRedDot() || functionModel.IsFuncNeedRedDot(FunctionIdDef.JINGCAIHUODONG)||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.ZAIXIANJIANGLI)||
                                        QuestModel.Ins.hasQiRiMuBiaoRewardDay().Count > 0;
            }

            //帮派红点
            funcDic.TryGetValue(FunctionIdDef.BANGPAI, out btn);
            if (btn != null && btn.btn != null)
            {

                btn.btn.redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.BANGPAI) ||
                                        functionModel.IsFuncNeedRedDot(FunctionIdDef.CORPBUILD);// ||
                                      //  functionModel.IsFuncNeedRedDot(FunctionIdDef.CORPBENIFIT);
            }

            funcDic.TryGetValue(FunctionIdDef.XINFAJINENG, out btn);

            if (btn != null && btn.btn != null)
            {
                btn.btn.redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.XINFAJINENG) ||
                                functionModel.IsFuncNeedRedDot(FunctionIdDef.BANGPAIFUZHU) ||
                                functionModel.IsFuncNeedRedDot(FunctionIdDef.BANGPAIXIULIAN);
            }

            //邮件
            GameUUButton friendBtn = GetFriendBtn();
            if (friendBtn != null)
            {
                friendBtn.redDotVisible = (chatModel.HasUnreadSysNotice() ||
                    chatModel.HasUnreadPrivateChatMsg()) ||
                    functionModel.IsFuncNeedRedDot(FunctionIdDef.YOUJIAN);
            }
            //精彩活动2
            UpdateChargeActivityRedDot();
        }

        public void UpdateChargeActivityRedDot(RMetaEvent e= null)
        {
            //精彩活动2
            MainButtonUI btn;
            funcDic.TryGetValue(FunctionIdDef.JINGCAIHUODONG2, out btn);
            if (btn != null && btn.btn != null)
            {
                btn.btn.redDotVisible = GoodActivityModel.Ins.ChargeActivityHasRedDot();
            }
        }

        private void startBangPaiRecord(RMetaEvent e)
        {
            chatModel.CurrentRecordingChannel = ChatScopeType.CHAT_SCOPE_CORPS;
            startRecord(e);
        }

        private void startDuiwuRecord(RMetaEvent e)
        {
            chatModel.CurrentRecordingChannel = ChatScopeType.CHAT_SCOPE_TEAM;
            startRecord(e);
        }

        private bool isRecording = false;
        private void startRecord(RMetaEvent e)
        {
            try
            {
                if (isRecording == false)
                {
                    isRecording = true;
                    AudioManager.Ins.SetAllMuteTmp(true);
                    ClientLog.LogWarning("开始录音");
                    UI.isRecording.gameObject.SetActive(true);
                    PlatForm.Instance.StartChat();
                    //int pindao = ChatModel.Ins.CurrentRecordingChannel;
                    //ChatCGHandler.sendCGChatMsg(pindao,"", "", (e!=null?e.type:"")+"  开始录音",0);
                }
            }
            catch (Exception ex)
            {
                ClientLog.LogWarning("调用开始录音，错误：" + ex.ToString());
            }
        }

        private void stopRecord(RMetaEvent e)
        {
            try
            {
                if (isRecording)
                {
                    isRecording = false;
                    ClientLog.LogWarning("停止录音");
                    UI.isRecording.gameObject.SetActive(false);
                    AudioManager.Ins.SetAllMuteTmp(false);
                    PlatForm.Instance.StopChat();
                }
            }
            catch (Exception ex)
            {
                ClientLog.LogWarning("调用开始录音，错误：" + ex.ToString());
            }
        }

        private void cancelRecord(RMetaEvent e)
        {
            try
            {
                if (isRecording)
                {
                    isRecording = false;
                    ClientLog.LogWarning("取消录音");
                    UI.isRecording.gameObject.SetActive(false);
                    AudioManager.Ins.SetAllMuteTmp(false);
                    //PlatForm.Instance.CancelChat();
                }
            }
            catch (Exception ex)
            {
                ClientLog.LogWarning("调用取消录音，错误：" + ex.ToString());
            }
        }

        public void AddNewFuncBtn(RMetaEvent e)
        {
            FuncShowInfo funcshowInfo = e.data as FuncShowInfo;
            if (JuQingManager.Ins.IsPlayingJuQing)
            {
                waitingAddNewFunc.Add(funcshowInfo);
            }
            else
            {
                addNewFuncId = funcshowInfo.funcType;
                //ClientLog.LogError("AddNewFuncBtn RMetaEvent" + addNewFuncId);
                NewFuncView newfuncview = Singleton.GetObj(typeof (NewFuncView)) as NewFuncView;
                string newfuncicon = newfuncview.GetMainUIBtnNameByFuncId(addNewFuncId);
                if (ServerConfig.instance.IsPassedCheck&&!string.IsNullOrEmpty(newfuncicon))
                {
                    //ClientLog.LogError("NewFuncViewWnd show");
                    WndManager.open(GlobalConstDefine.NewFuncViewWnd);
                }
                else
                {
                    MoveNewFuncBtn();
                }
            }
        }

        public void endJuQing(RMetaEvent e = null)
        {
            if (waitingAddNewFunc.Count>0)
            {
                RMetaEvent ev=new RMetaEvent("",waitingAddNewFunc[0]);
                waitingAddNewFunc.RemoveAt(0);
                AddNewFuncBtn(ev);
            }
        }

        public void UpdateFuncBtnInfo(RMetaEvent e)
        {
            UpdateFuncBtns();
            UpdateFuncRedDot();
        }

        private MainButtonUI addNewFuncBtn;
        private Vector3 endPos;
        public int addNewFuncId;
        private List<FuncShowInfo> waitingAddNewFunc = new List<FuncShowInfo>();
        /// <summary>
        /// 添加一个功能 带特效
        /// </summary>
        private void addOneFuncWithEffect(int functype)
        {
            MainButtonUI buttonui;
            addNewFuncBtn = null;
            endPos = Vector3.zero;
            bool needMove = false;

            funcDic.TryGetValue(functype, out buttonui);
            if (buttonui != null)
            {
                if (ZoneUI.ins.isShown && UI.mainuiButton.isActiveAndEnabled&& UGUIConfig.UICamera.isActiveAndEnabled
                    &&!JuQingManager.Ins.IsPlayingJuQing)
                {
                    if (UI.mainuiButton.downBtnGrid.Contains(buttonui)||UI.mainuiButton.rightBtnGrid.Contains(buttonui))
                    {
                        if (!isShowingBtns)
                        {
                            clickBaGua();
                        }
                    }
                    buttonui.transform.parent.gameObject.SetActive(true);
                    if (UI.mainuiButton.downBtnGrid.Contains(buttonui))
                    {
                        endPos = new Vector3(44,-45,0);
                        Vector3 startPos = UI.mainuiButton.transform.parent.TransformPoint(Vector3.zero);
                        startPos = buttonui.transform.parent.InverseTransformPoint(startPos);
                        buttonui.transform.localPosition = startPos;

                        downMask = UI.mainuiButton.downBtns.transform.parent.GetComponent<Mask>();
                        downMaskImg = UI.mainuiButton.downBtns.transform.parent.GetComponent<GameUUImageIgnoreRaycast>();
                        downMaskImg.enabled = false;
                        downMask.enabled = false;
                        needMove = true;
                    }
                    if (UI.mainuiButton.rightBtnGrid.Contains(buttonui))
                    {
                        endPos = new Vector3(44, -45, 0);
                        Vector3 startPos = UI.mainuiButton.transform.parent.TransformPoint(Vector3.zero);
                        startPos = buttonui.transform.parent.InverseTransformPoint(startPos);
                        buttonui.transform.localPosition = startPos;

                        downMask = UI.mainuiButton.rightBtns.transform.parent.GetComponent<Mask>();
                        downMaskImg = UI.mainuiButton.rightBtns.transform.parent.GetComponent<GameUUImageIgnoreRaycast>();
                        downMaskImg.enabled = false;
                        downMask.enabled = false;
                        needMove = true;
                    }
                    if (UI.mainuiButton.topBtnGrid.Contains(buttonui))
                    {
                        endPos = new Vector3(44, -45, 0);
                        Vector3 startPos = UI.mainuiButton.transform.parent.TransformPoint(Vector3.zero);
                        startPos = buttonui.transform.parent.InverseTransformPoint(startPos);
                        buttonui.transform.localPosition = startPos;

                        //downMask = UI.mainuiButton.topBtns.transform.parent.GetComponent<Mask>();
                        //downMask.enabled = false;
                        //downMaskImg = UI.mainuiButton.topBtns.transform.parent.GetComponent<GameUUImageIgnoreRaycast>();
                        //downMaskImg.enabled = false;
                        
                        needMove = true;
                    }

                    addNewFuncBtn = buttonui;
                }
                else
                {
                    buttonui.transform.parent.gameObject.SetActive(true);
                }
            }
            if (addNewFuncBtn != null)
            {
                if (needMove)
                {
                    TweenUtil.MoveTo(addNewFuncBtn.transform, endPos, 1, null, moveEnd);
                }
                else
                {
                    moveEnd();
                }
            }
            else
            {
                moveEnd();
            }
        }
        /// <summary>
        /// 移动按钮
        /// </summary>
        public void MoveNewFuncBtn()
        {
            addOneFuncWithEffect(addNewFuncId);

            MainButtonUI buttonui;
            funcDic.TryGetValue(addNewFuncId, out buttonui);
            if (buttonui != null)
            {
                UpdateFuncRedDot();
            }
        }

        private void moveEnd()
        {
            if (downMaskImg != null) downMaskImg.enabled = true;
            if (downMask != null) downMask.enabled = true;
            downMask = null;
            downMaskImg = null;

            if (functionModel.hasNewFuncOpen())
            {
                //ClientLog.LogError("下一个，检查有没有新功能开启" + (functionModel.waitingShowFunc!=null?functionModel.waitingShowFunc.Count:0));
                //检查有没有新功能开启
                functionModel.checkAddNewFunc();
            }
            else
            {
                //ClientLog.LogError("没有新功能拉");
                addNewFuncId = 0;
                //检测是否有新手引导
                checkNewFuncAndGuide();
            }
        }

        private void showGuide(RMetaEvent e)
        {
            //ClientLog.LogError("ZoneUI,showGuide," + e.type + "  " + (GuideIdDef)e.data);
            if (e != null && e.data != null)
            {
                if (e.type == GuideManager.Ins.EndGuideEvent)
                {
                    checkNewFuncAndGuide();
                    return;
                }
                             
                switch ((GuideIdDef)e.data)
                {
                    case GuideIdDef.FirstBattle:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        break;
                    case GuideIdDef.QianDao:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.QianDao, 1, UI.mainuiButton.leftBtnGrid[0].gameObject);
                        break;
                    case GuideIdDef.KeJu:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.KeJu, 1, UI.mainuiButton.topBtnGrid[0].gameObject);
                        break;
                    case GuideIdDef.JingJiChang:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.JingJiChang, 1, UI.mainuiButton.topBtnGrid[0].gameObject);
                        break;
                    case GuideIdDef.LvYeXianZong:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.LvYeXianZong, 1, UI.mainuiButton.topBtnGrid[0].gameObject);
                        break;
                    case GuideIdDef.JiuGuan:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.JiuGuan, 1, UI.mainuiButton.topBtnGrid[0].gameObject);
                        break;
                    case GuideIdDef.CangBaoTu:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.CangBaoTu, 1, UI.mainuiButton.topBtnGrid[0].gameObject);
                        break;
                    case GuideIdDef.YunLiang:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.YunLiang, 1, UI.mainuiButton.topBtnGrid[0].gameObject);
                        break;
                    case GuideIdDef.ChuBao:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.ChuBao, 1, UI.mainuiButton.topBtnGrid[0].gameObject);
                        break;
                    case GuideIdDef.ShengXing:
                        WndManager.Ins.HideAllCurrentShowWnd();
                        bool nowshow = false;
                        if (!isShowingBtns)
                        {
                            nowshow = true;
                            clickBaGua();
                        }
                        GuideManager.Ins.ShowGuide(GuideIdDef.ShengXing, 1, UI.mainuiButton.downBtnGrid[4].gameObject, false, nowshow?400:0);
                        break;
                    case GuideIdDef.DaZao:
                        WndManager.Ins.HideAllCurrentShowWnd();
                        bool nowshowdazao = false;
                        if (!isShowingBtns)
                        {
                            nowshowdazao = true;
                            clickBaGua();
                        }
                        GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 1, UI.mainuiButton.downBtnGrid[4].gameObject, false, nowshowdazao ? 400 : 0);
                        break;
                    case GuideIdDef.Gem:
                        WndManager.Ins.HideAllCurrentShowWnd();
                        bool nowshowgem = false;
                        if (!isShowingBtns)
                        {
                            nowshowgem = true;
                            clickBaGua();
                        }
                        GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 1, UI.mainuiButton.downBtnGrid[4].gameObject, false, nowshowgem ? 400 : 0);
                        break;
                    case GuideIdDef.LevelReward:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.LevelReward, 1, UI.mainuiButton.leftBtnGrid[0].gameObject, false);
                        break;
                    case GuideIdDef.TongTianTa:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.TongTianTa, 1, UI.mainuiButton.topBtnGrid[2].gameObject);
                        break;
                    case GuideIdDef.PetTalent:
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.PetTalent, 1, UI.userInfo.petInfo.gameObject,false);
                        break;
                    case GuideIdDef.SkillShuLian:
                        WndManager.Ins.HideAllCurrentShowWnd();
                        bool nowskill = false;
                        if (!isShowingBtns)
                        {
                            nowskill = true;
                            clickBaGua();
                        }
                        GuideManager.Ins.ShowGuide(GuideIdDef.SkillShuLian, 1, UI.mainuiButton.downBtnGrid[1].gameObject, false, nowskill ? 400 : 0);
                        break;
                    case GuideIdDef.XinFaShengJi:
                        WndManager.Ins.HideAllCurrentShowWnd();
                        bool nowxinfa = false;
                        if (!isShowingBtns)
                        {
                            nowxinfa = true;
                            clickBaGua();
                        }
                        GuideManager.Ins.ShowGuide(GuideIdDef.XinFaShengJi, 1, UI.mainuiButton.downBtnGrid[1].gameObject, false, nowxinfa ? 400 : 0);
                        break;
                    case GuideIdDef.SkillShengJi:
                        WndManager.Ins.HideAllCurrentShowWnd();
                        bool nowsshengji = false;
                        if (!isShowingBtns)
                        {
                            nowsshengji = true;
                            clickBaGua();
                        }
                        GuideManager.Ins.ShowGuide(GuideIdDef.SkillShengJi, 1, UI.mainuiButton.rightBtnGrid[0].gameObject, false, nowsshengji ? 400 : 0);
                        break;
                    case GuideIdDef.RingTask:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.RingTask, 1, UI.mainuiButton.topBtnGrid[0].gameObject);
                        break;
                    case GuideIdDef.AddFriend:
                        hideChatPanel();
                        WndManager.Ins.HideAllCurrentShowWnd();
                        GuideManager.Ins.ShowGuide(GuideIdDef.AddFriend, 1, UI.friendBtn.gameObject, false, 0);
                        break;
                }
            }
        }

        private void hideChatPanel()
        {
            if (chatView != null && UI.chatPanelUI!=null)
            {
                chatView.hidePanel();
            }
        }
        
        public void checkNewFuncAndGuide()
        {
            //if (StateManager.Ins.getCurState() != null && StateManager.Ins.getCurState().state == StateDef.zoneState
            //    && AutoMaticManager.Ins.CurAutoMaticType == AutoMaticManager.AutoMaticType.None
            //    && ((ZoneCharacterManager.ins.self != null && ZoneCharacterManager.ins.self.curBehavType == ZoneCharacterBehavType.IDLE))
            //    && ((GuideManager.Ins.isWaitingGuideNeedAllWndHide() && !WndManager.Ins.hasWndShowing())
            //    || !GuideManager.Ins.isWaitingGuideNeedAllWndHide())
            //    && addNewFuncId == 0 && waitingAddNewFunc.Count==0 && GuideManager.Ins.CurrentGuideId == GuideIdDef.NONE && hasInit
            //    && !JuQingManager.Ins.IsPlayingJuQing)
            //{
                //检查有没有新功能开启
                if (!FunctionModel.Ins.hasNewFuncOpen())
                {
                    //没有功能开启，检查有没有可以做的新手引导
                    if (!GuideManager.Ins.checkWaitingGuide())
                    {
                        //检查是否 还有 ，需要引导的功能
                        GuideManager.Ins.checkFuncGuide();
                    }
                }
                else
                {
                    FunctionModel.Ins.checkAddNewFunc();
                }
            //}
        }

        #endregion

        #region 主界面队伍逻辑

        public void UpdateTeamInfo()
        {
            if (TeamModel.ins.myTeamMemberList != null)
            {
                int dataLen = TeamModel.ins.myTeamMemberList.Length;

                for (int i = 0; i < dataLen; i++)
                {
                    mTeamMemberItems[i].SetData(TeamModel.ins.myTeamMemberList[i]);
                }

                int itemsLen = mTeamMemberItems.Count;
                for (int i = dataLen; i < itemsLen; i++)
                {
                    mTeamMemberItems[i].SetData(null);
                }
            }
            else
            {
                int itemsLen = mTeamMemberItems.Count;
                for (int i = 0; i < itemsLen; i++)
                {
                    mTeamMemberItems[i].SetData(null);
                }
            }

            if (TeamModel.ins.teamApplyAuto != null && TeamModel.ins.teamApplyAuto.getIsAuto() == 1)
            {
                TeamTargetTemplate tpl = TeamTargetTemplateDB.Instance.getTemplate(TeamModel.ins.teamApplyAuto.getTargetId());
                if (tpl != null)
                {
                    UI.questUI.autoMatchTeamPurpose.text = tpl.name;
                }
                else
                {
                    UI.questUI.autoMatchTeamPurpose.text = "???";
                }

                UI.questUI.exitTeamAutoMatchBtn.gameObject.SetActive(true);
            }
            else
            {
                UI.questUI.autoMatchTeamPurpose.text = "";
                UI.questUI.exitTeamAutoMatchBtn.gameObject.SetActive(false);
            }

            mainuiQuestview.UpdateTeamPanelVisible();
        }

        private void OnExitTeamAutoMatchBtnClicked()
        {
            TeamCGHandler.sendCGTeamApplyAuto(0, TeamModel.ins.teamApplyAuto.getTargetId());
        }

        private void ClickTeamMemberItems(GameObject go)
        {
            int len = mTeamMemberItems.Count;
            for (int i = 0; i < len; i++)
            {
                MainUITeamMemberItem item = mTeamMemberItems[i];
                if (item.UI.gameObject == go)
                {
                    if (item.GetData().uuid == Human.Instance.Id)
                    {
                        if (!UI.questUI.teamMemberOperList.activeSelf)
                        {
                            UI.questUI.teamMemberOperList.SetActive(true);
                            Vector3 pos = UI.questUI.teamMemberOperList.transform.localPosition;
                            pos.y = go.transform.localPosition.y;
                            UI.questUI.teamMemberOperList.transform.localPosition = pos;
                            int myStatus = TeamModel.ins.GetTeamMemberInfo(Human.Instance.Id).status;
                            UI.questUI.leaveTeamBtn.gameObject.SetActive(myStatus == 1);
                            UI.questUI.backToTeamBtn.gameObject.SetActive(myStatus == 2);
                            mNeedHideTeamMemberOperList = false;
                        }
                    }
                    else
                    {
                        UI.questUI.teamMemberOperList.SetActive(false);
                    }
                    break;
                }
            }
        }

        private void OnLeaveTeamBtnClicked()
        {
            if (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.TEAM_LEADER_CANNOT_LEAVE_TEAM);
            }
            else
            {
                TeamModel.ins.doTeamAway();
            }
        }

        private void OnBackToTeamBtnClicked()
        {
            TeamCGHandler.sendCGTeamBack();
        }

        private void OnExitTeamBtnClicked()
        {
            TeamModel.ins.doTeamQuit();
        }

        private int tishengClickCount;

        private void OnSceneUpHandler(RMetaEvent e)
        {
            if (mNeedHideTeamMemberOperList)
            {
                UI.questUI.teamMemberOperList.SetActive(false);
            }
            mNeedHideTeamMemberOperList = !mNeedHideTeamMemberOperList;
            //关闭提升列表
            if (tishengClickCount == 0 && mTishengView.MButtonState)
            {
                tishengClickCount++;
            }
            else
            {
                if (mTishengView.MButtonState && !InputManager.Ins.HasDownMove())
                {
                    TiShengModel.instance.OnClick();
                }
                tishengClickCount = 0;
            }
        }

#endregion

        private void OnMapBtnClicked()
        {
            DataReport.Instance.Game_SetEvent("c_touch", "mainui", FunctionIdDef.WORLDMAP.ToString());
            WndManager.open(GlobalConstDefine.WorldMapView_Name);
        }

        public GameUUButton GetFriendBtn()
        {
            if (UI != null)
            {
                return UI.friendBtn;
            }
            return null;
        }

        //private void OnTowerInfoChanged(RMetaEvent e = null)
        //{
        //    if (TongTianTaModel.ins.towerInfo != null)
        //    {
        //        UI.tfHulu.gameObject.SetActive(TongTianTaModel.ins.towerInfo.openDouble == 1);
        //        //UI.textDoublePoint.text = GuaJIModel.ins.towerInfo.curDoublePoint+ "点";
        //    }
        //}

        private void GuaJiInfo(RMetaEvent e = null)
        {
            if (NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().guaJi)
            {
                UI.userInfo.m_guajiicon.gameObject.SetActive(true);
            }
            else
            {
                UI.userInfo.m_guajiicon.gameObject.SetActive(false);
            }
        }

        public override void Destroy()
        {
            petModel.removeChangeEvent(PetModel.UPDATE_PET_PROP, updatePetInfo);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_LIST, updatePetInfo);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE, updatePetInfo);

            QuestModel.Ins.removeChangeEvent(QuestModel.UPDATEQUESTLIST, updateJiangLiOFQiRiRedDot);
            PlayerModel.Ins.removeChangeEvent(PlayerModel.UPDATE_LOGIN_DAYS, updateJiangLiOFQiRiRedDot);

            InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, OnSceneUpHandler);
            //InputManager.Ins.RemoveListener(InputManager.CLICK_EVENT_TYPE, UI.chatUI.boxCollider.gameObject, ShowChatPanel);
            //EventTriggerListener.Get(UI.chatUI.boxCollider.gameObject).onClick = null;

            InputManager.Ins.RemoveListener(InputManager.CANCEL_STATIONARY_EVENT_TYPE, UI.gameObject, cancelRecord);
            InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, stopRecord);

            InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, UI.chatUI.BangPailuyin.gameObject, startBangPaiRecord);
            InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, UI.chatUI.Duiwuluyin.gameObject, startDuiwuRecord);

            functionModel.removeChangeEvent(FunctionModel.ADD_NEW_FUNC, AddNewFuncBtn);
            functionModel.removeChangeEvent(FunctionModel.FUNC_INFO_UPDATE, UpdateFuncBtnInfo);

            onlineRewardModel.removeChangeEvent(OnlineRewardModel.UPDATE_REDDOT_STATE, UpdateFuncRedDot);

            chatModel.removeChangeEvent(ChatModel.APPEND_ONE_MSG, updateMsgContent);

            //TongTianTaModel.ins.removeChangeEvent (TongTianTaModel.UPDATE_TOWERINFO, OnTowerInfoChanged);

            EventCore.removeRMetaEventListener(GuideManager.Ins.StartGuideEvent, showGuide);
            EventCore.removeRMetaEventListener(GuideManager.Ins.EndGuideEvent, showGuide);

            EventCore.removeRMetaEventListener(JuQingManager.END_JUQING_EVENT, endJuQing);
            NewGuaJiModel.Ins.removeChangeEvent(NewGuaJiModel.REFRESH_GUAJI_INFO, GuaJiInfo);

            goodactivityModel.removeChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY2_RedDot, UpdateChargeActivityRedDot);

            if (mainuiQuestview != null)
            {
                mainuiQuestview.Destroy();
                mainuiQuestview = null;
            }

            if (chatView != null)
            {
                chatView.Destroy();
                chatView = null;
            }

            if (shituView != null)
            {
                shituView.Destroy();
                shituView = null;
            }

            if (mTishengView != null)
            {
                mTishengView.Destroy();
                mTishengView = null;
            }
            //if (chatMsgList!=null)
            //{
            //    chatMsgList.Clear();
            //    chatMsgList = null;
            //}
            if (chatTextList != null)
            {
                for (int i=0;i<chatTextList.Count;i++)
                {
                    chatTextList[i].Destroy();
                }
                chatTextList.Clear();
                chatTextList = null;
            }
            waitingAddNewFunc.Clear();
            base.Destroy();
            UI = null;
            mIns = null;
        }
    }
}