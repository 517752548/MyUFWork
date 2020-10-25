package com.imop.lj.gameserver.team.task;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.AbstractTaskManager;
import com.imop.lj.gameserver.team.model.Team;

public class TeamTaskManager extends AbstractTaskManager<Team> {
	/** 队伍当前任务 */
	private TeamTask curTask;

	/** 已完成的任务Id集合 */
	private Set<Integer> finishedTaskSet = new HashSet<Integer>();
	
	public TeamTaskManager(Team owner) {
		super(owner);
	}
	
	public TeamTask getCurTask() {
		return curTask;
	}

	public void setCurTask(TeamTask curTask) {
		this.curTask = curTask;
	}
	
	public void clearFinishedSet() {
		finishedTaskSet.clear();
	}

	public void addFinishedTask(int questId) {
		//加入已完成的集合
		if (!finishedTaskSet.contains(questId)) {
			finishedTaskSet.add(questId);
		}
	}
	
	/**
	 * 是否有正在进行的任务
	 * @return
	 */
	public boolean isDoing() {
		return this.curTask != null && this.curTask.isDoing();
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
	public boolean isFinished(int questId) {
		return this.finishedTaskSet.contains(questId);
	}

}
