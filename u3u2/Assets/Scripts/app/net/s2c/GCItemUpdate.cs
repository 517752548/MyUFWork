
using System;
namespace app.net
{
/**
 * 更新单个道具信息，客户端受到此消息就替换原来此位置的道具
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCItemUpdate :BaseMessage
{
	/** 单个道具信息 */
	private CommonItemData item;

	public GCItemUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 单个道具信息
	CommonItemData _item = new CommonItemData();
	// 道具实例uuid
	string _item_uuid = ReadString();	_item.uuid = _item_uuid;
	// 包id
	int _item_bagId = ReadInt();	_item.bagId = _item_bagId;
	// 道具在背包内位置索引
	int _item_index = ReadInt();	_item.index = _item_index;
	// 道具模板Id
	int _item_tplId = ReadInt();	_item.tplId = _item_tplId;
	// 数量
	int _item_count = ReadInt();	_item.count = _item_count;
	// 最后一次更新时间
	long _item_lastUpdateTime = ReadLong();	_item.lastUpdateTime = _item_lastUpdateTime;
	// 剩余使用时限描述
	string _item_expireDesc = ReadString();	_item.expireDesc = _item_expireDesc;
	// 持有者id，主背包为0
	long _item_wearerId = ReadLong();	_item.wearerId = _item_wearerId;
	// 绑定状态，0绑定，1未绑定
	int _item_bind = ReadInt();	_item.bind = _item_bind;
	// 道具props，json
	string _item_props = ReadString();	_item.props = _item_props;



		this.item = _item;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ITEM_UPDATE;
	}
	
	public override string getEventType()
	{
		return ItemGCHandler.GCItemUpdateEvent;
	}
	

	public CommonItemData getItem(){
		return item;
	}
		

}
}