using System;
using System.IO;
namespace app.net
{

/**
 * 功能按钮更新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFuncUpdate :BaseMessage
{
	
	/** 功能按钮类型 */
	private int funcType;
	
	public CGFuncUpdate ()
	{
	}
	
	public CGFuncUpdate (
			int funcType )
	{
			this.funcType = funcType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 功能按钮类型
	WriteInt(funcType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_FUNC_UPDATE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}