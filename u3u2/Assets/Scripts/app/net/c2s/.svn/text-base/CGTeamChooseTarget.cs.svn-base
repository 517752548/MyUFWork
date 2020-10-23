using System;
using System.IO;
namespace app.net
{

/**
 * 选择队伍的目标
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamChooseTarget :BaseMessage
{
	
	/** 目标Id */
	private int targetId;
	/** 等级下限 */
	private int levelMin;
	/** 等级上限 */
	private int levelMax;
	/** 是否自动匹配，0否1是 */
	private int isAutoMatch;
	
	public CGTeamChooseTarget ()
	{
	}
	
	public CGTeamChooseTarget (
			int targetId,
			int levelMin,
			int levelMax,
			int isAutoMatch )
	{
			this.targetId = targetId;
			this.levelMin = levelMin;
			this.levelMax = levelMax;
			this.isAutoMatch = isAutoMatch;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 目标Id
	WriteInt(targetId);
	// 等级下限
	WriteInt(levelMin);
	// 等级上限
	WriteInt(levelMax);
	// 是否自动匹配，0否1是
	WriteInt(isAutoMatch);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_CHOOSE_TARGET;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}