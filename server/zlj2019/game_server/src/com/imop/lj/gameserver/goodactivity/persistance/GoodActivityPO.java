package com.imop.lj.gameserver.goodactivity.persistance;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

import net.sf.json.JSONArray;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityStatus;
import com.imop.lj.gameserver.scene.CommonScene;
import com.imop.lj.gameserver.util.FixedSizeQueue;

public class GoodActivityPO implements PersistanceObject<Long, GoodActivityEntity> {
	
	/** uuid 主键 */
	private long id;
	
	/** 活动模板Id */
	private int activityTplId;
	/** 活动类型 */
	private int activityType;
	/** 活动开始时间 */
	private long startTime;
	/** 活动结束时间 */
	private long endTime;
	/** 是否已关闭 */
	private int isClosed;
	/** 关闭时间 */
	private long closeTime;
	/** 最后一次更新时间，用于记录活动期间的结算时间 */
	private long lastRefreshTime;
	/** 是否强制关闭的，0否，1是 */
	private int isForceEnd;
	/** 是否生效 */
	private int isAvailable;
	/** 名称 */
	private String activityName;
	/** 描述 */
	private String activityDesc;
	
	/** 名称图标 */
	private int nameIcon;
	/** 标题图标 */
	private int titleIcon;
	/** 活动是否已开始 */
	private int isStarted;
	
	/** 服务器Id列表，对应db的serverIds */
	private Set<Integer> serverIdSet = new HashSet<Integer>();
	
	/** 活动日志（游戏逻辑用） */
	protected FixedSizeQueue<String> logData = new FixedSizeQueue<String>(GoodActivityDef.GA_LOG_SIZE);
	
	/** 此实例是否在db中 */
	private boolean inDb;
	/** 生命期 */ 
	private final LifeCycle lifeCycle; 
	/** 场景 */
	private CommonScene commonScene;
	
	public GoodActivityPO() {
		commonScene = Globals.getSceneService().getCommonScene();
		this.lifeCycle = new LifeCycleImpl(this);
	}
	
	public int getActivityTplId() {
		return activityTplId;
	}

	public void setActivityTplId(int activityTplId) {
		this.activityTplId = activityTplId;
	}

	public int getActivityType() {
		return activityType;
	}

	public void setActivityType(int activityType) {
		this.activityType = activityType;
	}

	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	public long getEndTime() {
		return endTime;
	}

	public void setEndTime(long endTime) {
		this.endTime = endTime;
	}

	public int getIsClosed() {
		return isClosed;
	}

	public void setIsClosed(int isClosed) {
		this.isClosed = isClosed;
	}

	public long getCloseTime() {
		return closeTime;
	}

	public void setCloseTime(long closeTime) {
		this.closeTime = closeTime;
	}

	public long getLastRefreshTime() {
		return lastRefreshTime;
	}

	public void setLastRefreshTime(long lastRefreshTime) {
		this.lastRefreshTime = lastRefreshTime;
		this.setModified();
	}
	
	/**
	 * 当前活动是否生效
	 * @return
	 */
	public boolean isAvailable() {
		return getIsAvailable() == GoodActivityStatus.OPENED.getIndex();
	}

	public int getIsAvailable() {
		return isAvailable;
	}

	public void setIsAvailable(int isAvailable) {
		this.isAvailable = isAvailable;
		this.setModified();
	}
	
	/**
	 * 是否强制关闭的
	 * @return
	 */
	public boolean isForceEnd() {
		return getIsForceEnd() == GoodActivityStatus.OPENED.getIndex();
	}

	public int getIsForceEnd() {
		return isForceEnd;
	}

	public void setIsForceEnd(int isForceEnd) {
		this.isForceEnd = isForceEnd;
	}

	public String getActivityName() {
		return activityName;
	}

	public void setActivityName(String activityName) {
		this.activityName = activityName;
	}

	public String getActivityDesc() {
		return activityDesc;
	}

	public void setActivityDesc(String activityDesc) {
		this.activityDesc = activityDesc;
	}

	public String getLogStr() {
		JSONArray json = new JSONArray();
		for (int i = 0; i < logData.size(); i++) {
			if (logData.get(i) != null) {
				json.add(logData.get(i));
			}
		}
		return json.toString();
	}

	public void setLogStr(String logStr) {
		if (logStr == null || logStr.isEmpty()) {
			return;
		}
		JSONArray json = JSONArray.fromObject(logStr);
		if (json == null || json.isEmpty()) {
			return;
		}
		for (int i = 0; i < json.size(); i++) {
			addLog(json.getString(i));
		}
	}
	
