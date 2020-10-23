package com.imop.lj.gameserver.corpsboss;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.corps.CorpsBossCountRankInfo;
import com.imop.lj.common.model.corps.CorpsBossInfo;
import com.imop.lj.common.model.corps.CorpsBossRankInfo;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.CorpsBossCountRankEntity;
import com.imop.lj.db.model.CorpsBossRankEntity;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsEventType;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsEvent;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.corps.template.CorpsUpgradeTemplate;
import com.imop.lj.gameserver.corpsboss.model.CorpsBossEnterTmp;
import com.imop.lj.gameserver.corpsboss.template.CorpsBossCountRankTemplate;
import com.imop.lj.gameserver.corpsboss.template.CorpsBossRankTemplate;
import com.imop.lj.gameserver.corpsboss.template.CorpsBossTemplate;
import com.imop.lj.gameserver.enemy.EnemyParamContent;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.UserCorpsBossData;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.team.TeamDef;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

import java.util.*;
import java.util.Map.Entry;

public class CorpsBossService implements InitializeRequired {

	/** 该活动是否开启的全局状态位 */
	protected static boolean OPEN = true;
	
	/** 参加帮派boss的帮派Id集合Map<军团Id，帮派boss进度排名信息> */
	protected Map<Long,CorpsBossRank> bossRankMap = Maps.newHashMap(); 
	/** 参加帮派boss的帮派Id集合Map<军团Id，帮派boss挑战次数排名信息> */
	protected Map<Long,CorpsBossCountRank> bossCountRankMap = Maps.newHashMap(); 
	/** 帮派boss排行榜 */
	protected List<CorpsBossRank> rankList = new ArrayList<CorpsBossRank>();
	/** 帮派boss挑战次数排行榜 */
	protected List<CorpsBossCountRank> countRankList = new ArrayList<CorpsBossCountRank>();
	/** 帮派boss比较器 */
	protected CorpsBossRankComparator rankSortor = new CorpsBossRankComparator();
	/** 帮派boss挑战次数比较器 */
	protected CorpsBossCountRankComparator countRankSortor = new CorpsBossCountRankComparator();
	
	/** 请求挑战帮派boss的临时数据 */
	protected Map<Long, CorpsBossEnterTmp> enterTmpMap = Maps.newHashMap();

	@Override
	public void init() {
		//加载所有db中的数据
		List<CorpsBossRankEntity> lst = Globals.getDaoService().getCorpsBossRankDao().loadAllEntity();
		if (lst != null && !lst.isEmpty()) {
			for (CorpsBossRankEntity entity : lst) {
				CorpsBossRank rank = new CorpsBossRank();
				rank.fromEntity(entity);
				//加到map中
				addBossRankMap(rank);
			}
		}
		
		List<CorpsBossCountRankEntity> countLst = Globals.getDaoService().getCorpsBossCountRankDao().loadAllEntity();
		if (countLst != null && !countLst.isEmpty()) {
			for (CorpsBossCountRankEntity entity : countLst) {
				CorpsBossCountRank countRank = new CorpsBossCountRank();
				countRank.fromEntity(entity);
				//加到map中
				addBossCountRankMap(countRank);
			}
		}
		
		//初始化进度排行榜数据
		refreshBossRank(false, false);
		refreshBossCountRank(false, false);
		
	}
	
	public void addBossRankMap(CorpsBossRank cbr){
		bossRankMap.put(cbr.getCorpsId(), cbr);
	}
	
	public CorpsBossRank getBossRankMap(long corpsId){
		if(bossRankMap.containsKey(corpsId)){
			return bossRankMap.get(corpsId);
		}
		return null;
	}
	
	public void delBossRankMap(long corpsId){
		bossRankMap.remove(corpsId);
	}
	
	public void addBossCountRankMap(CorpsBossCountRank cbr){
		bossCountRankMap.put(cbr.getCorpsId(), cbr);
	}
	
	public CorpsBossCountRank getBossCountRankMap(long corpsId){
		if(bossCountRankMap.containsKey(corpsId)){
			return bossCountRankMap.get(corpsId);
		}
		return null;
	}
	
	public void delBossCountRankMap(long corpsId){
		bossCountRankMap.remove(corpsId);
	}
	
	protected void addEnterTmpData(TeamMember member, int level) {
		this.enterTmpMap.put(member.getRoleId(), new CorpsBossEnterTmp(
				member.getRoleId(), member.getTeam().getId(), level));
	}
	
	protected void removeEnterTmpData(long roleId) {
		this.enterTmpMap.remove(roleId);
	}
	
	protected CorpsBossEnterTmp getCorpsBossEnterTmp(long roleId) {
		return this.enterTmpMap.get(roleId);
	}
	
	/**
	 * 刷新玩家帮派boss进度排行榜
	 */
	protected void refreshBossRank(boolean saveFlag, boolean rankAll) {
		if (this.bossRankMap.isEmpty()) {
			return;
		}
		
		this.rankList.clear();
		this.rankList.addAll(bossRankMap.values());
		Collections.sort(this.rankList, rankSortor);
		
		int count = this.rankList.size();
		int rankCount = Globals.getGameConstants().getShowBossRankSize();
		for (int i = 0; i < count; i++) {
			CorpsBossRank cbr = this.rankList.get(i);
			
			//排行榜期间,帮派不存在了
			if(Globals.getCorpsService().getCorpsById(cbr.getCorpsId()) == null){
				continue;
			}
			int rank = i + 1;
			
			if (rankAll) {
				//更新排名
				cbr.setRank(rank);
			} else {
				if (rank <= rankCount) {
					//更新排名
					cbr.setRank(rank);
				} else {
					//榜外排名设置为0
					cbr.setRank(0);
				}
			}
			
			//存库
			if (saveFlag) {
				cbr.setModified();
			}
		}
		
		Loggers.corpsBossLogger.info("refreshBossRank saveFlag=" + saveFlag + ";rankAll=" + rankAll);
	}
	
