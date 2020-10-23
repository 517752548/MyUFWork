package com.imop.lj.gameserver.battle;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Lists;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.PetLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.BattleCreateException;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.arena.template.ArenaLeaderSkillWeightTemplate;
import com.imop.lj.gameserver.arena.template.ArenaPetSkillWeightTemplate;
import com.imop.lj.gameserver.arena.template.IArenaSkillWeightTpl;
import com.imop.lj.gameserver.battle.convertor.UnitConvertor;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.BattleDef.ReportMsgType;
import com.imop.lj.gameserver.battle.core.BattleDef.SkillCostType;
import com.imop.lj.gameserver.battle.core.BattleDef.TargetType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.battle.core.IBattle;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.msg.GCBattleEnd;
import com.imop.lj.gameserver.battle.msg.GCBattleForceEnd;
import com.imop.lj.gameserver.battle.msg.GCBattleSpeedup;
import com.imop.lj.gameserver.battle.report.BattleReportAddition;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.EnemyParamContent;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.FightDrugsType;
import com.imop.lj.gameserver.item.ItemDef.PoolAddType;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.map.template.MapMeetMonsterTemplate;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserPetData;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.PetFightState;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.PetMessageBuilder;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.pet.helper.PetHelper;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.IRewardAmend;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.amend.DoublePointRewardAmend;
import com.imop.lj.gameserver.skill.template.SkillEffectTemplate;
import com.imop.lj.gameserver.skill.template.SkillTemplate;
import com.imop.lj.gameserver.task.ITaskOwner;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.task.TaskDef.NumRecordType;
import com.imop.lj.gameserver.task.TaskListener;
import com.imop.lj.gameserver.team.TeamDef;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.tower.TowerMsgBuilder;
import com.imop.lj.gameserver.tower.template.TowerRewardTemplate;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

/**
 * 战斗服务
 * 
 */
public class BattleService {

	/** 战斗对象内存数据，保存当前正在进行的战斗key是battleId */
	protected Map<Integer, BattleProcess> battleMap = new LinkedHashMap<Integer, BattleProcess>();
	
	public BattleService() {
		
	}
	
	//TODO 考虑是否将战斗放入IO线程进行，如果放入IO线程，则可能需要在doIO结束后，发消息给场景线程，然后进行战斗结束的相关处理
	//TODO 找合适的时候做一下性能测试，再决定是否放IO线程中做
	//TODO 现在战斗中会直接调用扣道具（嗑药），召唤宠物，如果再放入IO线程，需要改动一些东西
	
	
	protected void addBattle(BattleProcess bp) {
		this.battleMap.put(bp.getBattleId(), bp);
	}
	
	protected BattleProcess getBattle(int battleId) {
		return battleMap.get(battleId);
	}
	
	protected void removeBattle(int battleId) {
		if (battleMap.containsKey(battleId)) {
			battleMap.remove(battleId);
		}
	}
	
//	protected int testCount = 0;
	public void testBattle(Human human) {
		
//		Globals.getPetService().onCatchPet(human, 1004);
		
		if (!human.isInBattle()) {
			//test
//			human.setRunningMainSkillType(MainSkillType.JIANREN);
			
			int enemyArmyId = 13;
			EnemyParamContent epc = new EnemyParamContent(enemyArmyId, 1, 1,1, false);
			Fighter<?> attacker = new Fighter<Human>(FighterType.FORMATION, human, true);
			Fighter<?> defender = Fighter.valueOf(FighterType.ENEMY, epc, false);
			startPVEBattle(human, BattleType.SINGLE, attacker, defender, null);
		} else {
			int skillId = 33333;
			int selTarget = 0;
			boolean isAuto = false;
//			testCount++;
//			if (testCount > 10) {
//				skillId = 0;
//				selTarget = 0;
//				isAuto = true;
//			}

//			long summonPetId = 288516249174934508L;
//			long summonPetId = 288516249174936512L;
			
			requestPVEBattleRound(human, isAuto, skillId, selTarget, 0, 1, 0, 0, 0);
		}
	}
	
	/**
	 * 按照地图获取随机到的怪物
	 * @param human
	 */
	public void meetMapMonsterBattle(Human human) {
		//根据地图随机怪物
		int enemyArmyId = getMeetEnemyArmyId(human.getMapId());
		if (enemyArmyId <= 0) {
			Loggers.battleLogger.error("meetMapMonsterBattle enemyArmyId is invalid!" + human.getCharId());
			return;
		}
		
		startBattle(human,enemyArmyId, human.getMapId(), false);
	}		
	
	protected void startBattle(Human human,int enemyArmyId, int mapId, boolean isCorpsBoss){
		EnemyParamContent epc = null;
		int sum = 0;
		long roleId = human.getCharId();
		if (Globals.getTeamService().canTriggerSingleBattle(roleId)) {
			//主将+伙伴的个数
			sum = 1; //+ Globals.getPetService().getCurArrFriendNum(roleId);
			epc = new EnemyParamContent(enemyArmyId, sum, human.getLevel(), mapId, false);
			
			Fighter<?> attacker = new Fighter<Human>(FighterType.FORMATION, human, true);
			Fighter<?> defender = Fighter.valueOf(FighterType.ENEMY, epc, false);
			//开始单人战斗
			startPVEBattle(human, BattleType.SINGLE, attacker, defender, null);
		} else if (Globals.getTeamService().canTriggerTeamBattle(roleId)) {
			Team team = Globals.getTeamService().getHumanTeam(roleId);
			sum = Globals.getTeamService().getMemberNumOfNormal(team.getId());
//			//加上队长的伙伴的数量
//			sum += Globals.getPetService().getCurArrFriendNum(roleId);
			if (sum > TeamDef.MAX_TEAM_MEMBER_NUM) {
				sum = TeamDef.MAX_TEAM_MEMBER_NUM;
			}
			//用队伍的平均等级
			epc = new EnemyParamContent(enemyArmyId, sum, team.getAvgLevel(), team.getMapId(), isCorpsBoss);
			
			Fighter<?> attacker = new Fighter<Team>(FighterType.TEAM, team, true);
			Fighter<?> defender = Fighter.valueOf(FighterType.ENEMY, epc, false);
			//开始组队战斗
			Globals.getTeamService().getTeamBattleLogic().startTeamPVEBattle(human, team, BattleType.TEAM, attacker, defender, null);
		} else {
			Loggers.battleLogger.error("meetMapMonsterBattle can not trigger fight!" + human.getCharId());
			return;
		}
	}
	
	protected int getMeetEnemyArmyId(int mapId) {
		MapTemplate mapTpl = Globals.getTemplateCacheService().get(mapId, MapTemplate.class);
		if (mapTpl == null || mapTpl.getMeetMonsterPlanId() <= 0) {
			return 0;
		}
		
		int planId = mapTpl.getMeetMonsterPlanId();
		MapMeetMonsterTemplate hitTpl = RandomUtils.hitObject(Globals.getTemplateCacheService().getMapTemplateCache().getMeetMonsterPlanProb(planId), 
				Globals.getTemplateCacheService().getMapTemplateCache().getMeetMonsterPlan(planId), 
				Globals.getGameConstants().getRandomBase());
		if (hitTpl == null) {
			Loggers.battleLogger.error("meetMonster hitTpl is null!mapId=" + mapId);
			return 0;
		}
		return hitTpl.getEnemyArmyId();
	}
	
	public int startPVEBattle(Human human, BattleType type, Fighter<?> attacker, Fighter<?> defender, Object param) {
		// 正在战斗，不允许发生另一次战斗
		if (human.isInAnyBattle()) {
			Loggers.battleLogger.error("human is in battle now!humanId=" + 
					human.getCharId() + ";battleId=" + human.getLastBattleId());
			return 0;
		}
		
		try {
			//构建战斗过程对象
			BattleProcess bp = new BattleProcess(human.getCharId(), type, attacker, defender);
			//设置额外参数
			if (param != null) {
				bp.setParam(param);
			}
			
			human.onStartBattle(bp.getBattleId());
			addBattle(bp);
			
			//开始战斗
			String startReport = bp.start();
			if (startReport == null) {
				Loggers.battleLogger.error("startReport is null!humanId=" + human.getCharId() + 
						";lastBattleTime=" + human.getLastBattleTime());
				return 0;
			}
			
			//第一次战斗的新手引导
			Globals.getGuideService().onStartPveBattle(human);
			
			//发战斗开始的消息
			Globals.getBattleReportService().sendBattlePartReport(human, ReportMsgType.START, startReport, bp.buildAdditionPack());
			//通知附近玩家，进入战斗
			Globals.getMapService().noticeNearMapInfoChanged(human);
			return bp.getBattleId();
		} catch (BattleCreateException e) {
			e.printStackTrace();
			Loggers.battleLogger.error("pve battle Exception!", e);
		}
		return 0;
	}
	
	/**
	 * 按照藏宝图地图获取随机到的怪物
	 * @param human
	 */
	public void meetTreasureMapMonsterBattle(Human human,int enemyArmyId) {
		//根据地图随机怪物
		if (enemyArmyId <= 0) {
			Loggers.battleLogger.error("meetMapMonsterBattle enemyArmyId is invalid!" + human.getCharId());
			return;
		}
		
		startBattle(human,enemyArmyId, 0, true);
	}
	
