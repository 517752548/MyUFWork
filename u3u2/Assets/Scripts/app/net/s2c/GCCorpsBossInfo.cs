
using System;
namespace app.net
{
/**
 * 返回当前队长或个人的boss情况
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsBossInfo :BaseMessage
{
	/** 当前挑战boss进度 */
	private int curCorpsBossLevel;
	/** 地图玩家信息 */
	private CorpsBossInfoData[] CorpsBossInfoDataList;

	public GCCorpsBossInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 当前挑战boss进度
	int _curCorpsBossLevel = ReadInt();

	// 地图玩家信息
	int CorpsBossInfoDataListSize = ReadShort();
	CorpsBossInfoData[] _CorpsBossInfoDataList = new CorpsBossInfoData[CorpsBossInfoDataListSize];
	int CorpsBossInfoDataListIndex = 0;
	CorpsBossInfoData _CorpsBossInfoDataListTmp = null;
	for(CorpsBossInfoDataListIndex=0; CorpsBossInfoDataListIndex<CorpsBossInfoDataListSize; CorpsBossInfoDataListIndex++){
		_CorpsBossInfoDataListTmp = new CorpsBossInfoData();
		_CorpsBossInfoDataList[CorpsBossInfoDataListIndex] = _CorpsBossInfoDataListTmp;
	// boss进度
	int _CorpsBossInfoDataList_bossLevel = ReadInt();	_CorpsBossInfoDataListTmp.bossLevel = _CorpsBossInfoDataList_bossLevel;
		// 可获得奖励次数
	int _CorpsBossInfoDataList_bossRewardNum = ReadInt();	_CorpsBossInfoDataListTmp.bossRewardNum = _CorpsBossInfoDataList_bossRewardNum;
		// 本周是否已打,1-已到,0-未打
	int _CorpsBossInfoDataList_weekFight = ReadInt();	_CorpsBossInfoDataListTmp.weekFight = _CorpsBossInfoDataList_weekFight;
		}
	//end



		this.curCorpsBossLevel = _curCorpsBossLevel;
		this.CorpsBossInfoDataList = _CorpsBossInfoDataList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPS_BOSS_INFO;
	}
	
	public override string getEventType()
	{
		return CorpsbossGCHandler.GCCorpsBossInfoEvent;
	}
	

	public int getCurCorpsBossLevel(){
		return curCorpsBossLevel;
	}
		

	public CorpsBossInfoData[] getCorpsBossInfoDataList(){
		return CorpsBossInfoDataList;
	}


}
}