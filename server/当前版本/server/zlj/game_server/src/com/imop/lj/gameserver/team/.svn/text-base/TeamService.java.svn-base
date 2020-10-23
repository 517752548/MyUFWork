package com.imop.lj.gameserver.team;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.team.TeamInfo;
import com.imop.lj.common.model.team.TeamInvitePlayerInfo;
import com.imop.lj.common.model.team.TeamMemberInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.battle.helper.IntIdHelper;
import com.imop.lj.gameserver.battle.helper.IntIdHelper.IntIdType;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.msg.GCBattleForceEnd;
import com.imop.lj.gameserver.broadcast.template.BroadcastTemplate;
import com.imop.lj.gameserver.chat.msg.GCChatMsg;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.TeamMemberChangeEvent;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.map.msg.GCMapTeamLeaderPosition;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.quest.msg.GCQuestUpdate;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.TaskListener;
import com.imop.lj.gameserver.task.template.QuestTemplate;
import com.imop.lj.gameserver.team.TeamDef.MemberAfterBattleStatus;
import com.imop.lj.gameserver.team.TeamDef.MemberStatus;
import com.imop.lj.gameserver.team.TeamDef.MemberType;
import com.imop.lj.gameserver.team.TeamDef.TeamInviteType;
import com.imop.lj.gameserver.team.TeamDef.TeamStatus;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamApplyer;
import com.imop.lj.gameserver.team.model.TeamMember;
import com.imop.lj.gameserver.team.model.TeamMemberChangeInfo;
import com.imop.lj.gameserver.team.msg.GCTeamApply;
import com.imop.lj.gameserver.team.msg.GCTeamApplyAuto;
import com.imop.lj.gameserver.team.msg.GCTeamCallBackNotice;
import com.imop.lj.gameserver.team.msg.GCTeamInviteList;
import com.imop.lj.gameserver.team.msg.GCTeamInvitePlayer;
import com.imop.lj.gameserver.team.msg.GCTeamInvitePlayerNotice;
import com.imop.lj.gameserver.team.msg.GCTeamQuit;
import com.imop.lj.gameserver.team.msg.TeamMsgBuilder;
import com.imop.lj.gameserver.team.task.TeamTask;
import com.imop.lj.gameserver.team.template.TeamTargetTemplate;

public class TeamService implements InitializeRequired {
	/** 组队战斗逻辑 */
	protected TeamBattleLogic<TeamBattleProcess> battleLogic = new TeamBattleLogic<TeamBattleProcess>();
	
	/** 队伍Map，key为队伍id */
	protected Map<Integer, Team> teamMap = Maps.newHashMap();
	/** 队员Map，key为队员id */
	protected Map<Long, TeamMember> memberMap = Maps.newHashMap();
	/** 已离线玩家id集合 */
	protected Set<Long> offlineSet = new LinkedHashSet<Long>();
	
	/** 开启自动匹配的队伍Id集合，value为目标Id */
	protected Map<Integer, Integer> autoMatchTeamIdMap = Maps.newHashMap();
	/** 自动加入队伍的玩家Id集合，value为目标Id */
	protected Map<Long, Integer> autoJoinPlayerIdMap = Maps.newHashMap();
	
	/** 所有可以显示的队伍Id集合，显示全部队伍用 */
	protected Set<Integer> teamIdSetForShow = new HashSet<Integer>();
	/** 按目标id索引的队伍Map<targetId, Set<队伍Id>>，分类显示用 */
	protected Map<Integer, Set<Integer>> targetTeamIdMapForShow = Maps.newHashMap();
	
	
	public TeamService() {
		
	}
	
	@Override
	public void init() {
		
	}
	
	public TeamBattleLogic<TeamBattleProcess> getTeamBattleLogic() {
		return battleLogic;
	}
	
	/**
	 * 玩家创建队伍
	 * @param human
	 */
	public void playerCreateTeam(Human human) {
		//能否创建队伍
		if (!canCreateTeam(human)) {
			human.sendErrorMessage(LangConstants.TEAM_CREATE_TEAM_FAIL);
			return;
		}
		
		//创建队伍
		Team team = createTeam(human);
		
		//队伍基础信息
		human.sendMessage(TeamMsgBuilder.buildGCTeamMyTeamInfo(team));
		//队员列表
		human.sendMessage(TeamMsgBuilder.buildGCTeamMyTeamMemberList(team));
		
		//提示创建队伍成功
		human.sendErrorMessage(LangConstants.TEAM_CREATE_OK);
	}
	
	/**
	 * 显示我的队伍
	 * @param human
	 */
	public void showMyTeam(Human human) {
		long roleId = human.getCharId();
		if (!isInTeam(roleId)) {
			return;
		}
		
		//获取我的队伍
		Team team = getHumanTeam(roleId);
		
		//队伍基础信息
		human.sendMessage(TeamMsgBuilder.buildGCTeamMyTeamInfo(team));
		//队员列表
		human.sendMessage(TeamMsgBuilder.buildGCTeamMyTeamMemberList(team));
	}
	
