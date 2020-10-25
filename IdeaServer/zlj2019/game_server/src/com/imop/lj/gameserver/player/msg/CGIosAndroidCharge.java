package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * IOS和android直冲查询
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGIosAndroidCharge extends CGMessage{
	
	
	public CGIosAndroidCharge (){
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
		return MessageType.CG_IOS_ANDROID_CHARGE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_IOS_ANDROID_CHARGE";
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleIosAndroidCharge(this.getSession().getPlayer(), this);
	}
}