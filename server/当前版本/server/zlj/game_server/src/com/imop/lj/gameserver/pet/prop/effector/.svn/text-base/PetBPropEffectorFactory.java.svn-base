package com.imop.lj.gameserver.pet.prop.effector;

import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corpscultivate.model.CulSkillRecord;
import com.imop.lj.gameserver.corpscultivate.template.CorpsCultivateTemplate;
import com.imop.lj.gameserver.equip.EquipHoleInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.humanskill.template.HumanSubPassiveSkillTemplate;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.PetEquipBag;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.item.template.EquipItemAttribute;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.SkillType;
import com.imop.lj.gameserver.pet.PetLeader;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.pet.template.PassiveTalentPropItem;
import com.imop.lj.gameserver.pet.template.PetPassiveNormalSkillTemplate;
import com.imop.lj.gameserver.pet.template.PetPassiveTalentSkillTemplate;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;
import com.imop.lj.gameserver.title.template.TitleTemplate;
import com.imop.lj.gameserver.wing.Wing;

public class PetBPropEffectorFactory {
	
	public static final PetPropertyEffector<PetBProperty, Pet> INIT_EFFECTOR = new PetPropertyEffector<PetBProperty, Pet>() {

		@Override
		public void effect(PetBProperty prop, Pet pet) {
			prop.clear();
			
			//读取模版
			PetTemplate petTemplate = Globals.getTemplateCacheService().get(pet.getTemplateId(), PetTemplate.class);
			if(petTemplate != null) {
				setProperty(prop, petTemplate);
			}
		}
	};
	
	private static void setProperty(PetBProperty prop, PetTemplate petTemp) {

		prop.set(PetBProperty.HP, petTemp.getHp());
		prop.set(PetBProperty.MP, petTemp.getMp());
		
		prop.set(PetBProperty.PHYSICAL_ATTACK, petTemp.getPhysicalAttack());
		prop.set(PetBProperty.PHYSICAL_ARMOR, petTemp.getPhysicalArmor());
		prop.set(PetBProperty.PHYSICAL_HIT, petTemp.getPhysicalHit());
		prop.set(PetBProperty.PHYSICAL_DODGY, petTemp.getPhysicalDodgy());
		prop.set(PetBProperty.PHYSICAL_CRIT, petTemp.getPhysicalCrit());
		prop.set(PetBProperty.PHYSICAL_ANTICRIT, petTemp.getPhsicalAntiCrit());
		
		prop.set(PetBProperty.MAGIC_ATTACK, petTemp.getMagicAttack());
		prop.set(PetBProperty.MAGIC_ARMOR, petTemp.getMagicArmor());
		prop.set(PetBProperty.MAGIC_HIT, petTemp.getMagicHit());
		prop.set(PetBProperty.MAGIC_DODGY, petTemp.getMagicDodgy());
		prop.set(PetBProperty.MAGIC_CRIT, petTemp.getMagicCrit());
		prop.set(PetBProperty.MAGIC_ANTICRIT, petTemp.getMagicAntiCrit());
		
		prop.set(PetBProperty.SPEED, petTemp.getSpeed());
//		prop.set(PetBProperty.SP, petTemp.getSp());
		prop.set(PetBProperty.LIFE, Globals.getGameConstants().getPetInitLife());
		prop.set(PetBProperty.LOYALTY, Globals.getGameConstants().getPetHorseInitLoy());
		prop.set(PetBProperty.CLOSENESS, Globals.getGameConstants().getPetHorseInitClo());
		
	}
	
