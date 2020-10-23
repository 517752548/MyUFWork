using System;
using System.IO;
namespace app.net
{

/**
 * 打开伙伴面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetOpenFriendPanel :BaseMessage
{
	
	
	public CGPetOpenFriendPanel ()
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
		return (short)MessageType.CG_PET_OPEN_FRIEND_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}