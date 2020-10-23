
using System;
namespace app.net
{
/**
 * 分配物品
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCStorageItemList :BaseMessage
{
	/** 仓库物品模版列表 */
	private StorageItemTempInfo[] storageItemTempList;
	/** 仓库物品列表 */
	private StorageItemInfo[] storageItemList;

	public GCStorageItemList ()
	{
	}

	protected override void ReadImpl()
	{

	// 仓库物品模版列表
	int storageItemTempListSize = ReadShort();
	StorageItemTempInfo[] _storageItemTempList = new StorageItemTempInfo[storageItemTempListSize];
	int storageItemTempListIndex = 0;
	StorageItemTempInfo _storageItemTempListTmp = null;
	for(storageItemTempListIndex=0; storageItemTempListIndex<storageItemTempListSize; storageItemTempListIndex++){
		_storageItemTempListTmp = new StorageItemTempInfo();
		_storageItemTempList[storageItemTempListIndex] = _storageItemTempListTmp;
	// 模版ID
	int _storageItemTempList_tempId = ReadInt();	_storageItemTempListTmp.tempId = _storageItemTempList_tempId;
		// ICONID
	string _storageItemTempList_iconId = ReadString();	_storageItemTempListTmp.iconId = _storageItemTempList_iconId;
		// 物品名称
	string _storageItemTempList_name = ReadString();	_storageItemTempListTmp.name = _storageItemTempList_name;
		// 使用等级
	int _storageItemTempList_useLevel = ReadInt();	_storageItemTempListTmp.useLevel = _storageItemTempList_useLevel;
		// 功能描述
	string _storageItemTempList_desc = ReadString();	_storageItemTempListTmp.desc = _storageItemTempList_desc;
		// 出售价格
	int _storageItemTempList_price = ReadInt();	_storageItemTempListTmp.price = _storageItemTempList_price;
		// 品质
	int _storageItemTempList_quality = ReadInt();	_storageItemTempListTmp.quality = _storageItemTempList_quality;
		}
	//end


	// 仓库物品列表
	int storageItemListSize = ReadShort();
	StorageItemInfo[] _storageItemList = new StorageItemInfo[storageItemListSize];
	int storageItemListIndex = 0;
	StorageItemInfo _storageItemListTmp = null;
	for(storageItemListIndex=0; storageItemListIndex<storageItemListSize; storageItemListIndex++){
		_storageItemListTmp = new StorageItemInfo();
		_storageItemList[storageItemListIndex] = _storageItemListTmp;
	// 模版ID
	int _storageItemList_tempId = ReadInt();	_storageItemListTmp.tempId = _storageItemList_tempId;
		// 物品位置
	int _storageItemList_index = ReadInt();	_storageItemListTmp.index = _storageItemList_index;
		// $field.comment
	int _storageItemList_num = ReadInt();	_storageItemListTmp.num = _storageItemList_num;
		}
	//end



		this.storageItemTempList = _storageItemTempList;
		this.storageItemList = _storageItemList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_STORAGE_ITEM_LIST;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCStorageItemListEvent;
	}
	

	public StorageItemTempInfo[] getStorageItemTempList(){
		return storageItemTempList;
	}


	public StorageItemInfo[] getStorageItemList(){
		return storageItemList;
	}


}
}