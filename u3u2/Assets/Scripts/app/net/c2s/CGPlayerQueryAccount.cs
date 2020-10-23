using System;
using System.IO;
namespace app.net
{

/**
 * 查询账户余额
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerQueryAccount :BaseMessage
{
	
	
	public CGPlayerQueryAccount ()
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
		return (short)MessageType.CG_PLAYER_QUERY_ACCOUNT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}