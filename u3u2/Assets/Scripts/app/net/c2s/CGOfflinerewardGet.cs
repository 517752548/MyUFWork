using System;
using System.IO;
namespace app.net
{

/**
 * 玩家领取一个离线奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOfflinerewardGet :BaseMessage
{
	
	/** 奖励功能按钮类型Id */
	private int funcTypeId;
	
	public CGOfflinerewardGet ()
	{
	}
	
	public CGOfflinerewardGet (
			int funcTypeId )
	{
			this.funcTypeId = funcTypeId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 奖励功能按钮类型Id
	WriteInt(funcTypeId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_OFFLINEREWARD_GET;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}