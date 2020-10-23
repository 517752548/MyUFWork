package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

/**
 * 装备-属性权重表
 */
@ExcelRowBinding
public class EquipPropRandTemplate extends EquipPropRandTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		
//		if (this.id == this.targetItemId) {
//			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "targetItemId不能是自己！targetItemId=" + this.targetItemId);
//		}
//		
//		if (templateService.get(this.targetItemId, ItemTemplate.class) == null) {
//			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "targetItemId不存在！targetItemId=" + this.targetItemId);
//		}
		
	}
	
	public double getPropValueFinal() {
		return EffectHelper.int2Double(this.getPropValue());
	}

}
