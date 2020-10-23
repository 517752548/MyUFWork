package com.imop.lj.gameserver.pet.helper;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gameserver.arena.template.ArenaLeaderSkillWeightTemplate;
import com.imop.lj.gameserver.arena.template.ArenaPetSkillWeightTemplate;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.FightUnitSkillEffectInfo;
import com.imop.lj.gameserver.battle.core.FightUnitSkillInfo;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.cache.template.BattleTemplateCache;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.SkillItem;
import com.imop.lj.gameserver.offlinedata.PetBattleSnap;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserPetData;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.pet.PetDef.GeneType;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.PetQuality;
import com.imop.lj.gameserver.pet.PetDef.PetState;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.PetFriend;
import com.imop.lj.gameserver.pet.PetHorse;
import com.imop.lj.gameserver.pet.PetLeader;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.pet.PetSkillEffectInfo;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.pet.template.PetFightPowerTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;

public class PetHelper {
	
	/**
	 * @description: 通过武将模板创建宠物，并设置一些初始信息<br>
	 *               这里需要注意的是，此方法中的pet<b>没有owner</b>，<Br>
	 *               所以方法中调用的所有Pet相关函数要注意<b>不可以直接使用pet.getOwner()</b>
	 * @param generalTmplId
	 * @param dbId
	 * @return
	 */
	public static Pet createNewPetFromTemplate(int generalTmplId, long dbId) {
		Pet pet = null;
		PetTemplate tpl = Globals.getTemplateCacheService().get(generalTmplId, PetTemplate.class);
		switch (tpl.getPetType()) {
		case LEADER:
			pet = new PetLeader();
			initPetBase(pet, generalTmplId, dbId);
			break;
		case PET:
			pet = new PetPet();
			initPetBase(pet, generalTmplId, dbId);
			break;
		case FRIEND:
			pet = new PetFriend();
			initPetBase(pet, generalTmplId, dbId);
			break;
		case HORSE:
			pet = new PetHorse();
			initPetBase(pet, generalTmplId, dbId);
			break;
		default:
			break;
		}
		return pet;
	}
	
	private static void initPetBase(Pet pet, int generalTmplId, long dbId) {
		pet.setDbId(dbId);
		//默认一级，白色
		pet.setLevel(RoleConstants.PET_INIT_LEVEL_NUM);
		pet.setColor(PetQuality.WHITE.index);
		pet.setExp(0);
		pet.setTemplateId(generalTmplId);
		pet.setCreateTime(Globals.getTimeService().now());
		pet.setPetState(PetState.NORMAL.index);
		
		pet.init();
	}
	
	public static Pet newPetFromEntity(PetEntity entity) {
		PetType petType = PetType.valueOf(entity.getPetType());
		if (petType == null) {
			return null;
		}
		Pet pet = null;
		switch (petType) {
		case LEADER:
			pet = new PetLeader();
			break;
		case PET:
			pet = new PetPet();
			break;
		case FRIEND:
			pet = new PetFriend();
			break;
		case HORSE:
			pet = new PetHorse();
			break;
		default:
			break;
		}
		return pet;
	}
	
