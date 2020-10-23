using app.chat;

namespace app.net
{
	public class ChatGCHandler : IGCHandler
	{
		public const string GCChatMsgEvent = "GCChatMsgEvent";
		public const string GCChatMsgListEvent = "GCChatMsgListEvent";

		public ChatGCHandler()
        {
            EventCore.addRMetaEventListener(GCChatMsgEvent, GCChatMsgHandler);
			EventCore.addRMetaEventListener(GCChatMsgListEvent, GCChatMsgListHandler);
        }
        
        private void GCChatMsgHandler(RMetaEvent e)
        {
        	GCChatMsg msg = e.data as GCChatMsg;
            ChatModel.Ins.receiveChatData(msg);
        }
        
		private void GCChatMsgListHandler(RMetaEvent e)
        {
        	GCChatMsgList msg = e.data as GCChatMsgList;
            ChatModel.Ins.AddChatList(msg.getChatInfos());
        }

	}
}