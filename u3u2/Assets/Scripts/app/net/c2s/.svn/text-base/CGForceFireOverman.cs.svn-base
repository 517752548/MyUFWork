using System;
using System.IO;
namespace app.net
{

/**
 * 强制出师
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGForceFireOverman :BaseMessage
{
	
	/** 师傅或者徒弟的charid */
	private long charId;
	
	public CGForceFireOverman ()
	{
	}
	
	public CGForceFireOverman (
			long charId )
	{
			this.charId = charId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 师傅或者徒弟的charid
	WriteLong(charId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_FORCE_FIRE_OVERMAN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}