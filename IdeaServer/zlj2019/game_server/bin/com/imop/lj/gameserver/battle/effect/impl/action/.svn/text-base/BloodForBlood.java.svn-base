package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.List;
import java.util.Random;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.model.RealDamage;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.common.Globals;

/**
 * 以血换血,无视防御(不可以出发暴击,无视伤害吸收盾)
 * 
 */
public class BloodForBlood extends AttackCoef {

	public BloodForBlood(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int preCost(FightUnit owner, FightUnit target, ReportItem item, Random random, List<ReportItem> content) {
		//消耗当前自身气血的X%
		ReportItem ownerItem = ReportItem.valueOf(owner, this);
		Double curHp = owner.getAttr(BattleDef.HP);
		//玩家当前血量是否满足最低要求
		if (curHp <= Globals.getGameConstants().getBattleCostOwnerMin()) {
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug("owner " + owner.getIdentifier() + "BloodForBlood#curHp is invalid!curHp = "+ curHp);
			}
			return 0;
		}
		int value = - (int) (curHp * EffectHelper.int2Double(getEffectTpl().getValueCoef()));  

		if(value == 0){
			//消耗值是否满足
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug("owner " + owner.getIdentifier() + "BloodForBlood value is invalid!curHp = "+ value);
			}
			return 0;
		}else{
			//直接更新
			owner.updateAttr(BattleDef.HP, value);
			
			ownerItem.updateAttr(EffectHelper.getReportAttrKey(owner, EffectValueType.HP), Integer.valueOf(value));
			content.add(ownerItem);
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug("owner " + owner.getIdentifier() + "use effectId =" + this.effectId + ";the BloodForBlood hp value ="+ value);
			}
		}
		if (content.isEmpty()) {
			return 0;
		}
		return value;
	}
	
	@Override
	protected List<ReportItem> execute(Context context, Action action, IEffect effect, FightUnit owner,
			FightUnit target, int damageHp, ReportItem r, RealDamage realDamage) {
		//不走伤害吸收盾
		return null;
	}
	
	@Override
	protected void afterDamageNotDead(Action action, FightUnit target, FightUnit owner, int realDamage, List<ReportItem> content, int preCostValue) {
		//对敌方造成（自身气血X%）的伤害【无视防御】
		ReportItem item = ReportItem.valueOf(target, this);
		//直接更新
		target.updateAttr(BattleDef.HP, preCostValue);
		
		item.updateAttr(EffectHelper.getReportAttrKey(target, EffectValueType.HP), Integer.valueOf(preCostValue));
		content.add(item);
		
		if(Loggers.battleLogger.isDebugEnabled()){
			logger.debug("target " + target.getIdentifier() + "use effectId =" + this.effectId + ";the BloodForBlood hp value ="+ preCostValue);
		}
		if (content.isEmpty()) {
			return;
		}
	}
	
	
}