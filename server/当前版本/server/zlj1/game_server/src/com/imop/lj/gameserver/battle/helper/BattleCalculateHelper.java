package com.imop.lj.gameserver.battle.helper;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffCatalog;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.FightUnitStatus;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.effect.impl.action.AddBuffFromAllAttack;
import com.imop.lj.gameserver.battle.effect.impl.buff.HurtShieldBuffEffect;
import com.imop.lj.gameserver.battle.model.RealDamage;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 战斗计算
 * 
 */
public class BattleCalculateHelper {
	
	/**
	 * 计算技能伤害
	 * @param attacker 攻击方
	 * @param attackerAttack 攻击方的攻击力
	 * @param defender 防守方
	 * @return
	 */
	public static int calcSkillHurt(FightUnit attacker, double attackerAttack, FightUnit defender) {
		return calcHurt(attacker, attackerAttack, defender);
	}
	
	/**
	 * 根据原始伤害，计算暴击伤害
	 * @param rawHurt
	 * @return
	 */
	public static int calcCritHurt(int rawHurt) {
		return (int)(rawHurt * getCritCoef());
	}
	
	/**
	 * 计算伤害
	 * @param attacker
	 * @param attackerAttack
	 * @param defender
	 * @return
	 */
	private static int calcHurt(FightUnit attacker, double attackerAttack, FightUnit defender) {
		//如果是无敌状态，则不造成伤害
		if (isNBDZTStatus(defender)) {
			return getNBDZTHurt();
		}
		
		double ret = 0;
		double def = getArmorProb(defender, attacker.getAttackType());
		//伤害公式=物理攻击*（1-防御方免伤率）
		ret = attackerAttack * (1 - def);
		
		//百分比计算防御状态的值
		if (isDefenceStatus(defender)) {
			ret = ret * getDefenceHurtScale();
		}
		
		if (ret < 1) {
			ret = 1;
		}
		return (int)ret;
	}
	
	/**
	 * 目标是否处于防御状态
	 * @param fu
	 * @return
	 */
	public static boolean isDefenceStatus(FightUnit fu) {
		return fu.hasStatus(FightUnitStatus.DEFENCE);
	}
	
	/**
	 * 是否处于无敌状态
	 * @param fu
	 * @return
	 */
	public static boolean isNBDZTStatus(FightUnit fu) {
		return fu.hasStatus(FightUnitStatus.NBDZT);
	}
	
	/**
	 * 获取防御状态受到伤害的数值
	 * @return
	 */
	public static int getDefenceHurt() {
		return Globals.getGameConstants().getBattleDefenceHurt();
	}
	
	/**
	 * 获取防御状态受到伤害的数值
	 * @return
	 */
	public static double getDefenceHurtScale() {
		return EffectHelper.int2Double(Globals.getGameConstants().getBattleDefenceHurtScale());
	}
	
	/**
	 * 获取无敌状态的伤害值
	 * @return
	 */
	public static int getNBDZTHurt() {
		return 0;
	}
	
	/**
	 * 获取暴击系数
	 * @return
	 */
	public static double getCritCoef() {
		return Globals.getGameConstants().getBattleCritHurtCoef();
	}
	
	/**
	 * 获取基础攻击力
	 * @param fu
	 * @return
	 */
	public static double getBaseAttack(FightUnit fu) {
		return fu.getAttackType() == PetAttackType.STRENGTH ? 
				fu.getAttr(BattleDef.PHYSICAL_ATTACK) : fu.getAttr(BattleDef.MAGIC_ATTACK);
	}
	
	public static double getBaseAttackByType(FightUnit fu, PetAttackType attackType) {
		return attackType == PetAttackType.STRENGTH ? 
				fu.getAttr(BattleDef.PHYSICAL_ATTACK) : fu.getAttr(BattleDef.MAGIC_ATTACK);
	}
	
	/**
	 * 获取命中率
	 * @param attacker
	 * @param defender
	 * @return
	 */
	public static double calcHitProb(FightUnit attacker, FightUnit defender) {
		//以攻击方的攻击类型为准
		PetAttackType attackType = attacker.getAttackType();
		double attHit = getHitProb(attacker, attackType);
		double defDodgy = getDodgyProb(defender, attackType);
		
		//命中率=(攻方命中率−守方闪避率)+(攻方等级−守方等级)×0.02
		double finalHit = (attHit - defDodgy) + 
				(attacker.getLevel() - defender.getLevel()) * Globals.getGameConstants().getBattleLevelCoef();
		
		if (Loggers.battleLogger.isDebugEnabled()) {
			Loggers.battleLogger.debug(attacker.getIdentifier() + " attack " + defender.getIdentifier() + " attHit=" + attHit + ";defDodgy=" + defDodgy + ";finalHit=" + finalHit);
		}
		
		if (finalHit < 0) {
			finalHit = 0;
		}
		return finalHit;
	}
	
