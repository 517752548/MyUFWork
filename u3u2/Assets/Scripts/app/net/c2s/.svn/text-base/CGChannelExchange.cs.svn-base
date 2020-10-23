using System;
using System.IO;
namespace app.net
{

/**
 * 通过码兑换奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGChannelExchange :BaseMessage
{
	
	/** 兑换码 */
	private string code;
	
	public CGChannelExchange ()
	{
	}
	
	public CGChannelExchange (
			string code )
	{
			this.code = code;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 兑换码
	WriteString(code);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CHANNEL_EXCHANGE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}