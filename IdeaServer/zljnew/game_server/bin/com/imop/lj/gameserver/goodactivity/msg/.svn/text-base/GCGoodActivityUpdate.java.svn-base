package com.imop.lj.gameserver.goodactivity.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 精彩活动更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGoodActivityUpdate extends GCMessage{
	
	/** 功能id */
	private int funcId;
	/** 精彩活动信息 */
	private com.imop.lj.common.model.goodactivity.GoodActivityInfo goodActivityInfo;

	public GCGoodActivityUpdate (){
	}
	
	public GCGoodActivityUpdate (
			int funcId,
			com.imop.lj.common.model.goodactivity.GoodActivityInfo goodActivityInfo ){
			this.funcId = funcId;
			this.goodActivityInfo = goodActivityInfo;
	}

	@Override
	protected boolean readImpl() {

	// 功能id
	int _funcId = readInteger();
	//end

	// 精彩活动信息
	com.imop.lj.common.model.goodactivity.GoodActivityInfo _goodActivityInfo = new com.imop.lj.common.model.goodactivity.GoodActivityInfo();

	// 活动唯一Id
	long _goodActivityInfo_activityId = readLong();
	//end
	_goodActivityInfo.setActivityId (_goodActivityInfo_activityId);

	// 活动类型Id
	int _goodActivityInfo_typeId = readInteger();
	//end
	_goodActivityInfo.setTypeId (_goodActivityInfo_typeId);

	// 活动图标
	int _goodActivityInfo_icon = readInteger();
	//end
	_goodActivityInfo.setIcon (_goodActivityInfo_icon);

	// 名称图标
	int _goodActivityInfo_nameIcon = readInteger();
	//end
	_goodActivityInfo.setNameIcon (_goodActivityInfo_nameIcon);

	// 标题图标
	int _goodActivityInfo_titleIcon = readInteger();
	//end
	_goodActivityInfo.setTitleIcon (_goodActivityInfo_titleIcon);

	// 名称
	String _goodActivityInfo_name = readString();
	//end
	_goodActivityInfo.setName (_goodActivityInfo_name);

	// 描述 
	String _goodActivityInfo_desc = readString();
	//end
	_goodActivityInfo.setDesc (_goodActivityInfo_desc);

	// 是否新活动，1新，0否
	int _goodActivityInfo_isNew = readInteger();
	//end
	_goodActivityInfo.setIsNew (_goodActivityInfo_isNew);

	// 活动开始时间
	long _goodActivityInfo_startTime = readLong();
	//end
	_goodActivityInfo.setStartTime (_goodActivityInfo_startTime);

	// 活动结束时间
	long _goodActivityInfo_endTime = readLong();
	//end
	_goodActivityInfo.setEndTime (_goodActivityInfo_endTime);

	// 是否有未领取的奖励，1是，0否
	int _goodActivityInfo_hasUnGotBonus = readInteger();
	//end
	_goodActivityInfo.setHasUnGotBonus (_goodActivityInfo_hasUnGotBonus);

	// 倒计时描述
	String _goodActivityInfo_countDownTimeDesc = readString();
	//end
	_goodActivityInfo.setCountDownTimeDesc (_goodActivityInfo_countDownTimeDesc);

	// 倒计时时间
	long _goodActivityInfo_countDownTime = readLong();
	//end
	_goodActivityInfo.setCountDownTime (_goodActivityInfo_countDownTime);

	// 自身相关信息
	String _goodActivityInfo_selfInfo = readString();
	//end
	_goodActivityInfo.setSelfInfo (_goodActivityInfo_selfInfo);

	// 活动目标json串
	String _goodActivityInfo_targetInfo = readString();
	//end
	_goodActivityInfo.setTargetInfo (_goodActivityInfo_targetInfo);

	// 目标类型，前端显示用
	int _goodActivityInfo_showTargetType = readInteger();
	//end
	_goodActivityInfo.setShowTargetType (_goodActivityInfo_showTargetType);

	// 最近开启的
	int _goodActivityInfo_isRecentOpen = readInteger();
	//end
	_goodActivityInfo.setIsRecentOpen (_goodActivityInfo_isRecentOpen);

	// 最近结束的
	int _goodActivityInfo_isRecentClose = readInteger();
	//end
	_goodActivityInfo.setIsRecentClose (_goodActivityInfo_isRecentClose);

	// 日志列表 
	int goodActivityInfo_logListSize = readUnsignedShort();
	String[] _goodActivityInfo_logList = new String[goodActivityInfo_logListSize];
	int goodActivityInfo_logListIndex = 0;
	for(goodActivityInfo_logListIndex=0; goodActivityInfo_logListIndex<goodActivityInfo_logListSize; goodActivityInfo_logListIndex++){
		_goodActivityInfo_logList[goodActivityInfo_logListIndex] = readString();
	}//end
	_goodActivityInfo.setLogList (_goodActivityInfo_logList);

	// 是否需要隐藏，0否，1是
	int _goodActivityInfo_needHide = readInteger();
	//end
	_goodActivityInfo.setNeedHide (_goodActivityInfo_needHide);



		this.funcId = _funcId;
		this.goodActivityInfo = _goodActivityInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 功能id
	writeInteger(funcId);


	long goodActivityInfo_activityId = goodActivityInfo.getActivityId ();

	// 活动唯一Id
	writeLong(goodActivityInfo_activityId);

	int goodActivityInfo_typeId = goodActivityInfo.getTypeId ();

	// 活动类型Id
	writeInteger(goodActivityInfo_typeId);

	int goodActivityInfo_icon = goodActivityInfo.getIcon ();

	// 活动图标
	writeInteger(goodActivityInfo_icon);

	int goodActivityInfo_nameIcon = goodActivityInfo.getNameIcon ();

	// 名称图标
	writeInteger(goodActivityInfo_nameIcon);

	int goodActivityInfo_titleIcon = goodActivityInfo.getTitleIcon ();

	// 标题图标
	writeInteger(goodActivityInfo_titleIcon);

	String goodActivityInfo_name = goodActivityInfo.getName ();

	// 名称
	writeString(goodActivityInfo_name);

	String goodActivityInfo_desc = goodActivityInfo.getDesc ();

	// 描述 
	writeString(goodActivityInfo_desc);

	int goodActivityInfo_isNew = goodActivityInfo.getIsNew ();

	// 是否新活动，1新，0否
	writeInteger(goodActivityInfo_isNew);

	long goodActivityInfo_startTime = goodActivityInfo.getStartTime ();

	// 活动开始时间
	writeLong(goodActivityInfo_startTime);

	long goodActivityInfo_endTime = goodActivityInfo.getEndTime ();

	// 活动结束时间
	writeLong(goodActivityInfo_endTime);

	int goodActivityInfo_hasUnGotBonus = goodActivityInfo.getHasUnGotBonus ();

	// 是否有未领取的奖励，1是，0否
	writeInteger(goodActivityInfo_hasUnGotBonus);

	String goodActivityInfo_countDownTimeDesc = goodActivityInfo.getCountDownTimeDesc ();

	// 倒计时描述
	writeString(goodActivityInfo_countDownTimeDesc);

	long goodActivityInfo_countDownTime = goodActivityInfo.getCountDownTime ();

	// 倒计时时间
	writeLong(goodActivityInfo_countDownTime);

	String goodActivityInfo_selfInfo = goodActivityInfo.getSelfInfo ();

	// 自身相关信息
	writeString(goodActivityInfo_selfInfo);

	String goodActivityInfo_targetInfo = goodActivityInfo.getTargetInfo ();

	// 活动目标json串
	writeString(goodActivityInfo_targetInfo);

	int goodActivityInfo_showTargetType = goodActivityInfo.getShowTargetType ();

	// 目标类型，前端显示用
	writeInteger(goodActivityInfo_showTargetType);

	int goodActivityInfo_isRecentOpen = goodActivityInfo.getIsRecentOpen ();

	// 最近开启的
	writeInteger(goodActivityInfo_isRecentOpen);

	int goodActivityInfo_isRecentClose = goodActivityInfo.getIsRecentClose ();

	// 最近结束的
	writeInteger(goodActivityInfo_isRecentClose);

	String[] goodActivityInfo_logList = goodActivityInfo.getLogList ();

	// 日志列表 
	writeShort(goodActivityInfo_logList.length);
	int goodActivityInfo_logListSize = goodActivityInfo_logList.length;
	int goodActivityInfo_logListIndex = 0;
	for(goodActivityInfo_logListIndex=0; goodActivityInfo_logListIndex<goodActivityInfo_logListSize; goodActivityInfo_logListIndex++){
		writeString(goodActivityInfo_logList [ goodActivityInfo_logListIndex ]);
	}//end

	int goodActivityInfo_needHide = goodActivityInfo.getNeedHide ();

	// 是否需要隐藏，0否，1是
	writeInteger(goodActivityInfo_needHide);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_GOOD_ACTIVITY_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GOOD_ACTIVITY_UPDATE";
	}

	public int getFuncId(){
		return funcId;
	}
		
	public void setFuncId(int funcId){
		this.funcId = funcId;
	}

	public com.imop.lj.common.model.goodactivity.GoodActivityInfo getGoodActivityInfo(){
		return goodActivityInfo;
	}
		
	public void setGoodActivityInfo(com.imop.lj.common.model.goodactivity.GoodActivityInfo goodActivityInfo){
		this.goodActivityInfo = goodActivityInfo;
	}
}