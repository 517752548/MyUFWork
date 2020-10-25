package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.pet.PetDef.PetType;

/**
 * 伙伴配置表
 * 
 */
@ExcelRowBinding
public class PetFriendTemplate extends PetFriendTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		PetTemplate petTpl = templateService.get(this.id, PetTemplate.class);
		if (petTpl == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "petTplId不存在！" + this.id);
		}
		if (PetType.FRIEND != petTpl.getPetType()) {
			throw new TemplateConfigException(this.sheetName, this.id, "petTplId不是伙伴！" + this.id);
		}
		if (isNeedUnlock()) {
			for (Integer cost : unlockCostList) {
				if (cost <= 0) {
					throw new TemplateConfigException(this.sheetName, this.id, "解锁的花费值非法！" + cost);
				}
			}
		}
	}
	
	/**
	 * 伙伴是否需要解锁
	 * @return
	 */
	public boolean isNeedUnlock() {
		return this.needUnlock == 1;
	}
	
}
