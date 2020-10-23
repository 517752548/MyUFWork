package com.imop.lj.gameserver.ringtask;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.db.model.RingTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.AbstractTaskManager;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

import net.sf.json.JSONObject;

/**
 * 跑环任务数据管理
 *
 */
public class RingTaskManager extends AbstractTaskManager<Human> implements RoleDataHolder,JsonPropDataHolder{
	public static final String RING_NUM = "ringNum";
	
	/** 当前进行的任务，进行中或已放弃 */
	private RingTask curTask;
	
	/** 当前环数*/
	private int ringNum;
	
	public RingTaskManager(Human owner) {
		super(owner);
	}
	
	/**
	 * 登录时加载所有的任务数据
	 */
	public void load() {
		long charId = owner.getUUID();
		List<RingTaskEntity> entityList = Globals.getDaoService().getRingTaskDao().loadEntityByCharId(charId);
		for (RingTaskEntity entity : entityList) {
			QuestTemplate template = Globals.getTemplateCacheService().get(entity.getQuestId(), QuestTemplate.class);
			if (null == template) {
				// 记录错误日志，对应的任务已被删除
				Loggers.questLogger.error("#RingTaskManager#load#ERROR!questTpl is null!questId=" + entity.getQuestId());
				continue;
			}
			RingTask task = new RingTask(owner, template);
			task.fromEntity(entity);
			if (task.isDoing()) {
				//更新当前任务
				updateCurTask(task);
				//当前任务只有一个
				break;
			}
		}
	}
	
	private void updateCurTask(RingTask task) {
		curTask = task;
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
		boolean flag = Globals.getRingTaskService().canAcceptTask(getOwner(), questId);
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

	public RingTask getCurTask() {
		return curTask;
	}

	public void setCurTask(RingTask curTask) {
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
	
	public int getRingNum() {
		return ringNum;
	}
	
	public void setRingNum(int ringNum) {
		this.ringNum = ringNum;
	}

	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(RING_NUM, this.ringNum);
		return obj.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if(value == null || value.isEmpty()){
			return;
		}
		
		JSONObject obj = JSONObject.fromObject(value);
		if(obj == null || obj.isEmpty()){
			return;
		}
		
		this.ringNum = JsonUtils.getInt(obj, RING_NUM);
	}
}
