package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.timelimit.msg.GCOpenTlMonsterPanel;
import com.imop.lj.gameserver.timelimit.msg.GCTlMonsterDone;
import com.imop.lj.gameserver.timelimit.msg.GCTlMonsterUpdate;

public class RobotTimelimitmonsterClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_OPEN_TL_MONSTER_PANEL, GCOpenTlMonsterPanel.class);
		msgs.put(MessageType.GC_TL_MONSTER_DONE, GCTlMonsterDone.class);
		msgs.put(MessageType.GC_TL_MONSTER_UPDATE, GCTlMonsterUpdate.class);
		return msgs;
	}
}
