package com.imop.lj.gameserver.corpswar;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.corps.CorpsWarRankInfo;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.CorpsWarRankEntity;
import com.imop.lj.gameserver.activity.Activity;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityType;
import com.imop.lj.gameserver.allocate.AllocateActivityStorageBuilder;
import com.imop.lj.gameserver.allocate.model.AllocateActivityStorage;
import com.imop.lj.gameserver.allocate.model.AllocateMemberData;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.helper.IntIdHelper;
import com.imop.lj.gameserver.battle.helper.IntIdHelper.IntIdType;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsEventType;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsEvent;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.corps.msg.GCCorpswarInfo;
import com.imop.lj.gameserver.corps.msg.GCCorpswarRankList;
import com.imop.lj.gameserver.corpswar.model.CorpsWarCorps;
import com.imop.lj.gameserver.corpswar.model.CorpsWarGroup;
import com.imop.lj.gameserver.corpswar.model.CorpsWarMember;
import com.imop.lj.gameserver.corpswar.model.CorpsWarRank;
import com.imop.lj.gameserver.corpswar.template.CorpsWarRankRewardTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.team.TeamDef.TeamStatus;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;
import com.imop.lj.gameserver.team.model.TeamPlayerBattleInfo;
import com.imop.lj.gameserver.teampvp.TeamPvpBattleProcess;
import com.imop.lj.gameserver.title.TitleDef.TitleTemplateType;

public class CorpsWarService implements InitializeRequired {
	/** 军团战积分排行榜 */
	protected List<CorpsWarRank> rankList = new ArrayList<CorpsWarRank>();
	/** 军团成员比较器 */
	public static CorpsWarRankComparator rankSortor;

	/** 当前活动 */
	protected Activity curActivity;
	
	/** 参加军团战的军团Id集合Map<军团Id，军团信息> */
	protected Map<Long, CorpsWarCorps> joinCorpsSet = new HashMap<Long, CorpsWarCorps>();
	/** 军团战的各个组 Map<组id，组对象> */
	protected Map<Integer, CorpsWarGroup> groupMap = new HashMap<Integer, CorpsWarGroup>();
	
	/** 参加据军团战的军团成员Map<玩家id，玩家军团战数据> */
	protected Map<Long, CorpsWarMember> joinMemberMap = new HashMap<Long, CorpsWarMember>();
	
	public CorpsWarService() {
		rankSortor = new CorpsWarRankComparator();
	}

	@Override
	public void init() {
		loadRankList();
	}
	
	/**
	 * 加载军团战积分排行榜
	 */
	protected void loadRankList() {
		List<CorpsWarRankEntity> entityList = Globals.getDaoService().getCorpsWarRankDao().loadAllEntity();
		for (CorpsWarRankEntity entity : entityList) {
			CorpsWarRank rank = new CorpsWarRank();
			rank.fromEntity(entity);
			
			rankList.add(rank);
		}
		if (!rankList.isEmpty()) {
			rankSort(rankList);
		}
	}
	
	protected void rankSort(List<CorpsWarRank> sortList) {
		// 排序
		Collections.sort(sortList, rankSortor);
	}
	
	class CorpsWarRankComparator implements Comparator<CorpsWarRank> {
		@Override
		public int compare(CorpsWarRank o1, CorpsWarRank o2) {
			//先按rank排，rank相同按score排，score相同按id排
			if (o1.getRank() < o2.getRank()) {
				return -1;
			} else if (o1.getRank() > o2.getRank()) {
				return 1;
			} else {
				long result = o2.getScore() - o1.getScore();
				if (result > 0) {
					return 1;
				} else if(result < 0) {
					return -1;
				} else {
					if (o1.getId() < o2.getId()) {
						return -1;
					} else {
						return 1;
					}
				}
			}
		}
	}
	
	protected void addGroup(CorpsWarGroup group) {
		this.groupMap.put(group.getId(), group);
		for (Long corpsId : group.getCorpsIdSet()) {
			addJoinCorps(corpsId, group.getId());
		}
	}
	
	protected CorpsWarGroup getGroup(int groupId) {
		return this.groupMap.get(groupId);
	}
	
	protected boolean hasGroup(int groupId) {
		return this.groupMap.containsKey(groupId);
	}
	
	protected void addJoinCorps(long corpsId, int groupId) {
		CorpsWarCorps cwCorps = buildInitCorps(corpsId, groupId);
		this.joinCorpsSet.put(cwCorps.getCorpsId(), cwCorps);
	}
	
	protected void addJoinMember(CorpsWarMember member) {
		this.joinMemberMap.put(member.getRoleId(), member);
	}
	
	protected CorpsWarMember getJoinMember(long roleId) {
		return this.joinMemberMap.get(roleId);
	}
	
	protected boolean hasJoinMember(long roleId) {
		return this.joinMemberMap.containsKey(roleId);
	}
	
	protected CorpsWarMember removeJoinMember(long roleId) {
		return this.joinMemberMap.remove(roleId);
	}
	
