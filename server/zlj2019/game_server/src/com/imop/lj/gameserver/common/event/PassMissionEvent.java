package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class PassMissionEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 关卡Id */
	private int missionId;
	
	private final static EventType eventType = EventType.PassMission;

	public PassMissionEvent(Human human, int missionId) {
		super(human, eventType);
		this.human = human;
		this.missionId = missionId;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public int getMissionId() {
		return missionId;
	}

}
