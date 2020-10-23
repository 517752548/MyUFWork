package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.timelimit.msg.GCOpenTlNpcPanel;
import com.imop.lj.gameserver.timelimit.msg.GCTlNpcDone;
import com.imop.lj.gameserver.timelimit.msg.GCTlNpcUpdate;

public class RobotTimelimitnpcClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_OPEN_TL_NPC_PANEL, GCOpenTlNpcPanel.class);
		msgs.put(MessageType.GC_TL_NPC_DONE, GCTlNpcDone.class);
		msgs.put(MessageType.GC_TL_NPC_UPDATE, GCTlNpcUpdate.class);
		return msgs;
	}
}
