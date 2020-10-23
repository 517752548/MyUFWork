
using System;
namespace app.net
{
/**
 * 查看他人宠物信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOfflineUserPetInfo :BaseMessage
{
	/** 玩家角色Id */
	private long roleId;
	/** 宠物Id */
	private long petId;
	/** 宠物信息json */
	private string petInfoJson;

	public GCOfflineUserPetInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 玩家角色Id
	long _roleId = ReadLong();
	// 宠物Id
	long _petId = ReadLong();
	// 宠物信息json
	string _petInfoJson = ReadString();


		this.roleId = _roleId;
		this.petId = _petId;
		this.petInfoJson = _petInfoJson;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OFFLINE_USER_PET_INFO;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCOfflineUserPetInfoEvent;
	}
	

	public long getRoleId(){
		return roleId;
	}
		

	public long getPetId(){
		return petId;
	}
		

	public string getPetInfoJson(){
		return petInfoJson;
	}
		

}
}