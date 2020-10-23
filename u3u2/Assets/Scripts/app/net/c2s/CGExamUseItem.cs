using System;
using System.IO;
namespace app.net
{

/**
 * 使用物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGExamUseItem :BaseMessage
{
	
	/** 申请的科举类型 */
	private int examType;
	/** 使用的特殊道具,1松木令,2玉木令 */
	private int itemId;
	
	public CGExamUseItem ()
	{
	}
	
	public CGExamUseItem (
			int examType,
			int itemId )
	{
			this.examType = examType;
			this.itemId = itemId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 申请的科举类型
	WriteInt(examType);
	// 使用的特殊道具,1松木令,2玉木令
	WriteInt(itemId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EXAM_USE_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}