	protected int getCorpsGroupId(long corpsId) {
		if (isCorpsIn(corpsId)) {
			return this.joinCorpsSet.get(corpsId).getGroupId();
		}
		return 0;
	}
	
	protected CorpsWarCorps getJoinCorps(long corpsId) {
		if (isCorpsIn(corpsId)) {
			return this.joinCorpsSet.get(corpsId);
		}
		return null;
	}
	
	protected boolean isCorpsIn(long corpsId) {
		return this.joinCorpsSet.containsKey(corpsId);
	}
	
	protected void clearAllData() {
		this.joinCorpsSet.clear();
		this.groupMap.clear();
		this.joinMemberMap.clear();
		
		//清除之前帮派竞赛的所有物品
		Globals.getAllocateActivityStorageService().delAllocateActivityStorageMap(ActivityType.CORPS_WAR.getIndex());
	}
	
	protected CorpsWarCorps buildInitCorps(long corpsId, int groupId) {
		return new CorpsWarCorps(corpsId, groupId);
	}
	
	/**
	 * 生成新的军团战数据
	 * @return
	 */
	protected boolean genCorpsWarData() {
		List<Corps> corpsList = chooseCorps();
		if (corpsList.isEmpty()) {
			//没有军团可参战
			Loggers.corpsWarLogger.warn("corpsList is empty,no corps can join corps war!");
			return false;
		}
		
		for (int i = 0; i < corpsList.size(); i += 2) {
			Set<Long> cSet = new HashSet<Long>();
			cSet.add(corpsList.get(i).getId());
			cSet.add(corpsList.get(i + 1).getId());
			
			//创建组对象
			CorpsWarGroup group = new CorpsWarGroup();
			//生成id
			genCorpsWarGroupId(group);
			group.setCorpsIdSet(cSet);
			
			//加入map
			addGroup(group);
			
			//打印日志
			Loggers.corpsWarLogger.info("match corps are " + 
			Globals.getCorpsService().getCorpsById(corpsList.get(i).getId()).getName() + " vs "
					+ Globals.getCorpsService().getCorpsById(corpsList.get(i + 1).getId()).getName());
		}
		
		return true;
	}
	
	protected void genCorpsWarGroupId(CorpsWarGroup group) {
		int id = IntIdHelper.genNextIntId(IntIdType.CORPSWAR_GROUP, this.groupMap.keySet());
		if (id == 0) {
			id = group.hashCode();
		}
		group.setId(id);
	}
	
	/**
	 * 选择可以参战的军团
	 * @return
	 */
	protected List<Corps> chooseCorps() {
		//满足条件的军团列表
		List<Corps> canCorpsList = new ArrayList<Corps>();
		
		//TODO 暂时先按照每次随机所有军团来，之后再按军团的一些参数排序来
		Collection<Corps> corpsCol = Globals.getCorpsService().getAllCorps();
		List<Corps> corpsList = new ArrayList<Corps>();
		corpsList.addAll(corpsCol);
		int count = corpsList.size();
		for (int i = 0; i < count; i++) {
			int index = RandomUtil.nextEntireInt(0, corpsList.size() - 1);
			Corps corps = corpsList.remove(index);
			if (isCorpsSatisfy(corps, true)) {
				canCorpsList.add(corps);
			}
		}
		
		//如果是奇数个军团，则最后一个移除掉
		if (canCorpsList.size() % 2 != 0 ) {
			Corps removeCorps = canCorpsList.remove(canCorpsList.size() - 1);
			Loggers.corpsWarLogger.warn("corps num is odd,remove last!removeCorpsId=" + removeCorps.getId());
		}
		
		return canCorpsList;
	}
	
	/**
	 * 检测 军团是否满足参战条件
	 * @param corps
	 * @param addMemberFlag
	 * @return
	 */
	protected boolean isCorpsSatisfy(Corps corps, boolean addMemberFlag) {
		//军团等级是否满足
		if (corps.getLevel() < Globals.getGameConstants().getCorpsWarMinCorpsLevel()) {
			return false;
		}
		
		//军团队员人数是否满足
		int num = 0;
		for (CorpsMember member : corps.getCorpsMemberManager().getCorpsMemberList()) {
			//队员等级条件
			if (member.getLevel() >= Globals.getGameConstants().getCorpsWarMemberMinLevel()) {
				//加入军团时间条件
				if (member.getJoinDate() < Globals.getTimeService().now() - Globals.getGameConstants().getCorpsWarMinJoinTime()) {
					num++;
					//如果需要 则将军团战队员信息加入map
					if (addMemberFlag) {
						addJoinMember(buildInitCorpsWarMember(member));
					}
				}
			}
		}
		if (num < Globals.getGameConstants().getCorpsWarMinMemberNum()) {
			return false;
		}
		
		return true;
	}
	
	protected CorpsWarMember buildInitCorpsWarMember(CorpsMember member) {
		CorpsWarMember cwMember = new CorpsWarMember(member.getCharId(), member.getCorpsId(), 
				Globals.getGameConstants().getCorpsWarInitScore(), member.getJob());
		return cwMember;
	}
	
