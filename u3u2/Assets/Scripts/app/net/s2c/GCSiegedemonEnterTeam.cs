
using System;
namespace app.net
{
/**
 * 进入组队副本
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSiegedemonEnterTeam :BaseMessage
{
	/** 副本类型,12-正常,13-困难 */
	private int siegeType;

	public GCSiegedemonEnterTeam ()
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
		return (short)MessageType.GC_SIEGEDEMON_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return SiegedemonGCHandler.GCSiegedemonEnterTeamEvent;
	}
	

	public int getSiegeType(){
		return siegeType;
	}
		

}
}