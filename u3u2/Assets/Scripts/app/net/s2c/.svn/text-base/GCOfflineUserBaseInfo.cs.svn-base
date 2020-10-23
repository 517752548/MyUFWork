
using System;
namespace app.net
{
/**
 * 查看他人基础信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOfflineUserBaseInfo :BaseMessage
{
	/** 玩家角色Id */
	private long roleId;
	/** 玩家角色基础信息json */
	private string roleBaseInfoJson;

	public GCOfflineUserBaseInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 玩家角色Id
	long _roleId = ReadLong();
	// 玩家角色基础信息json
	string _roleBaseInfoJson = ReadString();


		this.roleId = _roleId;
		this.roleBaseInfoJson = _roleBaseInfoJson;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OFFLINE_USER_BASE_INFO;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCOfflineUserBaseInfoEvent;
	}
	

	public long getRoleId(){
		return roleId;
	}
		

	public string getRoleBaseInfoJson(){
		return roleBaseInfoJson;
	}
		

}
}