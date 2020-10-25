package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 点击军团相关功能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickCorpsFunction extends CGMessage{
	
	/** 军团ID */
	private long corpsId;
	/** 功能ID */
	private int funcId;
	
	public CGClickCorpsFunction (){
	}
	
	public CGClickCorpsFunction (
			long corpsId,
			int funcId ){
			this.corpsId = corpsId;
			this.funcId = funcId;
	}
	
	@Override
	protected boolean readImpl() {

	// 军团ID
	long _corpsId = readLong();
	//end


	// 功能ID
	int _funcId = readInteger();
	//end



			this.corpsId = _corpsId;
			this.funcId = _funcId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 军团ID
	writeLong(corpsId);


	// 功能ID
	writeInteger(funcId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CLICK_CORPS_FUNCTION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CLICK_CORPS_FUNCTION";
	}

	public long getCorpsId(){
		return corpsId;
	}
		
	public void setCorpsId(long corpsId){
		this.corpsId = corpsId;
	}

	public int getFuncId(){
		return funcId;
	}
		
	public void setFuncId(int funcId){
		this.funcId = funcId;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleClickCorpsFunction(this.getSession().getPlayer(), this);
	}
}