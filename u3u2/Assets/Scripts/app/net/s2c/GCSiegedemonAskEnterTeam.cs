
using System;
namespace app.net
{
/**
 * 队长请求进入组队副本
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSiegedemonAskEnterTeam :BaseMessage
{
	/** 副本类型,12-正常,13-困难 */
	private int siegeType;

	public GCSiegedemonAskEnterTeam ()
	{
	}

	protected override void ReadImpl()
	{
	// 副本类型,12-正常,13-困难
	int _siegeType = ReadInt();


		this.siegeType = _siegeType;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SIEGEDEMON_ASK_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return SiegedemonGCHandler.GCSiegedemonAskEnterTeamEvent;
	}
	

	public int getSiegeType(){
		return siegeType;
	}
		

}
}