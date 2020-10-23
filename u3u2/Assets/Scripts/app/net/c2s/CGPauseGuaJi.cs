using System;
using System.IO;
namespace app.net
{

/**
 * 暂停挂机
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPauseGuaJi :BaseMessage
{
	
	
	public CGPauseGuaJi ()
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
		return (short)MessageType.CG_PAUSE_GUA_JI;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}