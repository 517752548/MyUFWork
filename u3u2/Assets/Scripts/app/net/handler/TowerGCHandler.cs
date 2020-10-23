using app.battle;
using app.tongtianta;
using app.state;
using app.zone;
namespace app.net
{
	public class TowerGCHandler : IGCHandler
	{
		public const string GCTowerInfoEvent = "GCTowerInfoEvent";
		public const string GCOpenDoubleStatusEvent = "GCOpenDoubleStatusEvent";
		public const string GCWatchFirstKillerReplayEvent = "GCWatchFirstKillerReplayEvent";
		public const string GCWatchBestKillerReplayEvent = "GCWatchBestKillerReplayEvent";
		public const string GCTowerRewardEvent = "GCTowerRewardEvent";
		public const string GCGuajiEvent = "GCGuajiEvent";
		public const string GCStopGuajiEvent = "GCStopGuajiEvent";
		
		public TowerGCHandler()
        {
            EventCore.addRMetaEventListener(GCTowerInfoEvent, GCTowerInfoHandler);
            EventCore.addRMetaEventListener(GCOpenDoubleStatusEvent, GCOpenDoubleStatusHandler);
            EventCore.addRMetaEventListener(GCWatchFirstKillerReplayEvent, GCWatchFirstKillerReplayHandler);
            EventCore.addRMetaEventListener(GCWatchBestKillerReplayEvent, GCWatchBestKillerReplayHandler);
            EventCore.addRMetaEventListener(GCTowerRewardEvent, GCTowerRewardHandler);
            EventCore.addRMetaEventListener(GCGuajiEvent, GCGuajiHandler);
            EventCore.addRMetaEventListener(GCStopGuajiEvent, GCStopGuajiHandler);
        }
        
        private void GCTowerInfoHandler(RMetaEvent e)
        {
        	GCTowerInfo msg = e.data as GCTowerInfo;
            TongTianTaModel.ins.towerInfo = msg.getTowerInfo();
        	
        }
        
        private void GCOpenDoubleStatusHandler(RMetaEvent e)
        {
        	GCOpenDoubleStatus msg = e.data as GCOpenDoubleStatus;
            TongTianTaModel.ins.doubleStatus = msg;
        	
        }
        
        private void GCWatchFirstKillerReplayHandler(RMetaEvent e)
        {
        	GCWatchFirstKillerReplay msg = e.data as GCWatchFirstKillerReplay;
            ClientLog.Log("&&&&&&&&&&&&&&&&&&&&  收到所有回合的战报  &&&&&&&&&&&&&&&&&&&&&&&&&");
            BattleCGHandler.sendCGPlayBattleReportByStrId(msg.getFirstKillerInfo(),0);

            //BattleModel.ins.battleType = BattleType.PLAY_BATTLE_REPORT;
            //BattleModel.ins.selfSiteType = BatCharacterSiteType.NONE;
            //BattleManager.ins.ParseWholeBattleReportData(msg.getFirstKillerInfo());           
            //if (StateManager.Ins.getCurState().state != StateDef.battleState && ZoneModel.ins.isZoneLoaded)
            //{
            //    StateManager.Ins.changeState(StateDef.battleState);
            //}
        }
        
        private void GCWatchBestKillerReplayHandler(RMetaEvent e)
        {
        	GCWatchBestKillerReplay msg = e.data as GCWatchBestKillerReplay;
            ClientLog.Log("&&&&&&&&&&&&&&&&&&&&  收到所有回合的战报  &&&&&&&&&&&&&&&&&&&&&&&&&");
            BattleCGHandler.sendCGPlayBattleReportByStrId(msg.getBestKillerInfo(), 0);

            //BattleModel.ins.battleType = BattleType.PLAY_BATTLE_REPORT;
            //BattleModel.ins.selfSiteType = BatCharacterSiteType.NONE;
            //BattleManager.ins.ParseWholeBattleReportData(msg.getBestKillerInfo());
            //if (StateManager.Ins.getCurState().state != StateDef.battleState && ZoneModel.ins.isZoneLoaded)
            //{
            //    StateManager.Ins.changeState(StateDef.battleState);
            //}
        }
        
        private void GCTowerRewardHandler(RMetaEvent e)
        {
        	GCTowerReward msg = e.data as GCTowerReward;
            TongTianTaModel.ins.towerReward = msg;
        }
        
        private void GCGuajiHandler(RMetaEvent e)
        {
        	GCGuaji msg = e.data as GCGuaji;
            //TongTianTaModel.ins.guajiResult = msg;        	
        }
        
        private void GCStopGuajiHandler(RMetaEvent e)
        {
        	GCStopGuaji msg = e.data as GCStopGuaji;
           
        	
        }
	}
}