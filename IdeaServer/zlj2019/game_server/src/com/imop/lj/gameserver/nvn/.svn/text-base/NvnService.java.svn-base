package com.imop.lj.gameserver.nvn;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.TreeMap;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.nvn.NvnRankInfo;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.NvnRankEntity;
import com.imop.lj.gameserver.activity.Activity;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutor;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.func.template.FuncOpenTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.map.model.NvnMap;
import com.imop.lj.gameserver.nvn.NvnDef.NvnTeamStatus;
import com.imop.lj.gameserver.nvn.model.NvnMatchedTeam;
import com.imop.lj.gameserver.nvn.model.NvnRank;
import com.imop.lj.gameserver.nvn.model.NvnTeam;
import com.imop.lj.gameserver.nvn.msg.GCNvnRule;
import com.imop.lj.gameserver.nvn.msg.NvnMsgBuilder;
import com.imop.lj.gameserver.nvn.template.NvnConWinScoreTemplate;
import com.imop.lj.gameserver.nvn.template.NvnRankRewardTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.rank.RankService;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.team.TeamDef.MemberStatus;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;
import com.imop.lj.gameserver.team.model.TeamPlayerBattleInfo;
import com.imop.lj.gameserver.teampvp.TeamPvpBattleProcess;
import com.imop.lj.gameserver.util.FixedSizeQueue;

public class NvnService implements InitializeRequired {
	/** 每个心跳最多触发战斗场数 */
	protected static int BATCH_NUM = 5;
	/** 每个心跳广播的已匹配队伍对儿数 */
	protected static int NOTICE_BATCH_NUM = 20;
	
	/** 排序器 */
	protected NvnTeamRankComparator teamSortor = new NvnTeamRankComparator();
	protected NvnRankComparator sortor = new NvnRankComparator();
	
	/** 当前活动 */
	protected Activity curActivity;
	
	/** 心跳任务处理器 */
	protected HeartbeatTaskExecutor hbTaskExecutor = new HeartbeatTaskExecutorImpl();
	
	/** nvn联赛的地图 */
	protected AbstractGameMap gameMap;
	
	/** 所有队伍数据Map<队伍Id，队伍数据> */
	protected Map<Integer, NvnTeam> teamDataMap = Maps.newHashMap();
	/** 每个玩家的nvn数据 Map<玩家id，玩家数据> */
	protected Map<Long, NvnRank> userDataMap = Maps.newHashMap();
	
	/** 每个玩家的log Map<玩家id，得分记录日志> */
	protected Map<Long, FixedSizeQueue<String>> userLogMap = Maps.newHashMap();
	
	/** 各个排名段的玩家队伍列表  Map<sectionId，队伍数据列表>*/
	protected Map<Integer, List<NvnTeam>> sectionTeamMap = new TreeMap<Integer, List<NvnTeam>>();
	/** 已匹配的队伍对象列表 */
	protected List<NvnMatchedTeam> matchedTeamList = new ArrayList<NvnMatchedTeam>();
	/** 开始匹配时间，设置为当前时间，通知完所有玩家匹配完成的消息后，设置为0 */
	protected long lastMatchTime;
	/** 开始触发战斗时间，当匹配完成并通知完所有玩家后，设置为当前时间，当所有战斗触发完后，设置为0 */
	protected long lastMatchEndTime;
	/** 通知匹配队伍的数量 */
	protected int noticeNum;
	
	protected List<NvnRank> userRankList = new ArrayList<NvnRank>();
	
	public NvnService() {
		
	}

	@Override
	public void init() {
		Globals.getTemplateCacheService().getNvnTemplateCache().initShowRewardList();
		
		//加载所有db中的数据
		List<NvnRankEntity> lst = Globals.getDaoService().getNvnRankDao().loadAllEntity();
		if (lst != null && !lst.isEmpty()) {
			for (NvnRankEntity entity : lst) {
				NvnRank nr = new NvnRank();
				nr.fromEntity(entity);
				//加到map中
				addUserData(nr);
			}
		}
		
		//初始化排行榜数据
		refreshUserDataRank(false, false);
	}
	
	protected void addUserData(NvnRank nr) {
		userDataMap.put(nr.getRoleId(), nr);
	}
	
	protected NvnRank getUserData(long roleId) {
		return userDataMap.get(roleId);
	}
	
	protected void addTeamData(NvnTeam nt) {
		teamDataMap.put(nt.getTeamId(), nt);
	}
	
	protected NvnTeam getTeamData(int teamId) {
		return teamDataMap.get(teamId);
	}
	
	protected void delTeamData(int teamId) {
		teamDataMap.remove(teamId);
	}
	
	protected NvnTeam getTeamDataWithAdd(int teamId) {
		//取队伍数据，如果没有则创建
		NvnTeam nt = getTeamData(teamId);
		if (nt == null) {
			nt = buildInitNvnTeam(teamId);
			addTeamData(nt);
		}
		return nt;
	}
	
	protected NvnTeam buildInitNvnTeam(int teamId) {
		NvnTeam nt = new NvnTeam(teamId);
		//初始默认即为匹配中状态
		nt.setStatus(NvnTeamStatus.MATCHING);
		//设置队伍积分
		nt.setScore(calcTeamScore(teamId));
		return nt;
	}
	
	protected NvnRank getUserDataWithAdd(long roleId) {
		//如果没有玩家数据，则增加
		NvnRank nr = getUserData(roleId);
		if (nr == null) {
			nr = buildInitNvnRank(roleId);
			addUserData(nr);
		}
		return nr;
	}
	
	protected void addSectionTeam(int section, NvnTeam nt) {
		List<NvnTeam> m = sectionTeamMap.get(section);
		if (m == null) {
			m = new ArrayList<NvnTeam>();
			sectionTeamMap.put(section, m);
		}
		m.add(nt);
	}
	
