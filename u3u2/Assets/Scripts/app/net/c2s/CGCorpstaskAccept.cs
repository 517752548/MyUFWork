using System;
using System.IO;
namespace app.net
{

/**
 * 接受任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpstaskAccept :BaseMessage
{
	
	
	public CGCorpstaskAccept ()
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
		return (short)MessageType.CG_CORPSTASK_ACCEPT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}