package com.imop.lj.gameserver.ringtask;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.RingTaskLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef;
import com.imop.lj.gameserver.ringtask.msg.GCOpenRingtaskPanel;
import com.imop.lj.gameserver.ringtask.msg.GCRingtaskUpdate;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public class RingTaskService implements InitializeRequired {

	@Override
	public void init() {
		
	}

	public boolean canAcceptTask(Human human, int questId) {
		checkHumanValid(human);
		
		if(human.getRingTaskManager().isDoing()){
			return false;
		}
		
		//任务是否可做
		boolean canDoFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.RING_TASK_NUM);
		if(!canDoFlag){
			return false;
		}
		
		return true;
	}
	
	
	/**
	 * 接受任务
	 * @param human
	 */
	public void acceptTask(Human human) {
		checkHumanValid(human);
		
		//放弃次数是否已达最大值
		boolean canGiveUpFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.RING_TASK_GIVE_UP_NUM);
		if(!canGiveUpFlag){
			human.sendErrorMessage(LangConstants.RINGTASK_GIVE_UP_MAX_NUM,
					human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.RING_TASK_GIVE_UP_NUM));
			return;
		}
		
		//任务是否可做
		boolean canDoFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.RING_TASK_NUM);
		if(!canDoFlag){
			human.sendErrorMessage(LangConstants.RINGTASK_MAX_NUM,
					human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.RING_TASK_NUM));
			return;
		}
		
		//任务完成计数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.RING_TASK_NUM);
		//设置环数
		human.getRingTaskManager().setRingNum(human.getBehaviorManager().getCount(BehaviorTypeEnum.RING_TASK_NUM));
		
		//任务状态是否正确
		RingTask curTask = human.getRingTaskManager().getCurTask();
		
		
		int qstId = 0;
		//根据环数得到轮数
		int roundNum = 0;
		int ringNum = human.getRingTaskManager().getRingNum();
		if(curTask == null || curTask.getStatus() != TaskStatus.CAN_ACCEPT){
			roundNum = getRoundNumByRingNum(ringNum);
			qstId = Globals.getTemplateCacheService().getRingTaskTemplateCache().getRandomRingTask(human.getLevel(), roundNum);
		}
		
		if(qstId <= 0){
			return;
		}
		
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(qstId, QuestTemplate.class);
		if(questTpl == null){
			Loggers.ringTaskLogger.error("#RingTaskService#acceptTask get QuestTemplate is null!questId="+ qstId);
			return;
		}
		
		RingTask task = buildInitTask(human, questTpl, ringNum);
		task.onAcceptTask();
	}

	private int getRoundNumByRingNum(int ringNum) {
		return ringNum % Globals.getGameConstants().getRingToRoundNumCoef() == 0
				? ringNum / Globals.getGameConstants().getRingToRoundNumCoef()
				: ringNum / Globals.getGameConstants().getRingToRoundNumCoef() + 1;
	}

	/**
	 * 验证human是否有效
	 * @param human
	 */
	protected void checkHumanValid(Human human) {
		if(human == null || human.getRingTaskManager() == null){
			return;
		}
	}

	/**
	 * 构建初始的任务数据
	 * @param human
	 * @param questTpl
	 * @param ringNum
	 * @return
	 */
	protected RingTask buildInitTask(Human human, QuestTemplate questTpl, int ringNum) {
		checkHumanValid(human);
		RingTask task = new RingTask(human, questTpl);
		task.setStatus(TaskStatus.CAN_ACCEPT);
		task.setId(KeyUtil.UUIDKey());
		task.setStartTime(Globals.getTimeService().now());
		task.setLastUpdateTime(Globals.getTimeService().now());
		// 激活并存库
		task.active();
		task.setModified();
		return task;
	}

	public boolean onAcceptTaskImpl(Human human, RingTask ringTask) {
		checkHumanValid(human);
		
		//当前是否已领取任务
		if(human.getRingTaskManager().isDoing()){
			return false;
		}
		
		//设置当前任务
		human.getRingTaskManager().setCurTask(ringTask);
		human.setModified();
		
		//给前台发消息,更新进行中的任务
		human.sendMessage(buildGCOpenRingtaskPanel(human));
		human.sendMessage(buildGCRingtaskUpdate(ringTask));
		
		//记录日志
		Globals.getLogService().sendRingTaskLog(human, RingTaskLogReason.ACCEPT_TASK, "",
				ringTask.getQuestId(), ringTask.getStatus().getIndex());
		
		return true;
	}
	
	protected GCRingtaskUpdate buildGCRingtaskUpdate(RingTask RingTask){
		GCRingtaskUpdate msg = new GCRingtaskUpdate();
		msg.setQuestInfo(RingTask.buildQuestInfo());
		return msg;
	}
	
	protected GCOpenRingtaskPanel buildGCOpenRingtaskPanel(Human human){
 		int finishTimes = human.getRingTaskManager().getRingNum();
		int totalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.RING_TASK_NUM);
		int giveUpTimes = human.getBehaviorManager().getCount(BehaviorTypeEnum.RING_TASK_GIVE_UP_NUM);
		int giveUpTotalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.RING_TASK_GIVE_UP_NUM);
		
		GCOpenRingtaskPanel msg = new GCOpenRingtaskPanel();
		msg.setFinishTimes(finishTimes);
		msg.setTotalTimes(totalTimes);
		msg.setGiveUpTimes(giveUpTimes);
		msg.setGiveUpTotalTimes(giveUpTotalTimes);
		return msg;
	}

	/**
	 * 放弃 任务
	 * @param human
	 */
	public void giveUpTask(Human human) {
		checkHumanValid(human);
		
		//是否有任务
		if(!human.getRingTaskManager().isDoing()){
			return;
		}
		
		//获取当前任务
		RingTask curTask = human.getRingTaskManager().getCurTask();
		if(curTask == null ||!curTask.canGiveUpTask()){
			return;
		}
		
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		curTask.onGiveUpTask();
		
		//记录日志
		Globals.getLogService().sendRingTaskLog(human, RingTaskLogReason.GIVEUP_TASK,	 "",
				questId, status);
		
	}

	public boolean onGiveupTaskImpl(Human human) {
		checkHumanValid(human);
		
		//放弃任务后，扣除本次任务次数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.RING_TASK_GIVE_UP_NUM);
		//设置环数
		human.getRingTaskManager().setRingNum(human.getBehaviorManager().getCount(BehaviorTypeEnum.RING_TASK_NUM));
		
		//获取当前任务
		RingTask curTask = human.getRingTaskManager().getCurTask();
		if(curTask == null){
			return false;
		}
		
		//发消息更新任务
		human.sendMessage(buildGCOpenRingtaskPanel(human));
		human.sendMessage(buildGCRingtaskUpdate(curTask));
		human.getRingTaskManager().clearCurTask();
		human.setModified();
		return true;
	}

	/**
	 * 完成任务
	 * @param human
	 */
	public void finishTask(Human human) {
		checkHumanValid(human);
		
		//是否有任务
		if(!human.getRingTaskManager().isDoing()){
			return;
		}
		
		//获取当前任务
		RingTask curTask = human.getRingTaskManager().getCurTask();
		if(curTask == null ||!curTask.canFinishTask()){
			return;
		}
		
		boolean flag = curTask.onFinishTask();
		if(!flag){
			Loggers.questLogger.error("玩家试图完成一个不可完成的任务！humanId=" + 
					human.getCharId() + ";questId=" + curTask.getQuestId());
			return;
		}
	}

	public boolean onFinishTaskImpl(Human human) {
		checkHumanValid(human);

		//获取当前任务
		RingTask curTask = human.getRingTaskManager().getCurTask();
		if(curTask == null){
			return false;
		}
		
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		
		//根据人物vip状态,单独给奖励
		int rewardId = Globals.getTemplateCacheService().getRingTaskTemplateCache().getRewardId(human.getLevel(), human.getRingTaskManager().getRingNum(),
				Globals.getVipService().getCurVipLevel(human.getUUID()));
		boolean vipOk = Globals.getTemplateCacheService().getRingTaskTemplateCache().vipIsOk(human.getLevel(), human.getRingTaskManager().getRingNum(),
				Globals.getVipService().getCurVipLevel(human.getUUID()));
		Reward reward = getRingCalculateReward(human, human.getRingTaskManager().getRingNum(), vipOk, rewardId);
		Globals.getRewardService().giveReward(human, reward, true);		
		
		//发消息更新任务
		human.sendMessage(buildGCOpenRingtaskPanel(human));
		human.sendMessage(buildGCRingtaskUpdate(curTask));
		
		//玩家能否继续做任务,如不可以,则发消息通知
		boolean canDo = human.getBehaviorManager().canDo(BehaviorTypeEnum.RING_TASK_NUM);
		if(!canDo){
			//通知客户端,今天的任务已经做完了
			human.sendErrorMessage(LangConstants.RINGTASK_FINISH_ALL
					, human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.RING_TASK_NUM));
		}
		else{
			//发送下一个任务
			this.acceptTask(human);
		}

		//记录日志
		Globals.getLogService().sendRingTaskLog(human, RingTaskLogReason.FINISH_TASK, "",
				questId, status);
		return true;
	}
	
	private Reward getRingCalculateReward(Human human, int ringNum, boolean vipOk, int rewardId) {
		Map<String, Object> baseParams = new HashMap<String, Object>();
		baseParams.put(RewardDef.CALC_KEY_LEVEL, Globals.getOfflineDataService().getUserLevel(human.getUUID()));
		baseParams.put(RewardDef.CALC_KEY_RING_NUM, ringNum);
		baseParams.put(RewardDef.CALC_KEY_VIP, vipOk);
		Reward baseRewad = Globals.getRewardService().createReward(human.getUUID(), 
				rewardId,
				"pet gain reward!  petId="+human.getUUID(), baseParams);
		return baseRewad;
	}

	/**
	 * 玩家登陆时发送任务信息
	 * @param human
	 */
	public void sendCurRingTaskMsg(Human human) {
		checkHumanValid(human);

		//是否有进行中的任务
		if(!human.getRingTaskManager().isDoing()){
			return;
		}
		
		RingTask curTask = human.getRingTaskManager().getCurTask();
		if(curTask == null){
			return;
		}
		
		//发送前台消息
		human.sendMessage(buildGCOpenRingtaskPanel(human));
		human.sendMessage(buildGCRingtaskUpdate(curTask));
		
	}

}