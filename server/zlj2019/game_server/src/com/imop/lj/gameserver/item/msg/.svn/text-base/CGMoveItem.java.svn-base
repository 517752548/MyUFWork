package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.item.handler.ItemHandlerFactory;

/**
 * 移动物品，用于拖拽动作
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMoveItem extends CGMessage{
	
	/** 来源包id */
	private int fromBagId;
	/** 道具在来源背包内位置索引 */
	private int fromIndex;
	/** 目的包id */
	private int toBagId;
	/** 道具在目的包内位置索引 */
	private int toIndex;
	/** 物品佩戴者的UUID,即当前操作的武将宠物id */
	private long wearerId;
	
	public CGMoveItem (){
	}
	
	public CGMoveItem (
			int fromBagId,
			int fromIndex,
			int toBagId,
			int toIndex,
			long wearerId ){
			this.fromBagId = fromBagId;
			this.fromIndex = fromIndex;
			this.toBagId = toBagId;
			this.toIndex = toIndex;
			this.wearerId = wearerId;
	}
	
	@Override
	protected boolean readImpl() {

	// 来源包id
	int _fromBagId = readInteger();
	//end


	// 道具在来源背包内位置索引
	int _fromIndex = readInteger();
	//end


	// 目的包id
	int _toBagId = readInteger();
	//end


	// 道具在目的包内位置索引
	int _toIndex = readInteger();
	//end


	// 物品佩戴者的UUID,即当前操作的武将宠物id
	long _wearerId = readLong();
	//end



			this.fromBagId = _fromBagId;
			this.fromIndex = _fromIndex;
			this.toBagId = _toBagId;
			this.toIndex = _toIndex;
			this.wearerId = _wearerId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 来源包id
	writeInteger(fromBagId);


	// 道具在来源背包内位置索引
	writeInteger(fromIndex);


	// 目的包id
	writeInteger(toBagId);


	// 道具在目的包内位置索引
	writeInteger(toIndex);


	// 物品佩戴者的UUID,即当前操作的武将宠物id
	writeLong(wearerId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_MOVE_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_MOVE_ITEM";
	}

	public int getFromBagId(){
		return fromBagId;
	}
		
	public void setFromBagId(int fromBagId){
		this.fromBagId = fromBagId;
	}

	public int getFromIndex(){
		return fromIndex;
	}
		
	public void setFromIndex(int fromIndex){
		this.fromIndex = fromIndex;
	}

	public int getToBagId(){
		return toBagId;
	}
		
	public void setToBagId(int toBagId){
		this.toBagId = toBagId;
	}

	public int getToIndex(){
		return toIndex;
	}
		
	public void setToIndex(int toIndex){
		this.toIndex = toIndex;
	}

	public long getWearerId(){
		return wearerId;
	}
		
	public void setWearerId(long wearerId){
		this.wearerId = wearerId;
	}


	@Override
	public void execute() {
		ItemHandlerFactory.getHandler().handleMoveItem(this.getSession().getPlayer(), this);
	}
}