	protected void addUserLog(long roleId, String log) {
		FixedSizeQueue<String> q = this.userLogMap.get(roleId);
		if (q == null) {
			q = new FixedSizeQueue<String>(NvnDef.LogQueueSize);
			this.userLogMap.put(roleId, q);
		}
		q.add(log);
	}
	
	protected List<String> getUserLogList(long roleId) {
		FixedSizeQueue<String> q = this.userLogMap.get(roleId);
		if (q != null) {
			return q.getList(false);
		}
		return new ArrayList<String>();
	}
	
	/**
	 * 刷新玩家的nvn联赛积分排行榜
	 */
	protected void refreshUserDataRank(boolean saveFlag, boolean rankAll) {
		if (this.userDataMap.isEmpty()) {
			return;
		}
		
		this.userRankList.clear();
		this.userRankList.addAll(userDataMap.values());
		Collections.sort(this.userRankList, sortor);
		
		int count = this.userRankList.size();
		int rankCount = RankService.RANK_SIZE;
		for (int i = 0; i < count; i++) {
			NvnRank nr = this.userRankList.get(i);
			int rank = i + 1;
			
			if (rankAll) {
				//更新排名
				nr.setRank(rank);
			} else {
				if (rank <= rankCount) {
					//更新排名
					nr.setRank(rank);
				} else {
					//榜外排名设置为0
					nr.setRank(0);
				}
			}
			
			//存库
			if (saveFlag) {
				nr.setModified();
			}
		}
		
		Loggers.nvnLogger.info("refreshUserDataRank saveFlag=" + saveFlag + ";rankAll=" + rankAll);
	}
	
	/**
	 * 心跳方法，带动check等方法
	 */
	public void heartBeat() {
		hbTaskExecutor.onHeartBeat();

		//检查通知玩家匹配结果
		if (this.lastMatchTime > 0) {
			//通知玩家
			boolean noticeEnd = checkNoticeTeamMatchResult();
			//如果全部通知完，则设置匹配时间为0，停止通知，匹配结束时间为当前时间
			if (noticeEnd) {
				this.noticeNum = 0;
				this.lastMatchTime = 0;
				this.lastMatchEndTime = Globals.getTimeService().now();
				
				Loggers.nvnLogger.info("notice match result end.");
			}
		}
		
		//检查已匹配的队伍进入战斗
		if (this.lastMatchEndTime > 0 && 
				Globals.getTimeService().now() > this.lastMatchEndTime + NvnDef.MatchedCoolTime) {
			//进行战斗
			boolean fightEnd = checkMatchedTeamFight();
			//如果战斗都触发完了，则匹配结束时间设置为0，停止触发战斗
			if (fightEnd) {
				this.lastMatchEndTime = 0;
				
				Loggers.nvnLogger.info("trigger fight end.");
			}
		}
	}
	
	/**
	 * 检查nvn，2分钟调用一次
	 * 1、刷新玩家积分排行榜
	 * 2、检查匹配队伍
	 */
	public void checkNvn() {
		//刷新积分排行榜，不存库
		refreshUserDataRank(false, false);
		
		//检查是否该匹配队伍了
		boolean flag = checkMatchTeam();
		if (flag) {
			this.lastMatchTime = Globals.getTimeService().now();
		}
	}
	
	protected boolean checkMatchTeam() {
		//上一次匹配相关的还没处理完，就先不处理这一次的，一般情况不会走到这里
		if (this.lastMatchTime > 0 || this.lastMatchEndTime > 0) {
			Loggers.nvnLogger.warn("checkMatchTeam but matchTime is not 0.lastMatchTime=" + lastMatchTime
					+ ";lastMatchEndTime=" + lastMatchEndTime);
			return false;
		}
		
		//清除之前的匹配数据
		clearMatchData();
		
		//生成合法的队伍列表
		List<NvnTeam> matchingTeamList = genValidTeamList();
		
		//没有可匹配的队伍，返回
		if (matchingTeamList.isEmpty()) {
			return false;
		}
		
		//对队伍排序
		Collections.sort(matchingTeamList, teamSortor);
		
		Loggers.nvnLogger.info("valid team size=" + matchingTeamList.size());
		
		//生成sectionTeamMap
		genSectionTeamMap(matchingTeamList);
		
		//配对队伍
		genMatchedTeamList();
		
		return true;
	}
	
	protected void clearMatchData() {
		//清除之前的匹配数据
		this.sectionTeamMap.clear();
		this.matchedTeamList.clear();
		
		this.lastMatchTime = 0;
		this.lastMatchEndTime = 0;
		this.noticeNum = 0;
	}
	
	protected List<NvnTeam> genValidTeamList() {
		List<NvnTeam> matchingTeamList = new ArrayList<NvnTeam>();
		//生成合法的队伍列表
		for (NvnTeam nvnTeam : teamDataMap.values()) {
			//必须是匹配中的状态，才会进行匹配
			if (nvnTeam.getStatus() == NvnTeamStatus.MATCHING) {
				if (isTeamValid(nvnTeam.getTeamId())) {
					//加入列表
					matchingTeamList.add(nvnTeam);
					//计算队伍积分
					nvnTeam.setScore(calcTeamScore(nvnTeam.getTeamId()));
				}
			}
		}
		return matchingTeamList;
	}
	
	protected void genSectionTeamMap(List<NvnTeam> matchingTeamList) {
		int count = matchingTeamList.size();
		for (int i = 0; i < count; i++) {
			int rank = i + 1;
			int section = Globals.getTemplateCacheService().getNvnTemplateCache().getMatchRankRange(rank);
			NvnTeam nt = matchingTeamList.get(i);
			nt.setRank(rank);
			addSectionTeam(section, nt);
		}
	}
	
