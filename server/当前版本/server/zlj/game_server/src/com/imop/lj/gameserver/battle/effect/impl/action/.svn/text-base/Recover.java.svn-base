package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffCatalog;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.BeTreatBuffEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.MagicDefenceBuffEffect;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 回复
 */
public class Recover extends AbstractAction {

	private int recoverNum;
	
	public Recover(int effectId) {
		super(effectId, 
			EffectType.Recover, new Phase[]{Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	@Override
	protected List<ReportItem> doActionExecute(Phase phase, Action action) {
		FightUnit owner = getOwner();
		Context context = action.getContext();
		List<ReportItem> content = new ArrayList<ReportItem>();
		
		if (TargetHelper.targetNotFound(action, this)) {
			// 一般不会出现这种问题
			return null;
		}
		
		for (FightUnit target : action.getTargets(this)) {
			ReportItem item = ReportItem.valueOf(target, this);
			
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug("行动方:" + action.getOwner() + "FightUnit id: " + action.getOwner().getIdentifier() + " tplId :" + action.getOwner().getTplId());
				logger.debug("被动方:" + target + "FightUnit id: " + target.getIdentifier() + " tplId :" + target.getTplId());
			}
			int value = getRecoverValue(owner, target);
			//如果目标有被治疗buff,则增加回复值
			List<IEffect> eList = target.getBuffEffectByCatalog(BuffCatalog.BE_TREAT);
			if(!eList.isEmpty()){
				IEffect effect = eList.get(0);
				if(effect instanceof BeTreatBuffEffect){
					BeTreatBuffEffect beTreatBuffEffect = (BeTreatBuffEffect)effect;
					
					//回复值 = 回复值 * 附加参数4
					value = (int) (value * EffectHelper.int2Double(beTreatBuffEffect.getEffectTpl().getExtraCoef4()));
					
					//被治疗buff次数增加
					recoverNum ++;
					//如果到达N次后,删除
					if(recoverNum >= beTreatBuffEffect.getEffectTpl().getExtraCoef2()){
						beTreatBuffEffect.remove();
						
						//同时删除降低法术防御buff
						List<IEffect> eListMagic = target.getBuffEffectByCatalog(BuffCatalog.MAGIC_DEFENCE);
						if(!eListMagic.isEmpty()){
							IEffect effect1 = eListMagic.get(0);
							if(effect1 instanceof MagicDefenceBuffEffect){
								MagicDefenceBuffEffect baseBuffEffect1 = (MagicDefenceBuffEffect)effect1;
								baseBuffEffect1.remove();
							}
						}
					}
				}
			}
			EffectValueType evType = getEffectTpl().getEffectValueType();
			context.put(target, EffectHelper.getAttrKey(target, evType), Integer.valueOf(value));
			item.updateAttr(EffectHelper.getReportAttrKey(target, evType), Integer.valueOf(value));
			content.add(item);
		}

		if (content.isEmpty()) {
			return null;
		}

		return content;
	}
	
	protected int getRecoverValue(FightUnit attacker, FightUnit target) {
		//恢复值=(（初始恢复系数）*攻击力+等级提升技能恢复加值*技能等级) * (1 +骑宠加成)
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		double skillLevelCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		
		double baseAttack = 0d;
		boolean isDefault = this.getEffectTpl().isDefaultAttack();
		boolean isStrength = this.getEffectTpl().isPhsicalAttack();
		boolean isMagic = this.getEffectTpl().isMagicAttack();
		if(isDefault){
			//默认-取面板攻击
			baseAttack = BattleCalculateHelper.getBaseAttack(attacker);
		}else if(isStrength){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.STRENGTH );
		}else if(isMagic){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.INTELLECT );
		}
		
		double part1 = (baseCoef) * baseAttack;
		//镶嵌的仙符效果取效果等级
		double part2 = skillLevelCoef * (isEmbedEffect() ? getEffectLevel() : getSkillLevel());
		
		//骑宠加成
		boolean isPetHorseAdd = attacker.getPetHorseAddMap().containsValue(this.skillId);
		double part3 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								attacker.getPetHorseSkillLevel(), attacker.getPetHorseAddTpl(attacker, this.skillId))
						) * attacker.getPetHorseSkillLevel()
				: 0;
		
		int finalAtk = (int)( (part1 + part2)  * (1 + part3));
		return finalAtk;
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