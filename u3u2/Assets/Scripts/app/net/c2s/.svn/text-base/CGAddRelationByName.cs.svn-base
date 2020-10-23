using System;
using System.IO;
namespace app.net
{

/**
 * 添加关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddRelationByName :BaseMessage
{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家名称 */
	private string targetName;
	
	public CGAddRelationByName ()
	{
	}
	
	public CGAddRelationByName (
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
		return (short)MessageType.CG_ADD_RELATION_BY_NAME;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}