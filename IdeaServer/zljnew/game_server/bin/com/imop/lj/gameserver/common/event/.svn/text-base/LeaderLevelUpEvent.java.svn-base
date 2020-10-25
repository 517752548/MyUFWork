package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class LeaderLevelUpEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 等级 */
	private int level;
	
	private final static EventType eventType = EventType.LeaderLevelUp;

	public LeaderLevelUpEvent(Human human, int level) {
		super(human, eventType);
		this.human = human;
		this.level = level;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public int getLevel() {
		return level;
	}

}
