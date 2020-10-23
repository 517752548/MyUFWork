package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.overman.msg.GCFirstOverman;
import com.imop.lj.gameserver.overman.msg.GCOvermanInfo;
import com.imop.lj.gameserver.overman.msg.GCOvermanHongdian;
import com.imop.lj.gameserver.overman.msg.GCFirstFireOverman;
import com.imop.lj.gameserver.overman.msg.GCFirstTeamFireOverman;
import com.imop.lj.gameserver.overman.msg.GCGetOvermanReward;
import com.imop.lj.gameserver.overman.msg.GCGetLowermanReward;

public class RobotOvermanClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_FIRST_OVERMAN, GCFirstOverman.class);
		msgs.put(MessageType.GC_OVERMAN_INFO, GCOvermanInfo.class);
		msgs.put(MessageType.GC_OVERMAN_HONGDIAN, GCOvermanHongdian.class);
		msgs.put(MessageType.GC_FIRST_FIRE_OVERMAN, GCFirstFireOverman.class);
		msgs.put(MessageType.GC_FIRST_TEAM_FIRE_OVERMAN, GCFirstTeamFireOverman.class);
		msgs.put(MessageType.GC_GET_OVERMAN_REWARD, GCGetOvermanReward.class);
		msgs.put(MessageType.GC_GET_LOWERMAN_REWARD, GCGetLowermanReward.class);
		return msgs;
	}
}
