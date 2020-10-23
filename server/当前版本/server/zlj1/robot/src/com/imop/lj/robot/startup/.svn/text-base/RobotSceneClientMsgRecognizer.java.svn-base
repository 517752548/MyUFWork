package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerList;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerRemoveList;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerAddedList;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerChangedList;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerMovedList;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerForceToCityScene;

public class RobotSceneClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_SCENE_PLAYER_LIST, GCScenePlayerList.class);
		msgs.put(MessageType.GC_SCENE_PLAYER_REMOVE_LIST, GCScenePlayerRemoveList.class);
		msgs.put(MessageType.GC_SCENE_PLAYER_ADDED_LIST, GCScenePlayerAddedList.class);
		msgs.put(MessageType.GC_SCENE_PLAYER_CHANGED_LIST, GCScenePlayerChangedList.class);
		msgs.put(MessageType.GC_SCENE_PLAYER_MOVED_LIST, GCScenePlayerMovedList.class);
		msgs.put(MessageType.GC_SCENE_PLAYER_FORCE_TO_CITY_SCENE, GCScenePlayerForceToCityScene.class);
		return msgs;
	}
}
