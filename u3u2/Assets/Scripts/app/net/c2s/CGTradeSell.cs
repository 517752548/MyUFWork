using System;
using System.IO;
namespace app.net
{

/**
 * 申请卖出商品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeSell :BaseMessage
{
	
	/** 商品UUID */
	private string commodityId;
	/** 出售的货币种类 */
	private int currencyType;
	/** 出售的货币数量(单价) */
	private int currencyNum;
	/** 商品类型 */
	private int commodityType;
	/** 商品数量 */
	private int commodityNum;
	/** 摊位坐标(1-10) */
	private int boothIndex;
	
	public CGTradeSell ()
	{
	}
	
	public CGTradeSell (
			string commodityId,
			int currencyType,
			int currencyNum,
			int commodityType,
			int commodityNum,
			int boothIndex )
	{
			this.commodityId = commodityId;
			this.currencyType = currencyType;
			this.currencyNum = currencyNum;
			this.commodityType = commodityType;
			this.commodityNum = commodityNum;
			this.boothIndex = boothIndex;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 商品UUID
	WriteString(commodityId);
	// 出售的货币种类
	WriteInt(currencyType);
	// 出售的货币数量(单价)
	WriteInt(currencyNum);
	// 商品类型
	WriteInt(commodityType);
	// 商品数量
	WriteInt(commodityNum);
	// 摊位坐标(1-10)
	WriteInt(boothIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TRADE_SELL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}