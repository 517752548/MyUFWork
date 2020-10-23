using app.net;
using app.reward;
using app.zone;
using app.chat;
using app.model;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


namespace app.relation
{
    public class RelationView : BaseWnd
    {
        //[Inject(ui = "RelationUI")]
        //public GameObject ui;
        public const int CHARACTER_LIMIT = 30;
        public RelationUI UI;

        private List<RelationItemScript> zuijinRenList;
        private List<RelationItemScript> haoyouList;
        private List<RelationItemScript> blackList;
        private List<RelationItemScript> mailList;

        private RelationInfo curRelationInfo;

        public RelationModel relationModel;
        public MailModel mailModel;
        public ChatModel chatModel;
        public FunctionModel functionModel;

        private List<RelationChatItemScript> chatMsgList;

        private List<RewardItem> mailRewardItemList;

        private InputField inputField;

        private Coroutine mUpdateZuijinRenListCorotine = null;
        private Coroutine mUpdateFriendListCorotine = null;
        private Coroutine mUpdateBlackListCorotine = null;
        private Coroutine mUpdateMailListCorotine = null;

        private int mZuiJinLianXiSelectIdx = -1;
        private bool mNeedHideOperList = false;

        public RelationView()
        {
            uiName = "RelationUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();

            relationModel = RelationModel.Ins;
            relationModel.addChangeEvent(RelationModel.REFRESH_Relation_LIST, UpdateLianxirenList);
            relationModel.addChangeEvent(RelationModel.ADD_Relation_Success, AddRelation);
            relationModel.addChangeEvent(RelationModel.DEL_Relation_Success, DelRelation);
            mailModel = MailModel.Ins;
            mailModel.addChangeEvent(MailModel.UPDATE_MAIL_INFO, updateCurrentMail);
            mailModel.addChangeEvent(MailModel.REFRESH_LIST, updateMailList);
            chatModel = ChatModel.Ins;
            chatModel.addChangeEvent(ChatModel.APPEND_ONE_MSG, updateMsgContent);
            chatModel.addChangeEvent(ChatModel.ADD_ZUIJINLIANXIREN, AddNewZuiJinLianXiRen);
            chatModel.addChangeEvent(ChatModel.DEL_ZUIJINLIANXIREN, DelZuiJinLianXiRen);
            chatModel.addChangeEvent(ChatModel.UPDATE_ZUIJINLIANXIREN, UpdateZuiJinLianXiRenData);
            functionModel = FunctionModel.Ins;
            functionModel.addChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.addChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);

            UI = ui.AddComponent<RelationUI>();
            UI.Init();

            UI.closeBtn.SetClickCallBack(closePanel);
            UI.addFriendBtn.SetClickCallBack(ShowAddFriend);
            /*
            UI.sendMsgBtn.SetClickCallBack(clickSendMsg);
            RectTransform rtf = UI.inputBg.gameObject.GetComponent<RectTransform>();
            inputField = CreateInputField(Color.black, 20, UI.inputBg);
            inputField.characterLimit = 30;
            */
            //UI.operationListGo.SetActive(false);
            //EventTriggerListener.Get(UI.operationBg.gameObject).onClick = clickOperateBg;