	/**
	 * 刷新玩家帮派boss挑战次数排行榜
	 */
	protected void refreshBossCountRank(boolean saveFlag, boolean rankAll) {
		if (this.bossCountRankMap.isEmpty()) {
			return;
		}
		
		this.countRankList.clear();
		this.countRankList.addAll(bossCountRankMap.values());
		Collections.sort(this.countRankList, countRankSortor);
		
		int count = this.countRankList.size();
		int rankCount = Globals.getGameConstants().getShowBossCountRankSize();
		for (int i = 0; i < count; i++) {
			CorpsBossCountRank cbcr = this.countRankList.get(i);
			//排行榜期间,帮派不存在了
			if(Globals.getCorpsService().getCorpsById(cbcr.getCorpsId()) == null){
				continue;
			}
			int rank = i + 1;
			
			if (rankAll) {
				//更新排名
				cbcr.setRank(rank);
			} else {
				if (rank <= rankCount) {
					//更新排名
					cbcr.setRank(rank);
				} else {
					//榜外排名设置为0
					cbcr.setRank(0);
				}
			}
			
			//存库
			if (saveFlag) {
				cbcr.setModified();
			}
		}
		
		Loggers.corpsBossLogger.info("refreshBossCountRank saveFlag=" + saveFlag + ";rankAll=" + rankAll);
	}
	
	class CorpsBossRankComparator implements Comparator<CorpsBossRank> {
		@Override
		public int compare(CorpsBossRank o1, CorpsBossRank o2) {
			//BOSS进度>挑战回合数>帮派ID最靠前
			if(o1.getBossBestLevel() > o2.getBossBestLevel()){
				return -1;
			}else if(o1.getBossBestLevel() < o2.getBossBestLevel()){
				return 1;
			}else{
				if(o1.getBossKillRound() > o2.getBossKillRound()){
					return 1;
				}else if(o1.getBossKillRound() < o2.getBossKillRound()){
					return -1;
				}else{
					if(o1.getCorpsId() > o2.getCorpsId()){
						return 1;
					}else{
						return -1;
					}
				}
			}
		}
	}
	
	class CorpsBossCountRankComparator implements Comparator<CorpsBossCountRank> {
		@Override
		public int compare(CorpsBossCountRank o1, CorpsBossCountRank o2) {
			//帮派BOSS有效挑战次数最高>帮派等级最高>帮派ID最靠前
			if(o1.getBossKillCount() > o2.getBossKillCount()){
				return -1;
			}else if(o1.getBossKillCount() < o2.getBossKillCount()){
				return 1;
			}else{
				if(o1.getLevel() > o2.getLevel()){
					return -1;
				}else if(o1.getLevel() > o2.getLevel()){
					return 1;
				}else{
					if(o1.getCorpsId() > o2.getCorpsId()){
						return 1;
					}else{
						return -1;
					}
				}
			}
		}
	}

	
	/**
	 * 判断队伍是否可以参加帮派boss
	 * @param human
	 * @return
	 */
	protected boolean canStartCorpsBossFight(Human human, int targetBossLevel) {
	
		long roleId = human.getCharId();
		//玩家是否队长
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			//非队长，不能进副本
			human.sendErrorMessage(LangConstants.CORPS_BOSS_NOT_LEADER);
			return false;
		}
		
