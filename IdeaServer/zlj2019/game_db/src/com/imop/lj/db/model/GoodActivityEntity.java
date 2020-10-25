package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 精彩活动数据实体
 *
 */
@Entity
@Table(name = "t_good_activity")
@Comment(content="数据库实体类：精彩活动数据实体")
public class GoodActivityEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	/** 唯一Id 主键 */
	@Comment(content="唯一Id 主键")
	private long id;
	
	/** 活动模板Id */
	@Comment(content="活动模板Id")
	private int activityTplId;
	/** 活动类型 */
	@Comment(content="活动类型")
	private int activityType;
	/** 活动开始时间 */
	@Comment(content="活动开始时间")
	private long startTime;
	/** 活动结束时间 */
	@Comment(content="活动结束时间 ")
	private long endTime;
	/** 是否关闭 */
	@Comment(content="是否关闭 ")
	private int isClosed;
	/** 关闭时间 */
	@Comment(content="关闭时间 ")
	private long closeTime;
	@Comment(content="是否强制关闭的，0否，1是")
	private int isForceEnd;
	/** 最后一次更新时间，用于记录活动期间的结算时间 */
	@Comment(content="最后一次更新时间，用于记录活动期间的结算时间")
	private long lastRefreshTime;
	@Comment(content="是否生效，1可用，0无效")
	private int isAvailable;
	@Comment(content="活动名称")
	private String activityName;
	@Comment(content="活动描述")
	private String activityDesc;
	@Comment(content="活动日志，游戏逻辑用")
	private String logStr;
	@Comment(content="名称图标")
	private int nameIcon;
	@Comment(content="标题图标")
	private int titleIcon;
	@Comment(content="活动是否已开始")
	private int isStarted;
	
	@Comment(content="服务器Id列表，普通服一个如[1001]，合过服的是多个，如[1001,1002]")
	private String serverIds;

	@Id
	@Override
	public Long getId() {
		return id;
	}
	
	@Override
	public void setId(Long id) {
		this.id = id;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getEndTime() {
		return endTime;
	}

	public void setEndTime(long endTime) {
		this.endTime = endTime;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getActivityTplId() {
		return activityTplId;
	}

	public void setActivityTplId(int activityTplId) {
		this.activityTplId = activityTplId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getActivityType() {
		return activityType;
	}

	public void setActivityType(int activityType) {
		this.activityType = activityType;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getIsClosed() {
		return isClosed;
	}

	public void setIsClosed(int isClosed) {
		this.isClosed = isClosed;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCloseTime() {
		return closeTime;
	}

	public void setCloseTime(long closeTime) {
		this.closeTime = closeTime;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastRefreshTime() {
		return lastRefreshTime;
	}

	public void setLastRefreshTime(long lastRefreshTime) {
		this.lastRefreshTime = lastRefreshTime;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getIsAvailable() {
		return isAvailable;
	}

	public void setIsAvailable(int isAvailable) {
		this.isAvailable = isAvailable;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getIsForceEnd() {
		return isForceEnd;
	}

	public void setIsForceEnd(int isForceEnd) {
		this.isForceEnd = isForceEnd;
	}

	@Column(columnDefinition = "TEXT")
	public String getActivityName() {
		return activityName;
	}

	public void setActivityName(String activityName) {
		this.activityName = activityName;
	}

	@Column(columnDefinition = "TEXT")
	public String getActivityDesc() {
		return activityDesc;
	}

	public void setActivityDesc(String activityDesc) {
		this.activityDesc = activityDesc;
	}

	@Column(columnDefinition = "TEXT")
	public String getLogStr() {
		return logStr;
	}

	public void setLogStr(String logStr) {
		this.logStr = logStr;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getNameIcon() {
		return nameIcon;
	}

	public void setNameIcon(int nameIcon) {
		this.nameIcon = nameIcon;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getTitleIcon() {
		return titleIcon;
	}

	public void setTitleIcon(int titleIcon) {
		this.titleIcon = titleIcon;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getIsStarted() {
		return isStarted;
	}

	public void setIsStarted(int isStarted) {
		this.isStarted = isStarted;
	}

	@Column(nullable = true, insertable = true, updatable = true)
	public String getServerIds() {
		return serverIds;
	}

	public void setServerIds(String serverIds) {
		this.serverIds = serverIds;
	}
}
