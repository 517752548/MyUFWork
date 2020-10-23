package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.chat.msg.GCChatMsg;
import com.imop.lj.gameserver.chat.msg.GCChatMsgList;

public class RobotChatClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_CHAT_MSG, GCChatMsg.class);
		msgs.put(MessageType.GC_CHAT_MSG_LIST, GCChatMsgList.class);
		return msgs;
	}
}
