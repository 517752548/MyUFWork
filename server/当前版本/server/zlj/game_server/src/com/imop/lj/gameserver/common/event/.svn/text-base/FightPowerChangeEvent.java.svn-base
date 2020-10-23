package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class FightPowerChangeEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 之前战力 */
	private int old;
	/** 当前战力 */
	private int cur;
	
	private final static EventType eventType = EventType.FightPowerChange;

	public FightPowerChangeEvent(Human human, int old, int cur) {
		super(human, eventType);
		this.human = human;
		this.old = old;
		this.cur = cur;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public int getOld() {
		return old;
	}

	public int getCur() {
		return cur;
	}

}
