package com.imop.lj.gameserver.pet.prop.effector;

import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.EquipHoleInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.humanskill.template.HumanSubPassiveSkillTemplate;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.PetEquipBag;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.item.template.EquipItemAttribute;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserPetHorseData;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.SkillType;
import com.imop.lj.gameserver.pet.PetHorse;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.template.PassiveTalentPropItem;
import com.imop.lj.gameserver.pet.template.PetHorsePassiveNormalSkillTemplate;
import com.imop.lj.gameserver.pet.template.PetHorsePassiveTalentSkillTemplate;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;
import com.imop.lj.gameserver.title.template.TitleTemplate;

public class PetAPropEffectorFactory {

    /**
     * 初始化影响，武将基础模版及天赋技能
     */
    public static final PetPropertyEffector<PetAProperty, Pet> INIT_EFFECTOR = new PetPropertyEffector<PetAProperty, Pet>() {

        @Override
        public void effect(PetAProperty prop, Pet pet) {
            prop.clear();
            PetTemplate petTpl = Globals.getTemplateCacheService().get(pet.getTemplateId(), PetTemplate.class);
            if (petTpl != null) {
                // 根据模版设置一级属性
                prop.set(PetAProperty.STRENGTH, petTpl.getStrength());
                prop.set(PetAProperty.AGILITY, petTpl.getAgility());
                prop.set(PetAProperty.INTELLECT, petTpl.getIntellect());
                prop.set(PetAProperty.FAITH, petTpl.getFaith());
                prop.set(PetAProperty.STAMINA, petTpl.getStamina());

                //宠物一级属性成长=模板值+随机分配值
                if (pet.isPet()) {
                    prop.set(PetAProperty.STRENGTH_GROWTH, petTpl.getStrengthGrowth() + pet.getAddAProp(PetAProperty.STRENGTH_GROWTH));
                    prop.set(PetAProperty.AGILITY_GROWTH, petTpl.getAgilityGrowth() + pet.getAddAProp(PetAProperty.AGILITY_GROWTH));
                    prop.set(PetAProperty.INTELLECT_GROWTH, petTpl.getIntellectGrowth() + pet.getAddAProp(PetAProperty.INTELLECT_GROWTH));
                    prop.set(PetAProperty.FAITH_GROWTH, petTpl.getFaithGrowth() + pet.getAddAProp(PetAProperty.FAITH_GROWTH));
                    prop.set(PetAProperty.STAMINA_GROWTH, petTpl.getStaminaGrowth() + pet.getAddAProp(PetAProperty.STAMINA_GROWTH));
                }
                
                if (pet.isHorse()) {
                	prop.set(PetAProperty.STRENGTH_GROWTH, petTpl.getStrengthGrowth() + pet.getAddAProp(PetAProperty.STRENGTH_GROWTH));
                	prop.set(PetAProperty.AGILITY_GROWTH, petTpl.getAgilityGrowth() + pet.getAddAProp(PetAProperty.AGILITY_GROWTH));
                	prop.set(PetAProperty.INTELLECT_GROWTH, petTpl.getIntellectGrowth() + pet.getAddAProp(PetAProperty.INTELLECT_GROWTH));
                	prop.set(PetAProperty.FAITH_GROWTH, petTpl.getFaithGrowth() + pet.getAddAProp(PetAProperty.FAITH_GROWTH));
                	prop.set(PetAProperty.STAMINA_GROWTH, petTpl.getStaminaGrowth() + pet.getAddAProp(PetAProperty.STAMINA_GROWTH));
                }
                
            }
        }
    };


    /**
     * 装备影响
     */
    public static final PetPropertyEffector<PetAProperty, Pet> EQUIP_EFFECTOR = new PetPropertyEffector<PetAProperty, Pet>() {

        @Override
        public void effect(PetAProperty prop, Pet pet) {
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

            // 套装属性
            createSuitEquipEffect(prop, pet, bag);
        }
    };

