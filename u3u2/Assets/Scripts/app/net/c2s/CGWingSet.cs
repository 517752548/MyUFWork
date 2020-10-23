using System;
using System.IO;
namespace app.net
{

/**
 * 装备翅膀
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWingSet :BaseMessage
{
	
	/** 翅膀模板Id */
	private int templateId;
	
	public CGWingSet ()
	{
	}
	
	public CGWingSet (
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
		return (short)MessageType.CG_WING_SET;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}