using System;
using System.IO;
namespace app.net
{

/**
 * 打开护送粮草任务面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenForagetaskPanel :BaseMessage
{
	
	
	public CGOpenForagetaskPanel ()
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
		return (short)MessageType.CG_OPEN_FORAGETASK_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}