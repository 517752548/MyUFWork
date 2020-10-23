using System;
using System.IO;
namespace app.net
{

/**
 * 申请答题
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGExamApply :BaseMessage
{
	
	/** 申请的科举类型 */
	private int examType;
	
	public CGExamApply ()
	{
	}
	
	public CGExamApply (
			int examType )
	{
			this.examType = examType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 申请的科举类型
	WriteInt(examType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EXAM_APPLY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}