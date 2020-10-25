package com.imop.lj.gameserver.charge.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * ipad版本充值配置模板的模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class IpadChargeTplTemplateVO extends TemplateObject {

	/** 充值档次后缀 */
	@ExcelCellBinding(offset = 1)
	protected String productIdPostfix;

	/** 产品id */
	@ExcelCellBinding(offset = 2)
	protected String appid;

	/** 礼包名称多语言id */
	@ExcelCellBinding(offset = 3)
	protected long nameLangId;

	/** 礼包名称 */
	@ExcelCellBinding(offset = 4)
	protected String name;

	/** 礼包描述多语言id */
	@ExcelCellBinding(offset = 5)
	protected long descLangId;

	/** 礼包描述 */
	@ExcelCellBinding(offset = 6)
	protected String desc;

	/** 钻石图标 */
	@ExcelCellBinding(offset = 7)
	protected String icon;

	/** 花费钻石RMB */
	@ExcelCellBinding(offset = 8)
	protected int costRMB;

	/** 兑换平台币数量 */
	@ExcelCellBinding(offset = 9)
	protected int coins;

	/** 地区编号 */
	@ExcelCellBinding(offset = 10)
	protected int areaId;

	/** app类型 */
	@ExcelCellBinding(offset = 11)
	protected String appType;

	/** 对应充值货币值（美元） */
	@ExcelCellBinding(offset = 12)
	protected float amount;


	public String getProductIdPostfix() {
		return this.productIdPostfix;
	}

	public void setProductIdPostfix(String productIdPostfix) {
		if (StringUtils.isEmpty(productIdPostfix)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[充值档次后缀]productIdPostfix不可以为空");
		}
		if (productIdPostfix != null) {
			this.productIdPostfix = productIdPostfix.trim();
		}else{
			this.productIdPostfix = productIdPostfix;
		}
	}
	
	public String getAppid() {
		return this.appid;
	}

	public void setAppid(String appid) {
		if (appid != null) {
			this.appid = appid.trim();
		}else{
			this.appid = appid;
		}
	}
	
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
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[礼包名称]name不可以为空");
		}
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
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[礼包描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public String getIcon() {
		return this.icon;
	}

	public void setIcon(String icon) {
		if (StringUtils.isEmpty(icon)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[钻石图标]icon不可以为空");
		}
		if (icon != null) {
			this.icon = icon.trim();
		}else{
			this.icon = icon;
		}
	}
	
	public int getCostRMB() {
		return this.costRMB;
	}

	public void setCostRMB(int costRMB) {
		if (costRMB == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[花费钻石RMB]costRMB不可以为0");
		}
		this.costRMB = costRMB;
	}
	
	public int getCoins() {
		return this.coins;
	}

	public void setCoins(int coins) {
		if (coins == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[兑换平台币数量]coins不可以为0");
		}
		this.coins = coins;
	}
	
	public int getAreaId() {
		return this.areaId;
	}

	public void setAreaId(int areaId) {
		if (areaId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[地区编号]areaId不可以为0");
		}
		this.areaId = areaId;
	}
	
	public String getAppType() {
		return this.appType;
	}

	public void setAppType(String appType) {
		if (StringUtils.isEmpty(appType)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[app类型]appType不可以为空");
		}
		if (appType != null) {
			this.appType = appType.trim();
		}else{
			this.appType = appType;
		}
	}
	
	public float getAmount() {
		return this.amount;
	}

	public void setAmount(float amount) {
		if (amount == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[对应充值货币值（美元）]amount不可以为0");
		}
		this.amount = amount;
	}
	

	@Override
	public String toString() {
		return "IpadChargeTplTemplateVO[productIdPostfix=" + productIdPostfix + ",appid=" + appid + ",nameLangId=" + nameLangId + ",name=" + name + ",descLangId=" + descLangId + ",desc=" + desc + ",icon=" + icon + ",costRMB=" + costRMB + ",coins=" + coins + ",areaId=" + areaId + ",appType=" + appType + ",amount=" + amount + ",]";

	}
}