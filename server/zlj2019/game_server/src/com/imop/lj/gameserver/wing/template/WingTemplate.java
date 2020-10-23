package com.imop.lj.gameserver.wing.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.pet.template.PassiveTalentPropItem;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;

@ExcelRowBinding
public class WingTemplate extends WingTemplateVO{
	/**
	 * 过滤，只保留大于0的属性
	 */
	private List<PassiveTalentPropItem> validPropList = new ArrayList<PassiveTalentPropItem>();
	
	
	@Override
	public void check() throws TemplateConfigException {
		//验证属性是否合法
		for (PassiveTalentPropItem item : propList) {
			if (item.getPropKey() > 0) {
				boolean flag = PetPropTemplate.isValidPropKey(item.getPropKey(), PropertyType.PET_PROP_B);
				if (!flag) {
					throw new TemplateConfigException(this.sheetName, this.id, "二级属性key不存在！");
				}
				if (item.getPropValue() <= 0 || item.getPropLevelAdd() <= 0) {
					throw new TemplateConfigException(this.sheetName, this.id, "属性值非法！");
				}
				
				validPropList.add(item);
			}
		}
	}
	
	/**
	 * 获取经过校验的属性加值列表
	 * @return
	 */
	public List<PassiveTalentPropItem> getValidPropList() {
		return validPropList;
	}
	
}
