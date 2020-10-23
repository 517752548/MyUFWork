package com.imop.lj.gameserver.siegedemon;

import java.awt.Point;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.PetIslandService;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.siegedemon.SiegeDemonDef.SDMonsterType;
import com.imop.lj.gameserver.siegedemon.SiegeDemonDef.SiegeDemonType;
import com.imop.lj.gameserver.siegedemon.model.SiegeDemonEnterTmp;
import com.imop.lj.gameserver.siegedemon.model.SiegeDemonMonster;
import com.imop.lj.gameserver.siegedemon.model.SiegeDemonRecordBase;
import com.imop.lj.gameserver.siegedemon.model.SiegeDemonRecordHard;
import com.imop.lj.gameserver.siegedemon.model.SiegeDemonRecordNormal;
import com.imop.lj.gameserver.siegedemon.msg.GCSiegedemonAskEnterTeam;
import com.imop.lj.gameserver.siegedemon.msg.GCSiegedemonEnterTeam;
import com.imop.lj.gameserver.siegedemon.template.SiegeDemonTemplate;
import com.imop.lj.gameserver.task.template.QuestTemplate;
import com.imop.lj.gameserver.team.TeamBattleProcess;
import com.imop.lj.gameserver.team.TeamDef.TeamStatus;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;

public class SiegeDemonService implements InitializeRequired {
	
	/** 该活动是否开启的全局状态位 */
	protected static boolean OPEN = true;
	/** 能否进入的全局状态位 */
	protected static boolean ENTER = true;
	/**副本进度, 普通 */
	protected Map<Integer, SiegeDemonRecordNormal> normalTeamMap = Maps.newHashMap();
	/**副本进度, 困难*/
	protected Map<Integer, SiegeDemonRecordHard> hardTeamMap = Maps.newHashMap();
	/** 请求进入副本的临时数据 */
	protected Map<Long, SiegeDemonEnterTmp> enterTmpMap = Maps.newHashMap();
	
	@Override
	public void init() {

	}
	
	protected SiegeDemonRecordNormal getNormalTeamData(int teamId) {
		return normalTeamMap.get(teamId);
	}
	
	protected void addNormalTeamData(SiegeDemonRecordNormal data) {
		normalTeamMap.put(data.getTeamId(), data);
	}
	
	protected void removeNormalTeamData(int teamId) {
		normalTeamMap.remove(teamId);
	}
	
	protected boolean isInNormalTeam(int teamId) {
		return normalTeamMap.containsKey(teamId);
	}
	
	protected SiegeDemonRecordHard getHardTeamData(int teamId) {
		return hardTeamMap.get(teamId);
	}
	
	protected void addHardTeamData(SiegeDemonRecordHard data) {
		hardTeamMap.put(data.getTeamId(), data);
	}
	
	protected void removeHardTeamData(int teamId) {
		hardTeamMap.remove(teamId);
	}
	
	protected boolean isInHardTeam(int teamId) {
		return hardTeamMap.containsKey(teamId);
	}
	
	protected void removeData(SiegeDemonRecordBase data) {
		if (data instanceof SiegeDemonRecordNormal) {
			removeNormalTeamData(((SiegeDemonRecordNormal)data).getTeamId());
		}else if(data instanceof SiegeDemonRecordHard){
			removeHardTeamData(((SiegeDemonRecordHard)data).getTeamId());
		}
	}
	
	protected void addEnterTmpData(TeamMember member, int raidId) {
		this.enterTmpMap.put(member.getRoleId(), new SiegeDemonEnterTmp(
				member.getRoleId(), member.getTeam().getId(), raidId));
	}
	
	protected void removeEnterTmpData(long roleId) {
		this.enterTmpMap.remove(roleId);
	}
	
	protected SiegeDemonEnterTmp getSiegeDemonEnterTmp(long roleId) {
		return this.enterTmpMap.get(roleId);
	}

	
	protected boolean isNormalSiege(int siegeType) {
		return siegeType == SiegeDemonType.NORMAL.getIndex();
	}
	
