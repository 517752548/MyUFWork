
using System;
namespace app.net
{
/**
 * 我的队伍信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamMyTeamInfo :BaseMessage
{
	/** 目标Id */
	private int targetId;
	/** 等级下限 */
	private int levelMin;
	/** 等级上限 */
	private int levelMax;
	/** 是否自动匹配，0否1是 */
	private int isAutoMatch;

	public GCTeamMyTeamInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 目标Id
	int _targetId = ReadInt();
	// 等级下限
	int _levelMin = ReadInt();
	// 等级上限
	int _levelMax = ReadInt();
	// 是否自动匹配，0否1是
	int _isAutoMatch = ReadInt();


		this.targetId = _targetId;
		this.levelMin = _levelMin;
		this.levelMax = _levelMax;
		this.isAutoMatch = _isAutoMatch;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEAM_MY_TEAM_INFO;
	}
	
	public override string getEventType()
	{
		return TeamGCHandler.GCTeamMyTeamInfoEvent;
	}
	

	public int getTargetId(){
		return targetId;
	}
		

	public int getLevelMin(){
		return levelMin;
	}
		

	public int getLevelMax(){
		return levelMax;
	}
		

	public int getIsAutoMatch(){
		return isAutoMatch;
	}
		

}
}