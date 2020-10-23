package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 武将加点结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetAddPoint extends GCMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 操作结果，1成功，2失败 */
	private int result;
	/** 一级属性附加值 */
	private int[] aPropAddArr;

	public GCPetAddPoint (){
	}
	
	public GCPetAddPoint (
			long petId,
			int result,
			int[] aPropAddArr ){
			this.petId = petId;
			this.result = result;
			this.aPropAddArr = aPropAddArr;
	}

	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end


	// 一级属性附加值
	int aPropAddArrSize = readUnsignedShort();
	int[] _aPropAddArr = new int[aPropAddArrSize];
	int aPropAddArrIndex = 0;
	for(aPropAddArrIndex=0; aPropAddArrIndex<aPropAddArrSize; aPropAddArrIndex++){
		_aPropAddArr[aPropAddArrIndex] = readInteger();
	}//end



		this.petId = _petId;
		this.result = _result;
		this.aPropAddArr = _aPropAddArr;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 操作结果，1成功，2失败
	writeInteger(result);


	// 一级属性附加值
	writeShort(aPropAddArr.length);
	int aPropAddArrSize = aPropAddArr.length;
	int aPropAddArrIndex = 0;
	for(aPropAddArrIndex=0; aPropAddArrIndex<aPropAddArrSize; aPropAddArrIndex++){
		writeInteger(aPropAddArr [ aPropAddArrIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_ADD_POINT;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_ADD_POINT";
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

	public int[] getAPropAddArr(){
		return aPropAddArr;
	}

	public void setAPropAddArr(int[] aPropAddArr){
		this.aPropAddArr = aPropAddArr;
	}	
}