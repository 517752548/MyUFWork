
using System;
namespace app.net
{
/**
 * 已全部完成新手引导的功能模块列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFinishedGuideListByFunc :BaseMessage
{
	/** 功能类型id */
	private int[] funcTypeIdList;

	public GCFinishedGuideListByFunc ()
	{
	}

	protected override void ReadImpl()
	{
	// 功能类型id
	int funcTypeIdListSize = ReadShort();
	int[] _funcTypeIdList = new int[funcTypeIdListSize];
	int funcTypeIdListIndex = 0;
	for(funcTypeIdListIndex=0; funcTypeIdListIndex<funcTypeIdListSize; funcTypeIdListIndex++){
		_funcTypeIdList[funcTypeIdListIndex] = ReadInt();
	}//end
	


		this.funcTypeIdList = _funcTypeIdList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_FINISHED_GUIDE_LIST_BY_FUNC;
	}
	
	public override string getEventType()
	{
		return GuideGCHandler.GCFinishedGuideListByFuncEvent;
	}
	

	public int[] getFuncTypeIdList(){
		return funcTypeIdList;
	}


}
}