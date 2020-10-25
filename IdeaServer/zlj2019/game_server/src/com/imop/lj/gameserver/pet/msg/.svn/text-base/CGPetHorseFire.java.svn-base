package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 骑宠放生
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseFire extends CGMessage{
	
	/** 骑宠唯一Id */
	private long petId;
	
	public CGPetHorseFire (){
	}
	
	public CGPetHorseFire (
			long petId ){
			this.petId = petId;
	}
	
	@Override
	protected boolean readImpl() {

	// 骑宠唯一Id
	long _petId = readLong();
	//end



			this.petId = _petId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 骑宠唯一Id
	writeLong(petId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_HORSE_FIRE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_HORSE_FIRE";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetHorseFire(this.getSession().getPlayer(), this);
	}
}