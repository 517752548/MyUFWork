package com.imop.lj.gameserver.common.event;

import com.imop.lj.core.event.IEvent;
import com.imop.lj.gameserver.human.Human;

public class MainCityLevelUpEvent implements IEvent<Human>{

	/** 玩家角色 */
	private final Human human;

	/** 主城到达的级别 */
	private int level;

	public MainCityLevelUpEvent(Human human,int level)
	{
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
