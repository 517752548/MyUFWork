using System;
using System.IO;
namespace app.net
{

/**
 * 商品查询
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeSearch :BaseMessage
{
	
	/** 商品查询条件 */
	private string conditions;
	
	public CGTradeSearch ()
	{
	}
	
	public CGTradeSearch (
			string conditions )
	{
			this.conditions = conditions;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 商品查询条件
	WriteString(conditions);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TRADE_SEARCH;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}