package com.imop.lj.gameserver.mysteryshop.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mysteryshop.handler.MysteryshopHandlerFactory;

/**
 * 购买神秘商店物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyMsItem extends CGMessage{
	
	/** 神秘商店物品ID */
	private int msItemId;
	
	public CGBuyMsItem (){
	}
	
	public CGBuyMsItem (
			int msItemId ){
			this.msItemId = msItemId;
	}
	
	@Override
	protected boolean readImpl() {

	// 神秘商店物品ID
	int _msItemId = readInteger();
	//end



			this.msItemId = _msItemId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 神秘商店物品ID
	writeInteger(msItemId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_BUY_MS_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BUY_MS_ITEM";
	}

	public int getMsItemId(){
		return msItemId;
	}
		
	public void setMsItemId(int msItemId){
		this.msItemId = msItemId;
	}


	@Override
	public void execute() {
		MysteryshopHandlerFactory.getHandler().handleBuyMsItem(this.getSession().getPlayer(), this);
	}
}