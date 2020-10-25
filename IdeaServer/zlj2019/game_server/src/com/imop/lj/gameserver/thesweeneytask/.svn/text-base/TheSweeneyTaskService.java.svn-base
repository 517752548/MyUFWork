package com.imop.lj.gameserver.thesweeneytask;

import com.imop.lj.common.LogReasons.TheSweeneyTaskLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;
import com.imop.lj.gameserver.thesweeneytask.msg.GCOpenThesweeneytaskPanel;
import com.imop.lj.gameserver.thesweeneytask.msg.GCThesweeneytaskUpdate;
import com.imop.lj.gameserver.thesweeneytask.template.TheSweeneyTaskGroupTemplate;
import com.imop.lj.gameserver.thesweeneytask.template.TheSweeneyTaskTemplate;

public class TheSweeneyTaskService {
	
	/**
	 * 随机除暴安良任务
	 * @param groupId
	 * @return
	 */
	protected TheSweeneyTaskGroupTemplate randTask(int groupId) {
			return RandomUtils.hitObject(Globals.getTemplateCacheService().getTheSweeneyTemplateCache().getGroupWeightList(groupId), 
					Globals.getTemplateCacheService().getTheSweeneyTemplateCache().getGroupRandList(groupId), 
					Globals.getTemplateCacheService().getTheSweeneyTemplateCache().getGroupWeightTotal(groupId));
	}
	
	public boolean canAcceptTask(Human human, int questId) {
		if (human.getTheSweeneyTaskManager() == null) {
			return false;
		}
		//有正在进行的任务，则不能再接受
		if (human.getTheSweeneyTaskManager().isDoing()) {
			return false;
		}
		//任务是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.THESWEENEY_TASK_NUM);
		if (!bFlag) {
			return false;
		}
		
		return false;
	}
	
	public void sendCurTheSweeneyTaskMsg(Human human) {
		//给前台发正在进行的任务，可能没有
		if (human == null || human.getTheSweeneyTaskManager() == null) {
			return;
		}
		
		//可做任务数
		human.sendMessage(buildGCOpenTheSweeneytaskPanel(human));
		
		//是否有正在进行的任务
		if (!human.getTheSweeneyTaskManager().isDoing()) {
			return;
		}
		
		TheSweeneyTask curTask = human.getTheSweeneyTaskManager().getCurTask();
		//给前台发消息，更新进行中的任务
		human.sendMessage(new GCThesweeneytaskUpdate(curTask.buildQuestInfo()));
	}
	
	
	public GCOpenThesweeneytaskPanel buildGCOpenTheSweeneytaskPanel(Human human) {
		int finishTimes = human.getBehaviorManager().getCount(BehaviorTypeEnum.THESWEENEY_TASK_NUM);
		int totalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.THESWEENEY_TASK_NUM);
		
