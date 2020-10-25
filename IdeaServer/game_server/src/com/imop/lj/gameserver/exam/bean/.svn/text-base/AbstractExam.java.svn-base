package com.imop.lj.gameserver.exam.bean;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exam.ExamDef;
import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.exam.msg.GCExamInfo;
import com.imop.lj.gameserver.exam.template.ExamSpecialRewardConditionTemplate;
import com.imop.lj.gameserver.exam.template.ExamTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.task.TaskDef;

public abstract class AbstractExam {
	/** 科举类型*/
	protected ExamType type;
	
	/**考试细节信息，用于推送给客户端*/
	protected ExamInfo examInfo ;
	
	/** 用户已答题 key=题目templateID value=是否正确*/
	protected HashMap<Integer,Boolean> results = Maps.newHashMap();
	
	/**考试细节信息，用于推送给客户端*/
	protected Reward reward ;

	/**奖励信息是否单独发送给客户端*/
	protected boolean rewardNeedNotify = true;
	
	/**一次使用一个特殊道具*/
	protected Integer useNum = 1;
	
	public ExamType getType() {
		return type;
	}

	public void setType(ExamType type) {
		this.type = type;
	}
	
	public AbstractExam() {
		super();
	}
	
	public AbstractExam(ExamDef.ExamType et) {
		this.type = et;
		init(et);
	}
	
	/**
	 * 初始化一个新的ExamInfo
	 * @param et
	 */
	private void init(ExamDef.ExamType et){
		this.examInfo = new ExamInfo();
		this.examInfo.setExamType(et.index);
		this.examInfo.setExamState(ExamDef.ExamState.PREPARE.index);
		this.examInfo.setRightNum(0);
		this.examInfo.setTotalNum(0);
		this.examInfo.setExamId(null);
		this.examInfo.setExcludeOptions(new int[]{});
		this.examInfo.setRewardInfo(Globals.getRewardService().createEmptyReward().toRewardInfo());
		this.examInfo.setTimestamp(0);
		reward = Globals.getRewardService().createEmptyReward();
	}
	
	
	public abstract void examApply(Human human, Integer examType);
	public abstract void examChoseAnswer(Human human, Integer examType, Integer choseAnswer);
	public abstract void examUseItem(Human human, Integer examType, Integer itemId);
	public abstract Map<Integer, ExamTemplate> getExamTemplateMap();
	public abstract Map<Integer, ExamSpecialRewardConditionTemplate> getExamSpecialRewardMap();
	public abstract boolean isOpening(Human human);
	public abstract boolean canDo(Human human);
	public abstract void doBehavior(Human human);
	public abstract GCExamInfo buildGCExamInfo(Human human, AbstractExam exam);
	
	/**
	 * 科举的任务监听
	 * @param human
	 */
	public void onExamNumRecordDesc(Human human){
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.ENTER_EXAM, 0, 1);
	}
	
	/** 生成一个随机的不在参数中的ExamTemplateId*/
	public Integer getARandomExamTemplate(AbstractExam exam, Map<Integer, ExamTemplate> examTemplateMap){
		List<Integer> resList = new ArrayList<Integer>();
		resList.addAll(examTemplateMap.keySet());
		for(Integer tpId : exam.getResults().keySet()){
			if(examTemplateMap.containsKey(tpId)){
				resList.remove(tpId);
			}
		}
		if(resList.size()>0){
			int res = RandomUtils.betweenInt(0, resList.size()-1, true);
			return resList.get(res);
		}
		return null;
	}
	
	/**
	 * 触发特殊奖励
	 * @param rightAnswerNum
	 * @return rewardId
	 */
	public Integer triggerTheSpecialReward(Integer rightAnswerNum, Map<Integer, ExamSpecialRewardConditionTemplate> examSpecialRewardMap){
		for(Entry<Integer, ExamSpecialRewardConditionTemplate> entry : examSpecialRewardMap.entrySet()){
			if(entry.getValue().getRightAnswerNum()==rightAnswerNum){
				return entry.getValue().getRewardId();
			}
		}
		return null;
	}
	

	/**
	 * 得到排除的答案数组*/
	public int[] passedAnswer(Exam exam){
		if(exam==null){
			return null;
		}
		if(exam.getExamInfo()==null){
			return null;
		}
		ExamTemplate et = Globals.getTemplateCacheService().getExamTemplateCache().getExamTplById(exam.getExamInfo().getExamId());
		if(et == null){
			Loggers.examLogger.error("getExamTplById is null! examId=" + exam.getExamInfo().getExamId());
			return null;
		}
		List<Integer> res = new ArrayList<Integer>();
		if(et.getFirstAnswerID() != et.getRightAnswerID()){
			res.add(et.getFirstAnswerID());
		}
		if(et.getSecendAnswerID() != et.getRightAnswerID()){
			res.add(et.getSecendAnswerID());
		}
		if(et.getThirdAnswerID() != et.getRightAnswerID()){
			res.add(et.getThirdAnswerID());
		}
		if(et.getFourthAnswerID() != et.getRightAnswerID()){
			res.add(et.getFourthAnswerID());
		}
		Integer index = RandomUtils.betweenInt(0, res.size()-1, true);
		res.remove(res.get(index));
		int[] resArr = {0,0};
		for(int i =0;i<res.size();i++){
			resArr[i] = res.get(i);
		}
		return resArr;
	}
	
	
	public ExamInfo getExamInfo() {
		return examInfo;
	}

	public void setExamInfo(ExamInfo examInfo) {
		this.examInfo = examInfo;
	}


	/**
	 * 开始答题
	 * @return
	 */
	public boolean startExam(){
		if(this.examInfo.getExamState() == ExamDef.ExamState.PREPARE.index){
			this.examInfo.setExamState(ExamDef.ExamState.EXAMING.index);
			this.examInfo.setTimestamp(Globals.getTimeService().now());
			return true;
		}
		return false;
	}
	
	
	public AbstractExam(ExamType examType, Integer examState, Integer rightNum,
			Integer totalNum, Integer examId, int[] excludeOptions,
			RewardInfo rewardInfo, long timestamp) {
		super();
		this.examInfo = new ExamInfo(examType.index, examState, rightNum,
				 totalNum,  examId,  excludeOptions,
				 rewardInfo,  timestamp);
	}


	public HashMap<Integer, Boolean> getResults() {
		return results;
	}


	public void setResults(HashMap<Integer, Boolean> results) {
		this.results = results;
	}


	public Reward getReward() {
		return reward;
	}


	public void setReward(Reward reward) {
		this.reward = reward;
	}

	@Override
	public String toString() {
		return "AbstractExam [type=" + type + ", examInfo=" + examInfo + ", results=" + results + ", reward=" + reward
				+ "]";
	}
	
}
