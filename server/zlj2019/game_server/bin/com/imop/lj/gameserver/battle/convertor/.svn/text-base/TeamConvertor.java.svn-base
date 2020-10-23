package com.imop.lj.gameserver.battle.convertor;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.PetBattleSnap;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetHorse;
import com.imop.lj.gameserver.pet.template.BattleTypeTemplate;
import com.imop.lj.gameserver.team.TeamDef.MemberStatus;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;

/**
 * 根据队伍创建玩家战队信息
 * 
 */
public class TeamConvertor extends UnitConvertor {
	
	@Override
	public List<FightUnit> convert(Object param, boolean isAttacker, BattleType type) {
		if (!(param instanceof Team)) {
			return null;
		}
		
		List<FightUnit> list = new ArrayList<FightUnit>();
		BattleTypeTemplate battleTypeTpl = Globals.getTemplateCacheService().get(type.getIndex(), BattleTypeTemplate.class);
		
		int leaderPos = BattleDef.LEADER_POS_DEFAULT;
		int petPos = BattleDef.PET_POS_DEFAULT;
		
		Team team = (Team) param;
		for (TeamMember tm : team.getMemberList()) {
			//非正常状态的队员，不能参战
			if (tm.getStatus() != MemberStatus.NORMAL) {
				continue;
			}
			
			petPos = leaderPos + 5;//宠物要站在对应的主将前面
			long roleId = tm.getRoleId();
			if (Globals.getTeamService().isOnlineNow(tm)) {
				//在线，按照human来创建
				Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
				
				//骑宠
				PetHorse petHorse = null;
				
				//主将
				Pet leader = human.getPetManager().getLeader();
				String id = genFighterId(leaderPos, isAttacker);
				petHorse = Globals.getPetService().getFightPetHorse(human);
				FightUnit unit = Globals.getFightUnitService().createFightUnit(leader, leaderPos, id, battleTypeTpl, isAttacker, petHorse);
				list.add(unit);
				
				//宠物
				Pet pet = Globals.getPetService().getFightPet(human);
				if (pet != null) {
					String petId = genFighterId(petPos, isAttacker);
					petHorse = Globals.getPetService().getSoulPetHorseByPetId(human, pet.getUUID());
					FightUnit petUnit = Globals.getFightUnitService().createFightUnit(pet, petPos, petId, battleTypeTpl, isAttacker, petHorse);
					list.add(petUnit);
				}
			} else {
				//离线，按照userSnap来创建
				UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(roleId);
				//骑宠
				long petHorseId = 0L; 
				PetBattleSnap petHorse = null;
				
				//主将
				PetBattleSnap leader = userSnap.getPsManager().getLeader();
				String id = genFighterId(leaderPos, isAttacker);
				petHorseId = Globals.getPetService().getFightPetHorseId(roleId);
				petHorse = userSnap.getPsManager().getPetById(petHorseId);
				FightUnit unit = Globals.getFightUnitService().createFightUnitByPetSnap(userSnap, leader, leaderPos, id, battleTypeTpl, isAttacker, petHorse);
				list.add(unit);
				
				//宠物
				long fightPetId = Globals.getPetService().getFightPetId(roleId);
				PetBattleSnap pet = userSnap.getPsManager().getPetById(fightPetId);
				if (pet != null) {
					String petId = genFighterId(petPos, isAttacker);
					petHorseId =  Globals.getPetService().getSoulPetHorseByPetId(roleId, pet.getPetId());
					petHorse = userSnap.getPsManager().getPetById(petHorseId);
					FightUnit petUnit = Globals.getFightUnitService().createFightUnitByPetSnap(userSnap, pet, petPos, petId, battleTypeTpl, isAttacker, petHorse);
					list.add(petUnit);
				}
			}
			//主将位置+1
			leaderPos++;
		}

//		//是否排除伙伴，不排除，则上阵
//		if (!type.isExceptFriend()) {
//			//伙伴，如果队伍人数不足5人，则用主将的伙伴顶
//			int lackNum = TeamDef.MAX_TEAM_MEMBER_NUM - (leaderPos - 1);
//			if (lackNum > 0) {
//				long leaderRoleId = team.getLeader().getRoleId();
//				int leaderLevel = team.getLeader().getLevel();
//				PetFriendArray arr = Globals.getPetService().getCurFriendArray(leaderRoleId);
//				if (arr != null) {
//					for (int i = 0; i < arr.getArr().length; i++) {
//						int friendTplId = arr.getArr()[i];
//						if (friendTplId > 0) {
//							PetTemplate friendTpl = Globals.getTemplateCacheService().get(friendTplId, PetTemplate.class);
//							String fid = genFighterId(leaderPos, isAttacker);
//							FightUnit friendFU = FightUnitHelper.toFightUnit(fid, leaderPos++, friendTpl, leaderLevel);
//							list.add(friendFU);
//							
//							lackNum--;
//							if (lackNum <= 0) {
//								//增加到队伍人数上限就退出
//								break;
//							}
//						}
//					}
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
