package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.corpsboss.msg.GCCorpsBossInfo;
import com.imop.lj.gameserver.corpsboss.msg.GCCorpsbossAskEnterTeam;
import com.imop.lj.gameserver.corpsboss.msg.GCCorpsbossRankList;
import com.imop.lj.gameserver.corpsboss.msg.GCCorpsbossCountRankList;

public class RobotCorpsbossClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_CORPS_BOSS_INFO, GCCorpsBossInfo.class);
		msgs.put(MessageType.GC_CORPSBOSS_ASK_ENTER_TEAM, GCCorpsbossAskEnterTeam.class);
		msgs.put(MessageType.GC_CORPSBOSS_RANK_LIST, GCCorpsbossRankList.class);
		msgs.put(MessageType.GC_CORPSBOSS_COUNT_RANK_LIST, GCCorpsbossCountRankList.class);
		return msgs;
	}
}
