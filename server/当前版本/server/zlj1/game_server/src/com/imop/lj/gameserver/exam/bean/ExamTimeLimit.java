package com.imop.lj.gameserver.exam.bean;

import java.util.HashMap;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.gameserver.activity.function.ActivityDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exam.ExamDef;
import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.exam.msg.GCExamApply;
import com.imop.lj.gameserver.exam.msg.GCExamChose;
import com.imop.lj.gameserver.exam.msg.GCExamInfo;
import com.imop.lj.gameserver.exam.template.ExamSpecialRewardConditionTemplate;
import com.imop.lj.gameserver.exam.template.ExamTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef;

/**
 * 限时活动答题 
 */
public class ExamTimeLimit extends AbstractExam {

	public ExamTimeLimit(ExamDef.ExamType et) {
		super(et);
	}

	@Override
	public void examApply(Human human, Integer examType) {
		//1.判断科举是否已经开启
		if(!this.isOpening(human)){
			human.sendMessage(new GCExamApply(examType,ResultTypes.FAIL.getIndex()));
			return ;
		}
		//2.判断科举类型是否合法
		if(examType==null||examType<0||ExamType.valueOf(examType)==null){
			Loggers.examLogger.error("examType is wrong! charId=" + 
					human.getCharId() + ";petId=" + human.getUUID());
			return ;
		}
		//答题限制，最多答10道题
		if (!canDo(human)) {
			human.sendErrorMessage(LangConstants.EXAM_IS_FINISHIED);
			return ;
		}
		//3.判断玩家是否已经申请限时答题
		if(Globals.getExamService().getExamMap().containsKey(human.getUUID())){
			if(Globals.getExamService().getExamMap().get(human.getUUID()).containsKey(ExamType.TIMELIMIT)){
				human.sendMessage(buildGCExamInfo(human, (ExamTimeLimit)Globals.getExamService().getExamMap().get(human.getUUID()).get(ExamType.TIMELIMIT)));
				human.sendMessage(new GCExamApply(examType,ResultTypes.SUCCESS.getIndex()));
				return ;
			}
		}
		//4.创建一个新Exam
		ExamTimeLimit exam = new ExamTimeLimit(ExamType.TIMELIMIT);
		//5.开始答题
		if(!exam.startExam()){
			Loggers.examLogger.error("examStart fail! charId=" + 
					human.getCharId() + ";petId=" + human.getUUID());
			return ;
		}
		exam.getExamInfo().setExamId(this.getARandomExamTemplate(exam, getExamTemplateMap()));
		Map<ExamType,AbstractExam> typeMap = Maps.newHashMap();
		typeMap.put(ExamType.TIMELIMIT, exam);
		Globals.getExamService().getExamMap().put(human.getUUID(), typeMap);
		//6.推送消息
		human.sendMessage(buildGCExamInfo(human, exam));
		human.sendMessage(new GCExamApply(examType,ResultTypes.SUCCESS.getIndex()));
		
		//领取成功
		human.sendErrorMessage(LangConstants.TIMELIMIT_ACCEPT_OK);
		
		//任务计数
		onExamNumRecordDesc(human);
	}
		

