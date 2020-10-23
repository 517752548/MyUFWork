
using System;
namespace app.net
{
/**
 * 通知前台某功能模块有新手引导了
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFuncHasGuide :BaseMessage
{
	/** 功能类型id */
	private int funcTypeId;

	public GCFuncHasGuide ()
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
		return (short)MessageType.GC_FUNC_HAS_GUIDE;
	}
	
	public override string getEventType()
	{
		return GuideGCHandler.GCFuncHasGuideEvent;
	}
	

	public int getFuncTypeId(){
		return funcTypeId;
	}
		

}
}