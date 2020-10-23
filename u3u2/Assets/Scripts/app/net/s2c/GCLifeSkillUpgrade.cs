
using System;
namespace app.net
{
/**
 * 生活技能升级结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLifeSkillUpgrade :BaseMessage
{
	/** 结果 1成功,2失败 */
	private int result;

	public GCLifeSkillUpgrade ()
	{
	}

	protected override void ReadImpl()
	{
	// 结果 1成功,2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_LIFE_SKILL_UPGRADE;
	}
	
	public override string getEventType()
	{
		return LifeskillGCHandler.GCLifeSkillUpgradeEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}