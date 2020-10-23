
using System;
namespace app.net
{
/**
 * 请求竞技场战斗记录
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaBattleRecord :BaseMessage
{
	/** 当前时间 */
	private long curTime;
	/** 竞技场战斗记录 */
	private ArenaReportHistoryData[] arenaReportHistoryList;

	public GCArenaBattleRecord ()
	{
	}

	protected override void ReadImpl()
	{
	// 当前时间
	long _curTime = ReadLong();

	// 竞技场战斗记录
	int arenaReportHistoryListSize = ReadShort();
	ArenaReportHistoryData[] _arenaReportHistoryList = new ArenaReportHistoryData[arenaReportHistoryListSize];
	int arenaReportHistoryListIndex = 0;
	ArenaReportHistoryData _arenaReportHistoryListTmp = null;
	for(arenaReportHistoryListIndex=0; arenaReportHistoryListIndex<arenaReportHistoryListSize; arenaReportHistoryListIndex++){
		_arenaReportHistoryListTmp = new ArenaReportHistoryData();
		_arenaReportHistoryList[arenaReportHistoryListIndex] = _arenaReportHistoryListTmp;
	// 战报Id
	string _arenaReportHistoryList_reportId = ReadString();	_arenaReportHistoryListTmp.reportId = _arenaReportHistoryList_reportId;
		// 战报时间
	long _arenaReportHistoryList_reportTime = ReadLong();	_arenaReportHistoryListTmp.reportTime = _arenaReportHistoryList_reportTime;
		// 对手Id
	long _arenaReportHistoryList_targetRoleId = ReadLong();	_arenaReportHistoryListTmp.targetRoleId = _arenaReportHistoryList_targetRoleId;
		// 对手模板Id
	int _arenaReportHistoryList_targetTplId = ReadInt();	_arenaReportHistoryListTmp.targetTplId = _arenaReportHistoryList_targetTplId;
		// 对手等级
	int _arenaReportHistoryList_targetLevel = ReadInt();	_arenaReportHistoryListTmp.targetLevel = _arenaReportHistoryList_targetLevel;
		// 对手名字
	string _arenaReportHistoryList_targetName = ReadString();	_arenaReportHistoryListTmp.targetName = _arenaReportHistoryList_targetName;
		// 名次变化
	int _arenaReportHistoryList_rankDelta = ReadInt();	_arenaReportHistoryListTmp.rankDelta = _arenaReportHistoryList_rankDelta;
		// 是否胜利
	int _arenaReportHistoryList_isWin = ReadInt();	_arenaReportHistoryListTmp.isWin = _arenaReportHistoryList_isWin;
		}
	//end



		this.curTime = _curTime;
		this.arenaReportHistoryList = _arenaReportHistoryList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ARENA_BATTLE_RECORD;
	}
	
	public override string getEventType()
	{
		return ArenaGCHandler.GCArenaBattleRecordEvent;
	}
	

	public long getCurTime(){
		return curTime;
	}
		

	public ArenaReportHistoryData[] getArenaReportHistoryList(){
		return arenaReportHistoryList;
	}


}
}