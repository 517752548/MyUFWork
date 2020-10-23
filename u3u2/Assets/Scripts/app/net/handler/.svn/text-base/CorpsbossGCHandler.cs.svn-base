using app.bangpaiBoss;

namespace app.net
{
	public class CorpsbossGCHandler : IGCHandler
	{
		public const string GCCorpsBossInfoEvent = "GCCorpsBossInfoEvent";
		public const string GCCorpsbossAskEnterTeamEvent = "GCCorpsbossAskEnterTeamEvent";
		public const string GCCorpsbossRankListEvent = "GCCorpsbossRankListEvent";
		public const string GCCorpsbossCountRankListEvent = "GCCorpsbossCountRankListEvent";

		public CorpsbossGCHandler()
        {
            EventCore.addRMetaEventListener(GCCorpsBossInfoEvent, GCCorpsBossInfoHandler);
            EventCore.addRMetaEventListener(GCCorpsbossAskEnterTeamEvent, GCCorpsbossAskEnterTeamHandler);
            EventCore.addRMetaEventListener(GCCorpsbossRankListEvent, GCCorpsbossRankListHandler);
            EventCore.addRMetaEventListener(GCCorpsbossCountRankListEvent, GCCorpsbossCountRankListHandler);
        }
        
        private void GCCorpsBossInfoHandler(RMetaEvent e)
        {
        	GCCorpsBossInfo msg = e.data as GCCorpsBossInfo;
            BangPaiBossModel.Ins.bossInfo = msg;
        }
        
        private void GCCorpsbossAskEnterTeamHandler(RMetaEvent e)
        {
        	GCCorpsbossAskEnterTeam msg = e.data as GCCorpsbossAskEnterTeam;
            BangPaiBossModel.Ins.askEnterTeam = msg;
        }
        
        private void GCCorpsbossRankListHandler(RMetaEvent e)
        {
        	GCCorpsbossRankList msg = e.data as GCCorpsbossRankList;
            BangPaiBossModel.Ins.corpsBossRankList = msg ;
        }
        
        private void GCCorpsbossCountRankListHandler(RMetaEvent e)
        {
        	GCCorpsbossCountRankList msg = e.data as GCCorpsbossCountRankList;
            BangPaiBossModel.Ins.corpsBossCountRankList = msg;
        }
        

	}
}