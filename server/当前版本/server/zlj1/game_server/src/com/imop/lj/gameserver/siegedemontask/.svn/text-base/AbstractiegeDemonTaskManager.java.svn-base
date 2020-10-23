package com.imop.lj.gameserver.siegedemontask;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.SiegeDemonTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.AbstractTaskManager;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 围剿魔族任务数据管理
 *
 */
public abstract class AbstractiegeDemonTaskManager extends AbstractTaskManager<Human> implements RoleDataHolder, JsonPropDataHolder {
	/** 当前进行的任务，进行中或已放弃 */
	private SiegeDemonTask curTask;
	/** 已完成的任务Id集合 */
	private Set<Integer> finishedTaskSet = new HashSet<Integer>();
	
	public AbstractiegeDemonTaskManager(Human owner) {
		super(owner);
	}
	
	public Set<Integer> getFinishedSet() {
		return this.finishedTaskSet;
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
	
	
	public void addFinishedTask(int questId) {
		if (!finishedTaskSet.contains(questId)) {
			finishedTaskSet.add(questId);
		}
	}
	/**
	 * 登录时加载所有的任务数据
	 */
	public void load() {
		long charId = owner.getUUID();
		List<SiegeDemonTaskEntity> entityList = Globals.getDaoService().getSiegeDemonTaskDao().loadEntityByCharId(charId);
		for (SiegeDemonTaskEntity entity : entityList) {
			QuestTemplate template = Globals.getTemplateCacheService().get(entity.getQuestId(), QuestTemplate.class);
			if (null == template) {
				// 记录错误日志，对应的任务已被删除
				Loggers.questLogger.error("#SiegeDemonTaskManager#load#ERROR!questTpl is null!questId=" + entity.getQuestId());
				continue;
			}
			SiegeDemonTask task = new SiegeDemonTask(owner, template);
			task.fromEntity(entity);
			if (task.hasFinished()) {
				//已完成的任务
				addFinishedTask(task.getQuestId());
			}	
			if (task.isDoing()) {
				//更新当前任务
				updateCurTask(task);
				//当前任务只有一个
				break;
			}
		}
	}
	
	private void updateCurTask(SiegeDemonTask task) {
		curTask = task;
	}
	
	@Override
	public String toJsonProp() {
		return "";
	}

	@Override
	public void loadJsonProp(String value) {
	}
	
	
	@Override
	public void checkAfterRoleLoad() {
		//检查是否需要刷新任务
	}

	@Override
	public void checkBeforeRoleEnter() {
		return;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public List<AbstractTask> getDoingTaskList() {
		List<AbstractTask> ret = new ArrayList<AbstractTask>();
		if (isDoing()) {
			ret.add(getCurTask());
		}
		return ret;
	}
	
	@Override
	public boolean canAcceptSpecialCheck(int questId) {
		boolean flag = Globals.getSiegeDemonTaskService().canAcceptTask(getOwner(), questId);
		return flag;
	}
	
	/**
	 * 任务是否进行中
	 * @param questId
	 * @return
	 */
	public boolean isDoing() {
		return this.curTask != null && this.curTask.isDoing();
	}

	public SiegeDemonTask getCurTask() {
		return curTask;
	}

	public void setCurTask(SiegeDemonTask curTask) {
		this.curTask = curTask;
	}
	
	public void clearCurTask() {
		this.curTask = null;
	}

	public void clearTask() {
		this.curTask = null;
	}
	
	@Override
	public Map<Integer,Integer> getTaskRewardByEmemyArmy(int ememyArmyId) {
		Map<Integer, Integer> map = Maps.newHashMap();
		//只有接了但未完成的任务，才算数，可完成的任务就不再获得奖励了
		if (curTask != null && 
				curTask.getStatus() == TaskStatus.ACCEPTED) {
			if(curTask.getTemplate().hasTaskEnemyArmy(ememyArmyId)){
				map.put(curTask.getQuestId(), curTask.getTemplate().getTaskDropRewardId());
			}
		}
		return map;
	}
}
