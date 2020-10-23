using System;
using System.IO;
namespace app.net
{

/**
 * 伙伴调整位置
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendChangePosition :BaseMessage
{
	
	/** 阵容索引，从0开始计数 */
	private int arrayIndex;
	/** 伙伴模板Id */
	private int tplId;
	/** 目标位置索引，从0开始计数 */
	private int targetPosIndex;
	
	public CGPetFriendChangePosition ()
	{
	}
	
	public CGPetFriendChangePosition (
			int arrayIndex,
			int tplId,
			int targetPosIndex )
	{
			this.arrayIndex = arrayIndex;
			this.tplId = tplId;
			this.targetPosIndex = targetPosIndex;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 阵容索引，从0开始计数
	WriteInt(arrayIndex);
	// 伙伴模板Id
	WriteInt(tplId);
	// 目标位置索引，从0开始计数
	WriteInt(targetPosIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_FRIEND_CHANGE_POSITION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}