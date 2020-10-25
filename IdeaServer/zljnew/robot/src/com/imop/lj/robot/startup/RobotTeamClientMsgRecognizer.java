package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.team.msg.GCTeamMyTeamMemberList;
import com.imop.lj.gameserver.team.msg.GCTeamMyTeamInfo;
import com.imop.lj.gameserver.team.msg.GCTeamApplyList;
import com.imop.lj.gameserver.team.msg.GCTeamShowList;
import com.imop.lj.gameserver.team.msg.GCTeamApply;
import com.imop.lj.gameserver.team.msg.GCTeamApplyAuto;
import com.imop.lj.gameserver.team.msg.GCTeamInviteList;
import com.imop.lj.gameserver.team.msg.GCTeamInvitePlayer;
import com.imop.lj.gameserver.team.msg.GCTeamInvitePlayerNotice;
import com.imop.lj.gameserver.team.msg.GCTeamQuit;
import com.imop.lj.gameserver.team.msg.GCTeamCallBackNotice;

public class RobotTeamClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_TEAM_MY_TEAM_MEMBER_LIST, GCTeamMyTeamMemberList.class);
		msgs.put(MessageType.GC_TEAM_MY_TEAM_INFO, GCTeamMyTeamInfo.class);
		msgs.put(MessageType.GC_TEAM_APPLY_LIST, GCTeamApplyList.class);
		msgs.put(MessageType.GC_TEAM_SHOW_LIST, GCTeamShowList.class);
		msgs.put(MessageType.GC_TEAM_APPLY, GCTeamApply.class);
		msgs.put(MessageType.GC_TEAM_APPLY_AUTO, GCTeamApplyAuto.class);
		msgs.put(MessageType.GC_TEAM_INVITE_LIST, GCTeamInviteList.class);
		msgs.put(MessageType.GC_TEAM_INVITE_PLAYER, GCTeamInvitePlayer.class);
		msgs.put(MessageType.GC_TEAM_INVITE_PLAYER_NOTICE, GCTeamInvitePlayerNotice.class);
		msgs.put(MessageType.GC_TEAM_QUIT, GCTeamQuit.class);
		msgs.put(MessageType.GC_TEAM_CALL_BACK_NOTICE, GCTeamCallBackNotice.class);
		return msgs;
	}
}
