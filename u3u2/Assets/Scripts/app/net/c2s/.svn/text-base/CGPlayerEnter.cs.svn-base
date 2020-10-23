using System;
using System.IO;
namespace app.net
{

/**
 * 选择角色进入游戏场景
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerEnter :BaseMessage
{
	
	/** 角色的uuid */
	private long roleUUID;
	
	public CGPlayerEnter ()
	{
	}
	
	public CGPlayerEnter (
			long roleUUID )
	{
			this.roleUUID = roleUUID;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 角色的uuid
	WriteLong(roleUUID);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PLAYER_ENTER;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}