package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.lifeskill.handler.LifeskillHandlerFactory;

/**
 * 申请开始采矿
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLsMineStart extends CGMessage{
	
	/** 矿点ID */
	private int pitId;
	/** 矿石ID */
	private int mineId;
	/** 采矿方式ID */
	private int miningTypeId;
	/** 矿工UUID */
	private long minerId;
	
	public CGLsMineStart (){
	}
	
	public CGLsMineStart (
			int pitId,
			int mineId,
			int miningTypeId,
			long minerId ){
			this.pitId = pitId;
			this.mineId = mineId;
			this.miningTypeId = miningTypeId;
			this.minerId = minerId;
	}
	
	@Override
	protected boolean readImpl() {

	// 矿点ID
	int _pitId = readInteger();
	//end


	// 矿石ID
	int _mineId = readInteger();
	//end


	// 采矿方式ID
	int _miningTypeId = readInteger();
	//end


	// 矿工UUID
	long _minerId = readLong();
	//end



			this.pitId = _pitId;
			this.mineId = _mineId;
			this.miningTypeId = _miningTypeId;
			this.minerId = _minerId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 矿点ID
	writeInteger(pitId);


	// 矿石ID
	writeInteger(mineId);


	// 采矿方式ID
	writeInteger(miningTypeId);


	// 矿工UUID
	writeLong(minerId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_LS_MINE_START;
	}
	
	@Override
	public String getTypeName() {
		return "CG_LS_MINE_START";
	}

	public int getPitId(){
		return pitId;
	}
		
	public void setPitId(int pitId){
		this.pitId = pitId;
	}

	public int getMineId(){
		return mineId;
	}
		
	public void setMineId(int mineId){
		this.mineId = mineId;
	}

	public int getMiningTypeId(){
		return miningTypeId;
	}
		
	public void setMiningTypeId(int miningTypeId){
		this.miningTypeId = miningTypeId;
	}

	public long getMinerId(){
		return minerId;
	}
		
	public void setMinerId(long minerId){
		this.minerId = minerId;
	}


	@Override
	public void execute() {
		LifeskillHandlerFactory.getHandler().handleLsMineStart(this.getSession().getPlayer(), this);
	}
}