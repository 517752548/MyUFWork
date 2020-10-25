package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 骑宠天赋技能升级
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorseTalentSkillLevelTemplateVO extends TemplateObject {

	/** 宠物天赋技能Id */
	@ExcelCellBinding(offset = 1)
	protected int talentSkillId;

	/** 技能等级 */
	@ExcelCellBinding(offset = 2)
	protected int skillLevel;

	/** 所需宠物等级 */
	@ExcelCellBinding(offset = 3)
	protected int needPetLevel;


	public int getTalentSkillId() {
		return this.talentSkillId;
	}

	public void setTalentSkillId(int talentSkillId) {
		if (talentSkillId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[宠物天赋技能Id]talentSkillId的值不得小于1");
		}
		this.talentSkillId = talentSkillId;
	}
	
	public int getSkillLevel() {
		return this.skillLevel;
	}

	public void setSkillLevel(int skillLevel) {
		if (skillLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[技能等级]skillLevel的值不得小于1");
		}
		this.skillLevel = skillLevel;
	}
	
	public int getNeedPetLevel() {
		return this.needPetLevel;
	}

	public void setNeedPetLevel(int needPetLevel) {
		if (needPetLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[所需宠物等级]needPetLevel的值不得小于1");
		}
		this.needPetLevel = needPetLevel;
	}
	

	@Override
	public String toString() {
		return "PetHorseTalentSkillLevelTemplateVO[talentSkillId=" + talentSkillId + ",skillLevel=" + skillLevel + ",needPetLevel=" + needPetLevel + ",]";

	}
}