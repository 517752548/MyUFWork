package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求个人帮派成员信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsMemberInfo extends CGMessage{
	
	
	public CGCorpsMemberInfo (){
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
		return MessageType.CG_CORPS_MEMBER_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPS_MEMBER_INFO";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCorpsMemberInfo(this.getSession().getPlayer(), this);
	}
}