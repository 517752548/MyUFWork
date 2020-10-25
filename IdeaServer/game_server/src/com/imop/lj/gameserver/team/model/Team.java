package com.imop.lj.gameserver.team.model;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.task.ITaskOwner;
import com.imop.lj.gameserver.task.TaskListener;
import com.imop.lj.gameserver.team.TeamDef.MemberStatus;
import com.imop.lj.gameserver.team.TeamDef.MemberType;
import com.imop.lj.gameserver.team.TeamDef.TeamStatus;
import com.imop.lj.gameserver.team.task.TeamTaskManager;
import com.imop.lj.gameserver.team.template.TeamTargetTemplate;

public class Team implements ITaskOwner {
	private static final Comparator<TeamMember> MemberSortor = new Team.TeamMemberComparator();
	
	/** 队伍id */
	private int id;
	/** 队伍当前状态 */
	private TeamStatus status;
	/** key是玩家Id，值是成员数据 */
	private Map<Long, TeamMember> memberMap = new HashMap<Long, TeamMember>();
	/** 按位置排序的队员列表 */
	private List<TeamMember> sortList = new ArrayList<TeamMember>();
	/** 队长 */
	private TeamMember leader;
	
	/** 队伍目标Id */
	private int targetId;
	/** 队伍要求最低进入等级 */
	private int levelMin;
	/** 队伍要求最高进入等级 */
	private int levelMax;
	/** 是否自动匹配 */
	private boolean isAutoMatch;
	
	/** 申请列表 */
	private List<TeamApplyer> applySet = new ArrayList<TeamApplyer>();
	
	/** 邀请列表Map<受邀人，发起邀请的人> */
	private Map<Long, Long> inviteMap = new HashMap<Long, Long>();
	
	/** 队伍战斗Id */
	private int curBattleId;
	
	/** 队伍所在地图Id */
	private int mapId;
	/** 队伍所在地图坐标x */
	private int x;
	/** 队伍所在地图坐标y */
	private int y;
	
	/** 队伍备用地图Id */
	private int backMapId;
	/** 队伍备用地图坐标x */
	private int backX;
	/** 队伍备用地图坐标y */
	private int backY;
	
	/** 组队任务管理器 */
	private TeamTaskManager taskManager;
	/** 组队任务监听器 */
	private TaskListener<Team> taskListener;
	
	public Team() {
		taskManager = new TeamTaskManager(this);
		taskListener = new TaskListener<Team>(this);
	}
	
	public void addMember(TeamMember tm) {
		if (this.memberMap.containsKey(tm.getRoleId())) {
			return;
		}
		
		this.memberMap.put(tm.getRoleId(), tm);
		if (tm.getType() == MemberType.LEADER) {
			this.leader = tm;
		}
		
		sortList.add(tm);
		sortMemberList();
	}
	
	public void sortMemberList() {
		Collections.sort(this.sortList, MemberSortor);
	}
	
	public void changeLeader(TeamMember newLeader) {
		Human oldLeaderHuman = Globals.getTeamService().getTeamLeaderHuman(this);
		
		leader.setType(MemberType.MEMBER);
		newLeader.setType(MemberType.LEADER);
		//位置互换
		leader.setPosition(newLeader.getPosition());
		newLeader.setPosition(1);
		
		//通知附近的玩家，队长变更
		Globals.getTeamService().noticeNearLeaderChanged(leader.getRoleId());
		Globals.getTeamService().noticeNearLeaderChanged(newLeader.getRoleId());
		
		leader = newLeader;
		
		//重新排序
		sortMemberList();
		
		//申请列表不空，则新旧队长功能按钮都要有变化
		if (!getApplySet().isEmpty()) {
			//新，旧队长功能按钮变化
			Human newLeaderHuman = Globals.getTeamService().getTeamLeaderHuman(this);
			if (oldLeaderHuman != null) {
				Globals.getFuncService().onFuncChanged(oldLeaderHuman, FuncTypeEnum.TEAM);
			}
			if (newLeaderHuman != null) {
				Globals.getFuncService().onFuncChanged(newLeaderHuman, FuncTypeEnum.TEAM);
			}
		}
	}
	
	public boolean isInBattle() {
		return curBattleId > 0;
	}
	
	public void removeMember(TeamMember tm) {
		this.memberMap.remove(tm.getRoleId());
		sortList.remove(tm);
		sortMemberList();
	}
	
	public int getMemberNum() {
		return this.memberMap.size();
	}
	
	public boolean hasMember(long memberId) {
		return this.memberMap.containsKey(memberId);
	}
	
	public TeamMember getMember(long memberId) {
		return this.memberMap.get(memberId);
	}
	
	public TeamApplyer getApplyer(long roleId) {
		for (TeamApplyer ta : applySet) {
			if (ta.getRoleId() == roleId) {
				return ta;
			}
		}
		return null;
	}
	
	public boolean isApplyer(long roleId) {
		for (TeamApplyer ta : applySet) {
			if (ta.getRoleId() == roleId) {
				return true;
			}
		}
		return false;
	}
	
	public void addApplyer(TeamApplyer applyer) {
		applySet.add(applyer);
		if (applySet.size() > Globals.getGameConstants().getTeamMaxApplyNum()) {
			//删除第一个
			applySet.remove(0);
		}
	}
	
	public List<TeamApplyer> getApplySet() {
		return applySet;
	}
	
	public void clearApplySet() {
		this.applySet.clear();
	}
	
	public void removeApplyer(TeamApplyer applyer) {
		this.applySet.remove(applyer);
	}
	
	public void addInvite(long roleId, long targetRoleId) {
		this.inviteMap.put(targetRoleId, roleId);
	}
	
