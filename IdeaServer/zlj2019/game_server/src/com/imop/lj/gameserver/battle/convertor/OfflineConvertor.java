package com.imop.lj.gameserver.battle.convertor;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.offlinedata.PetBattleSnap;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.pet.template.BattleTypeTemplate;

/**
 * 根据玩家离线数据创建玩家战队信息，玩家不需要在线
 * 
 */
public class OfflineConvertor extends UnitConvertor {
	
	@Override
	public List<FightUnit> convert(Object param, boolean isAttacker, BattleType type) {
		long playerId = (Long) param;

		// 玩家离线数据
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(playerId);
		if (userSnap == null) {
			Loggers.battleLogger.error("OfflineConvertor : playerId = " + playerId + "does not exist!!!");
			return null;
		}

		List<FightUnit> list = new ArrayList<FightUnit>();
		
		//当前角色
		BattleTypeTemplate battleTypeTpl = Globals.getTemplateCacheService().get(type.getIndex(), BattleTypeTemplate.class);
		
		boolean isAutoSelSkill = type.isAutoSelSkill();
		
		int leaderPos = BattleDef.LEADER_POS_DEFAULT;
		int petPos = BattleDef.PET_POS_DEFAULT;
		
		//骑宠
		long petHorseId = 0L; 
		PetBattleSnap petHorse = null;
		
		//主将
		PetBattleSnap leader = userSnap.getPsManager().getLeader();
		String id = genFighterId(leaderPos, isAttacker);
		petHorseId = Globals.getPetService().getFightPetHorseId(playerId);
		petHorse = userSnap.getPsManager().getPetById(petHorseId);
		FightUnit unit = Globals.getFightUnitService().createFightUnitByPetSnap(userSnap, leader, leaderPos, id, battleTypeTpl, isAttacker, petHorse);
		unit.setAutoSelSkill(isAutoSelSkill);
		list.add(unit);
		leaderPos++;
		
		//宠物
		long fightPetId = Globals.getPetService().getFightPetId(playerId);
		PetBattleSnap pet = userSnap.getPsManager().getPetById(fightPetId);
		if (pet != null) {
			String petId = genFighterId(petPos, isAttacker);
			petHorseId =  Globals.getPetService().getSoulPetHorseByPetId(playerId, pet.getPetId());
			petHorse = userSnap.getPsManager().getPetById(petHorseId);
			FightUnit petUnit = Globals.getFightUnitService().createFightUnitByPetSnap(userSnap, pet, petPos, petId, battleTypeTpl, isAttacker, petHorse);
			petUnit.setAutoSelSkill(isAutoSelSkill);
			list.add(petUnit);
		}
		
//		//伙伴
//		int level = userSnap.getLevel();
//		PetFriendArray arr = Globals.getPetService().getCurFriendArray(userSnap.getCharId());
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
		return FighterType.OFFLINE;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<IEffect> getEffects(Object param, boolean paramBoolean) {
		return Collections.EMPTY_LIST;
	}

}
