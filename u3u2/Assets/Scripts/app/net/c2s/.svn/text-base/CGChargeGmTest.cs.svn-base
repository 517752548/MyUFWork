using System;
using System.IO;
namespace app.net
{

/**
 * 充值测试消息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGChargeGmTest :BaseMessage
{
	
	/** 充值模板Id */
	private int tplId;
	
	public CGChargeGmTest ()
	{
	}
	
	public CGChargeGmTest (
			int tplId )
	{
			this.tplId = tplId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 充值模板Id
	WriteInt(tplId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CHARGE_GM_TEST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}