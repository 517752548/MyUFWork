package com.imop.lj.gameserver.mall.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mall.handler.MallHandlerFactory;

/**
 * 根据标签ID获取物品列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGItemListByCatalogid extends CGMessage{
	
	/** 标签ID */
	private int catalogId;
	
	public CGItemListByCatalogid (){
	}
	
	public CGItemListByCatalogid (
			int catalogId ){
			this.catalogId = catalogId;
	}
	
	@Override
	protected boolean readImpl() {

	// 标签ID
	int _catalogId = readInteger();
	//end



			this.catalogId = _catalogId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 标签ID
	writeInteger(catalogId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ITEM_LIST_BY_CATALOGID;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ITEM_LIST_BY_CATALOGID";
	}

	public int getCatalogId(){
		return catalogId;
	}
		
	public void setCatalogId(int catalogId){
		this.catalogId = catalogId;
	}


	@Override
	public void execute() {
		MallHandlerFactory.getHandler().handleItemListByCatalogid(this.getSession().getPlayer(), this);
	}
}