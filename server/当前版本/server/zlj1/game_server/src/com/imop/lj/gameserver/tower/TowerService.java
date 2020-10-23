package com.imop.lj.gameserver.tower;

import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.db.model.TowerEntity;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.team.TeamBattleProcess;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.tower.model.TowerRecordTeam;
import com.imop.lj.gameserver.tower.template.TowerMapTemplate;
import com.imop.lj.gameserver.tower.template.TowerRewardTemplate;

public class TowerService implements InitializeRequired {
	
	/** 该活动是否开启的全局状态位 */
	protected static boolean OPEN = true;

	/** Map<通天塔层数,通天塔该层信息>*/
	protected Map<Integer, Tower> towerMap = Maps.newHashMap();
	
	/** 副本进度数据，组队 */
	protected Map<Integer, TowerRecordTeam> teamMap = Maps.newHashMap();
	
	protected void addTowerMap(Tower t) {
		towerMap.put(t.getTowerLevel(), t);
	}
	
	protected Tower getTowerByLevel(int towerLevel) {
		if(towerMap.containsKey(towerLevel)){
			return towerMap.get(towerLevel);
		}
		return null;
	}
	
	protected void removeTowerMap(Tower t){
		towerMap.remove(t.getTowerLevel());
	}
	
	@Override
	public void init() {
		//加载奖励
		Globals.getTemplateCacheService().getTowerTemplateCache().initShowRewardList();
		//加载数据到内存中
		List<TowerEntity> allList = Globals.getDaoService().getTowerDao().loadAllEntity();
        if (allList == null || allList.isEmpty()) {
            if (Loggers.towerLogger.isDebugEnabled()) {
                Loggers.towerLogger.debug("TowerService init() : allList size = 0");
            }
        }
        
        for(TowerEntity entity : allList){
        	Tower t = new Tower() ;
        	t.fromEntity(entity);
        	
        	addTowerMap(t);
        }
	}
	
	/**
	 * 是否可以挑战NPC
	 * @param human
	 * @param mapId
	 * @param npcInfo
	 */
	public void startNpcFight(Human human, int mapId, NpcInfo npcInfo) {
		//该玩家是否是队长
		if(!Globals.getTeamService().isTeamLeader(human.getCharId())){
			human.sendErrorMessage(LangConstants.TOWER_BATTLE_NOT_TEAM);
			return;
		}
		//挑战层数不可大于已闯的层数
		int towerLevel = Globals.getTemplateCacheService().getTowerTemplateCache().getTowerLevelByMapId(mapId);
		if(towerLevel <= 0){
			return;
		}
		if(human == null || human.getTowerManager() == null){
			return;
		}
		int curTowerLevel = human.getTowerManager().getCurTowerLevel();
		//只能递进的闯塔,不能跳过去
		if(towerLevel > curTowerLevel + 1){
			human.sendErrorMessage(LangConstants.TOWER_LEVEL_LIMIT, curTowerLevel,towerLevel - 1);
			return;
		}
		
		//这里考虑3种情况:
		//1. 队长队员都通过的情况
		//2. 队长队员全未通过
		//3. 队长未通过,队员通过 + 队长通过,队员未通过
		if(isPassNPC(human, mapId, true)){
			human.sendErrorMessage(LangConstants.TOWER_NPC_ALREADY_PASS);
			return;
		}else{
			Globals.getMapService().mapFightNpc(human, npcInfo, false);
		}
	}
	
