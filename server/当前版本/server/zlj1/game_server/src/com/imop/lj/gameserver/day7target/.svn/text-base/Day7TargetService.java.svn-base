package com.imop.lj.gameserver.day7target;

import java.util.List;

import com.google.common.collect.Lists;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.PubTaskLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.quest.QuestInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.msg.GCDay7TaskList;
import com.imop.lj.gameserver.player.msg.GCLoginPopPanel;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 七日目标服务
 * @author yu.zhao
 *
 */
public class Day7TargetService implements InitializeRequired {
	
	/** 登录弹出面板是否开启 */
	public static boolean LOGIN_POP_OPEN = true;

	@Override
	public void init() {
		//设置任务的显示奖励信息
		for (QuestTemplate tpl : Globals.getTemplateCacheService().getAll(QuestTemplate.class).values()) {
			if (tpl.getShowRewardId() > 0) {
				tpl.setRewardStr(Globals.getRewardService().createShowRewardInfo(tpl.getShowRewardId()).getRewardStr());
			}
		}
	}
	
	public void acceptTaskNextDay(Human human) {
		int maxDay = Globals.getTemplateCacheService().getQuestTemplateCache().getMaxDayOfDay7Task();
		//如果所有天的任务都接了，那就不用再接了
		if (human.getDay7TaskManager().getDaySet().size() >= maxDay) {
			return;
		}
		
		//取下一个天数
		int day = 0;
		for (int i = 1; i <= maxDay; i++) {
			if (!human.getDay7TaskManager().hasDay(i)) {
				day = i;
				break;
			}
		}
		if (day <= 0) {
			return;
		}
		
		List<QuestInfo> questInfos = Lists.newArrayList();
		//只接受指定天数的任务
		for (Integer questId : Globals.getTemplateCacheService().getQuestTemplateCache().getDay7QuestIdSet(day)) {
			//初始化一个任务
			Day7Task task = buildInitTask(human, Globals.getTemplateCacheService().get(questId, QuestTemplate.class));
			//任务变为接受状态
			task.onAcceptTaskNotNotice();
			//放入管理器中
			human.getDay7TaskManager().addTask(task);

			questInfos.add(task.buildQuestInfo());
		}
		
		//发任务列表
		if (!questInfos.isEmpty()) {
			GCDay7TaskList msg = new GCDay7TaskList();
			msg.setQuestInfo(questInfos.toArray(new QuestInfo[0]));
			human.sendMessage(msg);
		}
	}
	
	@SuppressWarnings("rawtypes")
	public void sendDay7TaskList(Human human) {
		if (human == null || human.getDay7TaskManager() == null) {
			return;
		}
		
		List<QuestInfo> questInfos = Lists.newArrayList();
		List<AbstractTask> doingList = human.getDay7TaskManager().getDoingTaskList();
		if (doingList != null && !doingList.isEmpty()) {
			for (AbstractTask t : doingList) {
				questInfos.add(t.buildQuestInfo());
			}
		}
		
		GCDay7TaskList msg = new GCDay7TaskList();
		msg.setQuestInfo(questInfos.toArray(new QuestInfo[0]));
		human.sendMessage(msg);
	}
	
	/**
	 * 完成七日目标任务
	 * @param human
	 * @param questId
	 */
	public void finishTask(Human human, int questId) {
		if (human == null || human.getDay7TaskManager() == null) {
			return;
		}
		
		//已经完成的任务不能再完成
		if (human.getDay7TaskManager().isFinished(questId)) {
			return;
		}
		
		//玩家登陆天数是否满足任务的天数
		int questDay = Globals.getTemplateCacheService().getQuestTemplateCache().getDayOfDay7Task(questId);
		if (questDay <= 0) {
			return;
		}
		if (human.getTotalLoginDays() < questDay) {
			human.sendErrorMessage(LangConstants.QUEST_DAY7_FINISH_FAIL);
			return;
		}
		
		Day7Task task = human.getDay7TaskManager().getTask(questId);
		//这种情况前台可以避免掉，但如果直接发消息就可能走到，因为数据还没插进去
		if (task == null) {
			return;
		}
		//任务是否可完成
		if (!task.canFinishTask()) {
			return;
		}
		//完成任务
		task.onFinishTask();
		
		//记录日志
		Globals.getLogService().sendPubTaskLog(human, PubTaskLogReason.FINISH_DAY7_TASK, "day7target", 
				"", questId, task.getStatus().getIndex());
	}
	
	/**
	 * 构建初始的任务数据
	 * @param questTpl
	 * @return
	 */
	protected Day7Task buildInitTask(Human human, QuestTemplate questTpl) {
		long now = Globals.getTimeService().now();
		// 构建任务数据
		Day7Task task = new Day7Task(human, questTpl);
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

	/**
	 * 登录弹出面板逻辑
	 * @param human
	 */
	public void loginPopPanel(Human human) {
		if (!LOGIN_POP_OPEN) {
			return;
		}
		
		//目前默认弹签到面板
		human.sendMessage(new GCLoginPopPanel(FuncDef.FuncTypeEnum.DAILY_SIGN.getIndex(), ""));
	}
}