	/**
	 * 获取暴击率
	 * @param attacker
	 * @param defender
	 * @return
	 */
	public static double calcCritProb(FightUnit attacker, FightUnit defender) {
		//以攻击方的攻击类型为准
		PetAttackType attackType = attacker.getAttackType();
		double attCrit = getCritProb(attacker, attackType);
		double defAntiCrit = getAntiCritProb(defender, attackType);
		//暴击率=(攻方暴击率−守方抗暴率)+(攻方等级−守方等级)×0.02
		double finalCrit = attCrit - defAntiCrit + 
				(attacker.getLevel() - defender.getLevel()) * Globals.getGameConstants().getBattleLevelCoef();
		
		if (finalCrit < 0) {
			finalCrit = 0;
		}
		return finalCrit;
	}
	
	/**
	 * 获取命中率
	 * @param fu
	 * @param attackType
	 * @return
	 */
	public static double getHitProb(FightUnit fu, PetAttackType attackType) {
		//攻方命中率=物理命中等级/(物理命中转化系数×战斗实力)
		boolean isPh = attackType == PetAttackType.STRENGTH;
		int level = fu.getLevel();
		double value = fu.getAttr(isPh ? BattleDef.PHYSICAL_HIT : BattleDef.MAGIC_HIT);
		double coef = isPh ? Globals.getGameConstants().getBattlePhyHit() : Globals.getGameConstants().getBattleMagHit();
		double ret = value / (coef * calcZDSL(level));
		
		if (Loggers.battleLogger.isDebugEnabled()) {
			Loggers.battleLogger.debug(fu.getIdentifier() + "hit=" + value + ";coef=" + coef + ";finalHit=" + ret);
		}
		
		return ret;
	}
	
	/**
	 * 获取闪避率
	 * @param fu
	 * @param attackType
	 * @return
	 */
	public static double getDodgyProb(FightUnit fu, PetAttackType attackType) {
		//守方闪避率=(闪避转换常数×物理闪避等级)/(物理闪避转化系数×战斗实力+物理闪避等级)
		boolean isPh = attackType == PetAttackType.STRENGTH;
		int level = fu.getLevel();
		double value = fu.getAttr(isPh ? BattleDef.PHYSICAL_DODGY : BattleDef.MAGIC_DODGY);
		double coef2 = isPh ? Globals.getGameConstants().getBattlePhyDod() : Globals.getGameConstants().getBattleMagDod();
		double ret = (Globals.getGameConstants().getBattleDodgy() * value) / (coef2 * calcZDSL(level) + value);
		
		if (Loggers.battleLogger.isDebugEnabled()) {
			Loggers.battleLogger.debug(fu.getIdentifier() + " dodgy=" + value + ";coef=" + coef2 + ";finalDodgy=" + ret);
		}
		
		return ret;
	}
	
	/**
	 * 获取暴击率
	 * @param fu
	 * @param attackType
	 * @return
	 */
	public static double getCritProb(FightUnit fu, PetAttackType attackType) {
		//攻方暴击率=物理暴击等级/(物理暴击转化系数×战斗实力)
		boolean isPh = attackType == PetAttackType.STRENGTH;
		int level = fu.getLevel();
		double value = fu.getAttr(isPh ? BattleDef.PHYSICAL_CRIT : BattleDef.MAGIC_CRIT);
		double coef = isPh ? Globals.getGameConstants().getBattlePhyCri() : Globals.getGameConstants().getBattleMagCri();
		double ret = value / (coef * calcZDSL(level));
		return ret;
	}
	
