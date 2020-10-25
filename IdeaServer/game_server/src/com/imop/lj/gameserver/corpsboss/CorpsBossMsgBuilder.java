package com.imop.lj.gameserver.corpsboss;

import java.util.List;

import com.imop.lj.common.model.corps.CorpsBossCountRankInfo;
import com.imop.lj.common.model.corps.CorpsBossInfo;
import com.imop.lj.common.model.corps.CorpsBossRankInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corpsboss.msg.GCCorpsBossInfo;
import com.imop.lj.gameserver.corpsboss.msg.GCCorpsbossAskEnterTeam;
import com.imop.lj.gameserver.corpsboss.msg.GCCorpsbossCountRankList;
import com.imop.lj.gameserver.corpsboss.msg.GCCorpsbossRankList;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;

public class CorpsBossMsgBuilder {

	public static GCCorpsBossInfo createGCCorpsBossInfo(Human human, List<CorpsBossInfo> lst){
		long roleId = human.getCharId();
		GCCorpsBossInfo msg = new GCCorpsBossInfo();
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if(offlineData == null){
			return null;
		}
		msg.setCurCorpsBossLevel(offlineData.getCurCorpsBossLevel());
		msg.setCorpsBossInfoDataList(lst.toArray(new CorpsBossInfo[0]));
		return msg;
	}
	
	public static GCCorpsbossAskEnterTeam createGCCorpsbossAskEnterTeam(int level){
		GCCorpsbossAskEnterTeam msg = new GCCorpsbossAskEnterTeam(level);
		return msg;
	}
	
	public static GCCorpsbossRankList createGCCorpsbossRankList(CorpsBossRankInfo info, List<CorpsBossRankInfo> infoList){
		GCCorpsbossRankList msg = new GCCorpsbossRankList(info, infoList.toArray(new CorpsBossRankInfo[0]));
		return msg;
	}

	public static GCCorpsbossCountRankList buildCorpsBossCountRankInfo(CorpsBossCountRankInfo info, List<CorpsBossCountRankInfo> infoList) {
		GCCorpsbossCountRankList msg = new GCCorpsbossCountRankList(info, infoList.toArray(new CorpsBossCountRankInfo[0]));
		return msg;
	}
}
