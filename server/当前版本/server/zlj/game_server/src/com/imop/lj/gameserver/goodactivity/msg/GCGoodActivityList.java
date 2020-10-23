package com.imop.lj.gameserver.goodactivity.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 打开精彩活动列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGoodActivityList extends GCMessage{
	
	/** 功能id */
	private int funcId;
	/** 精彩活动信息列表 */
	private com.imop.lj.common.model.goodactivity.GoodActivityInfo[] goodActivityList;

	public GCGoodActivityList (){
	}
	
	public GCGoodActivityList (
			int funcId,
			com.imop.lj.common.model.goodactivity.GoodActivityInfo[] goodActivityList ){
			this.funcId = funcId;
			this.goodActivityList = goodActivityList;
	}

	@Override
	protected boolean readImpl() {

	// 功能id
	int _funcId = readInteger();
	//end


	// 精彩活动信息列表
	int goodActivityListSize = readUnsignedShort();
	com.imop.lj.common.model.goodactivity.GoodActivityInfo[] _goodActivityList = new com.imop.lj.common.model.goodactivity.GoodActivityInfo[goodActivityListSize];
	int goodActivityListIndex = 0;
	for(goodActivityListIndex=0; goodActivityListIndex<goodActivityListSize; goodActivityListIndex++){
		_goodActivityList[goodActivityListIndex] = new com.imop.lj.common.model.goodactivity.GoodActivityInfo();
	// 活动唯一Id
	long _goodActivityList_activityId = readLong();
	//end
	_goodActivityList[goodActivityListIndex].setActivityId (_goodActivityList_activityId);

	// 活动类型Id
	int _goodActivityList_typeId = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setTypeId (_goodActivityList_typeId);

	// 活动图标
	int _goodActivityList_icon = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setIcon (_goodActivityList_icon);

	// 名称图标
	int _goodActivityList_nameIcon = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setNameIcon (_goodActivityList_nameIcon);

	// 标题图标
	int _goodActivityList_titleIcon = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setTitleIcon (_goodActivityList_titleIcon);

	// 名称
	String _goodActivityList_name = readString();
	//end
	_goodActivityList[goodActivityListIndex].setName (_goodActivityList_name);

	// 描述 
	String _goodActivityList_desc = readString();
	//end
	_goodActivityList[goodActivityListIndex].setDesc (_goodActivityList_desc);

	// 是否新活动，1新，0否
	int _goodActivityList_isNew = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setIsNew (_goodActivityList_isNew);

	// 活动开始时间
	long _goodActivityList_startTime = readLong();
	//end
	_goodActivityList[goodActivityListIndex].setStartTime (_goodActivityList_startTime);

	// 活动结束时间
	long _goodActivityList_endTime = readLong();
	//end
	_goodActivityList[goodActivityListIndex].setEndTime (_goodActivityList_endTime);

	// 是否有未领取的奖励，1是，0否
	int _goodActivityList_hasUnGotBonus = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setHasUnGotBonus (_goodActivityList_hasUnGotBonus);

	// 倒计时描述
	String _goodActivityList_countDownTimeDesc = readString();
	//end
	_goodActivityList[goodActivityListIndex].setCountDownTimeDesc (_goodActivityList_countDownTimeDesc);

	// 倒计时时间
	long _goodActivityList_countDownTime = readLong();
	//end
	_goodActivityList[goodActivityListIndex].setCountDownTime (_goodActivityList_countDownTime);

	// 自身相关信息
	String _goodActivityList_selfInfo = readString();
	//end
	_goodActivityList[goodActivityListIndex].setSelfInfo (_goodActivityList_selfInfo);

	// 活动目标json串
	String _goodActivityList_targetInfo = readString();
	//end
	_goodActivityList[goodActivityListIndex].setTargetInfo (_goodActivityList_targetInfo);

	// 目标类型，前端显示用
	int _goodActivityList_showTargetType = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setShowTargetType (_goodActivityList_showTargetType);

	// 最近开启的
	int _goodActivityList_isRecentOpen = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setIsRecentOpen (_goodActivityList_isRecentOpen);

	// 最近结束的
	int _goodActivityList_isRecentClose = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setIsRecentClose (_goodActivityList_isRecentClose);

	// 日志列表 
	int goodActivityList_logListSize = readUnsignedShort();
	String[] _goodActivityList_logList = new String[goodActivityList_logListSize];
	int goodActivityList_logListIndex = 0;
	for(goodActivityList_logListIndex=0; goodActivityList_logListIndex<goodActivityList_logListSize; goodActivityList_logListIndex++){
		_goodActivityList_logList[goodActivityList_logListIndex] = readString();
	}//end
	_goodActivityList[goodActivityListIndex].setLogList (_goodActivityList_logList);

	// 是否需要隐藏，0否，1是
	int _goodActivityList_needHide = readInteger();
	//end
	_goodActivityList[goodActivityListIndex].setNeedHide (_goodActivityList_needHide);
	}
	//end



		this.funcId = _funcId;
		this.goodActivityList = _goodActivityList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 功能id
	writeInteger(funcId);


	// 精彩活动信息列表
	writeShort(goodActivityList.length);
	int goodActivityListIndex = 0;
	int goodActivityListSize = goodActivityList.length;
	for(goodActivityListIndex=0; goodActivityListIndex<goodActivityListSize; goodActivityListIndex++){

	long goodActivityList_activityId = goodActivityList[goodActivityListIndex].getActivityId();

	// 活动唯一Id
	writeLong(goodActivityList_activityId);

	int goodActivityList_typeId = goodActivityList[goodActivityListIndex].getTypeId();

	// 活动类型Id
	writeInteger(goodActivityList_typeId);

	int goodActivityList_icon = goodActivityList[goodActivityListIndex].getIcon();

	// 活动图标
	writeInteger(goodActivityList_icon);

	int goodActivityList_nameIcon = goodActivityList[goodActivityListIndex].getNameIcon();

	// 名称图标
	writeInteger(goodActivityList_nameIcon);

	int goodActivityList_titleIcon = goodActivityList[goodActivityListIndex].getTitleIcon();

	// 标题图标
	writeInteger(goodActivityList_titleIcon);

	String goodActivityList_name = goodActivityList[goodActivityListIndex].getName();

	// 名称
	writeString(goodActivityList_name);

	String goodActivityList_desc = goodActivityList[goodActivityListIndex].getDesc();

	// 描述 
	writeString(goodActivityList_desc);

	int goodActivityList_isNew = goodActivityList[goodActivityListIndex].getIsNew();

	// 是否新活动，1新，0否
	writeInteger(goodActivityList_isNew);

	long goodActivityList_startTime = goodActivityList[goodActivityListIndex].getStartTime();

	// 活动开始时间
	writeLong(goodActivityList_startTime);

	long goodActivityList_endTime = goodActivityList[goodActivityListIndex].getEndTime();

	// 活动结束时间
	writeLong(goodActivityList_endTime);

	int goodActivityList_hasUnGotBonus = goodActivityList[goodActivityListIndex].getHasUnGotBonus();

	// 是否有未领取的奖励，1是，0否
	writeInteger(goodActivityList_hasUnGotBonus);

	String goodActivityList_countDownTimeDesc = goodActivityList[goodActivityListIndex].getCountDownTimeDesc();

	// 倒计时描述
	writeString(goodActivityList_countDownTimeDesc);

	long goodActivityList_countDownTime = goodActivityList[goodActivityListIndex].getCountDownTime();

	// 倒计时时间
	writeLong(goodActivityList_countDownTime);

	String goodActivityList_selfInfo = goodActivityList[goodActivityListIndex].getSelfInfo();

	// 自身相关信息
	writeString(goodActivityList_selfInfo);

	String goodActivityList_targetInfo = goodActivityList[goodActivityListIndex].getTargetInfo();

	// 活动目标json串
	writeString(goodActivityList_targetInfo);

	int goodActivityList_showTargetType = goodActivityList[goodActivityListIndex].getShowTargetType();

	// 目标类型，前端显示用
	writeInteger(goodActivityList_showTargetType);

	int goodActivityList_isRecentOpen = goodActivityList[goodActivityListIndex].getIsRecentOpen();

	// 最近开启的
	writeInteger(goodActivityList_isRecentOpen);

	int goodActivityList_isRecentClose = goodActivityList[goodActivityListIndex].getIsRecentClose();

	// 最近结束的
	writeInteger(goodActivityList_isRecentClose);

	String[] goodActivityList_logList = goodActivityList[goodActivityListIndex].getLogList();

	// 日志列表 
	writeShort(goodActivityList_logList.length);
	int goodActivityList_logListSize = goodActivityList_logList.length;
	int goodActivityList_logListIndex = 0;
	for(goodActivityList_logListIndex=0; goodActivityList_logListIndex<goodActivityList_logListSize; goodActivityList_logListIndex++){
		writeString(goodActivityList_logList [ goodActivityList_logListIndex ]);
	}//end

	int goodActivityList_needHide = goodActivityList[goodActivityListIndex].getNeedHide();

	// 是否需要隐藏，0否，1是
	writeInteger(goodActivityList_needHide);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_GOOD_ACTIVITY_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GOOD_ACTIVITY_LIST";
	}

	public int getFuncId(){
		return funcId;
	}
		
	public void setFuncId(int funcId){
		this.funcId = funcId;
	}

	public com.imop.lj.common.model.goodactivity.GoodActivityInfo[] getGoodActivityList(){
		return goodActivityList;
	}

	public void setGoodActivityList(com.imop.lj.common.model.goodactivity.GoodActivityInfo[] goodActivityList){
		this.goodActivityList = goodActivityList;
	}	
}