
using System;
namespace app.net
{
/**
 * 通知前台一些功能模块有新手引导了，功能id列表，登录时发
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFuncHasGuideList :BaseMessage
{
	/** 功能类型id */
	private int[] funcTypeId;

	public GCFuncHasGuideList ()
	{
	}

	protected override void ReadImpl()
	{
	// 功能类型id
	int funcTypeIdSize = ReadShort();
	int[] _funcTypeId = new int[funcTypeIdSize];
	int funcTypeIdIndex = 0;
	for(funcTypeIdIndex=0; funcTypeIdIndex<funcTypeIdSize; funcTypeIdIndex++){
		_funcTypeId[funcTypeIdIndex] = ReadInt();
	}//end
	


		this.funcTypeId = _funcTypeId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_FUNC_HAS_GUIDE_LIST;
	}
	
	public override string getEventType()
	{
		return GuideGCHandler.GCFuncHasGuideListEvent;
	}
	

	public int[] getFuncTypeId(){
		return funcTypeId;
	}


}
}