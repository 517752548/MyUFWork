using System.Collections.Generic;
using System.Linq;
using app.human;
using app.model;
using app.zone;
using app.main;

namespace app.net
{
    public class PlayerGCHandler : IGCHandler
    {
        public const string GCRoleListEvent = "GCRoleListEvent";
        public const string GCRoleTemplateEvent = "GCRoleTemplateEvent";
        public const string GCGameEnterPlayerNumEvent = "GCGameEnterPlayerNumEvent";
        public const string GCRoleRandomNameEvent = "GCRoleRandomNameEvent";
        public const string GCFailedMsgEvent = "GCFailedMsgEvent";
        public const string GCSceneInfoEvent = "GCSceneInfoEvent";
        public const string GCEnterSceneEvent = "GCEnterSceneEvent";
        public const string GCNotifyExceptionEvent = "GCNotifyExceptionEvent";
        public const string GCPopupPanelEndEvent = "GCPopupPanelEndEvent";
        public const string GCPlayerChargeDiamondEvent = "GCPlayerChargeDiamondEvent";
        public const string GCPlayerQueryAccountEvent = "GCPlayerQueryAccountEvent";
        public const string GCWallowLoginNoticeEvent = "GCWallowLoginNoticeEvent";
        public const string GCGetSmsCheckcodeEvent = "GCGetSmsCheckcodeEvent";
        public const string GCCheckSmsCheckcodeEvent = "GCCheckSmsCheckcodeEvent";
        public const string GCSmsCheckcodePanelEvent = "GCSmsCheckcodePanelEvent";
        public const string GCReloginEvent = "GCReloginEvent";
        public const string GCUpdateTokenEvent = "GCUpdateTokenEvent";
		public const string GCChargeRecordEvent = "GCChargeRecordEvent";
		public const string GCChargeGenOrderidEvent = "GCChargeGenOrderidEvent";
		public const string GCLoginPopPanelEvent = "GCLoginPopPanelEvent";

        public PlayerGCHandler()
        {
            EventCore.addRMetaEventListener(GCRoleListEvent, GCRoleListHandler);
            EventCore.addRMetaEventListener(GCRoleTemplateEvent, GCRoleTemplateHandler);
            EventCore.addRMetaEventListener(GCGameEnterPlayerNumEvent, GCGameEnterPlayerNumHandler);
            EventCore.addRMetaEventListener(GCRoleRandomNameEvent, GCRoleRandomNameHandler);
            EventCore.addRMetaEventListener(GCFailedMsgEvent, GCFailedMsgHandler);
            EventCore.addRMetaEventListener(GCSceneInfoEvent, GCSceneInfoHandler);
            EventCore.addRMetaEventListener(GCEnterSceneEvent, GCEnterSceneHandler);
            EventCore.addRMetaEventListener(GCNotifyExceptionEvent, GCNotifyExceptionHandler);
            EventCore.addRMetaEventListener(GCPopupPanelEndEvent, GCPopupPanelEndHandler);
            EventCore.addRMetaEventListener(GCPlayerChargeDiamondEvent, GCPlayerChargeDiamondHandler);
            EventCore.addRMetaEventListener(GCPlayerQueryAccountEvent, GCPlayerQueryAccountHandler);
            EventCore.addRMetaEventListener(GCWallowLoginNoticeEvent, GCWallowLoginNoticeHandler);
            EventCore.addRMetaEventListener(GCGetSmsCheckcodeEvent, GCGetSmsCheckcodeHandler);
            EventCore.addRMetaEventListener(GCCheckSmsCheckcodeEvent, GCCheckSmsCheckcodeHandler);
            EventCore.addRMetaEventListener(GCSmsCheckcodePanelEvent, GCSmsCheckcodePanelHandler);
            EventCore.addRMetaEventListener(GCReloginEvent, GCReloginHandler);
            EventCore.addRMetaEventListener(GCUpdateTokenEvent, GCUpdateTokenHandler);
			EventCore.addRMetaEventListener(GCChargeRecordEvent, GCChargeRecordHandler);
			EventCore.addRMetaEventListener(GCChargeGenOrderidEvent, GCChargeGenOrderidHandler);
			EventCore.addRMetaEventListener(GCLoginPopPanelEvent, GCLoginPopPanelHandler);
        }

        private void GCRoleListHandler(RMetaEvent e)
        {
            ClientLog.Log("get gcRoleList");
            GCRoleList msg = e.data as GCRoleList;
            Human.Instance.Pid = msg.getPassportId();
            Human.Instance.PlayerModel.RoleList = msg;
            Human.Instance.PlayerModel.loginGame();
        }

