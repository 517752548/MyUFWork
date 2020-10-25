package com.imop.lj.gameserver.day7target;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.Day7TaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.AbstractTaskManager;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 七日目标任务数据管理
 * @author yu.zhao
 *
 */
public class Day7TaskManager extends AbstractTaskManager<Human> implements RoleDataHolder {
	
	/** 所有任务集合 */
	private Map<Integer, Day7Task> allTaskMap = new HashMap<Integer, Day7Task>();
	/** 已经有的任务的天数集合，缓存数据，不存库 */
	private Set<Integer> daySet = new HashSet<Integer>();
	
	public Day7TaskManager(Human owner) {
		super(owner);
	}
	
	/**
	 * 登录时加载所有的任务数据
	 */
	public void load() {
		long charId = owner.getUUID();
		List<Day7TaskEntity> entityList = Globals.getDaoService().getDay7TaskDao().loadEntityByCharId(charId);
		for (Day7TaskEntity entity : entityList) {
			QuestTemplate template = Globals.getTemplateCacheService().get(entity.getQuestId(), QuestTemplate.class);
			if (null == template) {
				// 记录错误日志，对应的任务已被删除
				Loggers.questLogger.error("#Day7TaskManager#load#ERROR!questTpl is null!questId=" + entity.getQuestId());
				continue;
			}
			Day7Task task = new Day7Task(owner, template);
			task.fromEntity(entity);
			//加入map
			addTask(task);
		}
	}
	
	public void addTask(Day7Task task) {
		if (!allTaskMap.containsKey(task.getQuestId())) {
			allTaskMap.put(task.getQuestId(), task);
			daySet.add(Globals.getTemplateCacheService().getQuestTemplateCache().getDayOfDay7Task(task.getQuestId()));
		}
	}
	
	public Set<Integer> getDaySet() {
		return daySet;
	}
	
	public boolean hasDay(int day) {
		return daySet.contains(day);
	}

	@Override
	public void checkAfterRoleLoad() {
//		Globals.getDay7TargetService().acceptTaskNextDay(getOwner());
	}

	@Override
	public void checkBeforeRoleEnter() {
		return;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public List<AbstractTask> getDoingTaskList() {
		List<AbstractTask> taskList = new ArrayList<AbstractTask>();
		taskList.addAll(allTaskMap.values());
		return taskList;
	}
	
	/**
	 * 任务是否已完成
	 * @param questId
	 * @return
	 */
	@Override
	public boolean isFinished(int questId) {
		if (allTaskMap.containsKey(questId)) {
			return allTaskMap.get(questId).getStatus() == TaskStatus.FINISHED;
		}
		return false;
	}
	
	public Day7Task getTask(int questId) {
		return allTaskMap.get(questId);
	}
}
