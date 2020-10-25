package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 骑宠洗炼
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseAffination extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetHorseAffination (){
	}
	
	public CGPetHorseAffination (
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
		return MessageType.CG_PET_HORSE_AFFINATION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_HORSE_AFFINATION";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetHorseAffination(this.getSession().getPlayer(), this);
	}
}