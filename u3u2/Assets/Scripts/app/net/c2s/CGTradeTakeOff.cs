using System;
using System.IO;
namespace app.net
{

/**
 * 申请下架物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeTakeOff :BaseMessage
{
	
	/** 商品类型 */
	private int commodityType;
	/** 摊位坐标(1-10) */
	private int boothIndex;
	
	public CGTradeTakeOff ()
	{
	}
	
	public CGTradeTakeOff (
			int commodityType,
			int boothIndex )
	{
			this.commodityType = commodityType;
			this.boothIndex = boothIndex;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 商品类型
	WriteInt(commodityType);
	// 摊位坐标(1-10)
	WriteInt(boothIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TRADE_TAKE_OFF;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}