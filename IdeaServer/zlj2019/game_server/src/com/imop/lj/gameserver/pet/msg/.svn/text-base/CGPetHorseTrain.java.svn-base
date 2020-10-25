package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 骑宠培养
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseTrain extends CGMessage{
	
	/** 骑宠唯一Id */
	private long petId;
	/** 1初级2中级3高级 */
	private int trainTypeId;
	
	public CGPetHorseTrain (){
	}
	
	public CGPetHorseTrain (
			long petId,
			int trainTypeId ){
			this.petId = petId;
			this.trainTypeId = trainTypeId;
	}
	
	@Override
	protected boolean readImpl() {

	// 骑宠唯一Id
	long _petId = readLong();
	//end


	// 1初级2中级3高级
	int _trainTypeId = readInteger();
	//end



			this.petId = _petId;
			this.trainTypeId = _trainTypeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 骑宠唯一Id
	writeLong(petId);


	// 1初级2中级3高级
	writeInteger(trainTypeId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_HORSE_TRAIN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_HORSE_TRAIN";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getTrainTypeId(){
		return trainTypeId;
	}
		
	public void setTrainTypeId(int trainTypeId){
		this.trainTypeId = trainTypeId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetHorseTrain(this.getSession().getPlayer(), this);
	}
}