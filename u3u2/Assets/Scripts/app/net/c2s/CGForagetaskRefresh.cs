using System;
using System.IO;
namespace app.net
{

/**
 * 护送粮草任务手动刷新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGForagetaskRefresh :BaseMessage
{
	
	
	public CGForagetaskRefresh ()
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
		return (short)MessageType.CG_FORAGETASK_REFRESH;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}