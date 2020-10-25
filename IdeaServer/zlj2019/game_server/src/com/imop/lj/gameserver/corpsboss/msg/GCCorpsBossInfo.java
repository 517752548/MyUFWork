package com.imop.lj.gameserver.corpsboss.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回当前队长或个人的boss情况
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsBossInfo extends GCMessage{
	
	/** 当前挑战boss进度 */
	private int curCorpsBossLevel;
	/** 地图玩家信息 */
	private com.imop.lj.common.model.corps.CorpsBossInfo[] CorpsBossInfoDataList;

	public GCCorpsBossInfo (){
	}
	
	public GCCorpsBossInfo (
			int curCorpsBossLevel,
			com.imop.lj.common.model.corps.CorpsBossInfo[] CorpsBossInfoDataList ){
			this.curCorpsBossLevel = curCorpsBossLevel;
			this.CorpsBossInfoDataList = CorpsBossInfoDataList;
	}

	@Override
	protected boolean readImpl() {

	// 当前挑战boss进度
	int _curCorpsBossLevel = readInteger();
	//end


	// 地图玩家信息
	int CorpsBossInfoDataListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsBossInfo[] _CorpsBossInfoDataList = new com.imop.lj.common.model.corps.CorpsBossInfo[CorpsBossInfoDataListSize];
	int CorpsBossInfoDataListIndex = 0;
	for(CorpsBossInfoDataListIndex=0; CorpsBossInfoDataListIndex<CorpsBossInfoDataListSize; CorpsBossInfoDataListIndex++){
		_CorpsBossInfoDataList[CorpsBossInfoDataListIndex] = new com.imop.lj.common.model.corps.CorpsBossInfo();
	// boss进度
	int _CorpsBossInfoDataList_bossLevel = readInteger();
	//end
	_CorpsBossInfoDataList[CorpsBossInfoDataListIndex].setBossLevel (_CorpsBossInfoDataList_bossLevel);

	// 可获得奖励次数
	int _CorpsBossInfoDataList_bossRewardNum = readInteger();
	//end
	_CorpsBossInfoDataList[CorpsBossInfoDataListIndex].setBossRewardNum (_CorpsBossInfoDataList_bossRewardNum);

	// 本周是否已打,1-已到,0-未打
	int _CorpsBossInfoDataList_weekFight = readInteger();
	//end
	_CorpsBossInfoDataList[CorpsBossInfoDataListIndex].setWeekFight (_CorpsBossInfoDataList_weekFight);
	}
	//end



		this.curCorpsBossLevel = _curCorpsBossLevel;
		this.CorpsBossInfoDataList = _CorpsBossInfoDataList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 当前挑战boss进度
	writeInteger(curCorpsBossLevel);


	// 地图玩家信息
	writeShort(CorpsBossInfoDataList.length);
	int CorpsBossInfoDataListIndex = 0;
	int CorpsBossInfoDataListSize = CorpsBossInfoDataList.length;
	for(CorpsBossInfoDataListIndex=0; CorpsBossInfoDataListIndex<CorpsBossInfoDataListSize; CorpsBossInfoDataListIndex++){

	int CorpsBossInfoDataList_bossLevel = CorpsBossInfoDataList[CorpsBossInfoDataListIndex].getBossLevel();

	// boss进度
	writeInteger(CorpsBossInfoDataList_bossLevel);

	int CorpsBossInfoDataList_bossRewardNum = CorpsBossInfoDataList[CorpsBossInfoDataListIndex].getBossRewardNum();

	// 可获得奖励次数
	writeInteger(CorpsBossInfoDataList_bossRewardNum);

	int CorpsBossInfoDataList_weekFight = CorpsBossInfoDataList[CorpsBossInfoDataListIndex].getWeekFight();

	// 本周是否已打,1-已到,0-未打
	writeInteger(CorpsBossInfoDataList_weekFight);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPS_BOSS_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPS_BOSS_INFO";
	}

	public int getCurCorpsBossLevel(){
		return curCorpsBossLevel;
	}
		
	public void setCurCorpsBossLevel(int curCorpsBossLevel){
		this.curCorpsBossLevel = curCorpsBossLevel;
	}

	public com.imop.lj.common.model.corps.CorpsBossInfo[] getCorpsBossInfoDataList(){
		return CorpsBossInfoDataList;
	}

	public void setCorpsBossInfoDataList(com.imop.lj.common.model.corps.CorpsBossInfo[] CorpsBossInfoDataList){
		this.CorpsBossInfoDataList = CorpsBossInfoDataList;
	}	
}