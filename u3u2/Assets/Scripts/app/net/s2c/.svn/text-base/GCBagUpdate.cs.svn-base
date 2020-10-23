
using System;
namespace app.net
{
/**
 * 刷新整个背包
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBagUpdate :BaseMessage
{
	/** 背包ID */
	private int bagId;
	/** 佩戴者uuid */
	private long wearerId;
	/** 单个道具信息 */
	private CommonItemData[] item;

	public GCBagUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 背包ID
	int _bagId = ReadInt();
	// 佩戴者uuid
	long _wearerId = ReadLong();

	// 单个道具信息
	int itemSize = ReadShort();
	CommonItemData[] _item = new CommonItemData[itemSize];
	int itemIndex = 0;
	CommonItemData _itemTmp = null;
	for(itemIndex=0; itemIndex<itemSize; itemIndex++){
		_itemTmp = new CommonItemData();
		_item[itemIndex] = _itemTmp;
	// 道具实例uuid
	string _item_uuid = ReadString();	_itemTmp.uuid = _item_uuid;
		// 包id
	int _item_bagId = ReadInt();	_itemTmp.bagId = _item_bagId;
		// 道具在背包内位置索引
	int _item_index = ReadInt();	_itemTmp.index = _item_index;
		// 道具模板Id
	int _item_tplId = ReadInt();	_itemTmp.tplId = _item_tplId;
		// 数量
	int _item_count = ReadInt();	_itemTmp.count = _item_count;
		// 最后一次更新时间
	long _item_lastUpdateTime = ReadLong();	_itemTmp.lastUpdateTime = _item_lastUpdateTime;
		// 剩余使用时限描述
	string _item_expireDesc = ReadString();	_itemTmp.expireDesc = _item_expireDesc;
		// 持有者id，主背包为0
	long _item_wearerId = ReadLong();	_itemTmp.wearerId = _item_wearerId;
		// 绑定状态，0绑定，1未绑定
	int _item_bind = ReadInt();	_itemTmp.bind = _item_bind;
		// 道具props，json
	string _item_props = ReadString();	_itemTmp.props = _item_props;
		}
	//end



		this.bagId = _bagId;
		this.wearerId = _wearerId;
		this.item = _item;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BAG_UPDATE;
	}
	
	public override string getEventType()
	{
		return ItemGCHandler.GCBagUpdateEvent;
	}
	

	public int getBagId(){
		return bagId;
	}
		

	public long getWearerId(){
		return wearerId;
	}
		

	public CommonItemData[] getItem(){
		return item;
	}


	public override bool isCompress() {
		return true;
	}
}
}