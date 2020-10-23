package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.wallow.msg.GCWallowOpenPanel;
import com.imop.lj.gameserver.wallow.msg.GCWallowAddInfoResult;

public class RobotWallowClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_WALLOW_OPEN_PANEL, GCWallowOpenPanel.class);
		msgs.put(MessageType.GC_WALLOW_ADD_INFO_RESULT, GCWallowAddInfoResult.class);
		return msgs;
	}
}
