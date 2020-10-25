package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.pubtask.msg.GCOpenPubtaskPanel;
import com.imop.lj.gameserver.pubtask.msg.GCPubtaskDone;
import com.imop.lj.gameserver.pubtask.msg.GCPubtaskUpdate;
import com.imop.lj.gameserver.pubtask.msg.GCPubtaskMaxStar;

public class RobotPubtaskClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_OPEN_PUBTASK_PANEL, GCOpenPubtaskPanel.class);
		msgs.put(MessageType.GC_PUBTASK_DONE, GCPubtaskDone.class);
		msgs.put(MessageType.GC_PUBTASK_UPDATE, GCPubtaskUpdate.class);
		msgs.put(MessageType.GC_PUBTASK_MAX_STAR, GCPubtaskMaxStar.class);
		return msgs;
	}
}
