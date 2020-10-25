package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.item.handler.ItemHandlerFactory;

/**
 * 卖出道具
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSellItem extends CGMessage{
	
	/** 背包ID */
	private int bagId;
	/** 卖出道具信息 */
	private com.imop.lj.common.model.item.SellItemInfo[] sellItems;
	
	public CGSellItem (){
	}
	
	public CGSellItem (
			int bagId,
			com.imop.lj.common.model.item.SellItemInfo[] sellItems ){
			this.bagId = bagId;
			this.sellItems = sellItems;
	}
	
	@Override
	protected boolean readImpl() {

	// 背包ID
	int _bagId = readInteger();
	//end


	// 卖出道具信息
	int sellItemsSize = readUnsignedShort();
	com.imop.lj.common.model.item.SellItemInfo[] _sellItems = new com.imop.lj.common.model.item.SellItemInfo[sellItemsSize];
	int sellItemsIndex = 0;
	for(sellItemsIndex=0; sellItemsIndex<sellItemsSize; sellItemsIndex++){
		_sellItems[sellItemsIndex] = new com.imop.lj.common.model.item.SellItemInfo();
	// 背包内位置索引
	int _sellItems_index = readInteger();
	//end
	_sellItems[sellItemsIndex].setIndex (_sellItems_index);

	// 卖出道具的数量
	int _sellItems_count = readInteger();
	//end
	_sellItems[sellItemsIndex].setCount (_sellItems_count);
	}
	//end



			this.bagId = _bagId;
			this.sellItems = _sellItems;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 背包ID
	writeInteger(bagId);


	// 卖出道具信息
	writeShort(sellItems.length);
	int sellItemsIndex = 0;
	int sellItemsSize = sellItems.length;
	for(sellItemsIndex=0; sellItemsIndex<sellItemsSize; sellItemsIndex++){

	int sellItems_index = sellItems[sellItemsIndex].getIndex();

	// 背包内位置索引
	writeInteger(sellItems_index);

	int sellItems_count = sellItems[sellItemsIndex].getCount();

	// 卖出道具的数量
	writeInteger(sellItems_count);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SELL_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SELL_ITEM";
	}

	public int getBagId(){
		return bagId;
	}
		
	public void setBagId(int bagId){
		this.bagId = bagId;
	}

	public com.imop.lj.common.model.item.SellItemInfo[] getSellItems(){
		return sellItems;
	}

	public void setSellItems(com.imop.lj.common.model.item.SellItemInfo[] sellItems){
		this.sellItems = sellItems;
	}	


	@Override
	public void execute() {
		ItemHandlerFactory.getHandler().handleSellItem(this.getSession().getPlayer(), this);
	}
}