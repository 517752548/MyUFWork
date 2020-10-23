using System;
using System.IO;
namespace app.net
{

/**
 * 应答进入组队副本的请求
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSiegedemonAnswerEnterTeam :BaseMessage
{
	
	/** 是否同意进入，0不同意，1同意 */
	private int agree;
	/** 副本类型,12-正常,13-困难 */
	private int siegeType;
	
	public CGSiegedemonAnswerEnterTeam ()
	{
	}
	
	public CGSiegedemonAnswerEnterTeam (
			int agree,
			int siegeType )
	{
			this.agree = agree;
			this.siegeType = siegeType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否同意进入，0不同意，1同意
	WriteInt(agree);
	// 副本类型,12-正常,13-困难
	WriteInt(siegeType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SIEGEDEMON_ANSWER_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}