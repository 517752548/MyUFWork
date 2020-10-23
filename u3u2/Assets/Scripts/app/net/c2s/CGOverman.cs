using System;
using System.IO;
namespace app.net
{

/**
 * 申请拜师 ,徒弟发出
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOverman :BaseMessage
{
	
	/** 是否同意 1是同意 */
	private int canOverman;
	
	public CGOverman ()
	{
	}
	
	public CGOverman (
			int canOverman )
	{
			this.canOverman = canOverman;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否同意 1是同意
	WriteInt(canOverman);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_OVERMAN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}