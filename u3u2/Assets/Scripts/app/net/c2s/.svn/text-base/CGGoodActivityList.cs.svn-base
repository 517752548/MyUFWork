using System;
using System.IO;
namespace app.net
{

/**
 * 打开精彩活动面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGoodActivityList :BaseMessage
{
	
	/** 功能id */
	private int funcId;
	
	public CGGoodActivityList ()
	{
	}
	
	public CGGoodActivityList (
			int funcId )
	{
			this.funcId = funcId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 功能id
	WriteInt(funcId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GOOD_ACTIVITY_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}