package com.imop.lj.gameserver.equip;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.template.EquipGradeTemplate;
import com.imop.lj.gameserver.equip.template.EquipPropRandTemplate;
import com.imop.lj.gameserver.item.feature.AbstractEquipFeature;
import com.imop.lj.gameserver.item.template.EquipItemTemplate;

/**
 * XXX 这个类中的方法，不能调用EquipService中的任何方法，也不能调用Globals中其他service方法，必须是最基础的方法
 * 因为装备现在存到了离线数据中，在服务器启动时，离线数据service中会通过props解析出装备的属性，而这时候服务器的Globals正在初始化过程中
 * 
 * @author yu.zhao
 *
 */
public class EquipHelper {

	/**
	 * 固定属性装备，直接根据配置表确定附加属性
	 * @param feature
	 */
	public static void genFixedAttrEquip(AbstractEquipFeature feature) {
		EquipItemTemplate tpl = feature.getEquipItemTemplate();
		if (!tpl.isFixedEquip()) {
			return;
		}
		//基础属性
		feature.getAttrManager().setBaseAttr(tpl.getBaseProp());
		//附加属性
		feature.getAttrManager().replaceAddAttr(tpl.getValidAddPropList());
	}
	
	/**
	 * 计算基础属性
	 * 基础属性直接根据配置表可以算出来
	 */
	public static void calcBaseAttr(AbstractEquipFeature feature) {
		if (feature.getEquipItemTemplate() == null) {
			Loggers.itemLogger.error("EquipAttrManager.calcBaseAttr feature item or itemTpl is null!");
			return;
		}
		
		EquipItemTemplate tpl = feature.getEquipItemTemplate();
		int gradeId = feature.getGrade().getIndex();
		EquipGradeTemplate gradeTpl = Globals.getTemplateCacheService().get(gradeId, EquipGradeTemplate.class);
		EquipPropRandTemplate eprTpl = Globals.getTemplateCacheService().get(tpl.getBaseProp().getPropKey(), EquipPropRandTemplate.class);
		if (gradeTpl == null || eprTpl == null) {
			Loggers.itemLogger.error("EquipAttrManager.calcBaseAttr gradeTpl or eprTpl is null!");
			return;
		}
		
		//基础属性值=基础属性价值 * 单价值数值 * 阶数系数
		double dValue = tpl.getBasePropValueFinal() * eprTpl.getPropValueFinal() * gradeTpl.getGradeCoef();
		//去余取整
		feature.getAttrManager().getBaseAttr().setPropKey(tpl.getBaseProp().getPropKey());
		feature.getAttrManager().getBaseAttr().setPropValue((int)dValue);
	}
	
}
