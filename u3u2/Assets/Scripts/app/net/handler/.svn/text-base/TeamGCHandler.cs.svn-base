using app.tongtianta;
using app.team;

namespace app.net
{
	public class TeamGCHandler : IGCHandler
	{
		public const string GCTeamMyTeamMemberListEvent = "GCTeamMyTeamMemberListEvent";
		public const string GCTeamMyTeamInfoEvent = "GCTeamMyTeamInfoEvent";
		public const string GCTeamApplyListEvent = "GCTeamApplyListEvent";
		public const string GCTeamShowListEvent = "GCTeamShowListEvent";
		public const string GCTeamApplyEvent = "GCTeamApplyEvent";
		public const string GCTeamApplyAutoEvent = "GCTeamApplyAutoEvent";
		public const string GCTeamInviteListEvent = "GCTeamInviteListEvent";
		public const string GCTeamInvitePlayerEvent = "GCTeamInvitePlayerEvent";
		public const string GCTeamInvitePlayerNoticeEvent = "GCTeamInvitePlayerNoticeEvent";
		public const string GCTeamQuitEvent = "GCTeamQuitEvent";
		public const string GCTeamCallBackNoticeEvent = "GCTeamCallBackNoticeEvent";

		public TeamGCHandler()
        {
            EventCore.addRMetaEventListener(GCTeamMyTeamMemberListEvent, GCTeamMyTeamMemberListHandler);
            EventCore.addRMetaEventListener(GCTeamMyTeamInfoEvent, GCTeamMyTeamInfoHandler);
            EventCore.addRMetaEventListener(GCTeamApplyListEvent, GCTeamApplyListHandler);
            EventCore.addRMetaEventListener(GCTeamShowListEvent, GCTeamShowListHandler);
            EventCore.addRMetaEventListener(GCTeamApplyEvent, GCTeamApplyHandler);
            EventCore.addRMetaEventListener(GCTeamApplyAutoEvent, GCTeamApplyAutoHandler);
            EventCore.addRMetaEventListener(GCTeamInviteListEvent, GCTeamInviteListHandler);
            EventCore.addRMetaEventListener(GCTeamInvitePlayerEvent, GCTeamInvitePlayerHandler);
            EventCore.addRMetaEventListener(GCTeamInvitePlayerNoticeEvent, GCTeamInvitePlayerNoticeHandler);
            EventCore.addRMetaEventListener(GCTeamQuitEvent, GCTeamQuitHandler);
            EventCore.addRMetaEventListener(GCTeamCallBackNoticeEvent, GCTeamCallBackNoticeHandler);
        }
        
        private void GCTeamMyTeamMemberListHandler(RMetaEvent e) 
        {
        	GCTeamMyTeamMemberList msg = e.data as GCTeamMyTeamMemberList;
            TeamManager.ins.OnReceivedMyTeamMemberList(msg.getTeamMemberInfos());
            //停止挂机状态
            TongTianTaModel.ins.StopAuto();
        }
        
        private void GCTeamMyTeamInfoHandler(RMetaEvent e)
        {
        	GCTeamMyTeamInfo msg = e.data as GCTeamMyTeamInfo;
            TeamManager.ins.OnReceivedMyTeamInfo(msg);
        }
        
        private void GCTeamApplyListHandler(RMetaEvent e)
        {
        	GCTeamApplyList msg = e.data as GCTeamApplyList;
            TeamManager.ins.OnReceivedTeamApplyMemberList(msg.getTeamMemberInfos());
        }
        
        private void GCTeamShowListHandler(RMetaEvent e)
        {
        	GCTeamShowList msg = e.data as GCTeamShowList;
            TeamManager.ins.OnReceivedTeamApplyList(msg.getTeamInfos());
        }
        
        private void GCTeamApplyHandler(RMetaEvent e)
        {
        	GCTeamApply msg = e.data as GCTeamApply;
            TeamManager.ins.OnReceivedTeamApplySuccss(msg.getTeamId());
        }
        
        private void GCTeamApplyAutoHandler(RMetaEvent e)
        {
        	GCTeamApplyAuto msg = e.data as GCTeamApplyAuto;
            TeamManager.ins.OnReceivedTeamApplyAuto(msg);
        }
        
        private void GCTeamInviteListHandler(RMetaEvent e)
        {
        	GCTeamInviteList msg = e.data as GCTeamInviteList;
            TeamManager.ins.OnReceivedInviteList(msg.getInviteTypeId(), msg.getTeamInvitePlayerInfos());
        }
        
        private void GCTeamInvitePlayerHandler(RMetaEvent e)
        {
        	GCTeamInvitePlayer msg = e.data as GCTeamInvitePlayer;
            TeamManager.ins.OnReceivedInviteSuccess(msg.getTargetPlayerId());
        }
        
        private void GCTeamInvitePlayerNoticeHandler(RMetaEvent e)
        {
        	GCTeamInvitePlayerNotice msg = e.data as GCTeamInvitePlayerNotice;
            TeamManager.ins.OnReceivedTeamInviteNotice(msg.getTeamId(),msg.getInviterName());
        }
        
        private void GCTeamQuitHandler(RMetaEvent e)
        {
        	GCTeamQuit msg = e.data as GCTeamQuit;
            TeamManager.ins.OnReceivedTeamQuit();
        }
        
        private void GCTeamCallBackNoticeHandler(RMetaEvent e)
        {
        	GCTeamCallBackNotice msg = e.data as GCTeamCallBackNotice;
            TeamManager.ins.OnReceivedTeamCallBackNotice();
        }
        

	}
}