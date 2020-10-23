using System;
using System.IO;
namespace app.net
{

/**
 * 查看他人宠物信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOfflineUserPetInfo :BaseMessage
{
	
	/** 玩家角色Id */
	private long roleId;
	/** 宠物Id */
	private long petId;
	
	public CGOfflineUserPetInfo ()
	{
	}
	
	public CGOfflineUserPetInfo (
			long roleId,
			long petId )
	{
			this.roleId = roleId;
			this.petId = petId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 玩家角色Id
	WriteLong(roleId);
	// 宠物Id
	WriteLong(petId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_OFFLINE_USER_PET_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}