package com.imop.lj.gameserver.battle.convertor;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.common.Globals;
//import com.imop.lj.gameserver.formation.FormationDef.FormationPositionType;
//import com.imop.lj.gameserver.formation.FormationManager;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetHorse;
//import com.imop.lj.gameserver.pet.template.BattleTypeTemplate;
import com.imop.lj.gameserver.pet.template.BattleTypeTemplate;

/**
 * 根据布阵创建玩家战队信息，玩家必须在线
 * 
 */
public class FormationConvertor extends UnitConvertor {
	
	@Override
	public List<FightUnit> convert(Object param, boolean isAttacker, BattleType type) {
		if (param == null || !(param instanceof Human)) {
			Loggers.battleLogger.error("FormationConvertor : human does not exist!!!");
			return null;
		}
		List<FightUnit> list = new ArrayList<FightUnit>();
		
		//当前角色
		Human human = (Human)param;
		BattleTypeTemplate battleTypeTpl = Globals.getTemplateCacheService().get(type.getIndex(), BattleTypeTemplate.class);
		boolean isAutoSelSkill = type.isAutoSelSkill();
		
		int leaderPos = BattleDef.LEADER_POS_DEFAULT;
		int petPos = BattleDef.PET_POS_DEFAULT;
		
		//骑宠
		PetHorse petHorse = null;
		
		//主将
		Pet leader = human.getPetManager().getLeader();
		String id = genFighterId(leaderPos, isAttacker);
		petHorse = Globals.getPetService().getFightPetHorse(human);
		FightUnit unit = Globals.getFightUnitService().createFightUnit(leader, leaderPos, id, battleTypeTpl, isAttacker, petHorse);
		unit.setAutoSelSkill(isAutoSelSkill);
		list.add(unit);
		leaderPos++;
		
		//宠物
		Pet pet = Globals.getPetService().getFightPet(human);
		if (pet != null) {
			String petId = genFighterId(petPos, isAttacker);
			petHorse = Globals.getPetService().getSoulPetHorseByPetId(human, pet.getUUID());
			FightUnit petUnit = Globals.getFightUnitService().createFightUnit(pet, petPos, petId, battleTypeTpl, isAttacker, petHorse);
			petUnit.setAutoSelSkill(isAutoSelSkill);
			list.add(petUnit);
		}
		
//		//伙伴
//		int level = human.getLevel();
//		PetFriendArray arr = Globals.getPetService().getCurFriendArray(human.getCharId());
//		if (arr != null) {
//			for (int i = 0; i < arr.getArr().length; i++) {
//				int friendTplId = arr.getArr()[i];
//				if (friendTplId > 0) {
//					PetTemplate friendTpl = Globals.getTemplateCacheService().get(friendTplId, PetTemplate.class);
//					String fid = genFighterId(leaderPos, isAttacker);
//					FightUnit friendFU = FightUnitHelper.toFightUnit(fid, leaderPos, friendTpl, level);
//					leaderPos++;
//					list.add(friendFU);
//				}
//			}
//		}
		
		return list;
	}
	
	@Override
	public FighterType getType() {
		return FighterType.FORMATION;
	}
	
	@Override
	public List<IEffect> getEffects(Object param, boolean paramBoolean) {
		return new ArrayList<IEffect>();
	}

}
