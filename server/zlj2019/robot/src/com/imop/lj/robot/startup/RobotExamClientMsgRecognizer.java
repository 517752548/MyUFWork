package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.exam.msg.GCExamApply;
import com.imop.lj.gameserver.exam.msg.GCExamUseItem;
import com.imop.lj.gameserver.exam.msg.GCExamChose;
import com.imop.lj.gameserver.exam.msg.GCExamInfo;

public class RobotExamClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_EXAM_APPLY, GCExamApply.class);
		msgs.put(MessageType.GC_EXAM_USE_ITEM, GCExamUseItem.class);
		msgs.put(MessageType.GC_EXAM_CHOSE, GCExamChose.class);
		msgs.put(MessageType.GC_EXAM_INFO, GCExamInfo.class);
		return msgs;
	}
}
