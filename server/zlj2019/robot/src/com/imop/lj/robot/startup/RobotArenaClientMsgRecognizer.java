package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.arena.msg.GCShowArenaPanelMain;
import com.imop.lj.gameserver.arena.msg.GCArenaBuyChallengeTime;
import com.imop.lj.gameserver.arena.msg.GCArenaTopRankList;
import com.imop.lj.gameserver.arena.msg.GCArenaKillCd;
import com.imop.lj.gameserver.arena.msg.GCArenaBattleRecord;
import com.imop.lj.gameserver.arena.msg.GCArenaRankRewardList;

public class RobotArenaClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_SHOW_ARENA_PANEL_MAIN, GCShowArenaPanelMain.class);
		msgs.put(MessageType.GC_ARENA_BUY_CHALLENGE_TIME, GCArenaBuyChallengeTime.class);
		msgs.put(MessageType.GC_ARENA_TOP_RANK_LIST, GCArenaTopRankList.class);
		msgs.put(MessageType.GC_ARENA_KILL_CD, GCArenaKillCd.class);
		msgs.put(MessageType.GC_ARENA_BATTLE_RECORD, GCArenaBattleRecord.class);
		msgs.put(MessageType.GC_ARENA_RANK_REWARD_LIST, GCArenaRankRewardList.class);
		return msgs;
	}
}