		Corps corps = Globals.getCorpsService().getUserCorps(roleId);
		if(corps == null){
			Loggers.corpsBossLogger.error("CorpsBossService#canStartCorpsBossFight# get corps is null!humanId = " + roleId);
			return false;
		}
		//帮派等级达到2级	
		int corpsLevel = corps.getLevel();
		if(corpsLevel < Globals.getGameConstants().getCorpsBossMinCorpsLevel()){
			human.sendErrorMessage(LangConstants.CORPS_LEVEL_NOT_ENOUGH, Globals.getGameConstants().getCorpsBossMinCorpsLevel());
			return false;
		}
		//成员3人以上组队	
		int memberNum = Globals.getTeamService().getHumanTeamMemberNum(roleId); 
		if(memberNum < Globals.getGameConstants().getCorpsBossMinMemberNum()){
			human.sendErrorMessage(LangConstants.MEMBER_NUM_NOT_ENOUGH, Globals.getGameConstants().getCorpsBossMinMemberNum());
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
				team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_NOT_ONLINE_NOW, member.getName());
				return false;
			}
			//状态必须都是正常状态
			if (!Globals.getTeamService().isInTeamNormal(member.getRoleId())) {
				team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_NOT_VALID_STATUS, member.getName());
				return false;
			}
			
			//玩家等级达到40级	
			int level = member.getLevel();
			if(level < Globals.getGameConstants().getCorpsBossMemberMinLevel()){
				team.noticeTeamMemberErrorMsg(LangConstants.MEMBER_LEVEL_NOT_ENOUGH, member.getName() ,Globals.getGameConstants().getCorpsBossMemberMinLevel());
				return false;
			}
			
			UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(member.getRoleId());
			if(offlineData == null){
				Loggers.corpsBossLogger.error("CorpsBossService#canStartCorpsBossFight#getUserOfflineData is null!humanId = " + member.getRoleId());
				return false;
			}
			
			//前置BOSS已完成,不可以跳级
			int curBossLevel = offlineData.getCorpsBossMaxLevel();
			if(curBossLevel + 1 < targetBossLevel){
				//第几章
				int chapter = getChapter(corps);
				CorpsBossTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsBossInfoByLevel(curBossLevel + 1);
				if(tpl == null){
					return false;
				}
				EnemyArmyTemplate enemyTpl = Globals.getTemplateCacheService().get(tpl.getEnemyArmyId(), EnemyArmyTemplate.class);
				if(enemyTpl == null){
					return false;
				}
				team.noticeTeamMemberErrorMsg(LangConstants.MEMBER_CORPS_LEVEL_NOT_ENOUGH, member.getName(), chapter, enemyTpl.getName());
				return false;
			}
			CorpsMember corpsMember = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(member.getRoleId());
			if(corpsMember == null){
				Loggers.corpsBossLogger.error("CorpsBossService#canStartCorpsBossFight#getCorpsMemberByRoleIdFromJoin is null!humanId = " + member.getRoleId());
				return false;
			}
			
			//加入帮派7天以上
			if(Globals.getTimeService().now() - corpsMember.getJoinDate() < Globals.getGameConstants().getCorpsBossMinJoinTime()){
				team.noticeTeamMemberErrorMsg(LangConstants.MEMBER_JOIN_DATE_IN_WEEK, member.getName());
				return false;
			}
			
			//玩家不能是战斗中状态
			Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
			if (memberHuman.isInAnyBattle()) {
				team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_NOT_VALID_STATUS, member.getName());
				return false;
			}
		}
		
		return true;
	}
	
	/**
	 * 查看帮派boss
	 * @param human
	 */
	public void sendCorpsBossInfo(Human human){
		long roleId = human.getCharId();
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if(offlineData == null){
			return;
		}
		List<CorpsBossInfo> lst = new ArrayList<CorpsBossInfo>();
		Map<Integer, UserCorpsBossData> bossMap = offlineData.getCorpsBossMap();
		int level = offlineData.getCorpsBossMaxLevel();
		UserCorpsBossData data = offlineData.getCorpsBossData(level);
		if(bossMap == null){
			return;
		}
		if(data == null){
			data = new UserCorpsBossData();
		}
		int allLevel = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsBossMaxLevel();
		//玩家第一次查看的时候
		if(data.getBossLevel() == 0){
			for(int i = 1;i <= allLevel;i++){
				CorpsBossInfo info = new CorpsBossInfo();
				info.setBossLevel(i);
				info.setBossRewardNum(getMaxOwnCorpsBossRewardNum(roleId));
				info.setWeekFight(0);
				lst.add(info);
			}
		}else{
			//玩家之前已经打过
			for(Entry<Integer, UserCorpsBossData> entry : bossMap.entrySet()){
				CorpsBossInfo info = new CorpsBossInfo();
				info.setBossLevel(entry.getKey());
				//传给前端的是可领次数
				info.setBossRewardNum(getMaxOwnCorpsBossRewardNum(roleId) - entry.getValue().getRewardNum());
				info.setWeekFight(1);
				lst.add(info);
			}
			//玩家没有打过的
			int fightedLevel = bossMap.size();
			for(int i = fightedLevel + 1;i <= allLevel;i++){
				CorpsBossInfo info = new CorpsBossInfo();
				info.setBossLevel(i);
				info.setBossRewardNum(getMaxOwnCorpsBossRewardNum(roleId));
				info.setWeekFight(0);
				lst.add(info);
			}
			
		}
		human.sendMessage(CorpsBossMsgBuilder.createGCCorpsBossInfo(human, lst));
		
	}
	
	public int getMaxOwnCorpsBossRewardNum(long roleId){
		return Globals.getGameConstants().getCorpsBossMaxRewardNum() +
				Globals.getVipService().getAddCountByVip(roleId, VipFuncTypeEnum.CORPS_BOSS_REWARD_MAX_NUM);
	}
	
	/**
	 * 队长请求挑战帮派boss
	 * @param human
	 * @param level
	 */
	public void askEnterCorpsBoss(Human human, int level) {
		//玩家能否挑战帮派boss
		if (!canStartCorpsBossFight(human, level)) {
			return;
		}
		Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
		
		//如果是周日的23:00-23:59,则不让打
		if(isSunDayCdTime()){
			team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_FIGHT_CD);
			return;
		}
		
		//通知队员，队长请求挑战帮派boss
		for (TeamMember member : team.getMemberMap().values()) {
			//记录临时数据，队伍申请挑战帮派boss了
			addEnterTmpData(member, level);
			
			//给队员发消息，告知要挑战帮派boss了
			Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
			memberHuman.sendMessage(CorpsBossMsgBuilder.createGCCorpsbossAskEnterTeam(level));
		}
	}
	
	/**
	 * 队员应答挑战帮派boss的请求
	 * @param human
	 * @param isAgree
	 */
	public void answerEnterCorpsBoss(Human human, boolean isAgree){
		long roleId = human.getCharId();
		CorpsBossEnterTmp enterTmp = getCorpsBossEnterTmp(roleId);
		if(enterTmp == null){
			return;
		}
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (team == null || team.getId() != enterTmp.getTeamId()) {
			removeEnterTmpData(roleId);
			return;
		}
		//设置结果
		enterTmp.setAgree(isAgree);
		int bossLevel = enterTmp.getBossLevel();
		
		//同意，则看是否都已经同意，是则开始挑战帮派boss
		if (isAgree) {
			boolean flag = true;
			//看队伍的其他人是否都已同意
			for (TeamMember member : team.getMemberMap().values()) {
				CorpsBossEnterTmp memEnterTmp = getCorpsBossEnterTmp(member.getRoleId());
				if (memEnterTmp != null && 
						!memEnterTmp.isAgree()) {
					flag = false;
					break;
				}
			}
			
			if (flag) {
				//队伍挑战帮派boss
				Player leaderPlayer = Globals.getOnlinePlayerService().getPlayer(team.getLeader().getRoleId());
				if (leaderPlayer != null && leaderPlayer.getHuman() != null && leaderPlayer.isOnline()) {
						startCorpsBossFight(leaderPlayer.getHuman(), bossLevel);
				} else {
					Loggers.corpsBossLogger.error("team leader is not online now!");
				}
			}
		} else {
			//拒绝，不能挑战帮派boss，删除临时数据
			for (TeamMember member : team.getMemberMap().values()) {
				//删除临时数据
				removeEnterTmpData(member.getRoleId());
				
				
				Player memberPlayer = Globals.getOnlinePlayerService().getPlayer(member.getRoleId());
				//通知其他人，该玩家拒绝挑战帮派boss
				if (memberPlayer == null || memberPlayer.getHuman() == null) {
					continue;
				}
				memberPlayer.getHuman().sendErrorMessage(LangConstants.CORPS_BOSS_NOT_AGREE, human.getName());
			}
		}
		
	}
	
	
	/**
	 * 打帮派boss
	 * @param human
	 * @param bossLevel
	 */
	protected void startCorpsBossFight(Human human, int bossLevel) {
		//获取到该层的怪物组
		CorpsBossTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsBossInfoByLevel(bossLevel);
		if(tpl == null){
			return;
		}

		long roleId = human.getCharId();
		EnemyParamContent epc = null;
		int sum = 0;
		if (Globals.getTeamService().canTriggerTeamBattle(roleId)) {
			Team team = Globals.getTeamService().getHumanTeam(roleId);
			sum = Globals.getTeamService().getMemberNumOfNormal(team.getId());
			//加上队长的伙伴的数量
			if (sum > TeamDef.MAX_TEAM_MEMBER_NUM) {
				sum = TeamDef.MAX_TEAM_MEMBER_NUM;
			}
			//用队伍的平均等级
			epc = new EnemyParamContent(tpl.getEnemyArmyId(), sum, team.getAvgLevel(), team.getMapId(), true, false);

			Fighter<?> attacker = new Fighter<Team>(BattleDef.FighterType.TEAM, team, true);
			Fighter<?> defender = Fighter.valueOf(BattleDef.FighterType.ENEMY, epc, false);
			//开始组队战斗
			Globals.getTeamService().getTeamBattleLogic().startTeamPVEBattle(human, team, BattleDef.BattleType.CORPS_BOSS, attacker, defender, null);
		}
	}
	
	/**
	 * 查看本帮的最高纪录
	 * @param human
	 */
	public void watchCorpsBossReplay(Human human) {
		Corps corps = Globals.getCorpsService().getUserCorps(human.getCharId());
		if(corps == null){
			return;
		}
		if(corps.getWeekBossLevelReplay().isEmpty()){
			human.sendErrorMessage(LangConstants.CORPSBOSS_BEST_REPLAY_NOT_EXIST);
		}else{
			//第几章
			int chapter = getChapter(corps);
			CorpsBossTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsBossInfoByLevel(corps.getWeekBossLevel());
			if(tpl == null){
				return;
			}
			EnemyArmyTemplate enemyTpl = Globals.getTemplateCacheService().get(tpl.getEnemyArmyId(), EnemyArmyTemplate.class);
			if(enemyTpl == null){
				return;
			}
			
			human.sendErrorMessage(LangConstants.CORPSBOSS_BEST_REPLAY, chapter, enemyTpl.getName(), corps.getWeekBossRound());
		}
		
	}

	protected int getChapter(Corps corps) {
		//每周的帮派boss等级清除后
		return corps.getWeekBossLevel() % Globals.getGameConstants().getChapterByCorpsBoss() == 0 
				&& corps.getWeekBossLevel() != 0
				? corps.getWeekBossLevel() / Globals.getGameConstants().getChapterByCorpsBoss()
				 : corps.getWeekBossLevel() / Globals.getGameConstants().getChapterByCorpsBoss() + 1;
	}

	
	/**
	 * 发帮派boss排行榜消息
	 * @param human
	 */
	public void showRankList(Human human) {
		if (this.rankList.isEmpty()) {
			human.sendErrorMessage(LangConstants.CORPSBOSS_RANK_ISEMPTY);
			return;
		}
		CorpsBossRank tmpCbr = this.rankList.get(0);
		//如果是本周,不发排行榜消息
		if(Globals.getGameConstants().getCorpsBossShowRankOnTimeSwtich() == 0){
			if(TimeUtils.isInSameWeek(tmpCbr.getLastUpdateTime(), Globals.getTimeService().now())){
				return;
			}
		}
		List<CorpsBossRankInfo> infoList = new ArrayList<CorpsBossRankInfo>();
		int count = Math.min(this.rankList.size(), Globals.getGameConstants().getShowBossRankSize());
		for (int i = 0; i < count; i++) {
			CorpsBossRank cbr = this.rankList.get(i);
			//帮派不存在了
			if(Globals.getCorpsService().getCorpsById(cbr.getCorpsId()) == null){
				continue;
			}
			infoList.add(this.buildCorpsBossRankInfo(cbr));
		}
		Corps corps = Globals.getCorpsService().getUserCorps(human.getCharId());
		CorpsBossRankInfo info = new CorpsBossRankInfo();
		if(corps == null){
			//无帮派玩家查看
			human.sendMessage(CorpsBossMsgBuilder.createGCCorpsbossRankList(info, infoList));
		}else{
			CorpsBossRank cbr = bossRankMap.get(corps.getId());
			if(cbr != null){
				//发送我的排名信息,榜外的话前端会处理
				info.setCorpsId(cbr.getCorpsId());
				info.setName(corps.getName());
				info.setRank(cbr.getRank());
				info.setBossLevel(cbr.getBossBestLevel());
				info.setReplay(cbr.getBossBestKiller());//改为战报id
				info.setRound(cbr.getBossKillRound());
			}
			
			human.sendMessage(CorpsBossMsgBuilder.createGCCorpsbossRankList(info, infoList));
		}
	}
	
	protected CorpsBossRankInfo buildCorpsBossRankInfo(CorpsBossRank cbRank) {
		CorpsBossRankInfo info = new CorpsBossRankInfo();
		info.setCorpsId(cbRank.getCorpsId());
		info.setName(getCorpsName(cbRank.getCorpsId()));
		info.setBossLevel(cbRank.getBossBestLevel());
		info.setRank(cbRank.getRank());
		info.setReplay(cbRank.getBossBestKiller());//改为战报id
		info.setRound(cbRank.getBossKillRound());
		return info;
	}
	
