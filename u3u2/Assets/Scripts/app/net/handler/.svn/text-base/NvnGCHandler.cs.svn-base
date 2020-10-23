using app.nvsn;

namespace app.net
{
	public class NvnGCHandler : IGCHandler
	{
		public const string GCNvnMyInfoEvent = "GCNvnMyInfoEvent";
		public const string GCNvnRankListEvent = "GCNvnRankListEvent";
		public const string GCNvnMatchedTeamInfoEvent = "GCNvnMatchedTeamInfoEvent";
		public const string GCNvnMatchStatusEvent = "GCNvnMatchStatusEvent";
		public const string GCNvnLeaveEvent = "GCNvnLeaveEvent";
        public const string GCNvnRuleEvent = "GCNvnRuleEvent";
        
	    public NvsNModel nvsnmodel;
		public NvnGCHandler()
        {
            EventCore.addRMetaEventListener(GCNvnMyInfoEvent, GCNvnMyInfoHandler);
            EventCore.addRMetaEventListener(GCNvnRankListEvent, GCNvnRankListHandler);
            EventCore.addRMetaEventListener(GCNvnMatchedTeamInfoEvent, GCNvnMatchedTeamInfoHandler);
            EventCore.addRMetaEventListener(GCNvnMatchStatusEvent, GCNvnMatchStatusHandler);
            EventCore.addRMetaEventListener(GCNvnLeaveEvent, GCNvnLeaveHandler);
            EventCore.addRMetaEventListener(GCNvnRuleEvent, GCNvnRuleHandler);
		    //nvsnmodel = Singleton.getObj(typeof (NvsNModel)) as NvsNModel;
            nvsnmodel = NvsNModel.Ins;
        }
        
        private void GCNvnMyInfoHandler(RMetaEvent e)
        {
        	GCNvnMyInfo msg = e.data as GCNvnMyInfo;
            nvsnmodel.MyInfo = msg;
        }
        
        private void GCNvnRankListHandler(RMetaEvent e)
        {
        	GCNvnRankList msg = e.data as GCNvnRankList;
            nvsnmodel.MyrankInfo = msg;
            nvsnmodel.RankList = msg.getNvnRankInfoList();
        }
        
        private void GCNvnMatchedTeamInfoHandler(RMetaEvent e)
        {
        	GCNvnMatchedTeamInfo msg = e.data as GCNvnMatchedTeamInfo;
            nvsnmodel.MatchedTeamInfo = msg;
        }
        
        private void GCNvnMatchStatusHandler(RMetaEvent e)
        {
        	GCNvnMatchStatus msg = e.data as GCNvnMatchStatus;
            nvsnmodel.CurrentNvsNStatus = msg.getTeamStatus();
        }
        
        private void GCNvnLeaveHandler(RMetaEvent e)
        {
        	GCNvnLeave msg = e.data as GCNvnLeave;
        	
        }

        private void GCNvnRuleHandler(RMetaEvent e)
        {
            GCNvnRule msg = e.data as GCNvnRule;
            nvsnmodel.RuleData = msg;
            nvsnmodel.OpenRuleWnd();
        }
	}
}