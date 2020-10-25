package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.goodactivity.msg.GCGoodActivityList;
import com.imop.lj.gameserver.goodactivity.msg.GCGoodActivityUpdate;

public class RobotGoodactivityClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_GOOD_ACTIVITY_LIST, GCGoodActivityList.class);
		msgs.put(MessageType.GC_GOOD_ACTIVITY_UPDATE, GCGoodActivityUpdate.class);
		return msgs;
	}
}
