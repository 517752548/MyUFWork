using System;
using System.IO;
namespace app.net
{

/**
 * 伙伴下阵
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendOffArray :BaseMessage
{
	
	/** 阵容索引，从0开始计数 */
	private int arrayIndex;
	/** 目标位置索引，从0开始计数 */
	private int targetPosIndex;
	
	public CGPetFriendOffArray ()
	{
	}
	
	public CGPetFriendOffArray (
			int arrayIndex,
			int targetPosIndex )
	{
			this.arrayIndex = arrayIndex;
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
	// 目标位置索引，从0开始计数
	WriteInt(targetPosIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_FRIEND_OFF_ARRAY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}