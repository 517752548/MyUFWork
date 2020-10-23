package com.imop.lj.gameserver.goodactivity.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.goodactivity.handler.GoodactivityHandlerFactory;

/**
 * 领取活动奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGoodActivityGetBonus extends CGMessage{
	
	/** 活动id */
	private long activityId;
	/** 奖励id */
	private int bonusId;
	
	public CGGoodActivityGetBonus (){
	}
	
	public CGGoodActivityGetBonus (
			long activityId,
			int bonusId ){
			this.activityId = activityId;
			this.bonusId = bonusId;
	}
	
	@Override
	protected boolean readImpl() {

	// 活动id
	long _activityId = readLong();
	//end


	// 奖励id
	int _bonusId = readInteger();
	//end



			this.activityId = _activityId;
			this.bonusId = _bonusId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 活动id
	writeLong(activityId);


	// 奖励id
	writeInteger(bonusId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_GOOD_ACTIVITY_GET_BONUS;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GOOD_ACTIVITY_GET_BONUS";
	}

	public long getActivityId(){
		return activityId;
	}
		
	public void setActivityId(long activityId){
		this.activityId = activityId;
	}

	public int getBonusId(){
		return bonusId;
	}
		
	public void setBonusId(int bonusId){
		this.bonusId = bonusId;
	}


	@Override
	public void execute() {
		GoodactivityHandlerFactory.getHandler().handleGoodActivityGetBonus(this.getSession().getPlayer(), this);
	}
}