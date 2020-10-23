package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.test.msg.GCTest;
import com.imop.lj.gameserver.test.msg.GCTestLong;
import com.imop.lj.gameserver.test.msg.GCTest1;

public class RobotTestClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_TEST, GCTest.class);
		msgs.put(MessageType.GC_TEST_LONG, GCTestLong.class);
		msgs.put(MessageType.GC_TEST1, GCTest1.class);
		return msgs;
	}
}
