
using System;
namespace app.net
{
/**
 * 服务器下发战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPlayBattleReport :BaseMessage
{
	/** 战报id，Long格式，包含日期信息 */
	private long id;
	/** 战报数据包 */
	private string reportPack;
	/** 是否可以立即结束 */
	private int canClose;
	/** 是否显示Url */
	private int hasUrl;
	/** 战报读取完毕以后，前端返回场景id */
	private int toBackType;
	/** 战斗附加json串，主要是奖励等信息 */
	private string additionPack;

	public GCPlayBattleReport ()
	{
	}

	protected override void ReadImpl()
	{
	// 战报id，Long格式，包含日期信息
	long _id = ReadLong();
	// 战报数据包
	string _reportPack = ReadString();
	// 是否可以立即结束
	int _canClose = ReadInt();
	// 是否显示Url
	int _hasUrl = ReadInt();
	// 战报读取完毕以后，前端返回场景id
	int _toBackType = ReadInt();
	// 战斗附加json串，主要是奖励等信息
	string _additionPack = ReadString();


		this.id = _id;
		this.reportPack = _reportPack;
		this.canClose = _canClose;
		this.hasUrl = _hasUrl;
		this.toBackType = _toBackType;
		this.additionPack = _additionPack;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PLAY_BATTLE_REPORT;
	}
	
	public override string getEventType()
	{
		return BattleGCHandler.GCPlayBattleReportEvent;
	}
	

	public long getId(){
		return id;
	}
		

	public string getReportPack(){
		return reportPack;
	}
		

	public int getCanClose(){
		return canClose;
	}
		

	public int getHasUrl(){
		return hasUrl;
	}
		

	public int getToBackType(){
		return toBackType;
	}
		

	public string getAdditionPack(){
		return additionPack;
	}
		

	public override bool isCompress() {
		return true;
	}
}
}