	/**
	 * 开始组队pvp战斗
	 * @param human
	 * @param targetRoleId
	 */
	public void startTeamPvpFight(Human human, long targetRoleId) {
		//当前是否可战斗的阶段
		if (!isFightingState()) {
			human.sendErrorMessage(LangConstants.CORPSWAR_CAN_NOT_FIGHT);
			return;
		}
		//玩家是否在军团战地图中
		if (human.getMapId() != Globals.getTemplateCacheService().getMapTemplateCache().getCorpsWarMapId()) {
			return;
		}
		//目标玩家是否在线且在军团战地图中
		Player targetPlayer = Globals.getOnlinePlayerService().getPlayer(targetRoleId);
		if (targetPlayer != null && targetPlayer.getHuman() != null) {
			if (targetPlayer.getHuman().getMapId() != Globals.getTemplateCacheService().getMapTemplateCache().getCorpsWarMapId()) {
				return;
			}
		} else {
			//目标玩家不在线，不能打
			return;
		}
		
		long roleId = human.getCharId();
		//检查两个玩家在同一个军团战地图中
		AbstractGameMap humanMap = getGameMap(roleId);
		AbstractGameMap targetMap = getGameMap(targetRoleId);
		if (humanMap == null || targetMap == null || 
				!humanMap.equals(targetMap)) {
			return;
		}
		
		//检测两个玩家是否不是同一军团的
		if (getJoinMember(roleId).getCorpsId() == getJoinMember(targetRoleId).getCorpsId()) {
			return;
		}
		
		//目标队伍战斗中，给玩家错误提示信息
		Team targetTeam = Globals.getTeamService().getHumanTeam(targetRoleId);
		if (targetTeam != null && targetTeam.isInBattle()) {
			human.sendErrorMessage(LangConstants.CORPSWAR_GO_FIGHT_FAIL);
			return;
		}
		
		//调用组队pvp，里面会检测双方组队的情况
		int battleId = Globals.getTeamPvpService().startTeamPVPBattle(roleId, targetRoleId, BattleType.CORPS_WAR_TEAM_PVP);
		if (battleId <= 0) {
			Loggers.corpsWarLogger.error("battleId is invalid!humanId=" + roleId + ";targetRoleId=" + targetRoleId);
		}
	}
	
	/**
	 * 组队pvp战斗结束的处理
	 * @param bp
	 * @param isAttackerWin
	 */
	public void onBattleEnd(TeamPvpBattleProcess bp, boolean isAttackerWin) {
		//只处理军团战的
		if (bp.getBattleType() != BattleType.CORPS_WAR_TEAM_PVP) {
			return;
		}
		
		Set<Long> needKickOutSet = new HashSet<Long>();
		
		int scoreBase = Globals.getGameConstants().getCorpsWarFightScore();
		int lossScore = 0;
		
		Team lossTeam = isAttackerWin ? bp.getDefenderTeam() : bp.getAttackerTeam();
		Team winTeam = isAttackerWin ? bp.getAttackerTeam() : bp.getDefenderTeam();
		
		long lossCorpsId = 0;
		long winCorpsId = 0;
		
		//失败队员减分
		for (Long memberId : lossTeam.getMemberMap().keySet()) {
			TeamPlayerBattleInfo info = bp.getPlayerInfo(memberId);
			if (info == null) {
				continue;
			}
			
			CorpsWarMember cwMember = getJoinMember(info.getHumanId());
			if (cwMember != null) {
				lossCorpsId = cwMember.getCorpsId();
				lossScore += scoreBase;
				//战斗场数+1
				cwMember.setFightNum(cwMember.getFightNum() + 1);
				int newScore = cwMember.getScore() - lossScore;
				if (newScore < 0) {
					newScore = 0;
					needKickOutSet.add(cwMember.getRoleId());
				}
				//失败的人减分
				cwMember.setScore(newScore);
			} else {
				Loggers.corpsWarLogger.error("CorpsWarMember is null!bp1=" + bp);
			}
		}
		
		//胜利玩家Id集合
		Set<Long> winSet = new HashSet<Long>();
		for (Long memberId : winTeam.getMemberMap().keySet()) {
			TeamPlayerBattleInfo info = bp.getPlayerInfo(memberId);
			if (info == null) {
				continue;
			}
			if (getJoinMember(memberId) == null) {
				Loggers.corpsWarLogger.error("CorpsWarMember is null!bp2=" + bp);
				continue;
			}
			
			winSet.add(memberId);
		}
		
		//胜利队员加分
		int winAddScore = lossScore / winSet.size();
		//最少+1分
		if (winAddScore < 1) {
			winAddScore = 1;
		}
		for (Long winId : winSet) {
			CorpsWarMember cwMember = getJoinMember(winId);
			winCorpsId = cwMember.getCorpsId();
			//加分
			cwMember.setScore(cwMember.getScore() + winAddScore);
			//战斗场数+1
			cwMember.setFightNum(cwMember.getFightNum() + 1);
			//胜利场数+1
			cwMember.setWinNum(cwMember.getWinNum() + 1);
		}
		
		//踢出变为0分的玩家
		kickOutMember(needKickOutSet);
		
		//两个军团的积分变化
		updateCorpsShowScore(lossCorpsId);
		updateCorpsShowScore(winCorpsId);
		
		Loggers.corpsWarLogger.info("onBattleEnd needKickOutSet=" + needKickOutSet);
	}
	