	/**
	 * 请求PVE战斗的下一轮战报
	 * @param human
	 * @param isAuto
	 * @param selSkillId
	 * @param selTarget
	 */
	public void requestPVEBattleRound(Human human, boolean isAuto, 
			int selSkillId, int selTarget, int selItemId, 
			int petSelSkillId, int petSelTarget, int petSelItemId, long summonPetId) {
		//玩家是否在战斗中
		int battleId = human.getLastBattleId();
		if (battleId <= 0) {
			Loggers.battleLogger.warn("invalid request!human not in battle now!humanId=" + human.getCharId());
			return;
		}
		
		//战斗对象是否存在
		BattleProcess bp = getBattle(battleId);
		if (bp == null) {
			human.setLastBattleId(0);
			
			Loggers.battleLogger.error("battle not exist!humanId=" + human.getCharId() + 
					";battleId=" + battleId + ";lastBattleTime=" + human.getLastBattleTime());
			return;
		}
		
		//战斗是否已结束
		boolean isEnd = bp.isBattleEnd();
		if (isEnd) {
			human.setLastBattleId(0);
			removeBattle(battleId);
			
			Loggers.battleLogger.error("battle is end!humanId=" + human.getCharId() + 
					";battleId=" + battleId + ";lastBattleTime=" + human.getLastBattleTime());
			return;
		}
		
		//设置手动战斗的参数
		if (!isAuto) {
			onChooseSkill(human, bp, true, selSkillId, selTarget, selItemId, 
					petSelSkillId, petSelTarget, petSelItemId, summonPetId);
		} else {
			//用自动战斗的数据更新本轮技能
			FightUnit leaderFu = bp.getAttackerFULive(true, human.getCharId());
			if (leaderFu != null) {
				leaderFu.setSelSkillId(human.getAutoFightAction());
				leaderFu.setSelTarget(0);
			}
			
			FightUnit petFu = bp.getAttackerFULive(false, human.getCharId());
			if (petFu != null) {
				petFu.setSelSkillId(human.getPetAutoFightAction());
				petFu.setSelTarget(0);
			}
		}
		
		//进行一轮战斗
		String roundReport = bp.round();
		if (roundReport == null) {
			Loggers.battleLogger.error("battle round error!humanId=" + human.getCharId() + 
					";battleId=" + battleId + ";lastBattleTime=" + human.getLastBattleTime());
		}
		
		if (bp.isBattleEnd()) {
//			battleEndProcess(human, bp);
		}
		
		//给玩家发该轮战报的消息并修改human属性
		human.snapChangedProperty(true);
		Globals.getBattleReportService().sendBattlePartReport(human, ReportMsgType.ROUND, roundReport, "");
	}
	
	/**
	 * 玩家选技能时的校验，以及更新自动技能
	 * @param human
	 * @param bp
	 * @param selSkillId
	 * @param selTarget
	 * @param petSelSkillId
	 * @param petSelTarget
	 */
	public void onChooseSkill(Human human, BattleProcess bp, boolean isAttacker,
			int selSkillId, int selTarget, int selItemId, 
			int petSelSkillId, int petSelTarget, int petSelItemId, long summonPetId) {
		//主将
		updateFighterSel(human, bp, isAttacker, true, selSkillId, selTarget, selItemId, summonPetId);
		//宠物
		updateFighterSel(human, bp, isAttacker, false, petSelSkillId, petSelTarget, petSelItemId, 0);
		//更新自动战斗参数
		genAutoSkill(human, selSkillId, petSelSkillId, bp, isAttacker);
	}
	
	/**
	 * 玩家选择更换自动技能
	 * @param human
	 * @param petTypeId
	 * @param selSkillId
	 */
	public void changeAutoAction(Human human, int petTypeId, int selSkillId) {
		PetType petType = PetType.valueOf(petTypeId);
		if (petType == null || (petType != PetType.LEADER && petType != PetType.PET)) {
			return;
		}
		if (petType == PetType.LEADER) {
			updateLeaderAutoSkillId(human, selSkillId);
		} else if (petType == PetType.PET) {
			updatePetAutoSkillId(human, selSkillId);
		}
		
		//玩家可能正在进行某种战斗，需要更新战斗中的自动技能数据
		long roleId = human.getCharId();
		if (Globals.getTeamService().isInTeamBattle(roleId)) {
			//组队pvp中
			if (Globals.getTeamPvpService().isInTeamPvpBattle(roleId)) {
				Globals.getTeamPvpService().onUpdateAutoAction(human);
			} else {
				//组队pve中
				Globals.getTeamService().getTeamBattleLogic().onUpdateAutoAction(human);
			}
		} else if (Globals.getPvpService().isPlayerInPvp(roleId)) {
			Globals.getPvpService().onUpdateAutoAction(human);
		}
	}
	
	/**
	 * 更新自动技能
	 * @param human
	 * @param selSkillId
	 * @param petSelSkillId
	 * @param bp
	 */
	protected void genAutoSkill(Human human, int selSkillId, int petSelSkillId, 
			BattleProcess bp, boolean isAttacker) {
		boolean flag = false;
		long ownerId = human.getCharId();
		FightUnit setFu = isAttacker ? bp.getAttackerFULive(true, ownerId) : bp.getDefenderFULive(true, ownerId);
		if (setFu != null) {
			boolean lFlag = updateLeaderAutoSkillId(human, selSkillId);
			if (lFlag) {
				setFu.setSelSkillId(human.getAutoFightAction());
			}
			flag |= lFlag;
		}
		
		// 宠物
		FightUnit setPetFu = isAttacker ? bp.getAttackerFULive(false, ownerId) : bp.getDefenderFULive(false, ownerId);
		if (setPetFu != null) {
			boolean pFlag = updatePetAutoSkillId(human, petSelSkillId);
			if (pFlag) {
				setPetFu.setSelSkillId(human.getPetAutoFightAction());
			}
			flag |= pFlag;
		}
		
		//如果有变化，则更新离线数据
		if (flag) {
			Globals.getOfflineDataService().onBaseInfoChange(human);
		}
	}
	
	protected boolean updateLeaderAutoSkillId(Human human, int selSkillId) {
		boolean flag = false;
		int defaultSkillId = BattleDef.NORMAL_ATTACK_SKILL_ID;
		//捕捉、逃跑、嗑药、召唤技能，不能作为自动攻击技能
		if (isSkillCanAuto(selSkillId)) {
			int cur = human.getAutoFightAction();
			if (human.getPetManager().getLeader() != null && 
					!human.getPetManager().getLeader().getSkillList().isEmpty() && 
					human.getPetManager().getLeader().getSkillMap().containsKey(selSkillId)) {
				human.setAutoFightAction(selSkillId);
			} else {
				human.setAutoFightAction(selSkillId == BattleDef.DEFENCE_SKILL_ID ? selSkillId : defaultSkillId);
			}
			//通知前台
			human.snapChangedProperty(true);
			flag = cur != human.getAutoFightAction();
		}
		return flag;
	}
	
	protected boolean updatePetAutoSkillId(Human human, int petSelSkillId) {
		boolean flag = false;
		int cur = human.getAutoFightAction();
		int defaultSkillId = BattleDef.NORMAL_ATTACK_SKILL_ID;
		PetPet fightPet = Globals.getPetService().getFightPet(human);
		if (isSkillCanAuto(petSelSkillId) &&
				fightPet != null && 
				!fightPet.getSkillList().isEmpty() && 
				fightPet.getSkillMap().containsKey(petSelSkillId)) {
			human.setPetAutoFightAction(petSelSkillId);
		} else {
			human.setPetAutoFightAction(petSelSkillId == BattleDef.DEFENCE_SKILL_ID ? petSelSkillId : defaultSkillId);
		}
		//通知前台
		human.snapChangedProperty(true);
		flag = cur != human.getAutoFightAction();
		return flag;
	}
	
	protected boolean isSkillCanAuto(int selSkillId) {
		//捕捉、逃跑、嗑药、召唤技能，不能作为自动攻击技能
		if (selSkillId != BattleDef.CATCH_PET_SKILL_ID &&
				selSkillId != BattleDef.ESCAPE_SKILL_ID &&
				selSkillId != BattleDef.USEDRUGS_SKILL_ID &&
				selSkillId != BattleDef.SUMMON_PET_SKILL_ID) {
			return true;
		}
		return false;
	}
	
	/**
	 * 战斗结束的相关处理
	 * @param human
	 * @param bp
	 * @param bra
	 */
	protected void battleEndProcess(Human human, BattleProcess bp) {
		BattleReportAddition bra = new BattleReportAddition();
		int battleId = bp.getBattleId();
		boolean isAttackerWin = bp.getBattleResult() == BattleResult.ATTACKER;
		
		//战斗结束后的处理
		human.onBattleEnd(battleId);
		onBattleEnd(battleId);
		
		long roleId = human.getCharId();
		//战斗结束后，更新战斗外hp、mp、life
		onBattleEndPropUpdate(roleId, bp.getBattleFU(true, true, roleId), bp.getBattleFU(true, false, roleId));
		
		//战斗胜利的相关处理
		if (isAttackerWin) {
			EnemyParamContent epc = (EnemyParamContent)bp.getDefenderContent();
			int enemyArmyId = epc.getEnemyArmyId();
			int mapId = epc.getMapId();
			EnemyArmyTemplate eaTpl = Globals.getTemplateCacheService().get(enemyArmyId, EnemyArmyTemplate.class);
			
			//捕捉宠物处理
			onBattleEndCatchPet(human, bp, enemyArmyId, bra);
			
			//给奖励
			onBattleEndEnemyReward(human.getCharId(), eaTpl, bra, mapId, bp);
			//给任务掉落道具奖励
			onBattleEndTaskReward(human, eaTpl, bra);
			
			//打怪任务监听 
			onBattleEndTaskListener(human.getTaskListener(), bp);
			
		}
		
		//与npc战斗结束的特殊处理
		onNpcBattleEnd(bp, isAttackerWin, false);
		
		//通知前台战斗结束
		human.sendMessage(new GCBattleEnd());
		

		//通知附近玩家，该玩家退出战斗状态
		Globals.getMapService().noticeNearMapInfoChanged(human);
		//通知护送粮草的玩家战斗状态
		Globals.getForageTaskService().notifyForageInfoChanged(human,isAttackerWin);
	}
	