	/**
	 * 战斗结束后的处理
	 * @param bp
	 * @param isAttackerWin
	 * @param isForceEnd
	 * @param npcInfo
	 */
	public void onNpcBattleEnd(BattleProcess bp, boolean isAttackerWin, boolean isForceEnd, NpcInfo npcInfo) {
		//参与战斗的每个玩家的处理
		if(bp instanceof TeamBattleProcess){
			TeamBattleProcess tbp = (TeamBattleProcess)bp;
			for (Long roleId : tbp.getBattleInfoMap().keySet()) {
				//战斗中途结束,只扣除双倍点,奖励全都没有
				if(isForceEnd){
					continue;
				}
				//1.状态判断
				if(!Globals.getTeamService().isPlayerOnline(roleId)){
					continue;
				}
				Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
				Human human = player.getHuman();
				//必须是组队状态
				if(!Globals.getTeamService().isInTeamNormal(roleId)){
					human.sendErrorMessage(LangConstants.TOWER_BATTLE_NOT_TEAM);
					continue;
				}
				
				TowerManager towerManager = human.getTowerManager();
				if(towerManager == null ){
					continue;
				}
				
				int towerLevel = towerManager.getCurTowerLevel();
				//挑战NPC成功
				if(isAttackerWin){
					int targetTowerLevel = 0;
					if(npcInfo != null){
						targetTowerLevel = Globals.getTemplateCacheService().getTowerTemplateCache().getTowerLevelByMapId(npcInfo.getMapId());
					}
					if(targetTowerLevel == 0){
						Loggers.towerLogger.error("TowerService#onNpcBattleEnd#TowerTemplateCache getTowerLevelByMapId result is 0!humanId=" + human.getCharId() +";mapId=" + human.getMapId());
						continue;
					}
					//助战奖励,这里有3种情况
					//1,A玩家2层,B玩家4层,此时AB玩家组队,
					//1.1,一起打3层,A当队长,A获得通关奖励,B获得助战奖励且不是通关,最后A层数变为3,B层数仍是4
					//1.2,一起打5层,B当队长,A获得助战奖励,B获得通关奖励,最后A的层数仍是2,B的层数为5
					//2,A,B玩家都是2层,一起打3层,此时A,B玩家获得通关奖励
					if(towerLevel + 1 == targetTowerLevel){
						//通关奖励
						TowerMapTemplate tpl = Globals.getTemplateCacheService().get(towerManager.getCurTowerLevel() + 1, TowerMapTemplate.class);
						if(tpl == null){
							continue;
						}
						Reward npcReward = Globals.getRewardService().createReward(roleId, tpl.getRewardId(),
								"gain npc reward by tower battle end.");
						if(!Globals.getRewardService().giveReward(human, npcReward, true)){
							Loggers.towerLogger.error("TowerService#battle npc win, but give npc reward is error!humanId=" + roleId);
							continue;
						}
						human.sendErrorMessage(LangConstants.NPC_BATTLE_OK);
						towerManager.setCurTowerLevel(towerManager.getCurTowerLevel() + 1);
						human.setModified();
					}else{
						//助战奖励
						human.sendErrorMessage(LangConstants.TOWER_ASSIST_REWARD);
						TowerRewardTemplate rewardTpl = Globals.getTemplateCacheService().getTowerTemplateCache().getTowerReward(human.getLevel());
						if(rewardTpl == null){
							continue;
						}
						Reward assistReward = Globals.getRewardService().createReward(roleId, rewardTpl.getAssistRewardId(),
								"gain assist reward by tower battle end.");
						if(!Globals.getRewardService().giveReward(human, assistReward, true)){
							Loggers.towerLogger.error("TowerService#battle npc win, but give assist reward is error!humanId=" + roleId);
							continue;
						}
					}
					
					//2. 存库
					int newTowerLevel = towerManager.getCurTowerLevel();
					Tower t = getTowerByLevel(newTowerLevel);
					//该层的最先击杀者为空
					if(t == null){
						//最先击杀者战报
						t = buildFirstKiller(bp, human, newTowerLevel);
						//同时更新最优击杀者
						buildBestKiller(bp, human, t);
						t.active();
						t.setModified();
						
						addTowerMap(t);
					}
					
					//根据 回合数 > 角色等级 > 战斗时间,跟新最优击杀者
					if(bp.getBattle().getRound() < t.getbRound()
							|| human.getLevel() < t.getbLevel()
							|| Math.abs(bp.getLastRoundEndTime() - bp.getLastRoundStartTime()) < t.getBattleDuration()){
						buildBestKiller(bp, human,t);
						t.setModified();
						
						addTowerMap(t);
					}
				}else{
					//挑战NPC失败
					human.sendErrorMessage(LangConstants.NPC_BATTLE_FAIL);
					continue;
				}
				
				//发送npc是否通关的状态,前台显示用
				human.sendMessage(TowerMsgBuilder.createGCTowerInfo(human));
			}
		}
	}
	


	protected void buildBestKiller(BattleProcess bp, Human human,Tower t) {
		long roleId = human.getCharId();
		t.setbCharId(roleId);
		t.setbRound(bp.getBattle().getRound());
		t.setbLevel(human.getLevel());
		t.setBattleDuration(Math.abs(bp.getLastRoundEndTime() - bp.getLastRoundStartTime()));
		t.setBestKiller(bp.getReportId()+"");
	}