	/**
	 * 获取抗暴率
	 * @param fu
	 * @param attackType
	 * @return
	 */
	public static double getAntiCritProb(FightUnit fu, PetAttackType attackType) {
		//守方抗暴率=(抗暴转换常数×物理抗暴等级)/(物理抗暴转化系数×战斗实力+物理抗暴等级)
		boolean isPh = attackType == PetAttackType.STRENGTH;
		int level = fu.getLevel();
		double value = fu.getAttr(isPh ? BattleDef.PHYSICAL_ANTICRIT : BattleDef.MAGIC_ANTICRIT);
		double coef = isPh ? Globals.getGameConstants().getBattlePhyAntCri() : Globals.getGameConstants().getBattleMagAntCri();
		double ret = (Globals.getGameConstants().getBattleAntiCrit() * value) / (coef * calcZDSL(level) + value);
		return ret;
	}
	
	/**
	 * 获取免伤率
	 * @param fu
	 * @param attackType
	 * @return
	 */
	public static double getArmorProb(FightUnit fu, PetAttackType attackType) {
		//守方免伤率=(免伤转换常数×物理防御等级)/(物理防御转化系数×战斗实力+物理防御等级)
		boolean isPh = attackType == PetAttackType.STRENGTH;
		int level = fu.getLevel();
		double value = fu.getAttr(isPh ? BattleDef.PHYSICAL_ARMOR : BattleDef.MAGIC_ARMOR);
		double coef = isPh ? Globals.getGameConstants().getBattlePhyDef() : Globals.getGameConstants().getBattleMagDef();
		double ret = (Globals.getGameConstants().getBattleMS() * value) / (coef * calcZDSL(level) + value);
		return ret;
	}
	
	/**
	 * 攻击敌人时，一些统一的处理放在这里
	 * @param context
	 * @param action
	 * @param effect
	 * @param owner
	 * @param target
	 * @param damageHp
	 * @param r
	 * @param realDamageHp
	 * @return
	 */
	public static List<ReportItem> onAttackEnemy(Context context, Action action, IEffect effect, FightUnit owner, FightUnit target, int damageHp, ReportItem r, RealDamage realDamageHp) {
		List<ReportItem> ret = new ArrayList<ReportItem>();
		//减血时的处理
		List<ReportItem> ri = onReduceHp(context, owner, target, damageHp, r, realDamageHp);
		if (ri != null && !ri.isEmpty()) {
			ret.addAll(ri);
		}
		
		//额外附加效果，如宠物天赋技能，在攻击时触发加buff
		if (action != null ) {
			long deltaHp = 0;
			if (context.get(owner, BattleDef.HP) != null) {
				deltaHp =  Long.valueOf((Integer) context.get(owner, BattleDef.HP));
			}
			//【天生毒性】技能，在所有攻击时，可能会触发增加buff
			if (deltaHp + owner.getHp() > 0) {
				action.addEffectExtra(effect, target, AddBuffFromAllAttack.class);
			}
		}
		
		return ret;
	}
	
	/**
	 * 减血的处理，含伤害吸收盾
	 * @param context
	 * @param owner
	 * @param target
	 * @param damageHp
	 * @param r
	 * @param realDamageHp
	 * @return
	 */
	public static List<ReportItem> onReduceHp(Context context, FightUnit owner, FightUnit target, int damageHp, ReportItem r, RealDamage realDamageHp) {
		List<ReportItem> ret = new ArrayList<ReportItem>();
		int realDamage = damageHp;
		List<IEffect> eList = target.getBuffEffectByCatalog(BuffCatalog.HURT_SHIELD);
		//伤害吸收盾的处理
		if (damageHp < 0 && 
				eList != null && !eList.isEmpty()) {
			int damageHpTmp = 0;
			for (IEffect e : eList) {
				if (!(e instanceof HurtShieldBuffEffect)) {
					continue;
				}
				damageHpTmp = Math.abs(realDamage);
				if (damageHpTmp <= 0) {
					break;
				}
				
				HurtShieldBuffEffect hsbe = (HurtShieldBuffEffect)e;
				int left = hsbe.costValue(damageHpTmp);
				if (left >= 0) {
					realDamage = 0;
				} else {
					realDamage = left;
				}
				
				//盾可吸收伤害降为0，清除buff
				if (left <= 0) {
					ret.addAll(hsbe.remove());
				}
			}
		}
		
		if (Loggers.battleLogger.isDebugEnabled()) {
			Loggers.battleLogger.debug(target.getIdentifier() + " 实际受到 " + realDamage + " 伤害，来源者 " + owner.getIdentifier());
			if (damageHp != realDamage) {
				Loggers.battleLogger.debug(target.getIdentifier() + " 伤害吸收盾吸收 " + (damageHp-realDamage) + " 伤害，来源者 " + owner.getIdentifier());
			}
		}
		
		boolean isDeadFly = false;
		//更新上下文的hp
		if (context != null) {
			//技能伤害
			context.increaseValue(target, BattleDef.HP, realDamage);
			
			//击飞判定
			long tmpHp = target.getHp() + (Integer)context.get(target, BattleDef.HP);
			if (target.calcDeadFly(tmpHp) || target.isDeadFly()) {
				isDeadFly = true;
			}
		} else {
			//buff伤害
			target.updateAttr(BattleDef.HP, realDamage);
			
			//击飞判定
			isDeadFly = target.isDeadFly();
		}
		
		//更新战报的hp
		r.updateAttr(BattleReportDefine.REPORT_ITEM_HP, realDamage);
		//被击飞的战报
		if (isDeadFly) {
			r.updateAction(BattleReportDefine.REPORT_ITEM_DEAD_FLY, Boolean.valueOf(true));
		}
		
		//怒气变化
		if (realDamage < 0 && target.canAddSp()) {
			//更新怒气值
			int addSp = Globals.getGameConstants().getBattleAddSp();
			target.updateAttr(BattleDef.SP, addSp);
			//加入战报
			r.updateAttr(BattleReportDefine.REPORT_ITEM_SP, addSp);
		}
		
		//实际伤害血量,给吸血攻击等效果用
		if(realDamageHp != null){
			realDamageHp.setRealDamage(realDamage);
		}
		
		return ret;
	}
	
