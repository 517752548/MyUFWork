package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class GetSkillEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 技能Id */
	private int skillId;
	
	private final static EventType eventType = EventType.GetSkill;

	public GetSkillEvent(Human human, int skillId) {
		super(human, eventType);
		this.human = human;
		this.skillId = skillId;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public int getSkillId() {
		return skillId;
	}

}
