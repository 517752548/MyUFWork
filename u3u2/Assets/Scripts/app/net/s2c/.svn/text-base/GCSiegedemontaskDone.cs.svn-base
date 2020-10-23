
using System;
namespace app.net
{
/**
 * 已完成所有任务
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSiegedemontaskDone :BaseMessage
{
	/** 任务类型 */
	private int questType;

	public GCSiegedemontaskDone ()
	{
	}

	protected override void ReadImpl()
	{
	// 任务类型
	int _questType = ReadInt();


		this.questType = _questType;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SIEGEDEMONTASK_DONE;
	}
	
	public override string getEventType()
	{
		return SiegedemonGCHandler.GCSiegedemontaskDoneEvent;
	}
	

	public int getQuestType(){
		return questType;
	}
		

}
}