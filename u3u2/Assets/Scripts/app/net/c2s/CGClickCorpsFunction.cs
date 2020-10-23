using System;
using System.IO;
namespace app.net
{

/**
 * 点击军团相关功能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickCorpsFunction :BaseMessage
{
	
	/** 军团ID */
	private long corpsId;
	/** 功能ID */
	private int funcId;
	
	public CGClickCorpsFunction ()
	{
	}
	
	public CGClickCorpsFunction (
			long corpsId,
			int funcId )
	{
			this.corpsId = corpsId;
			this.funcId = funcId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 军团ID
	WriteLong(corpsId);
	// 功能ID
	WriteInt(funcId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CLICK_CORPS_FUNCTION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}