using System;
using System.IO;
namespace app.net
{

/**
 * 请求单个伙伴的信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendInfo :BaseMessage
{
	
	/** 伙伴模板Id */
	private int tplId;
	
	public CGPetFriendInfo ()
	{
	}
	
	public CGPetFriendInfo (
			int tplId )
	{
			this.tplId = tplId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 伙伴模板Id
	WriteInt(tplId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_FRIEND_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}