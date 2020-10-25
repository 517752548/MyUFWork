package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求回到帮派场景
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBackCorpsMap extends CGMessage{
	
	
	public CGBackCorpsMap (){
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
		return MessageType.CG_BACK_CORPS_MAP;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BACK_CORPS_MAP";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleBackCorpsMap(this.getSession().getPlayer(), this);
	}
}