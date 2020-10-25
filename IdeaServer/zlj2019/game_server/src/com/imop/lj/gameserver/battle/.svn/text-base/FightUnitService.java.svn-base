package com.imop.lj.gameserver.battle;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.amend.IFightUnitAmend;
import com.imop.lj.gameserver.battle.core.FightUnit;
//import com.imop.lj.gameserver.horse.template.HorseTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.PetBattleSnap;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetHorse;
import com.imop.lj.gameserver.pet.helper.PetHelper;
//import com.imop.lj.gameserver.pet.template.BattleTypeTemplate;
//import com.imop.lj.gameserver.pet.template.PetDef.PositionType;
import com.imop.lj.gameserver.pet.template.BattleTypeTemplate;

/**
 * 战斗单位服务
 * 
 */
public class FightUnitService implements InitializeRequired{
	protected List<IFightUnitAmend> amendList = new ArrayList<IFightUnitAmend>();
	
	@Override
	public void init() {
		// --------------------直接累加二级属性-----------------------------
//		// 坐骑修正
//		amendList.add(new HorseFightUnitAmend());
//		// 神将修正
//		amendList.add(new GodHeroFightUnitAmend());
//		// 位置修正
//		amendList.add(new PositionFightUnitAmend());
//		
//		// -------------------累加完二级属性后，可能对二级属性加成------------
//		// 心法修正
//		amendList.add(new MindFightUnitAmend());
	}
	
	/**
	 * 由在线数据创建战斗单位
	 * @param pet
	 * @param battleIndex
	 * @param id
	 * @param battleTypeTemplate
	 * @param isAttacker
	 * @param petHorse
	 * @return
	 */
	public FightUnit createFightUnit(Pet pet, int battleIndex, String id, 
			BattleTypeTemplate battleTypeTemplate, boolean isAttacker, PetHorse petHorse) {
		FightUnit unit = PetHelper.createFightUnit(pet, battleIndex, id, isAttacker, petHorse);
		unit.setUuid(pet.getGUID());
		if(Loggers.battleLogger.isDebugEnabled()){
			Loggers.battleLogger.debug("未加成前数值：" + unit.toString());
		}
		for(IFightUnitAmend amend : amendList){
			amend.onlineAmend(unit, pet, battleIndex, id, battleTypeTemplate, isAttacker);
			if(Loggers.battleLogger.isDebugEnabled()){
				Loggers.battleLogger.debug(amend.getClass().getSimpleName()+ " 修正后数值： " + unit.toString());
			}
		}
		return unit;
	}

	/**
	 * 由离线数据创建战斗单位
	 * @param userSnap
	 * @param petSnap
	 * @param battleIndex
	 * @param id
	 * @param battleTypeTemplate
	 * @param isAttacker
	 * @param petHorse
	 * @return
	 */
	public FightUnit createFightUnitByPetSnap(UserSnap userSnap, PetBattleSnap petSnap, 
			int battleIndex, String id, BattleTypeTemplate battleTypeTemplate, boolean isAttacker, PetBattleSnap petHorse) {
		FightUnit unit = PetHelper.createFightUnitByPetSnap(userSnap, petSnap, battleIndex, id, isAttacker, petHorse);
		unit.setUuid(petSnap.getGUID());
		if(Loggers.battleLogger.isDebugEnabled()){
			Loggers.battleLogger.debug("未加成前数值：" + unit.toString());
		}
		for(IFightUnitAmend amend : amendList){
			amend.offlineAmend(unit, userSnap, petSnap, battleIndex, id, battleTypeTemplate, isAttacker);
			if(Loggers.battleLogger.isDebugEnabled()){
				Loggers.battleLogger.debug(amend.getClass().getSimpleName() + " 修正后数值： " + unit.toString());
			}
		}
		
		return unit;
	}
	
