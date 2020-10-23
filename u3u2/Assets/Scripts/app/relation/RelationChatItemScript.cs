using System;
using app.human;
using app.net;
using app.chat;
using app.utils;
using UnityEngine;

namespace app.relation
{
    /// <summary>
    /// 好友聊天的 单条消息
    /// </summary>
    public class RelationChatItemScript
    {
        public ChatMsgItemUI UI;
        private SysNoticeInfoData noticeInfo;
        private ChatMsgData chatMsg;
        private SysMsgInfoData sysmsgInfo;
        private RTimer playSoundTimer;

        public RelationChatItemScript(ChatMsgItemUI ui)
        {
            UI = ui;
            if (UI.duifangYuyinBtn != null) UI.duifangYuyinBtn.SetClickCallBack(playduifangYuYin);
            if (UI.selfYuyinBtn != null) UI.selfYuyinBtn.SetClickCallBack(playselfYuYin);
            if (UI.headItem != null) UI.headItem.ClickCommonItemHandler = clickheadItem;

            if (UI.duifangContent != null)
            {
                UI.duifangText = UGUIRichTextOptimized.Create(UI.duifangContent.transform, "duifangRichText");
            }
            if (UI.selfContent != null)
            {
                UI.selfText = UGUIRichTextOptimized.Create(UI.selfContent.transform, "selfRichtext"); 
            }
        }

        private void clickheadItem()
        {
            if (chatMsg != null && chatMsg.getFromRoleUUID()!=null)
            {
                long roleuuid=0;
                long.TryParse(chatMsg.getFromRoleUUID(), out roleuuid);
                if (roleuuid!=0)
                {
                    PopRoleInfoWnd.Ins.ShowInfo(roleuuid);
                }
            }
        }

        private void playduifangYuYin()
        {
            if (chatMsg != null)
            {
                ChatModel.Ins.PlayVoice(chatMsg);
            }
            //EventCore.dispatchRMetaEvent(new RMetaEvent(GameClient.StartCoroutineEvent, null, null,
            //    a =>
            //    {
            //        PlatForm.Instance.PlayChat(getYuYinUrl(chatMsg));
            //        ClientLog.LogWarning("开始播放" + getYuYinUrl(chatMsg));
            //    }));
        }
        /*
        private void startPlayChat()
        {
            string timestr = getYuYinTime(chatMsg);
            float timeint = 0f;
            float.TryParse(timestr, out timeint);
            if (timeint > 0)
            {
                if (playSoundTimer != null)
                {
                    playSoundTimer.stop();
                }
                playSoundTimer = TimerManager.Ins.createTimer(100, (int)(timeint * 1000), null, onTimerEnd);
                playSoundTimer.start();
                AudioManager.Ins.SetAllMuteTmp(true);
            }
        }

        private void onTimerEnd(RTimer r)
        {
            AudioManager.Ins.SetAllMuteTmp(false);
        }
        */
        private void playselfYuYin()
        {
            if (chatMsg != null)
            {
                ChatModel.Ins.PlayVoice(chatMsg);
            }
            //EventCore.dispatchRMetaEvent(new RMetaEvent(GameClient.StartCoroutineEvent, null, null,
            //    a =>
            //    {
            //        PlatForm.Instance.PlayChat(getYuYinUrl(chatMsg));
            //        ClientLog.LogWarning("开始播放" + getYuYinUrl(chatMsg));
            //    }));
        }