	/** 一级属性影响 **/
	public static final PetPropertyEffector<PetBProperty, Pet> PROP_A = new PetPropertyEffector<PetBProperty, Pet>() {

		@Override
		public void effect(PetBProperty prop, Pet pet) {
			prop.clear();
			
			//力量
			float strength = pet.getPropertyManager().getAProperty(PetAProperty.STRENGTH);
			//敏捷
			float agility = pet.getPropertyManager().getAProperty(PetAProperty.AGILITY);
			//智力
			float intellect = pet.getPropertyManager().getAProperty(PetAProperty.INTELLECT);
			//信仰
			float faith = pet.getPropertyManager().getAProperty(PetAProperty.FAITH);
			//耐力
			float stamina = pet.getPropertyManager().getAProperty(PetAProperty.STAMINA);
			
			int base = Globals.getGameConstants().getScale();
			Collection<PetPropTemplate> cAll = Globals.getTemplateCacheService().getAll(PetPropTemplate.class).values();
			for (PetPropTemplate ppTpl : cAll) {
				float attr = strength * ppTpl.getStrength() / base + 
						agility * ppTpl.getAgility() / base +
						intellect * ppTpl.getIntellect() / base +
						faith * ppTpl.getFaith() / base +
						stamina * ppTpl.getStamina() / base
						;
				
				prop.set(ppTpl.getPropIndex(), attr);
			}
			
		}
	};

	/** 装备影响 */
	public static final PetPropertyEffector<PetBProperty, Pet> EQUIP_EFFECTOR = new PetPropertyEffector<PetBProperty, Pet>() {

		@Override
		public void effect(PetBProperty prop, Pet pet) {
			prop.clear();
			PetEquipBag bag = pet.getOwner().getInventory().getBagByPet(pet.getUUID());
			if (bag == null) {
				return;
			}
			
			for (Item item : bag.getAllItems()) {
				if (item == null || item.isEmpty() || !item.isEquipment()) {
            		continue;
            	}
				addPropertyOfEquip(prop, item, pet);
			}
			
			createSuitEquipEffect(prop, pet, bag);
		}
	};
	
	private static void addPropertyOfEquip(PetBProperty targetProp, Item item, Pet pet) {
		if (!(item.getFeature() instanceof EquipFeature)) {
            return;
        }
        EquipFeature feature = (EquipFeature) item.getFeature();
		
        //装备属性
		Map<Integer, Float> map = Globals.getEquipService().calcEquipWithStarProp(pet, item, PetBProperty.TYPE);
		if (map != null) {
			for(Entry<Integer, Float> entry : map.entrySet()){
				targetProp.add(entry.getKey(), entry.getValue());
			}
		}
		
		//宝石属性
		addPropOfGem(targetProp, pet, feature);
	}
	
	/**
	 * 宝石属性
	 * @param targetProp
	 * @param pet
	 * @param feature
	 */
	private static void addPropOfGem(PetBProperty targetProp, Pet pet, EquipFeature feature) {
		List<EquipHoleInfo> ls = feature.getHoleManager().getHoleList();
		for (EquipHoleInfo info : ls) {
			if (info.getGemItemId() > 0 && info.getGemTpl() != null) {
				if (PetPropTemplate.isValidPropKey(info.getGemTpl().getPropKey(), PropertyType.PET_PROP_B)) {
					targetProp.add(info.getGemTpl().getPropKeyIndex(PetBProperty.TYPE), 
							info.getGemTpl().getPropValue());
				}
			}
		}
	}
	 
