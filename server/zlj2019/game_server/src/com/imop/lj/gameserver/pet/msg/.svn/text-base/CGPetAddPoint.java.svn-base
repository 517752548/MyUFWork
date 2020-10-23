package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 武将加点
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetAddPoint extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 加点数组，按照一级属性的顺序加 */
	private int[] addArr;
	
	public CGPetAddPoint (){
	}
	
	public CGPetAddPoint (
			long petId,
			int[] addArr ){
			this.petId = petId;
			this.addArr = addArr;
	}
	
	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 加点数组，按照一级属性的顺序加
	int addArrSize = readUnsignedShort();
	int[] _addArr = new int[addArrSize];
	int addArrIndex = 0;
	for(addArrIndex=0; addArrIndex<addArrSize; addArrIndex++){
		_addArr[addArrIndex] = readInteger();
	}//end



			this.petId = _petId;
			this.addArr = _addArr;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 加点数组，按照一级属性的顺序加
	writeShort(addArr.length);
	int addArrSize = addArr.length;
	int addArrIndex = 0;
	for(addArrIndex=0; addArrIndex<addArrSize; addArrIndex++){
		writeInteger(addArr [ addArrIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_ADD_POINT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_ADD_POINT";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int[] getAddArr(){
		return addArr;
	}

	public void setAddArr(int[] addArr){
		this.addArr = addArr;
	}	


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetAddPoint(this.getSession().getPlayer(), this);
	}
}