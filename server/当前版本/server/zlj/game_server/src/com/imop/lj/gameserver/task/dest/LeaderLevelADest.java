package com.imop.lj.gameserver.task.dest;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;

public class LeaderLevelADest extends AbstractQuestDestination {
	private int leaderLevel;
	
	public LeaderLevelADest(int questId, int leaderLevel) {
		super(questId);
		this.leaderLevel = leaderLevel;
	}

	@Override
	public DestType getDestType() {
		return DestType.LEADER_LEVEL_A;
	}

	@Override
	public int getRequiredNum() {
		return 1;
	}

	@Override
	public Object getInstKey() {
		return "LEADER_LEVEL_" + this.leaderLevel;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		if (!(task.getOwner() instanceof Human)) {
			return false;
		}
		if (task.getOwner().getLevel() >= getLeaderLevel()) {
			return true;
		} else {
			return false;
		}
	}

	public int getLeaderLevel() {
		return leaderLevel;
	}

	/**
	 * 验证参数是否正确
	 */
	public static void check(int level) throws TemplateConfigException{
		if (level <= 0) {
			throw new TemplateConfigException("任务表", 0, "主将等级不能小于或等于0");
		}
	}
}
