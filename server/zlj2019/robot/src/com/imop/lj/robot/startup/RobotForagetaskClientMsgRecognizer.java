package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.foragetask.msg.GCOpenForagetaskPanel;
import com.imop.lj.gameserver.foragetask.msg.GCForagetaskDone;
import com.imop.lj.gameserver.foragetask.msg.GCForagetaskUpdate;

public class RobotForagetaskClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_OPEN_FORAGETASK_PANEL, GCOpenForagetaskPanel.class);
		msgs.put(MessageType.GC_FORAGETASK_DONE, GCForagetaskDone.class);
		msgs.put(MessageType.GC_FORAGETASK_UPDATE, GCForagetaskUpdate.class);
		return msgs;
	}
}
