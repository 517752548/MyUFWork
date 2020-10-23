using System;
using System.IO;
namespace app.net
{

/**
 * 酒馆任务手动刷新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPubtaskRefresh :BaseMessage
{
	
	
	public CGPubtaskRefresh ()
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
		return (short)MessageType.CG_PUBTASK_REFRESH;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}