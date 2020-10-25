package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 分配物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAllocationItem extends CGMessage{
	
	/** 接受者 */
	private long targetId;
	/** 仓库物品列表 */
	private com.imop.lj.common.model.corps.StorageItemInfo[] storageItemList;
	
	public CGAllocationItem (){
	}
	
	public CGAllocationItem (
			long targetId,
			com.imop.lj.common.model.corps.StorageItemInfo[] storageItemList ){
			this.targetId = targetId;
			this.storageItemList = storageItemList;
	}
	
	@Override
	protected boolean readImpl() {

	// 接受者
	long _targetId = readLong();
	//end


	// 仓库物品列表
	int storageItemListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.StorageItemInfo[] _storageItemList = new com.imop.lj.common.model.corps.StorageItemInfo[storageItemListSize];
	int storageItemListIndex = 0;
	for(storageItemListIndex=0; storageItemListIndex<storageItemListSize; storageItemListIndex++){
		_storageItemList[storageItemListIndex] = new com.imop.lj.common.model.corps.StorageItemInfo();
	// 模版ID
	int _storageItemList_tempId = readInteger();
	//end
	_storageItemList[storageItemListIndex].setTempId (_storageItemList_tempId);

	// 物品位置
	int _storageItemList_index = readInteger();
	//end
	_storageItemList[storageItemListIndex].setIndex (_storageItemList_index);

	// $field.comment
	int _storageItemList_num = readInteger();
	//end
	_storageItemList[storageItemListIndex].setNum (_storageItemList_num);
	}
	//end



			this.targetId = _targetId;
			this.storageItemList = _storageItemList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 接受者
	writeLong(targetId);


	// 仓库物品列表
	writeShort(storageItemList.length);
	int storageItemListIndex = 0;
	int storageItemListSize = storageItemList.length;
	for(storageItemListIndex=0; storageItemListIndex<storageItemListSize; storageItemListIndex++){

	int storageItemList_tempId = storageItemList[storageItemListIndex].getTempId();

	// 模版ID
	writeInteger(storageItemList_tempId);

	int storageItemList_index = storageItemList[storageItemListIndex].getIndex();

	// 物品位置
	writeInteger(storageItemList_index);

	int storageItemList_num = storageItemList[storageItemListIndex].getNum();

	// $field.comment
	writeInteger(storageItemList_num);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ALLOCATION_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ALLOCATION_ITEM";
	}

	public long getTargetId(){
		return targetId;
	}
		
	public void setTargetId(long targetId){
		this.targetId = targetId;
	}

	public com.imop.lj.common.model.corps.StorageItemInfo[] getStorageItemList(){
		return storageItemList;
	}

	public void setStorageItemList(com.imop.lj.common.model.corps.StorageItemInfo[] storageItemList){
		this.storageItemList = storageItemList;
	}	


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleAllocationItem(this.getSession().getPlayer(), this);
	}
}