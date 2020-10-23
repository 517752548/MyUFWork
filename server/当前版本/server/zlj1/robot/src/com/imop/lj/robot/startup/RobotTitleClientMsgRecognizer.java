package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.title.msg.GCTitlePanel;
import com.imop.lj.gameserver.title.msg.GCUsrTitle;

public class RobotTitleClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_TITLE_PANEL, GCTitlePanel.class);
		msgs.put(MessageType.GC_USR_TITLE, GCUsrTitle.class);
		return msgs;
	}
}
