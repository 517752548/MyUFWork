package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.feature.NormalFeature;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.SkillType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 人物技能书
 */
@ExcelRowBinding
public class LeaderSkillBookTemplate extends LeaderSkillBookTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//技能id是否存在
		SkillTemplate skillTpl = templateService.get(this.skillId, SkillTemplate.class);
		if (skillTpl == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "技能Id不存在！ skillId=" + this.skillId);
		}
		//不是人物学习技能
		if (skillTpl.getSkillType() != SkillType.LEADER_STUDY) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "技能Id不是 人物学习技能！ skillId=" + this.skillId);
		}
		
		//职业限制
		if (getFirstJob() == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "职业限制非法！jobLimit=" + getJobLimit());
		}
	}
	
	@Override
	public boolean canPutOn(Pet pet) {
		JobType job = pet.getJobType();
		if (job == null) {
			return false;
		}
		
		boolean jobFlag = false;
		int jobId = job.getIndex();
		//职业要求
		if ((getJobLimit() & jobId) == jobId) {
			jobFlag = true;
		}
		return jobFlag;
	}

	/**
	 * 获取职业限制的第一个职业
	 * @return
	 */
	public JobType getFirstJob() {
		JobType[] arr = JobType.values();
		for (int i = 0; i < arr.length; i++) {
			JobType job = arr[i];
			if ((job.getIndex() & getJobLimit()) == job.getIndex()) {
				return job;
			}
		}
		return null;
	}
	
	@Override
	public Position getPosition() {
		return Position.NULL;
	}
	
	@Override
	public boolean isConsumable() {
		return false;
	}

	@Override
	public boolean isEquipment() {
		return false;
	}

	@Override
	public AttrDesc[] getAllAttrs() {
		return null;
	}

	@Override
	public ItemFeature initItemFeature(Item item) {
		return new NormalFeature(item);
	}

	@Override
	public boolean isGem() {
		return false;
	}
	
	@Override
	public boolean isSkillEffectItem() {
		return false;
	}
}