	protected void genMatchedTeamList() {
		List<Integer> sectionList = new ArrayList<Integer>();
		sectionList.addAll(sectionTeamMap.keySet());
		int sectionCount = sectionList.size();
		//遍历各个段
		for (int i = 0; i < sectionCount; i++) {
			int section = sectionList.get(i);
			List<NvnTeam> lst = sectionTeamMap.get(section);
			//如果该段是奇数个人，则随机一个人到下一个段中，如果没有下一个段，则该队伍轮空
			if (lst.size() % 2 != 0) {
				//该段移除一个队伍
				NvnTeam removeNt = lst.remove(MathUtils.random(0, lst.size() - 1));
				//如果是最后一个段
				if (i == sectionCount - 1) {
					//队伍设置为轮空状态
					removeNt.setStatus(NvnTeamStatus.NO_MATCHED);
					//加入已配对列表
					NvnMatchedTeam nmt = new NvnMatchedTeam(removeNt.getTeamId(), 0);
					matchedTeamList.add(nmt);
				} else {
					//放到下一个段中
					addSectionTeam(sectionList.get(i + 1), removeNt);
				}
			}
			if (lst.isEmpty()) {
				continue;
			}
			
			//配对
			int num = lst.size() / 2;
			for (int j = 0; j < num; j++) {
				NvnTeam nt1 = lst.remove(MathUtils.random(0, lst.size() - 1));
				NvnTeam nt2 = lst.remove(MathUtils.random(0, lst.size() - 1));
				nt1.setStatus(NvnTeamStatus.MATCHED);
				nt2.setStatus(NvnTeamStatus.MATCHED);
				
				//加入已配对列表
				NvnMatchedTeam nmt = new NvnMatchedTeam(nt1.getTeamId(), nt2.getTeamId());
				matchedTeamList.add(nmt);
			}
		}
		
		Loggers.nvnLogger.info("genMatchedTeamList end.matchedTeamList.size=" + matchedTeamList.size());
	}
	
	/**
	 * 检查通知所有已经匹配的队伍
	 * @return
	 */
	protected boolean checkNoticeTeamMatchResult() {
		int count = matchedTeamList.size();
		if (noticeNum >= count) {
			return true;
		}
		
		for (int i = 0; i < NOTICE_BATCH_NUM; i++) {
			if (noticeNum >= count) {
				break;
			}
			
			NvnMatchedTeam nmt = matchedTeamList.get(noticeNum);
			noticeNum++;
			
			int aid = nmt.getTeamIdA();
			int did = nmt.getTeamIdD();
			
			NvnTeam ant = getTeamData(aid);
			NvnTeam dnt = getTeamData(did);
			
			Team aTeam = Globals.getTeamService().getTeam(aid);
			Team dTeam = Globals.getTeamService().getTeam(did);
			
			if (ant != null && isTeamValid(aid)) {
				if (ant.getStatus() == NvnTeamStatus.MATCHED &&
						dnt != null && isTeamValid(did)) {
					//发状态变化消息
					Globals.getTeamService().getTeam(aid).noticeTeamMember(
							NvnMsgBuilder.buildGCNvnMatchStatus(ant.getStatus().getIndex()), false, true);
					//发匹配成功消息
					Globals.getTeamService().getTeam(aid).noticeTeamMember(
							NvnMsgBuilder.buildGCNvnMatchedTeamInfo(dTeam, dnt), false, true);
				} else {
					//发轮空消息
					Globals.getTeamService().getTeam(aid).noticeTeamMember(
							NvnMsgBuilder.buildGCNvnMatchStatus(NvnTeamStatus.NO_MATCHED.getIndex()), false, true);
				}
			}
			
			if (dnt != null && isTeamValid(did)) {
				if (dnt.getStatus() == NvnTeamStatus.MATCHED &&
						ant != null && isTeamValid(aid)) {
					//发状态变化消息
					Globals.getTeamService().getTeam(did).noticeTeamMember(
							NvnMsgBuilder.buildGCNvnMatchStatus(dnt.getStatus().getIndex()), false, true);
					//发匹配成功消息
					Globals.getTeamService().getTeam(did).noticeTeamMember(
							NvnMsgBuilder.buildGCNvnMatchedTeamInfo(aTeam, ant), false, true);
				} else {
					//发轮空消息
					Globals.getTeamService().getTeam(did).noticeTeamMember(
							NvnMsgBuilder.buildGCNvnMatchStatus(NvnTeamStatus.NO_MATCHED.getIndex()), false, true);
				}
			}
		}
		
		Loggers.nvnLogger.info("noticeNum=" + noticeNum);
		
		return noticeNum >= count;
	}
	
	protected boolean checkMatchedTeamFight() {
		if (matchedTeamList.isEmpty()) {
			return true;
		}
		
		for (int i = 0; i < BATCH_NUM; i++) {
			if (matchedTeamList.isEmpty()) {
				break;
			}
			
			NvnMatchedTeam nmt = matchedTeamList.remove(0);
			int aid = nmt.getTeamIdA();
			int did = nmt.getTeamIdD();
			
			NvnTeam ant = getTeamData(aid);
			NvnTeam dnt = getTeamData(did);
			
			if (ant != null && dnt != null && 
					isTeamValid(aid) && isTeamValid(did) &&
					ant.getStatus() == NvnTeamStatus.MATCHED && dnt.getStatus() == NvnTeamStatus.MATCHED) {
				//双方进入战斗
				matchedTeamGoFight(ant, dnt);
			} else {
				//轮空，直接给积分
				if (ant != null && isTeamValid(aid) &&
						(ant.getStatus() == NvnTeamStatus.MATCHED || ant.getStatus() == NvnTeamStatus.NO_MATCHED)) {
					onTeamNoMatch(aid);
				}
				
				if (dnt != null && isTeamValid(did) &&
						(dnt.getStatus() == NvnTeamStatus.MATCHED || dnt.getStatus() == NvnTeamStatus.NO_MATCHED)) {
					onTeamNoMatch(did);
				}
			}
		}
		
		Loggers.nvnLogger.info("go fight or no match.matchedTeamList left num=" + matchedTeamList.size());
		
		return matchedTeamList.isEmpty();
	}
	
