package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 查询账户余额
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerQueryAccount extends CGMessage{
	
	
	public CGPlayerQueryAccount (){
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
		return MessageType.CG_PLAYER_QUERY_ACCOUNT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLAYER_QUERY_ACCOUNT";
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handlePlayerQueryAccount(this.getSession().getPlayer(), this);
	}
}