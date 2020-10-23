using System;
using System.IO;
namespace app.net
{

/**
 * 获得活跃度奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAcitvityUiReward :BaseMessage
{
	
	/** 活力值(20,40,60,80,100) */
	private int vitalityNum;
	
	public CGAcitvityUiReward ()
	{
	}
	
	public CGAcitvityUiReward (
			int vitalityNum )
	{
			this.vitalityNum = vitalityNum;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 活力值(20,40,60,80,100)
	WriteInt(vitalityNum);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ACITVITY_UI_REWARD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}