
using System;
namespace app.net
{
/**
 * 心法升级结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHsMainSkillUpgrade :BaseMessage
{
	/** 结果 1成功,2失败 */
	private int result;

	public GCHsMainSkillUpgrade ()
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
		return (short)MessageType.GC_HS_MAIN_SKILL_UPGRADE;
	}
	
	public override string getEventType()
	{
		return HumanskillGCHandler.GCHsMainSkillUpgradeEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}