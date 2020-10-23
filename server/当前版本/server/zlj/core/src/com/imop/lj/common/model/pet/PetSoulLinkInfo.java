package com.imop.lj.common.model.pet;

/**
 * 宠物灵魂链接信息
 * 
 */
public class PetSoulLinkInfo {
	/** 宠物Id */
	private long petId;
	/** 灵魂链接骑宠ID, 0-无灵魂链接*/
	private long soulLinkPetHorseId;

	public long getPetId() {
		return petId;
	}

	public void setPetId(long petId) {
		this.petId = petId;
	}
	
	public long getSoulLinkPetHorseId() {
		return soulLinkPetHorseId;
	}

	public void setSoulLinkPetHorseId(long soulLinkPetHorseId) {
		this.soulLinkPetHorseId = soulLinkPetHorseId;
	}

	@Override
	public String toString() {
		return "PetHorseSoulLinkInfo [petId=" + petId + ", soulLinkPetHorseId=" + soulLinkPetHorseId + "]";
	}

}
