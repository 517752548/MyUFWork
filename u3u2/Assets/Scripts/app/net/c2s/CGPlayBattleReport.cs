using System;
using System.IO;
namespace app.net
{

/**
 * 客户端请求播放战报
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayBattleReport :BaseMessage
{
	
	/** 战报id，Long格式，包含日期信息 */
	private long id;
	/** 战报读取完毕以后，前端返回场景id */
	private int toBackType;
	
	public CGPlayBattleReport ()
	{
	}
	
	public CGPlayBattleReport (
			long id,
			int toBackType )
	{
			this.id = id;
			this.toBackType = toBackType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 战报id，Long格式，包含日期信息
	WriteLong(id);
	// 战报读取完毕以后，前端返回场景id
	WriteInt(toBackType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PLAY_BATTLE_REPORT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}