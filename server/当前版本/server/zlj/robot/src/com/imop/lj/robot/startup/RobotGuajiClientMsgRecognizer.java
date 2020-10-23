package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.guaji.msg.GCGuaJiPanel;
import com.imop.lj.gameserver.guaji.msg.GCStartGuaJi;

public class RobotGuajiClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_GUA_JI_PANEL, GCGuaJiPanel.class);
		msgs.put(MessageType.GC_START_GUA_JI, GCStartGuaJi.class);
		return msgs;
	}
}