	protected Tower buildFirstKiller(BattleProcess bp, Human human, int towerLevel) {
		long roleId = human.getCharId();
		Tower t = new Tower();
		t.setId(KeyUtil.UUIDKey());
		t.setTowerLevel(towerLevel);
		t.setfCharId(roleId);
		t.setfRound(bp.getBattle().getRound());
		t.setfLevel(human.getLevel());
		t.setBattleEndTime(bp.getLastRoundEndTime());
		t.setFirstKiller(bp.getReportId()+"");
		return t;
	}
	
	public boolean canOpenDouble(long roleId, int doublePoint){
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if(offlineData == null){
			return false;
		}
		
		//双倍经验点小于最小消耗值
		if(offlineData.getCurDoublePoint() < doublePoint){
			//双倍状态关闭
			offlineData.setIsOpenDouble(0);
			offlineData.setModified();
			return false;
		}
		
		return true;
	}
	
	/**
	 * 玩家是否打败该层的NPC
	 * @param human
	 * @param mapId
	 * @param isTeam
	 * @return
	 */
	public boolean isPassNPC(Human human, int mapId, boolean isTeam) {
		if(isTeam){
			if(!Globals.getTeamService().isInTeamNormal(human.getCharId())){
				human.sendErrorMessage(LangConstants.TOWER_BATTLE_NOT_TEAM);
				return false;
			}
		}
		//通过地图Id获得通天塔层数
		int towerLevel = Globals.getTemplateCacheService().getTowerTemplateCache().getTowerLevelByMapId(mapId);
		
		if(towerLevel <= 0){
			return false;
		}
		if(human == null || human.getTowerManager() == null){
			return false;
		}
		int curTowerLevel = human.getTowerManager().getCurTowerLevel();
		//判断当前玩家的层数是否小于该玩家所在地图的层数
		if(curTowerLevel < towerLevel){
			return false;
		}
		
		return true;
	}
	
	public boolean isOpening() {
		return OPEN;
	}

	/**
	 * 打开通天塔挂机面板
	 * @param human
	 */
	public void openTowerPanel(Human human) {
		human.sendMessage(TowerMsgBuilder.createGCTowerInfo(human));
	}

	/**
	 * 更新双倍状态
	 * @param human
	 */
	public void updateDoubleStatus(Human human, int flag) {
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
		if(offlineData == null){
			return;
		}
		int isOpenDouble = offlineData.getIsOpenDouble();
		if(offlineData.getCurDoublePoint() <= 0){
			human.sendErrorMessage(LangConstants.DOUBLE_POINT_IS_EMPTY);
			return;
		}
		//已经是打开状态,无需再打开
		if(flag == TowerDef.DoubleType.OPEN.getIndex() && isOpenDouble == TowerDef.DoubleType.OPEN.getIndex()){
			human.sendErrorMessage(LangConstants.ALREADY_OPEN_DOUBLE_STATUS);
			return;
		}
		//已经是关闭状态,无需再关闭
		if(flag == TowerDef.DoubleType.CLOSE.getIndex() && isOpenDouble == TowerDef.DoubleType.CLOSE.getIndex()){
			human.sendErrorMessage(LangConstants.ALREADY_CLOSE_DOUBLE_STATUS);
			return;
		}
		offlineData.setIsOpenDouble(flag);
		offlineData.setModified();
		human.sendMessage(TowerMsgBuilder.createGCTowerInfo(human));
	}
	
	/**
	 * 查看最先击杀者战报
	 * @param human
	 */
	public void watchFirstKillerReplay(Human human, int towerLevel) {
		Tower t = getTowerByLevel(towerLevel);
		if(t == null){
			human.sendErrorMessage(LangConstants.FIRST_KILLER_NOT_EXIST, towerLevel);
			return;
		}
		
		human.sendMessage(TowerMsgBuilder.createGCWatchFirstKillerReplay(human, t));
	}
	
	/**
	 * 查看最优击杀者战报
	 * @param human
	 */
	public void watchBestKillerReplay(Human human, int towerLevel) {
		Tower t = getTowerByLevel(towerLevel);
		if(t == null){
			human.sendErrorMessage(LangConstants.BEST_KILLER_NOT_EXIST, towerLevel);
			return;
		}
		
		human.sendMessage(TowerMsgBuilder.createGCWatchBestKillerReplay(human, t));
	}
	