	protected void onTeamNoMatch(int teamId) {
		Team team = Globals.getTeamService().getTeam(teamId);
		for (TeamMember tm : team.getMemberMap().values()) {
			if (tm.getStatus() != MemberStatus.NORMAL) {
				continue;
			}
			
			NvnRank nr = getUserData(tm.getRoleId());
			//增加积分
			addScore(nr, Globals.getGameConstants().getNvnNoMatchScore());
			//存库
			nr.setModified();
			//增加日志
			addUserLog(tm.getRoleId(), Globals.getLangService().readSysLang(LangConstants.NVN_NO_MATCH_LOG, 
					Globals.getGameConstants().getNvnNoMatchScore()));
		}
		
		NvnTeam nt = getTeamData(teamId);
		//队伍状态变为匹配中
		nt.setStatus(NvnTeamStatus.MATCHING);
		//队伍积分更新
		nt.setScore(calcTeamScore(teamId));
		
		//给队伍的队员发nvn面板消息
		noticeTeamMemberNvnMyInfo(team, nt);
		
		Loggers.nvnLogger.info("team no match.teamId=" + teamId + ";leaderId=" + team.getLeader().getRoleId() +
				";leaderName=" + team.getLeader().getName());
	}
	
	/**
	 * 给单人加减分
	 * @param nr
	 * @param add 正负均可
	 * @return
	 */
	protected int addScore(NvnRank nr, int add) {
		if (nr != null) {
			int s = nr.getScore() + add;
			if (s < 0) {
				s = 0;
			}
			nr.setScore(s);
			return nr.getScore();
		}
		return 0;
	}
	
	protected void matchedTeamGoFight(NvnTeam ant, NvnTeam dnt) {
		ant.setStatus(NvnTeamStatus.FIGHTING);
		dnt.setStatus(NvnTeamStatus.FIGHTING);
		Team aTeam = Globals.getTeamService().getTeam(ant.getTeamId());
		Team dTeam = Globals.getTeamService().getTeam(dnt.getTeamId());
		if (aTeam == null || dTeam == null) {
			return;
		}
		if (aTeam.isInBattle() || dTeam.isInBattle()) {
			Loggers.nvnLogger.error("team is in battle!aTeamLeaderId=" + aTeam.getLeader().getRoleId() +
					";dTeamLeaderId=" + dTeam.getLeader().getRoleId());
			return;
		}
		
		//调用组队pvp
		int battleId = Globals.getTeamPvpService().startTeamPVPBattle(aTeam.getLeader().getRoleId(), 
				dTeam.getLeader().getRoleId(), BattleType.NVN_TEAM_PVP);
		if (battleId <= 0) {
			Loggers.nvnLogger.error("battleId is invalid!aLeaderId=" + aTeam.getLeader().getRoleId() + 
					";dTeamLeaderId=" + dTeam.getLeader().getRoleId());
		}
	}
	
	protected boolean isTeamValid(int teamId) {
		boolean flag = false;
		Team team = Globals.getTeamService().getTeam(teamId);
		if (team != null) {
			//队伍普通状态的队员数量达到最低要求即可
			if (team.getTeamMemberNum() >= Globals.getGameConstants().getNvnTeamMemberNumMin()) {
				flag = true;
			}
		}
		return flag;
	}
	
	protected int calcTeamScore(int teamId) {
		int score = 0;
		Team team = Globals.getTeamService().getTeam(teamId);
		if (team != null) {
			int count = 0;
			for (TeamMember member : team.getMemberMap().values()) {
				//普通状态玩家有效
				if (member.getStatus() == MemberStatus.NORMAL) {
					count++;
					NvnRank nr = getUserData(member.getRoleId());
					if (nr != null) {
						score += nr.getScore();
					}
				}
			}
			if (count > 0) {
				score = score / count;
			}
		}
		return score;
	}
	
