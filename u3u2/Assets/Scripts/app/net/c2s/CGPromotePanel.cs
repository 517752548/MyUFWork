using System;
using System.IO;
namespace app.net
{

/**
 * 打开提升面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPromotePanel :BaseMessage
{
	
	
	public CGPromotePanel ()
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
		return (short)MessageType.CG_PROMOTE_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}