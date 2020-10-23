package com.imop.lj.gameserver.task;

import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public abstract class AbstractTaskManager<T extends ITaskOwner> {
	protected T owner;
	
	public final T getOwner() {
		return owner;
	}
	
	public AbstractTaskManager(T owner) {
		this.owner = owner;
	}
	
	public final boolean canAcceptTask(int questId) {
		QuestTemplate qt = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
		if (qt == null) {
			return false;
		}
		
		//等级要求
		if (!levelCheckOnAccept(qt, getOwner().getLevel())) {
			return false;
		}
		
		//前置任务
		if (!preQuestCheckOnAccept(qt)) {
			return false;
		}
		
		//组队人数要求
		if (!teamMemberNumCheck(qt, getOwner().getTeamMemberNum())) {
			return false;
		}
		
		//特殊条件判断
		return canAcceptSpecialCheck(questId);
	}
	
	public final boolean levelCheckOnAccept(QuestTemplate qt, int ownerLevel) {
		return ownerLevel >= qt.getAcceptMinLevel();
	}
	
	public final boolean preQuestCheckOnAccept(QuestTemplate qt) {
		int preId = qt.getPreQuestId();
		if (preId > 0) {
			return isFinished(preId);
		}
		return true;
	}
	
	public final boolean teamMemberNumCheck(QuestTemplate qt, int teamMemberNum) {
		return teamMemberNum >= qt.getMinTeamMemberNum();
	}
	
	@SuppressWarnings("rawtypes")
	public abstract List<AbstractTask> getDoingTaskList();
	
	public abstract boolean isFinished(int questId);
	
	/**
	 * 任务的特殊条件判定，默认为true，如果需要则各自去实现
	 * @return
	 */
	public boolean canAcceptSpecialCheck(int questId) {
		return true;
	}
	
	/**
	 * 获取怪物对应的任务奖励Id
	 * @param ememyArmyId
	 * @return
	 */
	public Map<Integer,Integer> getTaskRewardByEmemyArmy(int ememyArmyId) {
		return null;
	}
}
