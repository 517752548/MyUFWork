package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 宠物刷新天赋技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetRefreshTalentSkill extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetRefreshTalentSkill (){
	}
	
	public CGPetRefreshTalentSkill (
			long petId ){
			this.petId = petId;
	}
	
	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end



			this.petId = _petId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_REFRESH_TALENT_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_REFRESH_TALENT_SKILL";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetRefreshTalentSkill(this.getSession().getPlayer(), this);
	}
}