package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.thesweeneytask.msg.GCOpenThesweeneytaskPanel;
import com.imop.lj.gameserver.thesweeneytask.msg.GCThesweeneytaskDone;
import com.imop.lj.gameserver.thesweeneytask.msg.GCThesweeneytaskUpdate;

public class RobotThesweeneytaskClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_OPEN_THESWEENEYTASK_PANEL, GCOpenThesweeneytaskPanel.class);
		msgs.put(MessageType.GC_THESWEENEYTASK_DONE, GCThesweeneytaskDone.class);
		msgs.put(MessageType.GC_THESWEENEYTASK_UPDATE, GCThesweeneytaskUpdate.class);
		return msgs;
	}
}