        private void setASToMeMsg()
        {
            if (UI.selfMsgGo!=null) UI.selfMsgGo.gameObject.SetActive(false);
            if (UI.duifangMsgGo != null) UI.duifangMsgGo.gameObject.SetActive(true);

            UI.UIVerticalLayout.childAlignment = TextAnchor.UpperLeft;
            UI.contentVerticalLayout.childAlignment = TextAnchor.UpperRight;
            UI.contentVerticalLayout.padding.left = 75;

            if (chatMsg != null)
            {
                if (chatMsg.getChatType() == 1)
                {
                    ChatModel.Ins.setChatText(UI.duifangText, getYuYinText(chatMsg), 20, 0, new Color(119 / 255f, 79 / 255f, 49 / 255f));
                    if (UI.duifangYuyinTimeText != null) UI.duifangYuyinTimeText.text = ChatModel.Ins.GetVoiceTime(chatMsg) + "秒";
                    if (UI.duifangYuyinBtn != null) UI.duifangYuyinBtn.SetClickCallBack(playduifangYuYin);
                    if (UI.duifangYuyinGo != null) UI.duifangYuyinGo.SetActive(true);
                }
                else
                {
                    if (UI.duifangText != null)
                    {
                        ChatModel.Ins.setChatText(UI.duifangText, chatMsg.getContent(), 20, 0, new Color(119 / 255f, 79 / 255f, 49 / 255f));
                        //UI.duifangContent.text = chatMsg.getContent();
                    }
                    if (UI.duifangYuyinBtn != null) UI.duifangYuyinBtn.ClearClickCallBack();
                }

                if (UI.duifangYuyinGo != null) UI.duifangYuyinGo.SetActive(chatMsg.getChatType() == 1);
            }
        }
        /*
        public static string getYuYinUrl(ChatMsgData chatMsgv)
        {
            if (chatMsgv==null) return"";
            string str = chatMsgv.getContent();
            string[] messageArr = str.Split(new char[] { '|' });
            string url = messageArr[0];
            return url;
        }

        public static string getYuYinTime(ChatMsgData chatMsgv)
        {
            if (chatMsgv == null) return "";
            string str = chatMsgv.getContent();
            string[] messageArr = str.Split(new char[] { '|' });
            string timelen = "0";
            if (messageArr.Length > 2)
            {
                timelen = messageArr[2];
            }
            return timelen;
        }
        */
        public static string getContentText(ChatMsgData chatMsgv)
        {
            if (chatMsgv.getChatType() == 1)
            {
                return getYuYinText(chatMsgv);
            }
            else
            {
                return chatMsgv.getContent();
            }
        }

        public static string getYuYinText(ChatMsgData chatMsgv)
        {
            string str = chatMsgv.getContent();
            string[] messageArr = str.Split(new char[] { '|' });
            int indexofSplit = str.IndexOf('|');
            if (!string.IsNullOrEmpty(str) && messageArr.Length > 0)
            {
                string url = messageArr[0];
                if (url.IndexOf("http://") == 0 && url.EndsWith(".spx") && messageArr.Length >= 2)
                {
                    return messageArr[1]; //str.Substring(indexofSplit + 1, str.Length - indexofSplit - 1);
                }
            }
            return str;
        }

        private void setASFromMeMsg()
        {
            if (UI.selfMsgGo != null) UI.selfMsgGo.gameObject.SetActive(true);
            if (UI.duifangMsgGo != null) UI.duifangMsgGo.gameObject.SetActive(false);

            UI.UIVerticalLayout.childAlignment = TextAnchor.UpperRight;
            UI.contentVerticalLayout.childAlignment = TextAnchor.UpperLeft;
            UI.contentVerticalLayout.padding.left = 5;
            if (chatMsg != null)
            {
                if (chatMsg.getChatType() == 1)
                {
                    if (UI.selfText != null)
                    {
                        ChatModel.Ins.setChatText(UI.selfText, getYuYinText(chatMsg), 20, 0, new Color(119 / 255f, 79 / 255f, 49 / 255f));
                        //UI.selfContent.text = getYuYinText(chatMsg);
                    }
                    if (UI.selfYuyinTimeText != null) UI.selfYuyinTimeText.text = ChatModel.Ins.GetVoiceTime(chatMsg) + "秒"; ;
                    if (UI.selfYuyinBtn != null) UI.selfYuyinBtn.SetClickCallBack(playselfYuYin);
                }
                else
                {
                    if (UI.selfText != null)
                    {
                        ChatModel.Ins.setChatText(UI.selfText, chatMsg.getContent(), 20, 0, new Color(119 / 255f, 79 / 255f, 49 / 255f));
                        //UI.selfContent.text = chatMsg.getContent();
                    }
                    if (UI.selfYuyinBtn != null) UI.selfYuyinBtn.ClearClickCallBack();
                }
                if (UI.selfYuyinGo != null) UI.selfYuyinGo.SetActive(chatMsg.getChatType() == 1);
            }
        }

        public void setSiLiaoMsgInfo(ChatMsgData chatmsg)
        {
            setChannelMsgInfo(chatmsg);
        }

