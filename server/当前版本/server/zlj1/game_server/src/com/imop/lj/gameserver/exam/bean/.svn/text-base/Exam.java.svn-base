package com.imop.lj.gameserver.exam.bean;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exam.ExamDef;
import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.exam.msg.GCExamApply;
import com.imop.lj.gameserver.exam.msg.GCExamChose;
import com.imop.lj.gameserver.exam.msg.GCExamInfo;
import com.imop.lj.gameserver.exam.msg.GCExamUseItem;
import com.imop.lj.gameserver.exam.template.ExamSpecialRewardConditionTemplate;
import com.imop.lj.gameserver.exam.template.ExamTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef;
import com.imop.lj.gameserver.title.TitleDef;

public class Exam extends AbstractExam{
	
	
	public Exam(ExamDef.ExamType et) {
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
		//答题限制，最多答20道题
		if (!canDo(human)) {
			human.sendErrorMessage(LangConstants.EXAM_IS_FINISHIED);
			return ;
		}
		//3.判断玩家是否已经申请过乡试
		if(Globals.getExamService().getExamMap().containsKey(human.getUUID())){
			if(Globals.getExamService().getExamMap().get(human.getUUID()).containsKey(ExamType.PROVINCIAL)){
				human.sendMessage(buildGCExamInfo(human, (Exam)Globals.getExamService().getExamMap().get(human.getUUID()).get(ExamType.PROVINCIAL)));
				human.sendMessage(new GCExamApply(examType,ResultTypes.SUCCESS.getIndex()));
				return ;
			}
		}
		//4.创建一个新Exam
		Exam exam = new Exam(ExamType.PROVINCIAL);
		//5.开始答题
		if(!exam.startExam()){
			Loggers.examLogger.error("examStart fail! charId=" + 
					human.getCharId() + ";petId=" + human.getUUID());
			return ;
		}
		exam.getExamInfo().setExamId(this.getARandomExamTemplate(exam, getExamTemplateMap()));
		Map<ExamType,AbstractExam> typeMap = Maps.newHashMap();
		typeMap.put(ExamType.PROVINCIAL, exam);
		Globals.getExamService().getExamMap().put(human.getUUID(), typeMap);
		//6.推送消息
		human.sendMessage(buildGCExamInfo(human, exam));
		human.sendMessage(new GCExamApply(examType,ResultTypes.SUCCESS.getIndex()));
		Globals.getTitleService().addTitleInfo(human.getCharId(), TitleDef.TitleTemplateType.EXAM_PROVINCIAL.getIndex());
		
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
			if(!Globals.getExamService().getExamMap().get(human.getUUID()).containsKey(ExamType.PROVINCIAL)){
				Loggers.examLogger.error("player was not apply exam yet! charId=" + 
						human.getCharId() + ";petId=" + human.getUUID());
				return ;
			}
		}
		//5.判断现在的状态是否是正在答题
		Exam exam = (Exam) Globals.getExamService().getExamMap().get(human.getUUID()).get(ExamType.PROVINCIAL);
		if(exam == null){
			Loggers.examLogger.error("getExamMap retuan null! charId=" + human.getCharId());
			return;
		}
		if(exam.getExamInfo().getExamState() != ExamDef.ExamState.EXAMING.index){
			human.sendErrorMessage(LangConstants.EXAM_IS_FINISHIED);
			return ;
		}
		//答题限制，最多答20道题
		if (!canDo(human)) {
			human.sendErrorMessage(LangConstants.EXAM_IS_FINISHIED);
			return ;
		}
		//6.答题
		if(exam.getExamInfo().getTotalNum()>=0 && exam.getExamInfo().getTotalNum()<Globals.getGameConstants().getQuestionNumOfProvincialExamination()){
			//1.完成本次题目
			
			ExamTemplate tpl = Globals.getTemplateCacheService().getExamTemplateCache().getExamTplById(exam.getExamInfo().getExamId());
			if(tpl == null){
				Loggers.examLogger.error("getExamTplById is null! charId=" + 
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
			if(exam.getExamInfo().getTotalNum()>0 && exam.getExamInfo().getTotalNum()<Globals.getGameConstants().getQuestionNumOfProvincialExamination()){
				//发下一道题目
				Integer newTplId = this.getARandomExamTemplate(exam, getExamTemplateMap());
				exam.getExamInfo().setExamId(newTplId);
			}else{
				//刚刚完成最后一道题 答完啦
				exam.getExamInfo().setExamState(ExamDef.ExamState.END.index);
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

	

	/**
	 * 使用特殊道具答题
	 * @param human
	 * @param examType
	 * @param itemId
	 */
	public void examUseItem(Human human, Integer examType, Integer itemId) {
		//1.判断科举是否已经开启
		if(!this.isOpening(human)){
			human.sendMessage(new GCExamChose(examType,ResultTypes.FAIL.getIndex()));
			return ;
		}
		//2.判断科举类型是否合法
		if(examType==null||examType<0||ExamType.valueOf(examType)==null){
			Loggers.examLogger.error("examType is wrong! charId=" + 
					human.getCharId() + ";petId=" + human.getUUID());
			return ;
		}
		//3.判断使用的物品是否合法
		if(itemId==null||itemId<0||ExamDef.ExamAssistItem.valueOf(itemId)==null||ExamDef.ExamAssistItem.valueOf(itemId)==ExamDef.ExamAssistItem.NULL){
			Loggers.examLogger.error("exam use itemId is wrong! charId=" + 
					human.getCharId() + ";petId=" + human.getUUID()+ ";itemId=" + itemId);
			return ;
		}
		//4.判断玩家是否申请过
		if(!Globals.getExamService().getExamMap().containsKey(human.getUUID())){
			if(!Globals.getExamService().getExamMap().get(human.getUUID()).containsKey(ExamType.PROVINCIAL)){
				Loggers.examLogger.error("player was not apply exam yet! charId=" + 
						human.getCharId() + ";petId=" + human.getUUID());
				return ;
			}
		}
		Exam exam = (Exam) Globals.getExamService().getExamMap().get(human.getUUID()).get(ExamType.PROVINCIAL);
		if(exam == null){
			Loggers.examLogger.error("getExamMap retuan null! charId=" + human.getCharId());
			return;
		}
		//5.判断现在的状态是否是正在答题
		if(exam.getExamInfo().getExamState() != ExamDef.ExamState.EXAMING.index){
			human.sendErrorMessage(LangConstants.EXAM_IS_FINISHIED);
		}
		//6.如果用的是松木令的话，判断本题是否已经用过
		if(ExamDef.ExamAssistItem.valueOf(itemId) == ExamDef.ExamAssistItem.SONGMULING && exam.getExamInfo().getExcludeOptions().length!=0){
			human.sendErrorMessage(LangConstants.EXAM_SONGMULING_IS_ALREADY_USED);
			return ;
		}
		//7.判断特殊道具是否足够
		if(!human.getInventory().hasItemByTmplId(ExamDef.ExamAssistItem.valueOf(itemId).getItemId(),useNum)){
			human.sendErrorMessage(LangConstants.EXAM_SPECIAL_ITEM_DEFINCE);
			return ;
		}
		//8.扣除特殊道具
		Collection<Item> itemList = human.getInventory().removeItem(ExamDef.ExamAssistItem.valueOf(itemId).getItemId(), useNum, LogReasons.ItemLogReason.COST_ITEM_FOR_EXAM, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_EXAM, ExamDef.ExamAssistItem.valueOf(itemId).getItemId()));
		if(itemList==null||itemList.size()<=0){
			//没有道具被扣除，退出
			return ;
		}
		//9.松木令
		if(ExamDef.ExamAssistItem.valueOf(itemId) == ExamDef.ExamAssistItem.SONGMULING){
			int[] arr = this.passedAnswer(exam);
			if(arr==null||arr.length==0){
				Loggers.examLogger.error("SONGMULING working wrong! charId=" + 
						human.getCharId() + ";petId=" + human.getUUID());
				return ;
			}
			exam.getExamInfo().setExcludeOptions(arr);
			human.sendMessage(buildGCExamInfo(human, exam));
		}
		//10.玉木令
		if(ExamDef.ExamAssistItem.valueOf(itemId) == ExamDef.ExamAssistItem.YUMULING){
			ExamTemplate et = Globals.getTemplateCacheService().getExamTemplateCache().getExamTplById(exam.getExamInfo().getExamId());
			if(et == null){
				Loggers.examLogger.error("getExamTplById is null! charId=" + 
						human.getCharId() + ";examId=" + exam.getExamInfo().getExamId());
				return;
			}
			examChoseAnswer(human,examType,et.getRightAnswerID());
		}
		human.sendMessage(new GCExamUseItem(examType,ResultTypes.SUCCESS.getIndex()));
	}

	@Override
	public Map<Integer, ExamTemplate> getExamTemplateMap() {
		return Globals.getTemplateCacheService().getExamTemplateCache().getExamMap();
	}

	@Override
	public Map<Integer, ExamSpecialRewardConditionTemplate> getExamSpecialRewardMap() {
		return Globals.getTemplateCacheService().getExamTemplateCache().getRewardMap();
	}

	@Override
	public boolean isOpening(Human human) {
		return Globals.getTimeService().now() > getTodayStartTime() && Globals.getTimeService().now() < getTodayEndTime();
	}
	
	/**
	 * 当天活动开始时间
	 * @return
	 */
	public long getTodayStartTime() {
		return TimeUtils.getBeginOfDay(Globals.getTimeService().now()) + Globals.getGameConstants().getExamStartTime();
	}
	
	/**
	 * 当天活动结束时间
	 * @return
	 */
	public long getTodayEndTime() {
		return TimeUtils.getBeginOfDay(Globals.getTimeService().now()) + Globals.getGameConstants().getExamEndTime();
	}

	@Override
	public boolean canDo(Human human) {
		return human.getBehaviorManager().canDo(BehaviorTypeEnum.PROVINCIAL_EXAM_NUM);
	}

	@Override
	public void doBehavior(Human human) {
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.PROVINCIAL_EXAM_NUM);
	}

	@Override
	public GCExamInfo buildGCExamInfo(Human human, AbstractExam exam) {
		long leftTime = 0;
		if (isOpening(human)) {
			leftTime = this.getTodayEndTime() - Globals.getTimeService().now();
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
