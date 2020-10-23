
using System;
namespace app.net
{
/**
 * 科举考试信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCExamInfo :BaseMessage
{
	/** 科举信息 */
	private ExamInfo ExamInfo;

	public GCExamInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 科举信息
	ExamInfo _ExamInfo = new ExamInfo();
	// 申请的科举类型
	int _ExamInfo_examType = ReadInt();	_ExamInfo.examType = _ExamInfo_examType;
	// 申请的科举类型对应的运行状态
	int _ExamInfo_examState = ReadInt();	_ExamInfo.examState = _ExamInfo_examState;
	// 正确答题数目
	int _ExamInfo_rightNum = ReadInt();	_ExamInfo.rightNum = _ExamInfo_rightNum;
	// 答题总数目
	int _ExamInfo_totalNum = ReadInt();	_ExamInfo.totalNum = _ExamInfo_totalNum;
	// 题目Id
	int _ExamInfo_examId = ReadInt();	_ExamInfo.examId = _ExamInfo_examId;
	// 已经排除的答案ID
	int ExamInfo_excludeOptionsSize = ReadShort();
	int[] _ExamInfo_excludeOptions = new int[ExamInfo_excludeOptionsSize];
	int ExamInfo_excludeOptionsIndex = 0;
	for(ExamInfo_excludeOptionsIndex=0; ExamInfo_excludeOptionsIndex<ExamInfo_excludeOptionsSize; ExamInfo_excludeOptionsIndex++){
		_ExamInfo_excludeOptions[ExamInfo_excludeOptionsIndex] = ReadInt();
	}//end
		_ExamInfo.excludeOptions = _ExamInfo_excludeOptions;
	// 本次奖励
	RewardInfoData _ExamInfo_rewardInfo = new RewardInfoData();
	// 奖励信息
	string _ExamInfo_rewardInfo_rewardStr = ReadString();	_ExamInfo_rewardInfo.rewardStr = _ExamInfo_rewardInfo_rewardStr;
	_ExamInfo.rewardInfo = _ExamInfo_rewardInfo;
	// 时间戳
	long _ExamInfo_timestamp = ReadLong();	_ExamInfo.timestamp = _ExamInfo_timestamp;
	// 答题剩余时间，毫秒
	long _ExamInfo_leftTime = ReadLong();	_ExamInfo.leftTime = _ExamInfo_leftTime;



		this.ExamInfo = _ExamInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_EXAM_INFO;
	}
	
	public override string getEventType()
	{
		return ExamGCHandler.GCExamInfoEvent;
	}
	

	public ExamInfo getExamInfo(){
		return ExamInfo;
	}
		

}
}