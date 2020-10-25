package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 骑宠出战or休息结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseRide extends GCMessage{
	
	/** 骑宠唯一Id */
	private long petId;
	/** 出战状态，0休息，1出战 */
	private int state;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetHorseRide (){
	}
	
	public GCPetHorseRide (
			long petId,
			int state,
			int result ){
			this.petId = petId;
			this.state = state;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 骑宠唯一Id
	long _petId = readLong();
	//end


	// 出战状态，0休息，1出战
	int _state = readInteger();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.petId = _petId;
		this.state = _state;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 骑宠唯一Id
	writeLong(petId);


	// 出战状态，0休息，1出战
	writeInteger(state);


	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_HORSE_RIDE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_HORSE_RIDE";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getState(){
		return state;
	}
		
	public void setState(int state){
		this.state = state;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}