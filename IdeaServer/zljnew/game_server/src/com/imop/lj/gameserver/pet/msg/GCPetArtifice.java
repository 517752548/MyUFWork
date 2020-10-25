package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 炼化结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetArtifice extends GCMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetArtifice (){
	}
	
	public GCPetArtifice (
			long petId,
			int result ){
			this.petId = petId;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.petId = _petId;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_ARTIFICE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_ARTIFICE";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}