	/**
	 * 攻击敌人蓝时，一些统一的处理放在这里
	 * @param context
	 * @param action
	 * @param effect
	 * @param owner
	 * @param target
	 * @param damageHp
	 * @param r
	 * @param realDamageHp
	 * @return
	 */
	public static List<ReportItem> onAttackEnemyMp(Context context, Action action, IEffect effect, FightUnit owner, FightUnit target, int damageHp, ReportItem r, RealDamage realDamageHp) {
		List<ReportItem> ret = new ArrayList<ReportItem>();
		//减蓝时的处理
		List<ReportItem> ri = onReduceMp(context, owner, target, damageHp, r, realDamageHp);
		if (ri != null && !ri.isEmpty()) {
			ret.addAll(ri);
		}
		
		//额外附加效果，如宠物天赋技能，在攻击时触发加buff
		if (action != null ) {
			long deltaHp = 0;
			if (context.get(owner, BattleDef.HP) != null) {
				deltaHp =  Long.valueOf((Integer) context.get(owner, BattleDef.HP));
			}
			//【天生毒性】技能，在所有攻击时，可能会触发增加buff
			if (deltaHp + owner.getHp() > 0) {
				action.addEffectExtra(effect, target, AddBuffFromAllAttack.class);
			}
		}
		
		return ret;
	}
	
	/**
	 * 减蓝的处理
	 * @param context
	 * @param owner
	 * @param target
	 * @param damageMp
	 * @param r
	 * @param realDamageMp
	 * @return
	 */
	public static List<ReportItem> onReduceMp(Context context, FightUnit owner, FightUnit target, int damageMp, ReportItem r, RealDamage realDamageMp) {
		List<ReportItem> ret = new ArrayList<ReportItem>();
		int realDamage = damageMp;
		//更新上下文的hp
		if (context != null) {
			//技能伤害
			context.increaseValue(target, BattleDef.MP, realDamage);
			
		} else {
			//buff伤害
			target.updateAttr(BattleDef.MP, realDamage);
			
		}
		
		//更新战报的hp
		r.updateAttr(BattleReportDefine.REPORT_ITEM_MP, realDamage);
		//怒气变化
		if (realDamage < 0 && target.canAddSp()) {
			//更新怒气值
			int addSp = Globals.getGameConstants().getBattleAddSp();
			target.updateAttr(BattleDef.SP, addSp);
			//加入战报
			r.updateAttr(BattleReportDefine.REPORT_ITEM_SP, addSp);
		}
		
		//实际伤害血量,给吸血攻击等效果用
		if(realDamageMp != null){
			realDamageMp.setRealDamage(realDamage);
		}
		
		return ret;
	}
	
	/**
	 * 计算【战斗实力】
	 * @param level
	 * @return
	 */
	public static float calcZDSL(int level) {
		//战斗实力=5+当前角色等级*2
		double ret = Globals.getGameConstants().getBattleZDSL1() + level * Globals.getGameConstants().getBattleZDSL2();
		return (float)ret;
	}
	
}