	public Long removeInvite(long targetRoleId) {
		return this.inviteMap.remove(targetRoleId);
	}
	
	public Long getInviterId(long targetRoleId) {
		return this.inviteMap.get(targetRoleId);
	}
	
	public void clearInviteSet() {
		this.inviteMap.clear();
	}
	
	public boolean isDoing() {
		return this.getStatus() == TeamStatus.DOING || this.getStatus() == TeamStatus.DOING_NO_AWAY;
	}
	
	public boolean isDoingNoAway() {
		return this.getStatus() == TeamStatus.DOING_NO_AWAY;
	}
	
	/**
	 * 给队伍成员发消息
	 * @param msg
	 * @param containsLeader true所有队员，false排除队长
	 */
	public void noticeTeamMember(GCMessage msg, boolean containsUnNormal, boolean containsLeader) {
		for (TeamMember tm : memberMap.values()) {
			long roleId = tm.getRoleId();
			//非正常状态的队员,不发送
			if (!containsUnNormal && tm.getStatus() != MemberStatus.NORMAL) {
				continue;
			}
			//不包含队长，则排除
			if (!containsLeader && tm.getType() == MemberType.LEADER) {
				continue;
			}
			Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
			if (player != null && player.getHuman() != null) {
				player.sendMessage(msg);
			}
		}
	}
	
	/**
	 * 给队伍所有成员发指定的错误提示信息
	 * @param key
	 * @param params
	 */
	public void noticeTeamMemberErrorMsg(Integer key, Object... params) {
		for (TeamMember tm : memberMap.values()) {
			Player player = Globals.getOnlinePlayerService().getPlayer(tm.getRoleId());
			if (player != null && player.getHuman() != null) {
				player.sendErrorMessage(key, params);
			}
		}
	}
	
	/**
	 * 获取队伍平均等级
	 * @return
	 */
	public int getAvgLevel() {
		int level = 0;
		for (TeamMember tm : memberMap.values()) {
			level += tm.getLevel();
		}
		return level / memberMap.size();
	}
	
	/**
	 * 获取队伍等级，任务用，取的是所有队员的最低等级
	 */
	@Override
	public int getLevel() {
		int level = getLeader().getLevel();
		for (TeamMember tm : memberMap.values()) {
			if (tm.getLevel() < level) {
				level = tm.getLevel();
			}
		}
		return level;
	}
	
	/**
	 * 队伍队伍的有效人数
	 */
	@Override
	public int getTeamMemberNum() {
		int num = 0;
		for (TeamMember tm : memberMap.values()) {
			if (tm.getStatus() == MemberStatus.NORMAL) {
				num++;
			}
		}
		return num;
	}
	
	public TeamTargetTemplate getTargetTpl() {
		return Globals.getTemplateCacheService().get(getTargetId(), TeamTargetTemplate.class);
	}
	
	public boolean hasTarget() {
		return getTargetTpl() != null;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public TeamStatus getStatus() {
		return status;
	}

	public void setStatus(TeamStatus status) {
		this.status = status;
	}

	public Map<Long, TeamMember> getMemberMap() {
		return memberMap;
	}

	public void setMemberMap(Map<Long, TeamMember> memberMap) {
		this.memberMap = memberMap;
	}

	public TeamMember getLeader() {
		return leader;
	}

	public int getTargetId() {
		return targetId;
	}

	public void setTargetId(int targetId) {
		this.targetId = targetId;
	}

	public int getLevelMin() {
		return levelMin;
	}

	public void setLevelMin(int levelMin) {
		this.levelMin = levelMin;
	}

	public int getLevelMax() {
		return levelMax;
	}

	public void setLevelMax(int levelMax) {
		this.levelMax = levelMax;
	}

	public int getCurBattleId() {
		return curBattleId;
	}

	public void setCurBattleId(int curBattleId) {
		this.curBattleId = curBattleId;
	}
	
	public boolean isAutoMatch() {
		return isAutoMatch;
	}

	public void setAutoMatch(boolean isAutoMatch) {
		this.isAutoMatch = isAutoMatch;
	}

	public List<TeamMember> getMemberList() {
		return this.sortList;
	}
	
	public int getMapId() {
		return mapId;
	}

	public void setMapId(int mapId) {
		this.mapId = mapId;
	}

	public int getX() {
		return x;
	}

	public void setX(int x) {
		this.x = x;
	}

	public int getY() {
		return y;
	}

	public void setY(int y) {
		this.y = y;
	}

	public int getBackMapId() {
		return backMapId;
	}

	public void setBackMapId(int backMapId) {
		this.backMapId = backMapId;
	}

	public int getBackX() {
		return backX;
	}

	public void setBackX(int backX) {
		this.backX = backX;
	}

	public int getBackY() {
		return backY;
	}

	public void setBackY(int backY) {
		this.backY = backY;
	}

	public TeamTaskManager getTaskManager() {
		return taskManager;
	}

	public TaskListener<Team> getTaskListener() {
		return taskListener;
	}
	
	public String getName() {
		return getLeader().getName();
	}

	/**
	 * 使用备用地图作为队伍地图，一些特殊情况才可以
	 */
	public void onUseBackMap() {
		if (this.getMapId() != this.getBackMapId()) {
			this.setMapId(this.getBackMapId());
			this.setX(this.getBackX());
			this.setY(this.getBackY());
		}
	}
	
	static class TeamMemberComparator implements Comparator<TeamMember> {
		@Override
		public int compare(TeamMember o1, TeamMember o2) {
			if (o1.getPosition() < o2.getPosition()) {
				return -1;
			}
			if (o1.getPosition() > o2.getPosition()) {
				return 1;
			}
			return 0;
		}
	}

}
