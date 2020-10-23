package com.imop.lj.gameserver.enemy.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * 挂机价值配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EnemyGuaJiValueTemplateVO extends TemplateObject {

	/** 参数描述 */
	@ExcelCellBinding(offset = 1)
	protected String desc;

	/** 价值列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.enemy.template.GuaJiValueItem.class, collectionNumber = "2,3;4,5;6,7;8,9;10,11")
	protected List<com.imop.lj.gameserver.enemy.template.GuaJiValueItem> valueList;


	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[参数描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public List<com.imop.lj.gameserver.enemy.template.GuaJiValueItem> getValueList() {
		return this.valueList;
	}

	public void setValueList(List<com.imop.lj.gameserver.enemy.template.GuaJiValueItem> valueList) {
		if (valueList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[价值列表]valueList不可以为空");
		}	
		this.valueList = valueList;
	}
	

	@Override
	public String toString() {
		return "EnemyGuaJiValueTemplateVO[desc=" + desc + ",valueList=" + valueList + ",]";

	}
}