	/**
	 * 组队pvp战斗结束的处理
	 * @param bp
	 * @param isAttackerWin
	 */
	public void onBattleEnd(TeamPvpBattleProcess bp, boolean isAttackerWin) {
		//只处理nvn战斗
		if (bp.getBattleType() != BattleType.NVN_TEAM_PVP) {
			return;
		}
		
		//根据胜负，双方队伍的积分，计算每个玩家的得分
		Team winTeam = isAttackerWin ? bp.getAttackerTeam() : bp.getDefenderTeam();
		Team lossTeam = isAttackerWin ? bp.getDefenderTeam() : bp.getAttackerTeam();
		
		//先计算两个队的积分
		int winTeamScore = calcTeamScore(winTeam.getId());
		int lossTeamScore = calcTeamScore(lossTeam.getId());
		
		//胜利队伍队员积分处理
		for (Long memberId : winTeam.getMemberMap().keySet()) {
			TeamPlayerBattleInfo info = bp.getPlayerInfo(memberId);
			if (info == null) {
				continue;
			}
			NvnRank nr = getUserData(memberId);
			if (nr == null) {
				Loggers.nvnLogger.error("#NvnService#onBattleEnd#user data not exist!roleId=" + memberId);
				continue;
			}
			
			int addScore = calcBattleScore(nr.getScore(), winTeamScore, lossTeamScore, true);
			//连胜获得积分
			int nConWin = nr.getConWin() + 1;
			NvnConWinScoreTemplate conWinTpl = Globals.getTemplateCacheService().getNvnTemplateCache().getNvnConWinScoreTemplate(nConWin);
			if (conWinTpl != null) {
				addScore += conWinTpl.getScore();
			}
			
			//增加积分
			addScore(nr, addScore);
			//胜利次数+1
			nr.setWin(nr.getWin() + 1);
			//连胜+1
			nr.setConWin(nConWin);
			//存库
			nr.setModified();
			
			//增加日志
			addUserLog(memberId, Globals.getLangService().readSysLang(LangConstants.NVN_FIGHT_WIN_LOG, 
					lossTeam.getName(), addScore, nr.getConWin()));
		}
		NvnTeam wnt = getTeamData(winTeam.getId());
		//更新队伍积分
		wnt.setScore(calcTeamScore(winTeam.getId()));
		//队伍状态变为匹配中
		wnt.setStatus(NvnTeamStatus.MATCHING);
		//通知队伍玩家，队伍信息变化
		noticeTeamMemberNvnMyInfo(winTeam, wnt);
		
		//失败队伍队员积分处理
		for (Long memberId : lossTeam.getMemberMap().keySet()) {
			TeamPlayerBattleInfo info = bp.getPlayerInfo(memberId);
			if (info == null) {
				continue;
			}
			NvnRank nr = getUserData(memberId);
			if (nr == null) {
				Loggers.nvnLogger.error("#NvnService#onBattleEnd#user data not exist!roleId=" + memberId);
				continue;
			}
			
			int addScore = calcBattleScore(nr.getScore(), lossTeamScore, winTeamScore, false);
			//增加积分
			addScore(nr, addScore);
			//失败次数+1
			nr.setLoss(nr.getLoss() + 1);
			//连胜清零
			nr.setConWin(0);
			//存库
			nr.setModified();
			
			//增加日志
			addUserLog(memberId, Globals.getLangService().readSysLang(LangConstants.NVN_FIGHT_LOSS_LOG, 
					winTeam.getName(), Math.abs(addScore)));
		}
		NvnTeam lnt = getTeamData(lossTeam.getId());
		//更新队伍积分
		lnt.setScore(calcTeamScore(lossTeam.getId()));
		//队伍状态变为匹配中
		lnt.setStatus(NvnTeamStatus.MATCHING);
		//通知队伍玩家，队伍信息变化
		noticeTeamMemberNvnMyInfo(lossTeam, lnt);
	}
	
