using System;
using System.IO;
namespace app.net
{

/**
 * 获得徒弟所有的奖励状态
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetLowermanReward :BaseMessage
{
	
	
	public CGGetLowermanReward ()
	{
	}
	
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GET_LOWERMAN_REWARD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}