	/**
	 * 将玩家踢出军团战
	 * @param needKickOutSet
	 */
	protected void kickOutMember(Set<Long> needKickOutSet) {
		if (needKickOutSet == null || needKickOutSet.isEmpty()) {
			return;
		}
		
		for (Long roleId : needKickOutSet) {
			if (hasJoinMember(roleId)) {
				//调用玩家退队的操作
				Globals.getTeamService().forceMemberLeaveTeam(roleId, "CorpsWarKickNoScore");
			}
		}
		
		Loggers.corpsWarLogger.warn("kickOutMemberOnNoScore needKickOutSet=" + needKickOutSet);
	}
	
	/**
	 * 离开军团战地图
	 * @param roleId
	 */
	protected void leaveCorpsWarMap(long roleId, CorpsWarMember cwMember) {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player != null && player.getHuman() != null && player.isInScene()) {
			//如果玩家当前正在军团战地图中
			if (player.getHuman().getMapId() == Globals.getTemplateCacheService().getMapTemplateCache().getCorpsWarMapId()) {
				//取玩家的军团战地图，这样就能正常离开该地图，否则会出现玩家离开了，但是前台显示还在的bug
				AbstractGameMap map = null;
				if (cwMember != null) {
					CorpsWarGroup group = getGroup(getCorpsGroupId(cwMember.getCorpsId()));
					if (group != null) {
						map = group.getMap();
					}
				}
				//玩家在线，则回到之前的地图
				boolean flag = Globals.getMapService().enterMap(player.getHuman(), player.getHuman().getBackMapId(), 
						player.getHuman().getBackX(), player.getHuman().getBackY(), map);
				//设置队伍状态为普通状态
				if (flag &&
						Globals.getTeamService().isTeamLeader(roleId)) {
					Team team = Globals.getTeamService().getHumanTeam(roleId);
					if (team.isDoing()) {
						Globals.getTeamService().changeTeamStatus(team.getId(), TeamStatus.NORMAL);
					}
				}
			}
		}
	}

	/**
	 * 军团战结束的处理
	 */
	protected void endCorpsWar() {
		//如果有正在进行的战斗，则强制结束掉
		forceEndAllBattle();
		
		//场景内的玩家回到原来的地图
		allPlayerToBackMap();
		
		//统计每个军团的总积分，按积分排名，出排行榜
		calcCorpsWarTotalScore();
		refreshRankList();
		
		//根据军团排名，每个参赛玩家发奖励
		giveCorpsWarReward();
		
		//根据帮派排名,发放待分配的奖励
		giveCorpsWarAllocateReward();
	}
	
	/**
	 * 给参加军团战的队员奖励
	 */
	protected void giveCorpsWarReward() {
		for (CorpsWarMember cwMember : joinMemberMap.values()) {
			//非有效玩家，不给奖励
			if (!isCorpsWarMemberValid(cwMember)) {
				continue;
			}
			
			long corpsId = cwMember.getCorpsId();
			int rank = getJoinCorps(corpsId).getRank();
			if (rank <= 0) {
				//军团没有进排行榜，没有奖励
				continue;
			}
			
			long roleId = cwMember.getRoleId();
			CorpsWarRankRewardTemplate tpl = calcRankRewardTpl(rank);
			if (tpl == null) {
				Loggers.corpsWarLogger.error("rank do not has reward!rank=" + rank + ";roleId=" + roleId);
				continue;
			}
			
			//发邮件奖励
			Reward reward = Globals.getRewardService().createReward(roleId, tpl.getRewardId(), "CorpsWarRank");
			Globals.getMailService().sendSysMail(roleId, MailType.SYSTEM, tpl.getMailTitle(), tpl.getMailContent(), reward);
		}
	}
	
	protected void giveCorpsWarAllocateReward() {
		//遍历所有参加竞赛的帮派
		for (CorpsWarCorps cwCorps : joinCorpsSet.values()) {
			long corpsId = cwCorps.getCorpsId();
			int rank = cwCorps.getRank();
			if (rank <= 0) {
				//军团没有进排行榜，没有奖励
				continue;
			}
			CorpsWarRankRewardTemplate tpl = calcAllocateRankRewardTpl(rank);
			if (tpl == null) {
				Loggers.corpsWarLogger.error("rank do not has reward!rank=" + rank);
				continue;
			}
			
			Map<Long, AllocateMemberData> allocateMemberMap = Maps.newHashMap();
			Reward reward = Globals.getRewardService().createReward(0L, tpl.getRewardId(), "giveCorpsWarAllocateReward");
			//遍历该帮派所有参赛的成员
			for (CorpsWarMember cwMember : joinMemberMap.values()) {
				//非有效玩家，不给奖励
				if (!isCorpsWarMemberValid(cwMember)) {
					continue;
				}
				//是否是同一个帮派
				if(corpsId != cwMember.getCorpsId()){
					continue; 
				}
				
				long roleId = cwMember.getRoleId();
				Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(roleId);
				if(human == null){
					continue;
				}
				
				AllocateMemberData data = AllocateActivityStorageBuilder.createAllocateMemberData(cwMember, human);
				allocateMemberMap.put(cwMember.getRoleId(), data);
			}
			//没有有效的玩家,则不创建活动奖励仓库
			if(allocateMemberMap.isEmpty()){
				continue;
			}
			//一个帮派的创建一个活动奖励仓库
			AllocateActivityStorage storage = AllocateActivityStorageBuilder.createAllocateActivityStorage(
					Globals.getUUIDService().getNextUUID(UUIDType.ALLOCATE_ACTIVITY_STORAGE),
					ActivityType.CORPS_WAR,
					corpsId,
					allocateMemberMap,
					reward);
			//存库
			storage.active();
			storage.setModified();
			
			//加入内存中
			Globals.getAllocateActivityStorageService().addAllocateActivityStorageMap(ActivityType.CORPS_WAR.getIndex(),corpsId, storage);
			
			// 生成军团事件
			CorpsEvent event = CorpsEvent.valueOf(CorpsEventType.WAR_RANK_ALLOCATE_REWARD, rank, reward.getRewardItemString());
			Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
			if(corps == null){
				return;
			}
			corps.addEvent(event);
			
		}
	}

	
	/**
	 * 根据排名得到对应的模块，因为最后一个区间的上限值很大，所以这里就不用缓存了，直接循环获取
	 * @param rank
	 * @return
	 */
	protected CorpsWarRankRewardTemplate calcRankRewardTpl(int rank) {
		CorpsWarRankRewardTemplate hitTpl = null;
		for (CorpsWarRankRewardTemplate tpl : Globals.getTemplateCacheService().getAll(CorpsWarRankRewardTemplate.class).values()) {
			if(tpl.getCanAlloate() == 1){
				continue;
			}
			if (rank >= tpl.getRankMin() && rank <= tpl.getRankMax()) {
				hitTpl = tpl;
				break;
			}
		}
		return hitTpl;
	}
	
	/**
	 * 根据排名得到对应的模块,可以分配
	 * @param rank
	 * @return
	 */
	protected CorpsWarRankRewardTemplate calcAllocateRankRewardTpl(int rank) {
		CorpsWarRankRewardTemplate hitTpl = null;
		for (CorpsWarRankRewardTemplate tpl : Globals.getTemplateCacheService().getAll(CorpsWarRankRewardTemplate.class).values()) {
			if(tpl.getCanAlloate() == 0){
				continue;
			}
			if (rank >= tpl.getRankMin() && rank <= tpl.getRankMax()) {
				hitTpl = tpl;
				break;
			}
		}
		return hitTpl;
	}
	
	/**
	 * 计算每个军团的总分
	 */
	protected void calcCorpsWarTotalScore() {
		for (CorpsWarMember cwMember : joinMemberMap.values()) {
			long corpsId = cwMember.getCorpsId();
			int score = cwMember.getScore();
			if (score <= 0) {
				continue;
			}
			//至少参加过n场战斗才算有效玩家
			if (!isCorpsWarMemberValid(cwMember)) {
				continue;
			}
			
			CorpsWarCorps cwCorps = getJoinCorps(corpsId);
			if (cwCorps == null) {
				Loggers.corpsWarLogger.error("cwCorps not exist!corpsId=" + corpsId + ";cwMemberId=" + cwMember.getRoleId());
				continue;
			}
			int newScore = cwCorps.getTotalScore() + score;
			cwCorps.setTotalScore(newScore);
		}
	}
	
	protected void updateCorpsShowScore(long corpsId) {
		CorpsWarCorps cwCorps = getJoinCorps(corpsId);
		if (cwCorps == null) {
			Loggers.corpsWarLogger.error("cwCorps not exist!corpsId=" + corpsId);
			return;
		}
		Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
		if (corps == null) {
			Loggers.corpsWarLogger.warn("corps not exist!corpsId=" + corpsId);
			return;
		}
		
		cwCorps.setShowScore(0);
		for (CorpsMember cMember : corps.getCorpsMemberManager().getCorpsMemberList()) {
			long roleId = cMember.getCharId();
			if (hasJoinMember(roleId)) {
				CorpsWarMember cwMember = getJoinMember(roleId);
				if (cwMember.getScore() <= 0) {
					continue;
				}
				if (!isCorpsWarMemberValid(cwMember)) {
					continue;
				}
				
				//积分累加
				cwCorps.setShowScore(cwCorps.getShowScore() + cwMember.getScore());
			}
		}
		
		//广播该军团的军团战玩家，军团积分变化
		noticeCorps(corpsId, buildGCCorpswarInfo(corpsId));
	}
	
	/**
	 * 给当前在军团战地图中的该军团玩家广播消息
	 * @param corpsId
	 * @param msg
	 */
	protected void noticeCorps(long corpsId, GCMessage msg) {
		Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
		if (corps == null) {
			return;
		}
		
		for (CorpsMember cMember : corps.getCorpsMemberManager().getCorpsMemberList()) {
			long roleId = cMember.getCharId();
			if (hasJoinMember(roleId) && 
					Globals.getTeamService().isPlayerOnline(roleId)) {
				Globals.getOnlinePlayerService().getPlayer(roleId).sendMessage(msg);
			}
		}
	}
	
	protected boolean isCorpsWarMemberValid(CorpsWarMember cwMember) {
		//至少参加过n场战斗才算有效玩家
		return cwMember.getFightNum() >= Globals.getGameConstants().getCorpsWarFightMinNum();
	}
	
	/**
	 * 刷新军团战排行榜数据
	 */
	protected void refreshRankList() {
		//创建排行榜对象
		List<CorpsWarRank> tmpRankList = new ArrayList<CorpsWarRank>();
		for (CorpsWarCorps cwCorps : joinCorpsSet.values()) {
			int score = cwCorps.getTotalScore();
			//积分为0的军团不参与排名
			if (score <= 0) {
				continue;
			}
			CorpsWarRank cwRank = buildInitCorpsWarRank(cwCorps.getCorpsId(), score);
			tmpRankList.add(cwRank);
		}
		
		//排序
		rankSort(tmpRankList);
		
		//排名第一的军团id
		long firstCorpsId = 0;
		//重置排名
		int rank = 1;
		for (CorpsWarRank cwRank : tmpRankList) {
			cwRank.setRank(rank);
			//存库
			cwRank.setModified();
			
			//更新军团排名
			getJoinCorps(cwRank.getCorpsId()).setRank(rank);
			if (rank == 1) {
				firstCorpsId = cwRank.getCorpsId();
			}
			
			rank++;
		}
		
		//排名的时候没人，记录一下日志
		if (tmpRankList.isEmpty()) {
			Loggers.corpsWarLogger.warn("corps war no ranklist,maybe no one join or all kicked!");
		}
		
		//删除旧的数据
		for (CorpsWarRank cwRank : this.rankList) {
			cwRank.onDelete();
		}
		
		//更新当前的排行榜
		this.rankList = tmpRankList;
		
		//排名第一的军团的额外处理
		if (firstCorpsId > 0) {
			giveFirstRankCorpsTitle(firstCorpsId);
		}
	}
	
	protected void giveFirstRankCorpsTitle(long corpsId) {
		//给排名第一的军团天下第一帮的称号
		Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
		if (corps == null) {
			return;
		}
		for (CorpsMember cMember : corps.getCorpsMemberManager().getCorpsMemberList()) {
			Globals.getTitleService().addTitleInfo(cMember.getCharId(), TitleTemplateType.FIRST_CORPS.getIndex());
		}
	}
	
	protected CorpsWarRank buildInitCorpsWarRank(long corpsId, int score) {
		CorpsWarRank cwRank = new CorpsWarRank();
		cwRank.setId(Globals.getUUIDService().getNextUUID(UUIDType.CORPSWAR_RANK));
		cwRank.setCorpsId(corpsId);
		cwRank.setScore(score);
		cwRank.setLastUpdateTime(Globals.getTimeService().now());
		cwRank.setRank(0);
		
		cwRank.setInDb(false);
		cwRank.active();
		
		return cwRank;
	}
	
	/**
	 * 强制结束所有正在进行的军团战战斗
	 */
	protected void forceEndAllBattle() {
		Set<Integer> allBattleIdSet = new HashSet<Integer>(); 
		allBattleIdSet.addAll(Globals.getTeamPvpService().getAllBattleIdSet());
		if (allBattleIdSet.isEmpty()) {
			return;
		}
		
		for (Integer battleId : allBattleIdSet) {
			TeamPvpBattleProcess bp = Globals.getTeamPvpService().getBattle(battleId);
			//只处理军团战的战斗
			if (bp.getBattleType() != BattleType.CORPS_WAR_TEAM_PVP) {
				continue;
			}
			
			//强制结束战斗
			Globals.getTeamPvpService().forceEndBattle(bp, "CorpsWar end forceEnd!");
		}
	}
	
	/**
	 * 军团战地图内所有玩家退出本地图，回到原地图
	 */
	protected void allPlayerToBackMap() {
		//TODO FIXME 这里可能有问题，队员离开会失败
		for (Long roleId : joinMemberMap.keySet()) {
			leaveCorpsWarMap(roleId, null);
		}
	}
	
	protected int getCorpsScore(long corpsId) {
		int score = 0;
		if (isCorpsIn(corpsId)) {
			score = getJoinCorps(corpsId).getShowScore();
		}
		return score;
	}
	
	/**
	 * 组队队长请求进入军团战地图
	 * @param human
	 */
	public void enterCorpsWar(Human human) {
		//只有准备中状态可以进入地图
		if (!isReady()) {
			if (isFightingState()) {
				human.sendErrorMessage(LangConstants.CORPSWAR_CANNOT_ENTER);
			} else {
				human.sendErrorMessage(LangConstants.CORPSWAR_NOT_OPEN);
			}
			return;
		}
		
		long roleId = human.getCharId();
		//玩家是否在军团中
		long corpsId = Globals.getCorpsService().getUserCorpsId(roleId);
		if (corpsId <= 0) {
			return;
		}
		//军团是否可参战
		if (!isCorpsIn(corpsId)) {
			human.sendErrorMessage(LangConstants.CORPSWAR_CORPS_NOT_JOIN);
			return;
		}
		//玩家是否队长
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			return;
		}
		
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		for (TeamMember tm : team.getMemberMap().values()) {
			//队伍所有队员是否同一个军团的
			if (Globals.getCorpsService().getUserCorpsId(tm.getRoleId()) != corpsId) {
				return;
			}
			//队伍所有队员是否都在joinMember集合中
			if (!hasJoinMember(tm.getRoleId())) {
				team.noticeTeamMemberErrorMsg(LangConstants.CORPSWAR_MEMBER_NOT_JOIN, tm.getName());
				return;
			}
			//状态必须都是正常状态
			if (!Globals.getTeamService().isInTeamNormal(tm.getRoleId())) {
				team.noticeTeamMemberErrorMsg(LangConstants.CORPSWAR_NOT_VALID_STATUS, tm.getName());
				return;
			}
		}
		
		//进入地图
		boolean flag = Globals.getMapService().enterMap(human, 
				Globals.getTemplateCacheService().getMapTemplateCache().getCorpsWarMapId());
		//设置队伍状态为活动中不可暂离
		if (flag) {
			Globals.getTeamService().changeTeamStatus(team.getId(), TeamStatus.DOING_NO_AWAY);
		}
		
		//队伍成员广播军团战信息
		team.noticeTeamMember(buildGCCorpswarInfo(corpsId), true, true);
	}
	
	protected GCCorpswarInfo buildGCCorpswarInfo(long corpsId) {
		return new GCCorpswarInfo(getCorpsScore(corpsId), getCorpsName(corpsId), getLeftTime(), getActivityState());
	}
	
	protected String getCorpsName(long corpsId) {
		String name = "";
		if (null != Globals.getCorpsService().getCorpsById(corpsId)) {
			name = Globals.getCorpsService().getCorpsById(corpsId).getName();
		}
		return name;
	}
	
	/**
	 * 组队队长请求离开军团战地图
	 * @param human
	 */
	public void leaveCorpsWar(Human human) {
		//只有准备中状态可以离开地图
		if (!isReady()) {
			human.sendErrorMessage(LangConstants.CORPSWAR_CAN_NOT_LEAVE);
			return;
		}
		
		//玩家是否队长
		if (!Globals.getTeamService().isTeamLeader(human.getCharId())) {
			return;
		}
		
		int corpsWarMapId = Globals.getTemplateCacheService().getMapTemplateCache().getCorpsWarMapId();
		//玩家当前地图id是否军团战的
		if (human.getMapId() != corpsWarMapId) {
			return;
		}
		
		//玩家回到之前的地图
		boolean flag = Globals.getMapService().enterMap(human, human.getBackMapId(), human.getBackX(), human.getBackY());
		//设置队伍状态为普通
		if (flag) {
			Globals.getTeamService().changeTeamStatus(
					Globals.getTeamService().getHumanTeam(human.getCharId()).getId(), TeamStatus.NORMAL);
		}
	}
	
	/**
	 * 队伍中的队员离队时，退出军团战地图
	 * @param roleId
	 * @param teamId
	 */
	public void onTeamMemberLeave(long roleId, int teamId, boolean isLast) {
		//活动是否开启中
		if (!isOpening()) {
			return;
		}
		if (hasJoinMember(roleId)) {
			CorpsWarMember cwMember = null;
			//如果当前处于活动中可交战状态，则退队就视为退出军团战
			if (isFightingState()) {
				//参战数据中移除玩家
				cwMember = removeJoinMember(roleId);
			} else {
				cwMember = getJoinMember(roleId);
			}
			//离开军团战地图
			leaveCorpsWarMap(roleId, cwMember);
		}
	}
	
	/**
	 * 玩家军团变更时，踢出玩家
	 * @param roleId
	 * @param isInCorps
	 */
	public void onPlayerCorpsChanged(long roleId, boolean isInCorps) {
		if (isInCorps) {
			return;
		}
		
		//玩家退出军团时，如果在军团战中，则强制踢出
		if (!hasJoinMember(roleId)) {
			return;
		}
		
		//踢出玩家
		Set<Long> kickSet = new HashSet<Long>();
		kickSet.add(roleId);
		kickOutMember(kickSet);
	}
	
	/**
	 * 获取玩家的军团战地图
	 * @param roleId
	 * @return
	 */
	public AbstractGameMap getGameMap(long roleId) {
		if (!isOpening()) {
			return null;
		}
		//玩家必须是组队状态
		if (!Globals.getTeamService().isInTeamNormal(roleId)) {
			return null;
		}
		
		AbstractGameMap map = null;
		//玩家是否在军团战成员集合中
		if (hasJoinMember(roleId)) {
			long curCorpsId = Globals.getCorpsService().getUserCorpsId(roleId);
			long corpsId = getJoinMember(roleId).getCorpsId();
			//玩家当前军团id和参加军团战时的必须一致
			if (curCorpsId == corpsId &&
					isCorpsIn(corpsId)) {
				CorpsWarGroup group = getGroup(getCorpsGroupId(corpsId));
				if (group != null) {
					map = group.getMap();
				}
			}
		}
		
		return map;
	}
	
	public void onPlayerLogin(Human human) {
		if (!isOpening()) {
			return;
		}
		
		long roleId = human.getCharId();
		if (!hasJoinMember(roleId)) {
			return;
		}
		
		if (human.getMapId() != Globals.getTemplateCacheService().getMapTemplateCache().getCorpsWarMapId()) {
			return;
		}
		
		//发军团战积分等消息
		sendCorpsWarInfoMsg(human);
	}
	
	public void sendCorpsWarInfoMsg(Human human) {
		if (human == null) {
			return;
		}
		//发军团战积分等消息
		human.sendMessage(buildGCCorpswarInfo(getJoinMember(human.getCharId()).getCorpsId()));
	}
	
	/**
	 * 发军团战排行榜消息
	 * @param human
	 */
	public void showRankList(Human human) {
		if (this.rankList.isEmpty()) {
			human.sendErrorMessage(LangConstants.CORPSWAR_RANK_ISEMPTY);
			return;
		}
		List<CorpsWarRankInfo> infoList = new ArrayList<CorpsWarRankInfo>();
		for (CorpsWarRank cwRank : this.rankList) {
			CorpsWarRankInfo info = buildCorpsWarRankInfo(cwRank);
			infoList.add(info);
		}
		
		human.sendMessage(new GCCorpswarRankList(infoList.toArray(new CorpsWarRankInfo[0])));
	}
	
	protected CorpsWarRankInfo buildCorpsWarRankInfo(CorpsWarRank cwRank) {
		CorpsWarRankInfo info = new CorpsWarRankInfo();
		info.setCorpsId(cwRank.getCorpsId());
		info.setName(getCorpsName(cwRank.getCorpsId()));
		info.setRank(cwRank.getRank());
		info.setScore(cwRank.getScore());
		return info;
	}
	
	/**************活动相关*****************/
	
	/**
	 * 活动是否开启，这里是 准备中或进行中状态
	 * @return
	 */
	public boolean isOpening() {
		return curActivity != null && 
				(curActivity.getState() == ActivityState.OPENING || curActivity.getState() == ActivityState.READY);
	}
	
	/**
	 * 活动是否处于可交战状态
	 * @return
	 */
	public boolean isFightingState() {
		return curActivity != null && curActivity.getState() == ActivityState.OPENING;
	}
	
	public boolean isReady() {
		return curActivity != null && curActivity.getState() == ActivityState.READY;
	}
	
	public long getLeftTime() {
		long leftTime = 0;
		if (isOpening()) {
			if (isReady()) {
				leftTime = this.curActivity.getTodayStartTime() - Globals.getTimeService().now();
			} else if (isFightingState()) {
				leftTime = this.curActivity.getTodayEndTime() - Globals.getTimeService().now();
			}
			if (leftTime < 0) {
				leftTime = 0;
			}
		}
		return leftTime;
	}
	
	public int getActivityState() {
		int state = 0;
		if (isOpening()) {
			state = this.curActivity.getState().getIndex();
		}
		return state;
	}
	
	public void handleActivityNoticeMsg(Activity curActivity) {
		// 活动状态不是提醒阶段，不能执行
		if (curActivity.getState() != ActivityState.NOT_OPEN) {
			return;
		}
		
		// 记录日志
		Loggers.corpsWarLogger.info("#CorpsWarService#handleActivityNoticeMsg#activity state=" + curActivity.getState());
	}
	
	public void handleActivityReadyMsg(Activity curActivity) {
		// 活动状态不是准备阶段，不能执行
		if (curActivity.getState() != ActivityState.READY) {
			return;
		}
		
		// 设置当前活动
		this.curActivity = curActivity;
		
		//清除之前的数据
		clearAllData();
		
		//生成新的数据
		genCorpsWarData();
		
		Loggers.corpsWarLogger.info("#CorpsWarService#handleActivityReadyMsg#OK.activity state=" + curActivity.getState());
	}
	
	public void handleActivityStartMsg(Activity curActivity) {
		// 活动状态不是开始阶段，不能执行
		if (curActivity.getState() != ActivityState.OPENING) {
			return;
		}
		
		Loggers.corpsWarLogger.info("#CorpsWarService#handleActivityStartMsg#OK.activity state=" + curActivity.getState());
	}
	
	public void handleActivityEndMsg() {
		// 活动状态不是结束阶段，不能执行
		if (this.curActivity.getState() != ActivityState.FINISHED) {
			return;
		}

		//军团战结束处理
		endCorpsWar();
		
		Loggers.corpsWarLogger.info("#CorpsWarService#handleActivityStartMsg#OK.activity state=" + curActivity.getState());
	
	}
}