	/**
	 * 设置队伍的自动匹配
	 * @param human
	 * @param isAuto
	 */
	public void changeTeamAutoMatch(Human human, boolean isAuto, boolean notify) {
		long roleId = human.getCharId();
		if (!isTeamLeader(roleId)) {
			human.sendErrorMessage(LangConstants.TEAM_OP_FAIL);
			return;
		}
		
		Team team = getHumanTeam(roleId);
		if (team.isAutoMatch() == isAuto) {
			return;
		}
		
		//队伍必须有目标，才能设置为自动匹配
		if (isAuto && Globals.getTemplateCacheService().get(team.getTargetId(), TeamTargetTemplate.class) == null) {
			return;
		}
		
		//设置队伍的自动匹配
		team.setAutoMatch(isAuto);
		if (isAuto) {
			//将队伍加入到自动的数据结构中
			addAutoMatchTeam(team.getId(), team.getTargetId());
			//队伍变为自动后，检查加人进来
			onTeamBecomeAutoMatch(team);
		} else {
			removeAutoMatchTeam(team.getId());
		}
		
		//更新队伍信息，发给所有队员
		if (notify) {
			team.noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamInfo(team), true, true);
		}
	}
	
	/**
	 * 打开申请列表面板
	 * @param human
	 */
	public void openApplyListPanel(Human human) {
		long roleId = human.getCharId();
		if (!isTeamLeader(roleId)) {
			human.sendErrorMessage(LangConstants.TEAM_OP_FAIL);
			return;
		}
		
		Team team = getHumanTeam(roleId);
		//检查过期的申请，删掉
		checkApplyListOvertime(team);
		
		//构建申请者列表
		List<TeamMemberInfo> applyList = new ArrayList<TeamMemberInfo>();
		List<TeamApplyer> applySet = team.getApplySet();
		
		//申请者列表为空
		if(applySet.isEmpty()){
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.TEAM);
		}
		
		for (TeamApplyer applyer : applySet) {
			TeamMemberInfo info = buildApplyerInfo(applyer.getRoleId());
			if (info != null) {
				applyList.add(info);
			}
		}
		
		//发申请列表
		human.sendMessage(TeamMsgBuilder.buildGCTeamApplyList(applyList));
	}
	
	protected void checkApplyListOvertime(Team team) {
		List<TeamApplyer> removeList = new ArrayList<TeamApplyer>();
		for (TeamApplyer applyer : team.getApplySet()) {
			if (applyer == null) {
				continue;
			}
			if (applyer.getCreateTime() + Globals.getGameConstants().getTeamApplyExpiredTime() < Globals.getTimeService().now()) {
				removeList.add(applyer);
			}
			
			//申请者自己已经在队伍中的情况
			if (Globals.getTeamService().isInTeamNormal(applyer.getRoleId())){
				removeList.add(applyer);
			}
		}
		if (!removeList.isEmpty()) {
			team.getApplySet().removeAll(removeList);
		}
	}
	
	/**
	 * 清除申请列表
	 * @param human
	 */
	public void clearApplyList(Human human) {
		long roleId = human.getCharId();
		if (!isTeamLeader(roleId)) {
			human.sendErrorMessage(LangConstants.TEAM_OP_FAIL);
			return;
		}
		
		Team team = getHumanTeam(roleId);
		if (team.getApplySet().isEmpty()) {
			return;
		}
		
		//清除申请列表
		team.clearApplySet();
		
		//刷新申请列表
		human.sendMessage(TeamMsgBuilder.buildGCTeamApplyList(new ArrayList<TeamMemberInfo>()));
		
		//队长功能按钮变化
		Human leaderHuman = getTeamLeaderHuman(team);
		if (leaderHuman != null) {
			Globals.getFuncService().onFuncChanged(leaderHuman, FuncTypeEnum.TEAM);
		}
	}
	
	/**
	 * 接受申请者申请
	 * @param human
	 * @param targetRoleId
	 */
	public void agreeApplyer(Human human, long targetRoleId) {
		long roleId = human.getCharId();
		if (!isTeamLeader(roleId)) {
			human.sendErrorMessage(LangConstants.TEAM_OP_FAIL);
			return;
		}
		
		//目标玩家是否申请者
		Team team = getHumanTeam(roleId);
		TeamApplyer applyer = team.getApplyer(targetRoleId);
		if (applyer == null) {
			return;
		}
		
		//目标玩家是否在线
		Player targetPlayer = Globals.getOnlinePlayerService().getPlayer(targetRoleId);
		if (targetPlayer == null || targetPlayer.getHuman() == null || !targetPlayer.isOnline()) {
			human.sendErrorMessage(LangConstants.TEAM_OP_FAIL1);
			return;
		}
		
		//玩家加入队伍
		boolean flag = joinTeam(targetPlayer.getHuman(), team.getId(), false, human, false);
		if (flag) {
			//通过后移除申请者
			team.removeApplyer(applyer);
			//更新申请列表
			openApplyListPanel(human);
			//队长功能按钮变化
			Human leaderHuman = getTeamLeaderHuman(team);
			if (leaderHuman != null) {
				Globals.getFuncService().onFuncChanged(leaderHuman, FuncTypeEnum.TEAM);
			}
		} else {
			human.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL1);
		}
	}
	
	/**
	 * 选择队伍目标
	 * @param human
	 * @param targetId
	 * @param levelMin
	 * @param levelMax
	 * @param isAutoMatch
	 */
	public void chooseTarget(Human human, int targetId, int levelMin, int levelMax, boolean isAutoMatch) {
		long roleId = human.getCharId();
		if (!isTeamLeader(roleId)) {
			human.sendErrorMessage(LangConstants.TEAM_OP_FAIL);
			return;
		}
		if (levelMax < levelMin) {
			return;
		}
		TeamTargetTemplate targetTpl = Globals.getTemplateCacheService().get(targetId, TeamTargetTemplate.class);
		if (targetTpl != null) {
			if (levelMin < targetTpl.getLevelLimit()) {
				return;
			}
			//队长是否达到目标的最低等级要求
			if (human.getLevel() < targetTpl.getLevelLimit()) {
				return;
			}
		} else {
			//设置为无目标时，不能自动匹配
			isAutoMatch = false;
		}
		
		//修改队伍的目标和等级限制
		Team team = getHumanTeam(roleId);
		int oldTargetId = team.getTargetId();
		team.setTargetId(targetId);
		team.setLevelMin(levelMin);
		team.setLevelMax(levelMax);

		//修改队伍的自动匹配
		changeTeamAutoMatch(human, isAutoMatch, false);
		
		//显示相关的数据结构更新
		removeTargetTeam(oldTargetId, team.getId());
		onTeamChangedForShow(team);
		
		//更新队伍信息
		team.noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamInfo(team), true, true);
	}
	
	/**
	 * 打开队伍列表面板
	 * @param human
	 * @param targetId
	 */
	public void openTeamListPanel(Human human, int targetId) {
		long roleId = human.getCharId();
		if (isInTeam(roleId)) {
			//在队伍中，就不让看列表了
			return;
		}
		
		List<TeamInfo> teamInfoList = new ArrayList<TeamInfo>();
		//随机n个队伍
		List<Integer> teamIdList = randShowTeam(targetId);
		if (teamIdList != null && !teamIdList.isEmpty()) {
			for (Integer teamId : teamIdList) {
				Team team = getTeam(teamId);
				if (team != null) {
					TeamInfo info = buildTeamInfo(human, team);
					teamInfoList.add(info);
				}
			}
		}
		
		//发队伍列表消息
		human.sendMessage(TeamMsgBuilder.buildGCTeamShowList(teamInfoList, 
				getAutoMatchTeamNum(), getAutoJoinPlayerNum()));
	}
	
	/**
	 * 申请加入队伍
	 * @param human
	 * @param teamId
	 */
	public void applyJoinTeam(Human human, int teamId) {
		//是否能够加入队伍
		if (!canPlayerJoinTeam(human)) {
			return;
		}
		
		Team team = getTeam(teamId);
		if (team == null) {
			human.sendErrorMessage(LangConstants.TEAM_NOT_EXIST);
			return;
		}
		
		//队伍是否允许加入
		if (!canTeamBeJoined(team, human, true, null)) {
			return;
		}
		
		if (team.isAutoMatch()) {
			//队伍是自动匹配的，玩家直接加入队伍
			joinTeam(human, teamId, true, null, true);
		} else {
			if (!team.isApplyer(human.getCharId())) {
				//玩家加入申请列表
				team.addApplyer(new TeamApplyer(human.getCharId()));
				
				//队长功能按钮变化
				Human leaderHuman = getTeamLeaderHuman(team);
				if (leaderHuman != null) {
					Globals.getFuncService().onFuncChanged(leaderHuman, FuncTypeEnum.TEAM);
				}
			}
			//申请成功
			human.sendMessage(new GCTeamApply(teamId));
		}
	}
	
	public boolean hasApplyer(Human human) {
		long roleId = human.getCharId();
		if (isTeamLeader(roleId)) {
			return !getHumanTeam(roleId).getApplySet().isEmpty();
		}
		return false;
	}
	
	/**
	 * 玩家设置自动加入队伍或取消自动加入
	 * @param human
	 * @param isAuto
	 * @param targetId
	 */
	public void autoApplyJoinTeam(Human human, boolean isAuto, int targetId) {
		//是否能够加入队伍
		if (!canPlayerJoinTeam(human)) {
			return;
		}
		
		long roleId = human.getCharId();
		boolean isAutoPlayer = isAutoJoinPlayer(roleId);
		//当前已经是该状态
		if (isAutoPlayer == isAuto) {
			human.sendErrorMessage(LangConstants.TEAM_IS_ALREADY_AUTO_MATCH);
			return;
		}
		
		TeamTargetTemplate targetTpl = Globals.getTemplateCacheService().get(targetId, TeamTargetTemplate.class);
		if (isAuto && targetTpl == null) {
			//如果设置了自动，那么必须有目标才行
			human.sendErrorMessage(LangConstants.TEAM_NEED_TARGET);
			return;
		}
		
		if (isAuto) {
			//设置为自动加入
			addAutoJoinPlayer(roleId, targetId);
			//找自动匹配的队伍，让玩家加入
			letPlayerJoinAutoTeam(human, targetId);
		} else {
			//取消自动加入
			removeAutoJoinPlayer(roleId);
		}
		
		//通知玩家操作成功
		human.sendMessage(new GCTeamApplyAuto(isAuto ? 1 : 0, targetId));
	}
	
	/**
	 * 显示邀请玩家列表
	 * @param human
	 * @param invType
	 */
	public void showInviteList(Human human, TeamInviteType invType) {
		long roleId = human.getCharId();
		if (!isInTeam(roleId)) {
			return;
		}
		
		Team team = getHumanTeam(roleId);
		//队伍已满，不能再邀请人
		if (isTeamFull(team)) {
			human.sendErrorMessage(LangConstants.TEAM_IS_FULL);
			return;
		}
		
		List<Long> fList = null;
		List<TeamInvitePlayerInfo> retList = new ArrayList<TeamInvitePlayerInfo>();
		if (invType == TeamInviteType.FRIEND) {
			//获取玩家在线的好友
			fList = Globals.getRelationService().getPlayerOnlineFriendList(human);
		} else if (invType == TeamInviteType.CORPS) {
			//获取玩家军团在线的好友
			fList = Globals.getCorpsService().getCorpsOnlinePlayerList(human);
		}
		
		//转化为本地数据
		if (fList != null && !fList.isEmpty()) {
			for (Long rid : fList) {
				TeamInvitePlayerInfo info = buildTeamInvitePlayerInfo(rid);
				if (info != null) {
					retList.add(info);
				}
			}
		}
		
		//发好友或军团成员列表消息
		human.sendMessage(new GCTeamInviteList(invType.getIndex(), retList.toArray(new TeamInvitePlayerInfo[0])));
	}
	
	/**
	 * 邀请玩家加入队伍
	 * @param human
	 * @param invType
	 * @param targetRoleId
	 */
	public void invitePlayerJoinTeam(Human human, TeamInviteType invType, long targetRoleId) {
		long roleId = human.getCharId();
		if (!isInTeam(roleId)) {
			return;
		}
		
		Team team = getHumanTeam(roleId);
		//队伍已满，不能再邀请人
		if (isTeamFull(team)) {
			human.sendErrorMessage(LangConstants.TEAM_IS_FULL, 
					Globals.getOfflineDataService().getUserName(roleId));
			return;
		}
		
		//目标玩家是否已经在队伍中
		if (isInTeam(targetRoleId)) {
			human.sendErrorMessage(LangConstants.TEAM_INVITE_FAIL1, 
					Globals.getOfflineDataService().getUserName(targetRoleId));
			return;
		}
		
		List<Long> fList = null;
		if (invType == TeamInviteType.FRIEND) {
			//获取玩家在线的好友
			fList = Globals.getRelationService().getPlayerOnlineFriendList(human);
		} else if (invType == TeamInviteType.CORPS) {
			//获取玩家军团在线的好友
			fList = Globals.getCorpsService().getCorpsOnlinePlayerList(human);
		}
		
		//判断邀请的目标是否存在
		if (fList == null || !fList.contains(targetRoleId)) {
			human.sendErrorMessage(LangConstants.TEAM_INVITE_FAIL2);
			return;
		}
		
		//获取目标玩家Human
		Player tPlayer = Globals.getOnlinePlayerService().getPlayer(targetRoleId);
		if (tPlayer == null || tPlayer.getHuman() == null) {
			return;
		}
		Human targetHuman = tPlayer.getHuman();
		
		//目标是否能加入队伍
		boolean flag = canTeamBeJoined(team, targetHuman, false, human);
		if (!flag) {
			return;
		}
		
		//加入受邀列表
		team.addInvite(roleId, targetRoleId);
		
		//发操作成功消息
		human.sendMessage(new GCTeamInvitePlayer(targetRoleId));
		
		//给目标玩家发有邀请的消息
		targetHuman.sendMessage(new GCTeamInvitePlayerNotice(team.getId(), human.getCharId(), human.getName()));
	}
	
	/**
	 * 受邀玩家应答邀请
	 * @param human
	 * @param teamId
	 * @param isAgree
	 */
	public void invitedPlayerAnswer(Human human, int teamId, boolean isAgree) {
		long roleId = human.getCharId();
		//目标队伍是否还存在
		if (!hasTeam(teamId)) {
			human.sendErrorMessage(LangConstants.TEAM_NOT_EXIST);
			return;
		}
		
		Human invHuman = null;
		Team team = getTeam(teamId);
		Long inviterId = team.getInviterId(roleId);
		if (inviterId != null) {
			//如果在受邀列表中，则移除
			team.removeInvite(roleId);
			
			//获取邀请玩家Human
			Player invPlayer = Globals.getOnlinePlayerService().getPlayer(inviterId);
			if (invPlayer != null && invPlayer.getHuman() != null) {
				invHuman = invPlayer.getHuman();
			}
		} else {
			//玩家没有收到邀请，或队伍人数已满 邀请列表已清空
			if (isAgree) {
				human.sendErrorMessage(LangConstants.TEAM_INVITE_TARGET_JOIN_FAIL1);
			}
			return;
		}
		
		//玩家不同意，通知邀请人
		if (!isAgree) {
			if (invHuman != null) {
				invHuman.sendErrorMessage(LangConstants.TEAM_INVITE_TARGET_DENY, human.getName());
			}
			return;
		}

		//玩家同意加入队伍
		if (isInTeam(roleId)) {
			//受邀玩家当前已在队伍中
			if (invHuman != null) {
				invHuman.sendErrorMessage(LangConstants.TEAM_INVITE_TARGET_HAD_JOIN, human.getName());
			}
			return;
		}
		
		//目标是否能加入队伍
		boolean flag = canTeamBeJoined(team, human, false, null);
		if (!flag) {
			if (invHuman != null) {
				invHuman.sendErrorMessage(LangConstants.TEAM_INVITE_TARGET_JOIN_FAIL, human.getName());
			}
			return;
		}
		
		//加入队伍
		boolean jFlag = joinTeam(human, teamId, false, null, true);
		if (jFlag) {
			if (invHuman != null) {
				invHuman.sendErrorMessage(LangConstants.TEAM_INVITE_TARGET_JOIN_OK, human.getName());
			}
		}
	}
	
	/**
	 * 玩家点击暂离队伍
	 * @param human
	 */
	public void playerAwayFromTeam(Human human) {
		long roleId = human.getCharId();
		if (!isInTeam(roleId)) {
			return;
		}
		//队长不能暂离
		if (isTeamLeader(roleId)) {
			return;
		}
		//当前是否已经是暂离状态
		if (isAwayStatus(roleId)) {
			return;
		}
		
		//队伍战斗中，战斗结束后才能暂离
		if (getHumanTeam(roleId).isInBattle()) {
			getTeamMember(roleId).setAfterBattleStatus(MemberAfterBattleStatus.AWAY);
			human.sendErrorMessage(LangConstants.TEAM_AWAY_FAIL);
			return;
		}
		
		//队员暂离队伍
		memberAwayFromTeam(roleId);
	}
	
	/**
	 * 玩家点击退出队伍
	 * @param human
	 */
	public void playerLeaveTeam(Human human) {
		long roleId = human.getCharId();
		if (!isInTeam(roleId)) {
			return;
		}
		
		//队伍战斗中，战斗结束后才能退出
		if (getHumanTeam(roleId).isInBattle()) {
			getTeamMember(roleId).setAfterBattleStatus(MemberAfterBattleStatus.LEAVE);
			human.sendErrorMessage(LangConstants.TEAM_LEAVE_FAIL);
			return;
		}
		
		//队员退队
		memberLeaveTeam(roleId);
	}
	
	public void forceMemberLeaveTeam(long roleId, String source) {
		if (!isInTeam(roleId)) {
			return;
		}
		
		//队员退队
		memberLeaveTeam(roleId);
		
		Loggers.teamLogger.warn("forceMemberLeaveTeam roleId=" + roleId + ";source=" + source);
	}
	
	/**
	 * 玩家点击归队
	 * @param human
	 */
	public void playerReturnTeam(Human human) {
		long roleId = human.getCharId();
		if (!isInTeam(roleId)) {
			return;
		}
		//当前已经是普通状态
		if (isInTeamNormal(roleId)) {
			return;
		}
		
		//玩家当前能否归队
		if (human.isInAnyBattle()) {
			human.sendErrorMessage(LangConstants.TEAM_RETURN_FAIL1);
			return;
		}
		
		Team team = getHumanTeam(roleId);
		//队伍为活动中状态时，不能归队
		if (team.isDoing()) {
			human.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL4);
			return;
		}
		
		//队伍当前是否战斗中
		if (team.isInBattle()) {
			//设置为队伍战斗结束后归队
			getTeamMember(roleId).setAfterBattleStatus(MemberAfterBattleStatus.NORMAL);
			human.sendErrorMessage(LangConstants.TEAM_RETURN_FAIL2);
			return;
		}
		
		//归队时不再判断队伍地图能否进入，队伍任务是否可接，因为进地图的时候，接任务的时候，所有人都经过判断了
		
		//立即归队
		memberReturnTeam(human);
	}
	
	/**
	 * 队长召回队员
	 * @param human
	 * @param targetRoleId
	 */
	public void callPlayerBack(Human human, long targetRoleId) {
		long roleId = human.getCharId();
		//只有队长有权限
		if (!isTeamLeader(roleId)) {
			return;
		}
		
		//是否和队长同一个队伍的
		Team team = getHumanTeam(roleId);
		if (!team.hasMember(targetRoleId)) {
			return;
		}
		
		//目标当前是否暂离状态
		if (!isAwayStatus(targetRoleId)) {
			return;
		}
		
//		//给队长发消息
//		human.sendErrorMessage(LangConstants.TEAM_CALL_BACK_MEMBER);
		
		//通知目标玩家归队
		Player targetPlayer = Globals.getOnlinePlayerService().getPlayer(targetRoleId);
		if (targetPlayer != null && targetPlayer.getHuman() != null) {
			targetPlayer.sendMessage(new GCTeamCallBackNotice());
		}
	}
	
	/**
	 * 队长世界喊话，招人
	 * @param human
	 */
	public void teamChatJoin(Human human) {
		long roleId = human.getCharId();
		//只有队长有权限
		if (!isTeamLeader(roleId)) {
			return;
		}
		
		//队伍已满
		Team team = getHumanTeam(roleId);
		if (isTeamFull(team)) {
			human.sendErrorMessage(LangConstants.TEAM_IS_FULL);
			return;
		}
		
		TeamTargetTemplate tpl = Globals.getTemplateCacheService().get(team.getTargetId(), TeamTargetTemplate.class);
		//队伍必须有目标才行
		if (tpl == null) {
			human.sendErrorMessage(LangConstants.TEAM_NEED_TARGET);
			return;
		}
		
		//发组队频道的聊天内容
		int scope = SharedConstants.CHAT_SCOPE_COMMON_TEAM;
		long snapTime = Globals.getChatService().getSnapTime(scope);
		if (Globals.getTimeService().now() - human.getPlayer().getLastChatTime(scope) < snapTime) {
			String channel = Globals.getLangService().readSysLang(LangConstants.CHAT_COMMON_TEAM_CHANNEL);
			human.sendSystemMessage(LangConstants.CHAT_WORLD_TOO_FAST, channel, Globals.getGameConstants().getCommonTeamChat());
			return;
		}
		
		BroadcastTemplate broadcastTpl = Globals.getTemplateCacheService().get(Globals.getGameConstants().getTeamChatJoinTplId(), BroadcastTemplate.class);
		if (broadcastTpl != null) {
			String contents = MessageFormat.format(broadcastTpl.getContents(),  
					tpl.getName(), team.getLevelMin(), team.getLevelMax(), team.getId()+"");
			Globals.getChatService().handleCommonTeamChat(human, contents);
		}
	}
	
	/**
	 * 修改队员的位置
	 * @param human
	 * @param targetRoleId
	 * @param targetPosition
	 */
	public void changePlayerPosition(Human human, long targetRoleId, int targetPosition) {
		long roleId = human.getCharId();
		//只有队长有权限
		if (!isTeamLeader(roleId)) {
			return;
		}
		
		//是否和队长同一个队伍的
		Team team = getHumanTeam(roleId);
		if (!team.hasMember(targetRoleId)) {
			return;
		}
		
		//队长位置始终是1，不能调整
		if (roleId == targetRoleId) {
			return;
		}
		
		//位置是否合法，最少变为2号位置，最多变为当前人数的位置
		if (targetPosition <= 1 || targetPosition > team.getMemberNum()) {
			return;
		}
		
		TeamMember tm = getTeamMember(targetRoleId);
		//位置没变
		if (tm.getPosition() == targetPosition) {
			return;
		}
		
		//战斗中
		if (team.isInBattle()) {
			human.sendErrorMessage(LangConstants.TEAM_KICK_FAIL);
			return;
		}
		
		//队员位置变化
		List<TeamMember> memberList = team.getMemberList();
		if (memberList.remove(tm)) {
			memberList.add(targetPosition - 1, tm);
			int pos = 0;
			for (TeamMember m : memberList) {
				m.setPosition(++pos);
			}
		}
		
		//队伍变化，通知队员
		team.noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamMemberList(team), true, true);
	}
	
	/**
	 * 更换队长
	 * @param human
	 * @param targetRoleId
	 */
	public void playerChangeLeader(Human human, long targetRoleId) {
		long roleId = human.getCharId();
		//只有队长有权限
		if (!isTeamLeader(roleId)) {
			return;
		}
		//是否和队长同一个队伍的
		Team team = getHumanTeam(roleId);
		if (!team.hasMember(targetRoleId)) {
			return;
		}
		//当前是否正常状态
		if (!isInTeamNormal(roleId)) {
			human.sendErrorMessage(LangConstants.TEAM_CHANGE_LEADER_FAIL);
			return;
		}
		if (roleId == targetRoleId) {
			return;
		}
		//战斗中
		if (team.isInBattle()) {
			human.sendErrorMessage(LangConstants.TEAM_KICK_FAIL);
			return;
		}
		
		//更换队长
		changeLeader(team, targetRoleId);
	}
	
	/**
	 * 队长踢人
	 * @param human
	 * @param targetRoleId
	 */
	public void kickPlayer(Human human, long targetRoleId) {
		long roleId = human.getCharId();
		//只有队长有权限
		if (!isTeamLeader(roleId)) {
			human.sendErrorMessage(LangConstants.TEAM_OP_FAIL2);
			return;
		}
		//是否和队长同一个队伍的
		Team team = getHumanTeam(roleId);
		if (!team.hasMember(targetRoleId)) {
			return;
		}
		//不能踢自己
		if (roleId == targetRoleId) {
			return;
		}
		//战斗中
		if (team.isInBattle()) {
			human.sendErrorMessage(LangConstants.TEAM_KICK_FAIL);
			return;
		}
		
		//离队
		memberLeaveTeam(targetRoleId);
	}
	
	protected TeamInvitePlayerInfo buildTeamInvitePlayerInfo(long roleId) {
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(roleId);
		if (userSnap != null) {
			TeamInvitePlayerInfo info = new TeamInvitePlayerInfo();
			info.setUuid(roleId);
			info.setJobTypeId(userSnap.getHumanJobTypeId());
			info.setLevel(userSnap.getLevel());
			info.setName(userSnap.getName());
			info.setTplId(userSnap.getHumanTplId());
			return info;
		}
		return null;
	}
	
	/**
	 * 玩家设置为自动加入时，遍历所有自动的队伍，看能否让玩家加入
	 * @param human
	 * @param targetId
	 */
	protected void letPlayerJoinAutoTeam(Human human, int targetId) {
		for (Entry<Integer, Integer> entry : autoMatchTeamIdMap.entrySet()) {
			if (targetId == entry.getValue()) {
				int teamId = entry.getKey();
				boolean flag = joinTeam(human, teamId, false, null, true);
				if (flag) {
					//成功加入队伍
					return;
				}
			}
		}
	}
	
	/**
	 * 当队伍设置为自动匹配时，遍历所有自动加入的玩家，看能否进队伍
	 * @param team
	 */
	protected void onTeamBecomeAutoMatch(Team team) {
		if (!team.isAutoMatch()) {
			return;
		}
		int targetId = team.getTargetId();
		if (targetId <= 0) {
			return;
		}
		
		Set<Long> tmp = new HashSet<Long>();
		tmp.addAll(autoJoinPlayerIdMap.keySet());
		
		for (Long roleId : tmp) {
			int tId = autoJoinPlayerIdMap.get(roleId);
			//目标相同，且玩家在线
			if (tId == targetId 
					&& isPlayerOnline(roleId)) {
				Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
				//玩家状态判断
				if (canPlayerJoinTeam(human)) {
					//队伍状态判断，如果队伍不能被加入，则退出
					if (canTeamBeJoined(team, human, false, null)) {
						boolean flag = joinTeam(human, team.getId(), false, null, true);
						if (flag) {
							//成功加入队伍
							return;
						}
					} else {
						//队伍当前不能加人，退出
						return;
					}
				}
			}
		}
	}
	
	/**
	 * 从显示缓存数据结构中，随机n个队伍id
	 * @param targetId
	 * @return
	 */
	protected List<Integer> randShowTeam(int targetId) {
		Set<Integer> randSet = null;
		if (targetId == 0) {
			randSet = this.teamIdSetForShow;
		} else {
			randSet = this.targetTeamIdMapForShow.get(targetId);
		}
		if (randSet == null) {
			return null;
		}
		
		List<Integer> hitList = new ArrayList<Integer>();
		int max = Globals.getGameConstants().getTeamShowMaxNum();
		if (randSet.size() <= max) {
			hitList.addAll(randSet);
		} else {
			//随机max个队伍id
			List<Integer> tmp = new ArrayList<Integer>();
			tmp.addAll(randSet);
			hitList = RandomUtils.hitObjects(tmp, max);
		}
		return hitList;
	}
	
	/**
	 * 更新与显示相关的缓存数据结构
	 * @param team
	 */
	protected void onTeamChangedForShow(Team team) {
		if (!isTeamFull(team)) {
			//队伍未满员
			addShowTeamId(team);
			addTargetTeam(team);
		} else {
			//队伍已经满员
			removeShowTeamId(team.getId());
			removeTargetTeam(team.getTargetId(), team.getId());
		}
	}
	
	/**
	 * 队伍是否人数已满
	 * @param team
	 * @return
	 */
	public boolean isTeamFull(Team team) {
		return team.getMemberNum() >= TeamDef.MAX_TEAM_MEMBER_NUM;
	}
	
	public TeamMemberInfo buildTeamMemberInfo(TeamMember tm) {
		TeamMemberInfo info = new TeamMemberInfo();
		info.setUuid(tm.getRoleId());
		info.setJobTypeId(tm.getJobTypeId());
		info.setLevel(tm.getLevel());
		info.setName(tm.getName());
		info.setTplId(tm.getTplId());
		info.setIsLeader(tm.getType() == MemberType.LEADER ? 1 : 0);
		info.setPosition(tm.getPosition());
		info.setStatus(tm.getStatus().getIndex());
		info.setEquipWeaponId(Globals.getEquipService().getLeaderWeaponTplId(tm.getRoleId()));
		return info;
	}
	
	public TeamMemberInfo buildApplyerInfo(long charId) {
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(charId);
		if (userSnap != null) {
			TeamMemberInfo info = new TeamMemberInfo();
			info.setUuid(charId);
			info.setJobTypeId(userSnap.getHumanJobTypeId());
			info.setLevel(userSnap.getLevel());
			info.setName(userSnap.getName());
			info.setTplId(userSnap.getHumanTplId());
			return info;
		}
		return null;
	}
	
	protected TeamInfo buildTeamInfo(Human human, Team team) {
		TeamInfo info = new TeamInfo();
		info.setTeamId(team.getId());
		info.setLevelMin(team.getLevelMin());
		info.setLevelMax(team.getLevelMax());
		info.setMemberNum(team.getMemberNum());
		info.setTargetId(team.getTargetId());
		info.setLevel(team.getLeader().getLevel());
		info.setName(team.getLeader().getName());
		info.setJobTypeId(team.getLeader().getJobTypeId());
		info.setApplyStatus(team.isApplyer(human.getCharId()) ? 1 : 0);
		info.setTeamStatus(team.getStatus().getIndex());
		return info;
	}
	
	protected void addOffline(long roleId) {
		this.offlineSet.add(roleId);
	}
	
	protected void removeOffline(long roleId) {
		this.offlineSet.remove(roleId);
	}

	public Team getTeam(int teamId) {
		return teamMap.get(teamId);
	}
	
	protected boolean hasTeam(int teamId) {
		return teamMap.containsKey(teamId);
	}
	
	protected void addTeam(Team team) {
		teamMap.put(team.getId(), team);
	}
	
	protected void removeTeam(Team team) {
		teamMap.remove(team.getId());
	}
	
	public TeamMember getTeamMember(long roleId) {
		return this.memberMap.get(roleId);
	}
	
	protected void addMember(TeamMember member) {
		this.memberMap.put(member.getRoleId(), member);
	}
	
	protected void removeMember(TeamMember member) {
		this.memberMap.remove(member.getRoleId());
	}
	
	protected void addAutoMatchTeam(int teamId, int targetId) {
		if (targetId > 0 && teamId > 0) {
			this.autoMatchTeamIdMap.put(teamId, targetId);
		}
	}
	
	protected void removeAutoMatchTeam(int teamId) {
		this.autoMatchTeamIdMap.remove(teamId);
	}
	
	protected int getAutoMatchTeamNum() {
		return this.autoMatchTeamIdMap.size();
	}
	
	protected int getAutoJoinPlayerNum() {
		return this.autoJoinPlayerIdMap.size();
	}
	
	protected void addAutoJoinPlayer(long roleId, int targetId) {
		if (roleId > 0 && targetId > 0) {
			this.autoJoinPlayerIdMap.put(roleId, targetId);
		}
	}
	
	protected void removeAutoJoinPlayer(long roleId) {
		this.autoJoinPlayerIdMap.remove(roleId);
	}
	
	protected boolean isAutoJoinPlayer(long roleId) {
		return this.autoJoinPlayerIdMap.containsKey(roleId);
	}
	
	protected int getAutoJoinPlayerTargetId(long roleId) {
		if (isAutoJoinPlayer(roleId)) {
			return this.autoJoinPlayerIdMap.get(roleId);
		}
		return 0;
	}
	
	protected void addShowTeamId(Team team) {
		this.teamIdSetForShow.add(team.getId());
	}
	
	protected void removeShowTeamId(int teamId) {
		this.teamIdSetForShow.remove(teamId);
	}
	
	protected void addTargetTeam(Team team) {
		int targetId = team.getTargetId();
		if (targetId > 0) {
			Set<Integer> s = this.targetTeamIdMapForShow.get(targetId);
			if (s == null) {
				s = new HashSet<Integer>();
				this.targetTeamIdMapForShow.put(targetId, s);
			}
			s.add(team.getId());
		}
	}
	
	protected void removeTargetTeam(int targetId, int teamId) {
		Set<Integer> s = this.targetTeamIdMapForShow.get(targetId);
		if (s != null) {
			this.targetTeamIdMapForShow.remove(teamId);
		}
	}

	public boolean isInTeam(long roleId) {
		return this.memberMap.containsKey(roleId);
	}
	
	protected void onMemberJoinTeam(TeamMember member, Team team) {
		team.addMember(member);
		member.setTeam(team);
		addMember(member);
		//自动加入中移除
		removeAutoJoinPlayer(member.getRoleId());
	}
	
	protected void onMemberLeaveTeam(TeamMember member) {
		//map中移除队员
		removeMember(member);
		//队伍中移除队员
		member.getTeam().removeMember(member);
		//离线中移除
		removeOffline(member.getRoleId());
	}
	
	/**
	 * 玩家是否在队伍中且状态为正常
	 * @param roleId
	 * @return
	 */
	public boolean isInTeamNormal(long roleId) {
		TeamMember tm = getTeamMember(roleId);
		if (tm != null && 
				tm.getStatus() == MemberStatus.NORMAL) {
			return true;
		}
		return false;
	}
	
	protected TeamMember createTeamMember(Human human, MemberStatus status, MemberType mt, int pos) {
		long roleId = human.getCharId();
		TeamMember tm = new TeamMember();
		tm.setRoleId(roleId);
		tm.setStatus(status);
		tm.setType(mt);
		tm.setPosition(pos);
		return tm;
	}
	
	protected boolean canCreateTeam(Human human) {
		long roleId = human.getCharId();
		//有队伍，不能再创建
		if (isInTeam(roleId)) {
			return false;
		}
		//战斗中，不能创建队伍
		if (human.isInAnyBattle()) {
			return false;
		}
		//玩家在绿野仙踪中，不能创建队伍
		if (Globals.getWizardRaidService().isPlayerInSingle(roleId)) {
			return false;
		}
		
		//玩家在采集中,不能创建队伍
		if(human.isInGather()){
			return false;
		}
		
		return true;
	}
	
	protected Team createTeam(Human human) {
		//能否创建队伍
		if (!canCreateTeam(human)) {
			return null;
		}

		//创建队伍
		Team team = new Team();
		int teamId = IntIdHelper.genNextIntId(IntIdType.TEAM, this.teamMap.keySet());
		if (teamId == 0) {
			//没有可用id时，使用hashCode
			teamId = team.hashCode();
		}
		team.setId(teamId);
		team.setStatus(TeamStatus.NORMAL);
		
		//默认等级要求
		team.setLevelMin(RoleConstants.HUMAN_INIT_LEVEL_NUM);
		team.setLevelMax(Globals.getGameConstants().getLevelMax());
		
		//设置队伍位置信息
		team.setMapId(human.getMapId());
		team.setX(human.getX());
		team.setY(human.getY());
		//设置备用地图
		team.setBackMapId(human.getBackMapId());
		team.setBackX(human.getBackX());
		team.setBackY(human.getBackY());
		
		//队伍加入map
		addTeam(team);
		
		//创建队长
		TeamMember leader = createTeamMember(human, MemberStatus.NORMAL, MemberType.LEADER, getTeamNextPos(team));
		//队长加入队伍
		onMemberJoinTeam(leader, team);
		
		//显示相关的数据结构更新
		onTeamChangedForShow(team);
		//通知附近玩家，队长变化
		noticeNearLeaderChanged(leader.getRoleId());
		
		//调用队员离队的监听
		Globals.getEventService().fireEvent(new TeamMemberChangeEvent(new TeamMemberChangeInfo(leader.getRoleId(), team.getId(), 
				true, false, false, team.isDoing(), false)));
		return team;
	}
	
	/**
	 * 玩家能否加入队伍
	 * @param human
	 * @return
	 */
	protected boolean canPlayerJoinTeam(Human human) {
		long roleId = human.getCharId();
		//有队伍，不能再加入
		if (isInTeam(roleId)) {
			return false;
		}
		//玩家在绿野仙踪中，不能加入队伍
		if (Globals.getWizardRaidService().isPlayerInSingle(roleId)) {
			return false;
		}
		
		//玩家在采集中,不能加入队伍
		if(human.isInGather()){
			return false;
		}
		
		//玩家挂机中,不能加入队伍
		if(human.isInGuaJi()){
			return false;
		}
		return true;
	}
	
	protected boolean canTeamBeJoined(Team team, Human human, boolean notify, Human noticeHuman) {
		//队伍人数是否已满
		if (team.getMemberNum() >= TeamDef.MAX_TEAM_MEMBER_NUM) {
			if (notify) { 
				human.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL2);
			}
			if (noticeHuman != null) {
				noticeHuman.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL2);
			}
			return false;
		}
		//等级是否满足
		if (human.getLevel() < team.getLevelMin() || human.getLevel() > team.getLevelMax()) {
			if (notify) {
				human.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL3);
			}
			if (noticeHuman != null) {
				noticeHuman.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL3);
			}
			return false;
		}
		//队伍当前状态，是否允许加人
		if (team.isDoing()) {
			if (notify) {
				human.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL4);
			}
			if (noticeHuman != null) {
				noticeHuman.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL4);
			}
			return false;
		}
		
		long roleId = human.getCharId();
		//队伍当前地图，是否能进入，如果不能，则不能入队
		if (!isPlayerSatisfyMapLimit(roleId, team)) {
			if (notify) {
				human.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL5);
			}
			if (noticeHuman != null) {
				noticeHuman.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL5);
			}
			return false;
		}
		
		//队伍当前任务，是否能接，如果不能，则不能入队
		if (!canPlayerAcceptTeamTaskForJoinCheck(team, roleId)) {
			if (notify) {
				human.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL6);
			}
			if (noticeHuman != null) {
				noticeHuman.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL6);
			}
			return false;
		}

		return true;
	}

	/**
	 * 仅判断地图自身的条件是否满足
	 * @param roleId
	 * @param mapId
	 * @return
	 */
	protected boolean isPlayerSatisfyMapLimit(long roleId, Team team) {
		AbstractGameMap gameMap = Globals.getMapService().getGameMap(team.getMapId(), team.getLeader().getRoleId());
		if (gameMap != null) {
			return gameMap.canUserEnterMap(roleId, false);
		}
		return false;
	}
	
	/**
	 * XXX 只判断玩家等级能否接受任务，其他任务条件不做判断
	 * @param team
	 * @param roleId
	 * @return
	 */
	protected boolean canPlayerAcceptTeamTaskForJoinCheck(Team team, long roleId) {
		//判断玩家能否接队伍任务，如果不能接，则不能入队
		TeamTask curTask = team.getTaskManager().getCurTask();
		if (curTask != null) {
			int level = 0;
			UserSnap us = Globals.getOfflineDataService().getUserSnap(roleId);
			if (us != null) {
				level = us.getLevel();
			}
			return team.getTaskManager().levelCheckOnAccept(curTask.getTemplate(), level);
		}
		return true;
	}
	
	protected boolean joinTeam(Human human, int teamId, boolean notify, Human noticeHuman, boolean noticeJoiner) {
		//队伍是否存在
		if (!hasTeam(teamId)) {
			return false;
		}
		
		//玩家能否加入队伍
		if (!canPlayerJoinTeam(human)) {
			if (noticeJoiner) {
				human.sendErrorMessage(LangConstants.TEAM_JOIN_FAIL1);
			}
			return false;
		}
		
		Team joinTeam = getTeam(teamId);
		if (!canTeamBeJoined(joinTeam, human, notify, noticeHuman)) {
			return false;
		}
		
		//队员状态
		MemberStatus status = MemberStatus.NORMAL;
		//如果队伍正在战斗中，则新加入的队员为暂离状态
		if (joinTeam.isInBattle() || human.isInAnyBattle()) {
			status = MemberStatus.AWAY;
		}
		
		//创建队员
		TeamMember member = createTeamMember(human, status, MemberType.MEMBER, getTeamNextPos(joinTeam));
		//加入队伍
		onMemberJoinTeam(member, joinTeam);
		
		//显示相关的数据结构更新
		onTeamChangedForShow(joinTeam);
		
		if (isTeamFull(joinTeam)) {
			//队伍已满，取消自动匹配
			removeAutoMatchTeam(teamId);
			//队伍已满，清空受邀列表
			joinTeam.clearInviteSet();
		}
		
		//通知成员，更新成员列表
		joinTeam.noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamMemberList(joinTeam), true, true);
		//发队伍信息给玩家
		human.sendMessage(TeamMsgBuilder.buildGCTeamMyTeamInfo(joinTeam));
		//队伍任务
		if (joinTeam.getTaskManager().isDoing()) {
			human.sendMessage(new GCQuestUpdate(joinTeam.getTaskManager().getCurTask().buildQuestInfo()));
		}
		
		//如果加入队伍的时候为正常状态，则回到队长身边
		if (member.getStatus() == MemberStatus.NORMAL) {
			onReturnTeam(joinTeam, member.getRoleId());
		}
		//调用队员变化的监听
		Globals.getEventService().fireEvent(new TeamMemberChangeEvent(new TeamMemberChangeInfo(member.getRoleId(), joinTeam.getId(), 
				true, false, false, joinTeam.isDoing(), false)));
		return true;
	}
	
	protected int getTeamNextPos(Team team) {
		return team.getMemberNum() + 1;
	}
	
	/**
	 * 队员暂离队伍
	 * @param roleId
	 */
	protected void memberAwayFromTeam(long roleId) {
		TeamMember tm = getTeamMember(roleId);
		if (tm == null) {
			return;
		}
		//当前已是暂离状态
		if (tm.getStatus() == MemberStatus.AWAY) {
			return;
		}
		//队长暂离，则自动更换队长
		if (tm.getType() == MemberType.LEADER) {
			boolean flag = autoChangeLeader(tm.getTeam());
			if (!flag) {
				//更换队长失败，则队伍解散，直接返回
				return;
			}
		}
		
		//如果队伍处于不可暂离状态，则直接退队
		if (tm.getTeam().isDoingNoAway()) {
			memberLeaveTeam(roleId);
			return;
		}
		
		//设置为暂离状态
		tm.setStatus(MemberStatus.AWAY);
		
		//通知成员，有人状态发生变化
		tm.getTeam().noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamMemberList(tm.getTeam()), true, true);
		
		//调用队员暂离的监听
		Globals.getEventService().fireEvent(new TeamMemberChangeEvent(new TeamMemberChangeInfo(roleId, tm.getTeam().getId(), 
				false, true, false, tm.getTeam().isDoing(), false)));
	}
	
	/**
	 * 队员归队
	 * @param human
	 */
	protected void memberReturnTeam(Human human) {
		
		if(!canPlayerReturnTeam(human)){
			return;
		}
		
		long roleId = human.getCharId();
		TeamMember tm = getTeamMember(roleId);
		if (tm == null) {
			return;
		}
		//当前已是普通状态
		if (tm.getStatus() == MemberStatus.NORMAL) {
			return;
		}
		
		//设置为普通状态
		tm.setStatus(MemberStatus.NORMAL);

		//通知成员，有人状态发生变化
		tm.getTeam().noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamMemberList(tm.getTeam()), true, true);
		
		//回到队长身边
		onReturnTeam(tm.getTeam(), roleId);
		
		//调用队员变化的监听
		Globals.getEventService().fireEvent(new TeamMemberChangeEvent(new TeamMemberChangeInfo(tm.getRoleId(), tm.getTeam().getId(), 
				true, false, false, tm.getTeam().isDoing(), false)));
	}

	private boolean canPlayerReturnTeam(Human human) {
		//玩家处于战斗中，不能归队
		if (human.isInAnyBattle()) {
			return false;
		}
		
		//玩家在挂机中,停止挂机后归队
		if(human.isInGuaJi()){
			Globals.getGuaJiService().pauseGuaJi(human);
		}
		
		//玩家采集中,不能归队
		if(human.isInGather()){
			human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_DOING);
			return false;
		}
		
		return true;
	}
	
	/**
	 * 队员归队时，回到队长身边的处理
	 * @param team
	 * @param roleId
	 */
	protected void onReturnTeam(Team team, long roleId) {
		//归队，队长不需要
		if (team.getLeader().getRoleId() == roleId) {
			return;
		}
		//队员，飞到队长身边
		if (isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			if (human.getMapId() != team.getMapId()) {
				//玩家回到队长身边
				Globals.getMapService().enterMap(human, team.getMapId());
			}
			//发队伍位置给玩家，跑到队长身边
			human.sendMessage(new GCMapTeamLeaderPosition(team.getLeader().getRoleId(), 
					team.getMapId(), team.getX(), team.getY()));
		}
	}
	
	/**
	 * 队员离队
	 * @param roleId
	 */
	protected void memberLeaveTeam(long roleId) {
		TeamMember tm = getTeamMember(roleId);
		if (tm == null) {
			return;
		}
		//队长离开队伍，则自动切换队长
		if (tm.getType() == MemberType.LEADER) {
			boolean flag = autoChangeLeader(tm.getTeam());
			//切换队长失败，队伍解散
			if (!flag) {
				return;
			}
		}
		
		Team team = tm.getTeam();
		int teamId = team.getId();
		boolean isDoing = team.isDoing();
		
		//移除队员
		onMemberLeaveTeam(tm);
		
		//显示相关的数据结构更新
		onTeamChangedForShow(team);
		
		//通知成员，更新成员列表
		tm.getTeam().noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamMemberList(tm.getTeam()), true, true);
		
		//离开的玩家，发退出队伍消息
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player != null && player.getHuman() != null) {
			player.sendMessage(new GCTeamQuit());
			//提示玩家已经退出队伍
			player.sendErrorMessage(LangConstants.TEAM_QUIT_OK);
		}
		
		//调用队员离队的监听
		Globals.getEventService().fireEvent(new TeamMemberChangeEvent(new TeamMemberChangeInfo(roleId, teamId, 
				false, false, false, isDoing, false)));
	}
	
	/**
	 * 队伍解散
	 * @param teamId
	 */
	protected void dismissTeam(int teamId) {
		Team team = getTeam(teamId);
		if (team == null) {
			return;
		}
		
		//如果队伍正在战斗中，则强制结束战斗
		if (team.isInBattle() && battleLogic.getBattle(team.getCurBattleId()) != null) {
			battleLogic.forceEndBattle(battleLogic.getBattle(team.getCurBattleId()), "dismissTeam");
		}
		
		long leaderId = team.getLeader().getRoleId();
		//删除队员
		for (TeamMember tm : team.getMemberMap().values()) {
			long roleId = tm.getRoleId();
			//删除member
			removeMember(tm);
			//从离线set中删除
			removeOffline(roleId);
		}
		//map中删除队伍
		removeTeam(team);
		
		//显示相关的数据结构更新
		removeShowTeamId(teamId);
		removeTargetTeam(team.getTargetId(), teamId);
		//从自动匹配中删除
		removeAutoMatchTeam(teamId);
		
		//通知成员，队伍解散
		team.noticeTeamMember(new GCTeamQuit(), true, true);
		team.noticeTeamMemberErrorMsg(LangConstants.TEAM_QUIT_OK);
		//通知附近玩家，队长变更
		noticeNearLeaderChanged(leaderId);
		
		//队伍解散的监听
		onTeamDismiss(team);
	}
	
	protected void onTeamDismiss(Team team) {
		//队伍处于活动中状态，则调用队员离队的监听
		int size = team.getMemberMap().size();
		int i = 0;
		for (TeamMember tm : team.getMemberMap().values()) {
			i++;
			boolean isLast = false;
			if (i == size) {
				isLast = true;
			}
			Globals.getEventService().fireEvent(new TeamMemberChangeEvent(new TeamMemberChangeInfo(tm.getRoleId(), team.getId(), 
					false, false, isLast, team.isDoing(), false)));
		}
	}
	
	protected void changeLeader(Team team, long newLeaderId) {
		if (team.getLeader().getRoleId() == newLeaderId) {
			return;
		}
		//新队长是否在队伍中
		TeamMember nl = team.getMember(newLeaderId);
		if (nl == null) {
			return;
		}
		//新队长必须是正常状态
		if (nl.getStatus() != MemberStatus.NORMAL) {
			return;
		}
		
		//更换队长
		team.changeLeader(nl);
		
		//通知队员，成员类型变化
		team.noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamMemberList(team), true, true);
		//调用队员变化的监听
		Globals.getEventService().fireEvent(new TeamMemberChangeEvent(new TeamMemberChangeInfo(team.getLeader().getRoleId(),
				team.getId(), 
				false, false, false, team.isDoing(),true)));
	}
	
	/**
	 * 随机选择一个队长，优先选当前在线的
	 * @param team
	 * @return
	 */
	protected TeamMember selectNewLeader(Team team) {
		TeamMember nl = null;
		for (TeamMember tm : team.getMemberMap().values()) {
			if (tm.getType() == MemberType.LEADER) {
				continue;
			}
			if (tm.getStatus() != MemberStatus.NORMAL) {
				continue;
			}
			if (nl != null) {
				//tm是否在线
				if (isOnlineNow(tm)) {
					nl = tm;
				}
			} else {
				nl = tm;
			}
			if (isOnlineNow(nl)) {
				break;
			}			
		}
		return nl;
	}
	
	public boolean isOnlineNow(TeamMember member) {
		return isPlayerOnline(member.getRoleId());
	}
	
	public boolean isPlayerOnline(long roleId) {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		return player != null && player.getHuman() != null && player.isInScene();
	}
	
	public Human getTeamLeaderHuman(Team team) {
		if (isOnlineNow(team.getLeader())) {
			return Globals.getOnlinePlayerService().getPlayer(team.getLeader().getRoleId()).getHuman();
		}
		return null;
	}
	
	public Human getTeamMemberHuman(TeamMember tm){
		if (isOnlineNow(tm)) {
			return Globals.getOnlinePlayerService().getPlayer(tm.getRoleId()).getHuman();
		}
		return null;
	}
	
	protected boolean autoChangeLeader(Team team) {
		TeamMember nl = selectNewLeader(team);
		if (nl == null) {
			Loggers.teamLogger.warn("autoChangeLeader fail so dismiss team auto!teamId=" + 
					team.getId() + ";leaderId=" + team.getLeader().getRoleId());
			//队伍没有可变为队长的人了，自动解散
			dismissTeam(team.getId());
			return false;
		}
		
		long oldLeaderId = team.getLeader().getRoleId();
		//更换队伍的队长
		team.changeLeader(nl);
		
		Loggers.teamLogger.info("autoChangeLeader teamId=" + 
				team.getId() + ";oldLeaderId=" + oldLeaderId + ";newLeaderId=" + team.getLeader().getRoleId());
		
		//通知队员，成员类型变化
		team.noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamMemberList(team), true, true);
		//调用队员变化的监听
		Globals.getEventService().fireEvent(new TeamMemberChangeEvent(new TeamMemberChangeInfo(team.getLeader().getRoleId(), team.getId(), 
				false, false, false, team.isDoing(), true)));
		return true;
	}
	
	public void noticeNearLeaderChanged(long roleId) {
		if (isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			Globals.getMapService().noticeNearMapInfoChanged(human);
		}
	}
	
	/**
	 * 修改队伍整体状态
	 * @param teamId
	 * @param status
	 * @return
	 */
	public boolean changeTeamStatus(int teamId, TeamStatus status) {
		Team team = getTeam(teamId);
		if (team == null || status == null || team.getStatus() == status) {
			return false;
		}
		
		//更改队伍状态
		team.setStatus(status);
		
		return true;
	}
	
	/**
	 * 玩家是否正处于组队战斗中
	 * @param roleId
	 * @return
	 */
	public boolean isInTeamBattle(long roleId) {
		if (isInTeamNormal(roleId)) {
			return getTeamMember(roleId).getTeam().isInBattle();
		}
		return false;
	}
	
	/**
	 * 地图进入情况：
	 * 在线玩家，需判断完整的能否进入地图
	 * 离线玩家和暂离玩家，只判断是否满足进入地图的条件，不是完整的能否进入地图判断。之所以判断暂离玩家，是归队的时候能过去队长身边
	 * 队长进入地图后，在线的正常状态的玩家，跟着进入地图；离线玩家和非正常状态玩家，不进入地图
	 */
	
	/**
	 * 能否进入地图，这里只判断跟组队相关的
	 * @param roleId
	 * @param targetMapId
	 * @return
	 */
	public boolean canPlayerEnterMap(Human human, int targetMapId) {
		long roleId = human.getCharId();
		if (isInTeam(roleId)) {
			//普通状态，队员不可切换地图，队长可以
			if (isInTeamNormal(roleId)) {
				if (isTeamLeader(roleId)) {
					//除队长外的队员能否进入指定地图
					return canTeamEnterMap(human, targetMapId);
				} else {
					//队员进入非队伍地图，非法操作
					if (getHumanTeam(roleId).getMapId() != targetMapId) {
						return false;
					}
				}
			} else {
				//暂离状态，如果队伍处于活动中状态时，不能切换地图
				if (getHumanTeam(roleId).isDoing()) {
					return false;
				}
			}
		}
		return true;
	}
	
	/**
	 * 判断除队长外的队员能否进入指定地图
	 * @param human
	 * @param targetMapId
	 * @return
	 */
	protected boolean canTeamEnterMap(Human human, int targetMapId) {
		long roleId = human.getCharId();
		if (!isTeamLeader(roleId)) {
			return false;
		}
		
		//队长进入指定地图，需要判断所有队员都能进入才行
		Team team = getHumanTeam(roleId);
		int curMapId = team.getMapId();
		//设置队伍地图Id为目标地图
		team.setMapId(targetMapId);
		for (TeamMember tm : team.getMemberMap().values()) {
			//排除队长自身
			if (tm.getType() == MemberType.LEADER) {
				continue;
			}
			//XXX 这里暂离队员也要参与判断能否进入地图，如果不能进入，大家都不能进入，这样归队的时候，就不用再判断地图了
			boolean tmFlag = false;
			long tmRoleId = tm.getRoleId();
			//单纯的进入地图的等级要求是否满足，包括暂离的
			tmFlag = isPlayerSatisfyMapLimit(tmRoleId, team);
			//在线玩家需要跟着进地图，所以需要判断，暂离的除外，因为暂离的可能已经在targetMapId地图中了，canEnterMap会返回false
			if (tmFlag && isOnlineNow(tm) && tm.getStatus() != MemberStatus.AWAY) {
				//判断能否进入地图
				tmFlag = Globals.getMapService().canEnterMap(
						Globals.getOnlinePlayerService().getPlayer(tmRoleId).getHuman(), 
						targetMapId, false, null);
			}
			if (!tmFlag) {
				//如果有玩家不能进入，则将队伍地图重置回原来的
				team.setMapId(curMapId);
				//有队员不满足进入地图条件
				human.sendErrorMessage(LangConstants.TEAM_ENTER_MAP_FAIL, tm.getName());
				return false;
			}
		}
		return true;
	}
	
	/**
	 * 队长进入地图后，队员需进入
	 * @param human
	 */
	public void onLeaderEnterMap(Human human) {
		long roleId = human.getCharId();
		//非队长不处理
		if (!isTeamLeader(roleId)) {
			return;
		}
		
		int targetMapId = human.getMapId();
		//让队员也都进入地图
		Team team = getHumanTeam(roleId);
		//更新队伍地图为队长地图
		team.setMapId(targetMapId);
		
		//队员进入队伍地图
		for (TeamMember tm : team.getMemberMap().values()) {
			//排除队长自身
			if (tm.getType() == MemberType.LEADER) {
				continue;
			}
			//排除非正常状态的队员
			if (tm.getStatus() != MemberStatus.NORMAL) {
				continue;
			}
			//在线的玩家，需要跟着进入地图
			if (isOnlineNow(tm)) {
				boolean flag = Globals.getMapService().enterMap(
						Globals.getOnlinePlayerService().getPlayer(tm.getRoleId()).getHuman(), targetMapId);
				if (!flag) {
					Loggers.teamLogger.error("team enter map fail!teamId=" + team.getId() + ";roleId=" + tm.getRoleId());
				}
			} else {
				//XXX 不在线的玩家，没法进入队伍地图，只有重新登录后才能进入，即必须有human才行
			}
		}
	}
	
	/**
	 * 队长移动，通知客户端，让队员跟随
	 * @param human
	 */
	public void onLeaderMove(Human human) {
		long roleId = human.getCharId();
		//非队长不处理
		if (!isTeamLeader(roleId)) {
			return;
		}
		
		//让队员也都进入地图
		Team team = getHumanTeam(roleId);
		//更新队伍位置为队长位置
		team.setX(human.getX());
		team.setY(human.getY());
		
		//通知队员，队伍位置变化，客户端跟随队长
		team.noticeTeamMember(new GCMapTeamLeaderPosition(team.getLeader().getRoleId(), 
				team.getMapId(), team.getX(), team.getY()), false, false);
	}
	
	/**
	 * 登录时检查是否需要进入队伍地图
	 * @param human
	 * @return
	 */
	public int checkNeedEnterTeamMapOnLogin(Human human) {
		//默认为玩家上次离线时的地图
		int mapId = human.getMapId();
		long roleId = human.getCharId();
		//如果玩家不是队长，且在队伍中是正常状态时，玩家需要进入队伍地图
		if (isInTeamNormal(roleId) && 
				!isTeamLeader(roleId)) {
			int teamMapId = getHumanTeam(roleId).getMapId();
			if (human.getMapId() != teamMapId) {
				mapId = teamMapId;
			}
		}
		return mapId;
	}
	
	/**
	 * 登录时检查是否需要发队长位置给玩家
	 * @param human
	 */
	public void checkSendLeaderPositionOnLogin(Human human) {
		long roleId = human.getCharId();
		//如果玩家是队伍的队员，则发队长位置信息
		if (isInTeamNormal(roleId) && 
				!isTeamLeader(roleId)) {
			Team team = getHumanTeam(roleId);
			//发队伍位置给玩家，跑到队长身边
			human.sendMessage(new GCMapTeamLeaderPosition(team.getLeader().getRoleId(), 
					team.getMapId(), team.getX(), team.getY()));
		}
	}
	
	/**
	 * 玩家是否队伍的队长
	 * @param roleId
	 * @return
	 */
	public boolean isTeamLeader(long roleId) {
		if (isInTeam(roleId)) {
			return getTeamMember(roleId).getType() == MemberType.LEADER;
		}
		return false;
	}
	
	public boolean isAwayStatus(long roleId) {
		if (isInTeam(roleId)) {
			return getTeamMember(roleId).getStatus() == MemberStatus.AWAY;
		}
		return false;
	}
	
	public boolean canTriggerTeamBattle(long roleId) {
		if (isTeamLeader(roleId)) {
			if (!getHumanTeam(roleId).isInBattle()) {
				return true;
			}
		}
		return false;
	}
	
	public boolean canTriggerSingleBattle(long roleId) {
		//在队伍中，处于暂离状态，可触发单人战斗
		if (isInTeam(roleId)) {
			if (isAwayStatus(roleId)) {
				return true;
			}
			return false;
		}
		//没在队伍中，可以触发单人战斗
		return true;
	}
	
	/**
	 * 在地图遇到野怪的等级要求
	 * @param roleId
	 * @return
	 */
	public boolean triggerBattleLevelLimit(long roleId) {
		//玩家等级需要超过指定值才能遇怪
		return Globals.getOfflineDataService().getUserLevel(roleId) >= 
				Globals.getGameConstants().getMapMeetMonsterLevelLimit();
	}
	
	/**
	 * 玩家能否在地图遇到野怪
	 * @param roleId
	 * @return
	 */
	public boolean canTriggerBattle(long roleId) {
		boolean flag = canTriggerTeamBattle(roleId) || canTriggerSingleBattle(roleId);
		if (flag) {
			//玩家等级要求
			if (!triggerBattleLevelLimit(roleId)) {
				return false;
			}
		}
		return flag;
	}
	
	public Team getHumanTeam(long roleId) {
		if (isInTeam(roleId)) {
			return getTeamMember(roleId).getTeam();
		}
		return null;
	}
	
	/**
	 * 获取队伍有效人数
	 * @param teamId
	 * @return
	 */
	public int getMemberNumOfNormal(int teamId) {
		int num = 0;
		if (hasTeam(teamId)) {
			num = getTeam(teamId).getTeamMemberNum();
		}
		return num;
	}
	
	/**
	 * 获取玩家所在队伍，有效人数
	 * @param roleId
	 * @return
	 */
	public int getHumanTeamMemberNum(long roleId) {
		int num = 0;
		if (isInTeam(roleId)) {
			num = getHumanTeam(roleId).getTeamMemberNum();
		}
		return num;
	}
	
	/**
	 * 战斗中逃跑的处理
	 * @param roleId
	 */
	public void onEscape(long roleId) {
		if (!isInTeamNormal(roleId)) {
			return;
		}
		TeamMember tm = getTeamMember(roleId);
		Team team = tm.getTeam();
		if (!team.isInBattle()) {
			return;
		}
		
		//从战斗map中移除对应的战斗对象信息
		TeamBattleProcess bp = (TeamBattleProcess) battleLogic.getBattle(battleLogic.getPlayerBattleId(roleId));
		if (bp == null) {
			return;
		}
		bp.removeBattleInfo(roleId);
		
		//逃跑玩家，强制退出战斗
		if (isOnlineNow(tm)) {
			//通知客户端退出战斗
			Globals.getOnlinePlayerService().getPlayer(roleId).sendMessage(new GCBattleForceEnd());
		}
		
		//除 队伍中正常状态的玩家只有队长一人，且逃跑的是队长，不用变为暂离，其他情况下需要将玩家变为暂离状态
		if (!(tm.getType() == MemberType.LEADER && team.getTeamMemberNum() == 1)) {
			//逃跑的玩家变为暂离状态
			memberAwayFromTeam(tm.getRoleId());
		}
	}
	
	/**
	 * 玩家登录时的处理
	 * @param human
	 */
	public void onPlayerLogin(Human human) {
		long roleId = human.getUUID();
		TeamMember tm = getTeamMember(roleId);
		//是否在队伍中
		if (tm == null) {
			//玩家未在队伍中，发退出退伍的消息
			human.sendMessage(new GCTeamQuit());
			
			//未在队伍中，看是否自动匹配
			if (isAutoJoinPlayer(roleId)) {
				human.sendMessage(new GCTeamApplyAuto(1, getAutoJoinPlayerTargetId(roleId)));
			}
			return;
		}
		
		//更新lastLogoutTime
		tm.setLastOfflineTime(0);
		//从离线玩家集合中移除掉
		removeOffline(roleId);
		
		//玩家在队伍中，发队伍信息
		showMyTeam(human);
		//队伍任务
		if (tm.getTeam().getTaskManager().isDoing()) {
			human.sendMessage(new GCQuestUpdate(tm.getTeam().getTaskManager().getCurTask().buildQuestInfo()));
		}
		
		//组队战斗相关
		checkTeamBattleOnLogin(human);
	}
	
	/**
	 * 检查玩家是否有正在进行的组队战斗，有则发战报
	 * @param human
	 */
	protected void checkTeamBattleOnLogin(Human human) {
		long roleId = human.getUUID();
		//是否处于队伍战斗中
		if (!Globals.getTeamService().isInTeamBattle(roleId)) {
			return;
		}
		//获取战斗Id
		int battleId = getTeamMember(roleId).getTeam().getCurBattleId();
		//如果处于pve组队战斗
		if (battleLogic.getBattle(battleId) != null) {
			battleLogic.onPlayerLogin(human);
		} else if (Globals.getTeamPvpService().getBattle(battleId) != null) {
			//如果处于pvp组队战斗
			Globals.getTeamPvpService().onPlayerLogin(human);
		} else {
			//记录警告日志
			Loggers.battleLogger.error("battleId not exist!humanId=" + human.getCharId() + 
					";battleId=" + battleId);
		}
	}
	
	/**
	 * 玩家离线时的处理
	 * @param roleId
	 */
	public void onPlayerOffline(long roleId) {
		//如果玩家申请了自动加入队伍，则掉线时，取消
		if (isAutoJoinPlayer(roleId)) {
			removeAutoJoinPlayer(roleId);
		}
		
		TeamMember tm = getTeamMember(roleId);
		if (tm == null) {
			return;
		}
		
		//设置离线时间
		tm.setLastOfflineTime(Globals.getTimeService().now());
		//增加到离线玩家集合
		addOffline(roleId);
	}
	
	/**
	 * 战斗结束后，队员状态的更新
	 * @param team
	 */
	public void battleEndUpdateStatus(Team team) {
		//队伍战斗结束后，看是否有队员的状态需要变更
		List<TeamMember> col = new ArrayList<TeamMember>();
		col.addAll(team.getMemberMap().values());
		for (TeamMember tm : col) {
			long roleId = tm.getRoleId();
			MemberAfterBattleStatus changeStatus = tm.getAfterBattleStatus();
			if (changeStatus != null) {
				switch (changeStatus) {
				case NORMAL:
					if (isOnlineNow(tm)) {
						memberReturnTeam(Globals.getOnlinePlayerService().getPlayer(roleId).getHuman());
					}
					break;
				case AWAY:
					memberAwayFromTeam(roleId);
					break;
				case LEAVE:
					memberLeaveTeam(roleId);
					break;
				default:
					break;
				}
			}
			tm.setAfterBattleStatus(null);
		}
	}
	
	/**
	 * 定时检查队员是否离线超过20分钟，如果是，则变为暂离状态
	 */
	public void checkTeamMemberAway() {
		//检查所有队员，如果离线超过20分钟，则需要变为 暂离 状态
		long now = Globals.getTimeService().now();
		Iterator<Long> it = offlineSet.iterator();
		Set<Long> awaySet = new LinkedHashSet<Long>();
		while(it.hasNext()) {
			Long roleId = it.next();
			TeamMember tm = getTeamMember(roleId);
			if (tm == null) {
				it.remove();
				continue;
			}
			long offlineTime = tm.getLastOfflineTime();
			if (offlineTime <= 0) {
				it.remove();
				continue;
			}
			if (tm.getStatus() != MemberStatus.NORMAL) {
				it.remove();
				continue;
			}
			//离线超过20分钟，变为暂离状态
			if (offlineTime + TeamDef.MAX_OFFLINE_TIME < now) {
				if (tm.getTeam().isInBattle()) {
					tm.setAfterBattleStatus(MemberAfterBattleStatus.AWAY);
				} else {
					//memberAwayFromTeam 可能会删除 offlineSet，所以放到一个集合里面，后边再删除
					//memberAwayFromTeam(roleId);
					awaySet.add(roleId);
				}
				it.remove();
			} else {
				break;
			}
		}
		
		//超过20分钟的队员，变为暂离状态
		for (Long roleId : awaySet) {
			memberAwayFromTeam(roleId);
		}
	}
	
	public void checkTeamMemberAway(long roleId) {
		TeamMember tm = getTeamMember(roleId);
		if (tm == null) {
			return;
		}
		if (tm.getStatus() != MemberStatus.NORMAL) {
			return;
		}
		
		if (tm.getTeam().isInBattle()) {
			tm.setAfterBattleStatus(MemberAfterBattleStatus.AWAY);
		} else {
			memberAwayFromTeam(roleId);
		}
	}
	
	
	/****** 任务相关 *****/
	
	public boolean canTeamAcceptTask(Team team, int questId, Human notifyHuman) {
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
		if (questTpl == null) {
			return false;
		}
		//不是组队任务，直接返回
		if (questTpl.getQuestTypeEnum() != QuestType.TEAM) {
			return false;
		}
		
		//任务的人数要求
		if (!team.getTaskManager().teamMemberNumCheck(questTpl, getMemberNumOfNormal(team.getId()))) {
			if (notifyHuman != null) {
				notifyHuman.sendErrorMessage(LangConstants.TEAM_ACCEPT_TASK_FAIL2);
			}
			return false;
		}
		
		boolean preFlag = team.getTaskManager().preQuestCheckOnAccept(questTpl);
		if (!preFlag) {
			//前置任务没有完成，不能接受该任务
			Loggers.questLogger.warn("队长试图接受一个没有完成前置任务的任务.leaderId=" + 
					team.getLeader().getRoleId() + ";questId=" + questId);
			return false;
		}
		
		//XXX 检查任务是否可接受，需要所有队员都能接受才行，包括暂离的
		for (TeamMember tm : team.getMemberMap().values()) {
			boolean lvFlag = team.getTaskManager().levelCheckOnAccept(questTpl, tm.getLevel());
			if (!lvFlag) {
				//通知队长，有队员不能接任务
				if (notifyHuman != null) {
					notifyHuman.sendErrorMessage(LangConstants.TEAM_ACCEPT_TASK_FAIL, tm.getName());
				}
				return false;
			}
		}
		return true;
	}
	
	/**
	 * 队长接组队任务
	 * @param human
	 * @param questId
	 */
	public void acceptTask(Human human, int questId) {
		long roleId = human.getCharId();
		//只有队长可以
		if (!isTeamLeader(roleId)) {
			return;
		}
		
		Team team = getHumanTeam(human.getCharId());
		//队伍能否接此任务
		if (!canTeamAcceptTask(team, questId, human)) {
			return;
		}
		
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
		//自动接的任务手动接了，记录一个警告即可
		if (questTpl.isAutoAccept()) {
			Loggers.questLogger.warn("队长试图接受一个自动接受的任务.humanId=" + 
					human.getCharId() + ";questId=" + questId);
		}
		
		//队伍接任务
		TeamTask tt = buildInitTask(team, questTpl);
		tt.onAcceptTask();
	}
	
	public boolean onAcceptTask(Team team, TeamTask tt) {
		//如果新接的任务没有前置，则认为是一个新任务，清除之前的数据
		if (tt.getTemplate().getPreQuestId() == 0) {
			team.getTaskManager().clearFinishedSet();
		}
		//XXX 这里不判断当前任务，直接覆盖掉
		//重置当前任务
		team.getTaskManager().setCurTask(tt);
		//发消息，通知任务变化
		team.noticeTeamMember(new GCQuestUpdate(tt.buildQuestInfo()), true, true);
		return true;
	}
	
	protected TeamTask buildInitTask(Team team, QuestTemplate questTpl) {
		long now = Globals.getTimeService().now();
		// 构建任务数据
		TeamTask task = new TeamTask(team, questTpl);
		// 生成Id
		task.setId(KeyUtil.UUIDKey());
		// 设置时间
		task.setStartTime(now);
		task.setLastUpdateTime(now);
		return task;
	}
	
	/**
	 * 队长完成任务
	 * @param human
	 * @param questId
	 */
	public void finishTask(Human human, int questId) {
		long roleId = human.getCharId();
		//只有队长可以
		if (!isTeamLeader(roleId)) {
			return;
		}
		
		Team team = getHumanTeam(human.getCharId());
		TeamTask curTask = team.getTaskManager().getCurTask();
		if (curTask == null || curTask.getQuestId() != questId) {
			return;
		}
		
		QuestTemplate pTpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
		//自动完成的任务手动完成了，记录一个警告即可
		if (pTpl.isAutoFinish()) {
			Loggers.questLogger.warn("队长试图完成一个自动完成的任务.humanId=" + 
					human.getCharId() + ";questId=" + questId);
		}
		
		boolean flag = curTask.onFinishTask();
		if (!flag) {
			Loggers.questLogger.error("队长试图完成一个不可完成的任务！humanId=" + 
					human.getCharId() + ";questId=" + questId);
			return;
		}
	}
	
	public void checkAfterFinishTask(Team team, int finishedQuestId) {
		//发消息，更新任务
		team.noticeTeamMember(new GCQuestUpdate(team.getTaskManager().getCurTask().buildQuestInfo()), true, true);
		
		//加入已完成任务集合
		team.getTaskManager().addFinishedTask(finishedQuestId);
		
		//取前置为该完成的任务的集合
		Set<Integer> pIdSet = Globals.getTemplateCacheService().getQuestTemplateCache().getPostQuestIdSet(finishedQuestId);
		if (pIdSet != null && !pIdSet.isEmpty()) {
			for (Integer pId : pIdSet) {
				QuestTemplate questTpl = Globals.getTemplateCacheService().get(pId, QuestTemplate.class);
				//可接，且是自动接，则接
				if (canTeamAcceptTask(team, pId, null) &&
						questTpl.isAutoAccept()) {
					TeamTask tt = buildInitTask(team, questTpl);
					tt.onAcceptTask();
					//同时只有一个，所以接一个就退出
					break;
				}
			}
		}
	}
	
	public TaskListener<Team> getTeamTaskListener(Human human) {
		if (human != null) {
			long roleId = human.getCharId();
			if (isTeamLeader(roleId)) {
				Team team = getHumanTeam(roleId);
				//有进行中的任务，才返回监听器
				if (team.getTaskManager().isDoing()) {
					return team.getTaskListener();
				}
			}
		}
		return null;
	}
	
	/**
	 * 发队伍聊天信息
	 * @param human
	 * @param chatMsg
	 */
	public void sendTeamChatMsg(Human human, GCChatMsg chatMsg) {
		long roleId = human.getCharId();
		if (isInTeam(roleId)) {
			Team team = getHumanTeam(roleId);
			team.noticeTeamMember(chatMsg, true, true);
		}
	}
	
	public void noticeNearMapInfoChanged(TeamBattleProcess bp) {
		if (bp == null || bp.getBattleInfoMap() == null) {
			return;
		}
		for (Long uuid : bp.getBattleInfoMap().keySet()) {
			if (isPlayerOnline(uuid)) {
				Globals.getMapService().noticeNearMapInfoChanged(
						Globals.getOnlinePlayerService().getPlayer(uuid).getHuman());
			}
		}
	}
	
	public void onTeamMemberInfoChanged(Human human) {
		long roleId = human.getCharId();
		if (isInTeam(roleId)) {
			//通知队员，有人等级发生变化
			Team team = getHumanTeam(roleId);
			team.noticeTeamMember(TeamMsgBuilder.buildGCTeamMyTeamMemberList(team), true, true);
		}
	}
	
}
