package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 打造-颜色阶数系数
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipGradeColorTemplateVO extends TemplateObject {

	/** 系数列表 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "1;2;3;4;5")
	protected List<Integer> coefList;


	public List<Integer> getCoefList() {
		return this.coefList;
	}

	public void setCoefList(List<Integer> coefList) {
		if (coefList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[系数列表]coefList不可以为空");
		}	
		this.coefList = coefList;
	}
	

	@Override
	public String toString() {
		return "CraftEquipGradeColorTemplateVO[coefList=" + coefList + ",]";

	}
}