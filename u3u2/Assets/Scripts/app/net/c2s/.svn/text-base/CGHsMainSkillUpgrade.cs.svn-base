using System;
using System.IO;
namespace app.net
{

/**
 * 心法升级
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGHsMainSkillUpgrade :BaseMessage
{
	
	/** 心法ID */
	private int mindId;
	/** 修炼方式是否批量,0-否,1-是 */
	private int isBatch;
	
	public CGHsMainSkillUpgrade ()
	{
	}
	
	public CGHsMainSkillUpgrade (
			int mindId,
			int isBatch )
	{
			this.mindId = mindId;
			this.isBatch = isBatch;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 心法ID
	WriteInt(mindId);
	// 修炼方式是否批量,0-否,1-是
	WriteInt(isBatch);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_HS_MAIN_SKILL_UPGRADE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}