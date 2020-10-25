package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.treasuremap.msg.GCOpenTreasuremapPanel;
import com.imop.lj.gameserver.treasuremap.msg.GCTreasuremapDone;
import com.imop.lj.gameserver.treasuremap.msg.GCTreasuremapUpdate;

public class RobotTreasuremapClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_OPEN_TREASUREMAP_PANEL, GCOpenTreasuremapPanel.class);
		msgs.put(MessageType.GC_TREASUREMAP_DONE, GCTreasuremapDone.class);
		msgs.put(MessageType.GC_TREASUREMAP_UPDATE, GCTreasuremapUpdate.class);
		return msgs;
	}
}
