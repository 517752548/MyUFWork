using System;
using System.IO;
namespace app.net
{

/**
 * 点击活动
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickAcitvity :BaseMessage
{
	
	/** 活动id */
	private int activityId;
	
	public CGClickAcitvity ()
	{
	}
	
	public CGClickAcitvity (
			int activityId )
	{
			this.activityId = activityId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 活动id
	WriteInt(activityId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CLICK_ACITVITY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}