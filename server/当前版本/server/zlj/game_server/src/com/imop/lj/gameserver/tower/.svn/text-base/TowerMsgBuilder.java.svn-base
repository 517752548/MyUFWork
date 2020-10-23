package com.imop.lj.gameserver.tower;

import com.imop.lj.common.model.tower.TowerInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.tower.msg.GCGuaji;
import com.imop.lj.gameserver.tower.msg.GCStopGuaji;
import com.imop.lj.gameserver.tower.msg.GCTowerInfo;
import com.imop.lj.gameserver.tower.msg.GCTowerReward;
import com.imop.lj.gameserver.tower.msg.GCWatchBestKillerReplay;
import com.imop.lj.gameserver.tower.msg.GCWatchFirstKillerReplay;

/**
 * 通天塔消息生成器
 *
 */
public class TowerMsgBuilder {

	private static TowerInfo createTowerInfo(int curTowerLevel){
		TowerInfo info = new TowerInfo();
		info.setCurTowerLevel(curTowerLevel);
		return info;
	}
	
	public static GCTowerInfo createGCTowerInfo(Human human){
		GCTowerInfo msg = new GCTowerInfo();
		TowerManager towerManager = human.getTowerManager();
		if(towerManager == null){
			return null;
		}
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
		if(offlineData == null){
			return null;
		}
		
		msg.setTowerInfo(createTowerInfo(towerManager.getCurTowerLevel()));
		return msg;
	} 
	
	public static GCWatchFirstKillerReplay createGCWatchFirstKillerReplay(Human human,Tower t){
		GCWatchFirstKillerReplay msg = new GCWatchFirstKillerReplay();
		msg.setCharId(t.getfCharId());
		msg.setRound(t.getfRound());
		msg.setLevel(t.getfLevel());
		msg.setBattleEndTime(t.getBattleEndTime());
		msg.setFirstKillerInfo(t.getFirstKiller());
		return msg;
	}
	
	public static GCWatchBestKillerReplay createGCWatchBestKillerReplay(Human human, Tower t){
		GCWatchBestKillerReplay msg = new GCWatchBestKillerReplay();
		msg.setCharId(t.getbCharId());
		msg.setRound(t.getbRound());
		msg.setLevel(t.getbLevel());
		msg.setBattleDuration(t.getBattleDuration());
		msg.setBestKillerInfo(t.getBestKiller());
		return msg;
	}
	
	public static GCTowerReward createGCTowerReward(){
		GCTowerReward msg = new GCTowerReward();
		msg.setShowRewardList(Globals.getTemplateCacheService().getTowerTemplateCache().getShowRewardList().toArray(new String[0]));
		msg.setShowRewardNameList(Globals.getTemplateCacheService().getTowerTemplateCache().getShowRewardNameList().toArray(new String[0]));
		return msg;
	}

	public static GCGuaji createGCGuaji(Human human, int flag) {
		GCGuaji msg = new GCGuaji();
		msg.setResult(flag);
		return msg;
	}
	
	public static GCStopGuaji createGCStopGuaji(Human human) {
		GCStopGuaji msg = new GCStopGuaji();
		msg.setMapId(human.getMapId());
		return msg;
	}
}
