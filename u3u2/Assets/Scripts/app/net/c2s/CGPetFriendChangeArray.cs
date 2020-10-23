using System;
using System.IO;
namespace app.net
{

/**
 * 切换正在使用的阵容
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendChangeArray :BaseMessage
{
	
	/** 切换的阵容索引，从0开始计数 */
	private int arrayIndex;
	
	public CGPetFriendChangeArray ()
	{
	}
	
	public CGPetFriendChangeArray (
			int arrayIndex )
	{
			this.arrayIndex = arrayIndex;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 切换的阵容索引，从0开始计数
	WriteInt(arrayIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_FRIEND_CHANGE_ARRAY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}