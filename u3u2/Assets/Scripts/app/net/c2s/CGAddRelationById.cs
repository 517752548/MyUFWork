using System;
using System.IO;
namespace app.net
{

/**
 * 添加关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddRelationById :BaseMessage
{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家Id */
	private long targetCharId;
	
	public CGAddRelationById ()
	{
	}
	
	public CGAddRelationById (
			int relationType,
			long targetCharId )
	{
			this.relationType = relationType;
			this.targetCharId = targetCharId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 1好友，2黑名单
	WriteInt(relationType);
	// 目标玩家Id
	WriteLong(targetCharId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ADD_RELATION_BY_ID;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}