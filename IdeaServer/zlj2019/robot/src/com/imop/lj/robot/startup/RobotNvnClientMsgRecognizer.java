package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.nvn.msg.GCNvnMyInfo;
import com.imop.lj.gameserver.nvn.msg.GCNvnRankList;
import com.imop.lj.gameserver.nvn.msg.GCNvnMatchedTeamInfo;
import com.imop.lj.gameserver.nvn.msg.GCNvnMatchStatus;
import com.imop.lj.gameserver.nvn.msg.GCNvnLeave;
import com.imop.lj.gameserver.nvn.msg.GCNvnRule;

public class RobotNvnClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_NVN_MY_INFO, GCNvnMyInfo.class);
		msgs.put(MessageType.GC_NVN_RANK_LIST, GCNvnRankList.class);
		msgs.put(MessageType.GC_NVN_MATCHED_TEAM_INFO, GCNvnMatchedTeamInfo.class);
		msgs.put(MessageType.GC_NVN_MATCH_STATUS, GCNvnMatchStatus.class);
		msgs.put(MessageType.GC_NVN_LEAVE, GCNvnLeave.class);
		msgs.put(MessageType.GC_NVN_RULE, GCNvnRule.class);
		return msgs;
	}
}
