package com.imop.lj.gameserver.task.dest;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;

public class LeaderMindLevelADest extends AbstractQuestDestination {
	private int mindLevel;
	
	public LeaderMindLevelADest(int questId, int leaderLevel) {
		super(questId);
		this.mindLevel = leaderLevel;
	}

	@Override
	public DestType getDestType() {
		return DestType.LEADER_MIND_LEVEL_A;
	}

	@Override
	public int getRequiredNum() {
		return 1;
	}

	@Override
	public Object getInstKey() {
		return "LEADER_MIND_LEVEL_" + this.mindLevel;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		if (!(task.getOwner() instanceof Human)) {
			return false;
		}
		Human human = ((Human)task.getOwner());
		boolean destFlag = false;
		for(int mindLevel : human.getMainSkillMap().values()){
			if(mindLevel >= getNeedMindLevel()){
				destFlag = true;
				break;
			}
		}
		
		return destFlag;
	}

	public int getNeedMindLevel() {
		return mindLevel;
	}

	/**
	 * 验证参数是否正确
	 */
	public static void check(int level) throws TemplateConfigException{
		if (level <= 0) {
			throw new TemplateConfigException("任务表", 0, "心法等级不能小于或等于0");
		}
	}
}
