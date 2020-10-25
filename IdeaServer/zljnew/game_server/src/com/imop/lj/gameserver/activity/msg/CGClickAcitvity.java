package com.imop.lj.gameserver.activity.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.activity.handler.ActivityHandlerFactory;

/**
 * 点击活动
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickAcitvity extends CGMessage{
	
	/** 活动id */
	private int activityId;
	
	public CGClickAcitvity (){
	}
	
	public CGClickAcitvity (
			int activityId ){
			this.activityId = activityId;
	}
	
	@Override
	protected boolean readImpl() {

	// 活动id
	int _activityId = readInteger();
	//end



			this.activityId = _activityId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 活动id
	writeInteger(activityId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CLICK_ACITVITY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CLICK_ACITVITY";
	}

	public int getActivityId(){
		return activityId;
	}
		
	public void setActivityId(int activityId){
		this.activityId = activityId;
	}


	@Override
	public void execute() {
		ActivityHandlerFactory.getHandler().handleClickAcitvity(this.getSession().getPlayer(), this);
	}
}