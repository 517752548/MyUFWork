package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 变异
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetVariation extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 是否批量，0否，1是 */
	private int isBatch;
	
	public CGPetVariation (){
	}
	
	public CGPetVariation (
			long petId,
			int isBatch ){
			this.petId = petId;
			this.isBatch = isBatch;
	}
	
	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 是否批量，0否，1是
	int _isBatch = readInteger();
	//end



			this.petId = _petId;
			this.isBatch = _isBatch;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 是否批量，0否，1是
	writeInteger(isBatch);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_VARIATION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_VARIATION";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getIsBatch(){
		return isBatch;
	}
		
	public void setIsBatch(int isBatch){
		this.isBatch = isBatch;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetVariation(this.getSession().getPlayer(), this);
	}
}