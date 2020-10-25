package com.imop.lj.gameserver.marry.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.marry.handler.MarryHandlerFactory;

/**
 * 离婚
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFireMarry extends CGMessage{
	
	/** 是否同意 1是同意 */
	private int canFire;
	
	public CGFireMarry (){
	}
	
	public CGFireMarry (
			int canFire ){
			this.canFire = canFire;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否同意 1是同意
	int _canFire = readInteger();
	//end



			this.canFire = _canFire;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否同意 1是同意
	writeInteger(canFire);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_FIRE_MARRY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FIRE_MARRY";
	}

	public int getCanFire(){
		return canFire;
	}
		
	public void setCanFire(int canFire){
		this.canFire = canFire;
	}


	@Override
	public void execute() {
		MarryHandlerFactory.getHandler().handleFireMarry(this.getSession().getPlayer(), this);
	}
}