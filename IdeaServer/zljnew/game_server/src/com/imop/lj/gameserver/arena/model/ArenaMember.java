package com.imop.lj.gameserver.arena.model;

import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.model.arena.ArenaReportHistoryInfo;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.gameserver.arena.ArenaDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.scene.CommonScene;
import com.imop.lj.gameserver.util.FixedSizeQueue;

/**
 * 竞技场成员对象
 * @author yu.zhao
 *
 */
public class ArenaMember implements PersistanceObject<Long, ArenaSnapEntity> {
	/** 玩家角色ID 主键 */
	private long id;
	/** 当前排名 */
	private int rank;
	/** 等级快照 */
	private int snapLevel;
	/** 排名快照 */
	private int snapRank;
	/** 最高排名 */
	private int rankMax;
	/** 当前连续胜利次数 */
	private int conWinTimes;
	/** 总共挑战胜利次数 */
	private int winTimes;
	/** 总共失败次数 */
	private int lossTimes;
	/** 总共挑战次数 */
	private int attackTotalTimes;
	/** 攻击冷却时间 */
	private long attackCdTime;

	/** 战斗日志 */
	private FixedSizeQueue<ArenaReportHistoryInfo> fightLogQueue;
	
	/** 对手列表 */
	private List<ArenaOpponent> opList; 
	
	/** 是否已经在数据库中 */
	private boolean inDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	/** 公共场景 */
	private CommonScene commonScene;
	
