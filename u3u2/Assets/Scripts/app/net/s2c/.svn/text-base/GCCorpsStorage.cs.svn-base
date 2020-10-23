
using System;
namespace app.net
{
/**
 * 返回军团仓库
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsStorage :BaseMessage
{
	/** 仓库军团成员列表 */
	private StorageCorpsMemberInfo[] storageMemList;
	/** 仓库物品模版列表 */
	private StorageItemTempInfo[] storageItemTempList;
	/** 仓库物品列表 */
	private StorageItemInfo[] storageItemList;
	/** 是否可以進行分配操作1:可以；0：不可以 */
	private int canAllccation;

	public GCCorpsStorage ()
	{
	}

	protected override void ReadImpl()
	{

	// 仓库军团成员列表
	int storageMemListSize = ReadShort();
	StorageCorpsMemberInfo[] _storageMemList = new StorageCorpsMemberInfo[storageMemListSize];
	int storageMemListIndex = 0;
	StorageCorpsMemberInfo _storageMemListTmp = null;
	for(storageMemListIndex=0; storageMemListIndex<storageMemListSize; storageMemListIndex++){
		_storageMemListTmp = new StorageCorpsMemberInfo();
		_storageMemList[storageMemListIndex] = _storageMemListTmp;
	// 成员ID
	long _storageMemList_memId = ReadLong();	_storageMemListTmp.memId = _storageMemList_memId;
		// 名称
	string _storageMemList_name = ReadString();	_storageMemListTmp.name = _storageMemList_name;
		// 职位名称
	string _storageMemList_jobName = ReadString();	_storageMemListTmp.jobName = _storageMemList_jobName;
		// 总贡献
	long _storageMemList_totalContribution = ReadLong();	_storageMemListTmp.totalContribution = _storageMemList_totalContribution;
		}
	//end


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

	// 是否可以進行分配操作1:可以；0：不可以
	int _canAllccation = ReadInt();


		this.storageMemList = _storageMemList;
		this.storageItemTempList = _storageItemTempList;
		this.storageItemList = _storageItemList;
		this.canAllccation = _canAllccation;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPS_STORAGE;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCCorpsStorageEvent;
	}
	

	public StorageCorpsMemberInfo[] getStorageMemList(){
		return storageMemList;
	}


	public StorageItemTempInfo[] getStorageItemTempList(){
		return storageItemTempList;
	}


	public StorageItemInfo[] getStorageItemList(){
		return storageItemList;
	}


	public int getCanAllccation(){
		return canAllccation;
	}
		

}
}