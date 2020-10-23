using System;
using System.IO;
namespace app.net
{

/**
 * 查看他人基础信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOfflineUserBaseInfo :BaseMessage
{
	
	/** 玩家角色Id */
	private long roleId;
	
	public CGOfflineUserBaseInfo ()
	{
	}
	
	public CGOfflineUserBaseInfo (
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
		return (short)MessageType.CG_OFFLINE_USER_BASE_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}