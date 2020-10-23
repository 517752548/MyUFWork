package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 获取师傅在这个徒弟身上所有奖励的状态
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetOvermanReward extends CGMessage{
	
	/** 徒弟的charid */
	private long lowermanCharId;
	
	public CGGetOvermanReward (){
	}
	
	public CGGetOvermanReward (
			long lowermanCharId ){
			this.lowermanCharId = lowermanCharId;
	}
	
	@Override
	protected boolean readImpl() {

	// 徒弟的charid
	long _lowermanCharId = readLong();
	//end



			this.lowermanCharId = _lowermanCharId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 徒弟的charid
	writeLong(lowermanCharId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_GET_OVERMAN_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GET_OVERMAN_REWARD";
	}

	public long getLowermanCharId(){
		return lowermanCharId;
	}
		
	public void setLowermanCharId(long lowermanCharId){
		this.lowermanCharId = lowermanCharId;
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleGetOvermanReward(this.getSession().getPlayer(), this);
	}
}