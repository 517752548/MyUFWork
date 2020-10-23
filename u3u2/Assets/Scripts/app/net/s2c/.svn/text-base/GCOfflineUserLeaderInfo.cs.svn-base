
using System;
namespace app.net
{
/**
 * 查看他人主将信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOfflineUserLeaderInfo :BaseMessage
{
	/** 玩家角色Id */
	private long roleId;
	/** 主将信息json */
	private string roleInfoJson;

	public GCOfflineUserLeaderInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 玩家角色Id
	long _roleId = ReadLong();
	// 主将信息json
	string _roleInfoJson = ReadString();


		this.roleId = _roleId;
		this.roleInfoJson = _roleInfoJson;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OFFLINE_USER_LEADER_INFO;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCOfflineUserLeaderInfoEvent;
	}
	

	public long getRoleId(){
		return roleId;
	}
		

	public string getRoleInfoJson(){
		return roleInfoJson;
	}
		

}
}