	@Override
	public void examChoseAnswer(Human human, Integer examType, Integer choseAnswer) {
		//1.判断科举是否已经开启
		if(!this.isOpening(human)){
			human.sendMessage(new GCExamChose(examType,ResultTypes.FAIL.getIndex()));
			return ;
		}
		//2.判断科举类型是否合法
		if(examType==null||examType<0||ExamType.valueOf(examType)==null||ExamType.valueOf(examType)==ExamType.NULL){
			Loggers.examLogger.error("examType is wrong! charId=" + 
					human.getCharId() + ";petId=" + human.getUUID());
			return ;
		}
		//2.判断选择的答案是否合法
		if(choseAnswer==null||choseAnswer<0){
			Loggers.examLogger.error("exam choseAnswer is wrong! charId=" + 
					human.getCharId() + ";petId=" + human.getUUID());
			return ;
		}
		//4.判断玩家是否申请过科举
		if(!Globals.getExamService().getExamMap().containsKey(human.getUUID())){
			if(!Globals.getExamService().getExamMap().get(human.getUUID()).containsKey(ExamType.TIMELIMIT)){
				Loggers.examLogger.error("player was not apply exam yet! charId=" + 
						human.getCharId() + ";petId=" + human.getUUID());
				return ;
			}
		}
		//5.判断现在的状态是否是正在答题
		ExamTimeLimit exam = (ExamTimeLimit) Globals.getExamService().getExamMap().get(human.getUUID()).get(ExamType.TIMELIMIT);
		if(exam == null){
			Loggers.examLogger.error("getExamMap retuan null! charId=" + human.getCharId());
			return;
		}
		if(exam.getExamInfo().getExamState() != ExamDef.ExamState.EXAMING.index){
			human.sendErrorMessage(LangConstants.EXAM_IS_FINISHIED);
			return ;
		}
		//答题限制，最多答10道题
		if (!canDo(human)) {
			human.sendErrorMessage(LangConstants.EXAM_IS_FINISHIED);
			return ;
		}
		//6.答题
		if(exam.getExamInfo().getTotalNum()>=0 && exam.getExamInfo().getTotalNum()<Globals.getGameConstants().getQuestionNumOfTimeLimitExamination()){
			//1.完成本次题目
			
			ExamTemplate tpl = Globals.getTemplateCacheService().getExamTemplateCache().getTLExamTplById(exam.getExamInfo().getExamId());
			if(tpl == null){
				Loggers.examLogger.error("getTLExamTplById is null! charId=" + 
						human.getCharId() + ";examId = " + exam.getExamInfo().getExamId());
				return ;
			}
			Integer baseRewardId = 0;
			exam.getExamInfo().setTotalNum(exam.getExamInfo().getTotalNum()+1);
			exam.getExamInfo().setExcludeOptions(new int[]{});
			boolean flag = false;
			if(tpl.getRightAnswerID() == choseAnswer){
				exam.getExamInfo().setRightNum(exam.getExamInfo().getRightNum()+1);
				baseRewardId = tpl.getRightAnswerRewardId();
				flag = true ;
			}else{
				baseRewardId = tpl.getWrongAnswerRewardId();
				exam.getResults().put(tpl.getId(), false);
			}
			exam.getResults().put(tpl.getId(), flag);
			//发答题日志
			Globals.getLogService().sendExamLog(human, LogReasons.ExamLogReason.EXAM_ANSWER, null, exam.getExamInfo().getExamId(), exam.getExamInfo().getTotalNum(), flag==true?1:2);
			//2.生成奖励
			//特殊触发的奖励
			Integer specialRewardId = this.triggerTheSpecialReward(exam.getExamInfo().getRightNum(), this.getExamSpecialRewardMap());
			if(specialRewardId!=null){	
				Reward spcialRewad = Globals.getRewardService().createReward(human.getUUID(), specialRewardId, "pet gain special exam reward!  petId="+human.getUUID()+",examTempalteId="+tpl.getId()+",specialId="+specialRewardId);
				exam.setReward(Globals.getRewardService().mergeReward(exam.getReward(),spcialRewad));
				Globals.getRewardService().giveReward(human, spcialRewad, true);//发奖励
			}
			//基本奖励
			Map<String, Object> baseParams = new HashMap<String, Object>();
			baseParams.put(RewardDef.CALC_KEY_LEVEL, Globals.getOfflineDataService().getUserLevel(human.getUUID()));
			Reward baseRewad = Globals.getRewardService().createReward(human.getUUID(), baseRewardId, "pet gain exam reward!  petId="+human.getUUID()+",examTempalteId="+tpl.getId(), baseParams);
			exam.setReward(Globals.getRewardService().mergeReward(exam.getReward(),baseRewad));
			Globals.getRewardService().giveReward(human, baseRewad, true);//发奖励
			//生成奖励信息
			exam.getExamInfo().setRewardInfo(exam.getReward().toRewardInfo());
			
			//3.判断是不是完成了
			if(exam.getExamInfo().getTotalNum()>0 && exam.getExamInfo().getTotalNum()<Globals.getGameConstants().getQuestionNumOfTimeLimitExamination()){
				//发下一道题目
				Integer newTplId = this.getARandomExamTemplate(exam, getExamTemplateMap());
				exam.getExamInfo().setExamId(newTplId);
			}else{
				//刚刚完成最后一道题 答完啦
				exam.getExamInfo().setExamState(ExamDef.ExamState.END.index);
				
				//可以重新答题了
				if(Globals.getExamService().getExamMap().containsKey(human.getUUID())){
					Globals.getExamService().getExamMap().get(human.getUUID()).remove(ExamType.TIMELIMIT);
				}
				//重置限时活动
				human.getTimeLimitManager().resetTimeLimit(human);
				human.sendErrorMessage(LangConstants.EXAM_IS_FINISHIED);
				
				//世界广播
				Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getTimeLimitExamNoticeId(),
						human.getName());
			}
			//4.活跃度相关
			doBehavior(human);
		}
		
		if (!canDo(human)) {
			//答完啦
			exam.getExamInfo().setExamState(ExamDef.ExamState.END.index);
			human.sendErrorMessage(LangConstants.EXAM_IS_FINISHIED);
		}
		
		//7.推送消息
		human.sendMessage(buildGCExamInfo(human, exam));
		human.sendMessage(new GCExamChose(examType,ResultTypes.SUCCESS.getIndex()));		
	}

	@Override
	public void examUseItem(Human human, Integer examType, Integer itemId) {
		//限时答题没有使用道具,这里要判断
		if(ExamType.TIMELIMIT.getIndex() == examType){
			Loggers.examLogger.error("timelimit examType can not use item! charId=" + 
					human.getCharId() + ";examType=" + examType);
			return;
		}
	}

	@Override
	public Map<Integer, ExamTemplate> getExamTemplateMap() {
		return Globals.getTemplateCacheService().getExamTemplateCache().getTLExamMap();
	}

	@Override
	public Map<Integer, ExamSpecialRewardConditionTemplate> getExamSpecialRewardMap() {
		return Globals.getTemplateCacheService().getExamTemplateCache().getTLRewardMap();
	}

	@Override
	public boolean isOpening(Human human) {
		if(human == null || human.getTimeLimitManager() == null){
			return false;
		}
		//玩家身上是否有限时答题
		if(human.getTimeLimitManager().getPushType() != ActivityDef.TimeLimitType.DT.index){
			return false;
		}
		return true;
	}

	@Override
	public boolean canDo(Human human) {
//		return human.getBehaviorManager().canDo(BehaviorTypeEnum.TIME_LIMIT_EXAM);
		return true;
	}

	@Override
	public void doBehavior(Human human) {
//		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.TIME_LIMIT_EXAM);
	}

	@Override
	public GCExamInfo buildGCExamInfo(Human human, AbstractExam exam) {
		long leftTime = 0;
		if (isOpening(human)) {
			leftTime = human.getTimeLimitManager().getStartTime() + Globals.getGameConstants().getTimeLimitExistenceTime() - Globals.getTimeService().now();
		}
		if (leftTime < 0) {
			leftTime = 0;
		}
		
		GCExamInfo msg = new GCExamInfo();
		ExamInfo info = exam.getExamInfo();
		info.setLeftTime(leftTime);
		msg.setExamInfo(info);
		return msg;
	}

}
