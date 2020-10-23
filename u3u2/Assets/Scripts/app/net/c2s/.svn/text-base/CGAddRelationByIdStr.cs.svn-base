using System;
using System.IO;
namespace app.net
{

/**
 * 添加关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddRelationByIdStr :BaseMessage
{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家Id */
	private string targetCharIdStr;
	
	public CGAddRelationByIdStr ()
	{
	}
	
	public CGAddRelationByIdStr (
			int relationType,
			string targetCharIdStr )
	{
			this.relationType = relationType;
			this.targetCharIdStr = targetCharIdStr;
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
	WriteString(targetCharIdStr);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ADD_RELATION_BY_ID_STR;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}