	/**
	 * 由在线数据创建坐骑战斗单位
	 * 
	 * @param human
	 * @param isAttacker
	 * @return
	 */
	public FightUnit createHorseFightUnit(Human human, boolean horseBattle, boolean isAttacker, FightUnit leader){
		//FIXME
		return null;
//		if(!horseBattle){
//			return null;
//		}
//		
//		if(leader == null){
//			return null;
//		}
//		
//		if(!human.getHorseManager().getHorse().isHorseOpen()){
//			return null;
//		}
//		
//		if(!human.getHorseManager().getHorse().isHorseRiding()){
//			return null;
//		}
//		
//		FightUnit horse = leader.clone();
//		
//		horse.setUuid(human.getHorseManager().getHorse().getGUID());
//		horse.setUnitType(PetType.HORSE);
//		horse.setPosition(PositionType.NULL);
//		horse.setIndex(0);
//		HorseTemplate ht = human.getHorseManager().getHorse().getHorseTemplate();
//		horse.setLevel(human.getHorseManager().getHorse().getLevel());
//		horse.setName(ht.getName());
//		horse.setId(isAttacker ? "ah" : "dh");
//		horse.setTemplateId(ht.getId());
//		horse.setAnger(100);
//		if(human.getHorseManager().getHorse().getRidingHorseTemplate() != null){
//			horse.setModel(human.getHorseManager().getHorse().getRidingHorseTemplate().getPhoto());
//		}else{
//			horse.setModel(ht.getPhoto());
//		}
//		
//		
//		horse.setBattleSkillManager(HorseBattleSkillManager.createHorseSkillManager(human.getHorseManager(), horse));
//		if(Loggers.battleLogger.isDebugEnabled()){
//			Loggers.battleLogger.debug("坐骑 : " + horse.toString());
//		}
//		
//		UserSnap snap = Globals.getOfflineDataService().getUserSnap(human.getUUID());
//		if(snap != null){
//			horse.setPropMap(this.createHorseProps(snap));
//		}
//		return horse;
	}
	
	/**
	 * 由离线数据创建坐骑战斗单位
	 * 
	 * @param snap
	 * @param isAttacker
	 * @return
	 */
	public FightUnit createHorseFightUnitByUserSnap(UserSnap snap, boolean horseBattle, boolean isAttacker, FightUnit leader){
		//FIXME
		return null;
		
//		if(!horseBattle){
//			return null;
//		}
//		
//		if(leader == null){
//			return null;
//		}
//		
//		if(!snap.getHorseSnap().isHorseOpen()){
//			return null;
//		}
//		
//		if(!snap.getHorseSnap().isHorseRiding()){
//			return null;
//		}
//		
//		FightUnit horse = leader.clone();
//		
//		horse.setUuid(snap.getHorseSnap().getGUID());
//		horse.setUnitType(PetType.HORSE);
//		horse.setPosition(PositionType.NULL);
//		horse.setIndex(0);
//		HorseTemplate ht = snap.getHorseSnap().getCurrStepHorseTemplate();
//		horse.setLevel(snap.getHorseSnap().getStarLevel());
//		if(ht != null){
//			horse.setName(ht.getName());
//			horse.setModel(ht.getPhoto());
//		}
//		
//		horse.setTemplateId(ht.getId());
//		horse.setId(isAttacker ? "ah" : "dh");
//		horse.setAnger(100);
//		if(snap.getHorseSnap().getRidingHorseTemplate() != null){
//			horse.setModel(snap.getHorseSnap().getRidingHorseTemplate().getPhoto());
//		}else{
//			horse.setModel(ht.getPhoto());
//		}
//		
//		horse.setBattleSkillManager(HorseBattleSkillManager.createHorseSkillManagerForOffline(snap, horse));
//		if(Loggers.battleLogger.isDebugEnabled()){
//			Loggers.battleLogger.debug("坐骑 : " + horse.toString());
//		}
//		
//		horse.setPropMap(this.createHorseProps(snap));
//		return horse;
	}
	
	public Map<Integer, Object> createHorseProps(UserSnap userSnap){
		//FIXME
		return null;
//		Map<Integer, Object> map = new HashMap<Integer, Object>();
//		List<KeyValuePair<Integer, Integer>> intProps = Globals.getSeeOtherService().createHorseIntProps(userSnap);
//		
//		for(KeyValuePair<Integer, Integer> kv : intProps){
//			map.put(kv.getKey(), kv.getValue());
//		}
//		
//		return map;
	}
}
