using System;
using System.IO;
namespace app.net
{

/**
 * 请求发送帮派红包
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCreateCorpsRedEnvelope :BaseMessage
{
	
	/** 红包类型,1-帮派红包 */
	private int redEnvelopeType;
	/** 红包内容 */
	private string content;
	/** 红包总金额 */
	private int bonusAmount;
	
	public CGCreateCorpsRedEnvelope ()
	{
	}
	
	public CGCreateCorpsRedEnvelope (
			int redEnvelopeType,
			string content,
			int bonusAmount )
	{
			this.redEnvelopeType = redEnvelopeType;
			this.content = content;
			this.bonusAmount = bonusAmount;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 红包类型,1-帮派红包
	WriteInt(redEnvelopeType);
	// 红包内容
	WriteString(content);
	// 红包总金额
	WriteInt(bonusAmount);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CREATE_CORPS_RED_ENVELOPE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}