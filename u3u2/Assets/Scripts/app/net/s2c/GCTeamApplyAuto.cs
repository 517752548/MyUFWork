
using System;
namespace app.net
{
/**
 * 自动申请加入队伍
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamApplyAuto :BaseMessage
{
	/** 是否自动申请，0否1是 */
	private int isAuto;
	/** 目标Id */
	private int targetId;

	public GCTeamApplyAuto ()
	{
	}

	protected override void ReadImpl()
	{
	// 是否自动申请，0否1是
	int _isAuto = ReadInt();
	// 目标Id
	int _targetId = ReadInt();


		this.isAuto = _isAuto;
		this.targetId = _targetId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEAM_APPLY_AUTO;
	}
	
	public override string getEventType()
	{
		return TeamGCHandler.GCTeamApplyAutoEvent;
	}
	

	public int getIsAuto(){
		return isAuto;
	}
		

	public int getTargetId(){
		return targetId;
	}
		

}
}