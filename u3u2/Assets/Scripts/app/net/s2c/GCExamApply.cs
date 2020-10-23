
using System;
namespace app.net
{
/**
 * 申请答题结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCExamApply :BaseMessage
{
	/** 申请的科举类型 */
	private int examType;
	/** 申请结果 1成功,2失败 */
	private int result;

	public GCExamApply ()
	{
	}

	protected override void ReadImpl()
	{
	// 申请的科举类型
	int _examType = ReadInt();
	// 申请结果 1成功,2失败
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
		return (short)MessageType.GC_EXAM_APPLY;
	}
	
	public override string getEventType()
	{
		return ExamGCHandler.GCExamApplyEvent;
	}
	

	public int getExamType(){
		return examType;
	}
		

	public int getResult(){
		return result;
	}
		

}
}