package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 分配物品
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCStorageItemList extends GCMessage{
	
	/** 仓库物品模版列表 */
	private com.imop.lj.common.model.corps.StorageItemTempInfo[] storageItemTempList;
	/** 仓库物品列表 */
	private com.imop.lj.common.model.corps.StorageItemInfo[] storageItemList;

	public GCStorageItemList (){
	}
	
	public GCStorageItemList (
			com.imop.lj.common.model.corps.StorageItemTempInfo[] storageItemTempList,
			com.imop.lj.common.model.corps.StorageItemInfo[] storageItemList ){
			this.storageItemTempList = storageItemTempList;
			this.storageItemList = storageItemList;
	}

	@Override
	protected boolean readImpl() {

	// 仓库物品模版列表
	int storageItemTempListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.StorageItemTempInfo[] _storageItemTempList = new com.imop.lj.common.model.corps.StorageItemTempInfo[storageItemTempListSize];
	int storageItemTempListIndex = 0;
	for(storageItemTempListIndex=0; storageItemTempListIndex<storageItemTempListSize; storageItemTempListIndex++){
		_storageItemTempList[storageItemTempListIndex] = new com.imop.lj.common.model.corps.StorageItemTempInfo();
	// 模版ID
	int _storageItemTempList_tempId = readInteger();
	//end
	_storageItemTempList[storageItemTempListIndex].setTempId (_storageItemTempList_tempId);

	// ICONID
	String _storageItemTempList_iconId = readString();
	//end
	_storageItemTempList[storageItemTempListIndex].setIconId (_storageItemTempList_iconId);

	// 物品名称
	String _storageItemTempList_name = readString();
	//end
	_storageItemTempList[storageItemTempListIndex].setName (_storageItemTempList_name);

	// 使用等级
	int _storageItemTempList_useLevel = readInteger();
	//end
	_storageItemTempList[storageItemTempListIndex].setUseLevel (_storageItemTempList_useLevel);

	// 功能描述
	String _storageItemTempList_desc = readString();
	//end
	_storageItemTempList[storageItemTempListIndex].setDesc (_storageItemTempList_desc);

	// 出售价格
	int _storageItemTempList_price = readInteger();
	//end
	_storageItemTempList[storageItemTempListIndex].setPrice (_storageItemTempList_price);

	// 品质
	int _storageItemTempList_quality = readInteger();
	//end
	_storageItemTempList[storageItemTempListIndex].setQuality (_storageItemTempList_quality);
	}
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



		this.storageItemTempList = _storageItemTempList;
		this.storageItemList = _storageItemList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 仓库物品模版列表
	writeShort(storageItemTempList.length);
	int storageItemTempListIndex = 0;
	int storageItemTempListSize = storageItemTempList.length;
	for(storageItemTempListIndex=0; storageItemTempListIndex<storageItemTempListSize; storageItemTempListIndex++){

	int storageItemTempList_tempId = storageItemTempList[storageItemTempListIndex].getTempId();

	// 模版ID
	writeInteger(storageItemTempList_tempId);

	String storageItemTempList_iconId = storageItemTempList[storageItemTempListIndex].getIconId();

	// ICONID
	writeString(storageItemTempList_iconId);

	String storageItemTempList_name = storageItemTempList[storageItemTempListIndex].getName();

	// 物品名称
	writeString(storageItemTempList_name);

	int storageItemTempList_useLevel = storageItemTempList[storageItemTempListIndex].getUseLevel();

	// 使用等级
	writeInteger(storageItemTempList_useLevel);

	String storageItemTempList_desc = storageItemTempList[storageItemTempListIndex].getDesc();

	// 功能描述
	writeString(storageItemTempList_desc);

	int storageItemTempList_price = storageItemTempList[storageItemTempListIndex].getPrice();

	// 出售价格
	writeInteger(storageItemTempList_price);

	int storageItemTempList_quality = storageItemTempList[storageItemTempListIndex].getQuality();

	// 品质
	writeInteger(storageItemTempList_quality);
	}
	//end


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
		return MessageType.GC_STORAGE_ITEM_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_STORAGE_ITEM_LIST";
	}

	public com.imop.lj.common.model.corps.StorageItemTempInfo[] getStorageItemTempList(){
		return storageItemTempList;
	}

	public void setStorageItemTempList(com.imop.lj.common.model.corps.StorageItemTempInfo[] storageItemTempList){
		this.storageItemTempList = storageItemTempList;
	}	

	public com.imop.lj.common.model.corps.StorageItemInfo[] getStorageItemList(){
		return storageItemList;
	}

	public void setStorageItemList(com.imop.lj.common.model.corps.StorageItemInfo[] storageItemList){
		this.storageItemList = storageItemList;
	}	
}