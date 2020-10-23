package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.marry.msg.GCFirstMarry;
import com.imop.lj.gameserver.marry.msg.GCMarryInfo;
import com.imop.lj.gameserver.marry.msg.GCFirstFireMarry;

public class RobotMarryClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_FIRST_MARRY, GCFirstMarry.class);
		msgs.put(MessageType.GC_MARRY_INFO, GCMarryInfo.class);
		msgs.put(MessageType.GC_FIRST_FIRE_MARRY, GCFirstFireMarry.class);
		return msgs;
	}
}
