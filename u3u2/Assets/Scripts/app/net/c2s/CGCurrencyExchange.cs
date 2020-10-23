using System;
using System.IO;
namespace app.net
{

/**
 * 货币兑换
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCurrencyExchange :BaseMessage
{
	
	/** 花费的货币类型 */
	private int costId;
	/** 要兑换的货币数量 */
	private int exchangeNum;
	/** 要兑换的货币类型，金子兑银子1，金票兑银票5 */
	private int exchangeId;
	
	public CGCurrencyExchange ()
	{
	}
	
	public CGCurrencyExchange (
			int costId,
			int exchangeNum,
			int exchangeId )
	{
			this.costId = costId;
			this.exchangeNum = exchangeNum;
			this.exchangeId = exchangeId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 花费的货币类型
	WriteInt(costId);
	// 要兑换的货币数量
	WriteInt(exchangeNum);
	// 要兑换的货币类型，金子兑银子1，金票兑银票5
	WriteInt(exchangeId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CURRENCY_EXCHANGE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}