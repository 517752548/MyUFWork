package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffCatalog;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.LabelCatalog;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.BaseBuffEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.BeTreatBuffEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.MagicDefenceBuffEffect;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.model.BuffAddDamage;
import com.imop.lj.gameserver.battle.model.RealDamage;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.skill.template.SkillLabelTemplate;

/**
 * 带攻击系数的伤害
 * 
 */
public class AttackCoef extends AbstractAction {

	private int magicAttackNum;
	
	public AttackCoef(int effectId) {
		super(effectId, 
			EffectType.AttackCoef, new Phase[]{Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	@Override
	protected List<ReportItem> doActionExecute(Phase phase, Action action) {
		FightUnit owner = getOwner();
		
		List<ReportItem> content = new ArrayList<ReportItem>();
		
		//是否有嘲讽buff
		List<IEffect> eList = owner.getBuffEffectByCatalog(BuffCatalog.ONE_TARGET);
		FightUnit fromOwner = null;
		if(!eList.isEmpty()){
			IEffect effect = eList.get(0);
			if(effect instanceof BaseBuffEffect){
				fromOwner = ((BaseBuffEffect)effect).getFromOwner();
			}
		}
		
		Context context = action.getContext();
		Random random = owner.getRandom();
		
		
		if (TargetHelper.targetNotFound(action, this)) {
			// 一般不会出现这种问题
			return null;
		}
		
		boolean isHitFinal = false;
		int targetNum = 0;
		for (FightUnit target : action.getTargets(this)) {
			//计算命中
			double hitRate = BattleCalculateHelper.calcHitProb(owner, target);
			//命中
			boolean isHit = RandomUtils.isHit(hitRate, random);
			
			ReportItem targetItem = ReportItem.valueOf(target, this);
			
			//施法者
			if(fromOwner != null && targetNum ==0 ){
				
				//如果目标不是施法者,变成施法者
				if(fromOwner != target){
					target = fromOwner;
				}
				
				//只改变第一个选择的目标,其他的目标不变
				targetNum ++;
				
				//同时加上侠义之心,小于最大值
				SkillLabelTemplate labelTpl = Globals.getTemplateCacheService().get(LabelCatalog.CHIVALRIC.getIndex(), SkillLabelTemplate.class);
				if(labelTpl == null){
					continue;
				}
				if(target.getChivalricTimes() < labelTpl.getMaxLabelNum()){
					target.addChivalricTimes();
				}
				
				targetItem = ReportItem.valueOf(target, this);
				targetItem.updateAction(BattleReportDefine.REPORT_ITEM_CHIVALRIC_ID, LabelCatalog.CHIVALRIC.getIndex());
				targetItem.updateAction(BattleReportDefine.REPORT_ITEM_CHIVALRIC, Boolean.valueOf(true));
				
				//必定命中(有嘲讽buff的人,释放buff,目前仍走buff自身概率)
				isHit = true;
			}
			
			//用于第二次技能效果的判断,比如连击
			int deltaHpTmp = 0;
			if (context.get(target, BattleDef.HP) != null) {
				deltaHpTmp = (Integer)context.get(target, BattleDef.HP);
			}
			if (target.getHp() + deltaHpTmp <= 0) {
				continue;
			}
			
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug("行动方:" + action.getOwner() + "FightUnit id: " + action.getOwner().getIdentifier() + " tplId :" + action.getOwner().getTplId());
				logger.debug("被动方:" + target + "FightUnit id: " + target.getIdentifier() + " tplId :" + target.getTplId());
			}
			
			int value = 0;
			if (isHit) {
				//在计算伤害前的一些处理
				List<ReportItem> brList = beforeCalcDamage(target);
				if (brList != null && !brList.isEmpty()) {
					content.addAll(brList);
				}
				
				value = preCost(owner, target, targetItem, random, content);
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
				targetItem.updateAction(BattleReportDefine.REPORT_ITEM_DODGY, Boolean.valueOf(true));
				
				if (Loggers.battleLogger.isDebugEnabled()) {
					logger.debug(action.getOwner().getIdentifier() + " miss!");
				}
			}
			
			if (Loggers.battleLogger.isDebugEnabled()) {
				logger.debug("将会产生 " + value + " 伤害");
			}
			
			RealDamage realDamageHp = new RealDamage();
			
			List<ReportItem> atkReportList = execute(context, action, this, owner, target, value, targetItem, realDamageHp); 

			content.add(targetItem);
			
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

	private void onMagckDefenceBuff(FightUnit target, int value, BuffAddDamage buffValue) {
		//如果是法术攻击
		if(isMagicAttack()){
			//有降低法术防御buff
			List<IEffect> eListMagic = target.getBuffEffectByCatalog(BuffCatalog.MAGIC_DEFENCE);
			if(!eListMagic.isEmpty()){
				IEffect effect = eListMagic.get(0);
				if(effect instanceof MagicDefenceBuffEffect){
					MagicDefenceBuffEffect magicDefenceBuffEffect = (MagicDefenceBuffEffect)effect;
					
					//伤害值 增加  = 伤害值 * 附加参数4
					buffValue.setAddDamage((int) (value * EffectHelper.int2Double(magicDefenceBuffEffect.getEffectTpl().getExtraCoef4())));
					
					//被法术攻击次数增加
					magicAttackNum ++;
					
					//如果到达N次后,删除
					if(magicAttackNum >= magicDefenceBuffEffect.getEffectTpl().getExtraCoef2()){
						magicDefenceBuffEffect.remove();
						
						//同时删除被治疗buff
						List<IEffect> eList1 = target.getBuffEffectByCatalog(BuffCatalog.BE_TREAT);
						if(!eList1.isEmpty()){
							IEffect effect1 = eList1.get(0);
							if(effect1 instanceof BeTreatBuffEffect){
								BeTreatBuffEffect baseBuffEffect1 = (BeTreatBuffEffect)effect1;
								baseBuffEffect1.remove();
							}
						}
					}
				}
			}
		}
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
		
		BuffAddDamage addDamage = new BuffAddDamage();
		//目标身上有法术防御buff的处理
		onMagckDefenceBuff(target, value, addDamage);
		if(addDamage.getAddDamage() > 0){
			//取反
			value = -addDamage.getAddDamage();
		}else{
			value = -value;
		}

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
	
	protected List<ReportItem> execute(Context context, Action action, IEffect effect, FightUnit owner, FightUnit target, int damageHp, ReportItem r, RealDamage realDamage){
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