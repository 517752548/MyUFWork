
using System;
namespace app.net
{
/**
 * 移除一个道具
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRemoveItem :BaseMessage
{
	/** 佩戴者uuid，主背包为0 */
	private long wearerId;
	/** 物品UUID */
	private string uuid;
	/** 包id */
	private int bagId;
	/** 道具在包内位置索引 */
	private int index;

	public GCRemoveItem ()
	{
	}

	protected override void ReadImpl()
	{
	// 佩戴者uuid，主背包为0
	long _wearerId = ReadLong();
	// 物品UUID
	string _uuid = ReadString();
	// 包id
	int _bagId = ReadInt();
	// 道具在包内位置索引
	int _index = ReadInt();


		this.wearerId = _wearerId;
		this.uuid = _uuid;
		this.bagId = _bagId;
		this.index = _index;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_REMOVE_ITEM;
	}
	
	public override string getEventType()
	{
		return ItemGCHandler.GCRemoveItemEvent;
	}
	

	public long getWearerId(){
		return wearerId;
	}
		

	public string getUuid(){
		return uuid;
	}
		

	public int getBagId(){
		return bagId;
	}
		

	public int getIndex(){
		return index;
	}
		

}
}