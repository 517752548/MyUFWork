
using System;
namespace app.net
{
/**
 * 已全部完成新手引导的功能模块Id，当某完成某新手引导后给前台发送更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFinishedGuideByFunc :BaseMessage
{
	/** 功能类型id */
	private int funcTypeId;

	public GCFinishedGuideByFunc ()
	{
	}

	protected override void ReadImpl()
	{
	// 功能类型id
	int _funcTypeId = ReadInt();


		this.funcTypeId = _funcTypeId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_FINISHED_GUIDE_BY_FUNC;
	}
	
	public override string getEventType()
	{
		return GuideGCHandler.GCFinishedGuideByFuncEvent;
	}
	

	public int getFuncTypeId(){
		return funcTypeId;
	}
		

}
}