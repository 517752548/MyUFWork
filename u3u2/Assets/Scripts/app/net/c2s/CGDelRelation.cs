using System;
using System.IO;
namespace app.net
{

/**
 * 删除关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDelRelation :BaseMessage
{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家名称 */
	private string targetName;
	
	public CGDelRelation ()
	{
	}
	
	public CGDelRelation (
			int relationType,
			string targetName )
	{
			this.relationType = relationType;
			this.targetName = targetName;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 1好友，2黑名单
	WriteInt(relationType);
	// 目标玩家名称
	WriteString(targetName);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_DEL_RELATION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}