        public void setChannelMsgInfo(ChatMsgData chatmsg)
        {
            noticeInfo = null;
            sysmsgInfo = null;
            chatMsg = chatmsg;

            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(chatMsg.getChatTime());
            UI.roleName.text = chatMsg.getFromRoleName();//+ " : " + dt.ToString("yyyy-MM-dd HH:mm:ss");
            if (PropertyUtil.IsLegalID(chatMsg.getFromRoleTplId()))
            {
                //PathUtil.Ins.SetPetIconSource(UI.headIcon, chatMsg.getFromRoleTplId());
                PathUtil.Ins.SetHeadIcon(UI.headIcon, chatMsg.getFromRoleTplId());
                //VIP标示
                if (UI.vipsign != null && chatMsg.getFromRoleVipLevel()>0)
                {
                    Sprite t = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.chongzhiAtlasPath,
                        "v" + chatMsg.getFromRoleVipLevel());
                    UI.vipsign.sprite = t;
                    UI.vipsign.gameObject.SetActive(true);
                    UI.vipsign.SetNativeSize();
                }
            }
            else
            {
                //PathUtil.Ins.SetRawImageSource(UI.headIcon, "gm", PathUtil.TEXTUER_HEAD);
                PathUtil.Ins.SetHeadIcon(UI.headIcon, "gm");
                if (UI.vipsign != null)
                {
                    UI.vipsign.gameObject.SetActive(false);
                }
            }

            if (chatMsg.getFromRoleUUID() == Human.Instance.Id.ToString())
            {
                //是玩家自己，发送给别人的
                setASFromMeMsg();
            }
            else
            {
                //是别人发送给玩家的
                setASToMeMsg();
            }
            if (UI.channelName != null) UI.channelName.text = ChatScopeType.GetChatScopeName(chatmsg.getScope());
        }

        public void setSysNoticeInfo(SysNoticeInfoData noticeinfo)
        {
            noticeInfo = noticeinfo;
            sysmsgInfo = null;
            chatMsg = null;
            if (UI.duifangYuyinGo != null) UI.duifangYuyinGo.SetActive(false);
            //setASToMeMsg();
            if (UI.selfMsgGo != null) UI.selfMsgGo.gameObject.SetActive(false);
            if (UI.duifangMsgGo != null) UI.duifangMsgGo.gameObject.SetActive(true);
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(noticeInfo.getChatTime());
            UI.roleName.text = "系统";//+dt.ToString("yyyy-MM-dd HH:mm:ss");
            ChatModel.Ins.setChatText(UI.duifangText, noticeInfo.getContent(), 20, 0, Color.yellow);
            //UI.duifangContent.text = noticeInfo.getContent();
            //if (UI.headIcon != null) PathUtil.Ins.SetRawImageSource(UI.headIcon, "gm", PathUtil.TEXTUER_HEAD);
            if (UI.headIcon != null)
            {
                PathUtil.Ins.SetHeadIcon(UI.headIcon, "gm");
            }
            if (UI.vipsign != null)
            {
                UI.vipsign.gameObject.SetActive(false);
            }
        }

        public void setSysMessageInfo(SysMsgInfoData msgInfo)
        {
            noticeInfo = null;
            sysmsgInfo = msgInfo;
            chatMsg = null;
            if (UI.duifangYuyinGo!=null) UI.duifangYuyinGo.SetActive(false);
            //setASToMeMsg();
            if (UI.selfMsgGo != null) UI.selfMsgGo.gameObject.SetActive(false);
            if (UI.duifangMsgGo != null) UI.duifangMsgGo.gameObject.SetActive(true);
            if (UI.channelName != null) UI.channelName.text = "系统";
            UI.roleName.text = "";
            //UI.duifangContent.text = "" + sysmsgInfo.content;
            ChatModel.Ins.setChatText(UI.duifangText, sysmsgInfo.content, 20, 0, Color.yellow);
            //if (UI.headIcon!=null) PathUtil.Ins.SetRawImageSource(UI.headIcon, "gm", PathUtil.TEXTUER_HEAD);
            if (UI.headIcon != null)
            {
                PathUtil.Ins.SetHeadIcon(UI.headIcon, "gm");
            }
            if (UI.vipsign != null)
            {
                UI.vipsign.gameObject.SetActive(false);
            }
        }

        public void clear()
        {
            noticeInfo = null;
            sysmsgInfo = null;
            chatMsg = null;
        }

        public void Destroy()
        {
            clear();
            if (playSoundTimer != null)
            {
                playSoundTimer.stop();
                playSoundTimer = null;
            }
            
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }
    }

}