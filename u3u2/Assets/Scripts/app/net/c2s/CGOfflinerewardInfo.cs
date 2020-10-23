using System;
using System.IO;
namespace app.net
{

/**
 * 离线奖励信息，一个奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOfflinerewardInfo :BaseMessage
{
	
	/** 奖励功能按钮类型Id */
	private int funcTypeId;
	
	public CGOfflinerewardInfo ()
	{
	}
	
	public CGOfflinerewardInfo (
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
		return (short)MessageType.CG_OFFLINEREWARD_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}