	/**
	 * 根据武将创建战斗单位
	 * 
	 */
	public static FightUnit createFightUnit(Pet pet, int battleIndex, String id, boolean isAttacker) {
		long humanId = pet.getOwner().getCharId();
		long petId = pet.getUUID();
		PetType fuType = pet.getPetType();
		FightUnit fightUnit = new FightUnit();
		fightUnit.setUnitType(fuType);
		fightUnit.setUuid(pet.getGUID());
		fightUnit.setId(id);
		fightUnit.setOwnerId(humanId);
		fightUnit.setPetUUId(petId);
		
		fightUnit.setAttacker(isAttacker);
		
		//宠物是否变异字段
		if (pet instanceof PetPet) {
			fightUnit.setGeneType(((PetPet)pet).getGeneType());
		}
		
		//武将基础模版
		PetTemplate petTpl = pet.getTemplate();
		fightUnit.setTemplateId(petTpl.getId());
		fightUnit.setAttackType(petTpl.getPetAttackType());
		fightUnit.setLevel(pet.getLevel());
		fightUnit.setPosition(battleIndex);
		fightUnit.setName(pet.getName());
		
		//技能
		switch (petTpl.getPetType()) {
		//主将和宠物的从数据库读取
		case LEADER:
			//设置武器模板Id
			fightUnit.setLeaderWeaponId(Globals.getEquipService().getLeaderWeaponTplId(humanId));
			//设置心法Id和心法等级
			fightUnit.setMindId(pet.getOwner().getRunningMainSkillType().getIndex());
			fightUnit.setMindLevel(pet.getOwner().getMainSkillLevel());
			//主将的技能
			PetLeader pl = (PetLeader)pet;
			for (PetSkillInfo psi : pl.getSkillMap().values()) {
				FightUnitSkillInfo info = new FightUnitSkillInfo(psi.getSkillId(), psi.getLevel());
				//镶嵌的仙符效果
				for (PetSkillEffectInfo eInfo : psi.getEmbedEffectList()) {
					if (!eInfo.isEmptyPos()) {
						info.addEmbedEffect(new FightUnitSkillEffectInfo(eInfo.getEffectId(), eInfo.getEffectLevel()));
					}
				}
				fightUnit.addSkillOnInit(info);
			}
			//主将有捕捉技能
			FightUnitSkillInfo cInfo = new FightUnitSkillInfo(BattleDef.CATCH_PET_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(cInfo);
			
			//主将有逃跑技能
			FightUnitSkillInfo eInfo = new FightUnitSkillInfo(BattleDef.ESCAPE_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(eInfo);
			
			//主将有召唤技能
			FightUnitSkillInfo sInfo = new FightUnitSkillInfo(BattleDef.SUMMON_PET_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(sInfo);
			
			//主将和宠物都有防御技能
			FightUnitSkillInfo defenceInfoLeader = new FightUnitSkillInfo(BattleDef.DEFENCE_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(defenceInfoLeader);
			
			//主将和宠物都有嗑药技能
			FightUnitSkillInfo useDrugsInfoLeader = new FightUnitSkillInfo(BattleDef.USEDRUGS_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(useDrugsInfoLeader);
			
			break;
		case PET:
			for (PetSkillInfo psi : pet.getSkillList()) {
				FightUnitSkillInfo info = new FightUnitSkillInfo(psi.getSkillId(), psi.getLevel());
				fightUnit.addSkillOnInit(info);
			}
			
			//主将和宠物都有防御技能
			FightUnitSkillInfo defenceInfo = new FightUnitSkillInfo(BattleDef.DEFENCE_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(defenceInfo);
			
			//主将和宠物都有嗑药技能
			FightUnitSkillInfo useDrugsInfo = new FightUnitSkillInfo(BattleDef.USEDRUGS_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(useDrugsInfo);
			break;
			
		//伙伴的技能直接读取配置表，类似怪物
		case FRIEND:
			for (SkillItem esi : petTpl.getValidSkillList()) {
				FightUnitSkillInfo info = new FightUnitSkillInfo(esi.getSkillId(), PetDef.DEFAULT_SKILL_LEVEL, 
						esi.getWeight(), esi.getCdRound());
				fightUnit.addSkillOnInit(info);
			}
			break;
		default:
			Loggers.battleLogger.error("invalid petType not handled!");
			break;
		}
		
		//获取当前hp、mp、sp、life数值
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(humanId);
		UserPetData petData = offlineData.getPetData(petId);

		/**attr*/
		Map<String, Double> attrMap = fightUnit.getAttrMap();
		attrMap.put(BattleDef.HP, Double.valueOf(petData.getHp()));
		attrMap.put(BattleDef.HP + BattleDef.MAX, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.HP)));
		attrMap.put(BattleDef.MP, Double.valueOf(petData.getMp()));
		attrMap.put(BattleDef.MP + BattleDef.MAX, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.MP)));
		//怒气
		attrMap.put(BattleDef.SP, Double.valueOf(petData.getSp()));
		//怒气上限是个常量
		attrMap.put(BattleDef.SP + BattleDef.MAX, Double.valueOf(Globals.getGameConstants().getBattleSpMax()));
		
		//寿命
		attrMap.put(BattleDef.LIFE, Double.valueOf(petData.getLife()));
		
		attrMap.put(BattleDef.SPEED, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.SPEED)));
		attrMap.put(BattleDef.SPEED + BattleDef.MAX, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.SPEED)));
		
