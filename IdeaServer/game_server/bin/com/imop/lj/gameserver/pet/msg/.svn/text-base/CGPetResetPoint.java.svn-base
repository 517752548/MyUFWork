package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 武将洗点
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetResetPoint extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetResetPoint (){
	}
	
	public CGPetResetPoint (
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
		return MessageType.CG_PET_RESET_POINT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_RESET_POINT";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetResetPoint(this.getSession().getPlayer(), this);
	}
}