using System.Collections.Generic;
using System.Linq;
using app.jingjichang;

namespace app.net
{
	public class ArenaGCHandler : IGCHandler
	{
		public const string GCShowArenaPanelMainEvent = "GCShowArenaPanelMainEvent";
		public const string GCArenaBuyChallengeTimeEvent = "GCArenaBuyChallengeTimeEvent";
		public const string GCArenaTopRankListEvent = "GCArenaTopRankListEvent";
		public const string GCArenaKillCdEvent = "GCArenaKillCdEvent";
		public const string GCArenaBattleRecordEvent = "GCArenaBattleRecordEvent";
		public const string GCArenaRankRewardListEvent = "GCArenaRankRewardListEvent";
	    private JingJiChangModel jingjichangModel;

		public ArenaGCHandler()
        {
            EventCore.addRMetaEventListener(GCShowArenaPanelMainEvent, GCShowArenaPanelMainHandler);
            EventCore.addRMetaEventListener(GCArenaBuyChallengeTimeEvent, GCArenaBuyChallengeTimeHandler);
            EventCore.addRMetaEventListener(GCArenaTopRankListEvent, GCArenaTopRankListHandler);
            EventCore.addRMetaEventListener(GCArenaKillCdEvent, GCArenaKillCdHandler);
            EventCore.addRMetaEventListener(GCArenaBattleRecordEvent, GCArenaBattleRecordHandler);
            EventCore.addRMetaEventListener(GCArenaRankRewardListEvent, GCArenaRankRewardListHandler);

		    //jingjichangModel = Singleton.getObj(typeof (JingJiChangModel)) as JingJiChangModel;
            jingjichangModel = JingJiChangModel.Ins;
        }
        
        private void GCShowArenaPanelMainHandler(RMetaEvent e)
        {
        	GCShowArenaPanelMain msg = e.data as GCShowArenaPanelMain;
            jingjichangModel.PanelInfo = msg;
        }
        
        private void GCArenaBuyChallengeTimeHandler(RMetaEvent e)
        {
        	GCArenaBuyChallengeTime msg = e.data as GCArenaBuyChallengeTime;
        	jingjichangModel.CurChallengeTimes=(msg.getChallengeTimes());
        }
        
        private void GCArenaTopRankListHandler(RMetaEvent e)
        {
        	GCArenaTopRankList msg = e.data as GCArenaTopRankList;
            jingjichangModel.MyRankListInfo = msg;
            jingjichangModel.RankList = msg.getArenaTopMemberList().ToList();
        }
        
        private void GCArenaKillCdHandler(RMetaEvent e)
        {
        	GCArenaKillCd msg = e.data as GCArenaKillCd;
        	jingjichangModel.removeCD();
        }
        
        private void GCArenaBattleRecordHandler(RMetaEvent e)
        {
        	GCArenaBattleRecord msg = e.data as GCArenaBattleRecord;
            jingjichangModel.ZhanbaoInfo = msg;
        }
        
        private void GCArenaRankRewardListHandler(RMetaEvent e)
        {
        	GCArenaRankRewardList msg = e.data as GCArenaRankRewardList;
            jingjichangModel.RewardInfo = msg;
        }
        

	}
}