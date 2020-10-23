using System;
using System.IO;
namespace app.net
{

/**
 * 根据功能Id显示新手引导
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGShowGuideByFunc :BaseMessage
{
	
	/** 功能类型id */
	private int funcTypeId;
	
	public CGShowGuideByFunc ()
	{
	}
	
	public CGShowGuideByFunc (
			int funcTypeId )
	{
			this.funcTypeId = funcTypeId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 功能类型id
	WriteInt(funcTypeId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SHOW_GUIDE_BY_FUNC;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}