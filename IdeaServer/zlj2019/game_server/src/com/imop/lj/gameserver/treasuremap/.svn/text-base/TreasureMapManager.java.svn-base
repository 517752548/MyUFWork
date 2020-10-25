package com.imop.lj.gameserver.treasuremap;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.TreasureMapEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.AbstractTaskManager;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 藏宝图任务数据管理
 * @author maogen.feng
 */
public class TreasureMapManager extends AbstractTaskManager<Human> implements RoleDataHolder {
	/** 当前进行的任务，进行中或已放弃 */
	private TreasureMap curTask;
	
	public TreasureMapManager(Human owner) {
		super(owner);
	}
	
	/**
	 * 登录时加载所有的任务数据
	 */
	public void load() {
		long charId = owner.getUUID();
		List<TreasureMapEntity> entityList = Globals.getDaoService().getTreasureMapDao().loadEntityByCharId(charId);
		for (TreasureMapEntity entity : entityList) {
			QuestTemplate template = Globals.getTemplateCacheService().get(entity.getQuestId(), QuestTemplate.class);
			if (null == template) {
				// 记录错误日志，对应的任务已被删除
				Loggers.questLogger.error("#TreasureMapManager#load#ERROR!questTpl is null!questId=" + entity.getQuestId());
				continue;
			}
			TreasureMap task = new TreasureMap(owner, template);
			task.fromEntity(entity);
			if (task.isDoing()) {
				//更新当前任务
				updateCurTask(task);
				//当前任务只有一个
				break;
			}
		}
	}
	
	private void updateCurTask(TreasureMap task) {
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
		boolean flag = Globals.getTreasureMapService().canAcceptTask(getOwner(), questId);
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
	 * @return
	 */
	public boolean isDoing() {
		return this.curTask != null && this.curTask.isDoing();
	}

	public TreasureMap getCurTask() {
		return curTask;
	}

	public void setCurTask(TreasureMap curTask) {
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
