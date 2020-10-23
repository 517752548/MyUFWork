using System;
using System.IO;
namespace app.net
{

/**
 * 添加军团成员成好友
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsAddToFriend :BaseMessage
{
	
	
	public CGCorpsAddToFriend ()
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
		return (short)MessageType.CG_CORPS_ADD_TO_FRIEND;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}