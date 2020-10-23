package com.imop.lj.gameserver.battle.helper;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffCatalog;
import com.imop.lj.gameserver.battle.effect.AbstractEffect;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.effect.impl.action.AddAttrInAction;
import com.imop.lj.gameserver.battle.effect.impl.action.AddBuff;
import com.imop.lj.gameserver.battle.effect.impl.action.AddBuffFromAllAttack;
import com.imop.lj.gameserver.battle.effect.impl.action.AddBuffParam;
import com.imop.lj.gameserver.battle.effect.impl.action.AddBuffWithCost;
import com.imop.lj.gameserver.battle.effect.impl.action.AttackCoef;
import com.imop.lj.gameserver.battle.effect.impl.action.BloodForBlood;
import com.imop.lj.gameserver.battle.effect.impl.action.CatchPet;
import com.imop.lj.gameserver.battle.effect.impl.action.Defence;
import com.imop.lj.gameserver.battle.effect.impl.action.DefenceAttack;
import com.imop.lj.gameserver.battle.effect.impl.action.DefenceAttackParam;
import com.imop.lj.gameserver.battle.effect.impl.action.DefenceWithValue;
import com.imop.lj.gameserver.battle.effect.impl.action.DelBuff;
import com.imop.lj.gameserver.battle.effect.impl.action.DoubleAttackWithValue;
import com.imop.lj.gameserver.battle.effect.impl.action.Escape;
import com.imop.lj.gameserver.battle.effect.impl.action.Fumo1Main;
import com.imop.lj.gameserver.battle.effect.impl.action.Fumo2Main;
import com.imop.lj.gameserver.battle.effect.impl.action.LieyanMain;
import com.imop.lj.gameserver.battle.effect.impl.action.MpBurn;
import com.imop.lj.gameserver.battle.effect.impl.action.NormalAttack;
import com.imop.lj.gameserver.battle.effect.impl.action.PetNormalMain;
import com.imop.lj.gameserver.battle.effect.impl.action.PetTalentMain;
import com.imop.lj.gameserver.battle.effect.impl.action.Recover;
import com.imop.lj.gameserver.battle.effect.impl.action.RemoveRandDebuff;
import com.imop.lj.gameserver.battle.effect.impl.action.Revive;
import com.imop.lj.gameserver.battle.effect.impl.action.Sacrifice;
import com.imop.lj.gameserver.battle.effect.impl.action.SuckAttack;
import com.imop.lj.gameserver.battle.effect.impl.action.SummonPet;
import com.imop.lj.gameserver.battle.effect.impl.action.UseDrugs;
import com.imop.lj.gameserver.battle.effect.impl.buff.BaseBuffEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.HurtShieldBuffEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.HurtShieldBuffEffectWithValue;
import com.imop.lj.gameserver.battle.effect.impl.buff.Param1BuffEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.Param2BuffEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.ParamBuffEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.PetTalent1BuffEffect;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.skill.template.SkillBuffTemplate;
import com.imop.lj.gameserver.skill.template.SkillEffectTemplate;

/**
 * 创建战斗效果工厂对象
 * 
 */
public class EffectFactory {

	public static List<IEffect> createSkillEffect(List<Integer> effectIdList, int skillId, int skillLevel) {
		List<IEffect> resultList = new ArrayList<IEffect>();
		int c = 0;
		for (Integer effectId : effectIdList) {
			SkillEffectTemplate effectTpl = Globals.getTemplateCacheService().get(effectId,	SkillEffectTemplate.class);
			IEffect effect = EffectFactory.createEffect(effectTpl);
			//设置效果所述的技能Id和技能等级
			effect.setSkillId(skillId);
			effect.setSkillLevel(skillLevel);
			//第一个效果为主效果
			if (c == 0) {
				effect.setMain();
			}
			resultList.add(effect);
			c++;
		}
		return resultList;
	}
	
	public static IEffect createEmbedSkillEffect(int effectId, int effectLevel, int skillId, int skillLevel) {
		SkillEffectTemplate effectTpl = Globals.getTemplateCacheService().get(effectId,	SkillEffectTemplate.class);
		IEffect effect = EffectFactory.createEffect(effectTpl);
		//设置效果所述的技能Id和技能等级
		effect.setSkillId(skillId);
		effect.setSkillLevel(skillLevel);
		effect.setEffectLevel(effectLevel);
		return effect;
	}

