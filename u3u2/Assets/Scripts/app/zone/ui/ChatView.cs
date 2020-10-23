using System.Collections.Generic;
using app.db;
using app.human;
using app.main;
using app.net;
using app.role;
using app.story;
using app.team;
using app.relation;
using app.chat;
using app.config;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace app.zone
{
    public class ChatView : BaseUI
    {
        public const int CHARACTER_LIMIT = 50;

        public ChatPanelUI UI;

        private float showPositionX = 0;
        private float hidePositionX = 0;
        /// <summary>
        /// 除 系统频道外的频道
        /// </summary>
        private List<RelationChatItemScript> chatMsgList;
        /// <summary>
        /// 系统频道
        /// </summary>
        private List<RelationChatItemScript> sysMsgList;

        /// <summary>
        /// 闲置的对象
        /// </summary>
        private List<RelationChatItemScript> unusedMsgList=new List<RelationChatItemScript>();

        /// <summary>
        /// 闲置的对象
        /// </summary>
        private List<RelationChatItemScript> unusedSysMsgList = new List<RelationChatItemScript>();

        private int chatMsgLen;
        private int sysMsgLen;

        private InputField inputField;

        private RMetaEventHandler addListenerCallBack;

        private RMetaEventHandler mStartLuyin = null;
        //private RMetaEventHandler mStopLuyin = null;
        //private RMetaEventHandler mCancelLuyin = null;

        private ChatModel chatModel = null;

        /// <summary>
        /// 聊天中展示的信息
        /// </summary>
        private ChatContentBase chatExhibition;
        /// <summary>
        /// 聊天的文本内容
        /// </summary>
        private string chatText;

        public bool isShowing { get; private set; }

        public ChatView(ChatPanelUI ui, RMetaEventHandler addListenerCallBackv, RMetaEventHandler startLuyin)
        {
            this.ui = ui.gameObject;
            this.ignorePositionShow = true;
            UI = ui;
            base.ui = ui.gameObject;
            addListenerCallBack = addListenerCallBackv;
            mStartLuyin = startLuyin;
            //mStopLuyin = stopLuyin;
            //mCancelLuyin = cancelLuyin;

            chatModel = ChatModel.Ins;
            chatModel.addChangeEvent(ChatModel.APPEND_ONE_MSG, updateMsgContent);

            Initwnd();

            InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, UI.luyingBtn.gameObject, mStartLuyin);
            
            Vector3 pos = base.ui.transform.localPosition;
            showPositionX = pos.x;
            hidePositionX = showPositionX - 535;
            pos.x = hidePositionX;
            base.ui.transform.localPosition = pos;
            isShowing = false;
        }

        private void Initwnd()
        {
            UI.fasongBtn.SetClickCallBack(clickFaSong);
            UI.biaoqingBtn.SetClickCallBack(clickBiaoqing);
            UI.CloseBtn.SetClickCallBack(hidePanel);
            UI.channelTBG.SelectDefault = false;
            UI.channelTBG.TabChangeHandler = changeTab;
            
            UI.defaultSysMsgItemUI.gameObject.SetActive(false);
            UI.defaultMsgItemUI.gameObject.SetActive(false);

            inputField = CreateInputField(Color.black, 20, UI.inputBg);
            inputField.characterLimit = CHARACTER_LIMIT;
            //inputField.onEndEdit.AddListener(doSubmit);
        }
        
        public void hidePanel()
        {
            if (UI != null)
            {
                if(UI.transform!=null) UI.transform.DOKill();
                RectTransform rtf = UI.GetComponent<RectTransform>();
                if (rtf != null)
                {
                    isShowing = false;
                    TweenUtil.MoveTo(UI.transform, new Vector3(hidePositionX, rtf.localPosition.y, 0), 0.3f, null, hideEnd);
                }
            }
            if (ZoneUI.ins.UI != null && ZoneUI.ins.UI.chatUI != null) ZoneUI.ins.UI.chatUI.gameObject.SetActive(true);
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
            clickFaSong(2);
        }

        public void ExhibitionPet(string chatpet)
        {
            inputField.text += chatpet;
            clickFaSong(2);
        }

        private void clickBiaoqing()
        {
            chatModel.OpenBiaoqing();
        }

        private void clickFaSong1()
        {
            clickFaSong(0);
        }

        private void clickFaSong()
        {
            clickFaSong(0);
        }
        private void clickFaSong(int chattype=0)
        {
            string str = inputField.text;
            if (string.IsNullOrEmpty(str))
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请输入内容！");
                return;
            }
            int chatChannel = getCurrentChannel();
            if (canFaYan(chatChannel))
            {
                if (chatChannel == ChatScopeType.CHAT_SCOPE_CORPS)
                {
                    if (Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.HAS_CORPS) == 0)
                    {
                        inputField.text = "";
                        ZoneBubbleManager.ins.BubbleSysMsg("未加入帮派,不能发言");
                        return;
                    }
                }
                if (chatChannel == ChatScopeType.CHAT_SCOPE_TEAM)
                {
                    if (!TeamModel.ins.hasTeam())
                    {
                        inputField.text = "";
                        ZoneBubbleManager.ins.BubbleSysMsg("未加入队伍,不能发言");
                        return;
                    }
                }
                if (inputField.text.Contains("!guide "))
                {
                    string strtext = inputField.text;
                    string[] arr = strtext.Split(' ');
                    int groupid = 0;
                    int.TryParse(arr[1], out groupid);
                    if (groupid != 0)
                    {
                        GuideManager.Ins.StartGuide((GuideIdDef)groupid,true);
                    }
                    return;
                }
                if (inputField.text == "!debug")
                {
                    if (ClientConfig.Ins.debug)
                    {
                        inputField.text = "";
                        LogPanel.Ins.preLoadUI();
                    }
                    if (GameObject.Find("ScriptsRoot").GetComponent<GameInfoDisplay>() == null)
                    {
                        GameObject.Find("ScriptsRoot").AddComponent<GameInfoDisplay>();
                    }
                    return;
                }
                if (inputField.text.Contains("!storybattle"))
                {
                    string strtext = inputField.text;
                    string[] arr = strtext.Split(' ');
                    int groupid=0;
                    int.TryParse(arr[1],out groupid);
                    if (groupid!=0)
                    {
                        StoryManager.ins.EnterStory(groupid,true);
                    }
                    return;
                }
                if (inputField.text.Contains("!storyvideo"))
                {
                    string strtext = inputField.text;
                    string[] arr = strtext.Split(' ');
                    int videoId = 0;
                    int.TryParse(arr[1], out videoId);
                    if (videoId != 0)
                    {
                        StoryManager.ins.EnterStory(videoId,false);
                    }
                    return;
                }
                
                if (inputField.text == "!profiler")
                {
                    inputField.text = "";
                    ProfilerPanel.Ins.preLoadUI();
                    if (GameObject.Find("ScriptsRoot").GetComponent<GameInfoDisplay>() == null)
                    {
                        GameObject.Find("ScriptsRoot").AddComponent<GameInfoDisplay>();
                    }
                    return;
                }
                if (inputField.text == "!getallpet")
                {
                    inputField.text = "";
                    foreach (KeyValuePair<int, PetTemplate> pair in PetTemplateDB.Instance.getIdKeyDic())
                    {
                        ChatCGHandler.sendCGChatMsg(chatChannel, "", "", "!givepet " + pair.Value.Id + " 1", 0);
                    }
                    return;
                }
                ChatCGHandler.sendCGChatMsg(chatChannel, "", "", inputField.text, chattype);
                inputField.text = "";
            }
        }

        private void showEnd()
        {
            if (ZoneUI.ins.UI != null && ZoneUI.ins.UI.chatUI!=null) ZoneUI.ins.UI.chatUI.gameObject.SetActive(false);
            UI.transform.DOKill();
            //UI.gameObject.SetActive(true);
            if (UI.channelTBG.index == -1)
            {
                UI.channelTBG.SetIndexWithCallBack(1);
            }
            else
            {
                UI.channelTBG.SetIndexWithCallBack(UI.channelTBG.index);
            }
        }

        private void hideEnd()
        {
            UI.transform.DOKill();
            UI.gameObject.SetActive(false);
            if (addListenerCallBack != null)
            {
                addListenerCallBack(null);
            }
        }

        public void showPanel(bool newcreate=false)
        {
            //if (newcreate)
            //{
            //    if (UI.channelTBG.index == -1)
            //    {
            //        UI.channelTBG.SetIndexWithCallBack(1);
            //    }
            //    else
            //    {
            //        UI.channelTBG.SetIndexWithCallBack(UI.channelTBG.index);
            //    }
            //}
            UI.transform.DOKill();
            UI.gameObject.SetActive(true);
            //if (!UI.gameObject.activeSelf)
            //{
            //    UI.gameObject.SetActive(true);
            //}
            isShowing = true;
            RectTransform rtf = UI.GetComponent<RectTransform>();
            if (rtf != null)
            {
                //UI.transform.localPosition = new Vector3(hidePositionX, rtf.localPosition.y, 0);
                //rtf.anchoredPosition = new Vector3(showPositionX, rtf.localPosition.y, 0);
                if (rtf.localPosition.x != showPositionX)
                {
                    TweenUtil.MoveTo(UI.transform, new Vector3(showPositionX, rtf.localPosition.y, 0), 0.3f,null,showEnd);
                }
            }
        }

        private int getCurrentChannel()
        {
            int chatChannel = -1;
            switch (UI.channelTBG.index)
            {
                case 0:
                    //系统
                    chatChannel = -1;
                    break;
                case 1:
                    chatChannel = ChatScopeType.CHAT_SCOPE_WORLD;
                    break;
                case 2:
                    chatChannel = ChatScopeType.CHAT_SCOPE_COUNTRY;
                    break;
                case 3:
                    chatChannel = ChatScopeType.CHAT_SCOPE_CORPS;
                    break;
                case 4:
                    chatChannel = ChatScopeType.CHAT_SCOPE_TEAM;
                    break;
                case 5:
                    chatChannel = ChatScopeType.CHAT_SCOPE_COMMON_TEAM;
                    break;
                default:
                    break;
            }
            return chatChannel;
        }

        private void changeTab(int index)
        {
            int chatChannel = getCurrentChannel();
            if (chatChannel != -1)
            {
                setChatContent(chatChannel);
                chatModel.CurrentRecordingChannel = chatChannel;
            }
            else
            {
                showSysnotice();
            }
            UI.fayanGo.SetActive(canFaYan(chatChannel));
            UI.notFayanGo.SetActive(!canFaYan(chatChannel));
            if (!canFaYan(chatChannel))
            {
                if (chatChannel == -1)
                {
                    UI.notFaYanText.text = " 此频道不能发言,请到其他频道发言！";
                }
                else if (chatChannel == ChatScopeType.CHAT_SCOPE_COMMON_TEAM)
                {
                    UI.notFaYanText.text = "请在队伍界面中使用一键喊话";
                }
            }
        }

        private bool canFaYan(int chatChannel)
        {
            return chatChannel != -1 && chatChannel != ChatScopeType.CHAT_SCOPE_COMMON_TEAM;
        }

        private void showSysnotice()
        {
            for (int i = 0; chatMsgList != null && i < chatMsgList.Count; i++)
            {
                chatMsgList[i].UI.gameObject.SetActive(false);
            }
            if (sysMsgList == null)
            {
                sysMsgList = new List<RelationChatItemScript>();
            }

            List<SysMsgInfoData> sysNoticeList = chatModel.SysMessageList;
            //系统消息
            for (int i = 0; sysNoticeList != null && i < sysNoticeList.Count; i++)
            {
                if (i >= sysMsgList.Count)
                {
                    RelationChatItemScript script;
                    if (unusedMsgList.Count > 0)
                    {
                        script = unusedMsgList[0];
                        if (unusedSysMsgList.Count>0)
                        {
                            unusedSysMsgList.RemoveAt(0);
                        }
                    }
                    else
                    {
                        ChatMsgItemUI item = GameObject.Instantiate(UI.defaultSysMsgItemUI);
                        item.gameObject.SetActive(true);
                        script = new RelationChatItemScript(item);

                        script.UI.transform.SetParent(UI.chatGrid.transform);
                        script.UI.transform.localScale = Vector3.one;
                    }

                    sysMsgList.Add(script);
                }
                sysMsgList[i].UI.gameObject.transform.SetAsFirstSibling();
                sysMsgList[i].UI.gameObject.SetActive(true);
                sysMsgList[i].setSysMessageInfo(sysNoticeList[i]);
            }
            sysMsgLen = sysNoticeList!=null?sysNoticeList.Count:0;
            for (int i = sysMsgLen; i < sysMsgList.Count; i++)
            {
                sysMsgList[i].UI.gameObject.SetActive(false);

                sysMsgList[i].clear();
                unusedSysMsgList.Add(sysMsgList[i]);
            }
            sysMsgList.RemoveRange(sysMsgLen, sysMsgList.Count - sysMsgLen);
        }

        private void setChatContent(int chatChannel)
        {
            for (int i = 0; sysMsgList != null && i < sysMsgList.Count; i++)
            {
                sysMsgList[i].UI.gameObject.SetActive(false);
            }
            if (chatMsgList == null)
            {
                chatMsgList = new List<RelationChatItemScript>();
            }

            List<ChatMsgData> siliaoMsgList = chatModel.getChatList(chatChannel);
            //频道消息
            for (int i = 0; siliaoMsgList != null && i < siliaoMsgList.Count; i++)
            {
                if (i >= chatMsgList.Count)
                {
                    RelationChatItemScript script;
                    if (unusedMsgList.Count > 0)
                    {
                        script = unusedMsgList[0];
                        unusedMsgList.RemoveAt(0);
                    }
                    else
                    {
                        ChatMsgItemUI item = GameObject.Instantiate(UI.defaultMsgItemUI);
                        item.gameObject.SetActive(true);
                        script = new RelationChatItemScript(item);

                        script.UI.transform.SetParent(UI.chatGrid.transform);
                        script.UI.transform.localScale = Vector3.one;
                    }
                    chatMsgList.Add(script);
                }
                chatMsgList[i].UI.gameObject.transform.SetAsFirstSibling();
                chatMsgList[i].UI.gameObject.SetActive(true);
                chatMsgList[i].setChannelMsgInfo(siliaoMsgList[i]);
            }
            chatMsgLen = siliaoMsgList != null ? siliaoMsgList.Count : 0;
            for (int i = chatMsgLen; i < chatMsgList.Count; i++)
            {
                chatMsgList[i].UI.gameObject.SetActive(false);

                chatMsgList[i].clear();
                unusedMsgList.Add(chatMsgList[i]);
            }
            chatMsgList.RemoveRange(chatMsgLen, chatMsgList.Count - chatMsgLen);
        }

        public void updateMsgContent(RMetaEvent e)
        {
            //if (!isShowing)
            //{
            //    return;
            //}
            AddOneMsg(e);
            //if (UI.channelTBG.index < 0)
            //{
            //    UI.channelTBG.SetIndexWithCallBack(1);
            //}
            //else
            //{
            //    UI.channelTBG.SetIndexWithCallBack(UI.channelTBG.index);
            //}
        }

        private void AddOneMsg(RMetaEvent e)
        {
            if (chatMsgList == null)
            {
                chatMsgList = new List<RelationChatItemScript>();
            }
            
            int chatChannel = getCurrentChannel();
            if (chatChannel == -1)
            {
                //系统信息
                if (e.data is NoticeTipsInfoData)
                {
                    
                }
                else if (e.data is SysMsgInfoData)
                {
                    RelationChatItemScript script;
                    if (unusedSysMsgList.Count > 0)
                    {
                        script = unusedSysMsgList[0];
                        unusedSysMsgList.RemoveAt(0);
                    }
                    else
                    {
                        ChatMsgItemUI item = GameObject.Instantiate(UI.defaultSysMsgItemUI);
                        item.gameObject.SetActive(true);
                        script = new RelationChatItemScript(item);
                        script.UI.transform.SetParent(UI.chatGrid.transform);
                        script.UI.transform.localScale = Vector3.one;
                    }

                    sysMsgList.Add(script);
                    
                    script.UI.gameObject.transform.SetAsFirstSibling();
                    script.UI.gameObject.SetActive(true);
                    script.setSysMessageInfo(e.data as SysMsgInfoData);

                    sysMsgLen++;
                    if (sysMsgList.Count > ChatModel.MAX_LEN_PERSCOPE)
                    {//超出最大消息条数，优先移除老的消息
                        sysMsgList[0].clear();
                        unusedSysMsgList.Add(sysMsgList[0]);
                        sysMsgList.RemoveAt(0);
                        sysMsgLen--;
                    }
                }
            }
            else
            {
                if (e.data is ChatMsgData && (e.data as ChatMsgData).getScope() == chatChannel)
                {
                    RelationChatItemScript script;
                    if (unusedMsgList.Count > 0)
                    {
                        script = unusedMsgList[0];
                        unusedMsgList.RemoveAt(0);
                    }
                    else
                    {
                        ChatMsgItemUI item = GameObject.Instantiate(UI.defaultMsgItemUI);
                        item.gameObject.SetActive(true);
                        script = new RelationChatItemScript(item);

                        script.UI.transform.SetParent(UI.chatGrid.transform);
                        script.UI.transform.localScale = Vector3.one;
                    }

                    chatMsgList.Add(script);
                    
                    script.UI.gameObject.transform.SetAsFirstSibling();
                    script.UI.gameObject.SetActive(true);
                    script.setChannelMsgInfo(e.data as ChatMsgData);
                    chatMsgLen++;
                    if (chatMsgList.Count > ChatModel.MAX_LEN_PERSCOPE)
                    {//超出最大消息条数，优先移除老的消息
                        chatMsgList[0].clear();
                        unusedMsgList.Add(chatMsgList[0]);

                        chatMsgList.RemoveAt(0);
                        chatMsgLen--;
                    }
                }
            }
            
        }


        public override void Destroy()
        {
            InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, UI.luyingBtn.gameObject, mStartLuyin);
            
            chatModel.removeChangeEvent(ChatModel.APPEND_ONE_MSG, updateMsgContent);
            for (int i = 0; chatMsgList!=null&&i < chatMsgList.Count; i++)
            {
                chatMsgList[i].Destroy();
            }
            if (chatMsgList!=null)chatMsgList.Clear();

            for (int i = 0; sysMsgList != null && i < sysMsgList.Count; i++)
            {
                sysMsgList[i].Destroy();
            }
            if (sysMsgList != null) sysMsgList.Clear();

            for (int i = 0; unusedMsgList != null && i < unusedMsgList.Count; i++)
            {
                unusedMsgList[i].Destroy();
            }
            if (unusedMsgList != null) unusedMsgList.Clear();

            for (int i = 0; unusedSysMsgList != null && i < unusedSysMsgList.Count; i++)
            {
                unusedSysMsgList[i].Destroy();
            }
            if (unusedSysMsgList != null) unusedSysMsgList.Clear();

            base.Destroy();
            UI = null;
        }
    }
}
