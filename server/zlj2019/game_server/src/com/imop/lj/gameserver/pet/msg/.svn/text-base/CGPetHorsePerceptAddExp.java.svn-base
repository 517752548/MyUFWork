package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 骑宠悟性提升
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorsePerceptAddExp extends CGMessage{
	
	/** 骑宠唯一Id */
	private long petId;
	/** 提升方式,1初级,2中级,3高级 */
	private int addType;
	/** 是否批量,1是,2否 */
	private int isBatch;
	
	public CGPetHorsePerceptAddExp (){
	}
	
	public CGPetHorsePerceptAddExp (
			long petId,
			int addType,
			int isBatch ){
			this.petId = petId;
			this.addType = addType;
			this.isBatch = isBatch;
	}
	
	@Override
	protected boolean readImpl() {

	// 骑宠唯一Id
	long _petId = readLong();
	//end


	// 提升方式,1初级,2中级,3高级
	int _addType = readInteger();
	//end


	// 是否批量,1是,2否
	int _isBatch = readInteger();
	//end



			this.petId = _petId;
			this.addType = _addType;
			this.isBatch = _isBatch;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 骑宠唯一Id
	writeLong(petId);


	// 提升方式,1初级,2中级,3高级
	writeInteger(addType);


	// 是否批量,1是,2否
	writeInteger(isBatch);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_HORSE_PERCEPT_ADD_EXP;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_HORSE_PERCEPT_ADD_EXP";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getAddType(){
		return addType;
	}
		
	public void setAddType(int addType){
		this.addType = addType;
	}

	public int getIsBatch(){
		return isBatch;
	}
		
	public void setIsBatch(int isBatch){
		this.isBatch = isBatch;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetHorsePerceptAddExp(this.getSession().getPlayer(), this);
	}
}