package com.imop.lj.gameserver.mall.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mall.handler.MallHandlerFactory;

/**
 * 兑换商城物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyExchangeItem extends CGMessage{
	
	/** 商城物品ID */
	private int mallItemId;
	/** 购买数量 */
	private int count;
	
	public CGBuyExchangeItem (){
	}
	
	public CGBuyExchangeItem (
			int mallItemId,
			int count ){
			this.mallItemId = mallItemId;
			this.count = count;
	}
	
	@Override
	protected boolean readImpl() {

	// 商城物品ID
	int _mallItemId = readInteger();
	//end


	// 购买数量
	int _count = readInteger();
	//end



			this.mallItemId = _mallItemId;
			this.count = _count;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 商城物品ID
	writeInteger(mallItemId);


	// 购买数量
	writeInteger(count);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_BUY_EXCHANGE_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BUY_EXCHANGE_ITEM";
	}

	public int getMallItemId(){
		return mallItemId;
	}
		
	public void setMallItemId(int mallItemId){
		this.mallItemId = mallItemId;
	}

	public int getCount(){
		return count;
	}
		
	public void setCount(int count){
		this.count = count;
	}


	@Override
	public void execute() {
		MallHandlerFactory.getHandler().handleBuyExchangeItem(this.getSession().getPlayer(), this);
	}
}