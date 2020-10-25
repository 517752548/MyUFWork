package com.imop.lj.gameserver.skill;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 骑宠技能加成配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillPetHorseAddTemplateVO extends TemplateObject {

	/** 技能名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 影响技能Id */
	@ExcelCellBinding(offset = 2)
	protected int effectSkillId;

	/** 技能应用场景 */
	@ExcelCellBinding(offset = 3)
	protected int scenarios;

	/** 附加参数1 */
	@ExcelCellBinding(offset = 4)
	protected int extraCoef1;

	/** 附加参数2 */
	@ExcelCellBinding(offset = 5)
	protected int extraCoef2;

	/** 附加参数3 */
	@ExcelCellBinding(offset = 6)
	protected int extraCoef3;

	/** 附加参数4 */
	@ExcelCellBinding(offset = 7)
	protected int extraCoef4;

	/** 附加参数5 */
	@ExcelCellBinding(offset = 8)
	protected int extraCoef5;

	/** 骑宠技能等级加成列表 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "9;10;11;12;13;14;15;16;17;18")
	protected List<Integer> levelAddList;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getEffectSkillId() {
		return this.effectSkillId;
	}

	public void setEffectSkillId(int effectSkillId) {
		if (effectSkillId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[影响技能Id]effectSkillId的值不得小于0");
		}
		this.effectSkillId = effectSkillId;
	}
	
	public int getScenarios() {
		return this.scenarios;
	}

	public void setScenarios(int scenarios) {
		if (scenarios < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[技能应用场景]scenarios的值不得小于0");
		}
		this.scenarios = scenarios;
	}
	
	public int getExtraCoef1() {
		return this.extraCoef1;
	}

	public void setExtraCoef1(int extraCoef1) {
		if (extraCoef1 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[附加参数1]extraCoef1的值不得小于0");
		}
		this.extraCoef1 = extraCoef1;
	}
	
	public int getExtraCoef2() {
		return this.extraCoef2;
	}

	public void setExtraCoef2(int extraCoef2) {
		if (extraCoef2 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[附加参数2]extraCoef2的值不得小于0");
		}
		this.extraCoef2 = extraCoef2;
	}
	
	public int getExtraCoef3() {
		return this.extraCoef3;
	}

	public void setExtraCoef3(int extraCoef3) {
		if (extraCoef3 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[附加参数3]extraCoef3的值不得小于0");
		}
		this.extraCoef3 = extraCoef3;
	}
	
	public int getExtraCoef4() {
		return this.extraCoef4;
	}

	public void setExtraCoef4(int extraCoef4) {
		if (extraCoef4 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[附加参数4]extraCoef4的值不得小于0");
		}
		this.extraCoef4 = extraCoef4;
	}
	
	public int getExtraCoef5() {
		return this.extraCoef5;
	}

	public void setExtraCoef5(int extraCoef5) {
		if (extraCoef5 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[附加参数5]extraCoef5的值不得小于0");
		}
		this.extraCoef5 = extraCoef5;
	}
	
	public List<Integer> getLevelAddList() {
		return this.levelAddList;
	}

	public void setLevelAddList(List<Integer> levelAddList) {
		if (levelAddList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[骑宠技能等级加成列表]levelAddList不可以为空");
		}	
		this.levelAddList = levelAddList;
	}
	

	@Override
	public String toString() {
		return "SkillPetHorseAddTemplateVO[name=" + name + ",effectSkillId=" + effectSkillId + ",scenarios=" + scenarios + ",extraCoef1=" + extraCoef1 + ",extraCoef2=" + extraCoef2 + ",extraCoef3=" + extraCoef3 + ",extraCoef4=" + extraCoef4 + ",extraCoef5=" + extraCoef5 + ",levelAddList=" + levelAddList + ",]";

	}
}