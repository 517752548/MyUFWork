package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;
import com.imop.lj.gameserver.team.model.TeamMemberChangeInfo;

public class TeamMemberChangeEvent extends Event<TeamMemberChangeInfo>{

	private final static EventType eventType = EventType.TeamMemberChange;

	public TeamMemberChangeEvent(TeamMemberChangeInfo info) {
		super(info, eventType);
	}

}
