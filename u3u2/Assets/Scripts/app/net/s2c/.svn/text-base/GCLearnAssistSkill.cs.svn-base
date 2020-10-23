
using System;
namespace app.net
{
/**
 * 返回请求学习辅助技能结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLearnAssistSkill :BaseMessage
{
	/** 升级结果,1成功,2失败 */
	private int result;

	public GCLearnAssistSkill ()
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
		return (short)MessageType.GC_LEARN_ASSIST_SKILL;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCLearnAssistSkillEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}