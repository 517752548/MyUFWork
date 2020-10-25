package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.prize.msg.GCPrizeList;
import com.imop.lj.gameserver.prize.msg.GCPrizeSuccess;
import com.imop.lj.gameserver.prize.msg.GCPrizeExist;
import com.imop.lj.gameserver.prize.msg.GCPrizeListTip;

public class RobotPrizeClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_PRIZE_LIST, GCPrizeList.class);
		msgs.put(MessageType.GC_PRIZE_SUCCESS, GCPrizeSuccess.class);
		msgs.put(MessageType.GC_PRIZE_EXIST, GCPrizeExist.class);
		msgs.put(MessageType.GC_PRIZE_LIST_TIP, GCPrizeListTip.class);
		return msgs;
	}
}
