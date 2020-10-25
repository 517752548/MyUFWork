package com.imop.lj.gameserver.mall.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mall.handler.MallHandlerFactory;

/**
 * 购买限时物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyTimeLimitItem extends CGMessage{
	
	/** 限时列表ID */
	private String queueUUID;
	/** 商城物品ID */
	private int mallItemId;
	/** 购买数量 */
	private int count;
	
	public CGBuyTimeLimitItem (){
	}
	
	public CGBuyTimeLimitItem (
			String queueUUID,
			int mallItemId,
			int count ){
			this.queueUUID = queueUUID;
			this.mallItemId = mallItemId;
			this.count = count;
	}
	
	@Override
	protected boolean readImpl() {

	// 限时列表ID
	String _queueUUID = readString();
	//end


	// 商城物品ID
	int _mallItemId = readInteger();
	//end


	// 购买数量
	int _count = readInteger();
	//end



			this.queueUUID = _queueUUID;
			this.mallItemId = _mallItemId;
			this.count = _count;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 限时列表ID
	writeString(queueUUID);


	// 商城物品ID
	writeInteger(mallItemId);


	// 购买数量
	writeInteger(count);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_BUY_TIME_LIMIT_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BUY_TIME_LIMIT_ITEM";
	}

	public String getQueueUUID(){
		return queueUUID;
	}
		
	public void setQueueUUID(String queueUUID){
		this.queueUUID = queueUUID;
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
		MallHandlerFactory.getHandler().handleBuyTimeLimitItem(this.getSession().getPlayer(), this);
	}
}