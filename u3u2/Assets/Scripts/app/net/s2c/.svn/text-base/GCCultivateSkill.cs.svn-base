
using System;
namespace app.net
{
/**
 * 返回请求修炼技能结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCultivateSkill :BaseMessage
{
	/** 升级结果,1成功,2失败 */
	private int result;

	public GCCultivateSkill ()
	{
	}

	protected override void ReadImpl()
	{
	// 升级结果,1成功,2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CULTIVATE_SKILL;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCCultivateSkillEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}