            functionModel.AddFuncBindObj(FunctionIdDef.YOUJIAN, UI.lefttopBtn.toggleList[2].gameObject);
            UI.lefttopBtn.TabChangeHandler = changeTab;
            UI.lefttopBtn.SetIndexWithCallBack(0);

            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, hideOperateList);
        }

        private void selectZuijinLianxi(int tab)
        {
            InitMsgContentUI();
            InitSendMsgUI();
            SetChildVisible(UI.MsgContent, true);
            //UI.youshangjiaoGo.SetActive(true);
            inputField.text = "";
            SetChildVisible(UI.sendMsgBtn, true);
            SetChildVisible(UI.youshangBlackGo, false);
            SetChildVisible(UI.duifangMsg, false);
            if (tab == 0)
            {
//系统消息
                if (chatMsgList == null)
                {
                    chatMsgList = new List<RelationChatItemScript>();
                }
                List<SysNoticeInfoData> sysNoticeList = chatModel.SysNoticeList;
                //系统消息
                for (int i = 0; sysNoticeList != null && i < sysNoticeList.Count; i++)
                {
                    if (i >= chatMsgList.Count)
                    {
                        ChatMsgItemUI item = GameObject.Instantiate(UI.duifangMsg);
                        SetChildVisible(item, true);
                        RelationChatItemScript script = new RelationChatItemScript(item);
                        chatMsgList.Add(script);
                        item.transform.SetParent(UI.msgLayout.transform);
                        item.transform.localScale = Vector3.one;
                    }
                    SetChildVisible(chatMsgList[i].UI, true);
                    chatMsgList[i].setSysNoticeInfo(sysNoticeList[i]);
                    sysNoticeList[i].setHasReaden(true);
                }
                if (sysNoticeList != null)
                {
                    for (int i = sysNoticeList.Count; i < chatMsgList.Count; i++)
                    {
                        chatMsgList[i].UI.gameObject.SetActive(false);
                    }
                }

                SetChildVisible(UI.youshangjiaoGo, false);
            }
            else
            {
//其他玩家
                for (int i = 0; chatMsgList != null && i < chatMsgList.Count; i++)
                {
                    if (chatMsgList[i].UI != null)
                    {
                        SetChildVisible(chatMsgList[i].UI, false);
                    }
                }

                showSiLiaoMsg(
                    long.Parse(
                        zuijinRenList[UI.zuijinTBG.index].playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID)));
                //showSiLiaoMsg(zuijinRenList[UI.zuijinTBG.index].data.uuid);
                SetChildVisible(UI.youshangjiaoGo, true);
            }

            UpdateZuijinLianxirenRedDot();
            UpdateHaoyouRedDot();
        }

        private void UnselectAllZuiJinLianXiRen()
        {
            SetChildVisible(UI.youshangjiaoGo, false);
            SetChildVisible(UI.MsgContent, false);
        }

        private void selectFriendOrBlackList(int tab)
        {
            if (tab == 0)
            {
                SetChildVisible(UI.youshangBlackGo, false);
            }
            else
            {
                InitSendMsgUI();
                SetChildVisible(UI.youshangBlackGo, true);
                SetChildVisible(UI.youshangjiaoGo, true);
            }
        }

        private void selectHaoyou(int tab)
        {
            InitMsgContentUI();
            InitSendMsgUI();
            SetChildVisible(UI.MsgContent, true);
            SetChildVisible(UI.youshangjiaoGo, true);
            inputField.text = "";
            SetChildVisible(UI.sendMsgBtn, true);
            SetChildVisible(UI.youshangBlackGo, false);
            showSiLiaoMsg(haoyouList[UI.haoyouTBG.index].data.uuid);
        }

        private void UnSelectAllHaoYou()
        {
            SetChildVisible(UI.MsgContent, false);
            SetChildVisible(UI.youshangjiaoGo, false);
        }

        private void selectBlack(int tab)
        {
            InitSendMsgUI();
            SetChildVisible(UI.MsgContent, false);
            SetChildVisible(UI.youshangjiaoGo, true);
            inputField.text = "";
            SetChildVisible(UI.youshangBlackGo, true);
            SetChildVisible(UI.sendMsgBtn, false);
        }

        private void UnSelectAllBlack()
        {
            SetChildVisible(UI.MsgContent, false);
            SetChildVisible(UI.youshangjiaoGo, false);
        }

        public void updateCurrentMail(RMetaEvent e)
        {
            if (!UI.mailInited)
            {
                return;
            }
            if (UI.mailTBG.index >= 0 && UI.mailTBG.index < mailModel.MailList.Count)
            {
                MailInfoData currentmailinfo = mailModel.MailList[UI.mailTBG.index];
                MailInfoData mailinfo = e.data as MailInfoData;
                if (currentmailinfo.uuid == mailinfo.uuid)
                {
                    selectMail(UI.mailTBG.index);
                }
                UpdateMailInfo(mailinfo);
            }
        }

        private void UpdateMailInfo(MailInfoData infodata)
        {
            if (!UI.mailInited)
            {
                return;
            }

            for (int i = 0; i < mailList.Count; i++)
            {
                if (mailList[i].mailInfo.uuid == infodata.uuid)
                {
                    mailList[i].setMailData(infodata);
                }
            }
        }

        private void selectMail(int tab)
        {
            InitMailContentUI();
            SetChildVisible(UI.mailContentGo, true);
            SetChildVisible(UI.youshangjiaoGo, false);
            SetChildVisible(UI.youshangBlackGo, false);
            MailInfoData mailinfo = mailModel.MailList[tab];
            UI.mailTitleText.text = mailinfo.title;
            UI.mailContentText.text = mailinfo.content;

            if (mailinfo.attachmented == 1 && !string.IsNullOrEmpty(mailinfo.rewardInfo.rewardStr))
            {
                //有附件
                SetChildVisible(UI.mailItemScroller, true);
                SetChildVisible(UI.jiangliGo, true);
                SetChildVisible(UI.defaultJiangliItem, false);
                if (mailRewardItemList == null)
                {
                    mailRewardItemList = new List<RewardItem>();
                }
                RewardData rewardData = new RewardData();
                rewardData.ParseReward(mailinfo.rewardInfo.rewardStr);
                for (int i = 0; i < rewardData.items.Count; i++)
                {
                    if (i >= mailRewardItemList.Count)
                    {
                        CommonItemUI itemui = GameObject.Instantiate(UI.defaultJiangliItem);
                        RewardItem rewardItem = new RewardItem(itemui);
                        mailRewardItemList.Add(rewardItem);
                        itemui.transform.SetParent(UI.jiangliItemGrid.transform);
                        itemui.transform.localScale = Vector3.one;
                    }
                    mailRewardItemList[i].UI.ScrollRect = UI.mailItemScroller;
                    SetChildVisible(mailRewardItemList[i].UI, true);
                }
                rewardData.Parse(mailinfo.rewardInfo.rewardStr, mailRewardItemList);
                for (int i = rewardData.items.Count; i < mailRewardItemList.Count; i++)
                {
                    SetChildVisible(mailRewardItemList[i].UI, false);
                }
                UI.lingquBtn.ClearClickCallBack();
                UI.lingquBtn.SetClickCallBack(clickLingQu);
            }
            else
            {
                SetChildVisible(UI.jiangliGo, false);
                SetChildVisible(UI.mailItemScroller, false);
            }
            if (mailinfo.mailStatus != 2)
            {
                MailCGHandler.sendCGReadMail(mailinfo.uuid);
            }
        }

        private void clickLingQu()
        {
            if (UI.mailTBG.index >= 0 && UI.mailTBG.index < mailModel.MailList.Count)
            {
                MailInfoData mailinfo = mailModel.MailList[UI.mailTBG.index];
                MailCGHandler.sendCGGetMailAttachment(mailinfo.uuid);
            }
        }

        private void showSiLiaoMsg(long duifangRoleUUid)
        {
            if (chatMsgList == null)
            {
                chatMsgList = new List<RelationChatItemScript>();
            }
            SetChildVisible(UI.duifangMsg, false);

            List<ChatMsgData> siliaoMsgList = chatModel.getSiLiaoChatList(duifangRoleUUid.ToString());
            //系统消息
            for (int i = 0; siliaoMsgList != null && i < siliaoMsgList.Count; i++)
            {
                if (i >= chatMsgList.Count)
                {
                    ChatMsgItemUI item = GameObject.Instantiate(UI.duifangMsg);
                    SetChildVisible(item, true);
                    RelationChatItemScript script = new RelationChatItemScript(item);
                    chatMsgList.Add(script);
                    item.transform.SetParent(UI.msgLayout.transform);
                    item.transform.localScale = Vector3.one;
                }
                SetChildVisible(chatMsgList[i].UI, true);
                chatMsgList[i].setSiLiaoMsgInfo(siliaoMsgList[i]);
                siliaoMsgList[i].setHasReaden(true);
            }
            int hasLen = (siliaoMsgList != null) ? siliaoMsgList.Count : 0;
            for (int i = hasLen; i < chatMsgList.Count; i++)
            {
                SetChildVisible(chatMsgList[i].UI, false);
            }

            UpdateZuijinLianxirenRedDot();
            UpdateHaoyouRedDot();
        }

        private void hideOperateList(RMetaEvent e)
        {
            if (UI.operationListGo != null)
            {
                if (mNeedHideOperList)
                {
                    SetChildVisible(UI.operationListGo, false);
                }
                if (UI.operationListGo != null)
                {
                    if (UI.operationListGo.gameObject.activeSelf)
                    {
                        mNeedHideOperList = true;
                    }
                    else
                    {
                        mNeedHideOperList = false;
                    }
                }
            }
        }

        public void showOperate(int relationType, RelationInfo relationinfo)
        {
            curRelationInfo = relationinfo;
            InitOperationListUI();
            //SetChildVisible(UI.operationListGo, true);
            SetChildVisible(UI.operateBtnList[0], false);
            SetChildVisible(UI.operateBtnList[2], false);
            SetChildVisible(UI.operateBtnList[5], false);
            // InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE,UI.gameObject,clickScreen);
            if (relationType == RelationType.HAOYOU)
            {
                SetChildVisible(UI.operateBtnList[0], false);
                SetChildVisible(UI.operateBtnList[1], true);
                SetChildVisible(UI.operateBtnList[3], true);
                SetChildVisible(UI.operateBtnList[4], false);
            }
            else if (relationType == RelationType.HEIMINGDAN)
            {
                SetChildVisible(UI.operateBtnList[0], true);
                SetChildVisible(UI.operateBtnList[1], false);
                SetChildVisible(UI.operateBtnList[3], false);
                SetChildVisible(UI.operateBtnList[4], true);
            }
            SetChildVisible(UI.operationBg, true);
            SetChildVisible(UI.operationListGo, true);
            UI.operationListGo.transform.SetAsLastSibling();
        }

        private void addToHaoyouList()
        {
            if (curRelationInfo != null)
                RelationCGHandler.sendCGAddRelationById(RelationType.HAOYOU, curRelationInfo.uuid);
            //clickOperateBg();
        }

        private void addToBlackList()
        {
            if (curRelationInfo != null)
                RelationCGHandler.sendCGAddRelationById(RelationType.HEIMINGDAN, curRelationInfo.uuid);
            //clickOperateBg();
        }


        public void AddBiaoQing(string biaoqing)
        {
            if (inputField.text.Length < CHARACTER_LIMIT)
            {
                inputField.text += ChatContentBase.FACE_PREFIX + biaoqing;
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("已达字符上限！");
            }
        }

        public void ExhibitionItem(string chatitem)
        {
            inputField.text += chatitem;
            clickSendMsg(2);
        }

        public void ExhibitionPet(string chatpet)
        {
            inputField.text += chatpet;
            clickSendMsg(2);
        }

        private void clickSmileBtn()
        {
            chatModel.OpenBiaoqing();
        }

        private void clickSendMsg1()
        {
            clickSendMsg(0);
        }

        private void clickSendMsg(int chattype=0)
        {
            if (UI == null)
            {
                return;
            }
            if (UI.lefttopBtn == null)
            {
                return;
            }
            switch (UI.lefttopBtn.index)
            {
                case 0:
                //最近联系人

                //break;
                case 1:
                    //联系人(好友、黑名单)
                    if (UI.lefttopBtn.index == 0 || (UI.mainToggleTBG.index == 0 && UI.haoyouTBG.index >= 0))
                    {
                        string str = inputField.text;
                        if (string.IsNullOrEmpty(str))
                        {
                            inputField.text = "";
                            ZoneBubbleManager.ins.BubbleSysMsg("请输入聊天内容！");
                            return;
                        }
                        //好友
                        if (UI.lefttopBtn.index == 1)
                        {
                            ChatCGHandler.sendCGChatMsg(ChatScopeType.CHAT_SCOPE_PRIVATE,
                            haoyouList[UI.haoyouTBG.index].data.name,
                            haoyouList[UI.haoyouTBG.index].data.uuid.ToString(), inputField.text, chattype);
                        }
                        else if (UI.lefttopBtn.index == 0 && UI.zuijinTBG.index > 0)
                        {
                            ChatCGHandler.sendCGChatMsg(ChatScopeType.CHAT_SCOPE_PRIVATE,
                            zuijinRenList[UI.zuijinTBG.index].playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_NAME),
                            zuijinRenList[UI.zuijinTBG.index].playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID), inputField.text, chattype);
                        }

                        inputField.text = "";
                    }
                    break;
                case 2:
                    //邮件

                    break;
            }
        }

        private void delFriend()
        {
            if (curRelationInfo != null) RelationCGHandler.sendCGDelRelation(RelationType.HAOYOU, curRelationInfo.name);
            //clickOperateBg();
        }

        private void delFromBlackList()
        {
            if (curRelationInfo != null) RelationCGHandler.sendCGDelRelation(RelationType.HEIMINGDAN, curRelationInfo.name);
            //clickOperateBg();
        }

        private void ShowAddFriend()
        {
            hide();
            RelationCGHandler.sendCGShowRecommendFriendList();
            GuideManager.Ins.RemoveGuide(GuideIdDef.AddFriend);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            if (relationModel.HaoyouListNeedFresh || relationModel.BlackListNeedFresh)
            {
                relationModel.openRelationView(false);
            }

            if (e != null && e.data != null)
            {
                object selecttab = WndParam.GetWndParam(e, WndParam.RelationViewSelectZuijinLianxiren);
                if (selecttab != null)
                {
                    int.TryParse(selecttab.ToString(), out mZuiJinLianXiSelectIdx);
                    SelectZuiJinLianXiRen(mZuiJinLianXiSelectIdx);
                }
            }

            UpdateZuijinLianxirenRedDot();
            UpdateHaoyouRedDot();
            UpdateMailRedDot();
            app.main.GameClient.ins.OnBigWndShown();

            GuideManager.Ins.ShowGuide(GuideIdDef.AddFriend, 2, UI.addFriendBtn.gameObject, false, 0);
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
        }

        private void UpdateZuijinLianxirenRedDot()
        {
            bool hasUnreadSysNotice = chatModel.HasUnreadSysNotice();
            bool hasUnreadPrivateChatMsg = chatModel.HasUnreadPrivateChatMsg();
            UI.lefttopBtn.toggleList[0].redDotVisible = (hasUnreadSysNotice || hasUnreadPrivateChatMsg);
            if (zuijinRenList != null)
            {
                zuijinRenList[0].UI.toggel.redDotVisible = hasUnreadSysNotice;
                int len = zuijinRenList.Count;
                for (int i = 1; i < len; i++)
                {
                    //zuijinRenList[i].UI.toggel.redDotVisible = chatModel.HasUnreadPrivateChatMsg(zuijinRenList[i].data.uuid);
                    zuijinRenList[i].UI.toggel.redDotVisible = chatModel.HasUnreadPrivateChatMsg(long.Parse(zuijinRenList[i].playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID)));
                }
            }

            GameUUButton friendBtn = ZoneUI.ins.GetFriendBtn();
            if (friendBtn != null)
            {
                friendBtn.redDotVisible = friendBtn.redDotVisible && (hasUnreadSysNotice || hasUnreadPrivateChatMsg);
            }
        }

        private void UpdateHaoyouRedDot()
        {
            //UI.lefttopBtn.toggleList[1].redDotVisible = false;
            bool hasUnreadHaoyouMsg = false;
            if (relationModel.HaoyouList != null)
            {
                int len = relationModel.HaoyouList.Count;
                for (int i = 0; i < len; i++)
                {
                    if (chatModel.HasUnreadPrivateChatMsg(relationModel.HaoyouList[i].uuid))
                    {
                        hasUnreadHaoyouMsg = true;
                        break;
                    }
                }
            }

            UI.lefttopBtn.toggleList[1].redDotVisible = hasUnreadHaoyouMsg;

            if (haoyouList != null)
            {
                int len = haoyouList.Count;
                for (int i = 0; i < len; i++)
                {
                    haoyouList[i].UI.toggel.redDotVisible = chatModel.HasUnreadPrivateChatMsg(haoyouList[i].data.uuid);
                }
            }

            GameUUButton friendBtn = ZoneUI.ins.GetFriendBtn();
            if (friendBtn != null)
            {
                friendBtn.redDotVisible = friendBtn.redDotVisible && hasUnreadHaoyouMsg;
            }
        }

        private void UpdateMailRedDot()
        {
            UI.lefttopBtn.toggleList[2].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.YOUJIAN);
            GameUUButton friendBtn = ZoneUI.ins.GetFriendBtn();
            if (friendBtn != null)
            {
                friendBtn.redDotVisible = friendBtn.redDotVisible && functionModel.IsFuncNeedRedDot(FunctionIdDef.YOUJIAN);
            }
        }

        private void closePanel()
        {
            hide();
        }

        private void allMainToggleClose()
        {
            SetChildVisible(UI.youshangjiaoGo, false);
            SetChildVisible(UI.youshangBlackGo, false);
            /*
            for (int i = 0; i < haoyouList.Count; i++)
            {
                SetChildVisible(haoyouList[i].UI.gameObject, false);
            }
            for (int i = 0; i < blackList.Count; i++)
            {
                SetChildVisible(blackList[i].UI.gameObject, false);
            }
            */
            SetChildVisible(UI.whiteListGrid, false);
            SetChildVisible(UI.blackListGrid, false);
        }

        private void selectMainToggle(int tab)
        {
            UI.haoyouTBG.SetIndexWithCallBack(-1);
            SetChildVisible(UI.whiteListGrid, tab == 0);

            UI.heimingdanTBG.SetIndexWithCallBack(-1);
            SetChildVisible(UI.blackListGrid, tab == 1);
            /*
            List<RelationInfo> haoyouliebiao = relationModel.HaoyouList;
            int len = haoyouliebiao != null ? haoyouliebiao.Count : 0;
            for (int i = 0; i < len; i++)
            {
                haoyouList[i].UI.toggel.isOn = false;
                SetChildVisible(haoyouList[i].UI.gameObject, UI.mainToggleTBG.index == 0 ? true : false);
            }
            List<RelationInfo> blackliebiao = relationModel.BlackList;
            len = blackliebiao != null ? blackliebiao.Count : 0;
            for (int i = 0; i < len; i++)
            {
                blackList[i].UI.toggel.isOn = false;
                SetChildVisible(blackList[i].UI.gameObject, UI.mainToggleTBG.index == 1 ? true : false);
            }
            */
        }

        private void InitSendMsgUI()
        {
            if (!UI.sendMsgGoInited)
            {
                GameObject sendMsgGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "sengMsgGo"));
                sendMsgGo.name = "sengMsgGo";
                sendMsgGo.transform.SetParent(UI.transform);
                sendMsgGo.transform.localScale = Vector3.one;
                sendMsgGo.transform.localPosition = new Vector3(180, 200, 0);
                sendMsgGo.SetActive(true);
                UI.InitSendMsgGo();
                UI.sendMsgBtn.SetClickCallBack(clickSendMsg1);
                UI.smileBtn.SetClickCallBack(clickSmileBtn);
                RectTransform rtf = UI.inputBg.gameObject.GetComponent<RectTransform>();
                inputField = CreateInputField(Color.black, 20, UI.inputBg);
                inputField.characterLimit = CHARACTER_LIMIT;
            }
        }

        private void InitMsgContentUI()
        {
            if (!UI.msgContentInited)
            {
                GameObject msgContentGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "msgContent"));
                msgContentGo.name = "msgContent";
                msgContentGo.transform.SetParent(UI.transform);
                msgContentGo.transform.localScale = Vector3.one;
                msgContentGo.transform.localPosition = new Vector3(183, -8, 0);
                msgContentGo.SetActive(true);
                UI.InitMsgContent();
            }
        }

        private void InitMailContentUI()
        {
            if (!UI.mailContentInited)
            {
                GameObject mailContentGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "MailContent"));
                mailContentGo.name = "MailContent";
                mailContentGo.transform.SetParent(UI.transform);
                mailContentGo.transform.localScale = Vector3.one;
                mailContentGo.transform.localPosition = new Vector3(185, 7, 0);
                mailContentGo.SetActive(true);
                UI.InitMailContent();
            }
        }

        private void InitZuiJinLianXiRenUI()
        {
            if (!UI.zuiJinLianXiInited)
            {
                GameObject zuijinlianxirenGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "ZuiJinLianXi"));
                zuijinlianxirenGo.name = "ZuiJinLianXi";
                zuijinlianxirenGo.transform.SetParent(UI.transform);
                zuijinlianxirenGo.transform.localScale = Vector3.one;
                zuijinlianxirenGo.transform.localPosition = new Vector3(-254, -13, 0);
                zuijinlianxirenGo.SetActive(true);
                UI.InitZuiJinLianXi();
                UI.zuijinTBG.SelectDefault = false;
                UI.zuijinTBG.TabChangeHandler = selectZuijinLianxi;
                UI.zuijinTBG.AllTabCloseHandler = UnselectAllZuiJinLianXiRen;
            }
        }

        private void InitLianXiRenUI()
        {
            if (!UI.lianxirenInited)
            {
                GameObject lianxirenGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "LianXiRen"));
                lianxirenGo.name = "LianXiRen";
                lianxirenGo.transform.SetParent(UI.transform);
                lianxirenGo.transform.localScale = Vector3.one;
                lianxirenGo.transform.localPosition = new Vector3(-253, -11, 0);
                lianxirenGo.SetActive(true);
                UI.InitLianXiRen();
                //UI.mainToggleTBG.TabChangeHandler = selectFriendOrBlackList;

                UI.haoyouTBG.SelectDefault = false;
                UI.haoyouTBG.TabChangeHandler = selectHaoyou;
                UI.haoyouTBG.AllTabCloseHandler = UnSelectAllHaoYou;

                UI.heimingdanTBG.SelectDefault = false;
                UI.heimingdanTBG.TabChangeHandler = selectBlack;
                UI.heimingdanTBG.AllTabCloseHandler = UnSelectAllBlack;

                UI.shuomingText.text = "请 点击左侧选择玩家进入聊天~";
                UI.mainToggleTBG.TabChangeHandler = selectMainToggle;
                UI.mainToggleTBG.AllTabCloseHandler = allMainToggleClose;
            }
        }

        private void InitMailUI()
        {
            if (!UI.mailInited)
            {
                GameObject mailGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Mail"));
                mailGo.name = "Mail";
                mailGo.transform.SetParent(UI.transform);
                mailGo.transform.localScale = Vector3.one;
                mailGo.transform.localPosition = new Vector3(-254, -11, 0);
                mailGo.SetActive(true);
                UI.InitMail();
                UI.mailTBG.SelectDefault = false;
                UI.mailTBG.TabChangeHandler = selectMail;
            }
        }

        private void InitOperationListUI()
        {
            if (!UI.operationListInited)
            {
                GameObject operationListGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "operationList"));
                operationListGo.name = "operationList";
                operationListGo.transform.SetParent(UI.transform);
                operationListGo.transform.localScale = Vector3.one;
                operationListGo.transform.localPosition = new Vector3(-104, 131, 0);
                operationListGo.SetActive(true);
                UI.InitOperationList();
                //操作列表
                UI.operateBtnList[0].SetClickCallBack(addToHaoyouList);
                UI.operateBtnList[1].SetClickCallBack(addToBlackList);
                //UI.operateBtnList[2].SetClickCallBack(chakanXinxi);
                UI.operateBtnList[3].SetClickCallBack(delFriend);
                UI.operateBtnList[4].SetClickCallBack(delFromBlackList);
                //UI.operateBtnList[5].SetClickCallBack(delFromList);

                //UI.operationListGoBgBtn.AddClickCallBack(hideOperateList);
            }
        }

        private void changeTab(int tab)
        {
            switch (tab)
            {
                case 0://最近联系人
                    bool updateZuiJinLianXiRen = !UI.zuiJinLianXiInited;
                    InitZuiJinLianXiRenUI();
                    SetChildVisible(UI.zuijinGo, true);
                    SetChildVisible(UI.lianxirenGo, false);
                    SetChildVisible(UI.mailGo, false);
                    SetChildVisible(UI.MsgContent, false);
                    SetChildVisible(UI.mailContentGo, false);
                    SetChildVisible(UI.youshangjiaoGo, false);
                    UI.shuomingText.text = "请 点击左侧选择玩家进入聊天~";
                    if (updateZuiJinLianXiRen)
                    {
                        if (mUpdateZuijinRenListCorotine != null)
                        {
                            UI.StopCoroutine(mUpdateZuijinRenListCorotine);
                            mUpdateZuijinRenListCorotine = null;
                        }
                        mUpdateZuijinRenListCorotine = UI.StartCoroutine(UpdateZuijinRenList());
                    }
                    else
                    {
                        if (UI.zuijinTBG.index != -1)
                        {
                            UI.zuijinTBG.SetIndexWithCallBack(-1);
                        }
                    }
                    break;
                case 1://联系人
                    bool updateLianxirenList = !UI.lianxirenInited;
                    InitLianXiRenUI();
                    SetChildVisible(UI.lianxirenGo, true);
                    SetChildVisible(UI.zuijinGo, false);
                    SetChildVisible(UI.mailGo, false);
                    SetChildVisible(UI.MsgContent, false);
                    SetChildVisible(UI.mailContentGo, false);
                    SetChildVisible(UI.youshangjiaoGo, false);
                    if (updateLianxirenList)
                    {
                        UpdateLianxirenList();
                    }
                    else
                    {
                        if (UI.haoyouTBG.index != -1)
                        {
                            UI.haoyouTBG.SetIndexWithCallBack(UI.haoyouTBG.index);
                        }
                        else if (UI.heimingdanTBG.index != -1)
                        {
                            UI.heimingdanTBG.SetIndexWithCallBack(UI.heimingdanTBG.index);
                        }
                    }
                    break;
                case 2://邮件
                    InitMailUI();
                    SetChildVisible(UI.mailGo, true);
                    SetChildVisible(UI.defaultmailItem, false);
                    SetChildVisible(UI.zuijinGo, false);
                    SetChildVisible(UI.lianxirenGo, false);
                    SetChildVisible(UI.MsgContent, false);
                    SetChildVisible(UI.mailContentGo, false);
                    SetChildVisible(UI.youshangjiaoGo, false);
                    UI.shuomingText.text = "请从左侧 选择要查看的邮件~";
                    MailCGHandler.sendCGMailList(1, 1);
                    break;
            }
        }

        /// <summary>
        /// 刷新最近联系人列表
        /// </summary>
	    private IEnumerator UpdateZuijinRenList()
        {
            if (zuijinRenList == null)
            {
                zuijinRenList = new List<RelationItemScript>();
            }
            SetChildVisible(UI.defaultZuijinItem.gameObject, false);
            UI.zuijinTBG.UnSelectAll();
            UI.zuijinTBG.ClearToggleList();
            //系统消息
            PlayerDataList zuijinlianxiren = chatModel.ZuijinlianxirenList;
            List<PlayerData> zuijinlianxirenList = (zuijinlianxiren != null ? zuijinlianxiren.ShallowCopyList : null);
            if (zuijinlianxirenList != null)
            {
                zuijinlianxirenList.Reverse();
            }
            int lianxirenLen = (zuijinlianxirenList != null)
                ? zuijinlianxirenList.Count
                : 0;
            for (int i = 0; i < lianxirenLen + 1; i++)
            {
                if (i >= zuijinRenList.Count)
                {
                    RelationItemUI item = GameObject.Instantiate(UI.defaultZuijinItem);
                    RelationItemScript script = new RelationItemScript(item);
                    zuijinRenList.Add(script);
                    item.transform.SetParent(UI.zuijinGrid.transform);
                    item.transform.localScale = Vector3.one;
                }
                if (i == 0)
                {
                    zuijinRenList[i].setSystemRelation();
                }
                else
                {
                    zuijinRenList[i].setLianXiRenData(zuijinlianxirenList[i - 1]);
                }
                SetChildVisible(zuijinRenList[i].UI.zhankaiBtn, false);
                SetChildVisible(zuijinRenList[i].UI.shanchuBtn, false);
                SetChildVisible(zuijinRenList[i].UI, true);
                //zuijinRenList[i].UI.toggel.isOn = false;
                //ClientLog.LogError(i + "  isOn:" + zuijinRenList[i].UI.toggel.isOn);
                UI.zuijinTBG.AddToggle(zuijinRenList[i].UI.toggel);
                if (mZuiJinLianXiSelectIdx != -1)
                {
                    if (i == mZuiJinLianXiSelectIdx)
                    {
                        UI.zuijinTBG.SetIndexWithCallBack(mZuiJinLianXiSelectIdx);
                        mZuiJinLianXiSelectIdx = -1;
                    }
                }
                zuijinRenList[i].UI.transform.SetSiblingIndex(i);

                yield return 0;
            }
            for (int i = lianxirenLen + 1; i < zuijinRenList.Count; i++)
            {
                SetChildVisible(zuijinRenList[i].UI, false);
            }
            //UI.zuijinTBG.UnSelectAll();
            UpdateZuijinLianxirenRedDot();
            UpdateHaoyouRedDot();
            mUpdateZuijinRenListCorotine = null;
        }

        /// <summary>
        /// 刷新联系人列表（好友，黑名单）
        /// </summary>
        public void UpdateLianxirenList(RMetaEvent e = null)
        {
            //UI.defaultLianxirenItem.gameObject.transform.SetAsFirstSibling();
            //0为默认的item，不使用，负责创建新的
            //UI.haoyouToggle.gameObject.transform.SetSiblingIndex(1);
            //好友列表
            //int haoyoulistStartSibling = 2;

            UpdateFriendList();

            //黑名单
            //UI.heimingdanToggle.gameObject.transform.SetSiblingIndex(2 + haoyouList.Count - 1);
            //int blacklistStartSibling = 2 + haoyouList.Count + 1;
            UpdateBlackList();

        }

        public void UpdateFriendList()
        {
            if (!UI.lianxirenInited)
            {
                return;
            }

            if (mUpdateFriendListCorotine != null)
            {
                UI.StopCoroutine(mUpdateFriendListCorotine);
                mUpdateFriendListCorotine = null;
            }
            mUpdateFriendListCorotine = UI.StartCoroutine(StartUpdateFriendList());
        }

        public void UpdateBlackList()
        {
            if (!UI.lianxirenInited)
            {
                return;
            }

            if (mUpdateBlackListCorotine != null)
            {
                UI.StopCoroutine(mUpdateBlackListCorotine);
                mUpdateBlackListCorotine = null;
            }
            mUpdateBlackListCorotine = UI.StartCoroutine(StartUpdateBlackList());
        }

        private IEnumerator StartUpdateFriendList()
        {
            SetChildVisible(UI.whiteListGrid, UI.mainToggleTBG.index == 0);
            UI.haoyouTBG.ClearToggleList();
            if (haoyouList == null)
            {
                haoyouList = new List<RelationItemScript>();
            }
            List<RelationInfo> haoyouliebiao = relationModel.HaoyouList;
            int len = haoyouliebiao != null ? haoyouliebiao.Count : 0;
            for (int i = 0; i < len; i++)
            {
                if (i >= haoyouList.Count)
                {
                    RelationItemUI item = GameObject.Instantiate(UI.defaultLianxirenItem);
                    RelationItemScript script = new RelationItemScript(item);
                    haoyouList.Add(script);
                    item.transform.SetParent(UI.whiteListGrid.transform);
                    item.transform.localScale = Vector3.one;
                }
                SetChildVisible(haoyouList[i].UI, true);
                //haoyouList[i].UI.toggel.isOn = false;
                UI.haoyouTBG.AddToggle(haoyouList[i].UI.toggel);
                //haoyouList[i].UI.transform.SetSiblingIndex(haoyoulistStartSibling + i);
                haoyouList[i].setRelationData(haoyouliebiao[i], RelationType.HAOYOU);
                SetChildVisible(haoyouList[i].UI.shanchuBtn, false);
                //SetChildVisible(haoyouList[i].UI.gameObject, UI.mainToggleTBG.index == 0 ? true : false);
                yield return 0;
            }
            UI.haoyouTBG.UnSelectAll();
            /*
            for (int i = len; i < haoyouList.Count; i++)
            {
                SetChildVisible(haoyouList[i].UI.gameObject, false);
            }
            */
            UpdateZuijinLianxirenRedDot();
            UpdateHaoyouRedDot();

            mUpdateFriendListCorotine = null;
        }
        /// <summary>
        /// 添加关系
        /// </summary>
        /// <param name="relation"></param>
        public void AddRelation(RMetaEvent e)
        {
            if (!UI.lianxirenInited)
            {
                return;
            }
            GCAddRelation relation = e.data as GCAddRelation;
            if (relation.getRelationType() == RelationType.HAOYOU)
            {
                //添加好友
                RelationItemUI item = GameObject.Instantiate(UI.defaultLianxirenItem);
                RelationItemScript script = new RelationItemScript(item);
                haoyouList.Add(script);
                item.transform.SetParent(UI.whiteListGrid.transform);
                item.transform.localScale = Vector3.one;

                SetChildVisible(script.UI, true);
                //haoyouList[i].UI.toggel.isOn = false;
                UI.haoyouTBG.AddToggle(script.UI.toggel);
                //haoyouList[i].UI.transform.SetSiblingIndex(haoyoulistStartSibling + i);
                script.setRelationData(relation.getRelationInfoData(), RelationType.HAOYOU);
                SetChildVisible(script.UI.shanchuBtn, false);
            }
            else if (relation.getRelationType() == RelationType.HEIMINGDAN)
            {
                //添加黑名单
                RelationItemUI item = GameObject.Instantiate(UI.defaultLianxirenItem);
                RelationItemScript script = new RelationItemScript(item);
                blackList.Add(script);
                item.transform.SetParent(UI.blackListGrid.transform);
                item.transform.localScale = Vector3.one;
                SetChildVisible(script.UI, true);
                //blackList[i].UI.transform.SetAsLastSibling();
                //blackList[i].UI.transform.SetSiblingIndex(blacklistStartSibling + i);
                UI.heimingdanTBG.AddToggle(script.UI.toggel);
                script.setRelationData(relation.getRelationInfoData(), RelationType.HEIMINGDAN);
            }
        }

        /// <summary>
        /// 删除关系
        /// </summary>
        /// <param name="relation"></param>
        public void DelRelation(RMetaEvent e)
        {
            if (!UI.lianxirenInited)
            {
                return;
            }

            GCDelRelation relation = e.data as GCDelRelation;
            if (relation.getRelationType() == RelationType.HAOYOU)
            {
                //删除好友
                for (int i = 0; i < haoyouList.Count; i++)
                {
                    if (haoyouList[i].data.uuid.Equals(relation.getTargetCharId()))
                    {
                        UI.haoyouTBG.RemoveToggle(haoyouList[i].UI.toggel);
                        haoyouList[i].UI.gameObject.SetActive(false);
                        haoyouList[i].Destroy();
                        haoyouList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (relation.getRelationType() == RelationType.HEIMINGDAN)
            {
                //删除黑名单
                for (int i = 0; i < blackList.Count; i++)
                {
                    if (blackList[i].data.uuid.Equals(relation.getTargetCharId()))
                    {
                        UI.heimingdanTBG.RemoveToggle(blackList[i].UI.toggel);
                        blackList[i].UI.gameObject.SetActive(false);
                        blackList[i].Destroy();
                        blackList.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private IEnumerator StartUpdateBlackList()
        {
            SetChildVisible(UI.blackListGrid, UI.mainToggleTBG.index == 1);
            UI.heimingdanTBG.ClearToggleList();
            if (blackList == null)
            {
                blackList = new List<RelationItemScript>();
            }
            List<RelationInfo> blackliebiao = relationModel.BlackList;
            for (int i = 0; blackliebiao != null && i < blackliebiao.Count; i++)
            {
                if (i >= blackList.Count)
                {
                    RelationItemUI item = GameObject.Instantiate(UI.defaultLianxirenItem);
                    RelationItemScript script = new RelationItemScript(item);
                    blackList.Add(script);
                    item.transform.SetParent(UI.blackListGrid.transform);
                    item.transform.localScale = Vector3.one;
                }
                SetChildVisible(blackList[i].UI, true);
                //blackList[i].UI.transform.SetAsLastSibling();
                //blackList[i].UI.transform.SetSiblingIndex(blacklistStartSibling + i);
                UI.heimingdanTBG.AddToggle(blackList[i].UI.toggel);
                blackList[i].setRelationData(blackliebiao[i], RelationType.HEIMINGDAN);
                //SetChildVisible(blackList[i].UI.gameObject, UI.mainToggleTBG.index == 1 ? true : false);
                yield return 0;
            }
            UI.heimingdanTBG.UnSelectAll();
            /*
            if (blackliebiao != null)
            {
                for (int i = blackliebiao.Count; i < blackList.Count; i++)
                {
                    SetChildVisible(blackList[i].UI.gameObject, false);
                }
            }
            */
            mUpdateBlackListCorotine = null;
        }

        /// <summary>
        /// 更新邮件列表
        /// </summary>
        /// <param name="e"></param>
	    public void updateMailList(RMetaEvent e = null)
        {
            if (!UI.mailInited)
            {
                return;
            }

            if (mUpdateMailListCorotine != null)
            {
                UI.StopCoroutine(mUpdateMailListCorotine);
                mUpdateMailListCorotine = null;
            }
            mUpdateMailListCorotine = UI.StartCoroutine(StartUpdateMailList());
        }

        private IEnumerator StartUpdateMailList()
        {
            if (mailList == null)
            {
                mailList = new List<RelationItemScript>();
            }
            UI.mailTBG.ClearToggleList();
            List<MailInfoData> maillist = mailModel.MailList;
            for (int i = 0; maillist != null && i < maillist.Count; i++)
            {
                if (i >= mailList.Count)
                {
                    RelationItemUI item = GameObject.Instantiate(UI.defaultmailItem);
                    RelationItemScript script = new RelationItemScript(item);
                    mailList.Add(script);
                    item.transform.SetParent(UI.mailGrid.transform);
                    item.transform.localScale = Vector3.one;
                }
                mailList[i].UI.toggel.isOn = false;
                UI.mailTBG.AddToggle(mailList[i].UI.toggel);
                mailList[i].setMailData(maillist[i]);
                SetChildVisible(mailList[i].UI, true);
                yield return 0;
            }
            UI.mailTBG.UnSelectAll();
            if (maillist != null)
            {
                for (int i = maillist.Count; i < mailList.Count; i++)
                {
                    SetChildVisible(mailList[i].UI, false);
                }
            }
        }

        public void updateMsgContent(RMetaEvent e)
        {
            if (UI == null||!isShown) return;

            switch (UI.lefttopBtn.index)
            {
                case 0:
                    //最近联系人
                    if (UI.zuijinTBG.index >= 0 && UI.zuijinTBG.index < zuijinRenList.Count)
                    {
                        selectZuijinLianxi(UI.zuijinTBG.index);
                    }
                    else
                    {
                        UpdateZuijinLianxirenRedDot();
                        UpdateHaoyouRedDot();
                    }
                    break;
                case 1:
                    //联系人(好友、黑名单)
                    if (UI.mainToggleTBG.index == 0)
                    {
                        if (UI.haoyouTBG.index >= 0 && UI.haoyouTBG.index < haoyouList.Count)
                        {
                            //好友
                            showSiLiaoMsg(haoyouList[UI.haoyouTBG.index].data.uuid);
                        }
                        else
                        {
                            UpdateZuijinLianxirenRedDot();
                            UpdateHaoyouRedDot();
                        }
                    }
                    else if (UI.mainToggleTBG.index == 1)
                    {
                        //黑名单
                        UpdateZuijinLianxirenRedDot();
                        UpdateHaoyouRedDot();
                    }
                    break;
            }
        }

        public void SelectZuiJinLianXiRen(int idx)
        {
            //if (UI.lefttopBtn.index != 0)
            {
                UI.lefttopBtn.SetIndexWithCallBack(0);
            }

            //if (UI.zuijinTBG.index != idx)
            {
                UI.zuijinTBG.SetIndexWithCallBack(idx);
            }
        }

        private void AddNewZuiJinLianXiRen(RMetaEvent e)
        {
            PlayerData playerData = (PlayerData)e.data;
            RelationItemUI item = GameObject.Instantiate(UI.defaultZuijinItem);
            RelationItemScript script = new RelationItemScript(item);
            zuijinRenList.Insert(1, script);
            item.transform.SetParent(UI.zuijinGrid.transform);
            item.transform.localScale = Vector3.one;
            script.setLianXiRenData(playerData);
            SetChildVisible(script.UI.zhankaiBtn, false);
            SetChildVisible(script.UI.shanchuBtn, false);
            SetChildVisible(script.UI, true);
            UI.zuijinTBG.InsertToggle(script.UI.toggel, 1);

            int len = zuijinRenList.Count;
            for (int i = 0; i < len; i++)
            {
                zuijinRenList[i].UI.transform.SetSiblingIndex(i);
            }

            UpdateZuijinLianxirenRedDot();
            UpdateHaoyouRedDot();
        }

        private void DelZuiJinLianXiRen(RMetaEvent e)
        {
            string uuid = (string)e.data;
            int len = zuijinRenList.Count;
            for (int i = 1; i < len; i++)
            {
                if (zuijinRenList[i].playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID) == uuid)
                {
                    UI.zuijinTBG.RemoveToggle(zuijinRenList[i].UI.toggel);
                    zuijinRenList[i].Destroy();
                    zuijinRenList.RemoveAt(i);
                    break;
                }
            }
        }

        private void UpdateZuiJinLianXiRenData(RMetaEvent e)
        {
            PlayerData playerData = (PlayerData)e.data;
            int len = zuijinRenList.Count;
            for (int i = 1; i < len; i++)
            {
                if (zuijinRenList[i].playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID) == playerData.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID))
                {
                    zuijinRenList[i].setLianXiRenData(playerData);
                    SetChildVisible(zuijinRenList[i].UI.zhankaiBtn, false);
                    SetChildVisible(zuijinRenList[i].UI.shanchuBtn, false);
                    zuijinRenList[i].UI.transform.SetSiblingIndex(1);
                    if (UI.zuijinTBG.index == i)
                    {
                        UI.zuijinTBG.SetIndexWithCallBack(i);
                    }
                    break;
                }
            }
        }

        private void OnFuncInfoChanged(RMetaEvent e)
        {
            UpdateMailRedDot();
        }

        public override void Destroy()
        {
            relationModel.removeChangeEvent(RelationModel.REFRESH_Relation_LIST, UpdateLianxirenList);
            relationModel.removeChangeEvent(RelationModel.ADD_Relation_Success, AddRelation);
            relationModel.removeChangeEvent(RelationModel.DEL_Relation_Success, DelRelation);
            mailModel.removeChangeEvent(MailModel.UPDATE_MAIL_INFO, updateCurrentMail);
            mailModel.removeChangeEvent(MailModel.REFRESH_LIST, updateMailList);
            chatModel.removeChangeEvent(ChatModel.APPEND_ONE_MSG, updateMsgContent);
            chatModel.removeChangeEvent(ChatModel.ADD_ZUIJINLIANXIREN, AddNewZuiJinLianXiRen);
            chatModel.removeChangeEvent(ChatModel.DEL_ZUIJINLIANXIREN, DelZuiJinLianXiRen);
            chatModel.removeChangeEvent(ChatModel.UPDATE_ZUIJINLIANXIREN, UpdateZuiJinLianXiRenData);
            functionModel.removeChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.removeChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);
            InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, hideOperateList);

            if (chatMsgList != null)
            {
                int len = chatMsgList.Count;
                for (int i = 0; i < len; i++)
                {
                    chatMsgList[i].Destroy();
                }
                chatMsgList.Clear();
                chatMsgList = null;
            }

            if (zuijinRenList != null)
            {
                int len = zuijinRenList.Count;
                for (int i = 0; i < len; i++)
                {
                    zuijinRenList[i].Destroy();
                }
                zuijinRenList.Clear();
                zuijinRenList = null;
            }

            if (haoyouList != null)
            {
                int len = haoyouList.Count;
                for (int i = 0; i < len; i++)
                {
                    haoyouList[i].Destroy();
                }
                haoyouList.Clear();
                haoyouList = null;
            }

            if (blackList != null)
            {
                int len = blackList.Count;
                for (int i = 0; i < len; i++)
                {
                    blackList[i].Destroy();
                }
                blackList.Clear();
                blackList = null;
            }

            if (mailList != null)
            {
                int len = mailList.Count;
                for (int i = 0; i < len; i++)
                {
                    mailList[i].Destroy();
                }
                mailList.Clear();
                mailList = null;
            }

            base.Destroy();
            UI = null;
        }
    }
}