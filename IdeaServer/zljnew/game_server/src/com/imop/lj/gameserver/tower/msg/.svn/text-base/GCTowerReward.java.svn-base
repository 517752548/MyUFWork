package com.imop.lj.gameserver.tower.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回查看通天塔每层的奖励
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTowerReward extends GCMessage{
	
	/** 奖励名称 */
	private String[] showRewardNameList;
	/** 奖励内容 */
	private String[] showRewardList;

	public GCTowerReward (){
	}
	
	public GCTowerReward (
			String[] showRewardNameList,
			String[] showRewardList ){
			this.showRewardNameList = showRewardNameList;
			this.showRewardList = showRewardList;
	}

	@Override
	protected boolean readImpl() {

	// 奖励名称
	int showRewardNameListSize = readUnsignedShort();
	String[] _showRewardNameList = new String[showRewardNameListSize];
	int showRewardNameListIndex = 0;
	for(showRewardNameListIndex=0; showRewardNameListIndex<showRewardNameListSize; showRewardNameListIndex++){
		_showRewardNameList[showRewardNameListIndex] = readString();
	}//end


	// 奖励内容
	int showRewardListSize = readUnsignedShort();
	String[] _showRewardList = new String[showRewardListSize];
	int showRewardListIndex = 0;
	for(showRewardListIndex=0; showRewardListIndex<showRewardListSize; showRewardListIndex++){
		_showRewardList[showRewardListIndex] = readString();
	}//end



		this.showRewardNameList = _showRewardNameList;
		this.showRewardList = _showRewardList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 奖励名称
	writeShort(showRewardNameList.length);
	int showRewardNameListSize = showRewardNameList.length;
	int showRewardNameListIndex = 0;
	for(showRewardNameListIndex=0; showRewardNameListIndex<showRewardNameListSize; showRewardNameListIndex++){
		writeString(showRewardNameList [ showRewardNameListIndex ]);
	}//end


	// 奖励内容
	writeShort(showRewardList.length);
	int showRewardListSize = showRewardList.length;
	int showRewardListIndex = 0;
	for(showRewardListIndex=0; showRewardListIndex<showRewardListSize; showRewardListIndex++){
		writeString(showRewardList [ showRewardListIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TOWER_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TOWER_REWARD";
	}

	public String[] getShowRewardNameList(){
		return showRewardNameList;
	}

	public void setShowRewardNameList(String[] showRewardNameList){
		this.showRewardNameList = showRewardNameList;
	}	

	public String[] getShowRewardList(){
		return showRewardList;
	}

	public void setShowRewardList(String[] showRewardList){
		this.showRewardList = showRewardList;
	}	
}