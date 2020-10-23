package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.map.msg.GCMapPlayerEnter;
import com.imop.lj.gameserver.map.msg.GCMapPlayerChangedList;
import com.imop.lj.gameserver.map.msg.GCMapPlayerSetPosition;
import com.imop.lj.gameserver.map.msg.GCMapAddNpc;
import com.imop.lj.gameserver.map.msg.GCMapAddNpcList;
import com.imop.lj.gameserver.map.msg.GCMapRemoveAddNpc;
import com.imop.lj.gameserver.map.msg.GCMapUpdateAddNpc;
import com.imop.lj.gameserver.map.msg.GCMapTeamLeaderPosition;

public class RobotMapClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_MAP_PLAYER_ENTER, GCMapPlayerEnter.class);
		msgs.put(MessageType.GC_MAP_PLAYER_CHANGED_LIST, GCMapPlayerChangedList.class);
		msgs.put(MessageType.GC_MAP_PLAYER_SET_POSITION, GCMapPlayerSetPosition.class);
		msgs.put(MessageType.GC_MAP_ADD_NPC, GCMapAddNpc.class);
		msgs.put(MessageType.GC_MAP_ADD_NPC_LIST, GCMapAddNpcList.class);
		msgs.put(MessageType.GC_MAP_REMOVE_ADD_NPC, GCMapRemoveAddNpc.class);
		msgs.put(MessageType.GC_MAP_UPDATE_ADD_NPC, GCMapUpdateAddNpc.class);
		msgs.put(MessageType.GC_MAP_TEAM_LEADER_POSITION, GCMapTeamLeaderPosition.class);
		return msgs;
	}
}
