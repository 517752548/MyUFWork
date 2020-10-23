package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.quest.msg.GCCommonQuestList;
import com.imop.lj.gameserver.quest.msg.GCQuestUpdate;
import com.imop.lj.gameserver.quest.msg.GCFinishQuest;
import com.imop.lj.gameserver.quest.msg.GCRemoveQuest;
import com.imop.lj.gameserver.quest.msg.GCAcceptQuest;

public class RobotQuestClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_COMMON_QUEST_LIST, GCCommonQuestList.class);
		msgs.put(MessageType.GC_QUEST_UPDATE, GCQuestUpdate.class);
		msgs.put(MessageType.GC_FINISH_QUEST, GCFinishQuest.class);
		msgs.put(MessageType.GC_REMOVE_QUEST, GCRemoveQuest.class);
		msgs.put(MessageType.GC_ACCEPT_QUEST, GCAcceptQuest.class);
		return msgs;
	}
}
