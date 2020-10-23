package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.activityui.msg.GCActivityUiInfo;
import com.imop.lj.gameserver.activityui.msg.GCAcitvityUiRewardInfo;

public class RobotActivityuiClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_ACTIVITY_UI_INFO, GCActivityUiInfo.class);
		msgs.put(MessageType.GC_ACITVITY_UI_REWARD_INFO, GCAcitvityUiRewardInfo.class);
		return msgs;
	}
}
