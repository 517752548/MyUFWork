package com.imop.lj.gameserver.quest;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Lists;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.quest.QuestInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.quest.msg.GCCommonQuestList;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public class CommonTaskService {

	@SuppressWarnings("rawtypes")
	public void sendCommonTaskList(Human human) {
		if (human == null || human.getCommonTaskManager() == null) {
			return;
		}
		List<QuestInfo> questInfos = Lists.newArrayList();
		//已接任务
		List<AbstractTask> doingList = human.getCommonTaskManager().getDoingTaskList();
		if (doingList != null && !doingList.isEmpty()) {
			for (AbstractTask t : doingList) {
				questInfos.add(t.buildQuestInfo());
			}
		}
		//未接任务
		Map<Integer, TaskStatus> notAcceptMap = human.getCommonTaskManager().getNotAcceptMap();
		if (notAcceptMap != null && !notAcceptMap.isEmpty()) {
			for (Entry<Integer, TaskStatus> entry : notAcceptMap.entrySet()) {
				questInfos.add(AbstractTask.buildNotAcceptQuestInfo(entry.getKey(), entry.getValue()));
			}
		}
		
		GCCommonQuestList gcCommonQuestList = new GCCommonQuestList();
		gcCommonQuestList.setQuestInfos(questInfos.toArray(new QuestInfo[0]));
		human.sendMessage(gcCommonQuestList);
	}
	
	public void acceptTask(Human human, int questId) {
		if (human == null || human.getCommonTaskManager() == null) {
			return;
		}
		
		QuestTemplate pTpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
		if (pTpl == null) {
			return;
		}
		//自动接的任务手动接了，记录一个警告即可
		if (pTpl.isAutoAccept()) {
			Loggers.questLogger.warn("玩家试图接受一个自动接受的任务.humanId=" + 
					human.getCharId() + ";questId=" + questId);
		}
		
		//检查任务是否可接受
		if (!human.getCommonTaskManager().canAcceptTask(questId)) {
			Loggers.questLogger.error("玩家试图接受一个不可接的任务！humanId=" + 
					human.getCharId() + ";questId=" + questId);
			return;
		}
		
		
		CommonTask ct = buildInitTask(human, pTpl);
		ct.onAcceptTask();
		
		//发消息，通知任务变化
		human.getCommonTaskManager().notifyChanged();
	}
	
	public void finishTask(Human human, int questId) {
		if (human == null || human.getCommonTaskManager() == null) {
			return;
		}
		
		QuestTemplate pTpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
		if (pTpl == null) {
			return;
		}
		
		//自动完成的任务手动完成了，记录一个警告即可
		if (pTpl.isAutoFinish()) {
			Loggers.questLogger.warn("玩家试图完成一个自动完成的任务.humanId=" + 
					human.getCharId() + ";questId=" + questId);
		}
		
		if (!human.getCommonTaskManager().isDoing(questId)) {
			Loggers.questLogger.error("玩家试图完成一个未在进行中的任务！humanId=" + 
					human.getCharId() + ";questId=" + questId);
			return;
		}
		
		CommonTask ct = human.getCommonTaskManager().getDoingTask(questId);
		boolean flag = ct.onFinishTask();
		if (!flag) {
			Loggers.questLogger.error("玩家试图完成一个不可完成的任务！humanId=" + 
					human.getCharId() + ";questId=" + questId);
			return;
		}
		
		//发消息，通知任务变化
		human.getCommonTaskManager().notifyChanged();
	}
	
	public void checkAfterAcceptTask(Human human, CommonTask ct) {
		//加入已接受任务集合
		human.getCommonTaskManager().addDoingTask(ct);
		//从未接任务集合中删除
		human.getCommonTaskManager().removeNotAcceptTask(ct.getQuestId());
	}
	
	public void checkAfterFinishTask(Human human, int finishedQuestId) {
		//取前置为该完成的任务的集合
		Set<Integer> pIdSet = Globals.getTemplateCacheService().getQuestTemplateCache().getPostQuestIdSet(finishedQuestId);
		if (pIdSet != null && !pIdSet.isEmpty()) {
			for (Integer pId : pIdSet) {
				//已完成的任务，跳过
				if (human.getCommonTaskManager().isFinished(pId)) {
					continue;
				}
				
				QuestTemplate pTpl = Globals.getTemplateCacheService().get(pId, QuestTemplate.class);
				//可接，且是自动接，则接
				if (human.getCommonTaskManager().canAcceptTask(pId) &&
						pTpl.isAutoAccept()) {
					CommonTask ct = buildInitTask(human, pTpl);
					ct.onAcceptTask();
					continue;
				}
				
				//未接任务是否需要更新，仅限主线
				if (pTpl.getQuestTypeEnum() == QuestType.COMMON &&
						human.getCommonTaskManager().canAcceptSpecialCheck(pId) && 
						human.getCommonTaskManager().preQuestCheckOnAccept(pTpl)) {
					//等级不满足，可以加入未接任务集合
					TaskStatus ts = human.getCommonTaskManager().levelCheckOnAccept(pTpl, human.getLevel()) ? 
							TaskStatus.CAN_ACCEPT : TaskStatus.CAN_NOT_ACCEPT;
					//加入未接任务集合
					human.getCommonTaskManager().addNotAcceptTask(pId, ts);
				}
			}
		}
		
		//发消息，通知任务变化
		human.getCommonTaskManager().notifyChanged();
	}
	
	/**
	 * 玩家升级后，对任务状态变化的影响
	 * @param human
	 */
	public void onUpdateLevel(Human human) {
		if (human == null || human.getCommonTaskManager() == null) {
			return;
		}
		
		//主线需要接的任务
		Map<Integer, TaskStatus> nMap = human.getCommonTaskManager().getNotAcceptMap();
		if (nMap != null && !nMap.isEmpty()) {
			Map<Integer, TaskStatus> tMap = new HashMap<Integer, TaskStatus>();
			tMap.putAll(nMap);
			for (Entry<Integer, TaskStatus> entry : tMap.entrySet()) {
				TaskStatus ts = entry.getValue();
				if (ts == TaskStatus.CAN_NOT_ACCEPT) {
					int tId = entry.getKey();
					if (human.getCommonTaskManager().canAcceptTask(tId)) {
						QuestTemplate tTpl = Globals.getTemplateCacheService().get(tId, QuestTemplate.class);
						if (tTpl.isAutoAccept()) {
							CommonTask ct = buildInitTask(human, tTpl);
							ct.onAcceptTask();
						} else {
							//变为可接状态
							human.getCommonTaskManager().addNotAcceptTask(tId, TaskStatus.CAN_ACCEPT);
						}
					}
				}
			}
		}
		
		//支线任务处理
		Set<Integer> bSet = Globals.getTemplateCacheService().getQuestTemplateCache().getBranchLevelQuestIdSet(human.getLevel());
		if (bSet != null && !bSet.isEmpty()) {
			for (Integer tId : bSet) {
				//已完成的任务，跳过
				if (human.getCommonTaskManager().isFinished(tId)) {
					continue;
				}
				
				//是否可接受
				if (human.getCommonTaskManager().canAcceptTask(tId)) {
					QuestTemplate tTpl = Globals.getTemplateCacheService().get(tId, QuestTemplate.class);
					//只接自动的，不自动的需要手动接
					if (tTpl.isAutoAccept()) {
						CommonTask ct = buildInitTask(human, tTpl);
						ct.onAcceptTask();
					}
				}
			}
		}
		
		//发消息，通知任务变化
		human.getCommonTaskManager().notifyChanged();
	}
	
	/**
	 * 构建初始的任务数据
	 * @param questTpl
	 * @return
	 */
	protected CommonTask buildInitTask(Human human, QuestTemplate questTpl) {
		long now = Globals.getTimeService().now();
		// 构建任务数据
		CommonTask task = new CommonTask(human, questTpl);
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
	
}
