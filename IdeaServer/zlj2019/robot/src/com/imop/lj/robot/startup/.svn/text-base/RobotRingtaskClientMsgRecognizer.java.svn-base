package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.ringtask.msg.GCOpenRingtaskPanel;
import com.imop.lj.gameserver.ringtask.msg.GCRingtaskDone;
import com.imop.lj.gameserver.ringtask.msg.GCRingtaskUpdate;

public class RobotRingtaskClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_OPEN_RINGTASK_PANEL, GCOpenRingtaskPanel.class);
		msgs.put(MessageType.GC_RINGTASK_DONE, GCRingtaskDone.class);
		msgs.put(MessageType.GC_RINGTASK_UPDATE, GCRingtaskUpdate.class);
		return msgs;
	}
}
