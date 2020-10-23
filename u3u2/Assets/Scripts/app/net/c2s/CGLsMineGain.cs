using System;
using System.IO;
namespace app.net
{

/**
 * 申请取得矿石
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLsMineGain :BaseMessage
{
	
	/** 矿点ID */
	private int pitId;
	
	public CGLsMineGain ()
	{
	}
	
	public CGLsMineGain (
			int pitId )
	{
			this.pitId = pitId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 矿点ID
	WriteInt(pitId);

	}
	
	public override short GetMessageType()
	{
        return (short)0;// MessageType.CG_LS_MINE_GAIN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}