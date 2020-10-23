package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 出师
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFireOverman extends CGMessage{
	
	/** 是否同意 1是同意 徒弟发 */
	private int canOverman;
	
	public CGFireOverman (){
	}
	
	public CGFireOverman (
			int canOverman ){
			this.canOverman = canOverman;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否同意 1是同意 徒弟发
	int _canOverman = readInteger();
	//end



			this.canOverman = _canOverman;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否同意 1是同意 徒弟发
	writeInteger(canOverman);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_FIRE_OVERMAN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FIRE_OVERMAN";
	}

	public int getCanOverman(){
		return canOverman;
	}
		
	public void setCanOverman(int canOverman){
		this.canOverman = canOverman;
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleFireOverman(this.getSession().getPlayer(), this);
	}
}