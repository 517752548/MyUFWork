package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 武将增加经验，目前只有主将才发
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetAddExp extends GCMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 增加的经验 */
	private long addExp;

	public GCPetAddExp (){
	}
	
	public GCPetAddExp (
			long petId,
			long addExp ){
			this.petId = petId;
			this.addExp = addExp;
	}

	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 增加的经验
	long _addExp = readLong();
	//end



		this.petId = _petId;
		this.addExp = _addExp;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 增加的经验
	writeLong(addExp);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_ADD_EXP;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_ADD_EXP";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public long getAddExp(){
		return addExp;
	}
		
	public void setAddExp(long addExp){
		this.addExp = addExp;
	}
}