	/**
	 * 套装属性
	 * 
	 * @param prop
	 * @param pet
	 */
	public static final void createSuitEquipEffect(PetBProperty prop, Pet pet, PetEquipBag bag){
//		// 统计套装个数
//		Map<EquipSuitTemplate, Integer> map = new HashMap<EquipSuitTemplate, Integer>();
//		for(Item item : bag.getAllItems()){
////			ItemFeature itemFeature = item.getFeature();
////			if(!(itemFeature instanceof AbstractEquipmentFeature)){
////				continue;
////			}
////			
////			AbstractEquipmentFeature equip = (AbstractEquipmentFeature)itemFeature;
////			EquipItemTemplate equipTemp = equip.getEquipItemTemplate();
////			EquipSuitTemplate suitTemp = equipTemp.getSuitTemp();
////			if(suitTemp == null){
////				continue;
////			}
//			ItemFeature itemFeature = item.getFeature();
//			if(!(itemFeature instanceof IEquipSuit)){
//				continue;
//			}
//			
//			IEquipSuit equip = (IEquipSuit)itemFeature;
//			EquipSuitTemplate suitTemp = equip.getEquipSuitTemplate();
//			if(suitTemp == null){
//				continue;
//			}
//			
//			Integer num = map.get(suitTemp);
//			if(num == null){
//				num = 0;
//			}
//			
//			num ++;
//			map.put(suitTemp, num);
//		}
//		
//		// 计算套装效果suitCount
//		for(Entry<EquipSuitTemplate, Integer> entry : map.entrySet()){
//			int currNum = entry.getValue();
//			for(EquipSuitModel model : entry.getKey().getSuitAttrModelList()){
//				if(currNum >= model.getNumLimit()){
//					for(AmendTriple triple : model.getAttrList()){
//						if(triple.getAmend().getPropertyType() == PetBProperty.TYPE){
//							prop.add(triple.getAmend().getProperytIndex(), triple.getValue());
//						}
//					}
//				}
//			}
//		}
	}

//	/** 品质（阶数）影响 **/
//	public static final PetPropertyEffector<PetBProperty, Pet> COLOR_EFFECTOR = new PetPropertyEffector<PetBProperty, Pet>() {
//
//		@Override
//		public void effect(PetBProperty prop, Pet pet) {
//			prop.clear();
//			
//			int petTplId = pet.getTemplateId();
//			PetQuality pq = pet.getQuality();
//			Map<Integer, Integer> propMap = Globals.getTemplateCacheService().getPetTemplateCache().getColorPropMap(petTplId, pq);
//			if (null == propMap) {
//				return;
//			}
//			
//			for (Entry<Integer, Integer> entry : propMap.entrySet()) {
//				int key = entry.getKey();
//				int value = entry.getValue();
//				if (PetPropTemplate.isValidPropKey(key, PropertyType.PET_PROP_B)) {
//					prop.set(key - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_B), value);
//				}
//			}
//		}
//	};
	
//	/** 宝石影响 */
//	public static final PetPropertyEffector<PetBProperty, Pet> GEM_EFFECTOR = new PetPropertyEffector<PetBProperty, Pet>() {
//
//		@Override
//		public void effect(PetBProperty prop, Pet pet) {
//			prop.clear();
//			PetGemBag bag = pet.getOwner().getInventory().getGemBagByPet(pet.getUUID());
//			if(bag == null){
//				return;
//			}
//			for(Position p : bag.getPosition()){
//				for(Item item : bag.getItemsByPosition(p)){
//					addPropertyForGem(prop, item, pet, p);
//				}
//			}
//		}
//	};

