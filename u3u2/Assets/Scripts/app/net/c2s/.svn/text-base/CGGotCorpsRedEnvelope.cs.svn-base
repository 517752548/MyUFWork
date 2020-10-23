using System;
using System.IO;
namespace app.net
{

/**
 * 请求领取帮派红包
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGotCorpsRedEnvelope :BaseMessage
{
	
	/** 红包类型,1-帮派红包 */
	private int redEnvelopeType;
	/** 要领取红包的uuid */
	private string uuid;
	
	public CGGotCorpsRedEnvelope ()
	{
	}
	
	public CGGotCorpsRedEnvelope (
			int redEnvelopeType,
			string uuid )
	{
			this.redEnvelopeType = redEnvelopeType;
			this.uuid = uuid;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 红包类型,1-帮派红包
	WriteInt(redEnvelopeType);
	// 要领取红包的uuid
	WriteString(uuid);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GOT_CORPS_RED_ENVELOPE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}