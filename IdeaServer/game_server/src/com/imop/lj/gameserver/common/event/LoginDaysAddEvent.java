package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class LoginDaysAddEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	
	private final static EventType eventType = EventType.LoginDaysAdd;

	public LoginDaysAddEvent(Human human) {
		super(human, eventType);
		this.human = human;
	}

	@Override
	public Human getInfo() {
		return human;
	}

}