	public static final PetPropertyEffector<PetBProperty,Pet> TITLE_EFFECTOR = new PetPropertyEffector<PetBProperty, Pet>() {
		@Override
		public void effect(PetBProperty prop, Pet pet) {
            if(!pet.isLeader()){
                return ;
            }
			prop.clear();
			int tplid = Globals.getTitleService().getCurrentTitle(pet.getOwner().getCharId());
			TitleTemplate template = Globals.getTemplateCacheService().get(tplid,TitleTemplate.class);
			if(template==null){
				return;
			}
            for (EquipItemAttribute entry :template.getValidAddPropList()) {
                if (PetPropTemplate.isValidPropKey(entry.getPropKey(), PropertyType.PET_PROP_B)) {
                    prop.add(entry.getPropKey() - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_B), entry.getPropValue());
                }
            }
		}
	};
	
	
	public static final PetPropertyEffector<PetBProperty,Pet> WING_EFFECTOR = new PetPropertyEffector<PetBProperty, Pet>() {
		@Override
		public void effect(PetBProperty prop, Pet pet) {
			if(!pet.isLeader()){
				return ;
			}
			prop.clear();
			Wing w = pet.getOwner().getWingManager().getWinging();
			if(w==null)
			{
				return ;
			}
			//翅膀，只加二级属性，所以一级属性就不用写了
			for (PassiveTalentPropItem item : w.getTemplate().getValidPropList()) {
				//增加属性值=基础数值+ 等级(翅膀阶数从0开始)*每级增加值
				int value = item.getPropValue() + w.getWingLevel() * item.getPropLevelAdd();
				prop.add(item.getPropKeyIndex(PropertyType.PET_PROP_B), value);
			}
			
		}
	};
	
	/**
	 * 帮派辅助技能,影响二级属性
	 */
	public static final PetPropertyEffector<PetBProperty, Pet> CORPS_CULTIVATE_EFFECTOR = new PetPropertyEffector<PetBProperty, Pet>() {

		@Override
		public void effect(PetBProperty prop, Pet pet) {
			//目前只有骑宠不可以加
			if(pet.isHorse()){
				return;
			}
			
			Human human = pet.getOwner();
			UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
			if(offlineData == null ){
				return;
			}
			
			prop.clear();
			
			//宠物
			if(pet.isPet()){
				//休息状态
				if(offlineData.getFightPetId() == 0){
					return;
				}
				//出战状态重新计算
				
				//拿到玩家所有的帮派辅助技能
				for(Entry<Integer,CulSkillRecord> entry : Globals.getCorpsCultivateService().getCulSkillMap(pet.getOwner()).entrySet()){
					CorpsCultivateTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCultivatePetMapById(entry.getKey());
					if(tpl == null){
						continue;
					}
					for (PassiveTalentPropItem item : tpl.getValidPropList()) {
						//增加属性值=基础数值+ 技能等级(从0开始)*每级增加值
						int value = item.getPropValue() + entry.getValue().getLevel() * item.getPropLevelAdd();
						prop.add(item.getPropKeyIndex(PropertyType.PET_PROP_B), value);
					}
					
				}
			}
			
			//人物
			if(pet.isLeader()){
				
				//拿到玩家所有的帮派辅助技能
				for(Entry<Integer,CulSkillRecord> entry : Globals.getCorpsCultivateService().getCulSkillMap(pet.getOwner()).entrySet()){
					CorpsCultivateTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCultivatePlayerMapById(entry.getKey());
					if(tpl == null){
						continue;
					}
					for (PassiveTalentPropItem item : tpl.getValidPropList()) {
						//增加属性值=基础数值+ 技能等级(从0开始)*每级增加值
						int value = item.getPropValue() + entry.getValue().getLevel() * item.getPropLevelAdd();
						prop.add(item.getPropKeyIndex(PropertyType.PET_PROP_B), value);
					}
					
				}
			}
			
          
		}
	};
	
