using System;
using System.IO;
namespace app.net
{

/**
 * 请求制作物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMakeItem :BaseMessage
{
	
	/** 技能Id */
	private int skillId;
	/** 生成对应等级的物品,默认为0代表该生成物品为随机方式 */
	private int targetLevel;
	
	public CGMakeItem ()
	{
	}
	
	public CGMakeItem (
			int skillId,
			int targetLevel )
	{
			this.skillId = skillId;
			this.targetLevel = targetLevel;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 技能Id
	WriteInt(skillId);
	// 生成对应等级的物品,默认为0代表该生成物品为随机方式
	WriteInt(targetLevel);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_MAKE_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}