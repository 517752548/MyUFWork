package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class LandlordGetExpEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 增加的经验 */
	private long addExp;
	
	private final static EventType eventType = EventType.LandlordGetExp;

	public LandlordGetExpEvent(Human human, long addExp) {
		super(human, eventType);
		this.human = human;
		this.addExp = addExp;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public long getAddExp() {
		return addExp;
	}

}