//	private static void addPropertyForGem(PetBProperty targetProp, Item item, Pet pet, Position p) {
//		GemItemTemplate git = Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().get(item.getTemplateId());
//		if(git == null){
//			return ;
//		}
//		KeyValuePair<Integer, Integer> pair = Globals.getTemplateCacheService().getGemTemplateCache().getPropKeyAndValue(p,GemType.valueOf(git.getGemTypeId()), git.getGemLevel());
//		if (pair == null) {
//			return;
//		}
//		if(PetPropTemplate.isValidPropKey(pair.getKey(), PropertyType.PET_PROP_B)){
//			targetProp.add(pair.getKey() - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_B), pair.getValue());
//		}
//	}
	
	/** 技能影响二级属性 */
	public static final PetPropertyEffector<PetBProperty, Pet> SKILL_EFFECTOR = new PetPropertyEffector<PetBProperty, Pet>() {

		@Override
		public void effect(PetBProperty prop, Pet pet) {
			prop.clear();
			
			//主将，心法被动技能
			if (pet.isLeader()) {
				PetLeader petLeader = (PetLeader)pet;
				for (Entry<Integer, PetSkillInfo> entry : petLeader.getSkillMap().entrySet()) {
					SkillTemplate st = Globals.getTemplateCacheService().get(entry.getKey(),SkillTemplate.class);
					if (st!=null) {
						if (st.getSkillType() == SkillType.MIND_B) {
							HumanSubPassiveSkillTemplate hspst = Globals.getTemplateCacheService().get(entry.getKey(), HumanSubPassiveSkillTemplate.class);
							if (hspst!=null && PetPropTemplate.isValidPropKey(hspst.getPropType(), PropertyType.PET_PROP_B) && entry.getValue().getLevel()>0){
								prop.add(hspst.getPropType() - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_B), hspst.getBaseProp() + (entry.getValue().getLevel()-1)*hspst.getAddProp());
							}
						} else if (st.getSkillType() == SkillType.LEADER_STUDY) {
							//TODO 暂时没有被动增加属性的技能，等有了再做
							
						}
					}
				}
			} else if (pet.isPet()) {
				//宠物被动技能
				petPassvieSkillAdd(pet, prop);
			}
			
		}
	};
	
	private static void petPassvieSkillAdd(Pet pet, PetBProperty prop) {
		if (!pet.isPet()) {
			return;
		}
		
		//宠物，被动技能，只加二级属性，所以一级属性就不用写了
		Map<Integer, PetSkillInfo> skillMap = pet.getSkillMap();
		for (PetSkillInfo info : skillMap.values()) {
			SkillTemplate st = Globals.getTemplateCacheService().get(info.getSkillId(), SkillTemplate.class);
			//这里只处理被动技能
			if (!st.isPassive()) {
				continue;
			}
			//如果是天赋被动技能
			if (info.isTalent()) {
				PetPassiveTalentSkillTemplate ptsTpl = Globals.getTemplateCacheService().get(info.getSkillId(), PetPassiveTalentSkillTemplate.class);
				//可能有战斗内使用的被动技能，这种没有效果，所以会为null
				if (ptsTpl != null) {
					for (PassiveTalentPropItem item : ptsTpl.getValidPropList()) {
						//增加属性值=基础数值+（等级-1）*每级增加值
						int value = item.getPropValue() + (info.getLevel() - 1) * item.getPropLevelAdd();
						prop.add(item.getPropKeyIndex(PropertyType.PET_PROP_B), value);
					}
				}
			} else {
				//如果是普通被动技能
				PetPassiveNormalSkillTemplate ptsTpl = Globals.getTemplateCacheService().get(info.getSkillId(), PetPassiveNormalSkillTemplate.class);
				//可能有战斗内使用的被动技能，这种没有效果，所以会为null
				if (ptsTpl != null) {
					for (PassiveTalentPropItem item : ptsTpl.getValidPropList()) {
						//增加属性值=基础数值+（等级-1）*每级增加值
						int value = item.getPropValue() + (info.getLevel() - 1) * item.getPropLevelAdd();
						prop.add(item.getPropKeyIndex(PropertyType.PET_PROP_B), value);
					}
				}
			}
		}
	}
	
	/**
     * 主将二级属性成长
     */
    public static final PetPropertyEffector<PetBProperty, Pet> GROWTH_EFFECTOR = new PetPropertyEffector<PetBProperty, Pet>() {

        @Override
        public void effect(PetBProperty prop, Pet pet) {
            prop.clear();

            //只有主将有二级属性成长
            if (!pet.isLeader()) {
                return;
            }
            
            //战斗实力
            float zdsl = BattleCalculateHelper.calcZDSL(pet.getLevel());
            //根据职业获取职业系数
            JobType job = pet.getJobType();
			for (PetPropTemplate ppTpl : Globals.getTemplateCacheService().getAll(PetPropTemplate.class).values()) {
				int jobCoef = 0;
				switch (job) {
				case XIAKE:
					jobCoef = ppTpl.getXiakeCoef();
					break;
				case CIKE:
					jobCoef = ppTpl.getCikeCoef();
					break;
				case SHUSHI:
					jobCoef = ppTpl.getShushiCoef();
					break;
				case XIUZHEN:
					jobCoef = ppTpl.getXiuzhenCoef();
					break;
				default:
					break;
				}
				
				//二级属性=战斗实力*主角系数*职业系数
				double attr = zdsl * EffectHelper.int2Double(ppTpl.getLeaderCoef()) * EffectHelper.int2Double(jobCoef);
				
				prop.set(ppTpl.getPropIndex(), (float)attr);
			}
        }
    };
    
}
