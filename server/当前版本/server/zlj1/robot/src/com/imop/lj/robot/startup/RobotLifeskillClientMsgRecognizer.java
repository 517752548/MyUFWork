package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.lifeskill.msg.GCLsMineGetPannel;
import com.imop.lj.gameserver.lifeskill.msg.GCLsMineStart;
import com.imop.lj.gameserver.lifeskill.msg.GCLsMineGain;

public class RobotLifeskillClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_LS_MINE_GET_PANNEL, GCLsMineGetPannel.class);
		msgs.put(MessageType.GC_LS_MINE_START, GCLsMineStart.class);
		msgs.put(MessageType.GC_LS_MINE_GAIN, GCLsMineGain.class);
		return msgs;
	}
}
