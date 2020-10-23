package com.imop.lj.gameserver.thesweeneytask;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.TheSweeneyTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.AbstractTaskManager;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 除暴安良任务数据管理
 * @author yu.zhao
 *
 */
public class TheSweeneyTaskManager extends AbstractTaskManager<Human> implements RoleDataHolder {
	/** 当前进行的任务，进行中或已放弃 */
	private TheSweeneyTask curTask;
	
	public TheSweeneyTaskManager(Human owner) {
		super(owner);
	}
	
	/**
	 * 登录时加载所有的任务数据
	 */
	public void load() {
		long charId = owner.getUUID();
		List<TheSweeneyTaskEntity> entityList = Globals.getDaoService().getTheSweeneyTaskDao().loadEntityByCharId(charId);
		for (TheSweeneyTaskEntity entity : entityList) {
			QuestTemplate template = Globals.getTemplateCacheService().get(entity.getQuestId(), QuestTemplate.class);
			if (null == template) {
				// 记录错误日志，对应的任务已被删除
				Loggers.questLogger.error("#TheSweeneyTaskManager#load#ERROR!questTpl is null!questId=" + entity.getQuestId());
				continue;
			}
			TheSweeneyTask task = new TheSweeneyTask(owner, template);
			task.fromEntity(entity);
			if (task.isDoing()) {
				//更新当前任务
				updateCurTask(task);
				//当前任务只有一个
				break;
			}
		}
	}
	
	private void updateCurTask(TheSweeneyTask task) {
		curTask = task;
	}
	
	
	@Override
	public void checkAfterRoleLoad() {
	}

	@Override
	public void checkBeforeRoleEnter() {
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
		boolean flag = Globals.getTheSweeneyTaskService().canAcceptTask(getOwner(), questId);
		return flag;
	}
	
	/**
	 * 任务是否已完成
	 * @param questId
	 * @return
	 */
	@Override
	public boolean isFinished(int questId) {
		return false;
	}
	
	/**
	 * 任务是否进行中
	 * @param questId
	 * @return
	 */
	public boolean isDoing() {
		return this.curTask != null && this.curTask.isDoing();
	}

	public TheSweeneyTask getCurTask() {
		return curTask;
	}

	public void setCurTask(TheSweeneyTask curTask) {
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