	protected int calcBattleScore(int myScore, int myTeamScore, int targetTeamScore, boolean isWin) {
		int score = 0;
		//参数1= 1+-ROUND(（我的积分-自己队伍积分）/(1000*修正系数1),1)
		double p = (myScore - myTeamScore) / Globals.getGameConstants().getNvnBattleScoreCoef1();
		double p1 = MathUtils.roundNum(p, 1);
		double p2 = isWin ? 1 - p1 : 1 + p1;
		if (p2 < Globals.getGameConstants().getNvnBattleScoreMin1()) {
			p2 = Globals.getGameConstants().getNvnBattleScoreMin1();
		} else if (p2 > Globals.getGameConstants().getNvnBattleScoreMax1()) {
			p2 = Globals.getGameConstants().getNvnBattleScoreMax1();
		}
		
		//参数3= 1+-ROUND(（我的积分-匹配队伍积分）/(1000*修正系数2),1)
		double d = (myScore - targetTeamScore) / Globals.getGameConstants().getNvnBattleScoreCoef2();
		double d1 = MathUtils.roundNum(d, 1);
		double d2 = isWin ? 1 - d1 : 1 + d1;
		if (d2 < Globals.getGameConstants().getNvnBattleScoreMin2()) {
			d2 = Globals.getGameConstants().getNvnBattleScoreMin2();
		} else if (d2 > Globals.getGameConstants().getNvnBattleScoreMax2()) {
			d2 = Globals.getGameConstants().getNvnBattleScoreMax2();
		}
		
		//最终 个人积分 = ROUND(（基准积分*（1+自己队伍加成系数+匹配目标队伍加成系数）,0）
		int base = isWin ? Globals.getGameConstants().getNvnWinScoreBase() : Globals.getGameConstants().getNvnLossScoreBase();
		double ft = base * (1 + p2 + d2);
		score = (int)Math.round(ft);
		if (!isWin) {
			score = -score; 
		}
		
		return score;
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
			if (bp.getBattleType() != BattleType.NVN_TEAM_PVP) {
				continue;
			}
			
			//强制结束战斗
			Globals.getTeamPvpService().forceEndBattle(bp, "nvnFight end forceEnd!");
		}
	}
	
	/**
	 * 军团战地图内所有玩家退出本地图，回到原地图
	 */
	protected void allPlayerToBackMap() {
		Globals.getMapService().allPlayerToBackMap(this.gameMap);
	}
	
	/**
	 * nvn联赛结算奖励，按照积分排名给奖励，清空数据
	 */
	public void refreshNvnRankMonthly(String source) {
		//判断当前是否月初第一天，是则执行，否则返回
		if (!TimeUtils.isFirstDayOfMonth(Globals.getTimeService().now())) {
			return;
		}
		
		//重新根据积分排名
		refreshUserDataRank(false, true);
		
		//发奖，并所有人的数据删除
		for (NvnRank nr : this.userRankList) {
			int rank = nr.getRank();
			//删除数据
			nr.onDelete();
			NvnRankRewardTemplate tpl = Globals.getTemplateCacheService().getNvnTemplateCache().getNvnRankRewardTemplate(rank);
			if (tpl == null) {
				Loggers.nvnLogger.error("rank reward tpl is null!rank=" + rank);
				continue;
			}
			//可能超过指定排名没有奖励，所以这里判断奖励id是否大于0
			if (tpl.getRewardId() > 0) {
				//给玩家发邮件奖励
				Reward reward = Globals.getRewardService().createReward(nr.getRoleId(), tpl.getRewardId(), "refreshNvnRankMonthly");
				Globals.getMailService().sendSysMail(nr.getRoleId(), MailType.SYSTEM, tpl.getMailTitle(), tpl.getMailContent(), reward);
			}
		}
		
		Loggers.nvnLogger.info("refreshNvnRankMonthly end. source=" + source);
	}
	
	protected void onStartActivity() {
		//构建地图
		this.gameMap = new NvnMap();
		
		//加定时任务
		this.hbTaskExecutor.submit(new NvnChecker());
		
		//清除队伍数据
		this.teamDataMap.clear();
	}
	
	protected void onEndActivity() {
		//如果有正在进行的战斗，则强制结束掉
		forceEndAllBattle();
		
		//所有玩家返回之前的地图
		allPlayerToBackMap();
		
		//刷新积分排行榜，存库
		refreshUserDataRank(true, false);
		
		//清除定时任务
		this.hbTaskExecutor.clear();
		//清除队伍数据
		this.teamDataMap.clear();
		//地图重置
		this.gameMap = null;
	}
	
	public AbstractGameMap getGameMap() {
		return this.gameMap;
	}
	
	/**
	 * 队伍队员发生变化时的相关处理
	 * @param roleId
	 * @param teamId
	 * @param isAdd
	 * @param isLast
	 */
	public void onTeamMemberChanged(long roleId, int teamId, boolean isAdd, boolean isLast) {
		//新加人了，这里存在一种情况，当队伍匹配成功，进入战斗之前，有3秒cd时间，这期间应该将队伍设置为锁定状态，不能加新人进来
		//有人离队，退出地图，
		//有人暂离，退出地图，
		//更新队伍积分，看队伍是否满足最低人数要求，如果不满足，则重置队伍状态为空闲
		
		NvnTeam nt = getTeamData(teamId);
		if (nt == null) {
			return;
		}
		
		Team team = Globals.getTeamService().getTeam(teamId);
		if (team != null) {
			//新加入的队员的数据需要加进来
			if (isAdd) {
				for (TeamMember tm : team.getMemberMap().values()) {
					if (tm.getStatus() == MemberStatus.NORMAL) {
						getUserDataWithAdd(tm.getRoleId());
					}
				}
			}
			
			//队伍人数是否满足最低要求
			if (team.getTeamMemberNum() < Globals.getGameConstants().getNvnTeamMemberNumMin() &&
					nt.getStatus() != NvnTeamStatus.IDLE) {
				//人数已经不满足条件，队伍变为空闲
				nt.setStatus(NvnTeamStatus.IDLE);
			}
			
			//给队伍的队员发nvn面板消息
			noticeTeamMemberNvnMyInfo(team, nt);
		}
		
		//离队或暂离的处理
		if (!isAdd) {
			onTeamMemberLeaveOrAway(roleId, teamId, isLast);
		}
	}
	
	/**
	 * 给队伍的队员发nvn面板消息
	 * @param team
	 */
	protected void noticeTeamMemberNvnMyInfo(Team team, NvnTeam nt) {
		//通知队员队伍数据变化
		for (TeamMember tm : team.getMemberMap().values()) {
			if (tm.getStatus() != MemberStatus.NORMAL) {
				continue;
			}
			
			long memberId = tm.getRoleId();
			NvnRank nr = getUserData(memberId);
			
			//发nvn面板消息
			Player playerMember = Globals.getOnlinePlayerService().getPlayer(memberId);
			if (playerMember != null && playerMember.getHuman() != null) {
				playerMember.sendMessage(NvnMsgBuilder.buildGCNvnMyInfo(memberId, nt, nr, getUserLogList(memberId)));
			}
		}
	}
	
	protected void onTeamMemberLeaveOrAway(long roleId, int teamId, boolean isLast) {
		if (isLast) {
			//队伍解散，删除对应的NvnTeam数据
			delTeamData(teamId);
		}
		
		//回到原地图
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			Globals.getMapService().enterMap(human, human.getBackMapId(), human.getBackX(), human.getBackY());
		}
	}
	
	/**
	 * 进入nvn联赛
	 * @param human
	 */
	public void enterNvn(Human human) {
		//活动是否开启
		if (!isOpening()) {
			human.sendErrorMessage(LangConstants.NVN_NOT_OPENED);
			return;
		}
		
		//是否已经在地图中
		if (human.getMapId() == Globals.getTemplateCacheService().getMapTemplateCache().getNvnMapId()) {
			return;
		}
		
		long roleId = human.getCharId();
		//需是组队队长
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			return;
		}
		
		//队伍人数是否满足最低要求
		int curMemNum = Globals.getTeamService().getHumanTeamMemberNum(roleId);
		if (curMemNum < Globals.getGameConstants().getNvnTeamMemberNumMin()) {
			human.sendErrorMessage(LangConstants.NVN_ENTER_FAIL_TEAM_MEMBER_LESS, Globals.getGameConstants().getNvnTeamMemberNumMin());
			return;
		}
		
		//进入地图
		boolean flag = Globals.getMapService().enterMap(human, 
				Globals.getTemplateCacheService().getMapTemplateCache().getNvnMapId());
		if (!flag) {
			Loggers.nvnLogger.error("enter nvn map failed!humanId=" + roleId);
			return;
		}
		
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		//取队伍数据，如果没有则创建
		NvnTeam nt = getTeamDataWithAdd(team.getId());
		
		//将队员加入nvn数据结构中
		for (TeamMember tm : team.getMemberMap().values()) {
			if (tm.getStatus() != MemberStatus.NORMAL) {
				continue;
			}
			
			long memberId = tm.getRoleId();
			NvnRank nr = getUserDataWithAdd(memberId);
			
			//发nvn面板消息
			Player playerMember = Globals.getOnlinePlayerService().getPlayer(memberId);
			if (playerMember != null && playerMember.getHuman() != null) {
				playerMember.sendMessage(NvnMsgBuilder.buildGCNvnMyInfo(memberId, nt, nr, getUserLogList(memberId)));
			}
		}
		
		//给各个队员发nvn排行榜消息
		team.noticeTeamMember(NvnMsgBuilder.buildGCNvnRankList(buildNvnRankInfoList(), null), false, true);
	}
	
	public void openNvnPanel(Human human) {
		//活动是否开启
		if (!isOpening()) {
			return;
		}
		
		//是否在地图中
		if (human.getMapId() != Globals.getTemplateCacheService().getMapTemplateCache().getNvnMapId()) {
			return;
		}
		
		long roleId = human.getCharId();
		//是否在队伍中
		if (!Globals.getTeamService().isInTeamNormal(roleId)) {
			return;
		}
		
		int teamId = Globals.getTeamService().getHumanTeam(roleId).getId();
		NvnTeam nt = getTeamData(teamId);
		if (nt == null) {
			Loggers.nvnLogger.warn("nvnTeam data not exist!humanId=" + roleId);
			return;
		}
		
		//发我的数据消息
		human.sendMessage(NvnMsgBuilder.buildGCNvnMyInfo(roleId, 
				getTeamDataWithAdd(teamId), getUserDataWithAdd(roleId), getUserLogList(roleId)));
		//发排行榜消息
		human.sendMessage(NvnMsgBuilder.buildGCNvnRankList(buildNvnRankInfoList(), getUserData(roleId)));
	}
	
	/**
	 * 构建玩家初始的nvn排行数据
	 * @param roleId
	 * @return
	 */
	protected NvnRank buildInitNvnRank(long roleId) {
		NvnRank nr = new NvnRank();
		nr.setId(Globals.getUUIDService().getNextUUID(UUIDType.NVN_RANK));
		nr.setRoleId(roleId);
		nr.setLastUpdateTime(Globals.getTimeService().now());
		//初始积分
		nr.setScore(Globals.getGameConstants().getNvnInitScore());
		
		nr.setInDb(false);
		nr.active();
		nr.setModified();
		return nr;
	}
	
	public List<NvnRankInfo> buildNvnRankInfoList() {
		List<NvnRankInfo> infoList = new ArrayList<NvnRankInfo>();
		int count = Math.min(this.userRankList.size(), NvnDef.RankShowSize);
		for (int i = 0; i < count; i++) {
			NvnRank nr = this.userRankList.get(i);
			infoList.add(buildNvnRankInfo(nr));
		}
		return infoList;
	}
	
	protected NvnRankInfo buildNvnRankInfo(NvnRank nr) {
		NvnRankInfo info = new NvnRankInfo();
		info.setRoleId(nr.getRoleId());
		info.setRank(nr.getRank());
		info.setScore(nr.getScore());
		info.setConWinNum(nr.getConWin());
		info.setTplId(Globals.getOfflineDataService().getUserTplId(nr.getRoleId()));
		info.setName(Globals.getOfflineDataService().getUserName(nr.getRoleId()));
		return info;
	}
	
	/**
	 * 取消匹配，变为空闲状态
	 * @param human
	 */
	public void cancelMatch(Human human) {
		//活动是否开启中
		if (!isOpening()) {
			return;
		}
		
		long roleId = human.getCharId();
		//只有队长可以操作
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			human.sendErrorMessage(LangConstants.NVN_ONLY_LEADER_CAN_OP);
			return;
		}
		
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		NvnTeam nt = getTeamData(team.getId());
		if (nt == null) {
			Loggers.nvnLogger.warn("nvnTeam data not exist!humanId=" + roleId);
			return;
		}
		
		//当前是否已经是空闲状态
		if (nt.getStatus() == NvnTeamStatus.IDLE) {
			return;
		}
		
		//队伍当前状态是否允许操作
		if (!isTeamStateCanChange(nt.getStatus())) {
			human.sendErrorMessage(LangConstants.NVN_OP_FAILED);
			return;
		}
		
		//更新队伍状态
		nt.setStatus(NvnTeamStatus.IDLE);
		
		//通知队伍
		team.noticeTeamMember(NvnMsgBuilder.buildGCNvnMatchStatus(nt.getStatus().getIndex()), false, true);
	}
	
	protected boolean isTeamStateCanChange(NvnTeamStatus status) {
		return status == NvnTeamStatus.IDLE || status == NvnTeamStatus.MATCHING;
	}
	
	/**
	 * 开始匹配，变为匹配中状态
	 * @param human
	 */
	public void startMatch(Human human) {
		//活动是否开启中
		if (!isOpening()) {
			return;
		}
		
		long roleId = human.getCharId();
		//只有队长可以操作
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			return;
		}
		
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		NvnTeam nt = getTeamData(team.getId());
		if (nt == null) {
			Loggers.nvnLogger.warn("nvnTeam data not exist!humanId=" + roleId);
			return;
		}
		
		//当前是否已经是空闲状态
		if (nt.getStatus() == NvnTeamStatus.MATCHING) {
			return;
		}
		
		//队伍当前状态是否允许操作
		if (!isTeamStateCanChange(nt.getStatus())) {
			human.sendErrorMessage(LangConstants.NVN_OP_FAILED);
			return;
		}
		
		//队伍有效人数是否满足要求
		if (team.getTeamMemberNum() < Globals.getGameConstants().getNvnTeamMemberNumMin()) {
			human.sendErrorMessage(LangConstants.NVN_ENTER_FAIL_TEAM_MEMBER_LESS, Globals.getGameConstants().getNvnTeamMemberNumMin());
			return;
		}
		
		//更新队伍状态
		nt.setStatus(NvnTeamStatus.MATCHING);
		
		//通知队伍
		team.noticeTeamMember(NvnMsgBuilder.buildGCNvnMatchStatus(nt.getStatus().getIndex()), false, true);
	}
	
	/**
	 * 离开nvn地图
	 * @param human
	 */
	public void leaveNvn(Human human) {
		//活动是否开启中
		if (!isOpening()) {
			return;
		}
		
		long roleId = human.getCharId();
		//只有队长可以操作
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			return;
		}
		
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		NvnTeam nt = getTeamData(team.getId());
		if (nt == null) {
			Loggers.nvnLogger.warn("nvnTeam data not exist!humanId=" + roleId);
			return;
		}
		
		//删除nvn队伍数据
		delTeamData(team.getId());
		
		//回到原地图
		Globals.getMapService().enterMap(human, human.getBackMapId(), human.getBackX(), human.getBackY());
	}
	
	public GCNvnRule buildGCNvnRule() {
		GCNvnRule msg = new GCNvnRule();
		FuncOpenTemplate funcOpenTpl = Globals.getTemplateCacheService().get(FuncTypeEnum.NVN.getIndex(), FuncOpenTemplate.class);
		if(funcOpenTpl != null){
			msg.setLevel(funcOpenTpl.getLimitLevel());
		}
		msg.setMemberNum(Globals.getGameConstants().getNvnTeamMemberNumMin());
		msg.setShowRewardList(Globals.getTemplateCacheService().getNvnTemplateCache().getShowRewardList().toArray(new String[0]));
		msg.setShowRewardNameList(Globals.getTemplateCacheService().getNvnTemplateCache().getShowRewardNameList().toArray(new String[0]));
		return msg;
	}
	
	/**
	 * 发nvn规则说明
	 * @param human
	 */
	public void sendNvnRule(Human human) {
		human.sendMessage(buildGCNvnRule());
	}
	
	/**
	 * 请求nvn联赛排行榜数据
	 * @param human
	 */
	public void sendNvnRankList(Human human) {
		//发排行榜消息
		human.sendMessage(NvnMsgBuilder.buildGCNvnRankList(buildNvnRankInfoList(), getUserData(human.getCharId())));
	}
	
	public void onPlayerLogin(Human human) {
		if (!isOpening()) {
			return;
		}
		
		if (human.getMapId() != Globals.getTemplateCacheService().getMapTemplateCache().getNvnMapId()) {
			return;
		}
		
		long roleId = human.getCharId();
		//如果玩家不是正常在队伍中，则需要离开该地图
		if (!Globals.getTeamService().isInTeamNormal(roleId)) {
			onTeamMemberLeaveOrAway(roleId, 0, false);
			return;
		}
		
	}
	
	/******活动相关******/
	
	/**
	 * 活动是否开启，这里是 准备中或进行中状态
	 * @return
	 */
	public boolean isOpening() {
		return curActivity != null && 
				curActivity.getState() == ActivityState.OPENING;
	}
	
	public void handleActivityNoticeMsg(Activity curActivity) {
		// 活动状态不是提醒阶段，不能执行
		if (curActivity.getState() != ActivityState.NOT_OPEN) {
			return;
		}
		
		// 记录日志
		Loggers.nvnLogger.info("#NvnService#handleActivityNoticeMsg#activity state=" + curActivity.getState());
	}
	
	public void handleActivityReadyMsg(Activity curActivity) {
		// 活动状态不是准备阶段，不能执行
		if (curActivity.getState() != ActivityState.READY) {
			return;
		}
		
		//广播
		Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getNvnReadyNoticeId());
		
		Loggers.nvnLogger.info("#NvnService#handleActivityReadyMsg#OK.activity state=" + curActivity.getState());
	}
	
	public void handleActivityStartMsg(Activity curActivity) {
		// 活动状态不是开始阶段，不能执行
		if (curActivity.getState() != ActivityState.OPENING) {
			return;
		}
		
		// 设置当前活动
		this.curActivity = curActivity;
		
		//活动开始的处理
		onStartActivity();
		
		//广播
		Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getNvnStartNoticeId());
		
		Loggers.nvnLogger.info("#NvnService#handleActivityStartMsg#OK.activity state=" + curActivity.getState());
	}
	
	public void handleActivityEndMsg() {
		// 活动状态不是结束阶段，不能执行
		if (this.curActivity.getState() != ActivityState.FINISHED) {
			return;
		}
		
		//活动结束的处理
		onEndActivity();
		
		//广播
		Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getNvnEndNoticeId());
		
		Loggers.nvnLogger.info("#NvnService#handleActivityEndMsg#OK.activity state=" + curActivity.getState());
	}
	
	class NvnTeamRankComparator implements Comparator<NvnTeam> {
		
		@Override
		public int compare(NvnTeam o1, NvnTeam o2) {
			//先按score排，score相同按teamId排
			if (o1.getScore() > o2.getScore()) {
				return -1;
			} else if (o1.getScore() < o2.getScore()) {
				return 1;
			} else {
				if (o1.getTeamId() < o2.getTeamId()) {
					return -1;
				} else {
					return 1;
				}
			}
		}
	}
	
	class NvnRankComparator implements Comparator<NvnRank> {
		
		@Override
		public int compare(NvnRank o1, NvnRank o2) {
			//先按score排，再连胜，再胜利，再id
			//积分
			if (o1.getScore() > o2.getScore()) {
				return -1;
			} else if (o1.getScore() < o2.getScore()) {
				return 1;
			}
			//连胜数
			if (o1.getConWin() > o2.getConWin()) {
				return -1;
			} else if (o1.getConWin() < o2.getConWin()) {
				return 1;
			}
			//胜利数
			if (o1.getWin() > o2.getWin()) {
				return -1;
			} else if (o1.getWin() < o2.getWin()) {
				return 1;
			}
			//id
			if (o1.getDbId() < o2.getDbId()) {
				return -1;
			}
			return 1;
		}
	}
}
