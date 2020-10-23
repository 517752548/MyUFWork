using System;
using System.IO;
namespace app.net
{

/**
 * 离婚
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFireMarry :BaseMessage
{
	
	/** 是否同意 1是同意 */
	private int canFire;
	
	public CGFireMarry ()
	{
	}
	
	public CGFireMarry (
			int canFire )
	{
			this.canFire = canFire;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否同意 1是同意
	WriteInt(canFire);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_FIRE_MARRY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}