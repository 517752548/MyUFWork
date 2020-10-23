package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 申请拜师 ,徒弟发出
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOverman extends CGMessage{
	
	/** 是否同意 1是同意 */
	private int canOverman;
	
	public CGOverman (){
	}
	
	public CGOverman (
			int canOverman ){
			this.canOverman = canOverman;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否同意 1是同意
	int _canOverman = readInteger();
	//end



			this.canOverman = _canOverman;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否同意 1是同意
	writeInteger(canOverman);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_OVERMAN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OVERMAN";
	}

	public int getCanOverman(){
		return canOverman;
	}
		
	public void setCanOverman(int canOverman){
		this.canOverman = canOverman;
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleOverman(this.getSession().getPlayer(), this);
	}
}