package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 骑宠培养确认更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseTrainUpdate extends GCMessage{
	
	/** 骑宠唯一Id */
	private long petId;
	/** 1成功,2失败 */
	private int result;

	public GCPetHorseTrainUpdate (){
	}
	
	public GCPetHorseTrainUpdate (
			long petId,
			int result ){
			this.petId = petId;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 骑宠唯一Id
	long _petId = readLong();
	//end


	// 1成功,2失败
	int _result = readInteger();
	//end



		this.petId = _petId;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 骑宠唯一Id
	writeLong(petId);


	// 1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_HORSE_TRAIN_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_HORSE_TRAIN_UPDATE";
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