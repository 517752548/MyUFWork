package com.imop.lj.gameserver.pet.template;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.pet.PetDef.SkillType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 宠物天赋技能包
 * 
 */
@ExcelRowBinding
public class PetTalentSkillPackTemplate extends PetTalentSkillPackTemplateVO {
	
	private List<Integer> weightList = new ArrayList<Integer>();
	private List<Integer> skillIdList = new ArrayList<Integer>();
	
	@Override
	public void check() throws TemplateConfigException {
		//去掉数量限制
//		if (getTalentSkillList().size() != Globals.getGameConstants().getPetTalentSkillNumMax()) {
//			throw new TemplateConfigException(this.sheetName, this.id, "技能包的数量非法!" + getTalentSkillList().size());
//		}
		
		Set<Integer> cs = new HashSet<Integer>();
		//数量必须是15个,且每个都有数据，且不能重复
		for (TalentSkillItem tsi : getTalentSkillList()) {
			if(tsi.getSkillId() <= 0 ){
				continue;
			}
			SkillTemplate skillTpl = templateService.get(tsi.getSkillId(), SkillTemplate.class);
			if (skillTpl == null) {
				throw new TemplateConfigException(this.sheetName, this.id, "技能ID不存在! " + tsi.getSkillId());
			}
			if (skillTpl.getSkillType() != SkillType.PET_TALENT) {
				throw new TemplateConfigException(this.sheetName, this.id, "技能不是宠物天赋技能! " + tsi.getSkillId());
			}
			weightList.add(tsi.getWeight());
			skillIdList.add(tsi.getSkillId());
			if (!cs.contains(tsi.getSkillId())) {
				cs.add(tsi.getSkillId());
			} else {
				throw new TemplateConfigException(this.sheetName, this.id, "技能ID重复! " + tsi.getSkillId());
			}
		}
	}
	
	public List<Integer> getWeightList() {
		return this.weightList;
	}
	
	public List<Integer> getSkillIdList() {
		return this.skillIdList;
	}
	
}
