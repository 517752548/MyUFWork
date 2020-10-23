package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 师傅获取徒弟升级的奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddOvermanReward extends CGMessage{
	
	/** 奖励id */
	private int rewardId;
	/** 徒弟的id */
	private long lowermanCharId;
	
	public CGAddOvermanReward (){
	}
	
	public CGAddOvermanReward (
			int rewardId,
			long lowermanCharId ){
			this.rewardId = rewardId;
			this.lowermanCharId = lowermanCharId;
	}
	
	@Override
	protected boolean readImpl() {

	// 奖励id
	int _rewardId = readInteger();
	//end


	// 徒弟的id
	long _lowermanCharId = readLong();
	//end



			this.rewardId = _rewardId;
			this.lowermanCharId = _lowermanCharId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 奖励id
	writeInteger(rewardId);


	// 徒弟的id
	writeLong(lowermanCharId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ADD_OVERMAN_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ADD_OVERMAN_REWARD";
	}

	public int getRewardId(){
		return rewardId;
	}
		
	public void setRewardId(int rewardId){
		this.rewardId = rewardId;
	}

	public long getLowermanCharId(){
		return lowermanCharId;
	}
		
	public void setLowermanCharId(long lowermanCharId){
		this.lowermanCharId = lowermanCharId;
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleAddOvermanReward(this.getSession().getPlayer(), this);
	}
}