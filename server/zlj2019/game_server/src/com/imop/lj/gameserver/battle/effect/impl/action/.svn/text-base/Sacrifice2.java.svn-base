package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.model.RealDamage;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 
 *根据打出的伤害按比例掉血
 */
public class Sacrifice2 extends AddBuffWithCost {

	public Sacrifice2(int effectId) {
		super(effectId);
	}
	
	@Override
	public boolean preCost(FightUnit owner, FightUnit target, List<ReportItem> content, RealDamage realDamageHp) {
		//掉血 = 根据打出的伤害 * 效果系数 
		ReportItem item = ReportItem.valueOf(owner, this);
		int damage = (int)(getDamageValue(owner, target) * EffectHelper.int2Double(getEffectTpl().getValueCoef()));;  
		int value = -damage;

		if(value == 0){
			//消耗值是否满足
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug("owner " + owner.getIdentifier() + "Sacrifice value is invalid!curHp = "+ value);
			}
			return false;
		}else{
			//伤害吸收盾的值为正的
			this.setCost(Math.abs(value));
			
			//直接更新
			owner.updateAttr(BattleDef.HP, value);
			
			//该buff影响两个技能效果类型的时候,应该区分下,否则会和addTo方法里面有重复
			item.updateAttr(EffectHelper.getReportAttrKey(owner, EffectValueType.HP), Integer.valueOf(value));
			content.add(item);
			
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug("owner " + owner.getIdentifier() + "use effectId =" + this.effectId + ";the sacrifice hp value ="+ value);
			}
		}
		
		if (content.isEmpty()) {
			return false;
		}
		
		return true;
	}

}
