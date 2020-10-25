package com.imop.lj.gameserver.equip;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.template.CraftEquipPropTemplate;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.item.feature.AbstractEquipFeature;
import com.imop.lj.gameserver.item.template.EquipItemAttribute;
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
	
	public static EquipItemAttribute genBaseAttr(EquipItemTemplate equipTpl, Grade grade) {
		//基础属性算系数的时候按白色来
		Rarity color = Rarity.WHITE;
		//基础属性
		int basePropKey = equipTpl.getBasePropList().get(0).getPropKey();
		CraftEquipPropTemplate basePropTpl = Globals.getTemplateCacheService().get(basePropKey, CraftEquipPropTemplate.class);
		
		//属性的阶数颜色系数
		int gradeColorCoef = Globals.getTemplateCacheService().getCraftTemplateCache().getGradeColorCoef(grade, color);
		
		//属性值=基础属性价值*单价值数值*颜色阶数系数
		double basePropValue = 1.0d * equipTpl.getBasePropValue() * basePropTpl.getPropValue() * gradeColorCoef
				/ (Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale());
		
		int bv = (int)basePropValue;
		//最小为1
		if (bv <= 0) {
			bv = 1;
		}
		return new EquipItemAttribute(basePropKey, bv);
	}
	
}