		attrMap.put(BattleDef.PHYSICAL_ATTACK, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.PHYSICAL_ATTACK)));
		attrMap.put(BattleDef.PHYSICAL_ARMOR, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.PHYSICAL_ARMOR)));
		attrMap.put(BattleDef.MAGIC_ATTACK, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.MAGIC_ATTACK)));
		attrMap.put(BattleDef.MAGIC_ARMOR, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.MAGIC_ARMOR)));
		
		attrMap.put(BattleDef.PHYSICAL_HIT, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.PHYSICAL_HIT)));
		attrMap.put(BattleDef.PHYSICAL_DODGY, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.PHYSICAL_DODGY)));
		attrMap.put(BattleDef.PHYSICAL_CRIT, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.PHYSICAL_CRIT)));
		attrMap.put(BattleDef.PHYSICAL_ANTICRIT, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.PHYSICAL_ANTICRIT)));
		attrMap.put(BattleDef.MAGIC_HIT, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.MAGIC_HIT)));
		attrMap.put(BattleDef.MAGIC_DODGY, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.MAGIC_DODGY)));
		attrMap.put(BattleDef.MAGIC_CRIT, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.MAGIC_CRIT)));
		attrMap.put(BattleDef.MAGIC_ANTICRIT, Double.valueOf(pet.getPropertyManager().getBProperty(PetBProperty.MAGIC_ANTICRIT)));

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
	 * 根据武将离线数据创建战斗单位
	 * 
	 * @param userSnap
	 * @param petSnap
	 * @param battleIndex
	 * @param id
	 * @param horseBattle
	 * @param additionSkillIds
	 * @param isAttacker
	 * @return
	 */
	public static FightUnit createFightUnitByPetSnap(UserSnap userSnap, PetBattleSnap petSnap, int battleIndex, String id, boolean isAttacker) {
		long humanId = petSnap.getHumanId();
		long petId = petSnap.getPetId();
		PetType fuType = petSnap.getPetType();
		FightUnit fightUnit = new FightUnit();
		fightUnit.setUnitType(fuType);
		fightUnit.setUuid(petSnap.getGUID());
		fightUnit.setId(id);
		fightUnit.setOwnerId(humanId);
		fightUnit.setPetUUId(petId);
		
		fightUnit.setAttacker(isAttacker);
		
		//宠物是否变异字段
		if (fuType == PetType.PET) {
			fightUnit.setGeneType(GeneType.valueOf(petSnap.getGeneTypeId()));
		}
		
		//武将基础模版
		PetTemplate petTpl = petSnap.getTemplate();
		fightUnit.setTemplateId(petTpl.getId());
		fightUnit.setAttackType(petTpl.getPetAttackType());
		fightUnit.setLevel(petSnap.getLevel());
		fightUnit.setPosition(battleIndex);
		fightUnit.setName(petSnap.getName());
		
		//技能，离线数据构建战斗对象
		switch (petTpl.getPetType()) {
		//主将和宠物的从数据库读取
		case LEADER:
			//设置武器模板Id
			fightUnit.setLeaderWeaponId(Globals.getEquipService().getLeaderWeaponTplId(humanId));
			//设置心法Id和心法等级
			fightUnit.setMindId(userSnap.getMindId());
			fightUnit.setMindLevel(userSnap.getMindLevel());
			
			//主将的技能，只有自动技能
			int leaderSkillId = userSnap.getAutoActionId();
			int leaderSkillLevel = userSnap.getAutoSkillLevel();
			FightUnitSkillInfo info = new FightUnitSkillInfo(leaderSkillId, leaderSkillLevel);
			//镶嵌的仙符效果
			PetSkillInfo leaderSkillInfo = userSnap.getAutoSkillEmbedEffectList();
			if (leaderSkillInfo != null) {
				for (PetSkillEffectInfo eInfo : leaderSkillInfo.getEmbedEffectList()) {
					if (!eInfo.isEmptyPos()) {
						info.addEmbedEffect(new FightUnitSkillEffectInfo(eInfo.getEffectId(), eInfo.getEffectLevel()));
					}
				}
			}
			fightUnit.addSkillOnInit(info);
			
			//主将有捕捉技能
			FightUnitSkillInfo cInfo = new FightUnitSkillInfo(BattleDef.CATCH_PET_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(cInfo);
			
			//主将有逃跑技能
			FightUnitSkillInfo eInfo = new FightUnitSkillInfo(BattleDef.ESCAPE_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(eInfo);
			
			//主将有召唤技能
			FightUnitSkillInfo sInfo = new FightUnitSkillInfo(BattleDef.SUMMON_PET_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(sInfo);
			
			//主将和宠物都有防御技能
			FightUnitSkillInfo defenceInfoLeader = new FightUnitSkillInfo(BattleDef.DEFENCE_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(defenceInfoLeader);
			
			//主将和宠物都有嗑药技能
			FightUnitSkillInfo useDrugsInfoLeader = new FightUnitSkillInfo(BattleDef.USEDRUGS_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(useDrugsInfoLeader);
			break;
		case PET:
			//宠物的技能，只有自动技能
			int petSkillId = userSnap.getPetAutoActionId();
			int petSkillLevel = userSnap.getPetAutoSkillLevel();
			FightUnitSkillInfo psInfo = new FightUnitSkillInfo(petSkillId, petSkillLevel);
			fightUnit.addSkillOnInit(psInfo);
			
			//主将和宠物都有防御技能
			FightUnitSkillInfo defenceInfo = new FightUnitSkillInfo(BattleDef.DEFENCE_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(defenceInfo);
			
			//主将和宠物都有嗑药技能
			FightUnitSkillInfo useDrugsInfo = new FightUnitSkillInfo(BattleDef.USEDRUGS_SKILL_ID, BattleDef.DEFAULT_SKILL_LEVEL);
			fightUnit.addSkillOnInit(useDrugsInfo);
			break;
			
		//伙伴的技能直接读取配置表，类似怪物
		case FRIEND:
			for (SkillItem esi : petTpl.getValidSkillList()) {
				FightUnitSkillInfo fInfo = new FightUnitSkillInfo(esi.getSkillId(), PetDef.DEFAULT_SKILL_LEVEL, 
						esi.getWeight(), esi.getCdRound());
				fightUnit.addSkillOnInit(fInfo);
			}
			break;
		default:
			Loggers.battleLogger.error("invalid petType not handled!");
			break;
		}
		
		//获取当前hp、mp、sp、life数值
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(humanId);
		UserPetData petData = offlineData.getPetData(petId);
		
		/**attr*/
		Map<String, Double> attrMap = fightUnit.getAttrMap();
		attrMap.put(BattleDef.HP, Double.valueOf(petData.getHp()));
		attrMap.put(BattleDef.HP + BattleDef.MAX, Double.valueOf(petSnap.getBProperty(PetBProperty.HP)));
		attrMap.put(BattleDef.MP, Double.valueOf(petData.getMp()));
		attrMap.put(BattleDef.MP + BattleDef.MAX, Double.valueOf(petSnap.getBProperty(PetBProperty.MP)));
		//怒气
		attrMap.put(BattleDef.SP, Double.valueOf(petData.getSp()));
		//怒气上限是个常量
		attrMap.put(BattleDef.SP + BattleDef.MAX, Double.valueOf(Globals.getGameConstants().getBattleSpMax()));
		
		//寿命
		attrMap.put(BattleDef.LIFE, Double.valueOf(petData.getLife()));
		
		attrMap.put(BattleDef.SPEED, Double.valueOf(petSnap.getBProperty(PetBProperty.SPEED)));
		attrMap.put(BattleDef.SPEED + BattleDef.MAX, Double.valueOf(petSnap.getBProperty(PetBProperty.SPEED)));
		
		attrMap.put(BattleDef.PHYSICAL_ATTACK, Double.valueOf(petSnap.getBProperty(PetBProperty.PHYSICAL_ATTACK)));
		attrMap.put(BattleDef.PHYSICAL_ARMOR, Double.valueOf(petSnap.getBProperty(PetBProperty.PHYSICAL_ARMOR)));
		attrMap.put(BattleDef.MAGIC_ATTACK, Double.valueOf(petSnap.getBProperty(PetBProperty.MAGIC_ATTACK)));
		attrMap.put(BattleDef.MAGIC_ARMOR, Double.valueOf(petSnap.getBProperty(PetBProperty.MAGIC_ARMOR)));
		
		attrMap.put(BattleDef.PHYSICAL_HIT, Double.valueOf(petSnap.getBProperty(PetBProperty.PHYSICAL_HIT)));
		attrMap.put(BattleDef.PHYSICAL_DODGY, Double.valueOf(petSnap.getBProperty(PetBProperty.PHYSICAL_DODGY)));
		attrMap.put(BattleDef.PHYSICAL_CRIT, Double.valueOf(petSnap.getBProperty(PetBProperty.PHYSICAL_CRIT)));
		attrMap.put(BattleDef.PHYSICAL_ANTICRIT, Double.valueOf(petSnap.getBProperty(PetBProperty.PHYSICAL_ANTICRIT)));
		attrMap.put(BattleDef.MAGIC_HIT, Double.valueOf(petSnap.getBProperty(PetBProperty.MAGIC_HIT)));
		attrMap.put(BattleDef.MAGIC_DODGY, Double.valueOf(petSnap.getBProperty(PetBProperty.MAGIC_DODGY)));
		attrMap.put(BattleDef.MAGIC_CRIT, Double.valueOf(petSnap.getBProperty(PetBProperty.MAGIC_CRIT)));
		attrMap.put(BattleDef.MAGIC_ANTICRIT, Double.valueOf(petSnap.getBProperty(PetBProperty.MAGIC_ANTICRIT)));

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
	
//	/**
//	 * 计算伙伴的二级属性
//	 * @param petTpl
//	 * @param level
//	 * @return
//	 */
//	public static PetBProperty calcFriendBProp(PetTemplate petTpl, int level) {
//		PetBProperty prop = new PetBProperty();
//		//一级属性成长
//		PetBProperty addBProp = FightUnitHelper.calcAddBProp(petTpl, level);
//		
//		//模板的二级属性+一级属性成长
//		prop.set(PetBProperty.HP, petTpl.getHp() + addBProp.get(PetBProperty.HP));
//		prop.set(PetBProperty.MP, petTpl.getMp() + addBProp.get(PetBProperty.MP));
//		
//		prop.set(PetBProperty.PHYSICAL_ATTACK, petTpl.getPhysicalAttack() + addBProp.get(PetBProperty.PHYSICAL_ATTACK));
//		prop.set(PetBProperty.PHYSICAL_ARMOR, petTpl.getPhysicalArmor() + addBProp.get(PetBProperty.PHYSICAL_ARMOR));
//		prop.set(PetBProperty.PHYSICAL_HIT, petTpl.getPhysicalHit() + addBProp.get(PetBProperty.PHYSICAL_HIT));
//		prop.set(PetBProperty.PHYSICAL_DODGY, petTpl.getPhysicalDodgy() + addBProp.get(PetBProperty.PHYSICAL_DODGY));
//		prop.set(PetBProperty.PHYSICAL_CRIT, petTpl.getPhysicalCrit() + addBProp.get(PetBProperty.PHYSICAL_CRIT));
//		prop.set(PetBProperty.PHYSICAL_ANTICRIT, petTpl.getPhsicalAntiCrit() + addBProp.get(PetBProperty.PHYSICAL_ANTICRIT));
//		
//		prop.set(PetBProperty.MAGIC_ATTACK, petTpl.getMagicAttack() + addBProp.get(PetBProperty.MAGIC_ATTACK));
//		prop.set(PetBProperty.MAGIC_ARMOR, petTpl.getMagicArmor() + addBProp.get(PetBProperty.MAGIC_ARMOR));
//		prop.set(PetBProperty.MAGIC_HIT, petTpl.getMagicHit() + addBProp.get(PetBProperty.MAGIC_HIT));
//		prop.set(PetBProperty.MAGIC_DODGY, petTpl.getMagicDodgy() + addBProp.get(PetBProperty.MAGIC_DODGY));
//		prop.set(PetBProperty.MAGIC_CRIT, petTpl.getMagicCrit() + addBProp.get(PetBProperty.MAGIC_CRIT));
//		prop.set(PetBProperty.MAGIC_ANTICRIT, petTpl.getMagicAntiCrit() + addBProp.get(PetBProperty.MAGIC_ANTICRIT));
//		
//		prop.set(PetBProperty.SPEED, petTpl.getSpeed() + addBProp.get(PetBProperty.SPEED));
//		prop.set(PetBProperty.LIFE, petTpl.getLife() + addBProp.get(PetBProperty.LIFE));
//		
//		return prop;
//	}
	
	public static FightUnit createFightUnitForArena(Pet pet, int battleIndex, String id, boolean isAttacker) {
		FightUnit fu = createFightUnit(pet, battleIndex, id, isAttacker);
		//设置技能的冷却回合数
		updateSkillCdRound(fu, pet.getJobType());
		return fu;
	}
	
	public static FightUnit createFightUnitByPetSnapForArena(UserSnap userSnap, PetBattleSnap petSnap, int battleIndex, String id, boolean isAttacker) {
		FightUnit fu = createFightUnitByPetSnap(userSnap, petSnap, battleIndex, id, isAttacker);
		//设置技能的冷却回合数
		updateSkillCdRound(fu, userSnap.getHumanJobType());
		return fu;
	}
	
	private static void updateSkillCdRound(FightUnit fu, JobType jt) {
		//设置技能的冷却回合数
		for (FightUnitSkillInfo info : fu.getAllSkill()) {
			int skillId = info.getSkillId();
			if (fu.getUnitType() == PetType.LEADER) {
				Map<Integer, ArenaLeaderSkillWeightTemplate> m = Globals.getTemplateCacheService().getArenaTemplateCache().getLeaderSkillWeightMap(jt);
				if (m.containsKey(skillId)) {
					info.setCdRound(m.get(skillId).getCdRound());
				}
			} else if (fu.getUnitType() == PetType.PET) {
				ArenaPetSkillWeightTemplate tpl = Globals.getTemplateCacheService().get(skillId, ArenaPetSkillWeightTemplate.class);
				if (tpl != null) {
					info.setCdRound(tpl.getCdRound());
				}
			}
		}
	}
	
	/**
	 * 根据属性和模板，计算基础战力
	 * @param prop
	 * @param template
	 * @return
	 */
	public static double getBaseFightPower(PetBProperty prop, PetFightPowerTemplate template) {
		double basePower = 
		prop.get(PetBProperty.HP) * template.getHP() +
		prop.get(PetBProperty.MP) * template.getMP() +
		prop.get(PetBProperty.PHYSICAL_ATTACK) * template.getPhysicalAttack() + 
		prop.get(PetBProperty.PHYSICAL_ARMOR) * template.getPhysicalArmor() + 
		prop.get(PetBProperty.PHYSICAL_HIT) * template.getPhysicalHit() + 
		prop.get(PetBProperty.PHYSICAL_DODGY) * template.getPhysicalDodgy() + 
		prop.get(PetBProperty.PHYSICAL_CRIT) * template.getPhysicalCrit()+ 
		prop.get(PetBProperty.PHYSICAL_ANTICRIT) * template.getPhysicalAnticrit() + 
		prop.get(PetBProperty.MAGIC_ATTACK) * template.getMagicalAttack() + 
		prop.get(PetBProperty.MAGIC_ARMOR) * template.getMagicalArmor() + 
		prop.get(PetBProperty.MAGIC_HIT) * template.getMagicalHit() + 
		prop.get(PetBProperty.MAGIC_DODGY) * template.getMagicalDodgy() + 
		prop.get(PetBProperty.MAGIC_CRIT) * template.getMagicalCrit() + 
		prop.get(PetBProperty.MAGIC_ANTICRIT) * template.getMagicalAnticrit() + 
		prop.get(PetBProperty.SPEED) * template.getSpeed() ;
		return basePower;
	}
	
}