	public ArenaMember() {
		fightLogQueue = new FixedSizeQueue<ArenaReportHistoryInfo>(ArenaDef.ARENA_MEMBER_FIGHT_LOG_MAX_NUM);
		opList = new ArrayList<ArenaOpponent>();
		this.lifeCycle = new LifeCycleImpl(this);
		commonScene = Globals.getSceneService().getCommonScene();
	}
	
	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
		if (rank > 0) {
			// 新排名高于最高排名，则更新
			if (this.rankMax == 0 || rank < this.rankMax) {
				setRankMax(rank);
			}
		}
	}

	public int getSnapLevel() {
		return snapLevel;
	}

	public void setSnapLevel(int snapLevel) {
		this.snapLevel = snapLevel;
	}

	public int getSnapRank() {
		return snapRank;
	}

	public void setSnapRank(int snapRank) {
		this.snapRank = snapRank;
	}

	public int getRankMax() {
		return rankMax;
	}

	public void setRankMax(int rankMax) {
		this.rankMax = rankMax;
	}

	public int getConWinTimes() {
		return conWinTimes;
	}

	public void setConWinTimes(int conWinTimes) {
		this.conWinTimes = conWinTimes;
	}

	public int getWinTimes() {
		return winTimes;
	}

	public void setWinTimes(int winTimes) {
		this.winTimes = winTimes;
	}

	public int getLossTimes() {
		return lossTimes;
	}

	public void setLossTimes(int lossTimes) {
		this.lossTimes = lossTimes;
	}

	public int getAttackTotalTimes() {
		return attackTotalTimes;
	}

	public void setAttackTotalTimes(int attackTotalTimes) {
		this.attackTotalTimes = attackTotalTimes;
	}

	public long getAttackCdTime() {
		return attackCdTime;
	}

	public void setAttackCdTime(long attackCdTime) {
		this.attackCdTime = attackCdTime;
	}

	/**
	 * 获取战斗日志列表
	 * @return
	 */
	public List<ArenaReportHistoryInfo> getFightLogList() {
		return fightLogQueue.getList(true);
	}
	
	/**
	 * 增加一条战斗日志
	 * @param fightLog
	 */
	public void addFightLog(ArenaReportHistoryInfo fightLog) {
		fightLogQueue.add(fightLog);
	}
	
	protected String fightLogToJsonStr() {
		JSONArray fightLogJsonArr = new JSONArray();
		if (null == fightLogQueue || fightLogQueue.empty()) {
			return fightLogJsonArr.toString();
		}
		
		List<ArenaReportHistoryInfo> fightLogList = fightLogQueue.getList(false);
		for (ArenaReportHistoryInfo reportInfo : fightLogList) {
			JSONObject reportJsonObj = new JSONObject();
			reportJsonObj.put(ArenaDef.ARENA_PLAYER_REPORT_ID, reportInfo.getReportId());
			reportJsonObj.put(ArenaDef.ARENA_PLAYER_REPORT_TIME, reportInfo.getReportTime());
			reportJsonObj.put(ArenaDef.ARENA_PLAYER_REPORT_TARGET_ROLEID, reportInfo.getTargetRoleId());
			reportJsonObj.put(ArenaDef.ARENA_PLAYER_REPORT_TARGET_TPLID, reportInfo.getTargetTplId());
			reportJsonObj.put(ArenaDef.ARENA_PLAYER_REPORT_TARGET_LEVEL, reportInfo.getTargetLevel());
			reportJsonObj.put(ArenaDef.ARENA_PLAYER_REPORT_TARGET_NAME, reportInfo.getTargetName());
			reportJsonObj.put(ArenaDef.ARENA_PLAYER_REPORT_RANK_DELTA, reportInfo.getRankDelta());
			reportJsonObj.put(ArenaDef.ARENA_PLAYER_REPORT_ISWIN, reportInfo.getIsWin());
			fightLogJsonArr.add(reportJsonObj);
		}
		return fightLogJsonArr.toString(); 
	}
	
	protected void fightLogFromJsonStr(String jsonStr) {
		if (jsonStr == null || jsonStr.equalsIgnoreCase("")) {
			return;
		}
		
		JSONArray fightLogJsonArr = JSONArray.fromObject(jsonStr);
		if (fightLogJsonArr.isEmpty()) {
			return;
		}
		for (int i = 0; i < fightLogJsonArr.size(); i++) {
			JSONObject reportJsonObj = fightLogJsonArr.getJSONObject(i);
			if (reportJsonObj.isNullObject()) {
				continue;
			}
			
			String reportId = JsonUtils.getString(reportJsonObj, ArenaDef.ARENA_PLAYER_REPORT_ID);
			long reportTime =  JsonUtils.getLong(reportJsonObj, ArenaDef.ARENA_PLAYER_REPORT_TIME);
			long targetRoleId = JsonUtils.getLong(reportJsonObj, ArenaDef.ARENA_PLAYER_REPORT_TARGET_ROLEID);
			int targetTplId = JsonUtils.getInt(reportJsonObj, ArenaDef.ARENA_PLAYER_REPORT_TARGET_TPLID);
			int targetLevel = JsonUtils.getInt(reportJsonObj, ArenaDef.ARENA_PLAYER_REPORT_TARGET_LEVEL);
			String targetName = JsonUtils.getString(reportJsonObj, ArenaDef.ARENA_PLAYER_REPORT_TARGET_NAME);
			int rankDelta = JsonUtils.getInt(reportJsonObj, ArenaDef.ARENA_PLAYER_REPORT_RANK_DELTA);
			int isWin = JsonUtils.getInt(reportJsonObj, ArenaDef.ARENA_PLAYER_REPORT_ISWIN);
			
			ArenaReportHistoryInfo reportInfo = new ArenaReportHistoryInfo();
			reportInfo.setReportId(reportId);
			reportInfo.setReportTime(reportTime);
			reportInfo.setTargetRoleId(targetRoleId);
			reportInfo.setTargetTplId(targetTplId);
			reportInfo.setTargetLevel(targetLevel);
			reportInfo.setTargetName(targetName);
			reportInfo.setRankDelta(rankDelta);
			reportInfo.setIsWin(isWin);
			
			// 加入logQueue中
			addFightLog(reportInfo);
		}
	}
	
	private void addOpponent(ArenaOpponent ao) {
		this.opList.add(ao);
	}
	
	public List<ArenaOpponent> getOpList() {
		return opList;
	}

	public void setOpList(List<ArenaOpponent> opList) {
		this.opList = opList;
		this.setModified();
	}

	protected String opListToJsonStr() {
		JSONArray jsonArr = new JSONArray();
		if (null == opList || opList.isEmpty()) {
			return jsonArr.toString();
		}
		
		for (ArenaOpponent ao : opList) {
			JSONObject jsonObj = new JSONObject();
			jsonObj.put(ArenaDef.ARENA_OPPONENT_ROLEID, ao.getRoleId());
			jsonObj.put(ArenaDef.ARENA_OPPONENT_TPLID, ao.getTplId());
			jsonObj.put(ArenaDef.ARENA_OPPONENT_RANK, ao.getRank());
			
			jsonObj.put(ArenaDef.ARENA_OPPONENT_ROBOT_NAME, ao.getName());
			jsonObj.put(ArenaDef.ARENA_OPPONENT_ROBOT_LEVEL, ao.getRobotLevel());
			jsonObj.put(ArenaDef.ARENA_OPPONENT_ROBOT_FIGHTPOWER, ao.getRobotFightPower());
			
			jsonArr.add(jsonObj);
		}
		return jsonArr.toString(); 
	}
	
	protected void opListFromJsonStr(String jsonStr) {
		if (jsonStr == null || jsonStr.equalsIgnoreCase("")) {
			return;
		}
		
		JSONArray jsonArr = JSONArray.fromObject(jsonStr);
		if (jsonArr.isEmpty()) {
			return;
		}
		for (int i = 0; i < jsonArr.size(); i++) {
			JSONObject reportJsonObj = jsonArr.getJSONObject(i);
			if (reportJsonObj.isNullObject()) {
				continue;
			}
			
			long roleId = JsonUtils.getLong(reportJsonObj, ArenaDef.ARENA_OPPONENT_ROLEID);
			int tplId = JsonUtils.getInt(reportJsonObj, ArenaDef.ARENA_OPPONENT_TPLID);
			int rank = JsonUtils.getInt(reportJsonObj, ArenaDef.ARENA_OPPONENT_RANK);
			
			String robotName = JsonUtils.getString(reportJsonObj, ArenaDef.ARENA_OPPONENT_ROBOT_NAME);
			int robotLevel = JsonUtils.getInt(reportJsonObj, ArenaDef.ARENA_OPPONENT_ROBOT_LEVEL);
			int robotFightPower = JsonUtils.getInt(reportJsonObj, ArenaDef.ARENA_OPPONENT_ROBOT_FIGHTPOWER);
			// 加入list
			ArenaOpponent ao = new ArenaOpponent(roleId, tplId, rank);
			ao.setOwnerId(getCharId());
			//机器人名字
			if (robotName != null && !robotName.isEmpty()) {
				ao.setRobotName(robotName);
			}
			//机器人等级
			ao.setRobotLevel(robotLevel);
			//机器人战斗力
			ao.setRobotFightPower(robotFightPower);
			
			addOpponent(ao);
		}
	}
	
	@Override
	public boolean equals(Object obj) {
		ArenaMember oMember = (ArenaMember) obj;
		if (getId() == oMember.getId()) {
			return true;
		}
		return false;
	}

	@Override
	public void setDbId(Long id) {
		this.id = id;
	}

	@Override
	public Long getDbId() {
		return this.id;
	}

	@Override
	public String getGUID() {
		return "ArenaSnapEntity#" + this.id;
	}

	@Override
	public boolean isInDb() {
		return this.inDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.inDb = inDb;
	}

	@Override
	public long getCharId() {
		return this.id;
	}

	@Override
	public ArenaSnapEntity toEntity() {
		ArenaSnapEntity entity = new ArenaSnapEntity();
		entity.setId(getId());
		entity.setRank(getRank());
		entity.setSnapLevel(getSnapLevel());
		entity.setSnapRank(getSnapRank());
		entity.setRankMax(getRankMax());
		entity.setConWinTimes(getConWinTimes());
		entity.setWinTimes(getWinTimes());
		entity.setLossTimes(getLossTimes());
		entity.setAttackTotalTimes(getAttackTotalTimes());
		entity.setAttackCdTime(getAttackCdTime());
		entity.setOpList(opListToJsonStr());
		entity.setFightLog(fightLogToJsonStr());
		return entity;
	}

	@Override
	public void fromEntity(ArenaSnapEntity entity) {
		this.setId(entity.getId());
		this.setRank(entity.getRank());
		this.setSnapLevel(entity.getSnapLevel());
		this.setSnapRank(entity.getSnapRank());
		this.setRankMax(entity.getRankMax());
		this.setConWinTimes(entity.getConWinTimes());
		this.setWinTimes(entity.getWinTimes());
		this.setLossTimes(entity.getLossTimes());
		this.setAttackTotalTimes(entity.getAttackTotalTimes());
		this.setAttackCdTime(entity.getAttackCdTime());
		
		opListFromJsonStr(entity.getOpList());
		fightLogFromJsonStr(entity.getFightLog());
		
		this.setInDb(true);
		this.active();
	}

	@Override
	public LifeCycle getLifeCycle() {
		return this.lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			commonScene.getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}
	
	/**
	 * 激活此对象，并初始化属性 此方法在玩家登录加载完数据
	 */
	public void active() {
		getLifeCycle().activate();
	}

	

}
