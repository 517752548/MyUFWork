using System;
using System.IO;
namespace app.net
{

/**
 * 队长请求进入组队副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSiegedemonAskEnterTeam :BaseMessage
{
	
	/** 副本类型,12-正常,13-困难 */
	private int siegeType;
	
	public CGSiegedemonAskEnterTeam ()
	{
	}
	
	public CGSiegedemonAskEnterTeam (
			int siegeType )
	{
			this.siegeType = siegeType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 副本类型,12-正常,13-困难
	WriteInt(siegeType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SIEGEDEMON_ASK_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}