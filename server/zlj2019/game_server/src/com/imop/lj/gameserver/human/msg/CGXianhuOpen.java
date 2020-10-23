package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 开启仙葫
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGXianhuOpen extends CGMessage{
	
	/** 开启类型，0祝福仙葫，1祈福仙葫 */
	private int openType;
	
	public CGXianhuOpen (){
	}
	
	public CGXianhuOpen (
			int openType ){
			this.openType = openType;
	}
	
	@Override
	protected boolean readImpl() {

	// 开启类型，0祝福仙葫，1祈福仙葫
	int _openType = readInteger();
	//end



			this.openType = _openType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 开启类型，0祝福仙葫，1祈福仙葫
	writeInteger(openType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_XIANHU_OPEN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_XIANHU_OPEN";
	}

	public int getOpenType(){
		return openType;
	}
		
	public void setOpenType(int openType){
		this.openType = openType;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleXianhuOpen(this.getSession().getPlayer(), this);
	}
}