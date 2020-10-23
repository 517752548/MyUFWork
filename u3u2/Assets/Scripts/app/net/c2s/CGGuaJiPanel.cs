using System;
using System.IO;
namespace app.net
{

/**
 * 打开挂机面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGuaJiPanel :BaseMessage
{
	
	
	public CGGuaJiPanel ()
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
		return (short)MessageType.CG_GUA_JI_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}