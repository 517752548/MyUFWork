package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.item.handler.ItemHandlerFactory;

/**
 * 道具合成
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGItemCompose extends CGMessage{
	
	/** 背包ID */
	private int bagId;
	/** 道具索引 */
	private int index;
	/** 0合成一个，1批量合成 */
	private int batchFlag;
	
	public CGItemCompose (){
	}
	
	public CGItemCompose (
			int bagId,
			int index,
			int batchFlag ){
			this.bagId = bagId;
			this.index = index;
			this.batchFlag = batchFlag;
	}
	
	@Override
	protected boolean readImpl() {

	// 背包ID
	int _bagId = readInteger();
	//end


	// 道具索引
	int _index = readInteger();
	//end


	// 0合成一个，1批量合成
	int _batchFlag = readInteger();
	//end



			this.bagId = _bagId;
			this.index = _index;
			this.batchFlag = _batchFlag;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 背包ID
	writeInteger(bagId);


	// 道具索引
	writeInteger(index);


	// 0合成一个，1批量合成
	writeInteger(batchFlag);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ITEM_COMPOSE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ITEM_COMPOSE";
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

	public int getBatchFlag(){
		return batchFlag;
	}
		
	public void setBatchFlag(int batchFlag){
		this.batchFlag = batchFlag;
	}


	@Override
	public void execute() {
		ItemHandlerFactory.getHandler().handleItemCompose(this.getSession().getPlayer(), this);
	}
}