        private void GCRoleTemplateHandler(RMetaEvent e)
        {
            GCRoleTemplate msg = e.data as GCRoleTemplate;
            int len = msg.getCreatePetInfoList().Length;
            ClientLog.LogWarning("创建角色"+len);
            List<CreatePetInfoData> list = msg.getCreatePetInfoList().ToList();
            list.Sort((a, b) => a.petTemplateId.CompareTo(b.petTemplateId));
            Human.Instance.PlayerModel.RoleTemplate = list.ToArray();

            //SourceManager.Ins.ignoreDispose(PathUtil.UI_TEXTUER_RELATIVE_DIR+PathUtil.TEXTUER_CREATEROLE);
            //SourceManager.Ins.ignoreDispose(PathUtil.UI_TEXTUER_RELATIVE_DIR + PathUtil.TEXTUER_YUAN_HEAD);
            List<object[]> loadlist = new List<object[]>();
            loadlist.Add(new object[]{PathUtil.Ins.GetUIPath("CreateRoleUI"), LoadArgs.SLIMABLE, LoadContentType.ABL});
            //for (int i=0;i<PathUtil.Ins.RoleModelNameList.Count;i++)
            //{
            //    loadlist.Add(new object[]{PathUtil.Ins.GetUITexturePath(PathUtil.Ins.RoleModelNameList[i],
            //        PathUtil.TEXTUER_CREATEROLE), LoadArgs.NONE, LoadContentType.ABL});
            //    loadlist.Add(new object[]{PathUtil.Ins.GetUITexturePath(PathUtil.Ins.RoleModelNameList[i],
            //        PathUtil.TEXTUER_YUAN_HEAD), LoadArgs.NONE, LoadContentType.ABL});
            //}
            //PreLoadingView.Ins.startLoading(loadlist,"正在加载创建角色资源...",CreateRoleLoadComplete,null,false);
            SourceLoader.Ins.loadList(loadlist, CreateRoleLoadComplete);
        }

        private void CreateRoleLoadComplete(RMetaEvent e)
        {
            if (WndManager.Ins.IsWndShowing(GlobalConstDefine.LoginView_Name))
            {
                WndManager.Ins.close(GlobalConstDefine.LoginView_Name);
            }

            WndManager.open(GlobalConstDefine.CreateRoleView_Name);
        }

        private void GCGameEnterPlayerNumHandler(RMetaEvent e)
        {
            GCGameEnterPlayerNum msg = e.data as GCGameEnterPlayerNum;

        }

        private void GCRoleRandomNameHandler(RMetaEvent e)
        {
            GCRoleRandomName msg = e.data as GCRoleRandomName;
            Human.Instance.PlayerModel.handleGCRoleName(msg.getName());
        }

        private void GCFailedMsgHandler(RMetaEvent e)
        {
            GCFailedMsg msg = e.data as GCFailedMsg;
            ZoneBubbleManager.ins.BubbleSysMsg(msg.getErrMsg());
        }

        private void GCSceneInfoHandler(RMetaEvent e)
        {
            PlayerCGHandler.sendCGEnterScene();
        }

        private void GCEnterSceneHandler(RMetaEvent e)
        {
            //Human.Instance.PlayerModel.handleGCEnterScene();
        }

        private void GCNotifyExceptionHandler(RMetaEvent e)
        {
            GCNotifyException msg = e.data as GCNotifyException;
            ClientLog.LogError("GCNotifyExceptionHandler errno=" +
                msg.getCode() + ";errmsg=" + msg.getErrMsg());

            //服务器踢人，发生了异常
            GameConnection.Instance.onServerKick(msg);
        }

        private void GCPopupPanelEndHandler(RMetaEvent e)
        {
            GCPopupPanelEnd msg = e.data as GCPopupPanelEnd;
           //登录时发的消息结束，初始化
           Human.Instance.PlayerModel.handleGCEnterScene();
        }

        private void GCPlayerChargeDiamondHandler(RMetaEvent e)
        {
            GCPlayerChargeDiamond msg = e.data as GCPlayerChargeDiamond;

        }

        private void GCPlayerQueryAccountHandler(RMetaEvent e)
        {
            GCPlayerQueryAccount msg = e.data as GCPlayerQueryAccount;

        }

        private void GCWallowLoginNoticeHandler(RMetaEvent e)
        {
            GCWallowLoginNotice msg = e.data as GCWallowLoginNotice;

        }

        private void GCGetSmsCheckcodeHandler(RMetaEvent e)
        {
            GCGetSmsCheckcode msg = e.data as GCGetSmsCheckcode;

        }

        private void GCCheckSmsCheckcodeHandler(RMetaEvent e)
        {
            GCCheckSmsCheckcode msg = e.data as GCCheckSmsCheckcode;

        }

        private void GCSmsCheckcodePanelHandler(RMetaEvent e)
        {
            GCSmsCheckcodePanel msg = e.data as GCSmsCheckcodePanel;

        }

        private void GCReloginHandler(RMetaEvent e)
        {
            GCRelogin msg = e.data as GCRelogin;
            ClientLog.Log("GCReloginHandler");
        }

        public static string token="";
        public static string pid = "";
        public static long id;

        private void GCUpdateTokenHandler(RMetaEvent e)
        {
            GCUpdateToken msg = e.data as GCUpdateToken;

            PlayerGCHandler.token = msg.getToken();
            PlayerGCHandler.pid = msg.getPid();
            PlayerGCHandler.id = msg.getRid();

            //收到此消息表示登录成功
            GameConnection.Instance.onLoginSuccess();
        }

		private void GCChargeRecordHandler(RMetaEvent e)
        {
        	GCChargeRecord msg = e.data as GCChargeRecord;
		    PlayerModel.Ins.ChargetRecord = msg;
        }

		private void GCChargeGenOrderidHandler(RMetaEvent e)
        {
        	GCChargeGenOrderid msg = e.data as GCChargeGenOrderid;
            SDKManager.ins.GotOrderId(msg.getOrderId());
        }

		private void GCLoginPopPanelHandler(RMetaEvent e)
        {
        	GCLoginPopPanel msg = e.data as GCLoginPopPanel;
		    PlayerModel.Ins.LoginPopPanel = msg;
        }

    }
}