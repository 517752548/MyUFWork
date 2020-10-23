using System;
using System.IO;
namespace app.net
{

/**
 * 请求打开活动奖励分配面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenAllocatePanel :BaseMessage
{
	
	/** 活动类型,1-帮派竞赛 */
	private int activityType;
	
	public CGOpenAllocatePanel ()
	{
	}
	
	public CGOpenAllocatePanel (
			int activityType )
	{
			this.activityType = activityType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 活动类型,1-帮派竞赛
	WriteInt(activityType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_OPEN_ALLOCATE_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}