package com.imop.lj.gameserver.enemy.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.PetDef.Sex;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 单个怪物表
 * 
 */
@ExcelRowBinding
public class EnemyTemplate extends EnemyTemplateVO {
	
	private List<SkillItem> validSkillList = new ArrayList<SkillItem>();

	@Override
	public void check() throws TemplateConfigException {
		
		for (SkillItem esi : this.skillList) {
			int skillId = esi.getSkillId(); 
			if (skillId > 0) {
				if (templateService.get(skillId, SkillTemplate.class) == null) {
					throw new TemplateConfigException(sheetName, id, "skillId not exist! " + skillId);
				}
				//技能
				validSkillList.add(esi);
			}
		}
		
		//宠物Id是否存在，且类型是否宠物
		if (this.petTplId > 0) {
			PetTemplate petTpl = templateService.get(this.petTplId, PetTemplate.class);
			if (petTpl == null) {
				throw new TemplateConfigException(sheetName, id, "宠物Id不存在!" + petTplId);
			}
			if (petTpl.getPetType() != PetType.PET) {
				throw new TemplateConfigException(sheetName, id, "宠物Id不是宠物!" + petTplId);
			}
		}
		
		//单个怪物系数表中是否存在该怪物配置
		if (templateService.get(getId(), EnemyCoefTemplate.class) == null) {
			throw new TemplateConfigException(sheetName, id, "单个怪物系数表-怪物Id不存在! " + getId());
		}
	}

	@Override
	public void patchUp() throws Exception {
		
	}

	public PetAttackType getPetAttackType() {
		return PetAttackType.valueOf(this.getAttackTypeId());
	}
	
	public JobType getJobType() {
		return JobType.valueOf(this.getJobId());
	}
	
	public Sex getSex() {
		return Sex.valueOf(this.getSexId());
	}

	/**
	 * 获取技能信息列表
	 * @return
	 */
	public List<SkillItem> getValidSkillList() {
		return validSkillList;
	}
	
	/**
	 * 该怪物是否是一个可抓的宠物
	 * @return
	 */
	public boolean canCatch() {
		return this.petTplId > 0;
	}

	public PetType getPetType() {
		return PetType.MONSTER;
	}
	
}
