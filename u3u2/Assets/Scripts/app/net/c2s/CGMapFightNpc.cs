using System;
using System.IO;
namespace app.net
{

/**
 * 玩家请求与npc战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMapFightNpc :BaseMessage
{
	
	/** npcId */
	private int npcId;
	/** 唯一Id */
	private string uuid;
	
	public CGMapFightNpc ()
	{
	}
	
	public CGMapFightNpc (
			int npcId,
			string uuid )
	{
			this.npcId = npcId;
			this.uuid = uuid;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// npcId
	WriteInt(npcId);
	// 唯一Id
	WriteString(uuid);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_MAP_FIGHT_NPC;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}