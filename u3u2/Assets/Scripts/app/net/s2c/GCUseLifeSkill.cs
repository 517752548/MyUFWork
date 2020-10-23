
using System;
namespace app.net
{
/**
 * 使用生活技能结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUseLifeSkill :BaseMessage
{
	/** 采集状态,0未在采集,1-伐木,2-采药,3-采矿,4-狩猎 */
	private int result;

	public GCUseLifeSkill ()
	{
	}

	protected override void ReadImpl()
	{
	// 采集状态,0未在采集,1-伐木,2-采药,3-采矿,4-狩猎
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_USE_LIFE_SKILL;
	}
	
	public override string getEventType()
	{
		return LifeskillGCHandler.GCUseLifeSkillEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}