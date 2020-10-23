package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;
@ExcelRowBinding

public class PetPerceptTypeTemplate extends PetPerceptTypeTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//装备验证
		ItemTemplate itemTpl = templateService.get(this.getItemId(), ItemTemplate.class);
		if (itemTpl == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "物品不存在！ equipmentID="+this.getItemId());
		}
		
		if (vipFuncId > 0) {
			//检查vip功能id是否存在
			if (VipFuncTypeEnum.valueOf(vipFuncId) == null) {
				throw new TemplateConfigException(this.sheetName, this.id, "对应vip功能Id不存在！ "+ vipFuncId);
			}
		}
	}

	public VipFuncTypeEnum getVipFuncTypeEnum() {
		return VipFuncTypeEnum.valueOf(vipFuncId);
	}
	
}
