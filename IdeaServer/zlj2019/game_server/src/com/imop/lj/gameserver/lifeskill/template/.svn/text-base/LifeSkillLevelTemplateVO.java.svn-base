package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * 生活技能升级消耗
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class LifeSkillLevelTemplateVO extends TemplateObject {

	/** 技能ID */
	@ExcelCellBinding(offset = 1)
	protected int lifeSkillId;

	/** 技能名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 所需玩家等级 */
	@ExcelCellBinding(offset = 3)
	protected int needHumanLevel;

	/** 技能等级 */
	@ExcelCellBinding(offset = 4)
	protected int lifeSkillLevel;

	/** 升级技能层数熟练度列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost.class, collectionNumber = "5;6;7;8;9;10;11;12")
	protected List<com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost> lifeSkillCostList;

	/** 单次可获资源最大值 */
	@ExcelCellBinding(offset = 13)
	protected int maxResNum;

	/** 道具Id */
	@ExcelCellBinding(offset = 14)
	protected int itemId;

	/** 道具名称 */
	@ExcelCellBinding(offset = 15)
	protected String itemName;

	/** 消耗技能书Id */
	@ExcelCellBinding(offset = 16)
	protected int lifeSkillBookId;

	/** 升级描述 */
	@ExcelCellBinding(offset = 17)
	protected String upgradeDes;


	public int getLifeSkillId() {
		return this.lifeSkillId;
	}

	public void setLifeSkillId(int lifeSkillId) {
		if (lifeSkillId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[技能ID]lifeSkillId不可以为0");
		}
		if (lifeSkillId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[技能ID]lifeSkillId的值不得小于1");
		}
		this.lifeSkillId = lifeSkillId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[技能名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getNeedHumanLevel() {
		return this.needHumanLevel;
	}

	public void setNeedHumanLevel(int needHumanLevel) {
		if (needHumanLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[所需玩家等级]needHumanLevel不可以为0");
		}
		if (needHumanLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[所需玩家等级]needHumanLevel的值不得小于1");
		}
		this.needHumanLevel = needHumanLevel;
	}
	
	public int getLifeSkillLevel() {
		return this.lifeSkillLevel;
	}

	public void setLifeSkillLevel(int lifeSkillLevel) {
		if (lifeSkillLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[技能等级]lifeSkillLevel不可以为0");
		}
		if (lifeSkillLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[技能等级]lifeSkillLevel的值不得小于1");
		}
		this.lifeSkillLevel = lifeSkillLevel;
	}
	
	public List<com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost> getLifeSkillCostList() {
		return this.lifeSkillCostList;
	}

	public void setLifeSkillCostList(List<com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost> lifeSkillCostList) {
		if (lifeSkillCostList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[升级技能层数熟练度列表]lifeSkillCostList不可以为空");
		}	
		this.lifeSkillCostList = lifeSkillCostList;
	}
	
	public int getMaxResNum() {
		return this.maxResNum;
	}

	public void setMaxResNum(int maxResNum) {
		if (maxResNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[单次可获资源最大值]maxResNum不可以为0");
		}
		if (maxResNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[单次可获资源最大值]maxResNum的值不得小于1");
		}
		this.maxResNum = maxResNum;
	}
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[道具Id]itemId不可以为0");
		}
		if (itemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[道具Id]itemId的值不得小于1");
		}
		this.itemId = itemId;
	}
	
	public String getItemName() {
		return this.itemName;
	}

	public void setItemName(String itemName) {
		if (StringUtils.isEmpty(itemName)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[道具名称]itemName不可以为空");
		}
		if (itemName != null) {
			this.itemName = itemName.trim();
		}else{
			this.itemName = itemName;
		}
	}
	
	public int getLifeSkillBookId() {
		return this.lifeSkillBookId;
	}

	public void setLifeSkillBookId(int lifeSkillBookId) {
		this.lifeSkillBookId = lifeSkillBookId;
	}
	
	public String getUpgradeDes() {
		return this.upgradeDes;
	}

	public void setUpgradeDes(String upgradeDes) {
		if (StringUtils.isEmpty(upgradeDes)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					18, "[升级描述]upgradeDes不可以为空");
		}
		if (upgradeDes != null) {
			this.upgradeDes = upgradeDes.trim();
		}else{
			this.upgradeDes = upgradeDes;
		}
	}
	

	@Override
	public String toString() {
		return "LifeSkillLevelTemplateVO[lifeSkillId=" + lifeSkillId + ",name=" + name + ",needHumanLevel=" + needHumanLevel + ",lifeSkillLevel=" + lifeSkillLevel + ",lifeSkillCostList=" + lifeSkillCostList + ",maxResNum=" + maxResNum + ",itemId=" + itemId + ",itemName=" + itemName + ",lifeSkillBookId=" + lifeSkillBookId + ",upgradeDes=" + upgradeDes + ",]";

	}
}