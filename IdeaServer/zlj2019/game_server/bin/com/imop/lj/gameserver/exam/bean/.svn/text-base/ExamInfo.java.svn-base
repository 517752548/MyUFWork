package com.imop.lj.gameserver.exam.bean;

import com.imop.lj.common.model.reward.RewardInfo;

public class ExamInfo {
	
	/**科举类型*/
	private Integer examType ;
	/**答题状态*/
	private Integer examState;
	/**答对题数*/
	private Integer rightNum;
	/**已答总题数*/
	private Integer totalNum;
	/**正在答的问题ID*/
	private Integer examId ;
	/**已经排除掉的选项*/
	private int[] excludeOptions;
	/**本次活动获得的奖励*/
	private RewardInfo rewardInfo;
	/**开始答题的时间戳*/
	private long timestamp ;
	/**答题剩余时间，毫秒*/
	private long leftTime;
	
	public ExamInfo() {
		super();
	}

	public ExamInfo(Integer examType, Integer examState, Integer rightNum,
			Integer totalNum, Integer examId, int[] excludeOptions,
			RewardInfo rewardInfo, long timestamp) {
		super();
		this.examType = examType;
		this.examState = examState;
		this.rightNum = rightNum;
		this.totalNum = totalNum;
		this.examId = examId;
		this.excludeOptions = excludeOptions;
		this.rewardInfo = rewardInfo;
		this.timestamp = timestamp;
	}





	public Integer getExamType() {
		return examType;
	}


	public void setExamType(Integer examType) {
		this.examType = examType;
	}


	public Integer getExamState() {
		return examState;
	}


	public void setExamState(Integer examState) {
		this.examState = examState;
	}


	public Integer getRightNum() {
		return rightNum;
	}

	public void setRightNum(Integer rightNum) {
		this.rightNum = rightNum;
	}

	public Integer getTotalNum() {
		return totalNum;
	}

	public void setTotalNum(Integer totalNum) {
		this.totalNum = totalNum;
	}

	public Integer getExamId() {
		return examId;
	}

	public void setExamId(Integer examId) {
		this.examId = examId;
	}



	public int[] getExcludeOptions() {
		return excludeOptions;
	}

	public void setExcludeOptions(int[] excludeOptions) {
		this.excludeOptions = excludeOptions;
	}

	public RewardInfo getRewardInfo() {
		return rewardInfo;
	}

 
	public void setRewardInfo(RewardInfo rewardInfo) {
		this.rewardInfo = rewardInfo;
	}


	public long getTimestamp() {
		return timestamp;
	}

	public void setTimestamp(long timestamp) {
		this.timestamp = timestamp;
	}

	public long getLeftTime() {
		return leftTime;
	}

	public void setLeftTime(long leftTime) {
		this.leftTime = leftTime;
	}

	
}