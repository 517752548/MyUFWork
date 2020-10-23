package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 装备洗炼
 */

@ExcelRowBinding
public class EquipRefineryTemplate extends EquipRefineryTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		//装备验证
		if(templateService.get(equipmentID, CraftEquipTemplate.class)==null){
			throw new TemplateConfigException(this.sheetName, this.id, "装备不存在！ equipmentID="+equipmentID);
		}
		//阶数
		if (Grade.valueOf(grade) == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "阶数不存在！gradeId=" + grade + ",equipID="+ equipmentID);
		}
		//阶数概率
		if(gradeProb<0 || this.gradeProb>Globals.getGameConstants().getRandomBase()){
			throw new TemplateConfigException(this.sheetName, this.id, "阶数概率越界！gradeId=" + grade + ",equipID="+ equipmentID);
		}
		//洗练消耗道具ID
		if (templateService.get(itemId, ItemTemplate.class)==null) {
			throw new TemplateConfigException(this.sheetName, this.id, "材料不存在！itemId=" + itemId + ",equipID="+ equipmentID);
		}	
	}
	
	/**
	 * 获取装备属性
	 * @return
	 */
	public int getAllAttrDesc(){
		AttrDesc ad = new AttrDesc();
		return ad.getKey();
	}
	
}
