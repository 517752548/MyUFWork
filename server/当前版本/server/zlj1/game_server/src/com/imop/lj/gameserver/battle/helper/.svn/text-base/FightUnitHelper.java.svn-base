package com.imop.lj.gameserver.battle.helper;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.FightUnitSkillInfo;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.cache.template.BattleTemplateCache;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyCoefTemplate;
import com.imop.lj.gameserver.enemy.template.EnemyTemplate;
import com.imop.lj.gameserver.enemy.template.SkillItem;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.pet.prop.PetBProperty;


/**
 * 战斗单位创建
 * 
 */
public class FightUnitHelper {
	
	public static FightUnit toFightUnit(String id, int position, EnemyTemplate tpl, int level) {
		return toFightUnit(id, position, tpl, level, null);
	}
	
	/**
	 * 构建EnemyTemplate或PetTemplate的伙伴对应的战斗对象
	 * @param id
	 * @param position
	 * @param tpl
	 * @param level
	 * @return
	 */
	public static FightUnit toFightUnit(String id, int position, EnemyTemplate tpl, int level, String name) {
		FightUnit fightUnit = new FightUnit();
		//类型
		fightUnit.setUnitType(tpl.getPetType());
		fightUnit.setId(id);
		fightUnit.setTemplateId(tpl.getId());
		fightUnit.setAttackType(tpl.getPetAttackType());
		fightUnit.setPosition(position);
		fightUnit.setName(name != null ? name : tpl.getName());
		
		//技能
		for (SkillItem esi : tpl.getValidSkillList()) {
			FightUnitSkillInfo info = new FightUnitSkillInfo(esi.getSkillId(), PetDef.DEFAULT_SKILL_LEVEL, 
					esi.getWeight(), esi.getCdRound());
			
			fightUnit.addSkillOnInit(info);
		}
		
		//是否攻击方
		fightUnit.setAttacker(false);
		
		//捕捉宠物Id
		fightUnit.setCatchPetId(tpl.getPetTplId());
		
		//等级，如果模板中配置了，就取模板的，没配就用传过来的
		level = tpl.getLevel() > 0 ? tpl.getLevel() : level;
		if (level <= 0) {
			level = 1;
		}
		fightUnit.setLevel(level);
		
		//一级属性增加的
		PetBProperty addBProp = calcAddBProp(Globals.getTemplateCacheService().get(tpl.getId(), EnemyCoefTemplate.class), level);

		/** 战斗属性 */
		Map<String, Double> attrMap = fightUnit.getAttrMap();
		double hp = Double.valueOf(tpl.getHp() + addBProp.get(PetBProperty.HP));
		attrMap.put(BattleDef.HP, hp);
		attrMap.put(BattleDef.HP + BattleDef.MAX, hp);
		double mp = Double.valueOf(tpl.getMp() + addBProp.get(PetBProperty.MP));
		attrMap.put(BattleDef.MP, mp);
		attrMap.put(BattleDef.MP + BattleDef.MAX, mp);
		double sp = Double.valueOf(tpl.getSp() + addBProp.get(PetBProperty.SP));
		attrMap.put(BattleDef.SP, sp);
		attrMap.put(BattleDef.SP + BattleDef.MAX, sp);
		
		double speed = Double.valueOf(tpl.getSpeed() + addBProp.get(PetBProperty.SPEED));
		attrMap.put(BattleDef.SPEED, speed);
		attrMap.put(BattleDef.SPEED + BattleDef.MAX, speed);
		
		attrMap.put(BattleDef.PHYSICAL_ATTACK, Double.valueOf(tpl.getPhysicalAttack() + addBProp.get(PetBProperty.PHYSICAL_ATTACK)));
		attrMap.put(BattleDef.PHYSICAL_ARMOR, Double.valueOf(tpl.getPhysicalArmor() + addBProp.get(PetBProperty.PHYSICAL_ARMOR)));
		attrMap.put(BattleDef.MAGIC_ATTACK, Double.valueOf(tpl.getMagicAttack() + addBProp.get(PetBProperty.MAGIC_ATTACK)));
		attrMap.put(BattleDef.MAGIC_ARMOR, Double.valueOf(tpl.getMagicArmor() + addBProp.get(PetBProperty.MAGIC_ARMOR)));
		
		attrMap.put(BattleDef.PHYSICAL_HIT, Double.valueOf(tpl.getPhysicalHit() + addBProp.get(PetBProperty.PHYSICAL_HIT)));
		attrMap.put(BattleDef.PHYSICAL_DODGY, Double.valueOf(tpl.getPhysicalDodgy() + addBProp.get(PetBProperty.PHYSICAL_DODGY)));
		attrMap.put(BattleDef.PHYSICAL_CRIT, Double.valueOf(tpl.getPhysicalCrit() + addBProp.get(PetBProperty.PHYSICAL_CRIT)));
		attrMap.put(BattleDef.PHYSICAL_ANTICRIT, Double.valueOf(tpl.getPhsicalAntiCrit() + addBProp.get(PetBProperty.PHYSICAL_ANTICRIT)));
		attrMap.put(BattleDef.MAGIC_HIT, Double.valueOf(tpl.getMagicHit() + addBProp.get(PetBProperty.MAGIC_HIT)));
		attrMap.put(BattleDef.MAGIC_DODGY, Double.valueOf(tpl.getMagicDodgy() + addBProp.get(PetBProperty.MAGIC_DODGY)));
		attrMap.put(BattleDef.MAGIC_CRIT, Double.valueOf(tpl.getMagicCrit() + addBProp.get(PetBProperty.MAGIC_CRIT)));
		attrMap.put(BattleDef.MAGIC_ANTICRIT, Double.valueOf(tpl.getMagicAntiCrit() + addBProp.get(PetBProperty.MAGIC_ANTICRIT)));
		
		//初始属性Map
		Map<String, Double> initAttrMap = new HashMap<String, Double>(); 
		initAttrMap.putAll(attrMap);
		fightUnit.setInitAttrMap(initAttrMap);

		BattleTemplateCache battleTemplateCache = Globals.getTemplateCacheService().getBattleTemplateCache();
	
		// 普通攻击
		List<IEffect> normal = battleTemplateCache.getSkillEffectsNoMind(BattleDef.NORMAL_ATTACK_SKILL_ID, 
				BattleDef.DEFAULT_SKILL_LEVEL);
		fightUnit.setNormalAttack(normal);

		// 技能效果
		fightUnit.addSkillEffectOnInit();
		
		return fightUnit;
	}
	
