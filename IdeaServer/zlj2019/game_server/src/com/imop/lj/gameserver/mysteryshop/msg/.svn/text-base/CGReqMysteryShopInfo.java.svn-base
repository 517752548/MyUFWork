package com.imop.lj.gameserver.mysteryshop.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mysteryshop.handler.MysteryshopHandlerFactory;

/**
 * 请求神秘商店信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGReqMysteryShopInfo extends CGMessage{
	
	
	public CGReqMysteryShopInfo (){
	}
	
	
	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_REQ_MYSTERY_SHOP_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_REQ_MYSTERY_SHOP_INFO";
	}


	@Override
	public void execute() {
		MysteryshopHandlerFactory.getHandler().handleReqMysteryShopInfo(this.getSession().getPlayer(), this);
	}
}