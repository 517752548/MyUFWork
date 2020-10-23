package com.imop.lj.gameserver.skill.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.pet.PetDef.MainSkillType;

/**
 * 技能效果配置
 * 
 */
@ExcelRowBinding
public class SkillAddTemplate extends SkillAddTemplateVO {
	
	private List<Integer> validEffectIdList = new ArrayList<Integer>();
	
	@Override
	public void check() throws TemplateConfigException {
		SkillTemplate skillTpl = templateService.get(this.skillId, SkillTemplate.class);
		// 技能Id是否存在
		if (skillTpl == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "技能Id不存在！" + skillId);
		}
		
		//心法Id是否存在
		if (this.mindId > 0) {
			if (MainSkillType.valueOf(this.mindId) == null) {
				throw new TemplateConfigException(this.sheetName, this.id, "心法Id不存在！" + mindId);
			}
		}
		//有心法等级的话，必须有心法Id限制
		if (this.mindId == 0 && (this.mindLevelMin > 0 || this.mindLevelMax > 0)) {
			throw new TemplateConfigException(this.sheetName, this.id, "有心法等级限制，但没有心法Id！");
		}
		
		//主效果必须配
		if (effectIdList.get(0) <= 0) {
			throw new TemplateConfigException(this.sheetName, this.id, "技能主效果值非法！" + effectIdList.get(0));
		}
		
		//验证效果Id是否存在
		for(Integer effectId : this.effectIdList) {
			if (effectId > 0) {
				if (templateService.get(effectId, SkillEffectTemplate.class) == null) {
					throw new TemplateConfigException(this.sheetName, this.id, "技能效果Id不存在！effectId=" + effectId);
				}
				validEffectIdList.add(effectId);
			}
		}
		
		//主动技能，主效果必须使用自身目标
		SkillEffectTemplate mainETpl = templateService.get(effectIdList.get(0), SkillEffectTemplate.class);
		if (!mainETpl.isTargetSelf() && !skillTpl.isPassive()) {
			//被动技能，可以作为主效果，但不用指定目标
			throw new TemplateConfigException(this.sheetName, this.id, "主效果必须使用自身目标！");
		}
		
		//等级下限要小于上限
		if (this.skillLevelMin > this.skillLevelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		if (!(this.skillLevelMin == 0 && this.skillLevelMax == 0)) {
			if (this.skillLevelMin == 0 || this.skillLevelMax == 0) {
				throw new TemplateConfigException(this.sheetName, this.id, "有等级段的技能，等级限制不能为0！");
			}
		}
		
		//等级下限要小于上限
		if (this.mindLevelMin > this.mindLevelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		if (!(this.mindLevelMin == 0 && this.mindLevelMax == 0)) {
			if (this.mindLevelMin == 0 || this.mindLevelMax == 0) {
				throw new TemplateConfigException(this.sheetName, this.id, "心法有等级段的技能，等级限制不能为0！");
			}
		}
	}
	
	public List<Integer> getValidEffectIdList() {
		return validEffectIdList;
	}
}
