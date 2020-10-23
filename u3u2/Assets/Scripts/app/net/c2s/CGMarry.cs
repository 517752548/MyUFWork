using System;
using System.IO;
namespace app.net
{

/**
 * 结婚 ,2发出
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMarry :BaseMessage
{
	
	/** 是否同意 1是同意 */
	private int canMarry;
	
	public CGMarry ()
	{
	}
	
	public CGMarry (
			int canMarry )
	{
			this.canMarry = canMarry;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否同意 1是同意
	WriteInt(canMarry);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_MARRY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}