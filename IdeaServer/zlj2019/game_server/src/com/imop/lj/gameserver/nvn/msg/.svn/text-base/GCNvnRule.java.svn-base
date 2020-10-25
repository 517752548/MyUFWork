package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * nvn联赛规则
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnRule extends GCMessage{
	
	/** 等级 */
	private int level;
	/** 人数最低 */
	private int memberNum;
	/** 奖励名称 */
	private String[] showRewardNameList;
	/** 奖励内容 */
	private String[] showRewardList;

	public GCNvnRule (){
	}
	
	public GCNvnRule (
			int level,
			int memberNum,
			String[] showRewardNameList,
			String[] showRewardList ){
			this.level = level;
			this.memberNum = memberNum;
			this.showRewardNameList = showRewardNameList;
			this.showRewardList = showRewardList;
	}

	@Override
	protected boolean readImpl() {

	// 等级
	int _level = readInteger();
	//end


	// 人数最低
	int _memberNum = readInteger();
	//end


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



		this.level = _level;
		this.memberNum = _memberNum;
		this.showRewardNameList = _showRewardNameList;
		this.showRewardList = _showRewardList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 等级
	writeInteger(level);


	// 人数最低
	writeInteger(memberNum);


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
		return MessageType.GC_NVN_RULE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_NVN_RULE";
	}

	public int getLevel(){
		return level;
	}
		
	public void setLevel(int level){
		this.level = level;
	}

	public int getMemberNum(){
		return memberNum;
	}
		
	public void setMemberNum(int memberNum){
		this.memberNum = memberNum;
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