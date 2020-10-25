package com.imop.lj.gameserver.corpsassist.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 辅助技能消耗配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsAssistCostTemplateVO extends TemplateObject {

	/** 当前辅助技能等级 */
	@ExcelCellBinding(offset = 1)
	protected int assistLevel;

	/** 需求玩家等级 */
	@ExcelCellBinding(offset = 2)
	protected int playerLevel;

	/** 需求帮派等级 */
	@ExcelCellBinding(offset = 3)
	protected int corpsLevel;

	/** 需求侍剑堂等级 */
	@ExcelCellBinding(offset = 4)
	protected int sjLevel;

	/** 升级消耗银票 */
	@ExcelCellBinding(offset = 5)
	protected int costCurrency;

	/** 修炼1次消耗帮贡 */
	@ExcelCellBinding(offset = 6)
	protected int costContri;


	public int getAssistLevel() {
		return this.assistLevel;
	}

	public void setAssistLevel(int assistLevel) {
		if (assistLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[当前辅助技能等级]assistLevel的值不得小于0");
		}
		this.assistLevel = assistLevel;
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
	
	public int getSjLevel() {
		return this.sjLevel;
	}

	public void setSjLevel(int sjLevel) {
		if (sjLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[需求侍剑堂等级]sjLevel的值不得小于0");
		}
		this.sjLevel = sjLevel;
	}
	
	public int getCostCurrency() {
		return this.costCurrency;
	}

	public void setCostCurrency(int costCurrency) {
		if (costCurrency < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[升级消耗银票]costCurrency的值不得小于1");
		}
		this.costCurrency = costCurrency;
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
	

	@Override
	public String toString() {
		return "CorpsAssistCostTemplateVO[assistLevel=" + assistLevel + ",playerLevel=" + playerLevel + ",corpsLevel=" + corpsLevel + ",sjLevel=" + sjLevel + ",costCurrency=" + costCurrency + ",costContri=" + costContri + ",]";

	}
}