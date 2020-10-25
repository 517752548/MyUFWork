package com.imop.lj.gameserver.marry.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.marry.handler.MarryHandlerFactory;

/**
 * 结婚 ,2发出
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMarry extends CGMessage{
	
	/** 是否同意 1是同意 */
	private int canMarry;
	
	public CGMarry (){
	}
	
	public CGMarry (
			int canMarry ){
			this.canMarry = canMarry;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否同意 1是同意
	int _canMarry = readInteger();
	//end



			this.canMarry = _canMarry;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否同意 1是同意
	writeInteger(canMarry);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_MARRY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_MARRY";
	}

	public int getCanMarry(){
		return canMarry;
	}
		
	public void setCanMarry(int canMarry){
		this.canMarry = canMarry;
	}


	@Override
	public void execute() {
		MarryHandlerFactory.getHandler().handleMarry(this.getSession().getPlayer(), this);
	}
}