package com.imop.lj.gameserver.task.dest;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.PetSkillEffectInfo;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;

public class SkillEffectEmbedDest extends AbstractQuestDestination {
	private int num;
	private int color;
	private int level;
	
	public SkillEffectEmbedDest(int questId, int num, int color, int level) {
		super(questId);
		this.num = num;
		this.color = color;
		this.level = level;
	}

	@Override
	public DestType getDestType() {
		return DestType.SKILL_EFFECT_EMBED_NUM_X_COLOR_Y_LEVEL_Z;
	}

	@Override
	public int getRequiredNum() {
		return 1;
	}

	@Override
	public Object getInstKey() {
		return "SKILL_EFFECT_EMBED_NUM_" + this.num + "_COLOR_"+ this.color +"_LEVEL_" + this.level;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		if (!(task.getOwner() instanceof Human)) {
			return false;
		}
		
		int hadNum = 0;
		Human human = (Human)task.getOwner();
		for (PetSkillInfo skillInfo : human.getPetManager().getLeader().getSkillMap().values()) {
			//不能镶嵌仙符的技能跳过
			if (!skillInfo.getSkillTemplate().canEmbedSkillEffect()) {
				continue;
			}
			for (PetSkillEffectInfo eInfo : skillInfo.getEmbedEffectList()) {
				if (eInfo.isEmptyPos()) {
					continue;
				}
				
				//颜色和等级满足要求就+1
				if (eInfo.getEffectItemTemplate().getRarityId() >= getColor() &&
						eInfo.getEffectLevel() >= getLevel()) {
					hadNum++;
					if (hadNum >= getNum()) {
						return true;
					}
				}
			}
		}
		
		return false;
	}

	public int getNum() {
		return num;
	}

	public int getColor() {
		return color;
	}

	public int getLevel() {
		return level;
	}

	/**
	 * 验证参数是否正确
	 */
	public static void check(int num, int color, int level) throws TemplateConfigException{
		if (num <= 0) {
			throw new TemplateConfigException("任务表", 0, "镶嵌仙符数量不能小于或等于0");
		}
	}
}
