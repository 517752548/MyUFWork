package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class PlayerFinishQuestEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 任务Id */
	private int questId;
	
	private final static EventType eventType = EventType.PlayerFinishQuest;

	public PlayerFinishQuestEvent(Human human, int questId) {
		super(human, eventType);
		this.human = human;
		this.questId = questId;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public int getQuestId() {
		return questId;
	}

	public void setQuestId(int questId) {
		this.questId = questId;
	}

	
}
