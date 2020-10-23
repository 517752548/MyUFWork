package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 骑宠loy,clo当前值更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseCurPropUpdate extends GCMessage{
	
	/** 骑宠唯一Id */
	private long petId;
	/** 当前忠诚度 */
	private int loy;
	/** 当前亲密度 */
	private int clo;

	public GCPetHorseCurPropUpdate (){
	}
	
	public GCPetHorseCurPropUpdate (
			long petId,
			int loy,
			int clo ){
			this.petId = petId;
			this.loy = loy;
			this.clo = clo;
	}

	@Override
	protected boolean readImpl() {

	// 骑宠唯一Id
	long _petId = readLong();
	//end


	// 当前忠诚度
	int _loy = readInteger();
	//end


	// 当前亲密度
	int _clo = readInteger();
	//end



		this.petId = _petId;
		this.loy = _loy;
		this.clo = _clo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 骑宠唯一Id
	writeLong(petId);


	// 当前忠诚度
	writeInteger(loy);


	// 当前亲密度
	writeInteger(clo);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_HORSE_CUR_PROP_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_HORSE_CUR_PROP_UPDATE";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getLoy(){
		return loy;
	}
		
	public void setLoy(int loy){
		this.loy = loy;
	}

	public int getClo(){
		return clo;
	}
		
	public void setClo(int clo){
		this.clo = clo;
	}
}