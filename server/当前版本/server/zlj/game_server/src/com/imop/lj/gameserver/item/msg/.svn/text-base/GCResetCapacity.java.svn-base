package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 重新设置背包的容量，只可能是主道具包、材料包、仓库三者之一
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCResetCapacity extends GCMessage{
	
	/** 包Id */
	private int bagId;
	/** 新的容量 */
	private int capacity;

	public GCResetCapacity (){
	}
	
	public GCResetCapacity (
			int bagId,
			int capacity ){
			this.bagId = bagId;
			this.capacity = capacity;
	}

	@Override
	protected boolean readImpl() {

	// 包Id
	int _bagId = readInteger();
	//end


	// 新的容量
	int _capacity = readInteger();
	//end



		this.bagId = _bagId;
		this.capacity = _capacity;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 包Id
	writeInteger(bagId);


	// 新的容量
	writeInteger(capacity);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_RESET_CAPACITY;
	}
	
	@Override
	public String getTypeName() {
		return "GC_RESET_CAPACITY";
	}

	public int getBagId(){
		return bagId;
	}
		
	public void setBagId(int bagId){
		this.bagId = bagId;
	}

	public int getCapacity(){
		return capacity;
	}
		
	public void setCapacity(int capacity){
		this.capacity = capacity;
	}
}