		GCOpenThesweeneytaskPanel msg = new GCOpenThesweeneytaskPanel();
		msg.setFinishTimes(finishTimes);
		msg.setTotalTimes(totalTimes);
		return msg;
	}
	
	/**
	 * 接受任务
	 * @param human
	 */
	public void acceptTask(Human human) {
		int questGroupId = 0;  //任务组ID
		TheSweeneyTaskGroupTemplate targetTpl = new TheSweeneyTaskGroupTemplate();
		
		if (human == null || human.getTheSweeneyTaskManager() == null) {
			return;
		}
		//行为是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.THESWEENEY_TASK_NUM);
		if (!bFlag) {
			human.sendErrorMessage(LangConstants.THE_SWEENEY_TASK_MAX_NUM);
			return;
		}
		
		//任务状态是否正确
		for (TheSweeneyTaskTemplate tpl : Globals.getTemplateCacheService().getAll(TheSweeneyTaskTemplate.class).values()){
			int minLevel = tpl.getLevelMin();
			int maxLevel = tpl.getLevelMax();
			if(human.getLevel() <= maxLevel && human.getLevel() >= minLevel){
				questGroupId = tpl.getQuestGroupId();
			}
		}
		
		TheSweeneyTask bpt = human.getTheSweeneyTaskManager().getCurTask();
		if (bpt == null || bpt.getStatus() != TaskStatus.CAN_ACCEPT) {
			targetTpl = randTask(questGroupId);
		}
		
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(targetTpl.getQuestId(), QuestTemplate.class);
		if (questTpl == null) {
			Loggers.humanLogger.error("#TheSweeneyTaskService#acceptTask#ERROR!quest not exist!humanId=" + human.getCharId());
			return;
		}
		
		//构建任务
		TheSweeneyTask theSweeneyTask = buildInitTask(human, questTpl);
		theSweeneyTask.onAcceptTask();
	}
	
	/**
	 * 构建初始的任务数据
	 * @param questTpl
	 * @return
	 */
	protected TheSweeneyTask buildInitTask(Human human, QuestTemplate questTpl) {
		long now = Globals.getTimeService().now();
		// 构建任务数据
		TheSweeneyTask task = new TheSweeneyTask(human, questTpl);
		// 生成Id
		task.setId(KeyUtil.UUIDKey());
		// 设置时间
		task.setStartTime(now);
		task.setLastUpdateTime(now);
		
		// 激活并存库
		task.active();
		task.setModified();
		return task;
	}
	
	public boolean onAcceptTask(Human human, TheSweeneyTask task) {
		if (human.getTheSweeneyTaskManager() == null || task == null) {
			return false;
		}
		if (human.getTheSweeneyTaskManager().isDoing()) {
			return false;
		}
		
		//设置当前任务
		human.getTheSweeneyTaskManager().setCurTask(task);
		human.setModified();
		
		//给前台发消息，更新进行中的任务
		human.sendMessage(buildGCOpenTheSweeneytaskPanel(human));
		human.sendMessage(new GCThesweeneytaskUpdate(task.buildQuestInfo()));
		
		//记录日志
		Globals.getLogService().sendTheSweeneyTaskLog(human, TheSweeneyTaskLogReason.ACCEPT_TASK, "", task.getQuestId(), task.getStatus().getIndex());
		return true;
	}
	
	/**
	 * 完成除暴安良任务
	 * @param human
	 */
	public void finishTask(Human human) {
		if (human.getTheSweeneyTaskManager() == null) {
			return;
		}
		//当前任务是否进行中
		if (!human.getTheSweeneyTaskManager().isDoing()) {
			return;
		}
		
		TheSweeneyTask curTask = human.getTheSweeneyTaskManager().getCurTask();
		if (!curTask.canFinishTask()) {
			return;
		}
		
		//完成任务
		boolean flag = curTask.onFinishTask();
		if (!flag) {
			Loggers.questLogger.error("玩家试图完成一个不可完成的任务！humanId=" + 
					human.getCharId() + ";questId=" + curTask.getQuestId());
			return;
		}
	}
	
	public boolean onFinishTask(Human human) {
		if (human.getTheSweeneyTaskManager() == null) {
			return false;
		}
		//任务完成计数
		doBehavior(human);
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.FINISH_THESWEENEY, 0, 1);
		
		TheSweeneyTask curTask = human.getTheSweeneyTaskManager().getCurTask();
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		
		//已做任务数
		int finishTimes = human.getBehaviorManager().getCount(BehaviorTypeEnum.THESWEENEY_TASK_NUM); 
		//可做任务数
		int totalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.THESWEENEY_TASK_NUM);  
		//给特殊奖励
		if(finishTimes == totalTimes && totalTimes != 0){
			for (TheSweeneyTaskTemplate tpl : Globals.getTemplateCacheService().getAll(TheSweeneyTaskTemplate.class).values()){
				int minLevel = tpl.getLevelMin();
				int maxLevel = tpl.getLevelMax();
				//主将所在等级区间判断
				if(human.getLevel() <= maxLevel && human.getLevel() >= minLevel){
					
					int SpecialAwards = tpl.getSpecialAwards();
					Reward reward = Globals.getRewardService().createReward(
							human.getCharId(),
							SpecialAwards,
							"human thesweeney special reward!  petId="
									+ human.getUUID() 
									+ ",rewardId="
									+SpecialAwards);
					Globals.getRewardService().giveReward(human, reward, true);
					
					human.sendErrorMessage(LangConstants.THE_SWEENEY_TASK_MAX_SPECIAL);
				}
			}
		}
		
		human.sendMessage(buildGCOpenTheSweeneytaskPanel(human));
		human.sendMessage(new GCThesweeneytaskUpdate(curTask.buildQuestInfo()));
		
		//玩家能否继续做任务，如不可以，则发消息通知
		boolean canDo = human.getBehaviorManager().canDo(BehaviorTypeEnum.THESWEENEY_TASK_NUM);
		if (!canDo) {
			//通知客户端，今天的任务已经做完了
			human.sendErrorMessage(LangConstants.THE_SWEENEY_TASK_MAX_NUM);
		} else {
			//继续接下个任务
			Globals.getTheSweeneyTaskService().acceptTask(human);
		}
		
		//记录日志
		Globals.getLogService().sendTheSweeneyTaskLog(human, TheSweeneyTaskLogReason.FINISH_TASK, "", questId, status);
		return true;
	}

	protected void doBehavior(Human human) {
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.THESWEENEY_TASK_NUM);
	}
	
	/**
	 * 放弃任务
	 * @param human
	 */
	public void giveupTask(Human human) {
		if (human.getTheSweeneyTaskManager() == null) {
			return;
		}
		//当前任务是否进行中
		if (!human.getTheSweeneyTaskManager().isDoing()) {
			return;
		}
		
		TheSweeneyTask curTask = human.getTheSweeneyTaskManager().getCurTask();
		if (!curTask.canGiveUpTask()) {
			return;
		}
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		
		curTask.onGiveUpTask();
		
		//记录日志
		Globals.getLogService().sendTheSweeneyTaskLog(human, TheSweeneyTaskLogReason.GIVEUP_TASK,"", questId, status);
	}
	
	public boolean onGiveupTask(Human human) {
		if (human.getTheSweeneyTaskManager() == null) {
			return false;
		}
		TheSweeneyTask curTask = human.getTheSweeneyTaskManager().getCurTask();
		if (curTask == null) {
			return false;
		}
		
		
		//发消息更新任务
		human.sendMessage(buildGCOpenTheSweeneytaskPanel(human));
		human.sendMessage(new GCThesweeneytaskUpdate(curTask.buildQuestInfo()));
		
		human.getTheSweeneyTaskManager().clearCurTask();
		human.setModified();
		return true;
	}
	
}
