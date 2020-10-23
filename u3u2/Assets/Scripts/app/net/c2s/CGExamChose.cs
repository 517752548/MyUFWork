using System;
using System.IO;
namespace app.net
{

/**
 * 选择选项
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGExamChose :BaseMessage
{
	
	/** 申请的科举类型 */
	private int examType;
	/** 选择的答案 */
	private int choseAnswer;
	
	public CGExamChose ()
	{
	}
	
	public CGExamChose (
			int examType,
			int choseAnswer )
	{
			this.examType = examType;
			this.choseAnswer = choseAnswer;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 申请的科举类型
	WriteInt(examType);
	// 选择的答案
	WriteInt(choseAnswer);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EXAM_CHOSE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}