package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 领取富贵至尊仙葫
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGXianhuGive extends CGMessage{
	
	/** 领取类型，0富贵仙葫，1至尊仙葫 */
	private int giveType;
	
	public CGXianhuGive (){
	}
	
	public CGXianhuGive (
			int giveType ){
			this.giveType = giveType;
	}
	
	@Override
	protected boolean readImpl() {

	// 领取类型，0富贵仙葫，1至尊仙葫
	int _giveType = readInteger();
	//end



			this.giveType = _giveType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 领取类型，0富贵仙葫，1至尊仙葫
	writeInteger(giveType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_XIANHU_GIVE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_XIANHU_GIVE";
	}

	public int getGiveType(){
		return giveType;
	}
		
	public void setGiveType(int giveType){
		this.giveType = giveType;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleXianhuGive(this.getSession().getPlayer(), this);
	}
}