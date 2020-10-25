package com.imop.lj.gameserver.exam.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 科举考试信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCExamInfo extends GCMessage{
	
	/** 科举信息 */
	private com.imop.lj.gameserver.exam.bean.ExamInfo ExamInfo;

	public GCExamInfo (){
	}
	
	public GCExamInfo (
			com.imop.lj.gameserver.exam.bean.ExamInfo ExamInfo ){
			this.ExamInfo = ExamInfo;
	}

	@Override
	protected boolean readImpl() {
	// 科举信息
	com.imop.lj.gameserver.exam.bean.ExamInfo _ExamInfo = new com.imop.lj.gameserver.exam.bean.ExamInfo();

	// 申请的科举类型
	int _ExamInfo_examType = readInteger();
	//end
	_ExamInfo.setExamType (_ExamInfo_examType);

	// 申请的科举类型对应的运行状态
	int _ExamInfo_examState = readInteger();
	//end
	_ExamInfo.setExamState (_ExamInfo_examState);

	// 正确答题数目
	int _ExamInfo_rightNum = readInteger();
	//end
	_ExamInfo.setRightNum (_ExamInfo_rightNum);

	// 答题总数目
	int _ExamInfo_totalNum = readInteger();
	//end
	_ExamInfo.setTotalNum (_ExamInfo_totalNum);

	// 题目Id
	int _ExamInfo_examId = readInteger();
	//end
	_ExamInfo.setExamId (_ExamInfo_examId);

	// 已经排除的答案ID
	int ExamInfo_excludeOptionsSize = readUnsignedShort();
	int[] _ExamInfo_excludeOptions = new int[ExamInfo_excludeOptionsSize];
	int ExamInfo_excludeOptionsIndex = 0;
	for(ExamInfo_excludeOptionsIndex=0; ExamInfo_excludeOptionsIndex<ExamInfo_excludeOptionsSize; ExamInfo_excludeOptionsIndex++){
		_ExamInfo_excludeOptions[ExamInfo_excludeOptionsIndex] = readInteger();
	}//end
	_ExamInfo.setExcludeOptions (_ExamInfo_excludeOptions);
	// 本次奖励
	com.imop.lj.common.model.reward.RewardInfo _ExamInfo_rewardInfo = new com.imop.lj.common.model.reward.RewardInfo();

	// 奖励信息
	String _ExamInfo_rewardInfo_rewardStr = readString();
	//end
	_ExamInfo_rewardInfo.setRewardStr (_ExamInfo_rewardInfo_rewardStr);
	_ExamInfo.setRewardInfo (_ExamInfo_rewardInfo);

	// 时间戳
	long _ExamInfo_timestamp = readLong();
	//end
	_ExamInfo.setTimestamp (_ExamInfo_timestamp);

	// 答题剩余时间，毫秒
	long _ExamInfo_leftTime = readLong();
	//end
	_ExamInfo.setLeftTime (_ExamInfo_leftTime);



		this.ExamInfo = _ExamInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	int ExamInfo_examType = ExamInfo.getExamType ();

	// 申请的科举类型
	writeInteger(ExamInfo_examType);

	int ExamInfo_examState = ExamInfo.getExamState ();

	// 申请的科举类型对应的运行状态
	writeInteger(ExamInfo_examState);

	int ExamInfo_rightNum = ExamInfo.getRightNum ();

	// 正确答题数目
	writeInteger(ExamInfo_rightNum);

	int ExamInfo_totalNum = ExamInfo.getTotalNum ();

	// 答题总数目
	writeInteger(ExamInfo_totalNum);

	int ExamInfo_examId = ExamInfo.getExamId ();

	// 题目Id
	writeInteger(ExamInfo_examId);

	int[] ExamInfo_excludeOptions = ExamInfo.getExcludeOptions ();

	// 已经排除的答案ID
	writeShort(ExamInfo_excludeOptions.length);
	int ExamInfo_excludeOptionsSize = ExamInfo_excludeOptions.length;
	int ExamInfo_excludeOptionsIndex = 0;
	for(ExamInfo_excludeOptionsIndex=0; ExamInfo_excludeOptionsIndex<ExamInfo_excludeOptionsSize; ExamInfo_excludeOptionsIndex++){
		writeInteger(ExamInfo_excludeOptions [ ExamInfo_excludeOptionsIndex ]);
	}//end

	com.imop.lj.common.model.reward.RewardInfo ExamInfo_rewardInfo = ExamInfo.getRewardInfo ();

	String ExamInfo_rewardInfo_rewardStr = ExamInfo_rewardInfo.getRewardStr ();

	// 奖励信息
	writeString(ExamInfo_rewardInfo_rewardStr);

	long ExamInfo_timestamp = ExamInfo.getTimestamp ();

	// 时间戳
	writeLong(ExamInfo_timestamp);

	long ExamInfo_leftTime = ExamInfo.getLeftTime ();

	// 答题剩余时间，毫秒
	writeLong(ExamInfo_leftTime);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EXAM_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EXAM_INFO";
	}

	public com.imop.lj.gameserver.exam.bean.ExamInfo getExamInfo(){
		return ExamInfo;
	}
		
	public void setExamInfo(com.imop.lj.gameserver.exam.bean.ExamInfo ExamInfo){
		this.ExamInfo = ExamInfo;
	}
}