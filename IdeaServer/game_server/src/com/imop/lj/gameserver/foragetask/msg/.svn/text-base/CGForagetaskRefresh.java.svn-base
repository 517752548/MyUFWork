package com.imop.lj.gameserver.foragetask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.foragetask.handler.ForagetaskHandlerFactory;

/**
 * 护送粮草任务手动刷新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGForagetaskRefresh extends CGMessage{
	
	
	public CGForagetaskRefresh (){
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
		return MessageType.CG_FORAGETASK_REFRESH;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FORAGETASK_REFRESH";
	}


	@Override
	public void execute() {
		ForagetaskHandlerFactory.getHandler().handleForagetaskRefresh(this.getSession().getPlayer(), this);
	}
}