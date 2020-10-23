using System;
using System.IO;
namespace app.net
{

/**
 * 请求查看红包详情
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLookCorpsRedEnvelope :BaseMessage
{
	
	/** 要查看红包的uuid */
	private string uuid;
	
	public CGLookCorpsRedEnvelope ()
	{
	}
	
	public CGLookCorpsRedEnvelope (
			string uuid )
	{
			this.uuid = uuid;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 要查看红包的uuid
	WriteString(uuid);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_LOOK_CORPS_RED_ENVELOPE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}