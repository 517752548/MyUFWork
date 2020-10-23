package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 打开军团成员列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenCorpsMemberList extends CGMessage{
	
	
	public CGOpenCorpsMemberList (){
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
		return MessageType.CG_OPEN_CORPS_MEMBER_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OPEN_CORPS_MEMBER_LIST";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleOpenCorpsMemberList(this.getSession().getPlayer(), this);
	}
}