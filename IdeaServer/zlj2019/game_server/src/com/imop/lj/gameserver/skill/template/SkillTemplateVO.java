package com.imop.lj.gameserver.skill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 技能配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillTemplateVO extends TemplateObject {

	/** 名称多语言Id */
	@ExcelCellBinding(offset = 1)
	protected long nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 描述多语言Id */
	@ExcelCellBinding(offset = 3)
	protected long descLangId;

	/** 描述 */
	@ExcelCellBinding(offset = 4)
	protected String descInfo;

	/** 能否镶嵌仙符（0不能，1能） */
	@ExcelCellBinding(offset = 5)
	protected int embedEffect;

	/** 是否被动技能，0否，1是 */
	@ExcelCellBinding(offset = 6)
	protected int isPassive;

	/** 技能类型（0普通技能，1宠物天赋技能，2宠物普通技能） */
	@ExcelCellBinding(offset = 7)
	protected int skillTypeId;

	/** 技能冒字资源 */
	@ExcelCellBinding(offset = 8)
	protected String bubble;

	/** 技能icon */
	@ExcelCellBinding(offset = 9)
	protected String icon;

	/** 是否不需要表现，0需要，1不需要 */
	@ExcelCellBinding(offset = 10)
	protected int notNeedShow;

	/** 是否在头顶显示名称,0不显示，1显示 */
	@ExcelCellBinding(offset = 11)
	protected int needShowOnRelease;

	/** 消耗类型 1、魔法 2、怒气 3、寿命 */
	@ExcelCellBinding(offset = 12)
	protected int costTypeId;

	/** 初始消耗 */
	@ExcelCellBinding(offset = 13)
	protected int costBase;

	/** 增量消耗 */
	@ExcelCellBinding(offset = 14)
	protected int costAdd;

	/** 战力及评分系数 */
	@ExcelCellBinding(offset = 15)
	protected int skillScore;

	/** 人物学习技能升级消耗位置 */
	@ExcelCellBinding(offset = 16)
	protected int upgradeCostPos;

	/** 人物学习技能升级消耗系数（放大1000倍） */
	@ExcelCellBinding(offset = 17)
	protected int upgradeCostCoef;


	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		this.nameLangId = nameLangId;
	}
	
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
	
	public long getDescLangId() {
		return this.descLangId;
	}

	public void setDescLangId(long descLangId) {
		this.descLangId = descLangId;
	}
	
	public String getDescInfo() {
		return this.descInfo;
	}

	public void setDescInfo(String descInfo) {
		if (descInfo != null) {
			this.descInfo = descInfo.trim();
		}else{
			this.descInfo = descInfo;
		}
	}
	
	public int getEmbedEffect() {
		return this.embedEffect;
	}

	public void setEmbedEffect(int embedEffect) {
		if (embedEffect > 1 || embedEffect < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[能否镶嵌仙符（0不能，1能）]embedEffect的值不合法，应为0至1之间");
		}
		this.embedEffect = embedEffect;
	}
	
	public int getIsPassive() {
		return this.isPassive;
	}

	public void setIsPassive(int isPassive) {
		if (isPassive < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[是否被动技能，0否，1是]isPassive的值不得小于0");
		}
		this.isPassive = isPassive;
	}
	
	public int getSkillTypeId() {
		return this.skillTypeId;
	}

	public void setSkillTypeId(int skillTypeId) {
		if (skillTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[技能类型（0普通技能，1宠物天赋技能，2宠物普通技能）]skillTypeId的值不得小于0");
		}
		this.skillTypeId = skillTypeId;
	}
	
	public String getBubble() {
		return this.bubble;
	}

	public void setBubble(String bubble) {
		if (bubble != null) {
			this.bubble = bubble.trim();
		}else{
			this.bubble = bubble;
		}
	}
	
	public String getIcon() {
		return this.icon;
	}

	public void setIcon(String icon) {
		if (icon != null) {
			this.icon = icon.trim();
		}else{
			this.icon = icon;
		}
	}
	
	public int getNotNeedShow() {
		return this.notNeedShow;
	}

	public void setNotNeedShow(int notNeedShow) {
		if (notNeedShow > 1 || notNeedShow < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[是否不需要表现，0需要，1不需要]notNeedShow的值不合法，应为0至1之间");
		}
		this.notNeedShow = notNeedShow;
	}
	
	public int getNeedShowOnRelease() {
		return this.needShowOnRelease;
	}

	public void setNeedShowOnRelease(int needShowOnRelease) {
		if (needShowOnRelease > 1 || needShowOnRelease < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[是否在头顶显示名称,0不显示，1显示]needShowOnRelease的值不合法，应为0至1之间");
		}
		this.needShowOnRelease = needShowOnRelease;
	}
	
	public int getCostTypeId() {
		return this.costTypeId;
	}

	public void setCostTypeId(int costTypeId) {
		if (costTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[消耗类型 1、魔法 2、怒气 3、寿命]costTypeId的值不得小于0");
		}
		this.costTypeId = costTypeId;
	}
	
	public int getCostBase() {
		return this.costBase;
	}

	public void setCostBase(int costBase) {
		if (costBase < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[初始消耗]costBase的值不得小于0");
		}
		this.costBase = costBase;
	}
	
	public int getCostAdd() {
		return this.costAdd;
	}

	public void setCostAdd(int costAdd) {
		if (costAdd < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[增量消耗]costAdd的值不得小于0");
		}
		this.costAdd = costAdd;
	}
	
	public int getSkillScore() {
		return this.skillScore;
	}

	public void setSkillScore(int skillScore) {
		if (skillScore < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[战力及评分系数]skillScore的值不得小于0");
		}
		this.skillScore = skillScore;
	}
	
	public int getUpgradeCostPos() {
		return this.upgradeCostPos;
	}

	public void setUpgradeCostPos(int upgradeCostPos) {
		if (upgradeCostPos < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[人物学习技能升级消耗位置]upgradeCostPos的值不得小于0");
		}
		this.upgradeCostPos = upgradeCostPos;
	}
	
	public int getUpgradeCostCoef() {
		return this.upgradeCostCoef;
	}

	public void setUpgradeCostCoef(int upgradeCostCoef) {
		if (upgradeCostCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					18, "[人物学习技能升级消耗系数（放大1000倍）]upgradeCostCoef的值不得小于0");
		}
		this.upgradeCostCoef = upgradeCostCoef;
	}
	

	@Override
	public String toString() {
		return "SkillTemplateVO[nameLangId=" + nameLangId + ",name=" + name + ",descLangId=" + descLangId + ",descInfo=" + descInfo + ",embedEffect=" + embedEffect + ",isPassive=" + isPassive + ",skillTypeId=" + skillTypeId + ",bubble=" + bubble + ",icon=" + icon + ",notNeedShow=" + notNeedShow + ",needShowOnRelease=" + needShowOnRelease + ",costTypeId=" + costTypeId + ",costBase=" + costBase + ",costAdd=" + costAdd + ",skillScore=" + skillScore + ",upgradeCostPos=" + upgradeCostPos + ",upgradeCostCoef=" + upgradeCostCoef + ",]";

	}
}