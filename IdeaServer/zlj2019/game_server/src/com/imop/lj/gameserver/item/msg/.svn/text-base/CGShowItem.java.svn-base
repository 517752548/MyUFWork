package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.item.handler.ItemHandlerFactory;

/**
 * 按uuid查看道具，聊天中使用
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGShowItem extends CGMessage{
	
	/** 道具唯一Id */
	private String itemUUID;
	
	public CGShowItem (){
	}
	
	public CGShowItem (
			String itemUUID ){
			this.itemUUID = itemUUID;
	}
	
	@Override
	protected boolean readImpl() {

	// 道具唯一Id
	String _itemUUID = readString();
	//end



			this.itemUUID = _itemUUID;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 道具唯一Id
	writeString(itemUUID);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SHOW_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SHOW_ITEM";
	}

	public String getItemUUID(){
		return itemUUID;
	}
		
	public void setItemUUID(String itemUUID){
		this.itemUUID = itemUUID;
	}


	@Override
	public void execute() {
		ItemHandlerFactory.getHandler().handleShowItem(this.getSession().getPlayer(), this);
	}
}