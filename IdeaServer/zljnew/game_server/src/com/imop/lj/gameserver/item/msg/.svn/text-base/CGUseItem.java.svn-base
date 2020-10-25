package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.item.handler.ItemHandlerFactory;

/**
 * 玩家使用道具消息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGUseItem extends CGMessage{
	
	/** 背包ID */
	private int bagId;
	/** 道具索引 */
	private int index;
	/** 使用数量 */
	private int count;
	/** 佩戴者类型，如果佩戴者不为0，wearType与roleType对应1:human,2:pet,3:horse,默认对wearId只对2、3有效 */
	private int wearType;
	/** 物品佩戴者的UUID,即当前操作的武将或者宠物id，wearId为0表示没有佩戴者 */
	private long wearerId;
	
	public CGUseItem (){
	}
	
	public CGUseItem (
			int bagId,
			int index,
			int count,
			int wearType,
			long wearerId ){
			this.bagId = bagId;
			this.index = index;
			this.count = count;
			this.wearType = wearType;
			this.wearerId = wearerId;
	}
	
	@Override
	protected boolean readImpl() {

	// 背包ID
	int _bagId = readInteger();
	//end


	// 道具索引
	int _index = readInteger();
	//end


	// 使用数量
	int _count = readInteger();
	//end


	// 佩戴者类型，如果佩戴者不为0，wearType与roleType对应1:human,2:pet,3:horse,默认对wearId只对2、3有效
	int _wearType = readInteger();
	//end


	// 物品佩戴者的UUID,即当前操作的武将或者宠物id，wearId为0表示没有佩戴者
	long _wearerId = readLong();
	//end



			this.bagId = _bagId;
			this.index = _index;
			this.count = _count;
			this.wearType = _wearType;
			this.wearerId = _wearerId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 背包ID
	writeInteger(bagId);


	// 道具索引
	writeInteger(index);


	// 使用数量
	writeInteger(count);


	// 佩戴者类型，如果佩戴者不为0，wearType与roleType对应1:human,2:pet,3:horse,默认对wearId只对2、3有效
	writeInteger(wearType);


	// 物品佩戴者的UUID,即当前操作的武将或者宠物id，wearId为0表示没有佩戴者
	writeLong(wearerId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_USE_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_USE_ITEM";
	}

	public int getBagId(){
		return bagId;
	}
		
	public void setBagId(int bagId){
		this.bagId = bagId;
	}

	public int getIndex(){
		return index;
	}
		
	public void setIndex(int index){
		this.index = index;
	}

	public int getCount(){
		return count;
	}
		
	public void setCount(int count){
		this.count = count;
	}

	public int getWearType(){
		return wearType;
	}
		
	public void setWearType(int wearType){
		this.wearType = wearType;
	}

	public long getWearerId(){
		return wearerId;
	}
		
	public void setWearerId(long wearerId){
		this.wearerId = wearerId;
	}


	@Override
	public void execute() {
		ItemHandlerFactory.getHandler().handleUseItem(this.getSession().getPlayer(), this);
	}
}