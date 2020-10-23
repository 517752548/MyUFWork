using System;
using System.IO;
namespace app.net
{

/**
 * 隐藏称号
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDisTitle :BaseMessage
{
	
	/** 是否隐藏称号 0隐藏,1显示称号 */
	private int distitle;
	
	public CGDisTitle ()
	{
	}
	
	public CGDisTitle (
			int distitle )
	{
			this.distitle = distitle;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否隐藏称号 0隐藏,1显示称号
	WriteInt(distitle);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_DIS_TITLE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}