	protected boolean isHardSiege(int siegeType) {
		return siegeType == SiegeDemonType.HARD.getIndex();
	}
	
	/**
	 * 队长请求进入组队副本
	 * @param human
	 * @param siegeType
	 */
	public void askEnterSiegeDemon(Human human, int siegeType) {
		//玩家能否进入副本
		if (!canEnterSiegeDemon(human, siegeType)) {
			return;
		}
		
		//通知队员，队长请求进入副本
		Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
		for (TeamMember member : team.getMemberMap().values()) {
			//记录临时数据，队伍申请进入副本了
			addEnterTmpData(member, siegeType);
			
			//给队员发消息，告知要进入副本了
			Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
			memberHuman.sendMessage(new GCSiegedemonAskEnterTeam(siegeType));
		}
	}
	
	protected boolean canEnterSiegeDemon(Human human, int siegeType) {
		if (!ENTER) {
			return false;
		}
		//活动是否开启中
		if (!isOpening()) {
			return false;
		}
		
		long roleId = human.getCharId();
		//玩家是否队长
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			//非队长，不能进副本
			human.sendErrorMessage(LangConstants.SIEGE_DEMON_NOT_LEADER);
			return false;
		}
		
		//队伍人数最低要求
		if (isNormalSiege(siegeType)) {
			if (team.getMemberNum() < Globals.getGameConstants().getSiegeDemonNormalMinMemNum()) {
				human.sendErrorMessage(LangConstants.SIEGE_DEMON_NOT_ENOUGH_MEMBER, 
						Globals.getGameConstants().getSiegeDemonNormalMinMemNum());
				return false;
			}
			
		}else if(isHardSiege(siegeType)){
			if (team.getMemberNum() < Globals.getGameConstants().getSiegeDemonHardMinMemNum()) {
				human.sendErrorMessage(LangConstants.SIEGE_DEMON_NOT_ENOUGH_MEMBER, 
						Globals.getGameConstants().getSiegeDemonHardMinMemNum());
				return false;
			}
		}
		
		//队伍是否已经在副本中
		if (isInNormalTeam(team.getId()) || isInHardTeam(team.getId())) {
			return false;
		}
		
		//队伍正在战斗，不能进入
		if (team.isInBattle()) {
			return false;
		}
		
		//对所有队员的要求
		for (TeamMember member : team.getMemberMap().values()) {
			//必须在线
			if (!Globals.getTeamService().isOnlineNow(member)) {
				team.noticeTeamMemberErrorMsg(LangConstants.SIEGE_DEMON_NOT_ONLINE_NOW, member.getName());
				return false;
			}
			//状态必须都是正常状态
			if (!Globals.getTeamService().isInTeamNormal(member.getRoleId())) {
				team.noticeTeamMemberErrorMsg(LangConstants.SIEGE_DEMON_NOT_VALID_STATUS, member.getName());
				return false;
			}
			//玩家等级是否满足
			if (isNormalSiege(siegeType)) {
				if (member.getLevel() < Globals.getGameConstants().getSiegeDemonNormalMinLevel()) {
					team.noticeTeamMemberErrorMsg(LangConstants.SIEGE_DEMON_NOT_VALID_LEVEL, member.getName());
					return false;
				}
			}else if(isHardSiege(siegeType)){
				if (member.getLevel() < Globals.getGameConstants().getSiegeDemonHardMinLevel()) {
					team.noticeTeamMemberErrorMsg(LangConstants.SIEGE_DEMON_NOT_VALID_LEVEL, member.getName());
					return false;
				}
			}
			
			Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
			
			//玩家不能是战斗中状态
			if (memberHuman.isInAnyBattle()) {
				team.noticeTeamMemberErrorMsg(LangConstants.SIEGE_DEMON_NOT_VALID_STATUS, member.getName());
				return false;
			}
		}
		
