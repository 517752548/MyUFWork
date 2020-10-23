
namespace app.chat
{
    public class ChatSettingView:BaseWnd
    {
        public ChatSettingUI UI;
        
        public ChatSettingView()
        {
            uiName = "ChatSettingUI";
            useTween = false;
            isShowBgMask = true;
            bgMaskAlpha = 0.2f;
        }

        public override void initWnd()
        {
            base.initWnd();

            UI = ui.AddComponent<ChatSettingUI>();
            UI.Init();
            UI.closeBtn.AddClickCallBack(clickClose);
            UI.suerBtn.AddClickCallBack(clickSure);
            AddListener();

            if (!ChatModel.Ins.ScopeMsgShow.ContainsKey(ChatScopeType.CHAT_SCOPE_WORLD))
            {
                ChatModel.Ins.ScopeMsgShow.Add(ChatScopeType.CHAT_SCOPE_WORLD, true);
            }
            if (!ChatModel.Ins.ScopeMsgShow.ContainsKey(ChatScopeType.CHAT_SCOPE_CORPS))
            {
                ChatModel.Ins.ScopeMsgShow.Add(ChatScopeType.CHAT_SCOPE_CORPS, true);
            }
            if (!ChatModel.Ins.ScopeMsgShow.ContainsKey(ChatScopeType.CHAT_SCOPE_DEFAULT))
            {
                ChatModel.Ins.ScopeMsgShow.Add(ChatScopeType.CHAT_SCOPE_DEFAULT, true);
            }
            if (!ChatModel.Ins.ScopeMsgShow.ContainsKey(ChatScopeType.CHAT_SCOPE_COUNTRY))
            {
                ChatModel.Ins.ScopeMsgShow.Add(ChatScopeType.CHAT_SCOPE_COUNTRY, true);
            }
            if (!ChatModel.Ins.ScopeMsgShow.ContainsKey(ChatScopeType.CHAT_SCOPE_TEAM))
            {
                ChatModel.Ins.ScopeMsgShow.Add(ChatScopeType.CHAT_SCOPE_TEAM, true);
            }
        }

        private void AddListener()
        {
        }

        private void clickSure()
        {
            ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_WORLD]= UI.shijieToggle.isOn;
            ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_CORPS]= UI.bangpaiToggle.isOn;
            ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_DEFAULT]= UI.xitongToggle.isOn;
            ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_COUNTRY]= UI.dangqianToggle.isOn;
            ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_TEAM]= UI.duiwuToggle.isOn;
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);

            UI.shijieToggle.isOn = ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_WORLD];
            UI.bangpaiToggle.isOn=ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_CORPS];
            UI.xitongToggle.isOn=ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_DEFAULT];
            UI.dangqianToggle.isOn=ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_COUNTRY];
            UI.duiwuToggle.isOn=ChatModel.Ins.ScopeMsgShow[ChatScopeType.CHAT_SCOPE_TEAM];
        }

        private void clickClose()
        {
            hide();
        }

        public override void Destroy()
        {
            RemoveListener();
            base.Destroy();
        }

        private void RemoveListener()
        {

        }
    }
}
