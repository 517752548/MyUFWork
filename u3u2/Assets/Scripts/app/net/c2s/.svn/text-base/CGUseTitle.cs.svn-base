using System;
using System.IO;
namespace app.net
{

/**
 * 使用称号
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGUseTitle :BaseMessage
{
	
	/** 称号的模版ID */
	private int titleTemplateId;
	
	public CGUseTitle ()
	{
	}
	
	public CGUseTitle (
			int titleTemplateId )
	{
			this.titleTemplateId = titleTemplateId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 称号的模版ID
	WriteInt(titleTemplateId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_USE_TITLE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}