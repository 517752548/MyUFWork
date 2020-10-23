
using System;
namespace app.net
{
/**
 * 使用物品结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCExamUseItem :BaseMessage
{
	/** 申请的科举类型 */
	private int examType;
	/** 物品使用结果 1成功,2失败 */
	private int result;

	public GCExamUseItem ()
	{
	}

	protected override void ReadImpl()
	{
	// 申请的科举类型
	int _examType = ReadInt();
	// 物品使用结果 1成功,2失败
	int _result = ReadInt();


		this.examType = _examType;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_EXAM_USE_ITEM;
	}
	
	public override string getEventType()
	{
		return ExamGCHandler.GCExamUseItemEvent;
	}
	

	public int getExamType(){
		return examType;
	}
		

	public int getResult(){
		return result;
	}
		

}
}