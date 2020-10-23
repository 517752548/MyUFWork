using System;
using System.IO;
namespace app.net
{

/**
 * 分配物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAllocationItem :BaseMessage
{
	
	/** 接受者 */
	private long targetId;
	/** 仓库物品列表 */
	private StorageItemInfo[] storageItemList;
	
	public CGAllocationItem ()
	{
	}
	
	public CGAllocationItem (
			long targetId,
			StorageItemInfo[] storageItemList )
	{
			this.targetId = targetId;
			this.storageItemList = storageItemList;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 接受者
	WriteLong(targetId);

	// 仓库物品列表
	WriteShort((short)storageItemList.Length);
	int storageItemListIndex = 0;
	int storageItemListSize = storageItemList.Length;
	for(storageItemListIndex=0; storageItemListIndex<storageItemListSize; storageItemListIndex++){

	int storageItemList_tempId = storageItemList[storageItemListIndex].tempId;
	// 模版ID
	WriteInt(storageItemList_tempId);
	int storageItemList_index = storageItemList[storageItemListIndex].index;
	// 物品位置
	WriteInt(storageItemList_index);
	int storageItemList_num = storageItemList[storageItemListIndex].num;
	// $field.comment
	WriteInt(storageItemList_num);	}
	//end


	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ALLOCATION_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public StorageItemInfo[] getStorageItemList()
	{
		return storageItemList;
	}

	public void setStorageItemList(StorageItemInfo[] storageItemList)
	{
		this.storageItemList = storageItemList;
	}
	}
}