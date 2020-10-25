package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.template.ItemTemplate;

@ExcelRowBinding
public class UpgradeEquipStarTemplate extends UpgradeEquipStarTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		//遗漏验证
		if (this.id > templateService.getAll(UpgradeEquipStarTemplate.class).size()) {
			throw new TemplateConfigException(this.sheetName, this.id, "有遗漏了的装备位升星等级！ starNum="+this.id);
		}
		//物品验证
		ItemTemplate itemTpl = templateService.get(this.getBaseItemId(), ItemTemplate.class);
		if (itemTpl == null ) {
			throw new TemplateConfigException(this.sheetName, this.id, "基础升级物品不存在！ starNum="+this.id);
		}
		itemTpl = templateService.get(this.getExtraItemId(), ItemTemplate.class);
		if (itemTpl == null ) {
			throw new TemplateConfigException(this.sheetName, this.id, "额外升级物品不存在！ starNum="+this.id);
		}
		//概率验证
		if(this.getBaseProb()>Globals.getGameConstants().getScale()){
			throw new TemplateConfigException(this.sheetName, this.id, "基础升级概率超过上线！ starNum="+this.id);
		}
		if(this.getExtraItemProb()>Globals.getGameConstants().getScale()){
			throw new TemplateConfigException(this.sheetName, this.id, "额外物品升级概率超过上线！ starNum="+this.id);
		}
		//开启等级越界
		if(this.level<0 || this.level>Globals.getGameConstants().getLevelMax()){
			throw new TemplateConfigException(this.sheetName, this.id, "开启升星越界！ starNum="+this.id);
		//this.levelSegment
		}
	}
}
