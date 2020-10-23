using System;
using System.IO;
namespace app.net
{

/**
 * 出师
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFireOverman :BaseMessage
{
	
	/** 是否同意 1是同意 徒弟发 */
	private int canOverman;
	
	public CGFireOverman ()
	{
	}
	
	public CGFireOverman (
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
	// 是否同意 1是同意 徒弟发
	WriteInt(canOverman);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_FIRE_OVERMAN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}