package com.imop.lj.gameserver.skill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 技能效果配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillAddTemplateVO extends TemplateObject {

	/** 技能Id */
	@ExcelCellBinding(offset = 1)
	protected int skillId;

	/** 心法Id */
	@ExcelCellBinding(offset = 2)
	protected int mindId;

	/** 心法等级下限 */
	@ExcelCellBinding(offset = 3)
	protected int mindLevelMin;

	/** 心法等级上限 */
	@ExcelCellBinding(offset = 4)
	protected int mindLevelMax;

	/** 技能等级下限 */
	@ExcelCellBinding(offset = 5)
	protected int skillLevelMin;

	/** 技能等级上限 */
	@ExcelCellBinding(offset = 6)
	protected int skillLevelMax;

	/** 技能效果Id列表 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "7;8;9;10;11")
	protected List<Integer> effectIdList;


	public int getSkillId() {
		return this.skillId;
	}

	public void setSkillId(int skillId) {
		if (skillId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[技能Id]skillId的值不得小于1");
		}
		this.skillId = skillId;
	}
	
	public int getMindId() {
		return this.mindId;
	}

	public void setMindId(int mindId) {
		if (mindId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[心法Id]mindId的值不得小于0");
		}
		this.mindId = mindId;
	}
	
	public int getMindLevelMin() {
		return this.mindLevelMin;
	}

	public void setMindLevelMin(int mindLevelMin) {
		if (mindLevelMin < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[心法等级下限]mindLevelMin的值不得小于0");
		}
		this.mindLevelMin = mindLevelMin;
	}
	
	public int getMindLevelMax() {
		return this.mindLevelMax;
	}

	public void setMindLevelMax(int mindLevelMax) {
		if (mindLevelMax < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[心法等级上限]mindLevelMax的值不得小于0");
		}
		this.mindLevelMax = mindLevelMax;
	}
	
	public int getSkillLevelMin() {
		return this.skillLevelMin;
	}

	public void setSkillLevelMin(int skillLevelMin) {
		if (skillLevelMin < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[技能等级下限]skillLevelMin的值不得小于0");
		}
		this.skillLevelMin = skillLevelMin;
	}
	
	public int getSkillLevelMax() {
		return this.skillLevelMax;
	}

	public void setSkillLevelMax(int skillLevelMax) {
		if (skillLevelMax < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[技能等级上限]skillLevelMax的值不得小于0");
		}
		this.skillLevelMax = skillLevelMax;
	}
	
	public List<Integer> getEffectIdList() {
		return this.effectIdList;
	}

	public void setEffectIdList(List<Integer> effectIdList) {
		if (effectIdList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[技能效果Id列表]effectIdList不可以为空");
		}	
		this.effectIdList = effectIdList;
	}
	

	@Override
	public String toString() {
		return "SkillAddTemplateVO[skillId=" + skillId + ",mindId=" + mindId + ",mindLevelMin=" + mindLevelMin + ",mindLevelMax=" + mindLevelMax + ",skillLevelMin=" + skillLevelMin + ",skillLevelMax=" + skillLevelMax + ",effectIdList=" + effectIdList + ",]";

	}
}