//	/**
//	 * 查看进度排行榜的某一战报
//	 * @param human
//	 */
//	public void watchCorpsBossRankReplay(Human human, int rank) {
//		Corps corps = Globals.getCorpsService().getUserCorps(human.getCharId());
//		String replay = "";
//		if(rank <= 0){
//			//未上榜玩家,查看自己帮派录像
//			replay = corps.getWeekBossLevelReplay();
//		}else{
//			CorpsBossRank cbr = this.rankList.get(rank - 1);
//			//榜内
//			if(cbr != null){
//				if(cbr.getBossBestKiller().isEmpty()){
//					human.sendErrorMessage(LangConstants.CORPS_BOSS_REPLAY_IS_ENPTY);
//				}
//				replay = cbr.getBossBestKiller();
//				
//			}
//			
//		}
//		Globals.getBattleReportService().sendBattleReportMsg(human, replay, 0L, false, false, BattleDef.BattleType.TEAM.getIndex(), "");
//	}
	
	
	/**
	 * 发帮派boss挑战次数排行榜消息
	 * @param human
	 */
	public void showCountRankList(Human human) {
		if (this.countRankList.isEmpty()) {
			human.sendErrorMessage(LangConstants.CORPSBOSS_COUNT_RANK_ISEMPTY);
			return;
		}
		CorpsBossCountRank tmpCbcr = this.countRankList.get(0);
		if(Globals.getGameConstants().getCorpsBossShowRankOnTimeSwtich() == 0){
			//如果是本周,不发生排行榜消息
			if (TimeUtils.isInSameWeek(tmpCbcr.getLastUpdateTime(), Globals.getTimeService().now())) {
				return;
			} 
		}
		List<CorpsBossCountRankInfo> infoList = new ArrayList<CorpsBossCountRankInfo>();
		int count = Math.min(this.countRankList.size(), Globals.getGameConstants().getShowBossCountRankSize());
		for (int i = 0; i < count; i++) {
			CorpsBossCountRank cbcRank = this.countRankList.get(i);
			//帮派不存在了
			if(Globals.getCorpsService().getCorpsById(cbcRank.getCorpsId()) == null){
				continue;
			}
			infoList.add(this.buildCorpsBossCountRankInfo(cbcRank));
		}
		
		Corps corps = Globals.getCorpsService().getUserCorps(human.getCharId());
		CorpsBossCountRankInfo info = new CorpsBossCountRankInfo();
		if(corps == null){
			//无帮派玩家查看
			human.sendMessage(CorpsBossMsgBuilder.buildCorpsBossCountRankInfo(info, infoList));
		}else{
			CorpsBossCountRank cbcr = bossCountRankMap.get(corps.getId());
			if(cbcr != null){
				//发送我的排名信息,榜外的话前端会处理
				info.setCorpsId(cbcr.getCorpsId());
				info.setName(corps.getName());
				info.setRank(cbcr.getRank());
				info.setCount(cbcr.getBossKillCount());
				info.setCurMemberCount(corps.getCurrMemNum());
				info.setMaxMemberCount(getMaxCorpsMemNum(cbcr.getCorpsId()));
				info.setPresidentName(corps.getPresidentName());
			}
			
			human.sendMessage(CorpsBossMsgBuilder.buildCorpsBossCountRankInfo(info, infoList));
		}
	}
	
	protected CorpsBossCountRankInfo buildCorpsBossCountRankInfo(CorpsBossCountRank cbcRank) {
		CorpsBossCountRankInfo info = new CorpsBossCountRankInfo();
		info.setCorpsId(cbcRank.getCorpsId());
		info.setName(getCorpsName(cbcRank.getCorpsId()));
		info.setRank(cbcRank.getRank());
		info.setCount(cbcRank.getBossKillCount());
		info.setPresidentName(getCorpsPresidentName(cbcRank.getCorpsId()));
		info.setCurMemberCount(getCurrCorpsMemNum(cbcRank.getCorpsId()));
		info.setMaxMemberCount(getMaxCorpsMemNum(cbcRank.getCorpsId()));
		return info;
	}
	
	protected String getCorpsName(long corpsId) {
		String name = "";
		if (null != Globals.getCorpsService().getCorpsById(corpsId)) {
			name = Globals.getCorpsService().getCorpsById(corpsId).getName();
		}
		return name;
	}
	
	protected String getCorpsPresidentName(long corpsId) {
		String name = "";
		if (null != Globals.getCorpsService().getCorpsById(corpsId)) {
			name = Globals.getCorpsService().getCorpsById(corpsId).getPresidentName();
		}
		return name;
	}
	protected int getCurrCorpsMemNum(long corpsId) {
		int num= 0;
		if (null != Globals.getCorpsService().getCorpsById(corpsId)) {
			num = Globals.getCorpsService().getCorpsById(corpsId).getCurrMemNum();
		}
		return num;
	}
	
	protected int getMaxCorpsMemNum(long corpsId) {
		int num = 0;
		Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
		if(null != corps){
			CorpsUpgradeTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsUpgradeTplByLevel(corps.getLevel());
			if(tpl != null){
				num = tpl.getMaxMemberNum();
			}
		}
		return num;
	}
	
	
	/**
	 * 一周刷新一次帮派boss进度排行榜
	 */
	public void refreshCorpsBossRankWeekly(String source) {
		//是否是本周,并且战斗cd时间已过
		if(!isSunDayTime()){
			return;
		}
		//重新根据帮派boss进度排名
		refreshBossRank(false, true);
		
		//10名
		int count = Math.min(this.rankList.size(), Globals.getGameConstants().getBossRankRewardSize());
		
		//发奖，然后将帮派的数据删除
		for (int i = 0;i < count;i++) {
			int rank = this.rankList.get(i).getRank();
			long corpsId = this.rankList.get(i).getCorpsId();
			Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
			if(corps == null){
				continue;
			}
			
			CorpsBossRankTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getBossRankInfoByRank(rank);
			if (tpl == null) {
				Loggers.corpsBossLogger.error("corps boss rank reward tpl is null!rank=" + rank);
				continue;
			}
			//可能超过指定排名没有奖励，所以这里判断奖励id是否大于0
			if (tpl.getRewardId() > 0) {
				//给帮派发奖励
				Reward reward = Globals.getRewardService().createCorpsReward(corpsId, tpl.getRewardId(), "refreshCorpsBossRankWeekly", null);
				// 生成军团事件
				CorpsEvent event = CorpsEvent.valueOf(CorpsEventType.BOSS_RANK_REWARD, rank, reward.getRewardString());
				corps.addEvent(event);
				
				boolean giveRewardFlag = Globals.getRewardService().giveCoprsReward(corpsId, reward, true);
				if (!giveRewardFlag) {
					// 记录错误日志
					Loggers.corpsBossLogger
							.error("CorpsBossService#refreshCorpsBossRankWeekly give reward error!corpsId=" + corpsId);
					return;
				}
			}
		}
		
		
		Loggers.corpsBossLogger.info("refreshCorpsBossRankWeekly end. source=" + source);
	}

	/**
	 * 当前时间是否是周日的冷却时间
	 */
	protected boolean isSunDayCdTime() {
		int curWeekDay = TimeUtils.getDayOfTheWeekNum(Globals.getTimeService().now());
		if(curWeekDay == Globals.getGameConstants().getCorpsBossRefreshDayOfWeek()){
			//当前时间处于冷却时间段23:00-23:59内,则不允许打
			if(TimeUtils.getHourTime(Globals.getTimeService().now()) == Globals.getGameConstants().getCorpsBossRefreshDayOfHour()){
				return true;
			}
		}
		return false;
	}
	
	/**
	 * 当前时间是否是周日
	 */
	protected boolean isSunDayTime() {
		int curWeekDay = TimeUtils.getDayOfTheWeekNum(Globals.getTimeService().now());
		if(curWeekDay == Globals.getGameConstants().getCorpsBossRefreshDayOfWeek()){
			return true;
		}
		return false;
	}
	
	
	/**
	 * 一周刷新一次帮派boss挑战次数排行榜
	 */
	public void refreshCorpsBossCountRankWeekly(String source) {
		//是否是本周,并且战斗cd时间已过
		if(!isSunDayTime()){
			return;
		}
		
		//重新根据帮派挑战次数排名
		refreshBossCountRank(false, true);
		
		//10名
		int count = Math.min(this.countRankList.size(), Globals.getGameConstants().getBossCountRankRewardSize());
		
		//发奖，然后将帮派的数据删除
		for (int i = 0;i < count;i++) {
			int rank = this.countRankList.get(i).getRank();
			long corpsId = this.countRankList.get(i).getCorpsId();
			Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
			if(corps == null){
				continue;
			}
			
			CorpsBossCountRankTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getBossCountRankInfoByRank(rank);
			if (tpl == null) {
				Loggers.corpsBossLogger.error("corps boss count rank reward tpl is null!rank=" + rank);
				continue;
			}
			//可能超过指定排名没有奖励，所以这里判断奖励id是否大于0
			if (tpl.getRewardId() > 0) {
				//给帮派发奖励
				Reward reward = Globals.getRewardService().createCorpsReward(corpsId, tpl.getRewardId(), "refreshCorpsBossCountRankWeekly", null);
				// 生成军团事件
				CorpsEvent event = CorpsEvent.valueOf(CorpsEventType.BOSS_COUNT_RANK_REWARD, rank, reward.getRewardString());
				corps.addEvent(event);
				boolean giveRewardFlag = Globals.getRewardService().giveCoprsReward(corpsId, reward, true);
				if (!giveRewardFlag) {
					// 记录错误日志
					Loggers.corpsBossLogger
							.error("CorpsBossService#refreshCorpsBossCountRankWeekly give reward error!corpsId=" + corpsId);
					return;
				}
			}
		}
		
		
		Loggers.corpsBossLogger.info("refreshCorpsBossCountRankWeekly end. source=" + source);
	}
	
	/**
	 * 战胜帮派boss后的奖励
	 * @param roleId
	 * @param eaTpl
	 * @param mapId
	 * @param bp
	 */
	public void giveCorpsBossReward(long roleId, EnemyArmyTemplate eaTpl, int mapId, BattleProcess bp) {
		CorpsBossTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsBossInfoByEnemy(eaTpl.getId());
		if(tpl == null){
			return;
		}
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if(offlineData == null){
			Loggers.corpsBossLogger.error("CorpsBossService#getCorpsBossReward getUserOfflineData is null!humanId=" + roleId);
			return;
		}
		int targetBossLevel = tpl.getBossLevel();
		UserCorpsBossData data = offlineData.getCorpsBossData(targetBossLevel);
		if(data == null){
			data = new UserCorpsBossData();
			data.setBossLevel(offlineData.getCorpsBossMaxLevel());
			data.setLastUpdateTime(Globals.getTimeService().now());
		}
		//第一次打的时候,才开始更新帮派BOSS的离线数据
		//本周打下一关:获得boss奖励,更新帮派BOSS的离线数据
		//本周重复打本关:不得奖励
		//不是本周打:奖励次数会刷新,从第一关开始打,更新帮派BOSS的离线数据
		if (data.getBossLevel() + 1 == targetBossLevel) {
			sendBossReward(roleId, tpl); 
			
			//更新玩家本周帮派boss进度
			data.setBossLevel(data.getBossLevel() + 1);
			data.setRewardNum(data.getRewardNum() + 1);
			data.setLastUpdateTime(Globals.getTimeService().now());
			offlineData.addCorpsBossData(targetBossLevel, data);
			offlineData.setModified();
		}else {
			//vip 重复挑战的时候
			if(this.getMaxOwnCorpsBossRewardNum(roleId) - data.getRewardNum() > 0){
				sendBossReward(roleId, tpl);
			
				data.setRewardNum(data.getRewardNum() + 1);
				data.setLastUpdateTime(Globals.getTimeService().now());
				offlineData.addCorpsBossData(targetBossLevel, data);
				offlineData.setModified();
			}
		}
			
		//更新玩家历史帮派boss进度
		if(offlineData.getCurCorpsBossLevel() + 1 == targetBossLevel){
			offlineData.setCurCorpsBossLevel(offlineData.getCurCorpsBossLevel() + 1);
			offlineData.setModified();
		}
		
		Corps corps = Globals.getCorpsService().getUserCorps(roleId);
		if(corps == null){
			return;
		}
		//判断玩家是否还在帮派中
		if(!Globals.getCorpsService().inCorps(roleId)){
			Loggers.corpsBossLogger.warn("player is in corps boss battle, but is not in corps!roleId=" + roleId);
			return;
		}
		
		
		//更新库
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			//进度榜存库
			CorpsBossRank rank = bossRankMap.get(corps.getId());
			if(rank == null){
				rank = buildCorpsBossRank(corps, offlineData.getCurCorpsBossLevel(), bp, human);
				rank.active();
				rank.setModified();
				addBossRankMap(rank);
				
				//同时更新帮派最高纪录
				updateCorpsBossBestInfo(corps);
			}
			
			//根据 boss进度 > 回合数 > 队员总战力 > 队员总人数 > 队员总等级,更新最优击杀者
			if(offlineData.getCurCorpsBossLevel() > rank.getBossBestLevel()
					|| bp.getBattle().getRound() < rank.getBossKillRound()
					|| this.getPowerSum(human) > rank.getBossKillPowerSum()
					|| this.getMemberNum(human) < rank.getBossKillMemberNum()
					|| this.getLevelSum(human) < rank.getBossKillLevelSum()){
				this.updateCorpsBossRank(rank, offlineData.getCurCorpsBossLevel(), bp, human);
				rank.setModified();
				addBossRankMap(rank);
				
				//同时更新帮派最高纪录
				updateCorpsBossBestInfo(corps);
			}
			
			//挑战次数榜存库
			CorpsBossCountRank countRank = bossCountRankMap.get(corps.getId());
			if(countRank == null){
				countRank = buildCorpsBossCountRank(corps, offlineData.getCurCorpsBossLevel(), bp, human);
				countRank.active();
			}else{
				countRank.addBossKillCount(1);
			}
			countRank.setModified();
			addBossCountRankMap(countRank);
		}
		
		CorpsBossCountRank countRankCorps = bossCountRankMap.get(corps.getId());
		if(countRankCorps != null 
				&& TimeUtils.isInSameWeek(countRankCorps.getLastUpdateTime(), Globals.getTimeService().now())){
			//帮派存库
			corps.setWeekBossCount(countRankCorps.getBossKillCount());
			corps.setModified();
			
		}
		//刷新进度排行榜，存库
		refreshBossRank(true, false);
		
		//刷新次数排行榜，存库
		refreshBossCountRank(true, false);
		
	}

	/**
	 * 更新帮派最高纪录
	 * @param corps
	 */
	protected void updateCorpsBossBestInfo(Corps corps) {
		CorpsBossRank rankCorps = bossRankMap.get(corps.getId());
		if(rankCorps != null 
				&& TimeUtils.isInSameWeek(rankCorps.getLastUpdateTime(), Globals.getTimeService().now())){
			//帮派存库,如果是本周内挑战帮派boss,则数据更新
			corps.setWeekBossLevel(rankCorps.getBossBestLevel());
			corps.setWeekBossLevelReplay(rankCorps.getBossBestKiller());
			corps.setWeekBossRound(rankCorps.getBossKillRound());
			corps.setWeekBossUpdateTime(Globals.getTimeService().now());
			corps.setModified();
		}
	}

	/**
	 * 发送boss奖励
	 * @param roleId
	 * @param tpl
	 */
	protected void sendBossReward(long roleId, CorpsBossTemplate tpl) {
		boolean giveRewardFlag = false;
		Reward reward = null;
		if (tpl.getRewardId() > 0) {
			reward = Globals.getRewardService().createReward(roleId, tpl.getRewardId(),
					"gain reward by corps boss battle end.");
		}
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			giveRewardFlag = Globals.getRewardService().giveReward(human, reward, true);
		} else {
			//玩家离线，给离线奖励
			giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId,
					OfflineRewardType.CORPS_BOSS, reward, "");
		}
		if (!giveRewardFlag) {
			// 记录错误日志
			Loggers.corpsBossLogger
					.error("CorpsBossService#getCorpsBossReward give reward error!humanId=" + roleId);
			return;
		}
	}

	
	protected CorpsBossRank buildCorpsBossRank(Corps corps, int bossLevel, BattleProcess bp, Human human){
		CorpsBossRank rank = new CorpsBossRank();
		rank.setId(Globals.getUUIDService().getNextUUID(UUIDType.CORPSBOSS_RANK));
		rank.setCorpsId(corps.getId());
		rank.setLevel(corps.getLevel());
		rank.setBossBestLevel(bossLevel);
		rank.setBossKillRound(bp.getBattle().getRound());
		rank.setBossKillPowerSum(this.getPowerSum(human));
		rank.setBossKillMemberNum(this.getMemberNum(human));
		rank.setBossKillLevelSum(this.getLevelSum(human));
		rank.setBossBestKiller(bp.getReportId()+"");
		rank.setLastUpdateTime(Globals.getTimeService().now());
		return rank;
	}
	
	protected CorpsBossCountRank buildCorpsBossCountRank(Corps corps, int bossLevel, BattleProcess bp, Human human){
		CorpsBossCountRank countRank = new CorpsBossCountRank();
		countRank.setId(Globals.getUUIDService().getNextUUID(UUIDType.CORPSBOSS_COUNT_RANK));
		countRank.setCorpsId(corps.getId());
		countRank.setLevel(corps.getLevel());
		countRank.addBossKillCount(1);
		countRank.setLastUpdateTime(Globals.getTimeService().now());
		return countRank;
	}
	
	protected void updateCorpsBossRank(CorpsBossRank cbr,  int bossLevel, BattleProcess bp, Human human){
		cbr.setBossBestLevel(bossLevel);
		cbr.setBossKillRound(bp.getBattle().getRound());
		cbr.setBossKillPowerSum(this.getPowerSum(human));
		cbr.setBossKillMemberNum(this.getMemberNum(human));
		cbr.setBossKillLevelSum(this.getLevelSum(human));
		cbr.setBossBestKiller(bp.getReportId()+"");
		cbr.setLastUpdateTime(Globals.getTimeService().now());
	}
	
	/**
	 * 获得玩家队伍成员的总人数
	 * @param human
	 * @return
	 */
	protected int getMemberNum(Human human){
		if(Globals.getTeamService().isInTeamNormal(human.getCharId())){
			return Globals.getTeamService().getHumanTeamMemberNum(human.getCharId());
		}
		return 0;
	}
	
	/**
	 * 获得玩家队伍成员的总等级
	 * @param human
	 * @return
	 */
	protected int getLevelSum(Human human){
		int levelSum = 0;
		if(Globals.getTeamService().isInTeamNormal(human.getCharId())){
			Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
			//对所有队员的要求
			for (TeamMember member : team.getMemberMap().values()) {
				//必须在线
				if (!Globals.getTeamService().isOnlineNow(member)) {
					team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_NOT_ONLINE_NOW, member.getName());
					return 0;
				}
				//状态必须都是正常状态
				if (!Globals.getTeamService().isInTeamNormal(member.getRoleId())) {
					team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_NOT_VALID_STATUS, member.getName());
					return 0;
				}
				//玩家不能是战斗中状态
				Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
				if (memberHuman.isInAnyBattle()) {
					team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_NOT_VALID_STATUS, member.getName());
					return 0;
				}
				
				levelSum += memberHuman.getLevel();
			}
		}
		
		return levelSum;
	}
	
	/**
	 * 获得玩家队伍成员的总战力
	 * @param human
	 * @return
	 */
	protected int getPowerSum(Human human){
		long sum = 0;
		if(Globals.getTeamService().isInTeamNormal(human.getCharId())){
			Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
			//对所有队员的要求
			for (TeamMember member : team.getMemberMap().values()) {
				//必须在线
				if (!Globals.getTeamService().isOnlineNow(member)) {
					team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_NOT_ONLINE_NOW, member.getName());
					return 0;
				}
				//状态必须都是正常状态
				if (!Globals.getTeamService().isInTeamNormal(member.getRoleId())) {
					team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_NOT_VALID_STATUS, member.getName());
					return 0;
				}
				//玩家不能是战斗中状态
				Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
				if (memberHuman.isInAnyBattle()) {
					team.noticeTeamMemberErrorMsg(LangConstants.CORPS_BOSS_NOT_VALID_STATUS, member.getName());
					return 0;
				}
				
				sum += memberHuman.getPetManager().getLeader().getFightPower();
			}
		}
		
		return (int)sum;
	}
	
	/**
	 * 帮派boss进度是否有效
	 * @param level
	 * @return
	 */
	public boolean isValidLevel(int level){
		//判断层数
		if(level < Globals.getTemplateCacheService().getCorpsTemplateCache().getMinCorpsBossLevel()
				|| level > Globals.getTemplateCacheService().getCorpsTemplateCache().getMaxCorpsBossLevel()){
			return false;
		}
		return true;
	}
	
	public boolean isOpening() {
		return OPEN;
	}

	/**
	 * 帮派解散时,排行榜不需要显示
	 * @param corpsId
	 * @param isInCorps
	 */
	public void onPlayerCorpsChanged(long corpsId, boolean isInCorps) {
		if(!isInCorps){
			CorpsBossRank rank = this.getBossRankMap(corpsId);
			if(rank != null){
				rank.onDelete();
				this.delBossRankMap(corpsId);
			}
			CorpsBossCountRank cbcRank = this.getBossCountRankMap(corpsId);
			if(cbcRank != null){
				cbcRank.onDelete();
				this.delBossCountRankMap(corpsId);
			}
			
			Loggers.corpsBossLogger.info("corps is not exist!delete the boss rank and boss count rank!corpsId=" + corpsId);
		}
	}

}
