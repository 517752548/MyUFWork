using app.zone;
using app.global;
using app.main;
using app.chat;
using app.pet;

namespace app.net
{
	public class CommonGCHandler : IGCHandler
	{
        public const string GCSystemMessageEvent = "GCSystemMessageEvent";
        public const string GCSystemNoticeEvent = "GCSystemNoticeEvent";
        public const string GCShowOptionDlgEvent = "GCShowOptionDlgEvent";
        public const string GCPingEvent = "GCPingEvent";
        public const string GCShowCurrencyEvent = "GCShowCurrencyEvent";
        public const string GCConstantListEvent = "GCConstantListEvent";
        public const string GCMusicConfigListEvent = "GCMusicConfigListEvent";
        public const string GCSystemMessageListEvent = "GCSystemMessageListEvent";
        public const string GCNoticeTipsInfoListEvent = "GCNoticeTipsInfoListEvent";
        public const string GCNoticeTipsInfoAddEvent = "GCNoticeTipsInfoAddEvent";
        public const string GCPopFlagEvent = "GCPopFlagEvent";
        public const string GCOfflineUserBaseInfoEvent = "GCOfflineUserBaseInfoEvent";
        public const string GCOfflineUserLeaderInfoEvent = "GCOfflineUserLeaderInfoEvent";
        public const string GCOfflineUserPetInfoEvent = "GCOfflineUserPetInfoEvent";

	    private ChatModel chatModel;
		public CommonGCHandler()
        {
            EventCore.addRMetaEventListener(GCSystemMessageEvent, GCSystemMessageHandler);
            EventCore.addRMetaEventListener(GCSystemNoticeEvent, GCSystemNoticeHandler);
            EventCore.addRMetaEventListener(GCShowOptionDlgEvent, GCShowOptionDlgHandler);
            EventCore.addRMetaEventListener(GCPingEvent, GCPingHandler);
            //EventCore.addRMetaEventListener(GCShowCurrencyEvent, GCShowCurrencyHandler);
            EventCore.addRMetaEventListener(GCConstantListEvent, GCConstantListHandler);
            //EventCore.addRMetaEventListener(GCMusicConfigListEvent, GCMusicConfigListHandler);
            EventCore.addRMetaEventListener(GCSystemMessageListEvent, GCSystemMessageListHandler);
            EventCore.addRMetaEventListener(GCNoticeTipsInfoListEvent, GCNoticeTipsInfoListHandler);
            EventCore.addRMetaEventListener(GCNoticeTipsInfoAddEvent, GCNoticeTipsInfoAddHandler);
            EventCore.addRMetaEventListener(GCPopFlagEvent, GCPopFlagHandler);
		    // chatModel = Singleton.getObj(typeof (ChatModel)) as ChatModel;
            chatModel = ChatModel.Ins;

            EventCore.addRMetaEventListener(GCOfflineUserBaseInfoEvent, GCOfflineUserBaseInfoHandler);
            EventCore.addRMetaEventListener(GCOfflineUserLeaderInfoEvent, GCOfflineUserLeaderInfoHandler);
            EventCore.addRMetaEventListener(GCOfflineUserPetInfoEvent, GCOfflineUserPetInfoHandler);
        }
        
        /// <summary>
        /// 冒泡提示，加
        /// </summary>
        /// <param name="e"></param>
        private void GCSystemMessageHandler(RMetaEvent e)
        {
        	GCSystemMessage msg = e.data as GCSystemMessage;
            string info = msg.getContent();
            ClientLog.Log("GCSystemMessageHandler :" + info);
            //冒泡
            ZoneBubbleManager.ins.BubbleSysMsg(msg.getContent());
            //系统提示
            SysMsgInfoData sysmsg = new SysMsgInfoData();
            sysmsg.content = msg.getContent();
            sysmsg.showType = msg.getShowType();
            chatModel.addSysMessage(sysmsg);
        }
        
        /// <summary>
        /// 跑马灯
        /// </summary>
        /// <param name="e"></param>
        private void GCSystemNoticeHandler(RMetaEvent e)
        {
        	GCSystemNotice msg = e.data as GCSystemNotice;
            string info = msg.getContent();
            if (!string.IsNullOrEmpty(info))
            {
                //系统跑马灯公告
                SystemNotice.ins.ShowNotice(msg.getContent());
                //系统提示
                SysMsgInfoData sysmsg = new SysMsgInfoData();
                sysmsg.content = msg.getContent();
                sysmsg.showType = (short)SystemMessageListType.NOTICE_MESSAGE;
                chatModel.addSysMessage(sysmsg);
            }
        }

