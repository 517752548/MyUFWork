package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class BattleEscapeEvent extends Event<Long>{

	/** 玩家角色Id */
	private final Long roleId;
	
	private final static EventType eventType = EventType.BattleEscape;

	public BattleEscapeEvent(Long roleId) {
		super(roleId, eventType);
		this.roleId = roleId;
	}

	@Override
	public Long getInfo() {
		return roleId;
	}

}
