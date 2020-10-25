package com.imop.lj.gameserver.quest;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.CommonTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.AbstractTaskManager;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 普通任务数据管理
 * @author yu.zhao
 *
 */
public class CommonTaskManager extends AbstractTaskManager<Human> implements RoleDataHolder {
	
	/** 正在进行的任务Id集合 */
	private Map<Integer, CommonTask> doingTaskMap = new LinkedHashMap<Integer, CommonTask>();
	/** 已完成的任务Id集合 */
	private Set<Integer> finishedTaskSet = new HashSet<Integer>();
	
	/** 未接的任务，包含可接和可见不可接的，只有主线 */
	private Map<Integer, TaskStatus> notAcceptMap = new HashMap<Integer, TaskStatus>();
	
	/** 发消息用的标识位 */
	private boolean isChanged;
	/** 发消息用的标识位 */
	private boolean isInit;
	
	public CommonTaskManager(Human owner) {
		super(owner);
	}
	
	/**
	 * 登录时加载所有的任务数据
	 */
	public void load() {
		long charId = owner.getUUID();
		List<CommonTaskEntity> entityList = Globals.getDaoService().getCommonTaskDao().loadEntityByCharId(charId);
		for (CommonTaskEntity entity : entityList) {
			QuestTemplate template = Globals.getTemplateCacheService().get(entity.getQuestId(), QuestTemplate.class);
			if (null == template) {
				// 记录错误日志，对应的任务已被删除
				Loggers.questLogger.error("#CommonTaskManager#load#ERROR!questTpl is null!questId=" + entity.getQuestId());
				continue;
			}
			CommonTask task = new CommonTask(owner, template);
			task.fromEntity(entity);
			if (task.hasFinished()) {
				//已完成的任务
				addFinishedTask(task.getQuestId());
			} else {
				//进行中的任务
				addDoingTask(task);
			}
		}
	}
	
	public void addDoingTask(CommonTask task) {
		if (!doingTaskMap.containsKey(task.getQuestId())) {
			doingTaskMap.put(task.getQuestId(), task);
			setChanged(true);
		}
	}
	
	public void addFinishedTask(int questId) {
		//从进行中map删除
		if (doingTaskMap.containsKey(questId)) {
			doingTaskMap.remove(questId);
			setChanged(true);
		}
		//加入已完成的集合
		if (!finishedTaskSet.contains(questId)) {
			finishedTaskSet.add(questId);
			setChanged(true);
		}
	}
	
	public boolean isChanged() {
		return isChanged;
	}

	private void setChanged(boolean isChanged) {
		this.isChanged = isChanged;
	}
	
	public boolean isInit() {
		return isInit;
	}

	private void setInit(boolean isInit) {
		this.isInit = isInit;
	}

	public void notifyChanged() {
		//非初始阶段，且有变更，再发任务列表
		if (isChanged() && !isInit()) {
			Globals.getCommonTaskService().sendCommonTaskList(getOwner());
			setChanged(false);
		}
	}

	@Override
	public void checkAfterRoleLoad() {
		//初始阶段开始
		setInit(true);

		//如果任务为空，则表示第一次登陆，接受第一个任务
		if (finishedTaskSet.isEmpty() && doingTaskMap.isEmpty()) {
			//接受第一个任务
			Globals.getCommonTaskService().acceptTask(getOwner(), 
					Globals.getTemplateCacheService().getQuestTemplateCache().getFirstQuestId());
		}
		
		//检查是否有可完成，且自动完成的任务
		for (CommonTask ct : doingTaskMap.values()) {
			//可完成，且自动完成的任务，则完成
			if (ct.canFinishTask() && 
					ct.getTemplate().isAutoFinish()) {
				ct.onFinishTask();
			}
		}
		
		//检查是否有可接的任务，或未接的任务
		Set<Integer> finishedSet = getFinishedSet();
		if (!finishedSet.isEmpty()) {
			for (Integer fQuestId : finishedSet) {
				Globals.getCommonTaskService().checkAfterFinishTask(getOwner(), fQuestId);
			}
		}
		
		//初始阶段变更无效
		setChanged(false);
		//初始阶段完毕
		setInit(false);
	}

	@Override
	public void checkBeforeRoleEnter() {
		return;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public List<AbstractTask> getDoingTaskList() {
		List<AbstractTask> taskList = new ArrayList<AbstractTask>();
		taskList.addAll(doingTaskMap.values());
		return taskList;
	}
	
	@Override
	public boolean canAcceptSpecialCheck(int questId) {
		//进行中或者已完成的任务不能再接
		if (!isDoing(questId) && !isFinished(questId)) {
			return true;
		}
		return false;
	}
	
	/**
	 * 任务是否已完成
	 * @param questId
	 * @return
	 */
	@Override
	public boolean isFinished(int questId) {
		return this.finishedTaskSet.contains(questId);
	}
	
	/**
	 * 任务是否进行中
	 * @param questId
	 * @return
	 */
	public boolean isDoing(int questId) {
		return this.doingTaskMap.containsKey(questId);
	}
	
	public Set<Integer> getFinishedSet() {
		return this.finishedTaskSet;
	}
	
	/**
	 * 增加或更新一个未接受的任务
	 * @param questId
	 * @param status
	 * @return
	 */
	public boolean addNotAcceptTask(int questId, TaskStatus status) {
		if (!notAcceptMap.containsKey(questId) ||
				notAcceptMap.get(questId) != status) {
			notAcceptMap.put(questId, status);
			setChanged(true);
			return true;
		}
		return false;
	}
	
	public boolean removeNotAcceptTask(int questId) {
		if (notAcceptMap.containsKey(questId)) {
			notAcceptMap.remove(questId);
			setChanged(true);
			return true;
		}
		return false;
	}
	
	public Map<Integer, TaskStatus> getNotAcceptMap() {
		return this.notAcceptMap;
	}

	public CommonTask getDoingTask(int questId) {
		return doingTaskMap.get(questId);
	}
	
	/**
	 * 通过怪物组ID来判断是不是打任务怪，如果是则返回任务怪对应的任务物品掉落IDList
	 * 若打的不是对应任务的任务怪，则返回map.size() == 0
	 * @param ememyArmyId
	 * @return
	 */
	@Override
	public Map<Integer,Integer> getTaskRewardByEmemyArmy(int ememyArmyId) {
		Map<Integer,Integer> map = Maps.newHashMap();
		for(Entry<Integer, CommonTask> entry : doingTaskMap.entrySet()){
			//只有接了但未完成的任务，才算数，可完成的任务就不再获得奖励了
			if (entry.getValue().getStatus() == TaskStatus.ACCEPTED) {
				if(entry.getValue().getTemplate().hasTaskEnemyArmy(ememyArmyId)){
					map.put(entry.getKey(),entry.getValue().getTemplate().getTaskDropRewardId());
				}
			}
		}
		return map;
	}
}
