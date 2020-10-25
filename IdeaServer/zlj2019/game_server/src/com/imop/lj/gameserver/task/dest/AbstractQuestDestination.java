package com.imop.lj.gameserver.task.dest;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;


/**
 * @see IQuestDestination
 * 
 * 
 */
public abstract class AbstractQuestDestination implements IQuestDestination {

	private int questId;

	public AbstractQuestDestination(int questId) {
		super();
		this.questId = questId;
	}

	public int getQuestId() {
		return questId;
	}
	
	
	@Override
	public boolean canAccept(Human human) {
		return true;
	}
	
	@Override
	public void onAccept(Human human) {
	}

	@Override
	public boolean onQuestFinish(Human human) {
		return true;
	}
	
	@Override
	public boolean onDestFinish(Human human) {
		return true;
	}
	
	@Override
	public boolean isInFinishStatus(Human human) {
		return true;
	}
	
	@Override
	public boolean onQuestGiveUp(Human human) {
		return true;
	}
	
	@Override
	public void onLoad() {
	}
	
	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		return false;
	}
	
	@SuppressWarnings("rawtypes")
	@Override
	public boolean init(AbstractTask task) {
		return true;
	}
	
	@SuppressWarnings("rawtypes")
	public boolean onFinishTask(AbstractTask task) {
		return true;
	}
	
	public boolean canStatusBack() {
		return false;
	}
	
	@SuppressWarnings("rawtypes")
	public int getGotNum(AbstractTask task) {
		return 0;
	}
}
