package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 变异结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetVariation extends GCMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 是否批量，0否，1是 */
	private int isBatch;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetVariation (){
	}
	
	public GCPetVariation (
			long petId,
			int isBatch,
			int result ){
			this.petId = petId;
			this.isBatch = isBatch;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 是否批量，0否，1是
	int _isBatch = readInteger();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.petId = _petId;
		this.isBatch = _isBatch;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 是否批量，0否，1是
	writeInteger(isBatch);


	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_VARIATION;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_VARIATION";
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

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}