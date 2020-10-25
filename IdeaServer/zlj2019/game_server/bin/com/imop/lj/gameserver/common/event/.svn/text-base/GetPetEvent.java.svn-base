package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;
import com.imop.lj.gameserver.pet.Pet;

public class GetPetEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 获得的武将 */
	private Pet pet;
	
	private final static EventType eventType = EventType.GetPet;

	public GetPetEvent(Human human, Pet pet) {
		super(human, eventType);
		this.human = human;
		this.pet = pet;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public Pet getPet() {
		return pet;
	}

}
