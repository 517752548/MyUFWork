package com.imop.lj.gameserver.corpscultivate.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 帮派修炼消耗配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsCultivateCostTemplateVO extends TemplateObject {

	/** 当前修炼等级 */
	@ExcelCellBinding(offset = 1)
	protected int cultivateLevel;

	/** 需求玩家等级 */
	@ExcelCellBinding(offset = 2)
	protected int playerLevel;

	/** 需求帮派等级 */
	@ExcelCellBinding(offset = 3)
	protected int corpsLevel;

	/** 需求朱雀堂等级 */
	@ExcelCellBinding(offset = 4)
	protected int zqLevel;

	/** 修炼上限 */
	@ExcelCellBinding(offset = 5)
	protected int cultivateLimit;

	/** 修炼1次消耗帮贡 */
	@ExcelCellBinding(offset = 6)
	protected int costContri;

	/** 修炼升级所需经验 */
	@ExcelCellBinding(offset = 7)
	protected long costExp;


	public int getCultivateLevel() {
		return this.cultivateLevel;
	}

	public void setCultivateLevel(int cultivateLevel) {
		if (cultivateLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[当前修炼等级]cultivateLevel的值不得小于0");
		}
		this.cultivateLevel = cultivateLevel;
	}
	
	public int getPlayerLevel() {
		return this.playerLevel;
	}

	public void setPlayerLevel(int playerLevel) {
		if (playerLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[需求玩家等级]playerLevel的值不得小于0");
		}
		this.playerLevel = playerLevel;
	}
	
	public int getCorpsLevel() {
		return this.corpsLevel;
	}

	public void setCorpsLevel(int corpsLevel) {
		if (corpsLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[需求帮派等级]corpsLevel的值不得小于0");
		}
		this.corpsLevel = corpsLevel;
	}
	
	public int getZqLevel() {
		return this.zqLevel;
	}

	public void setZqLevel(int zqLevel) {
		if (zqLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[需求朱雀堂等级]zqLevel的值不得小于0");
		}
		this.zqLevel = zqLevel;
	}
	
	public int getCultivateLimit() {
		return this.cultivateLimit;
	}

	public void setCultivateLimit(int cultivateLimit) {
		if (cultivateLimit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[修炼上限]cultivateLimit的值不得小于0");
		}
		this.cultivateLimit = cultivateLimit;
	}
	
	public int getCostContri() {
		return this.costContri;
	}

	public void setCostContri(int costContri) {
		if (costContri < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[修炼1次消耗帮贡]costContri的值不得小于0");
		}
		this.costContri = costContri;
	}
	
	public long getCostExp() {
		return this.costExp;
	}

	public void setCostExp(long costExp) {
		if (costExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[修炼升级所需经验]costExp的值不得小于0");
		}
		this.costExp = costExp;
	}
	

	@Override
	public String toString() {
		return "CorpsCultivateCostTemplateVO[cultivateLevel=" + cultivateLevel + ",playerLevel=" + playerLevel + ",corpsLevel=" + corpsLevel + ",zqLevel=" + zqLevel + ",cultivateLimit=" + cultivateLimit + ",costContri=" + costContri + ",costExp=" + costExp + ",]";

	}
}