    private static void addPropertyOfEquip(PetAProperty targetProp, Item item, Pet pet) {
        if (!(item.getFeature() instanceof EquipFeature)) {
            return;
        }
        EquipFeature feature = (EquipFeature) item.getFeature();

        //装备属性
        Map<Integer, Float> map = Globals.getEquipService().calcEquipWithStarProp(pet, item, PetAProperty.TYPE);
        if (map != null) {
	        for (Entry<Integer, Float> entry : map.entrySet()) {
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
    private static void addPropOfGem(PetAProperty targetProp, Pet pet, EquipFeature feature) {
    	List<EquipHoleInfo> ls = feature.getHoleManager().getHoleList();
    	for (EquipHoleInfo info : ls) {
    		if (info.getGemItemId() > 0 && info.getGemTpl() != null) {
    			if (PetPropTemplate.isValidPropKey(info.getGemTpl().getPropKey(), PropertyType.PET_PROP_A)) {
	    			targetProp.add(info.getGemTpl().getPropKeyIndex(PetAProperty.TYPE), 
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
    private static final void createSuitEquipEffect(PetAProperty prop, Pet pet, PetEquipBag bag) {
//		// 统计套装个数
//		Map<EquipSuitTemplate, Integer> map = new HashMap<EquipSuitTemplate, Integer>();
//		for(Item item : bag.getAllItems()){
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
//						if(triple.getAmend().getPropertyType() == PetAProperty.TYPE){
//							prop.add(triple.getAmend().getProperytIndex(), triple.getValue());
//						}
//					}
//				}
//			}
//		}
    }

    /**
     * 升级后分配点数
     */
    public static final PetPropertyEffector<PetAProperty, Pet> LEVEL_ADD_POINT = new PetPropertyEffector<PetAProperty, Pet>() {

        @Override
        public void effect(PetAProperty prop, Pet pet) {
            prop.clear();

            int gStrength = pet.getAddAProp(PetAProperty.STRENGTH);
            int gAgility = pet.getAddAProp(PetAProperty.AGILITY);
            int gIntellect = pet.getAddAProp(PetAProperty.INTELLECT);
            int gFaith = pet.getAddAProp(PetAProperty.FAITH);
            int gStamina = pet.getAddAProp(PetAProperty.STAMINA);

            prop.set(PetAProperty.STRENGTH, gStrength);
            prop.set(PetAProperty.AGILITY, gAgility);
            prop.set(PetAProperty.INTELLECT, gIntellect);
            prop.set(PetAProperty.FAITH, gFaith);
            prop.set(PetAProperty.STAMINA, gStamina);

        }
    };
    
    /**
     * 宠物成长率相关
     * 提升等级需要更新
     * 凡是对一级属性成长有影响的，也都在这里更新
     */
    public static final PetPropertyEffector<PetAProperty, Pet> GROWTH_EFFECTOR = new PetPropertyEffector<PetAProperty, Pet>() {

        @Override
        public void effect(PetAProperty prop, Pet pet) {
            prop.clear();
            
            if (pet.isPet()) {
	            PetPet pp = (PetPet) pet;
	            
	            float gStrength = MathUtils.doDiv(pp.getItemAddProp(PetAProperty.STRENGTH), Globals.getGameConstants().getScale());
	            float gAgility =  MathUtils.doDiv(pp.getItemAddProp(PetAProperty.AGILITY), Globals.getGameConstants().getScale());
	            float gIntellect =  MathUtils.doDiv(pp.getItemAddProp(PetAProperty.INTELLECT), Globals.getGameConstants().getScale());
	            float gFaith =  MathUtils.doDiv(pp.getItemAddProp(PetAProperty.FAITH), Globals.getGameConstants().getScale());
	            float gStamina =  MathUtils.doDiv(pp.getItemAddProp(PetAProperty.STAMINA), Globals.getGameConstants().getScale());
	            
	            prop.set(PetAProperty.STRENGTH, gStrength);
	            prop.set(PetAProperty.AGILITY, gAgility);
	            prop.set(PetAProperty.INTELLECT, gIntellect);
	            prop.set(PetAProperty.FAITH, gFaith);
	            prop.set(PetAProperty.STAMINA, gStamina);
    		}
    		
    		if (pet.isHorse()) {
    			PetHorse horse = (PetHorse) pet;
    			
	            float gStrength = MathUtils.doDiv(horse.getItemAddProp(PetAProperty.STRENGTH), Globals.getGameConstants().getScale());
	            float gAgility =  MathUtils.doDiv(horse.getItemAddProp(PetAProperty.AGILITY), Globals.getGameConstants().getScale());
	            float gIntellect =  MathUtils.doDiv(horse.getItemAddProp(PetAProperty.INTELLECT), Globals.getGameConstants().getScale());
	            float gFaith =  MathUtils.doDiv(horse.getItemAddProp(PetAProperty.FAITH), Globals.getGameConstants().getScale());
	            float gStamina =  MathUtils.doDiv(horse.getItemAddProp(PetAProperty.STAMINA), Globals.getGameConstants().getScale());
    			
    			prop.set(PetAProperty.STRENGTH, gStrength);
    			prop.set(PetAProperty.AGILITY, gAgility);
    			prop.set(PetAProperty.INTELLECT, gIntellect);
    			prop.set(PetAProperty.FAITH, gFaith);
    			prop.set(PetAProperty.STAMINA, gStamina);
    		}
    		
        }
    };

    /**
     * 培养增加一级属性
     */
    public static final PetPropertyEffector<PetAProperty, Pet> TRAIN_EFFECTOR = new PetPropertyEffector<PetAProperty, Pet>() {

        @Override
        public void effect(PetAProperty prop, Pet pet) {
            prop.clear();

            int gStrength = 0;
            int gAgility = 0;
            int gIntellect = 0;
            int gFaith = 0;
            int gStamina = 0;

            if (pet.isPet()) {
                PetPet pp = (PetPet) pet;
                gStrength = pp.getTrainAddProp(PetAProperty.STRENGTH);
                gAgility = pp.getTrainAddProp(PetAProperty.AGILITY);
                gIntellect = pp.getTrainAddProp(PetAProperty.INTELLECT);
                gFaith = pp.getTrainAddProp(PetAProperty.FAITH);
                gStamina = pp.getTrainAddProp(PetAProperty.STAMINA);
            }
            if(pet.isHorse()){
            	 PetHorse ph = (PetHorse) pet;
                 gStrength = ph.getTrainAddProp(PetAProperty.STRENGTH);
                 gAgility = ph.getTrainAddProp(PetAProperty.AGILITY);
                 gIntellect = ph.getTrainAddProp(PetAProperty.INTELLECT);
                 gFaith = ph.getTrainAddProp(PetAProperty.FAITH);
                 gStamina = ph.getTrainAddProp(PetAProperty.STAMINA);
            }

            prop.set(PetAProperty.STRENGTH, gStrength);
            prop.set(PetAProperty.AGILITY, gAgility);
            prop.set(PetAProperty.INTELLECT, gIntellect);
            prop.set(PetAProperty.FAITH, gFaith);
            prop.set(PetAProperty.STAMINA, gStamina);
        }
    };

//    /**
//     * 宝石影响一级属性
//     */
//    public static final PetPropertyEffector<PetAProperty, Pet> GEM_EFFECTOR = new PetPropertyEffector<PetAProperty, Pet>() {
//
//        @Override
//        public void effect(PetAProperty prop, Pet pet) {
//            prop.clear();
//            PetGemBag bag = pet.getOwner().getInventory().getGemBagByPet(pet.getUUID());
//            if (bag == null) {
//                return;
//            }
//            for (Position p : bag.getPosition()) {
//                for (Item item : bag.getItemsByPosition(p)) {
//                    addPropertyForGem(prop, item, pet, p);
//                }
//            }
//        }
//    };
//
//    private static void addPropertyForGem(PetAProperty targetProp, Item item, Pet pet, Position p) {
//        GemTemplateCache gtc = Globals.getTemplateCacheService().getGemTemplateCache();
//        GemItemTemplate git = gtc.getGitMap().get(item.getTemplateId());
//        if (git == null) {
//            return;
//        }
//        KeyValuePair<Integer, Integer> pair = gtc.getPropKeyAndValue(p, GemType.valueOf(git.getGemTypeId()), git.getGemLevel());
//        if (pair == null) {
//            return;
//        }
//        if (PetPropTemplate.isValidPropKey(pair.getKey(), PropertyType.PET_PROP_A)) {
//            targetProp.add(pair.getKey() - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_A), pair.getValue());
//        }
//    }

    /**
     * 技能影响一级属性
     */
    public static final PetPropertyEffector<PetAProperty, Pet> SKILL_EFFECTOR = new PetPropertyEffector<PetAProperty, Pet>() {

        @Override
        public void effect(PetAProperty prop, Pet pet) {
            prop.clear();
            
            //主将的心法被动技能
            if (pet.isLeader()) {
	            for (Entry<Integer, PetSkillInfo> entry : pet.getSkillMap().entrySet()) {
	                SkillTemplate st = Globals.getTemplateCacheService().get(entry.getKey(), SkillTemplate.class);
	                if (st != null) {
	                    if (st.getSkillType() == SkillType.MIND_B) {
	                        HumanSubPassiveSkillTemplate hspst = Globals.getTemplateCacheService().get(entry.getKey(), HumanSubPassiveSkillTemplate.class);
	                        if (hspst != null && PetPropTemplate.isValidPropKey(hspst.getPropType(), PropertyType.PET_PROP_A) && entry.getValue().getLevel() > 0) {
	                            int value = hspst.getBaseProp() + (entry.getValue().getLevel() - 1) * hspst.getAddProp();
	                            prop.add(hspst.getPropType() - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_A), value);
	                        }
	                    } else if (st.getSkillType() == SkillType.LEADER_STUDY) {
							//TODO 暂时没有被动增加属性的技能，等有了再做
							
						}
	                }
	            }
            } else if (pet.isHorse()){
				//骑宠被动技能 
				petHorsePassvieSkillAdd(pet, prop);
			}
            
            
        }
    };
    
    private static void petHorsePassvieSkillAdd(Pet pet, PetAProperty prop) {
		if (!pet.isHorse()) {
			return;
		}
		
		//骑宠，被动技能，只加一级属性，所以二级属性就不用写了
		Map<Integer, PetSkillInfo> skillMap = pet.getSkillMap();
		for (PetSkillInfo info : skillMap.values()) {
			SkillTemplate st = Globals.getTemplateCacheService().get(info.getSkillId(), SkillTemplate.class);
			//这里只处理被动技能
			if (!st.isPassive()) {
				continue;
			}
			//如果是天赋被动技能
			if (info.isTalent()) {
				PetHorsePassiveTalentSkillTemplate ptsTpl = Globals.getTemplateCacheService().get(info.getSkillId(), PetHorsePassiveTalentSkillTemplate.class);
				//可能有战斗内使用的被动技能，这种没有效果，所以会为null
				if (ptsTpl != null) {
					for (PassiveTalentPropItem item : ptsTpl.getValidPropList()) {
						//增加属性值=基础数值+（等级-1）*每级增加值
						int value = item.getPropValue() + (info.getLevel() - 1) * item.getPropLevelAdd();
						prop.add(item.getPropKeyIndex(PropertyType.PET_PROP_A), value);
					}
				}
			} else {
				//如果是普通被动技能
				PetHorsePassiveNormalSkillTemplate ptsTpl = Globals.getTemplateCacheService().get(info.getSkillId(), PetHorsePassiveNormalSkillTemplate.class);
				//可能有战斗内使用的被动技能，这种没有效果，所以会为null
				if (ptsTpl != null) {
					for (PassiveTalentPropItem item : ptsTpl.getValidPropList()) {
						//增加属性值=基础数值+（等级-1）*每级增加值
						int value = item.getPropValue() + (info.getLevel() - 1) * item.getPropLevelAdd();
						prop.add(item.getPropKeyIndex(PropertyType.PET_PROP_A), value);
					}
				}
			}
		}
	}

    public static final PetPropertyEffector<PetAProperty, Pet> TITLE_EFFECTOR = new PetPropertyEffector<PetAProperty, Pet>() {
        @Override
        public void effect(PetAProperty prop, Pet pet) {
            if (!pet.isLeader()) {
                return;
            }
            prop.clear();
            int tplid = Globals.getTitleService().getCurrentTitle(pet.getOwner().getCharId());
            TitleTemplate template = Globals.getTemplateCacheService().get(tplid,TitleTemplate.class);
            if(template==null){
                return;
            }
            for (EquipItemAttribute entry : template.getValidAddPropList()) {
                if (PetPropTemplate.isValidPropKey(entry.getPropKey(), PropertyType.PET_PROP_A)) {
                    prop.add(entry.getPropKey() - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_A), entry.getPropValue());
                }
            }
        }

    };
    
    /**
     * 骑宠影响一级属性
     */
    public static final PetPropertyEffector<PetAProperty, Pet> HORSE_EFFECTOR = new PetPropertyEffector<PetAProperty, Pet>() {

		@Override
		public void effect(PetAProperty prop, Pet pet) {
			
			prop.clear();
			
			//骑宠目前只影响主将一级属性
			if(!pet.isLeader()){
				return;
			}
			Human human = pet.getOwner();
			UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
			if(offlineData == null ){
				return;
			}
			//休息状态
			if(offlineData.getFightPetHorseId() == 0){
				return;
			}
			
			UserPetHorseData petHorseData = offlineData.getPetHorseData(offlineData.getFightPetHorseId());
			if(petHorseData == null){
				return;
			}
			
			//武将加成一级属性 = 骑宠一级属性 * 系数  * 亲密度加成
			PetHorse ph = (PetHorse) human.getPetManager().getPetByUuid(offlineData.getFightPetHorseId());
			if(ph != null){
				int petHorseCloAdd = Globals.getTemplateCacheService().getPetTemplateCache().getPetHorseCloAdd((int) petHorseData.getClo());
				if(petHorseCloAdd < 0){
					//默认没有加成
					petHorseCloAdd =  Globals.getGameConstants().getScale();
				}
				
				double petHorseAddCoef = petHorseCloAdd == 0 ? Globals.getGameConstants().getPetHorseAddCoef()
						: Globals.getGameConstants().getPetHorseAddCoef() * (((double)petHorseCloAdd) / Globals.getGameConstants().getScale());
				
				prop.add(PetAProperty.STRENGTH,(float)( ph.getPropertyManager().getAProperty(PetAProperty.STRENGTH) * petHorseAddCoef));
				prop.add(PetAProperty.AGILITY,(float)( ph.getPropertyManager().getAProperty(PetAProperty.AGILITY) * petHorseAddCoef));
				prop.add(PetAProperty.INTELLECT,(float)( ph.getPropertyManager().getAProperty(PetAProperty.INTELLECT) * petHorseAddCoef));
				prop.add(PetAProperty.FAITH,(float)( ph.getPropertyManager().getAProperty(PetAProperty.FAITH) * petHorseAddCoef));
				prop.add(PetAProperty.STAMINA,(float)( ph.getPropertyManager().getAProperty(PetAProperty.STAMINA) * petHorseAddCoef));
			}
			
		}
    	
    	
    };
    

}