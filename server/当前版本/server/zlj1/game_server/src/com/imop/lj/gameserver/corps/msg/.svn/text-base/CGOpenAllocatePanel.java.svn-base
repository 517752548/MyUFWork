package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求打开活动奖励分配面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenAllocatePanel extends CGMessage{
	
	/** 活动类型,1-帮派竞赛 */
	private int activityType;
	
	public CGOpenAllocatePanel (){
	}
	
	public CGOpenAllocatePanel (
			int activityType ){
			this.activityType = activityType;
	}
	
	@Override
	protected boolean readImpl() {

	// 活动类型,1-帮派竞赛
	int _activityType = readInteger();
	//end



			this.activityType = _activityType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 活动类型,1-帮派竞赛
	writeInteger(activityType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_OPEN_ALLOCATE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OPEN_ALLOCATE_PANEL";
	}

	public int getActivityType(){
		return activityType;
	}
		
	public void setActivityType(int activityType){
		this.activityType = activityType;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleOpenAllocatePanel(this.getSession().getPlayer(), this);
	}
}