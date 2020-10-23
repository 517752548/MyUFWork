package com.imop.lj.gameserver.skill.template;

import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.battle.core.BattleDef.SkillCostType;
import com.imop.lj.gameserver.pet.PetDef.SkillType;

/**
 * 技能配置
 * 
 */
@ExcelRowBinding
public class SkillTemplate extends SkillTemplateVO {
	/** 临时数据，初始化完后，就清空了 Map<心法Id,Map<心法等级key,Map<技能等级key,效果Id列表>>> */
	private Map<Integer, Map<Integer, Map<Integer, List<Integer>>>> tmpEffectIdMap = Maps.newHashMap();
	
	/** Map<心法Id,Map<心法等级,Map<技能等级,效果Id列表>>> */
	private Map<Integer, Map<Byte, Map<Byte, List<Integer>>>> effectIdMap = Maps.newHashMap();
	
	private boolean hasMindIdLimit;
	private boolean hasMindLevelLimit;
	private boolean hasSkillLevelLimit;
	
	@Override
	public void check() throws TemplateConfigException {
		SkillType st = SkillType.valueOf(this.skillTypeId);
		if (null == st) {
			throw new TemplateConfigException(this.sheetName, this.id, "技能类型非法！" + skillTypeId);
		}
		//心法被动技能必须是被动技能
		if (isMindB() && !isPassive()) {
			throw new TemplateConfigException(this.sheetName, this.id, "心法被动技能必须是被动技能！");
		}
		
		SkillCostType sct = SkillCostType.valueOf(getCostTypeId());
		if (sct == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "技能消耗类型非法！" + getCostTypeId());
		}
		
//		//如果是天赋技能，并且是被动技能，需要在宠物天赋被动技能表中配置
//		if (isTalent() && isPassive()) {
//			PetPassiveTalentSkillTemplate ptsTpl = templateService.get(this.id, PetPassiveTalentSkillTemplate.class);
//			if (ptsTpl == null) {
//				throw new TemplateConfigException(this.sheetName, this.id, "缺少 宠物被动天赋技能 的配置！skillId=" + this.id);
//			}
//		}
		
		//人物学习技能必须配置升级消耗参数
		if (isLeaderStudy()) {
			if (getUpgradeCostPos() <= 0 || getUpgradeCostCoef() <= 0) {
				throw new TemplateConfigException(this.sheetName, this.id, "人物学习技能升级消耗参数不能为空！" + this.id);
			}
		}
	}
	
	public SkillCostType getSkillCostType() {
		return SkillCostType.valueOf(getCostTypeId());
	}
	
	/**
	 * 是否被动技能
	 * @return
	 */
	public boolean isPassive() {
		return this.getIsPassive() == 1;
	}
	
	public SkillType getSkillType() {
		return SkillType.valueOf(this.skillTypeId);
	}

	public boolean isHasMindIdLimit() {
		return hasMindIdLimit;
	}

	public void setHasMindIdLimit(boolean hasMindIdLimit) {
		this.hasMindIdLimit = hasMindIdLimit;
	}

	public boolean isHasMindLevelLimit() {
		return hasMindLevelLimit;
	}

	public void setHasMindLevelLimit(boolean hasMindLevelLimit) {
		this.hasMindLevelLimit = hasMindLevelLimit;
	}

	public boolean isHasSkillLevelLimit() {
		return hasSkillLevelLimit;
	}

	public void setHasSkillLevelLimit(boolean hasSkillLevelLimit) {
		this.hasSkillLevelLimit = hasSkillLevelLimit;
	}

	public Map<Integer, Map<Integer, Map<Integer, List<Integer>>>> getTmpEffectIdMap() {
		return tmpEffectIdMap;
	}
	
	public Map<Integer, Map<Byte, Map<Byte, List<Integer>>>> getEffectIdMap() {
		return effectIdMap;
	}
	
	/**
	 * 是否心法被动技能
	 * @return
	 */
	public boolean isMindB() {
		return getSkillType() == SkillType.MIND_B;
	}
	
	/**
	 * 是否心法主动技能
	 * @return
	 */
	public boolean isMindA() {
		return getSkillType() == SkillType.MIND_A;
	}
	
	/**
	 * 是否心法技能
	 * @return
	 */
	public boolean isMind() {
		return getSkillType() == SkillType.MIND_A || getSkillType() == SkillType.MIND_B;
	}
	
	public boolean isTalent() {
		return getSkillType() == SkillType.PET_TALENT;
	}
	
	/**
	 * 技能能否镶嵌仙符
	 * @return
	 */
	public boolean canEmbedSkillEffect() {
		return getEmbedEffect() == 1;
	}
	
	/**
	 * 是否主将学习技能
	 * @return
	 */
	public boolean isLeaderStudy() {
		return getSkillType() == SkillType.LEADER_STUDY;
	}
	
}
