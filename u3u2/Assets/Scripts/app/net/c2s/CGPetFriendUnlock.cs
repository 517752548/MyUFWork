using System;
using System.IO;
namespace app.net
{

/**
 * 伙伴解锁
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendUnlock :BaseMessage
{
	
	/** 伙伴模板Id */
	private int tplId;
	/** 解锁方式，分别为1(7d)，2(30d)，3(forever) */
	private int unlockId;
	
	public CGPetFriendUnlock ()
	{
	}
	
	public CGPetFriendUnlock (
			int tplId,
			int unlockId )
	{
			this.tplId = tplId;
			this.unlockId = unlockId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 伙伴模板Id
	WriteInt(tplId);
	// 解锁方式，分别为1(7d)，2(30d)，3(forever)
	WriteInt(unlockId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_FRIEND_UNLOCK;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}