	/**
	 * 查看通天塔奖励
	 * @param human
	 */
	public void sendTowerReward(Human human){
		human.sendMessage(TowerMsgBuilder.createGCTowerReward());
	}

	/**
	 * 队伍队员发生变化时的相关处理
	 * @param roleId
	 * @param teamId
	 * @param isLeader
	 */
	public void onTeamMemberChanged(long roleId, int teamId, boolean isLeader) {
		//队长切换,则判定新队长是否可挂机(打败NPC)
		if(isLeader){
			if(Globals.getTeamService().isPlayerOnline(roleId)){
				Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
				Team team = Globals.getTeamService().getTeam(teamId);
				if(team != null 
						&& Globals.getMapService().isTower(team.getMapId())){
					if(!this.isPassNPC(human, team.getMapId(), true)){
						team.noticeTeamMemberErrorMsg(LangConstants.NPC_TEAM_LEADER_NOT_PASS, human.getName());
					}else{
						team.noticeTeamMemberErrorMsg(LangConstants.TOWER_NEW_TEAM_LEADER, human.getName());
					}
					//旧队长需要停止跟随,否则会一直提示"组队状态,不能自由移动",这里前端处理了
//					human.sendMessage(TowerMsgBuilder.createGCStopGuaji(human));
				}
			}
		}
	}

	/**
	 * 判断玩家是否可以挂机
	 * @param human
	 * @param mapId
	 */
	public boolean canGuaji(Human human, int mapId){
		long roleId = human.getCharId();
		if(mapId != human.getMapId()){
			return false;
		}
		//其他地图上的挂机判断
		MapTemplate mapTpl = Globals.getTemplateCacheService().get(mapId, MapTemplate.class);
		if(mapTpl != null){
			if(mapTpl.getGuajiFlag() <= 0){
				human.sendErrorMessage(LangConstants.MAP_NOT_SUPPORT_GUAJI);
				return false;
			}
		}
		
		//通天塔地图
		if (Globals.getMapService().isTower(mapId)) {
			//组队情况,但不是队长
			if(Globals.getTeamService().isInTeamNormal(roleId)){
				if (!Globals.getTeamService().isTeamLeader(roleId)) {
					return false;
				}
				if (!isPassNPC(human, mapId, false)) {
					human.sendErrorMessage(LangConstants.NPC_TEAM_LEADER_NOT_PASS, human.getName());
					return false;
					
				}
			}else{
			//单人
				if(human.isInAnyBattle()){
					return false;
				}
				if (!isPassNPC(human, mapId, false)) {
					human.sendErrorMessage(LangConstants.NPC_LEADER_NOT_PASS);
					return false;
					
				}
				
			}
			
		}
		return true;
				
	}
	
	/**
	 * 玩家挂机操作
	 * @param human
	 */
	public void startGuaji(Human human, int mapId) {
		if(!canGuaji(human, mapId)){
			return;
		}
		human.sendMessage(TowerMsgBuilder.createGCGuaji(human, 1));
	}

	/**
	 * 通天塔层数是否有效
	 * @param towerLevel
	 * @return
	 */
	public boolean isValidTowerLevel(int towerLevel){
		//判断层数
		if(towerLevel < Globals.getTemplateCacheService().getTowerTemplateCache().getMinTowerLevel()
				|| towerLevel > Globals.getTemplateCacheService().getTowerTemplateCache().getMaxTowerLevel()){
			return false;
		}
		return true;
	}
	
	/**
	 * 是否是通天塔中的NPC
	 * @param npcId
	 * @return
	 */
	public boolean isNpcInTower(int npcId) {
		NpcTemplate npcTpl = Globals.getTemplateCacheService().get(npcId, NpcTemplate.class);
		if (npcTpl != null) {
			int enemyArmyId = npcTpl.getEnemyGroupId();
			EnemyArmyTemplate enemyArmyTpl = Globals.getTemplateCacheService().get(enemyArmyId, EnemyArmyTemplate.class);
			if (enemyArmyTpl != null && enemyArmyTpl.getIsTower() == 1) {
				return true;
			}
		}
		return false;
	}
}
