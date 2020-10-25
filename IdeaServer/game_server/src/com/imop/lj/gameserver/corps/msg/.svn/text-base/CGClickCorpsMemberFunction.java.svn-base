package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 点击军团成员相关功能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickCorpsMemberFunction extends CGMessage{
	
	/** 军团成员ID */
	private long corpsMemberId;
	/** 功能ID */
	private int funcId;
	
	public CGClickCorpsMemberFunction (){
	}
	
	public CGClickCorpsMemberFunction (
			long corpsMemberId,
			int funcId ){
			this.corpsMemberId = corpsMemberId;
			this.funcId = funcId;
	}
	
	@Override
	protected boolean readImpl() {

	// 军团成员ID
	long _corpsMemberId = readLong();
	//end


	// 功能ID
	int _funcId = readInteger();
	//end



			this.corpsMemberId = _corpsMemberId;
			this.funcId = _funcId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 军团成员ID
	writeLong(corpsMemberId);


	// 功能ID
	writeInteger(funcId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CLICK_CORPS_MEMBER_FUNCTION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CLICK_CORPS_MEMBER_FUNCTION";
	}

	public long getCorpsMemberId(){
		return corpsMemberId;
	}
		
	public void setCorpsMemberId(long corpsMemberId){
		this.corpsMemberId = corpsMemberId;
	}

	public int getFuncId(){
		return funcId;
	}
		
	public void setFuncId(int funcId){
		this.funcId = funcId;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleClickCorpsMemberFunction(this.getSession().getPlayer(), this);
	}
}