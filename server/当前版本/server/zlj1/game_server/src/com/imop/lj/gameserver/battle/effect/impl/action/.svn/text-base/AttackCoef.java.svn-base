package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.model.RealDamage;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;

/**
 * 带攻击系数的伤害
 * 
 */
public class AttackCoef extends AbstractAction {

	public AttackCoef(int effectId) {
		super(effectId, 
			EffectType.AttackCoef, new Phase[]{Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	@Override
	protected List<ReportItem> doActionExecute(Phase phase, Action action) {
		FightUnit owner = getOwner();
		
		Context context = action.getContext();
		Random random = owner.getRandom();
		
		List<ReportItem> content = new ArrayList<ReportItem>();
		
		if (TargetHelper.targetNotFound(action, this)) {
			// 一般不会出现这种问题
			return null;
		}
		
		boolean isHitFinal = false;
		for (FightUnit target : action.getTargets(this)) {
			//用于第二次技能效果的判断,比如连击
			int deltaHpTmp = 0;
			if (context.get(target, BattleDef.HP) != null) {
				deltaHpTmp = (Integer)context.get(target, BattleDef.HP);
			}
			if (target.getHp() + deltaHpTmp <= 0) {
				continue;
			}
			
			ReportItem item = ReportItem.valueOf(target, this);
			
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug("行动方:" + action.getOwner() + "FightUnit id: " + action.getOwner().getIdentifier() + " tplId :" + action.getOwner().getTplId());
				logger.debug("被动方:" + target + "FightUnit id: " + target.getIdentifier() + " tplId :" + target.getTplId());
			}
			
			int value = 0;
			//计算命中
			double hitRate = BattleCalculateHelper.calcHitProb(owner, target);
			//命中
			boolean isHit = RandomUtils.isHit(hitRate, random);
			if (isHit) {
				//在计算伤害前的一些处理
				List<ReportItem> brList = beforeCalcDamage(target);
				if (brList != null && !brList.isEmpty()) {
					content.addAll(brList);
				}
				
				value = preCost(owner, target, item, random, content);
				if(value == 0){
					//消耗为0
					if (Loggers.battleLogger.isDebugEnabled()) {
						logger.debug(action.getOwner().getIdentifier() + "preCost ret value is invalid!value=" + value);
					}
					continue;
				}
				//只要又一次命中,就可以触发连击
				isHitFinal = isHit;
			} else {
				//未命中
				item.updateAction(BattleReportDefine.REPORT_ITEM_DODGY, Boolean.valueOf(true));
				
				if (Loggers.battleLogger.isDebugEnabled()) {
					logger.debug(action.getOwner().getIdentifier() + " miss!");
				}
			}
			
			if (Loggers.battleLogger.isDebugEnabled()) {
				logger.debug("将会产生 " + value + " 伤害");
			}
			
			RealDamage realDamageHp = new RealDamage();
			
			List<ReportItem> atkReportList = afterCost(context, action, this, owner, target, value, item, realDamageHp); 

			content.add(item);
			
			if (atkReportList != null && !atkReportList.isEmpty()) {
				content.addAll(atkReportList);
			}
			
			//如果命中，且目标未死亡
			if (isHit && target.getHp() + value > 0) {
				afterDamageNotDead(action, target, owner, realDamageHp.getRealDamage(), content, value);
			}
			
		}

		Boolean isCanDoulbeAttack = (Boolean) context.get(BattleDef.DOUBLE_ATTACK);
		//1.连击不可以触发连击
		//2.闪避之后不可以触发连击
		if (isCanDoulbeAttack == null && isHitFinal) {
			action.addEffectExtra(this, null, DoubleAttackWithValue.class);
			context.put(BattleDef.TRIGGER_DOUBLE_ATTACK, Boolean.valueOf(true));
		}
		
		
		if (content.isEmpty()) {
			return null;
		}

		return content;
	}
	
	/**
	 * 在计算伤害前的一些处理
	 * @param target
	 */
	protected List<ReportItem> beforeCalcDamage(FightUnit target) {
		//默认没有操作
		return null;
	}
	
	/**
	 * 默认操作
	 * @param owner
	 * @param target
	 * @param targetItem
	 * @param random
	 * @param content
	 * @return
	 */
	protected int preCost(FightUnit owner, FightUnit target, ReportItem targetItem, Random random, List<ReportItem> content){
		//计算伤害
		int value = getDamageValue(owner, target);
		//取反
		value = -value;

		// 暴击率
		double fatalRate = BattleCalculateHelper.calcCritProb(owner, target);
		// 是否暴击
		if (RandomUtils.isHit(fatalRate, random)) {
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug(owner.getIdentifier() + " 对 " + target.getIdentifier() + "产生暴击");
			}
			
			// 计算暴击
			value = BattleCalculateHelper.calcCritHurt(value);

			targetItem.updateAction(BattleReportDefine.REPORT_ITEM_FATAL, Boolean.valueOf(true));
		}
		return value;
	}
	
	protected List<ReportItem> afterCost(Context context, Action action, IEffect effect, FightUnit owner, FightUnit target, int damageHp, ReportItem r, RealDamage realDamage){
		return BattleCalculateHelper.onAttackEnemy(context, action, effect, owner, target, damageHp, r, realDamage);
	}
	
	/**
	 * 如果命中，且目标未死亡的处理
	 * @param action
	 * @param target
	 * @param owner
	 * @param realDamage Mp或者HP等
	 * @param content
	 * @param preCostValue
	 */
	protected void afterDamageNotDead(Action action, FightUnit target, FightUnit owner, int realDamage, List<ReportItem> content, int preCostValue) {
		
	}
	
	/**
	 * 行动开始阶段
	 */
	@Override
	protected List<ReportItem> doActionStart(Phase phase, Action action) {
		return null;
	}

	/**
	 * 行动结束阶段
	 */
	@Override
	protected List<ReportItem> doActionEnd(Phase phase, Action action) {
		return null;
	}
}