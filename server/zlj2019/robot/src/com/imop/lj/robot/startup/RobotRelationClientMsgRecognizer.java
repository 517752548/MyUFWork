package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.relation.msg.GCClickRelationPanel;
import com.imop.lj.gameserver.relation.msg.GCAddRelation;
import com.imop.lj.gameserver.relation.msg.GCDelRelation;
import com.imop.lj.gameserver.relation.msg.GCShowRecommendFriendList;

public class RobotRelationClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_CLICK_RELATION_PANEL, GCClickRelationPanel.class);
		msgs.put(MessageType.GC_ADD_RELATION, GCAddRelation.class);
		msgs.put(MessageType.GC_DEL_RELATION, GCDelRelation.class);
		msgs.put(MessageType.GC_SHOW_RECOMMEND_FRIEND_LIST, GCShowRecommendFriendList.class);
		return msgs;
	}
}
