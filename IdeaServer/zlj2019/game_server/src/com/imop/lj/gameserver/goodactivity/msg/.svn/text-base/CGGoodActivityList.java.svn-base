package com.imop.lj.gameserver.goodactivity.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.goodactivity.handler.GoodactivityHandlerFactory;

/**
 * 打开精彩活动面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGoodActivityList extends CGMessage{
	
	/** 功能id */
	private int funcId;
	
	public CGGoodActivityList (){
	}
	
	public CGGoodActivityList (
			int funcId ){
			this.funcId = funcId;
	}
	
	@Override
	protected boolean readImpl() {

	// 功能id
	int _funcId = readInteger();
	//end



			this.funcId = _funcId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 功能id
	writeInteger(funcId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_GOOD_ACTIVITY_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GOOD_ACTIVITY_LIST";
	}

	public int getFuncId(){
		return funcId;
	}
		
	public void setFuncId(int funcId){
		this.funcId = funcId;
	}


	@Override
	public void execute() {
		GoodactivityHandlerFactory.getHandler().handleGoodActivityList(this.getSession().getPlayer(), this);
	}
}