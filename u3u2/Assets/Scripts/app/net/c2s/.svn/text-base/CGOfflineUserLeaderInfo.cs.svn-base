using System;
using System.IO;
namespace app.net
{

/**
 * 查看他人主将信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOfflineUserLeaderInfo :BaseMessage
{
	
	/** 玩家角色Id */
	private long roleId;
	
	public CGOfflineUserLeaderInfo ()
	{
	}
	
	public CGOfflineUserLeaderInfo (
			long roleId )
	{
			this.roleId = roleId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 玩家角色Id
	WriteLong(roleId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_OFFLINE_USER_LEADER_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}