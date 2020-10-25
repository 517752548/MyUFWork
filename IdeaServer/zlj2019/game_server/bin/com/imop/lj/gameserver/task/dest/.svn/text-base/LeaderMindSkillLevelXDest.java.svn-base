package com.imop.lj.gameserver.task.dest;

import java.util.Set;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;

public class LeaderMindSkillLevelXDest extends AbstractQuestDestination {
	private int mindSkillLevel;
	
	public LeaderMindSkillLevelXDest(int questId, int leaderLevel) {
		super(questId);
		this.mindSkillLevel = leaderLevel;
	}

	@Override
	public DestType getDestType() {
		return DestType.LEADER_MIND_SKILL_LEVEL_X;
	}

	@Override
	public int getRequiredNum() {
		return 1;
	}

	@Override
	public Object getInstKey() {
		return "LEADER_MIND_SKILL_LEVEL_" + this.mindSkillLevel;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		if (!(task.getOwner() instanceof Human)) {
			return false;
		}
		
		Human human = (Human)task.getOwner();
		//检查心法主动技能等级是否满足要求
		Set<Integer> mindAkillList = Globals.getTemplateCacheService().getHumanSkillTemplateCache().getjobToMindASkillMap(human.getJobType());
		if (mindAkillList == null || mindAkillList.isEmpty()) {
			return false;
		}
		for (Integer skillId : mindAkillList) {
			PetSkillInfo skillInfo = human.getPetManager().getLeader().getSkillInfo(skillId);
			if (skillInfo != null && skillInfo.getLevel() >= getNeedLevel()) {
				return true;
			}
		}
		return false;
	}

	public int getNeedLevel() {
		return mindSkillLevel;
	}

	/**
	 * 验证参数是否正确
	 */
	public static void check(int level) throws TemplateConfigException{
		if (level <= 0) {
			throw new TemplateConfigException("任务表", 0, "心法技能等级不能小于或等于0");
		}
	}
}
