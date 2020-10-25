package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.BattleDef.LabelCatalog;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 侠客一朝归元效果,清除侠义之心次数
 * 
 */
public class Fumo4Main extends AttackCoef {

	public Fumo4Main(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//伤害=(（初始数值*面板攻击力+增量*等级层数对应值）*（1+附加参数1*侠义之心层数）) * (1 + 骑宠加成)
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());

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
		
		double valueAdd = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		//镶嵌的仙符效果取效果等级
		int skillLevel = isEmbedEffect() ? getEffectLevel() : getSkillLevel();
		double part2 =  EffectHelper.int2Double((int)getEffectTpl().getExtraCoef1());
		int part3 =  attacker.getChivalricTimes();
		
		//骑宠加成
		boolean isPetHorseAdd = attacker.getPetHorseAddMap().containsValue(this.skillId);
		double part4 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								attacker.getPetHorseSkillLevel(), attacker.getPetHorseAddTpl(attacker, this.skillId))
						) * attacker.getPetHorseSkillLevel()
				: 0;
						
		int finalAtk = (int)(( (baseCoef * baseAttack + valueAdd * skillLevel) * (1 + part2 * part3) ) * (1 + part4));
		
		return finalAtk;
	}
	
	
	@Override
	protected List<ReportItem> doActionExecute(Phase phase, Action action) {
		
		
		List<ReportItem> content = super.doActionExecute(phase, action);
		
		if(getOwner().getChivalricTimes() > 0){
			//清除侠义之心
			ReportItem item = ReportItem.valueOf(getOwner(), this);
			item.updateAction(BattleReportDefine.REPORT_ITEM_CHIVALRIC_ID, LabelCatalog.CHIVALRIC.getIndex());
			item.updateAction(BattleReportDefine.REPORT_ITEM_CHIVALRIC, Boolean.valueOf(false));
			content.add(item);
			
			//清除侠义之心,之前只是写好了战报
			getOwner().clearChivalricTimes();
		}
		
		return content;
	}
	
	
}