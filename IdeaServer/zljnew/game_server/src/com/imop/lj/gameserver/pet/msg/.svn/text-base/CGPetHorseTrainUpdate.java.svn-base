package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 骑宠培养确认更新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseTrainUpdate extends CGMessage{
	
	/** 骑宠唯一Id */
	private long petId;
	
	public CGPetHorseTrainUpdate (){
	}
	
	public CGPetHorseTrainUpdate (
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
		return MessageType.CG_PET_HORSE_TRAIN_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_HORSE_TRAIN_UPDATE";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetHorseTrainUpdate(this.getSession().getPlayer(), this);
	}
}