        private void GCShowOptionDlgHandler(RMetaEvent e)
        {
            GCShowOptionDlg msg = e.data as GCShowOptionDlg;
            CommonCGHandler.sendCGSelectOption(msg.getTag(),1,1);
        }

        private void GCPingHandler(RMetaEvent e)
        {
            GCPing msg = e.data as GCPing;
            ClientLog.Log("recv gcping timestamp=" + msg.getTimestamp());
            GameClient.ins.serverTime = msg.getTimestamp();
            PetModel.Ins.dispatchChangeEvent(PetModel.UPDATE_SERVER_TIME,msg.getTimestamp());
        }
        
        //private void GCShowCurrencyHandler(RMetaEvent e)
        //{
        //    GCShowCurrency msg = e.data as GCShowCurrency;
        	
        //}
        
        private void GCConstantListHandler(RMetaEvent e)
        {
			GCConstantList msg = e.data as GCConstantList;
			ConstantModel.Ins.setData (msg);
        	
        }
        
        //private void GCMusicConfigListHandler(RMetaEvent e)
        //{
        //    GCMusicConfigList msg = e.data as GCMusicConfigList;
        	
        //}

        private void GCSystemMessageListHandler(RMetaEvent e)
        {
            GCSystemMessageList msg = e.data as GCSystemMessageList;
            for (int i=0;i<msg.getSysMsgInfoList().Length;i++)
            {
                switch (msg.getSysMsgInfoList()[i].showType)
                {
                    case (int)SystemMessageListType.SYSTEM_AND_CHAT_AND_NOTICE_MESSAGE:
                        if (!string.IsNullOrEmpty(msg.getSysMsgInfoList()[i].content))
                        {
                            SystemNotice.ins.ShowNotice(msg.getSysMsgInfoList()[i].content);

                            chatModel.addSysMessage(msg.getSysMsgInfoList()[i]);
                        }
                        break;
                    default:
                        if (!string.IsNullOrEmpty(msg.getSysMsgInfoList()[i].content))
                        {
                            ZoneBubbleManager.ins.BubbleSysMsg(msg.getSysMsgInfoList()[i].content);

                            chatModel.addSysMessage(msg.getSysMsgInfoList()[i]);
                        }
                        break;
                }
            }
        }
        
        //登录时推送来离线消息列表。
        private void GCNoticeTipsInfoListHandler(RMetaEvent e)
        {
            GCNoticeTipsInfoList msg = e.data as GCNoticeTipsInfoList;

            chatModel.setSysNoticeList(msg.getNoticeTipsInfoList());
        }
        
        //登录后的单条系统消息。
        private void GCNoticeTipsInfoAddHandler(RMetaEvent e)
        {
            GCNoticeTipsInfoAdd msg = e.data as GCNoticeTipsInfoAdd;

            chatModel.addSysNotice(msg.getNoticeTipsInfo());
        }

        private void GCPopFlagHandler(RMetaEvent e)
        {
            GCPopFlag msg = e.data as GCPopFlag;
            ZoneBubbleManager.ins.isEnabledByServer = (msg.getFlag() == 1);
        }

        private void GCOfflineUserBaseInfoHandler(RMetaEvent e)
        {
            GCOfflineUserBaseInfo msg = e.data as GCOfflineUserBaseInfo;
            PopRoleInfoWnd.Ins.RoleBaseInfoResult(msg);

        }

        private void GCOfflineUserLeaderInfoHandler(RMetaEvent e)
        {
            GCOfflineUserLeaderInfo msg = e.data as GCOfflineUserLeaderInfo;
            PopRoleDetailInfoWnd.Ins.RoleLeaderInfoResult(msg);
        }

        private void GCOfflineUserPetInfoHandler(RMetaEvent e)
        {
            GCOfflineUserPetInfo msg = e.data as GCOfflineUserPetInfo;
            PopPetInfoWnd.Ins.PetInfoResult(msg);
        }
	}
}