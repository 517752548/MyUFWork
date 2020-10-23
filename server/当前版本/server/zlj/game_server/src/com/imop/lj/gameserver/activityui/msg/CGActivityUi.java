package com.imop.lj.gameserver.activityui.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.activityui.handler.ActivityuiHandlerFactory;

/**
 * 打开活动UI面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGActivityUi extends CGMessage{
	
	
	public CGActivityUi (){
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
		return MessageType.CG_ACTIVITY_UI;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ACTIVITY_UI";
	}


	@Override
	public void execute() {
		ActivityuiHandlerFactory.getHandler().handleActivityUi(this.getSession().getPlayer(), this);
	}
}