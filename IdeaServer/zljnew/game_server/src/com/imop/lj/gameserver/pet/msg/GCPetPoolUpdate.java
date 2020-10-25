package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 武将池数值更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetPoolUpdate extends GCMessage{
	
	/** 当前血池 */
	private long hpPool;
	/** 当前蓝池 */
	private long mpPool;
	/** 当前寿命池 */
	private long lifePool;

	public GCPetPoolUpdate (){
	}
	
	public GCPetPoolUpdate (
			long hpPool,
			long mpPool,
			long lifePool ){
			this.hpPool = hpPool;
			this.mpPool = mpPool;
			this.lifePool = lifePool;
	}

	@Override
	protected boolean readImpl() {

	// 当前血池
	long _hpPool = readLong();
	//end


	// 当前蓝池
	long _mpPool = readLong();
	//end


	// 当前寿命池
	long _lifePool = readLong();
	//end



		this.hpPool = _hpPool;
		this.mpPool = _mpPool;
		this.lifePool = _lifePool;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 当前血池
	writeLong(hpPool);


	// 当前蓝池
	writeLong(mpPool);


	// 当前寿命池
	writeLong(lifePool);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_POOL_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_POOL_UPDATE";
	}

	public long getHpPool(){
		return hpPool;
	}
		
	public void setHpPool(long hpPool){
		this.hpPool = hpPool;
	}

	public long getMpPool(){
		return mpPool;
	}
		
	public void setMpPool(long mpPool){
		this.mpPool = mpPool;
	}

	public long getLifePool(){
		return lifePool;
	}
		
	public void setLifePool(long lifePool){
		this.lifePool = lifePool;
	}
}