package com.imop.lj.gameserver.task.cond;

import java.util.List;

import com.imop.lj.gameserver.human.Human;

/**
 * 检查前置任务是否已完成
 *
 *
 */
public class PreQuestCondition implements IQuestCondition {

	/** 前置任务的ID */
	private List<Integer> questIds;

	public PreQuestCondition(List<Integer> questIds) {
		this.questIds = questIds;
	}

	public List<Integer> getQuestIds() {
		return this.questIds;
	}

	@Override
	public boolean canAccept(Human human) {
		return true;
	}

	@Override
	public boolean canSee(Human human) {
		return true;
	}

	@Override
	public boolean onAccept(Human human) {
		return true;
	}

	@Override
	public String getErrorDesc(Human human) {
		return null;
	}

}
