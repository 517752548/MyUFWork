using System;
using System.IO;
namespace app.net
{

/**
 * 卸下翅膀
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWingTakedown :BaseMessage
{
	
	/** 翅膀模板Id */
	private int templateId;
	
	public CGWingTakedown ()
	{
	}
	
	public CGWingTakedown (
			int templateId )
	{
			this.templateId = templateId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 翅膀模板Id
	WriteInt(templateId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_WING_TAKEDOWN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}