	public void addLog(String log) {
		logData.add(log);
	}
	
	public List<String> getLogList() {
		return logData.getList(true);
	}

	public int getNameIcon() {
		return nameIcon;
	}

	public void setNameIcon(int nameIcon) {
		this.nameIcon = nameIcon;
	}

	public int getTitleIcon() {
		return titleIcon;
	}

	public void setTitleIcon(int titleIcon) {
		this.titleIcon = titleIcon;
	}

	/**
	 * 活动是否已开始
	 * @return
	 */
	public boolean isStarted() {
		return getIsStarted() == GoodActivityStatus.OPENED.getIndex();
	}
	
	public int getIsStarted() {
		return isStarted;
	}

	public void setIsStarted(int isStarted) {
		this.isStarted = isStarted;
		setModified();
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}
	
	public Set<Integer> getServerIdSet() {
		return serverIdSet;
	}
	
	public void setServerIdSet(Set<Integer> serverIdSet) {
		this.serverIdSet = serverIdSet;
	}

	protected void explainServerIds(String serverIds) {
		if (serverIds == null || serverIds.isEmpty()) {
			return;
		}
		JSONArray jsonArr = JSONArray.fromObject(serverIds);
		if (null == jsonArr || jsonArr.isEmpty()) {
			return;
		}
		for (int i = 0; i < jsonArr.size(); i++) {
			int serverId = jsonArr.getInt(i);
			if (serverId <= 0) {
				continue;
			}
			serverIdSet.add(serverId);
		}
	}
	
	protected String serverIdsToString() {
		JSONArray jsonArr = new JSONArray();
		for (Integer serverId : serverIdSet) {
			jsonArr.add(serverId);
		}
		return jsonArr.toString();
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
		return "GoodActivityEntity#" + this.id;
	}

	@Override
	public boolean isInDb() {
		return inDb;
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
	public GoodActivityEntity toEntity() {
		GoodActivityEntity entity = new GoodActivityEntity();
		entity.setId(this.getId());
		entity.setActivityTplId(getActivityTplId());
		entity.setActivityType(getActivityType());
		entity.setStartTime(getStartTime());
		entity.setEndTime(getEndTime());
		entity.setIsClosed(getIsClosed());
		entity.setCloseTime(getCloseTime());
		entity.setLastRefreshTime(getLastRefreshTime());
		entity.setIsAvailable(getIsAvailable());
		entity.setIsForceEnd(getIsForceEnd());
		entity.setActivityName(getActivityName());
		entity.setActivityDesc(getActivityDesc());
		entity.setLogStr(getLogStr());
		entity.setNameIcon(getNameIcon());
		entity.setTitleIcon(getTitleIcon());
		entity.setIsStarted(getIsStarted());
		// 服务器Ids
		entity.setServerIds(serverIdsToString());
		return entity;
	}

	@Override
	public void fromEntity(GoodActivityEntity entity) {
		this.setId(entity.getId());
		this.setActivityTplId(entity.getActivityTplId());
		this.setActivityType(entity.getActivityType());
		this.setStartTime(entity.getStartTime());
		this.setEndTime(entity.getEndTime());
		this.setIsClosed(entity.getIsClosed());
		this.setCloseTime(entity.getCloseTime());
		this.setLastRefreshTime(entity.getLastRefreshTime());
		this.setIsAvailable(entity.getIsAvailable());
		this.setIsForceEnd(entity.getIsForceEnd());
		this.setActivityName(entity.getActivityName());
		this.setActivityDesc(entity.getActivityDesc());
		this.setLogStr(entity.getLogStr());
		this.setNameIcon(entity.getNameIcon());
		this.setTitleIcon(entity.getTitleIcon());
		this.setIsStarted(entity.getIsStarted());
		// 服务器Ids
		explainServerIds(entity.getServerIds());
		
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
	 * 删除信息
	 */
	public void delete() {
		onDelete();
	}
	
	/**
	 * 实例被删除,触发删除机制
	 */
	protected void onDelete() {
		this.lifeCycle.destroy();
		this.commonScene.getCommonDataUpdater().addDelete(lifeCycle);
	}
	
	/**
	 * 激活此对象，并初始化属性 此方法在玩家登录加载完数据
	 */
	public void active() {
		getLifeCycle().activate();
	}

}