	/**
	 * 创建战斗效果
	 * 
	 * @param effectConfig
	 * @return
	 */
	public static IEffect createEffect(SkillEffectTemplate effectTpl) {
		int effectId = effectTpl.getId();
		switch (effectTpl.getEffectType()) {
		case NormalAttack:
			return new NormalAttack();
			/** 造成伤害 */
		case AttackCoef:
			return new AttackCoef(effectId);
			/** 加buff */
		case AddBuff:
			return new AddBuff(effectId);
		case AddBuffParam:
			return new AddBuffParam(effectId);
			/** 解buff*/
		case DelBuff:
			return new DelBuff();
			/** 复活 */
		case Revive:
			return new Revive(effectId);
			/** 反击 */
		case DefenceAttack:
			return new DefenceAttack(effectId);
			/** 连击 */
		case DoubleAttackWithValue:
			return new DoubleAttackWithValue(effectId);
		case CatchPet:
			return new CatchPet(effectId);
		case Defence:
			return new Defence(effectId);
		case Fumo1Main:
			return new Fumo1Main(effectId);
		case Fumo2Main:
			return new Fumo2Main(effectId);
		case LieyanMain:
			return new LieyanMain(effectId);
		case Recover:
			return new Recover(effectId);
		case RemoveRandDebuff:
			return new RemoveRandDebuff(effectId);
		case AddBuffFromAllAttack:
			return new AddBuffFromAllAttack(effectId);
		case DefenceAttackParam:
			return new DefenceAttackParam(effectId);
		case PetTalentMain:
			return new PetTalentMain(effectId);
		case Escape:
			return new Escape(effectId);
		case UseDrugs:
			return new UseDrugs(effectId);
		case SummonPet:
			return new SummonPet(effectId);
		case AddAttrInAction:
			return new AddAttrInAction(effectId);
		case Suck:
			return new SuckAttack(effectId);
		case AddBuffWithCost:
			return new AddBuffWithCost(effectId);
		case Sacrifice:
			return new Sacrifice(effectId);
		case BloodForBlood:
			return new BloodForBlood(effectId);
		case MpBurn:
			return new MpBurn(effectId);
		case DefenceWithValue:
			return new DefenceWithValue(effectId);
		case PetNormalMain:
			return new PetNormalMain(effectId);
		default:
			throw new TemplateConfigException(effectTpl.getSheetName(),
					effectId, String.format("创建战斗效果错误"));
		}
	}
	
	public static BaseBuffEffect buildBuffEffect(AbstractEffect ownerEffect) {
		int eId = ownerEffect.getId();
		SkillEffectTemplate effectTpl = Globals.getTemplateCacheService().get(eId, SkillEffectTemplate.class);
		SkillBuffTemplate buffTpl = Globals.getTemplateCacheService().get(effectTpl.getBuffTypeId(), SkillBuffTemplate.class);
		BuffCatalog buffCat = buffTpl.getBuffCatalog();
		BaseBuffEffect abe = null;
		switch (buffCat) {
		case BASE:
			abe = new BaseBuffEffect(eId);
			break;
		case PARAM:
			abe = new ParamBuffEffect(eId);
			break;
		case PARAM_1:
			abe = new Param1BuffEffect(eId);
			break;
		case PARAM_2:
			abe = new Param2BuffEffect(eId);
			break;
		case HURT_SHIELD:
			abe = new HurtShieldBuffEffect(eId);
			break;
		case HURT_SHIELD_WITH_VALUE:
			abe = new HurtShieldBuffEffectWithValue(eId);
			break;
		case PET_TALENT_1:
			abe = new PetTalent1BuffEffect(eId);
			break;
		default:
			break;
		}
		
		if (abe != null) {
			//设置owner
			abe.setOwner(ownerEffect.getOwner());
			//设置来源者Owner
			abe.setFromOwner(ownerEffect.getOwner());
			//初始化
			abe.init();
			//设置技能Id和技能等级
			abe.setSkillId(ownerEffect.getSkillId());
			abe.setSkillLevel(ownerEffect.getSkillLevel());
			//设置效果等级
			abe.setEffectLevel(ownerEffect.getEffectLevel());
		}
		return abe;
	}
	
}
