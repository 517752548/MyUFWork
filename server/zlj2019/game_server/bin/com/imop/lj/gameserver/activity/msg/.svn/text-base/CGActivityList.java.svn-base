package com.imop.lj.gameserver.activity.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.activity.handler.ActivityHandlerFactory;

/**
 * 打开活动面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGActivityList extends CGMessage{
	
	
	public CGActivityList (){
	}
	
	
	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ACTIVITY_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ACTIVITY_LIST";
	}


	@Override
	public void execute() {
		ActivityHandlerFactory.getHandler().handleActivityList(this.getSession().getPlayer(), this);
	}
}