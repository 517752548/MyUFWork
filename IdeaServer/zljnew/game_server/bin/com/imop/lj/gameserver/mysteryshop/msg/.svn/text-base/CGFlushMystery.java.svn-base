package com.imop.lj.gameserver.mysteryshop.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mysteryshop.handler.MysteryshopHandlerFactory;

/**
 * 刷新神秘商店
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFlushMystery extends CGMessage{
	
	/** 刷新类型1：普通刷新2：Vip刷新 */
	private int flushType;
	
	public CGFlushMystery (){
	}
	
	public CGFlushMystery (
			int flushType ){
			this.flushType = flushType;
	}
	
	@Override
	protected boolean readImpl() {

	// 刷新类型1：普通刷新2：Vip刷新
	int _flushType = readInteger();
	//end



			this.flushType = _flushType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 刷新类型1：普通刷新2：Vip刷新
	writeInteger(flushType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_FLUSH_MYSTERY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FLUSH_MYSTERY";
	}

	public int getFlushType(){
		return flushType;
	}
		
	public void setFlushType(int flushType){
		this.flushType = flushType;
	}


	@Override
	public void execute() {
		MysteryshopHandlerFactory.getHandler().handleFlushMystery(this.getSession().getPlayer(), this);
	}
}