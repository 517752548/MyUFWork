using System;
using System.IO;
namespace app.net
{

/**
 * 请求打开通天塔面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTowerInfo :BaseMessage
{
	
	
	public CGTowerInfo ()
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
		return (short)MessageType.CG_TOWER_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}