	/**
	 * 计算等级带来的属性影响，即怪物的成长
	 * @param enemyTpl
	 * @param level
	 * @return
	 */
	public static PetBProperty calcAddBProp(EnemyCoefTemplate tpl, int level) {
		PetBProperty prop = new PetBProperty();
		//二级属性=（等级-1）*对应系数
		int levelP = level - 1;
		
		double hp = levelP * EffectHelper.int2Double(tpl.getHp());
		prop.set(PetBProperty.HP, (int)hp);
		double mp = levelP * EffectHelper.int2Double(tpl.getMp());
		prop.set(PetBProperty.MP, (int)mp);
		double speed = levelP * EffectHelper.int2Double(tpl.getSpeed());
		prop.set(PetBProperty.SPEED, (int)speed);
		
		double pa = levelP * EffectHelper.int2Double(tpl.getPhysicalAttack());
		prop.set(PetBProperty.PHYSICAL_ATTACK, (int)pa);
		double par = levelP * EffectHelper.int2Double(tpl.getPhysicalArmor());
		prop.set(PetBProperty.PHYSICAL_ARMOR, (int)par);
		double ph = levelP * EffectHelper.int2Double(tpl.getPhysicalHit());
		prop.set(PetBProperty.PHYSICAL_HIT, (int)ph);
		double pd = levelP * EffectHelper.int2Double(tpl.getPhysicalDodgy());
		prop.set(PetBProperty.PHYSICAL_DODGY, (int)pd);
		double pc = levelP * EffectHelper.int2Double(tpl.getPhysicalCrit());
		prop.set(PetBProperty.PHYSICAL_CRIT, (int)pc);
		double pac = levelP * EffectHelper.int2Double(tpl.getPhsicalAntiCrit());
		prop.set(PetBProperty.PHYSICAL_ANTICRIT, (int)pac);
		
		double ma = levelP * EffectHelper.int2Double(tpl.getMagicAttack());
		prop.set(PetBProperty.MAGIC_ATTACK, (int)ma);
		double mar = levelP * EffectHelper.int2Double(tpl.getMagicArmor());
		prop.set(PetBProperty.MAGIC_ARMOR, (int)mar);
		double mh = levelP * EffectHelper.int2Double(tpl.getMagicHit());
		prop.set(PetBProperty.MAGIC_HIT, (int)mh);
		double md = levelP * EffectHelper.int2Double(tpl.getMagicDodgy());
		prop.set(PetBProperty.MAGIC_DODGY, (int)md);
		double mc = levelP * EffectHelper.int2Double(tpl.getMagicCrit());
		prop.set(PetBProperty.MAGIC_CRIT, (int)mc);
		double mac = levelP * EffectHelper.int2Double(tpl.getMagicAntiCrit());
		prop.set(PetBProperty.MAGIC_ANTICRIT, (int)mac);
		
		return prop;
	}
}