	/**
	 * 回复hp、mp、life
	 * XXX 整体规则是，两种状态：满值时，分子分母一起变化，值始终相同；不满时，只分母变，分子不变（可能会由不满变到满的状态，一旦变满，则按照满的规则）
	 * @param roleId
	 * @param leaderFu
	 * @param petFu
	 */
	public void onBattleEndPropUpdate(long roleId, FightUnit leaderFu, FightUnit petFu) {
		//获取玩家数据
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (null == offlineData) {
			Loggers.battleLogger.error("#BattleService#onBattleEndPropUpdate#can not find offline data!humanId=" + roleId);
			return;
		}
		
		//主将数据更新
		onBattleEndPetPropUpdate(offlineData, leaderFu, true);
		
		//如果有出战宠物，则更新宠物数值
		if (petFu != null) {
			onBattleEndPetPropUpdate(offlineData, petFu, true);
			
			//该宠物如果可以出战，则设置为出战状态
			Globals.getPetService().onFightPetChanged(roleId, PetFightState.FIGHT, petFu.getPetUUId(), 
					PetLogReason.PET_CHANGE_FIGHT_STATE_AFTER_BATTLE);
		}
		
		//存库
		offlineData.setModified();
		
		//发消息属性变化
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player != null && player.getHuman() != null) {
			//pet当前数值变化消息
			player.sendMessage(PetMessageBuilder.buildGCPetCurPropUpdate(roleId, leaderFu.getPetUUId()));
			if (petFu != null) {
				player.sendMessage(PetMessageBuilder.buildGCPetCurPropUpdate(roleId, petFu.getPetUUId()));
			}
			//池子数值更新消息
			player.sendMessage(PetMessageBuilder.buildGCPetPoolUpdate(roleId));
		}
	}
	
	protected boolean onBattleEndPetPropUpdate(UserOfflineData offlineData, FightUnit petFu, boolean recoverFlag) {
		//根据 recoverFlag判断 是否恢复hp、mp、life
		long roleId = offlineData.getCharId();
		long petId = petFu.getPetUUId();
		//获取pet数据
		UserPetData petData = offlineData.getPetData(petId);
		if (null == petData) {
			Loggers.battleLogger.error("#BattleService#onBattleEndPropUpdate#can not find pet offline data!humanId=" + 
					roleId + ";petId=" +petFu.getPetUUId());
			return false;
		}
		
		//出战宠物是否休息了
		boolean flag = false;
		
		boolean isLeader = petFu.getUnitType() == PetType.LEADER;
		boolean isPetPet = petFu.getUnitType() == PetType.PET;
		
		int costLife = 0;
		//每场战斗搞定消耗寿命
		if (isPetPet) {
			costLife = Globals.getGameConstants().getPetBattleCostLife();
			if (petFu.isDead()) {
				costLife = Globals.getGameConstants().getPetBattleCostLifeOnDead();
			}
		}
		
		//战斗后剩余值
		int petHpLeft = petFu.getAttr(BattleDef.HP).intValue();
		int petMpLeft = petFu.getAttr(BattleDef.MP).intValue();
		int petSpLeft = petFu.getAttr(BattleDef.SP).intValue();
		
		//剩余寿命，需要减去每场战斗固定消耗
		int petLifeLeft = petFu.getAttr(BattleDef.LIFE).intValue() - costLife;
		if (petLifeLeft < 0) {
			petLifeLeft = 0;
		}
		
		long petCurHp = petHpLeft;
		long petCurMp  = petMpLeft;
		long petCurLife = petLifeLeft;
		
		if (recoverFlag) {
			//上限值
			int petHpMax = 0;
			int petMpMax = 0;
			int petLifeMax = 0;
			//在线从human取，不在线从UserSnap取
			if (Globals.getTeamService().isPlayerOnline(roleId)) {
				Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
				petHpMax = (int)human.getPetManager().getPetByUuid(petId).getPropertyManager().getBProperty(PetBProperty.HP);
				petMpMax = (int)human.getPetManager().getPetByUuid(petId).getPropertyManager().getBProperty(PetBProperty.MP);
				petLifeMax = (int)human.getPetManager().getPetByUuid(petId).getPropertyManager().getBProperty(PetBProperty.LIFE);
			} else {
				UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(roleId);
				petHpMax = (int)userSnap.getPsManager().getPetById(petId).getBProperty(PetBProperty.HP);
				petMpMax = (int)userSnap.getPsManager().getPetById(petId).getBProperty(PetBProperty.MP);
				petLifeMax = (int)userSnap.getPsManager().getPetById(petId).getBProperty(PetBProperty.LIFE);
			}
			
			long hpPool = offlineData.getHpPool();
			long mpPool = offlineData.getMpPool();
			long lifePool = offlineData.getLifePool();
			
			//hp补充
			RecoverAttrResult hpResult = recoverAttrByPool(petHpLeft, petHpMax, hpPool);
			petCurHp = hpResult.getCur();
			long hpPoolLeft = hpResult.getPoolLeft();
			
			//mp补充
			RecoverAttrResult mpResult = recoverAttrByPool(petMpLeft, petMpMax, mpPool);
			petCurMp = mpResult.getCur();
			long mpPoolLeft = mpResult.getPoolLeft();
			
			//life补充
			RecoverAttrResult lfResult = recoverAttrByPool(petLifeLeft, petLifeMax, lifePool);
			petCurLife = lfResult.getCur();
			long lfPoolLeft = lfResult.getPoolLeft();
			
			//更新池子数值
			offlineData.setHpPool(hpPoolLeft);
			offlineData.setMpPool(mpPoolLeft);
			if (isPetPet) {
				offlineData.setLifePool(lfPoolLeft);
			}
		} else {
			int minValue = Globals.getGameConstants().getBattleLeftMin();
			if (petCurHp < minValue) {
				petCurHp = minValue;
			}
			if (petCurMp < minValue) {
				petCurMp = minValue;
			}
			if (petCurLife < minValue) {
				petCurLife = minValue;
			}
		}
		
		//怒气最小为0
		if (petSpLeft < 0) {
			petSpLeft = 0;
		}
		//怒气最大为n
		if (petSpLeft > Globals.getGameConstants().getBattleSpMax()) {
			petSpLeft = Globals.getGameConstants().getBattleSpMax();
		}
		
		//更新宠物当前值
		petData.setHp(petCurHp);
		petData.setMp(petCurMp);
		if (isPetPet) {
			petData.setLife(petCurLife);
			//如果宠物寿命值过低，则改为休息状态，还需要给前台发消息通知
			long curFightPetId = offlineData.getFightPetId();
			if (curFightPetId == petData.getUuid() && 
					petData.getLife() < Globals.getGameConstants().getPetFightLifeMin()) {
				offlineData.setFightPetId(0);
				flag = true;
			}
		}
		if (isLeader) {
			petData.setSp(petSpLeft);
		}
		//存库
		offlineData.setModified();
		
		return flag;
	}
	
	/**
	 * 池子类恢复计算
	 * @param cur 属性当前值
	 * @param max 属性最大值
	 * @param pool 属性池子数值
	 * @return 返回值中的当前值，已经过最小值为1的检查
	 */
	protected RecoverAttrResult recoverAttrByPool(long cur, long max, long pool) {
		long poolLeft = pool;
		if (cur < max) {
			long deltaHp = max - cur;
			poolLeft = pool - deltaHp;
			if (poolLeft < 0) {
				poolLeft = 0;
				cur = cur + pool;
			} else {
				cur = max;
			}
		} else {
			cur = max;
		}
		
		//最小为x
		int minValue = Globals.getGameConstants().getBattleLeftMin();
		if (cur < minValue) {
			cur = minValue;
		}
		
		RecoverAttrResult ret = new RecoverAttrResult(cur, poolLeft);
		return ret;
	}
	
	protected static class RecoverAttrResult {
		protected long cur;
		protected long poolLeft;
		
		public RecoverAttrResult(long cur, long poolLeft) {
			this.cur = cur;
			this.poolLeft = poolLeft;
		}
		public long getCur() {
			return cur;
		}
		public long getPoolLeft() {
			return poolLeft;
		}
	}
	
	public boolean onUseItemPoolAdd(Human human, PoolAddType type, long addValue) {
		long roleId = human.getCharId();
		//获取玩家数据
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (null == offlineData) {
			Loggers.battleLogger.error("#BattleService#onUsePoolAddItem#can not find offline data!humanId=" 
					+ human.getCharId() + ";type=" + type + ";addValue=" + addValue);
			return false;
		}
		
		Pet leader = human.getPetManager().getLeader();
		Pet fightPet = Globals.getPetService().getFightPet(human);
		
		boolean noticeFlag = false;
		switch (type) {
		case HP:
			//更新血池
			long newHp = calcNewPoolValue(offlineData.getHpPool(), 
					Globals.getGameConstants().getMaxHpPool(), addValue);
			offlineData.setHpPool(newHp);
			offlineData.setModified();
			//主将补充
			noticeFlag = petOfflinePropUpdate(human, leader, true, false, false);
			//出战宠物补充
			if (fightPet != null) {
				noticeFlag |= petOfflinePropUpdate(human, fightPet, true, false, false);
			}
			break;
		case MP:
			//更新蓝池
			long newMp = calcNewPoolValue(offlineData.getMpPool(), 
					Globals.getGameConstants().getMaxMpPool(), addValue);
			offlineData.setMpPool(newMp);
			offlineData.setModified();
			//主将补充
			noticeFlag = petOfflinePropUpdate(human, leader, false, true, false);
			//出战宠物补充
			if (fightPet != null) {
				noticeFlag |= petOfflinePropUpdate(human, fightPet, false, true, false);
			}
			break;
		case LIFE:
			//更新寿命池
			long newLf = calcNewPoolValue(offlineData.getLifePool(), 
					Globals.getGameConstants().getMaxLifePool(), addValue);
			offlineData.setLifePool(newLf);
			offlineData.setModified();
			//出战宠物补充
			if (fightPet != null) {
				noticeFlag = petOfflinePropUpdate(human, fightPet, false, false, true);
			}
			break;

		default:
			break;
		}
		
		if (!noticeFlag) {
			//池子数值更新消息
			human.sendMessage(PetMessageBuilder.buildGCPetPoolUpdate(roleId));
		}
		return true;
	}
	
	/**
	 * 给pet补充hp、mp、life
	 * @param human
	 * @param pet
	 * @param hpChanged
	 * @param mpChanged
	 * @param lifeChanged
	 */
	public boolean petOfflinePropUpdate(Human human, Pet pet, 
			boolean hpChanged, boolean mpChanged, boolean lifeChanged) {
		long roleId = human.getCharId();
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (null == offlineData) {
			return false;
		}
		UserPetData petData = offlineData.getPetData(pet.getUUID());
		if (null == petData) {
			return false;
		}
		
		boolean changedFlag = false;
		
		//上限值
		int petHpMax = (int)pet.getPropertyManager().getBProperty(PetBProperty.HP);
		int petMpMax = (int)pet.getPropertyManager().getBProperty(PetBProperty.MP);
		int petLifeMax = (int)pet.getPropertyManager().getBProperty(PetBProperty.LIFE);
		
		if (hpChanged && petData.getHp() < petHpMax) {
			//hp补充
			RecoverAttrResult hpResult = recoverAttrByPool(petData.getHp(), petHpMax, offlineData.getHpPool());
			//更新数值
			petData.setHp(hpResult.getCur());
			offlineData.setHpPool(hpResult.getPoolLeft());
			offlineData.setModified();
			
			changedFlag = true;
		}
		
		if (mpChanged && petData.getMp() < petMpMax) {
			//mp补充
			RecoverAttrResult mpResult = recoverAttrByPool(petData.getMp(), petMpMax, offlineData.getMpPool());
			//更新数值
			petData.setMp(mpResult.getCur());
			offlineData.setMpPool(mpResult.getPoolLeft());
			offlineData.setModified();
			
			changedFlag = true;
		}
		
		if (lifeChanged && petData.getLife() < petLifeMax) {
			//life补充
			RecoverAttrResult lfResult = recoverAttrByPool(petData.getLife(), petLifeMax, offlineData.getLifePool());
			//更新数值
			petData.setLife(lfResult.getCur());
			offlineData.setLifePool(lfResult.getPoolLeft());
			offlineData.setModified();
			
			changedFlag = true;
		}
		
		if (changedFlag) {
			//pet当前数值变化消息
			human.sendMessage(PetMessageBuilder.buildGCPetCurPropUpdate(roleId, pet.getUUID()));
			//池子数值更新消息
			human.sendMessage(PetMessageBuilder.buildGCPetPoolUpdate(roleId));
		}
		return changedFlag;
	}
	
	public long calcNewPoolValue(long cur, long max, long addValue) {
		long newValue = cur + addValue;
		//池子分子可以大于分母
//		if (newValue > max) {
//			newValue = max;
//		}
		return newValue;
	}
	
	public void onBattleEndCatchPet(Human human, BattleProcess bp, int enemyArmyId, BattleReportAddition bra) {
		if (bp.getAttackerCatchPetTplId() > 0 &&
				human.getCharId() == bp.getAttackerCatchPetOwnerId()) {
			PetTemplate catchPetTpl = Globals.getTemplateCacheService().get(bp.getAttackerCatchPetTplId(), PetTemplate.class);
			//能否招募武将
			if (!Globals.getPetService().canCatchPet(human, catchPetTpl)) {
				return;
			}
			//检查抓宠物的消耗品是否足够
			if (checkAndCostCatchItem(human, bp.getAttackerCatchPetTplId(), enemyArmyId)) {
				PetPet caughtPet = Globals.getPetService().onCatchPet(human, bp.getAttackerCatchPetTplId(), PetLogReason.PET_CATCH_PET);
				//设置战报中的捕捉宠物信息
				if (bra != null) {
					bra.getReportCatchPetInfo().setPetTplId(caughtPet.getTemplateId());
					bra.getReportCatchPetInfo().setGeneTypeId(caughtPet.getGeneTypeId());
				}
				
				//如果是神兽or高级宠，则广播 恭喜XXXX玩家成功抓捕到XXX神兽/高级宠
				PetTemplate tpl = Globals.getTemplateCacheService().get(caughtPet.getTemplateId(), PetTemplate.class);
				if (tpl.isGoodPet()) {
					Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getPetIslandGoodPetCaughtNoticeId(), 
							human.getName(), tpl.getName(), Globals.getLangService().readSysLang(tpl.getPetPetType().getNameLangId()));
				}
			} else {
				Loggers.battleLogger.warn("#BattleService#battleEndProcess#catch success but has not enough item!humanId=" + 
						human.getCharId() + ";petTplId=" + bp.getAttackerCatchPetTplId());
			}
		}
	}
	
	public void onBattleEndEnemyReward(long roleId, EnemyArmyTemplate eaTpl, BattleReportAddition bra, int mapId, BattleProcess bp) {
		int rewardId = eaTpl.getRewardId();
		IRewardAmend addAmend = null;
		//怪物组有可扣除双倍点
		if(eaTpl.getDoublePointCost() > 0){
			//并且开启双倍
			if(this.isDoubleStatus(roleId)){
				boolean flag = this.onBattleEndDoublePointUpdate(roleId, eaTpl.getDoublePointCost());
				if (flag) {
					addAmend = new DoublePointRewardAmend();
				}
			}
		}
		if (rewardId > 0) {
			Reward rewardEnemyArmy = Globals.getRewardService().createRewardWithAmend(roleId, rewardId, "winEnemyArmy " + eaTpl.getId(), addAmend);
			if (rewardEnemyArmy != null && !rewardEnemyArmy.isNull()) {
				boolean giveRewardFlag = false;
				//玩家在线，直接给奖励，不提示
				if (Globals.getTeamService().isPlayerOnline(roleId)) {
					Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
					giveRewardFlag = Globals.getRewardService().giveReward(human, rewardEnemyArmy, false);
					if (giveRewardFlag && bra != null) {
						//设置战报
						bra.addReward(rewardEnemyArmy);
					}
				} else {
					//玩家离线，给离线奖励
					giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.WIN_ENEMY, rewardEnemyArmy, "");
				}
				if (!giveRewardFlag) {
					// 记录错误日志
					Loggers.humanLogger.error("#BattleService#battleEndProcess# giveReward failed!uuid=" + roleId + ";rewardId=" + rewardId);
				}
			} else {
				// 记录错误日志
				Loggers.humanLogger.error("#BattleService#battleEndProcess# reward is null!uuid=" + roleId + ";rewardId=" + rewardId);
			}
		}
		
		//是通天塔的怪物,并且不是npc类型
		int npcId = Globals.getTemplateCacheService().getMapTemplateCache().getTowerNpcIdByMapId(mapId);
		if(npcId > 0){
			if(eaTpl.getIsTower() == 1 && !Globals.getTowerService().isNpcInTower(npcId)){
				//通天塔走单独的奖励配置
				this.getGuajiRewardByTower(roleId, eaTpl, mapId, addAmend);
			}
		}
		
		//帮派boss的怪物
		if(Globals.getTemplateCacheService().getCorpsTemplateCache().isCorpsBossEnemy(eaTpl.getId())){
			Globals.getCorpsBossService().giveCorpsBossReward(roleId, eaTpl, mapId, bp);
		}
		
		//剧情副本的怪物
		if(Globals.getTemplateCacheService().getPlotDungeonTemplateCache().isPlotDungeonEnemy(eaTpl.getId())){
			Globals.getPlotDungeonService().updatePlotDungeonRecord(roleId, eaTpl, mapId, bp);
		}
	}
	
	/**
	 * 挂机后的奖励
	 * @param roleId
	 * @param eaTpl
	 */
	protected void getGuajiRewardByTower(long roleId, EnemyArmyTemplate eaTpl, int mapId, IRewardAmend addAmend){
		List<Reward> rewards = Lists.newArrayList();
		Reward totalReward = null;
		//玩家在线，直接给奖励
		boolean giveRewardFlag = false;
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			
			TowerRewardTemplate rewardTpl = Globals.getTemplateCacheService().getTowerTemplateCache().getTowerReward(human.getLevel());
			if(rewardTpl == null || human.getTowerManager() == null){
				return;
			}
			
			//固定奖励
			if(rewardTpl.getFixedRewardId() > 0){
				rewards.add(Globals.getRewardService().createReward(roleId, rewardTpl.getFixedRewardId(),
						"gain fixed reward by tower battle end."));
				
			}
			//战斗胜利随机奖励
			if(RandomUtils.isHit(rewardTpl.getRewardProb())){
				rewards.add(Globals.getRewardService().createReward(roleId, rewardTpl.getRandomRewardId(),
						"gain random reward by tower battle end."));
			}
			
			//人,宠,骑宠的经验获得 * 组队人员的系数
			int num = 0;
			if(Globals.getTeamService().isInTeamNormal(roleId)){
				num = Globals.getTeamService().getHumanTeamMemberNum(roleId);
			}else{
				num = 1;
			}
			int coef = Globals.getTemplateCacheService().getTowerTemplateCache().getExpTplByLevel(human.getLevel(), num);
			if(coef <= 0){
				return;
			}	
			int exp = (int)( Globals.getTemplateCacheService().getTowerTemplateCache().getTowerExp(human.getLevel(),
					Globals.getTemplateCacheService().getTowerTemplateCache().getTowerLevelByMapId(mapId),
					coef) * ((double)coef / Globals.getGameConstants().getScale()));
			if (addAmend != null) {
				exp = exp * DoublePointRewardAmend.getAmendCoef() / Globals.getGameConstants().getScale();
			}
			List<RewardParam> paramList = new ArrayList<RewardParam>();
			RewardParam rp1 = new RewardParam(RewardType.REWARD_LEADER_EXP, 0, exp);
			RewardParam rp2 = new RewardParam(RewardType.REWARD_PET_EXP, 0, exp);
			RewardParam rp3 = new RewardParam(RewardType.REWARD_PET_HORSE_EXP, 0, exp);
			paramList.add(rp1);
			paramList.add(rp2);
			paramList.add(rp3);
			Reward reward = Globals.getRewardService().createRewardByFixedContent(roleId, RewardReasonType.TOWER_REWARD, paramList, "towerGuajiReward");
			rewards.add(reward);
			
			//合并
			totalReward = Globals.getRewardService().mergeReward(rewards);
			
			giveRewardFlag = Globals.getRewardService().giveReward(human, totalReward, true);
			
			//任务监听
			human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.MAP_TOWER_ENEMY, 0, 1);
		} else {
			//玩家离线，给离线奖励
			giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.GUAJI, totalReward, "");
		}
		if (!giveRewardFlag) {
			// 记录错误日志
			Loggers.towerLogger.error("TowerService#onBattleEndEnemyReward give reward error!humanId=" + roleId);
			return;
		}
		
		
	}
	
	
	/**
	 * 战斗结束,扣除双倍经验点
	 * @param roleId
	 */
	public boolean onBattleEndDoublePointUpdate(long roleId, int doublePoint) {
		//是否可开启双倍
		if(!Globals.getTowerService().canOpenDouble(roleId, doublePoint)){
			return false;
		}
		//是否双倍状态
		if(!this.isDoubleStatus(roleId)){
			return false;
		}
		
		//扣除双倍点
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if(offlineData == null){
			return false;
		}
		
		int newDoublePoint = offlineData.getCurDoublePoint() - doublePoint;
		
		offlineData.setCurDoublePoint(newDoublePoint);
		offlineData.setModified();
		
		//发送剩余双倍点
		if(Globals.getTeamService().isPlayerOnline(roleId)){
			Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
			if(player != null && player.getHuman() != null){
				player.sendMessage(TowerMsgBuilder.createGCTowerInfo(player.getHuman()));
			}
		}
		return true;
	}
	
	/**
	 * 是否开启双倍
	 * @param roleId
	 * @return
	 */
	public boolean isDoubleStatus(long roleId){
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if(offlineData == null){
			return false;
		}
		return offlineData.getIsOpenDouble() == 1 ? true : false;
	}
	
	/**
	 * 根据玩家身上的任务和当前打的怪物Id，获取玩家获得的特殊奖励Id
	 * @param human
	 * @param eaTpl
	 * @return
	 */
	public Map<Integer, Integer> getHumanTaskRewardMap(Human human, EnemyArmyTemplate eaTpl) {
		Map<Integer,Integer> m1 = human.getCommonTaskManager().getTaskRewardByEmemyArmy(eaTpl.getId());
		Map<Integer,Integer> m2 = human.getPubTaskManager().getTaskRewardByEmemyArmy(eaTpl.getId());
		Map<Integer,Integer> m3 = human.getTheSweeneyTaskManager().getTaskRewardByEmemyArmy(eaTpl.getId());
		Map<Integer,Integer> m4 = human.getCorpsTaskManager().getTaskRewardByEmemyArmy(eaTpl.getId());
		Map<Integer,Integer> m5 = human.getTimeLimitMonsterManager().getTaskRewardByEmemyArmy(eaTpl.getId());
		Map<Integer,Integer> m6 = human.getTimeLimitNpcManager().getTaskRewardByEmemyArmy(eaTpl.getId());
		Map<Integer,Integer> m7 = human.getSiegeDemonNormalTaskManager().getTaskRewardByEmemyArmy(eaTpl.getId());
		Map<Integer,Integer> m8 = human.getSiegeDemonHardTaskManager().getTaskRewardByEmemyArmy(eaTpl.getId());
		
		m1.putAll(m2);
		m1.putAll(m3);
		m1.putAll(m4);
		m1.putAll(m5);
		m1.putAll(m6);
		m1.putAll(m7);
		m1.putAll(m8);
		return m1;
	}
	
	/**
	 * 给玩家任务的打怪奖励（掉落特殊物品）
	 * @param human
	 * @param eaTpl
	 * @param bra
	 */
	public void onBattleEndTaskReward(Human human, EnemyArmyTemplate eaTpl, BattleReportAddition bra) {
		//给任务掉落 
		Map<Integer,Integer> taskRrewardIdMap = getHumanTaskRewardMap(human, eaTpl);
		if(taskRrewardIdMap != null && !taskRrewardIdMap.isEmpty()){
			for(Entry<Integer,Integer> entry : taskRrewardIdMap.entrySet()) {
				int taskId = entry.getKey();
				int taskRewardId = entry.getValue();
				if (taskRewardId > 0) {
					Reward rewardTaskEnemyArmy = Globals.getRewardService().createReward(human.getCharId(), taskRewardId, "winEnemyArmy " + eaTpl.getId() + ";taskId=" + taskId);
					if (rewardTaskEnemyArmy != null && !rewardTaskEnemyArmy.isNull()) {
						// 给玩家奖励，不提示
						boolean flag = rewardTaskEnemyArmy.giveReward(human, true);
						if (flag && bra != null) {
							bra.addReward(rewardTaskEnemyArmy);
						} else {
							// 记录错误日志
							Loggers.humanLogger.error("#BattleService#battleEndProcess# giveReward failed!uuid=" + human.getUUID() + ";rewardId=" + taskRewardId+ ";taskId=" + taskId);
						}
					} else {
						// 记录错误日志
						Loggers.humanLogger.error("#BattleService#battleEndProcess# reward is null!uuid=" + human.getUUID() + ";rewardId=" + taskRewardId+ ";taskId=" + taskId);
					}
//					//有特殊任务掉落，添加监听 这种任务类型都改为 DestType.COLLECTION_ITEM 了，所以这里不再监听了
//					if(rewardTaskEnemyArmy.getItemMap() != null && !rewardTaskEnemyArmy.getItemMap().isEmpty()){
//						for(Entry<Integer, Integer> itemData : rewardTaskEnemyArmy.getItemMap().entrySet()){
//							human.getTaskListener().onNumRecordDest(NumRecordType.MAP_COLLECTION, itemData.getKey(), itemData.getValue());
//						}
//					}
				}
			}
		}
	}
	
	/**
	 * pve战斗结束后的任务监听
	 * @param tl
	 * @param bp
	 */
	public void onBattleEndTaskListener(TaskListener<? extends ITaskOwner> tl, BattleProcess bp) {
		Map<Integer, Integer> enemyMap = calcBattleEnemyMap(bp);
		//打怪任务监听 
		for (Entry<Integer, Integer> entry : enemyMap.entrySet()) {
			//玩家任务监听
			tl.onNumRecordDest(NumRecordType.MAP_ENEMY, entry.getKey(), entry.getValue());
			//战胜任意怪的任务监听
			tl.onNumRecordDest(NumRecordType.WIN_ANY_ENEMY, entry.getKey(), entry.getValue());
		}
		
		//打npc任务监听
		if (isNpcBattle(bp)) {
			NpcInfo npcInfo = (NpcInfo) bp.getParam();
			tl.onNumRecordDest(NumRecordType.MAP_NPC_WIN, npcInfo.getNpcId(), 1);
		}
		
	}
	
	public boolean isNpcBattle(BattleProcess bp) {
		Object param = bp.getParam();
		if (param != null && param instanceof NpcInfo) {
			return true;
		}
		return false;
	}
	
	/**
	 * 获取战斗过程中，所有防守方为怪物的统计map
	 * @param bp
	 * @return Map<怪物模板Id, 怪物数量>
	 */
	public Map<Integer, Integer> calcBattleEnemyMap(BattleProcess bp) {
		//取防守方的所有战斗对象
		Collection<FightUnit> dCol = bp.getAllFUs(false);
		Map<Integer, Integer> enemyMap = new HashMap<Integer, Integer>();
		for (FightUnit fu : dCol) {
			//怪物中的
			if (fu.getUnitType() == PetType.MONSTER) {
				int tplId = fu.getTemplateId();
				int curNum = enemyMap.containsKey(tplId) ? enemyMap.get(tplId) : 0;
				enemyMap.put(tplId, curNum + 1);
			}
		}
		return enemyMap;
	}
	
	protected boolean checkAndCostCatchItem(Human human, int petTplId, int enemyArmyId) {
		PetTemplate petTpl = Globals.getTemplateCacheService().get(petTplId, PetTemplate.class);
		if (petTpl == null) {
			return false;
		}
		if (petTpl.getCatchItemId() <= 0) {
			return true;
		}
		if (human.getInventory().hasItemByTmplId(petTpl.getCatchItemId(), petTpl.getCatchItemNum())) {
			//扣道具
			human.getInventory().removeItem(petTpl.getCatchItemId(), petTpl.getCatchItemNum(), 
					ItemLogReason.CATCH_PET_COST, LogUtils.genReasonText(ItemLogReason.CATCH_PET_COST, petTplId, enemyArmyId));
			return true;
		}
		return false;
	}
	
	protected boolean hasEnoughCatchItem(Human human, int petTplId) {
		PetTemplate petTpl = Globals.getTemplateCacheService().get(petTplId, PetTemplate.class);
		if (petTpl == null) {
			return false;
		}
		if (petTpl.getCatchItemId() <= 0) {
			return true;
		}
		if (human.getInventory().hasItemByTmplId(petTpl.getCatchItemId(), petTpl.getCatchItemNum())) {
			return true;
		}
		return false;
	}
	
	/**
	 * 更新本轮选择的技能和目标
	 * @param leaderOrPet
	 * @param selSkillId
	 * @param selTarget 为0表示没选目标，不用验证目标
	 * @return
	 */
	protected boolean updateFighterSel(Human human, BattleProcess bp, boolean isAttacker, boolean leaderOrPet, 
			int selSkillId, int selTarget, int selItemId, long summonPetId) {
		long ownerId = human.getCharId();
		FightUnit setFu = isAttacker ? bp.getAttackerFULive(leaderOrPet, ownerId) : bp.getDefenderFULive(leaderOrPet, ownerId);
		if (setFu == null) {
			return false;
		}
		
		//技能是否存在
		if (!setFu.hasSkill(selSkillId)) {
			Loggers.battleLogger.error("hasSkill return false!selSkillId=" + selSkillId);
			return false;
		}
		boolean isSetFuAttacker = setFu.isAttacker();
		int skillLevel = setFu.getSkillLevel(selSkillId);
		
		//检测是否需要选目标，目标方是否正确
		SkillEffectTemplate seTpl = Globals.getTemplateCacheService().getBattleTemplateCache().getSkillMainEffectTpl(selSkillId, skillLevel, 
				human.getRunningMainSkillType().getIndex(), human.getMainSkillLevel());
		if (seTpl == null) {
			Loggers.battleLogger.error("main SkillEffectTemplate is null!selSkillId=" + selSkillId);
			return false;
		}
		
		FightUnit tmpTarget = null;
		boolean isAll = false;
		boolean isLive = true;
		
		//目标是否存在
		boolean targetFlag = false;
		
		//如果是不需要选目标的技能，则不验证selTarget，直接置为0
		boolean needTarget = seTpl.isTargetSelect();
		TargetType tt = seTpl.getTargetType();
		//selTarget==0表示没选目标，程序随机一个即可
		if (needTarget && selTarget > 0) {
			boolean targetTypeFlag = targetTypeBaseCheck(tt, selSkillId, selTarget);
			if (!targetTypeFlag) {
				return false;
			}
			
			if (tt == TargetType.OUR_DEAD) {
				isLive = false;
			}
			if (tt == TargetType.OUR_ALL) {
				isAll = true;
			}
			
			int pos = selTarget;
			
			Collection<FightUnit> tCol = null;
			if (isAll) {
				if (selTarget > BattleDef.POS_ADD) {
					//敌方
					pos = selTarget - BattleDef.POS_ADD;
					tCol = bp.getAllCanOpFUs(isSetFuAttacker ? false : true);
				} else {
					//我方
					tCol = bp.getAllCanOpFUs(isSetFuAttacker ? true : false);
				}
			} else {
				if (selTarget > BattleDef.POS_ADD) {
					//敌方
					pos = selTarget - BattleDef.POS_ADD;
					tCol = bp.getFUs(isLive, isSetFuAttacker ? false : true);
				} else {
					//我方
					tCol = bp.getFUs(isLive, isSetFuAttacker ? true : false);
				}
			}
			for (FightUnit tf : tCol) {
				if (tf.getPosition() == pos) {
					targetFlag = true;
					tmpTarget = tf;
					break;
				}
			}
		} else {
			//不需要选目标，直接设置为true
			targetFlag = true;
			selTarget = 0;
		}
		
		if (targetFlag) {
			//嗑药单独判断，道具是否足够，是否选择了目标
			if (selSkillId == BattleDef.USEDRUGS_SKILL_ID) {
				//是否有对应的道具
				if (!human.getInventory().hasItemByTmplId(selItemId, 1)) {
					return false;
				}
				//必须选择目标，不能自动
				if (selTarget <= 0) {
					return false;
				}
				
				targetFlag = true;
				setFu.setSelItemId(selItemId);
			} else if (selSkillId == BattleDef.SUMMON_PET_SKILL_ID) {
				//召唤宠物
				setFu.setSummonPetId(summonPetId);
			}
		}
		
		if (targetFlag) {
			//捕捉宠物，需要验证道具是否足够
			if (selSkillId == BattleDef.CATCH_PET_SKILL_ID) {
				//验证有没有道具
				if (!hasEnoughCatchItem(human, tmpTarget.getCatchPetId())) {
					selSkillId = 0;
					selTarget = 0;
					targetFlag = false;
				}
			}
			
			setFu.setSelSkillId(selSkillId);
			setFu.setSelTarget(selTarget);
		}
		return targetFlag;
	}
	
	protected boolean targetTypeBaseCheck(TargetType tt, int selSkillId, int selTarget) {
		if (tt == null) {
			return false;
		}
		switch (tt) {
		case ENEMY:
			if (selTarget <= BattleDef.POS_ADD) {
				Loggers.battleLogger.error("selTarget bad param!enemy.selTarget=" + selTarget + "selSkillId=" + selSkillId);
				return false;
			}
			break;
		case OUR:
			if (selTarget > BattleDef.POS_ADD) {
				Loggers.battleLogger.error("selTarget bad param!our.selTarget=" + selTarget + "selSkillId=" + selSkillId);
				return false;
			}
			break;
		case OUR_DEAD:
//			isLive = false;
			if (selTarget > BattleDef.POS_ADD) {
				Loggers.battleLogger.error("selTarget bad param!our.selTarget=" + selTarget + "selSkillId=" + selSkillId);
				return false;
			}
			break;
		
		case OUR_ALL:
//			isAll = true;
			if (selTarget > BattleDef.POS_ADD) {
				Loggers.battleLogger.error("selTarget bad param!our.selTarget=" + selTarget + "selSkillId=" + selSkillId);
				return false;
			}
			break;
		//捕捉宠物，从敌方选
		case ENEMY_CAN_CATCH:
			if (selTarget <= BattleDef.POS_ADD) {
				Loggers.battleLogger.error("selTarget bad param!enemy.selTarget=" + selTarget + "selSkillId=" + selSkillId);
				return false;
			}
			break;
			
		case MYSELF:
		case LEADER:
		case PET:
			Loggers.battleLogger.error("not need sel target!selSkillId=" + selSkillId + "selTarget=" + selTarget);
			return false;
			
		default:
			Loggers.battleLogger.error("invalid target type!selSkillId=" + selSkillId + "selTarget=" + selTarget);
			return false;
		}
		
		return true;
	}
	
	public boolean isValidUseDrugsItem(int itemId) {
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		if (!itemTpl.isConsumable() || !(itemTpl instanceof ConsumeItemTemplate)) {
			return false;
		}
		ConsumeItemTemplate cTpl = (ConsumeItemTemplate)itemTpl;
		FightDrugsType dt = cTpl.getFightDrugsType();
		if (dt == null) {
			return false;
		}
		return true;
	}
	
	public ConsumeItemTemplate getUseDrugsItemTemplate(int itemId) {
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		ConsumeItemTemplate cTpl = (ConsumeItemTemplate)itemTpl;
		return cTpl;
	}
	
	public boolean canUseDrugsItemRevive(int itemId) {
		if (!isValidUseDrugsItem(itemId)) {
			return false;
		}
		
		ConsumeItemTemplate cTpl = getUseDrugsItemTemplate(itemId);
		FightDrugsType dt = cTpl.getFightDrugsType();
		
		if (dt == FightDrugsType.HP) {
			if (cTpl.getArgC() > 0) {
				return true;
			}
		}
		return false;
	}
	
	public int getUseDrugsItemValue(int itemId) {
		if (!isValidUseDrugsItem(itemId)) {
			return 0;
		}
		
		ConsumeItemTemplate cTpl = getUseDrugsItemTemplate(itemId);
		return cTpl.getArgB();
	}
	
	public boolean hasItem(long roleId, int selItemId) {
		if (!isValidUseDrugsItem(selItemId)) {
			return false;
		}
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player != null && player.getHuman() != null &&
				player.getHuman().getInventory().hasItemByTmplId(selItemId, 1)) {
			return true;
		}
		return false;
	}
	
	public boolean costUseDrugsItemInFight(long roleId, int selItemId, FightUnit fu) {
		if (!isValidUseDrugsItem(selItemId)) {
			return false;
		}
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player != null && player.getHuman() != null) {
			String detailReason = ItemLogReason.FIGHT_USE_COST.getReasonText();
			detailReason = MessageFormat.format(detailReason, fu.getPetUUId()+"", fu.getUnitType());
			Collection<Item> ret = player.getHuman().getInventory().removeItem(selItemId, 1, ItemLogReason.FIGHT_USE_COST, detailReason);
			if (ret == null || ret.isEmpty()) {
				return false;
			}
			return true;
		}
		return false;
	}
	
	protected void onBattleEnd(int battleId) {
		BattleProcess bp = getBattle(battleId);
		if (bp != null && bp.isBattleEnd()) {
			removeBattle(battleId);
			//保存战报
			saveReport(bp);
		}
	}
	
	public long saveReport(BattleProcess bp) {
		if (bp.isGenReport()) {
			if (bp.getReportList() != null && !bp.getReportList().isEmpty()) {
				long reportId = Globals.getBattleReportService().generateReportId();
				bp.setReportId(reportId);
				Globals.getBattleReportService().saveBattleReport(reportId, bp.getReportList());
				return reportId;
			}
		}
		return 0;
	}
	
	/**
	 * 定时检测是否有超时的战斗，如果有则处理掉
	 */
	public void checkBattleOvertime() {
		long now = Globals.getTimeService().now();
		Set<BattleProcess> endSet = new HashSet<BattleProcess>();
		
		Iterator<BattleProcess> it = battleMap.values().iterator();
		for (;it.hasNext();) {
			BattleProcess bp = it.next();
			//如果战斗已经结束，且已经到了读战报结束的时间，且玩家在线，则正常结束战斗，否则等待战斗超时
			if (bp.isBattleEnd() && 
					now >= bp.getLastRoundEndTime() &&
					getAttackerHuman(bp) != null) {
				endSet.add(bp);
				continue;
			}
			
			if (bp.getStartTime() + BattleDef.BATTLE_MAX_TIME < now) {
				onBattleOvertime(bp, false);
				//移除战斗
				it.remove();
			} else {
				//由于是linkedHashMap，所以后边的不会超时
				break;
			}
		}
		
		//将到了读战报结束时间的战斗 正常结束
		if (!endSet.isEmpty()) {
			for (BattleProcess bp : endSet) {
				//前面判断了human在线
				battleEndProcess(getAttackerHuman(bp), bp);
			}
		}
	}
	
	protected Human getAttackerHuman(BattleProcess bp) {
		Player player = Globals.getOnlinePlayerService().getPlayer(bp.getAttackerId());
		if (player != null && player.getHuman() != null && player.isOnline()) {
			return player.getHuman();
		}
		return null;
	}
	
	/**
	 * 战斗超时的处理
	 * @param bp
	 * @param isForce
	 */
	protected void onBattleOvertime(BattleProcess bp, boolean isForce) {
		//战斗已超时，需要强制清除
		onAbnormalEndBattle(bp, "onBattleOvertime");
		
		//记录警告日志
		Loggers.battleLogger.warn("battel overtime deleted!battleId=" + bp.getBattleId() + 
				";attackerHumanId=" + bp.getAttackerId());
	}
	
	/**
	 * 强制结束战斗，由外部调用
	 * @param battleId
	 */
	public void forceEndBattle(int battleId) {
		BattleProcess bp = getBattle(battleId);
		if (bp == null) {
			Loggers.battleLogger.error("battleId not exist!" + battleId);
			return;
		}
		
		//强制清除战斗
		onAbnormalEndBattle(bp, "forceEndBattle");
		
		//移除战斗
		removeBattle(bp.getBattleId());
		
		//记录警告日志
		Loggers.battleLogger.warn("forceEndBattle!battleId=" + battleId);
	}
	
	/**
	 * 非正常结束战斗的处理
	 * @param bp
	 * @param source
	 */
	protected void onAbnormalEndBattle(BattleProcess bp, String source) {
		int battleId = bp.getBattleId();
		long attackerHumanId = bp.getAttackerId();
		
		//战斗结束后，更新战斗外hp、mp、life
		onBattleEndPropUpdate(attackerHumanId, bp.getBattleFU(true, true, attackerHumanId), bp.getBattleFU(true, false, attackerHumanId));
		
		//与npc战斗结束的特殊处理
		onNpcBattleEnd(bp, false, true);
		
		boolean isOnline = false;
		Player player = Globals.getOnlinePlayerService().getPlayer(attackerHumanId);
		Human human = null;
		if (player != null && player.getHuman() != null && player.isOnline()) {
			isOnline = true;
			human = player.getHuman();
			//玩家在线，但战斗还是超时了，这种情况可能是因为服务器没有监测到玩家下线；另一种可能就是客户端死了
			player.getHuman().setLastBattleId(0);
			//发消息通知客户端
			player.sendMessage(new GCBattleForceEnd());
		}
		
		//通知附近玩家，该玩家退出战斗状态
		Globals.getMapService().noticeNearMapInfoChanged(human);
		
		//记录警告日志
		Loggers.battleLogger.warn("battel end abnormal deleted!battleId=" + battleId + 
				";attackerHumanId=" + attackerHumanId + ";isOnline=" + isOnline + ";source=" + source);
	}
	
	/**
	 * 与npc战斗结束处理
	 * @param human
	 * @param battleId
	 * @param isAttackerWin
	 * @param isForceEnd
	 * @param param
	 */
	protected void onNpcBattleEnd(BattleProcess bp, boolean isAttackerWin, boolean isForceEnd) {
		if (!isNpcBattle(bp)) {
			return;
		}
		int battleId = bp.getBattleId();
		
		NpcInfo npcInfo = (NpcInfo) bp.getParam();
		
		//宠物岛需要单独处理 TODO 宠物岛按说不能是组队的
		if (Globals.getMapService().isPetIsland(npcInfo.getMapId())) {
			Globals.getPetIslandService().onBattleEnd(battleId, isAttackerWin, isForceEnd);
		}
		
		//绿野仙踪需要单独处理
		if (Globals.getMapService().isWizardRaidMap(npcInfo.getMapId())) {
			Globals.getWizardRaidService().onBattleEnd(bp, npcInfo.getUuid(), isAttackerWin, isForceEnd);
		}
		
		//单人的封印小妖需要处理
		if(Globals.getMapService().isSealDemonMap(npcInfo.getMapId())){
			Globals.getSealDemonService().onNpcBattleEnd(bp, npcInfo, isAttackerWin, isForceEnd);
		}
		
		//npc的战斗状态变为0
		npcInfo.setBattleId(0);
		
		//记录日志
		Loggers.mapLogger.info("map fight npc end.npcInfo=" + npcInfo + 
				";attackerId=" + bp.getAttackerId());
	}
	
	/**
	 * 玩家登录时，检测其战斗是否存在
	 * 存在则发战报
	 * 不存在则恢复玩家状态
	 * @param human
	 */
	public void onPlayerLogin(Human human) {
		int battleId = human.getLastBattleId();
		if (battleId == 0) {
			return;
		}
		
		BattleProcess bp = getBattle(battleId);
		if (bp != null) {
			if (!bp.isBattleEnd()) {
				//玩家正在进行战斗，给前台发战报，直接进入战斗
				String startReport = bp.getBeforeRoundReport();
				Globals.getBattleReportService().sendBattlePartReport(human, ReportMsgType.START, startReport, "");
			} else {
				//如果战斗已经结束，则发最后一轮的战报
				String lastReport = bp.getLastReport();
				Globals.getBattleReportService().sendBattlePartReport(human, ReportMsgType.ROUND, lastReport, "");
			}
		} else {
			//XXX 这里可能因为玩家战斗超时，已被定时任务删掉造成；也可能是因为服务器宕机引起的玩家状态错误，需要强制恢复，记录警告日志
			human.setLastBattleId(0);
			//记录警告日志
			Loggers.battleLogger.warn("human battleId not exist now!humanId=" + human.getCharId() + 
					";humanBattleId=" + battleId + ";humanLastBattleTime=" + human.getLastBattleTime());
		}
	}
	
	/**
	 * 玩家读完最后一轮战报的请求
	 * @param human
	 * @return
	 */
	public boolean readLastRoundReportEnd(Human human) {
		int battleId = human.getLastBattleId();
		if (battleId <= 0) {
			return false;
		}
		
		BattleProcess bp = getBattle(battleId);
		if (bp == null) {
			return false;
		}
		
		//战斗未结束，不做处理
		if (!bp.isBattleEnd()) {
			return false;
		}
		
		//结束战斗的处理
		battleEndProcess(human, bp);
		
		return true;
	}
	
	/**
	 * 客户端请求已经读完最后一轮战报
	 * @param human
	 */
	public void requestReadLastReportEnd(Human human) {
		long roleId = human.getCharId();
		if (Globals.getTeamService().isInTeamBattle(roleId)) {
			//组队pvp中
			if (Globals.getTeamPvpService().isInTeamPvpBattle(roleId)) {
				Globals.getTeamPvpService().readLastRoundReportEnd(human);
			} else {
				//组队pve中
				Globals.getTeamService().getTeamBattleLogic().readLastRoundReportEnd(human);
			}
		} else if (Globals.getPvpService().isPlayerInPvp(roleId)) {
			//单人pvp
			Globals.getPvpService().readLastRoundReportEnd(human);
		} else if (human.isInBattle()) {
			//单人pve
			readLastRoundReportEnd(human);
		}
		return;
	}
	
	/**
	 * 获取技能消耗数值
	 * @param skillId
	 * @param skillLevel
	 * @return
	 */
	public int getSkillCostValue(int skillId, int skillLevel) {
		SkillTemplate skillTpl = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		//不需要消耗，返回0
		if (skillTpl == null || skillTpl.getSkillCostType() == SkillCostType.NONE) {
			return 0;
		}
		//技能消耗=初始消耗+增量消耗*等级
		int cost = skillTpl.getCostBase() + skillLevel * skillTpl.getCostAdd();
		return cost;
	}
	
	public String getSkillCostAttrKey(int skillId, int skillLevel) {
		SkillTemplate skillTpl = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		return skillTpl.getSkillCostType().getAttrKey();
	}
	
	public int getSkillCostReportKey(int skillId, int skillLevel) {
		SkillTemplate skillTpl = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		return skillTpl.getSkillCostType().getReportKey();
	}

	/**
	 * 召唤宠物，战斗内召唤技能调用
	 * @param bp
	 * @param isAttacker
	 * @param roleId
	 * @param summonPetId
	 * @return
	 */
	public FightUnit summonPet(IBattle battle, boolean isAttacker, long roleId, long summonPetId) {
		if (roleId <= 0 || summonPetId <= 0) {
			return null;
		}
		if (!Globals.getTeamService().isPlayerOnline(roleId)) {
			return null;
		}
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (offlineData == null) {
			return null;
		}
		UserPetData summonPetData = offlineData.getPetData(summonPetId);
		if (summonPetData == null) {
			return null;
		}
		Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
		Pet pet = human.getPetManager().getNormalPetByUUID(summonPetId);
		if (pet.getPetType() != PetType.PET) {
			return null;
		}
		
		//召唤宠物的寿命、血量是否能出战
		//是否达到宠物携带等级
		int minLevel = summonPetData.getTemplate().getFightLevel();
		if (human.getLevel() < minLevel) {
			return null;
		}
		//宠物寿命值过低，寿命池也过低，不能被召唤
		if (summonPetData.getLife() < Globals.getGameConstants().getPetFightLifeMin()) {
			return null;
		}
		//宠物血量是否能被召唤
		if (summonPetData.getHp() <= Globals.getGameConstants().getBattleLeftMin()) {
			return null;
		}
		
		int battleIndex = 0;
		String id = "";
		FightUnit curPetFu = battle.getBattleFU(isAttacker, false, roleId);
		if (curPetFu != null) {
			//召唤的宠物不能是当前战斗中正在用的宠物
			if (curPetFu.getPetUUId() == summonPetId) {
				return null;
			}
			
			//战斗中删除该宠物
			battle.delFightUnit(curPetFu, isAttacker);
			
			//该宠物hp、mp、life更新
			onBattleEndPetPropUpdate(offlineData, curPetFu, false);
			human.sendMessage(PetMessageBuilder.buildGCPetCurPropUpdate(roleId, curPetFu.getPetUUId()));
			
			//当前有宠物，则用宠物的位置
			battleIndex = curPetFu.getPosition();
			id = curPetFu.getIdentifier();
		} else {
			//当前没有宠物，则根据主将位置生成新的
			int leaderPos = battle.getBattleFU(isAttacker, true, roleId).getPosition();
			battleIndex = leaderPos + BattleDef.PET_POS_DEFAULT - BattleDef.LEADER_POS_DEFAULT;
			id = UnitConvertor.genFighterId(battleIndex, isAttacker);
		}
		
		//根据Pet构建FightUnit
		PetPet summonPet = (PetPet) pet;
		FightUnit summonFightUnit = PetHelper.createFightUnit(summonPet, battleIndex, id, isAttacker);
		
		//放到BattleProcess中
		battle.addFightUnit(summonFightUnit, isAttacker);
		
		//当前宠物自动技能重置
		human.setPetAutoFightAction(BattleDef.NORMAL_ATTACK_SKILL_ID);
		human.snapChangedProperty(true);
		
		return summonFightUnit;
	}
	
	/**
	 * 主将、宠物自动选择技能的策率，非手动战斗使用此策率
	 * @param fu
	 * @param round
	 * @return
	 */
	public boolean autoSelSkillForFightUnit(FightUnit fu, int round) {
		//只有主将和宠物可以这么选技能
		if (fu.getUnitType() != PetType.LEADER && fu.getUnitType() != PetType.PET) {
			return false;
		}
		
		//当前拥有的主动技能Id集合
		Set<Integer> hasSkillSet = fu.getSkillIdSet();
		
		Map<Integer, IArenaSkillWeightTpl> iMap = new HashMap<Integer, IArenaSkillWeightTpl>();
		boolean isLeader = fu.getUnitType() == PetType.LEADER;
		if (isLeader) {
			JobType jt = Globals.getOfflineDataService().getUserJobType(fu.getOwnerId());
			Map<Integer, ArenaLeaderSkillWeightTemplate> totalSkillMap = Globals.getTemplateCacheService().getArenaTemplateCache().getLeaderSkillWeightMap(jt);
			iMap.putAll(totalSkillMap); 
		} else {
			Map<Integer, ArenaPetSkillWeightTemplate> totalSkillMap = Globals.getTemplateCacheService().getAll(ArenaPetSkillWeightTemplate.class);
			iMap.putAll(totalSkillMap);
		}
		int selSkillId = randSelSkill(fu, round, hasSkillSet, iMap);
		
		fu.setSelSkillId(selSkillId);
		return true;
	}
	
	protected int randSelSkill(FightUnit fu, int round, Set<Integer> hasSkillSet, 
			Map<Integer, IArenaSkillWeightTpl> totalSkillMap) {
		int selSkillId = BattleDef.NORMAL_ATTACK_SKILL_ID;
		List<IArenaSkillWeightTpl> wFirstObjList = new ArrayList<IArenaSkillWeightTpl>();
		List<Integer> wFirstList = new ArrayList<Integer>();
		int wFirst = 0;
		List<IArenaSkillWeightTpl> wObjList = new ArrayList<IArenaSkillWeightTpl>();
		List<Integer> wList = new ArrayList<Integer>();
		int w = 0;
		
		for (Integer skillId : hasSkillSet) {
			IArenaSkillWeightTpl tpl = totalSkillMap.get(skillId);
			if (tpl == null) {
				continue;
			}
			//不能放的技能过滤掉
			if (!checkSkillCost(fu, skillId)) {
				continue;
			}
			//cd中的技能过滤掉
			if (fu.isSkillInCdRound(skillId, round)) {
				continue;
			}
			
			if (tpl.isFirst()) {
				wFirst += tpl.getWeight();
				wFirstObjList.add(tpl);
				wFirstList.add(wFirst);
			} else {
				w += tpl.getWeight();
				wObjList.add(tpl);
				wList.add(w);
			}
		}
		
		//先从优先释放的技能中随机，如果优先的没有，则从普通的里面随机
		if (!wFirstObjList.isEmpty()) {
			IArenaSkillWeightTpl tpl = RandomUtils.hitObject(wFirstList, wFirstObjList, wFirst);
			if (tpl != null) {
				selSkillId = tpl.getSkillId();
			}
		} else if (!wObjList.isEmpty()) {
			IArenaSkillWeightTpl tpl = RandomUtils.hitObject(wList, wObjList, w);
			if (tpl != null) {
				selSkillId = tpl.getSkillId();
			}
		}
		
		return selSkillId;
	}
	
	/**
	 * 检查技能消耗是否满足
	 * @param fu
	 * @param selSkillId
	 * @return
	 */
	public boolean checkSkillCost(FightUnit fu, int selSkillId) {
		if (!fu.hasSkill(selSkillId)) {
			return false;
		}
		
		SkillTemplate skillTpl = Globals.getTemplateCacheService().get(selSkillId, SkillTemplate.class);
		if (skillTpl == null) {
			return false;
		}
		
		//无需任何消耗就可以释放
		int cost = Globals.getBattleService().getSkillCostValue(selSkillId, fu.getSkillLevel(selSkillId));
		if (cost <= 0) {
			return true;
		}
		
		String attrKey = skillTpl.getSkillCostType().getAttrKey();
		//看是否达到释放技能所需的数值要求
		if (fu.getAttr(attrKey) >= cost) {
			return true;
		}
		return false;
	}
	
	/**
	 * 获取技能消耗不足的错误提示信息
	 * @param skillId
	 * @return
	 */
	public String getSkillCostError(int skillId) {
		SkillTemplate skillTpl = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		if (skillTpl != null) {
			return Globals.getLangService().readSysLang(LangConstants.BATTLE_SKILL_COST_FAIL, 
					Globals.getLangService().readSysLang(skillTpl.getSkillCostType().getLangId()), skillTpl.getName());
		}
		return "";
	}

	/**
	 * 点击战斗的加速
	 * @param human
	 * @param speed
	 */
	public void speedup(Human human, int speed) {
		if (human == null || human.getBattleManager() == null) {
			return;
		}
		//能否加速
		if (!canSpeedup(human)) {
			human.sendErrorMessage(LangConstants.BATTLE_SPEEDUP_FAIL,
					Globals.getGameConstants().getBattleReportSpeed2XLevel(),
					Globals.getTemplateCacheService().getVipTemplateCache().getBattleSpeedupVipLevel());
			return;
		}
		
		int curSpeed = human.getBattleManager().getSpeed();
		if (speed == curSpeed) {
			return;
		}
		
		//更新speed
		human.getBattleManager().setSpeed(speed);
		human.setModified();
		
		//离线数据更新
		Globals.getOfflineDataService().onBaseInfoChange(human);
		
		//通知前台
		noticeBattleSpeedup(human);
	}
	
	/**
	 * 能否使用战斗加速功能
	 * @param human
	 * @return
	 */
	public boolean canSpeedup(Human human) {
		//等级满足要求
		if (human.getLevel() >= Globals.getGameConstants().getBattleReportSpeed2XLevel()) {
			return true;
		}
		//或者vip满足要求
		if (Globals.getVipService().checkVipRule(human.getUUID(), VipFuncTypeEnum.BATTLE_SPEEDUP)) {
			return true;
		}
		
		return false;
	}
	
	public void noticeBattleSpeedup(Human human) {
		human.sendMessage(new GCBattleSpeedup(human.getBattleManager().getSpeed(), canSpeedup(human) ? 1 : 0));
	}
	
	/**
	 * 获取玩家的战斗速度，先从在线中取，然后缓存中，最后离线数据中取
	 * @param roleId
	 * @return
	 */
	public int getBattleSpeedByRoleId(long roleId) {
		int speed = 0;
		Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(roleId);
		if (human != null) {
			speed = human.getBattleManager().getSpeed();
		} else {
			//从离线中取
			UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(roleId);
			if (userSnap != null) {
				speed = userSnap.getBattleSpeed();
			}
		}
		return speed;
	}
	
	public void onShutDownServer() {
		//TODO 正常关闭服务器时，结束玩家正在进行的战斗
		//TODO 可能需要服务器自己跑自动战斗
		
	}
	
}