using System;
using System.IO;
namespace app.net
{

/**
 * 购买物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeBuy :BaseMessage
{
	
	/** 卖家Id */
	private long sellerId;
	/** 商品类型 */
	private int commodityType;
	/** 摊位坐标(1-10) */
	private int boothIndex;
	/** 商品uuid */
	private string commodityId;
	
	public CGTradeBuy ()
	{
	}
	
	public CGTradeBuy (
			long sellerId,
			int commodityType,
			int boothIndex,
			string commodityId )
	{
			this.sellerId = sellerId;
			this.commodityType = commodityType;
			this.boothIndex = boothIndex;
			this.commodityId = commodityId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 卖家Id
	WriteLong(sellerId);
	// 商品类型
	WriteInt(commodityType);
	// 摊位坐标(1-10)
	WriteInt(boothIndex);
	// 商品uuid
	WriteString(commodityId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TRADE_BUY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}