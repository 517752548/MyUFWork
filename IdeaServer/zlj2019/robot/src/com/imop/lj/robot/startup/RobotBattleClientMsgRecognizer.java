package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.battle.msg.GCPlayBattleReport;
import com.imop.lj.gameserver.battle.msg.GCBattleReportPart;
import com.imop.lj.gameserver.battle.msg.GCBattleForceEnd;
import com.imop.lj.gameserver.battle.msg.GCBattleReportPvp;
import com.imop.lj.gameserver.battle.msg.GCBattleReportTeam;
import com.imop.lj.gameserver.battle.msg.GCBattleReadyChangedPvp;
import com.imop.lj.gameserver.battle.msg.GCBattleReadyChangedTeam;
import com.imop.lj.gameserver.battle.msg.GCBattleEnd;
import com.imop.lj.gameserver.battle.msg.GCBattleStartPvpInvite;
import com.imop.lj.gameserver.battle.msg.GCBattleSpeedup;

public class RobotBattleClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_PLAY_BATTLE_REPORT, GCPlayBattleReport.class);
		msgs.put(MessageType.GC_BATTLE_REPORT_PART, GCBattleReportPart.class);
		msgs.put(MessageType.GC_BATTLE_FORCE_END, GCBattleForceEnd.class);
		msgs.put(MessageType.GC_BATTLE_REPORT_PVP, GCBattleReportPvp.class);
		msgs.put(MessageType.GC_BATTLE_REPORT_TEAM, GCBattleReportTeam.class);
		msgs.put(MessageType.GC_BATTLE_READY_CHANGED_PVP, GCBattleReadyChangedPvp.class);
		msgs.put(MessageType.GC_BATTLE_READY_CHANGED_TEAM, GCBattleReadyChangedTeam.class);
		msgs.put(MessageType.GC_BATTLE_END, GCBattleEnd.class);
		msgs.put(MessageType.GC_BATTLE_START_PVP_INVITE, GCBattleStartPvpInvite.class);
		msgs.put(MessageType.GC_BATTLE_SPEEDUP, GCBattleSpeedup.class);
		return msgs;
	}
}
