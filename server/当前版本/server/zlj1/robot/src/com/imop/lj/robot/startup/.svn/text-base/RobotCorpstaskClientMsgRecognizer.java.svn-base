package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.corpstask.msg.GCOpenCorpstaskPanel;
import com.imop.lj.gameserver.corpstask.msg.GCCorpstaskDone;
import com.imop.lj.gameserver.corpstask.msg.GCCorpstaskUpdate;

public class RobotCorpstaskClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_OPEN_CORPSTASK_PANEL, GCOpenCorpstaskPanel.class);
		msgs.put(MessageType.GC_CORPSTASK_DONE, GCCorpstaskDone.class);
		msgs.put(MessageType.GC_CORPSTASK_UPDATE, GCCorpstaskUpdate.class);
		return msgs;
	}
}
