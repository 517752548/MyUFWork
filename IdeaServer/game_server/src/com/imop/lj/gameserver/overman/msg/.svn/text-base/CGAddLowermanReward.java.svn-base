package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 徒弟获取升级的奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddLowermanReward extends CGMessage{
	
	/** 奖励id */
	private int rewardId;
	
	public CGAddLowermanReward (){
	}
	
	public CGAddLowermanReward (
			int rewardId ){
			this.rewardId = rewardId;
	}
	
	@Override
	protected boolean readImpl() {

	// 奖励id
	int _rewardId = readInteger();
	//end



			this.rewardId = _rewardId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 奖励id
	writeInteger(rewardId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ADD_LOWERMAN_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ADD_LOWERMAN_REWARD";
	}

	public int getRewardId(){
		return rewardId;
	}
		
	public void setRewardId(int rewardId){
		this.rewardId = rewardId;
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleAddLowermanReward(this.getSession().getPlayer(), this);
	}
}