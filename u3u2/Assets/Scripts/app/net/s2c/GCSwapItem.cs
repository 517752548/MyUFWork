
using System;
namespace app.net
{
/**
 * 交换道具
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSwapItem :BaseMessage
{
	/** 来源持有者id，主背包为0 */
	private long fromWearerId;
	/** 来源包id */
	private int fromBagId;
	/** 道具在来源背包内位置索引 */
	private int fromIndex;
	/** 目的持有者id，主背包为0 */
	private long toWearerId;
	/** 目的包id */
	private int toBagId;
	/** 道具在目的包内位置索引 */
	private int toIndex;

	public GCSwapItem ()
	{
	}

	protected override void ReadImpl()
	{
	// 来源持有者id，主背包为0
	long _fromWearerId = ReadLong();
	// 来源包id
	int _fromBagId = ReadInt();
	// 道具在来源背包内位置索引
	int _fromIndex = ReadInt();
	// 目的持有者id，主背包为0
	long _toWearerId = ReadLong();
	// 目的包id
	int _toBagId = ReadInt();
	// 道具在目的包内位置索引
	int _toIndex = ReadInt();


		this.fromWearerId = _fromWearerId;
		this.fromBagId = _fromBagId;
		this.fromIndex = _fromIndex;
		this.toWearerId = _toWearerId;
		this.toBagId = _toBagId;
		this.toIndex = _toIndex;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SWAP_ITEM;
	}
	
	public override string getEventType()
	{
		return ItemGCHandler.GCSwapItemEvent;
	}
	

	public long getFromWearerId(){
		return fromWearerId;
	}
		

	public int getFromBagId(){
		return fromBagId;
	}
		

	public int getFromIndex(){
		return fromIndex;
	}
		

	public long getToWearerId(){
		return toWearerId;
	}
		

	public int getToBagId(){
		return toBagId;
	}
		

	public int getToIndex(){
		return toIndex;
	}
		

}
}