using System;
using System.IO;
namespace app.net
{

/**
 * 卖出道具
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSellItem :BaseMessage
{
	
	/** 背包ID */
	private int bagId;
	/** 卖出道具信息 */
	private SellItemInfoData[] sellItems;
	
	public CGSellItem ()
	{
	}
	
	public CGSellItem (
			int bagId,
			SellItemInfoData[] sellItems )
	{
			this.bagId = bagId;
			this.sellItems = sellItems;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 背包ID
	WriteInt(bagId);

	// 卖出道具信息
	WriteShort((short)sellItems.Length);
	int sellItemsIndex = 0;
	int sellItemsSize = sellItems.Length;
	for(sellItemsIndex=0; sellItemsIndex<sellItemsSize; sellItemsIndex++){

	int sellItems_index = sellItems[sellItemsIndex].index;
	// 背包内位置索引
	WriteInt(sellItems_index);
	int sellItems_count = sellItems[sellItemsIndex].count;
	// 卖出道具的数量
	WriteInt(sellItems_count);	}
	//end


	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SELL_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public SellItemInfoData[] getSellItems()
	{
		return sellItems;
	}

	public void setSellItems(SellItemInfoData[] sellItems)
	{
		this.sellItems = sellItems;
	}
	}
}