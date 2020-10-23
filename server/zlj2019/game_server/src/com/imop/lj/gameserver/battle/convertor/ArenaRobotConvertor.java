package com.imop.lj.gameserver.battle.convertor;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.arena.model.ArenaOpponent;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.FightUnitHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyTemplate;
import com.imop.lj.gameserver.pet.PetDef.PetType;

/**
 * 竞技场机器人
 * 
 */
public class ArenaRobotConvertor extends UnitConvertor {
	
	@Override
	public List<FightUnit> convert(Object param, boolean isAttacker, BattleType type) {
		if (param == null || !(param instanceof ArenaOpponent)) {
			Loggers.battleLogger.error("ArenaRobotConvertor : ArenaOpponent does not exist!!!");
			return null;
		}
		
		ArenaOpponent targetOp = (ArenaOpponent) param;
		long roleId = targetOp.getOwnerId();
		int level = Globals.getOfflineDataService().getUserLevel(roleId);
		
		int leaderTplId = targetOp.getTplId();
//		PetTemplate leaderTpl = Globals.getTemplateCacheService().get(leaderTplId, PetTemplate.class);
		EnemyTemplate leaderTpl = Globals.getTemplateCacheService().get(leaderTplId, EnemyTemplate.class);
		int petTplId = Globals.getGameConstants().getArenaRobotPetId();
//		PetTemplate petTpl = Globals.getTemplateCacheService().get(petTplId, PetTemplate.class);
		EnemyTemplate petTpl = Globals.getTemplateCacheService().get(petTplId, EnemyTemplate.class);
		
		List<FightUnit> list = new ArrayList<FightUnit>();
		
		//机器人所有的战斗单元全都是伙伴类型，因为释放技能使用的是伙伴的策率
		PetType petType = PetType.FRIEND;
		
		int leaderPos = BattleDef.LEADER_POS_DEFAULT;
		int petPos = BattleDef.PET_POS_DEFAULT;
		
		//主将
		String id = genFighterId(leaderPos, isAttacker);
		FightUnit unit = FightUnitHelper.toFightUnit(id, leaderPos, leaderTpl, level, targetOp.getName());
		unit.setUnitType(petType);
		unit.setRobot(true);
		list.add(unit);
		leaderPos++;
		
		//宠物
		String petId = genFighterId(petPos, isAttacker);
		FightUnit petUnit = FightUnitHelper.toFightUnit(petId, petPos, petTpl, level);
		petUnit.setUnitType(petType);
		petUnit.setRobot(true);
		list.add(petUnit);
		
//		//伙伴
//		PetFriendArray arr = new PetFriendArray();
//		int[] fArr = { Globals.getGameConstants().getArenaRobotFriendId1(),
//				Globals.getGameConstants().getArenaRobotFriendId2(),
//				Globals.getGameConstants().getArenaRobotFriendId3(),
//				Globals.getGameConstants().getArenaRobotFriendId4() };
//		arr.setArr(fArr);
//		for (int i = 0; i < arr.getArr().length; i++) {
//			int friendTplId = arr.getArr()[i];
//			if (friendTplId > 0) {
//				PetTemplate friendTpl = Globals.getTemplateCacheService().get(friendTplId, PetTemplate.class);
//				String fid = genFighterId(leaderPos, isAttacker);
//				FightUnit friendFU = FightUnitHelper.toFightUnit(fid, leaderPos, friendTpl, level);
//				friendFU.setUnitType(petType);
//				friendFU.setRobot(true);
//				leaderPos++;
//				list.add(friendFU);
//			}
//		}
		
		return list;
	}
	
	@Override
	public FighterType getType() {
		return FighterType.ARENA_ROBOT;
	}
	
	@Override
	public List<IEffect> getEffects(Object param, boolean paramBoolean) {
		return new ArrayList<IEffect>();
	}

}