		return true;
	}
	
	/**
	 * 玩家是否还有进入副本的次数
	 * @param human
	 * @param siegeType
	 * @return
	 */
	public boolean hasEnterTimes(Human human, int siegeType) {
		BehaviorTypeEnum bt = null;
		if (isNormalSiege(siegeType)) {
			 bt = BehaviorTypeEnum.SIEGE_DEMON_NORMAL;
		}else if(isHardSiege(siegeType)){
			 bt = BehaviorTypeEnum.SIEGE_DEMON_HARD;
		}
		
		if (!human.getBehaviorManager().canDo(bt)) {
			return false;
		}
		return true;
	}
	
	
	public void answerEnterSiegeDemon(Human human, int siegeType, boolean agree) {
		long roleId = human.getCharId();
		SiegeDemonEnterTmp enterTmp = getSiegeDemonEnterTmp(roleId);
		if (enterTmp == null) {
			return;
		}
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (team == null || team.getId() != enterTmp.getTeamId()) {
			removeEnterTmpData(roleId);
			return;
		}
		
		//设置结果
		enterTmp.setAgree(agree);
		
		//同意，则看是否都已经同意，是则进入副本
		if (agree) {
			boolean flag = true;
			//看队伍的其他人是否都已同意
			for (TeamMember member : team.getMemberMap().values()) {
				SiegeDemonEnterTmp memEnterTmp = getSiegeDemonEnterTmp(member.getRoleId());
				if (memEnterTmp != null && 
						!memEnterTmp.isAgree()) {
					flag = false;
					break;
				}
			}
			
			if (flag) {
				//队伍进入副本
				Player leaderPlayer = Globals.getOnlinePlayerService().getPlayer(team.getLeader().getRoleId());
				if (leaderPlayer != null && leaderPlayer.getHuman() != null && leaderPlayer.isOnline()) {
					enterSiegeDemon(leaderPlayer.getHuman(), siegeType);
				} else {
					Loggers.siegeDemonLogger.error("team leader is not online now!");
				}
			}
		} else {
			//拒绝，不能进入副本，删除临时数据
			for (TeamMember member : team.getMemberMap().values()) {
				//删除临时数据
				removeEnterTmpData(member.getRoleId());
				
				Player memberPlayer = Globals.getOnlinePlayerService().getPlayer(member.getRoleId());
				//通知其他人，该玩家拒绝进入副本
				if (memberPlayer == null || memberPlayer.getHuman() == null) {
					continue;
				}
				memberPlayer.getHuman().sendErrorMessage(LangConstants.SIEGE_DEMON_NOT_AGREE, human.getName());
			}
		}		
		
	}

	protected void enterSiegeDemon(Human human, int siegeType) {
		//玩家能否进入副本
		if (!canEnterSiegeDemon(human, siegeType)) {
			return;
		}
		
		int siegeMapId = Globals.getTemplateCacheService().getMapTemplateCache().getSiegeDemonMapId();
		long leaderId = human.getCharId();
		
		Team team = Globals.getTeamService().getHumanTeam(leaderId);
		for (TeamMember member : team.getMemberMap().values()) {
			//删除临时数据
			removeEnterTmpData(member.getRoleId());
			
			Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
			//可以重复进入,但不会获得活跃点
			//都同意了之后才可以领取任务
			if(isNormalSiege(siegeType)){
				if(memberHuman.getBehaviorManager().canDo(BehaviorTypeEnum.SIEGE_DEMON_NORMAL)){
					Globals.getSiegeDemonTaskService().acceptTask(memberHuman, siegeType);
				}
			}else if(isHardSiege(siegeType)){
				if(memberHuman.getBehaviorManager().canDo(BehaviorTypeEnum.SIEGE_DEMON_HARD)){
					Globals.getSiegeDemonTaskService().acceptTask(memberHuman, siegeType);
				}
			}
			
		}
		
		//设置队伍状态为活动中
		Globals.getTeamService().changeTeamStatus(team.getId(), TeamStatus.DOING_NO_AWAY);

		//队伍进入副本
		SiegeDemonRecordBase data = createTeamData(human, team, siegeType);
		
		//加入map
		if(isNormalSiege(siegeType)){
			addNormalTeamData((SiegeDemonRecordNormal)data);
		}else if(isHardSiege(siegeType)){
			addHardTeamData((SiegeDemonRecordHard)data);
		}
		
		//队长进入副本，队员会跟着进入
		Globals.getMapService().enterMap(human, siegeMapId);
		
		//动态生成第一只怪物
		refreshNewMonster(data);
		
		//发消息
		team.noticeTeamMember(new GCSiegedemonEnterTeam(siegeType), true, true);
	}
	
	protected SiegeDemonRecordBase createTeamData(Human human, Team team, int siegeType) {
		SiegeDemonRecordBase data = null;
		if (isNormalSiege(siegeType)) {
			data = new SiegeDemonRecordNormal();
			data.setTeamId(team.getId());
			data.setType(SiegeDemonType.NORMAL);
			long now = Globals.getTimeService().now();
			data.setEnterTime(now);
		}else if(isHardSiege(siegeType)){
			data = new SiegeDemonRecordHard();
			data.setTeamId(team.getId());
			data.setType(SiegeDemonType.HARD);
			long now = Globals.getTimeService().now();
			data.setEnterTime(now);
		}
		return data;
	}
	
	protected void refreshNewMonster(SiegeDemonRecordBase data) {
		List<SiegeDemonTemplate> monsterTplList = Globals.getTemplateCacheService().getSiegeDemonTemplateCache().getMonsterTplList(data.getType().getIndex());
		if(monsterTplList == null || monsterTplList.isEmpty()){
			return ;
		}
		
		//当前地图没有怪物时才能刷出新怪物
		if(data.getMonsterMap().isEmpty()){
			int monsterTplSize = monsterTplList.size();
			//战胜的怪物数量 和刷出的npc数组下标是一致的
			if(data.getWinMonsterNum() < monsterTplSize){
				genMonsterInMap(data,monsterTplList.get(data.getWinMonsterNum()).getSiegeNpcId(), SDMonsterType.valueOf(data.getWinMonsterNum() + 1), null);
			}
		}
	}
	
	protected boolean isLastMonster(SiegeDemonRecordBase data, List<SiegeDemonTemplate> monsterTplList) {
		return data.getWinMonsterNum() == monsterTplList.size();
	}
	
	protected SiegeDemonMonster genMonsterInMap(SiegeDemonRecordBase data, int npcId, SDMonsterType type, Point npcPoint) {
		if (npcPoint == null) {
			//随机地图中的一个点
			npcPoint = randNpcPos(data);
		}
		//构建npc
		NpcInfo npcInfo = PetIslandService.buildNpcInfo(data.getMap().getId(), npcId, npcPoint);
		//添加npc到地图中
		data.getMap().addNpc(npcInfo);
		//生成怪物
		SiegeDemonMonster monster = buildSiegeDemonMonster(npcInfo, type);
		//添加到副本中
		data.getMonsterMap().put(monster.getUuid(), monster);
		
		//通知玩家，刷出怪物了
		data.noticeMonster(npcId, type);
		
		return monster;
	}
	
	protected Point randNpcPos(SiegeDemonRecordBase data) {
		List<Integer> canPointList = new ArrayList<Integer>();
		//所有的点
		List<Integer> allPoint = Globals.getTemplateCacheService().getSiegeDemonTemplateCache().getAllPointList();
		canPointList.addAll(allPoint);
		//已经占用的点
		List<Integer> usedPointList = data.getMap().getAddNpcUsedPoint();
		canPointList.removeAll(usedPointList);
		
		//如果点不够用了，那就取重复的点
		if (canPointList.isEmpty()) {
			canPointList.addAll(allPoint);
			Loggers.siegeDemonLogger.warn("monster point maybe overlap!data=" + data);
		}

		int randKey = RandomUtil.nextEntireInt(0, canPointList.size() - 1);
		int hit = canPointList.get(randKey);
		Point point = new Point(AbstractGameMap.calcPointX(hit), AbstractGameMap.calcPointY(hit));
		return point;
	}
	
	protected SiegeDemonMonster buildSiegeDemonMonster(NpcInfo npcInfo, SDMonsterType type) {
		SiegeDemonMonster monster = new SiegeDemonMonster();
		monster.setUuid(npcInfo.getUuid());
		monster.setNpcId(npcInfo.getNpcId());
		monster.setType(type);
		return monster;
	}
	

	public void startNpcFight(Human human, NpcInfo npcInfo) {
		SiegeDemonRecordBase data = null;
		long roleId = human.getCharId();
		if (Globals.getTeamService().isInTeam(roleId)) {
			//组队
			Team team = Globals.getTeamService().getHumanTeam(roleId);
			if(team == null){
				return;
			}
			if (getNormalTeamData(team.getId()) != null) {
				data = getNormalTeamData(team.getId());
			}else if (getHardTeamData(team.getId()) != null){
				data = getHardTeamData(team.getId());
			}
			
			if(data == null){
				Loggers.siegeDemonLogger.error("siegeDemonData is null!teamId=" + team.getId() +";humanId" + human.getCharId());
				return;
			}
			
			//只有队长可以触发战斗，暂离状态的队员不可触发战斗
			if (!Globals.getTeamService().isTeamLeader(roleId) && 
					Globals.getTeamService().isAwayStatus(roleId)) {
				return;
			}
		} 
		
		//怪物是否存在
		SiegeDemonMonster monster = data.getMonster(npcInfo.getUuid());
		if (monster == null) {
			Loggers.siegeDemonLogger.error("monster not exist!roleId=" + roleId + ";npcInfo=" + npcInfo);
			return;
		}
		
		//与npc战斗
		Globals.getMapService().mapFightNpc(human, npcInfo, false);		
	}
	

	public void onBattleEnd(BattleProcess bp, String npcUUID, boolean isAttackerWin, boolean isForceEnd) {
		//取副本数据
		SiegeDemonRecordBase data = null;
		if(bp instanceof TeamBattleProcess){
			TeamBattleProcess bpTeam = (TeamBattleProcess) bp;
			data = getNormalTeamData(bpTeam.getTeam().getId());
			if(data == null){
				data = getHardTeamData(bpTeam.getTeam().getId());
			}
		}
		
		if(data == null){
			Loggers.siegeDemonLogger.error("siegeDemonData is null!bp=" + bp + ";attackerId=" + bp.getAttackerId());
			return;
		}
		
		//设置怪物的battleId为0
		NpcInfo npc = data.getMap().getAddNpc(npcUUID);
		if(npc == null){
			Loggers.siegeDemonLogger.error("npc is null!bp=" + bp + 
					";attackerId=" + bp.getAttackerId() + ";npcUUID=" + npcUUID);
			return;
		}
		npc.setBattleId(0);

		//如果攻击方胜利,则地图移除怪物,副本中设置怪物为死亡状态
		if(isAttackerWin){
			//删除怪物对象
			SiegeDemonMonster monster = data.removeMonsterMap(npcUUID);
			if(monster == null){
				Loggers.siegeDemonLogger.error("monster is null!bp=" + bp + 
						";attackerId=" + bp.getAttackerId() + ";npcUUID=" + npcUUID);
				return;
			}
			
			//从地图移除npc
			data.getMap().removeAddNpc(npcUUID);
			//战胜怪物数量 + 1
			data.setWinMonsterNum(data.getWinMonsterNum() + 1);
			
			List<SiegeDemonTemplate> monsterTplList = Globals.getTemplateCacheService().getSiegeDemonTemplateCache().getMonsterTplList(data.getType().getIndex());
			if(monsterTplList == null || monsterTplList.isEmpty()){
				return ;
			}
			//如果是最后一只怪物且不是助战,则获得通关奖励,退出副本
			if(isLastMonster(data, monsterTplList)){
				
				this.giveRewardTeam(data, true, npc.getNpcId());
				
				//退出副本
				onSiegeDemonEnd(data);
			}else{
				//助战奖励
				this.giveRewardTeam(data, false, npc.getNpcId());
				
				//立即刷新出新的怪物
				refreshNewMonster(data);
			}
			
			//记录日志
			Loggers.siegeDemonLogger.info("data=" + data);
		}
		
		//记录日志
		Loggers.siegeDemonLogger.info("data=" + data + ";isAttackerWin=" + isAttackerWin);
	}

	
	public void giveRewardTeam(SiegeDemonRecordBase data, boolean isFinal, int monsterId) {
		if(data == null){
			Loggers.siegeDemonLogger.error("SiegeDemonRecordBase data is null!teamId=" + data);
			return;
		}
		int teamId = data.getTeamId();
		Team team = Globals.getTeamService().getTeam(teamId);
		if (team == null) {
			Loggers.siegeDemonLogger.error("team is null!teamId=" + teamId);
			return;
		}
		
		for (TeamMember member : team.getMemberList()) {
			giveReward(data.getType().getIndex(), member.getRoleId(), isFinal, data.getType().toString(), monsterId);
		}
	}
	
	
	protected void giveReward(int siegeType, long roleId, boolean isFinal, String source, int monsterId) {
		boolean giveRewardFlag = false;
		int rewardId = 0;
		Reward reward = null;
		//给助战奖励
		boolean isAssistReward = false;
		//玩家在线，直接给奖励
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			
			Globals.getSiegeDemonTaskService().finishTask(human, siegeType);
			
			//玩家自身有任务,不给助战奖励,给任务奖励
			if (canGetAssistReward(human, monsterId, siegeType)) {
				isAssistReward = true;
			}
			//最后一个npc且身上有该任务,则领取通关奖励
			if(isFinal && !isAssistReward){
				if (isNormalSiege(siegeType)) {
					rewardId = Globals.getGameConstants().getSiegeDemonNormalFinalRewardId();
				}else if (isHardSiege(siegeType)) {
					rewardId = Globals.getGameConstants().getSiegeDemonHardFinalRewardId();
				}
				reward = Globals.getRewardService().createReward(roleId, rewardId, source);
			}
			
			//助战奖励
			if(isAssistReward){
				if (isNormalSiege(siegeType)) {
					rewardId = Globals.getGameConstants().getSiegeDemonNormalAssistRewardId();
				}else if (isHardSiege(siegeType)) {
					rewardId = Globals.getGameConstants().getSiegeDemonHardAssistRewardId();
				}
				reward = Globals.getRewardService().createReward(roleId, rewardId, source);
			}
			
			if(rewardId == 0 || reward == null){
				// 记录错误日志
				Loggers.siegeDemonLogger.error("#SiegeDemonService#giveReward failed!uuid=" + 
						roleId + ";rewardId=" + rewardId + ";source=" + source);
				return;
			}
			
			giveRewardFlag = Globals.getRewardService().giveReward(human, reward, true);
			//通知玩家完成活动
			if (isFinal) {
				human.sendErrorMessage(LangConstants.SIEGE_DEMON_SUCCESS_FINISH);
			}
		} else {
			//玩家离线，给离线奖励
			giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.SIEGE_DEMON, reward, "");
		}
		if (!giveRewardFlag) {
			// 记录错误日志
			Loggers.siegeDemonLogger.error("#SiegeDemonService#giveReward failed!uuid=" + 
					roleId + ";rewardId=" + rewardId + ";source=" + source);
		}
	}
	
	
	protected boolean canGetAssistReward(Human human, int monsterId, int siegeType){
		if (isNormalSiege(siegeType)) {
			//跳过有该任务的玩家
			if (human.getSiegeDemonNormalTaskManager() != null
					&& human.getSiegeDemonNormalTaskManager().getCurTask() != null) {
				int questId = human.getSiegeDemonNormalTaskManager().getCurTask().getQuestId();
				QuestTemplate tpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
				if (tpl != null) {
					int targetNpcId = Integer.parseInt(tpl.getSpecialDestination().getParam2nd());
					if (monsterId == targetNpcId) {
						return false;
					}
				}
			} 
		}else if (isHardSiege(siegeType)) {
			//跳过有该任务的玩家
			if (human.getSiegeDemonHardTaskManager() != null
					&& human.getSiegeDemonHardTaskManager().getCurTask() != null) {
				int questId = human.getSiegeDemonHardTaskManager().getCurTask().getQuestId();
				QuestTemplate tpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
				if (tpl != null) {
					int targetNpcId = Integer.parseInt(tpl.getSpecialDestination().getParam2nd());
					if (monsterId == targetNpcId) {
						return false;
					}
				}
			} 
		}
		return true;
	}
	
	protected void onSiegeDemonEnd(SiegeDemonRecordBase data) {
		//看是否有正在进行的战斗，有则强制结束掉
		for (SiegeDemonMonster monster : data.getMonsterMap().values()) {
			NpcInfo npcInfo = data.getMap().getAddNpc(monster.getUuid());
			if (npcInfo == null) {
				continue;
			}
			int npcBattleId = npcInfo.getBattleId();
			if (npcBattleId > 0) {
				forceEndDoingFight(data, npcBattleId);
			}
		}
		
		//退出副本
		exitSiegeDemon(data);
		
		//删除副本数据
		removeData(data);
	}
	
	
	/**
	 * 检测是否需要强制结束正在进行的战斗
	 * @param data
	 * @param npcBattleId
	 */
	protected void forceEndDoingFight(SiegeDemonRecordBase data, int npcBattleId) {
		if (npcBattleId <= 0) {
			return;
		}
		
		if (data.getType() == SiegeDemonType.NORMAL) {
			//组队
			Team team = Globals.getTeamService().getTeam(((SiegeDemonRecordNormal)data).getTeamId());
			if(team != null){
				//队伍正在与npc战斗
				//队员自己不可以 和npc战斗
				if (team.getCurBattleId() == npcBattleId) {
					Globals.getTeamService().getTeamBattleLogic().forceEndBattle(
							Globals.getTeamService().getTeamBattleLogic().getBattle(team.getCurBattleId()), "SiegeDemonRecordNormalFight");
				}
			}
		}
		
		if (data.getType() == SiegeDemonType.HARD) {
			//组队
			Team team = Globals.getTeamService().getTeam(((SiegeDemonRecordHard)data).getTeamId());
			if(team != null){
				//队伍正在与npc战斗
				//队员自己不可以 和npc战斗
				if (team.getCurBattleId() == npcBattleId) {
					Globals.getTeamService().getTeamBattleLogic().forceEndBattle(
							Globals.getTeamService().getTeamBattleLogic().getBattle(team.getCurBattleId()), "SiegeDemonRecordHardFight");
				}
			}
		}
		
	}
	
	/**
	 * 获得围剿魔族副本地图
	 * @param roleId
	 * @return
	 */
	public AbstractGameMap getGameMap(long roleId) {
		if (!isOpening()) {
			return null;
		}
		AbstractGameMap map = null;
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (team != null) {
			if (getNormalTeamData(team.getId()) != null) {
				map = getNormalTeamData(team.getId()).getMap();
			}else if (getHardTeamData(team.getId()) != null){
				map = getHardTeamData(team.getId()).getMap();
			}
		}
		return map;
	}

	public void exitSiegeDemon(SiegeDemonRecordBase data) {
		int teamId = data.getTeamId();
		Team team = Globals.getTeamService().getTeam(teamId);
		if (team == null) {
			Loggers.siegeDemonLogger.warn("exitSiegeDemon team is null!teamId=" + 
					teamId + ",maybe team already dismissed.");
			return;
		}
		
		//设置队伍状态为普通
		Globals.getTeamService().changeTeamStatus(team.getId(), TeamStatus.NORMAL);
		
		//地图所有人离开，回到备用地图
		Globals.getMapService().allPlayerToBackMap(data.getMap());
	}

	
	public boolean isOpening() {
		return OPEN;
	}

	/**
	 * 玩家点击离开副本
	 * @param human
	 */
	public void leaveSiegeDemon(Human human) {
		//战斗中不能离开
		if (human.isInAnyBattle()) {
			return;
		}
		
		long roleId = human.getCharId();
		//非组队状态可以会强制退出副本
		//组队的话，只有队长可以点离开副本
		boolean isLeader = Globals.getTeamService().isTeamLeader(roleId);
		if (!isLeader) {
			human.sendErrorMessage(LangConstants.SIEGE_DEMON_NOT_PERMIT);
			return;
		}
		
		//队伍退出副本
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (team != null 
			&& isInNormalTeam(team.getId())) {
			//退出普通副本
			if(getNormalTeamData(team.getId()) != null){
				onSiegeDemonEnd(getNormalTeamData(team.getId()));
			}
		}
		if (team != null 
			&& isInHardTeam(team.getId())) {
			//退出困难副本
			if(getHardTeamData(team.getId()) != null){
				onSiegeDemonEnd(getHardTeamData(team.getId()));
			}
		}
	}

	/**
	 * 队伍中的队员离队时，退出副本
	 * @param roleId
	 * @param teamId
	 */
	public void onTeamMemberLeave(long roleId, int teamId, boolean isLast) {
		//玩家所在的队伍在副本中，则玩家单独退出副本
		if (isInNormalTeam(teamId)) {
			SiegeDemonRecordBase data = getNormalTeamData(teamId);
			if(data == null){
				return;
			}
			//队员退出副本地图，在队伍被清除之前调用，否则找不到之前的地图
			leaveSiegeDemonMap(roleId, data);
			
			//如果是队伍最后一个人，则删除副本数据
			if (isLast) {
				onSiegeDemonEnd(data);
			}
		}else if(isInHardTeam(teamId)){
			SiegeDemonRecordBase data = getHardTeamData(teamId);
			if(data == null){
				return;
			}
			//队员退出副本地图，在队伍被清除之前调用，否则找不到之前的地图
			leaveSiegeDemonMap(roleId, data);
			
			//如果是队伍最后一个人，则删除副本数据
			if (isLast) {
				onSiegeDemonEnd(data);
			}
		}
		
		
	}
	
	/**
	 * 离开副本地图
	 * @param roleId
	 * @param teamData
	 */
	protected void leaveSiegeDemonMap(long roleId, SiegeDemonRecordBase teamData) {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player != null && player.getHuman() != null && player.isInScene()) {
			//如果玩家当前正在副本地图中
			if (player.getHuman().getMapId() == Globals.getTemplateCacheService().getMapTemplateCache().getSiegeDemonMapId()) {
				//玩家在线，则回到之前的地图，这里如果是组队需要传入地图，因为玩家离队后取不到地图了
				Globals.getMapService().enterMap(player.getHuman(), 
						player.getHuman().getBackMapId(), player.getHuman().getBackX(), player.getHuman().getBackY(),
						teamData != null ? teamData.getMap() : null);
			}
		}
	}
	
}
