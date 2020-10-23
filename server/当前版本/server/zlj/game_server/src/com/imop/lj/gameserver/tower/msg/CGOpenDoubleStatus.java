package com.imop.lj.gameserver.tower.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.tower.handler.TowerHandlerFactory;

/**
 * 请求开启双倍状态
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenDoubleStatus extends CGMessage{
	
	/** 1开启，0关闭 */
	private int openOrClose;
	
	public CGOpenDoubleStatus (){
	}
	
	public CGOpenDoubleStatus (
			int openOrClose ){
			this.openOrClose = openOrClose;
	}
	
	@Override
	protected boolean readImpl() {

	// 1开启，0关闭
	int _openOrClose = readInteger();
	//end



			this.openOrClose = _openOrClose;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1开启，0关闭
	writeInteger(openOrClose);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_OPEN_DOUBLE_STATUS;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OPEN_DOUBLE_STATUS";
	}

	public int getOpenOrClose(){
		return openOrClose;
	}
		
	public void setOpenOrClose(int openOrClose){
		this.openOrClose = openOrClose;
	}


	@Override
	public void execute() {
		TowerHandlerFactory.getHandler().handleOpenDoubleStatus(this.getSession().getPlayer(), this);
	}
}