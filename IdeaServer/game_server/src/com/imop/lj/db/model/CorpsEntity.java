package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

@Entity
@Table(name = "t_corps")
@Comment(content="数据库实体类：军团")
public class CorpsEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	/** 军团ID */
	@Comment(content="军团ID")
	private long id;
	/** 帮派名称 */
	@Comment(content="名称")
	private String name;
	/** 军团级别 */
	@Comment(content="军团级别")
	private int level;
	/** 当前经验 */
	@Comment(content="当前经验")
	private long currExp;
	/** 当前帮派资金 */
	@Comment(content="当前帮派资金")
	private long currFund;
	/** 当前成员数量 */
	private int currMemNum;
	/** 公告 */
	@Comment(content="公告")
	private String notice;
	/** 会长 */
	@Comment(content="会长")
	private long president;
	/** 会长名 */
	@Comment(content="会长名")
	private String presidentName;
	/** 创建者 */
	@Comment(content="创建者")
	private long creater;
	/** 创建时间 */
	@Comment(content="创建时间")
	private long createDate;
	/** 仓库信息 */
	@Comment(content="仓库信息")
	private String storagePack;
	
	@Comment(content="能否改名，合服时被改名的标记")
	private int canRename;
	
	/** 帮派解散确认时间*/
	@Comment(content="帮派解散确认时间")
	private long disbandConfrimDate;
	
	/** 帮派升级确认时间*/
//	@Comment(content="帮派升级确认时间")
//	private long upgradeConfrimDate;
	
	/**帮派维护费用通知次数*/
	@Comment(content="帮派维护费用通知次数")
	private int delinquentNum = 0;
	
	/** 本周帮派boss最高进度*/
	@Comment(content="本周帮派boss进度")
	private int weekBossLevel;
	
	/** 本周帮派boss最高进度录像*/
	@Comment(content="本周帮派boss进度录像")
	private String weekBossLevelReplay;
	
	/** 本周帮派boss最少回合数*/
	@Comment(content="本周帮派boss最少回合数")
	private int weekBossRound;
	
	/** 本周帮派boss挑战次数*/
	@Comment(content="本周帮派boss挑战次数")
	private int weekBossCount;
	
	/** 本周挑战帮派boss时间*/
	@Comment(content="本周挑战帮派boss时间")
	private long weekBossUpdateTime;
	
	/** 帮派建筑信息 */
	@Comment(content="帮派建筑信息")
	private String buildInfo;
	
	
	@Id
	@Override
	public Long getId() {
		return this.id;
	}

	@Override
	public void setId(Long id) {
		this.id = id;
	}

	@Column
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCurrExp() {
		return currExp;
	}

	public void setCurrExp(long currExp) {
		this.currExp = currExp;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCurrFund() {
		return currFund;
	}

	public void setCurrFund(long currFund) {
		this.currFund = currFund;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getCurrMemNum() {
		return currMemNum;
	}

	public void setCurrMemNum(int currMemNum) {
		this.currMemNum = currMemNum;
	}

	@Column
	public String getNotice() {
		return notice;
	}

	public void setNotice(String notice) {
		this.notice = notice;
	}

	@Column
	public long getPresident() {
		return president;
	}

	public void setPresident(long president) {
		this.president = president;
	}

	@Column
	public String getPresidentName() {
		return presidentName;
	}

	public void setPresidentName(String presidentName) {
		this.presidentName = presidentName;
	}

	@Column
	public long getCreater() {
		return creater;
	}

	public void setCreater(long creater) {
		this.creater = creater;
	}

	@Column
	public long getCreateDate() {
		return createDate;
	}

	public void setCreateDate(long createDate) {
		this.createDate = createDate;
	}
	
	@Column
	public String getStoragePack() {
		return storagePack;
	}

	public void setStoragePack(String storagePack) {
		this.storagePack = storagePack;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getCanRename() {
		return canRename;
	}

	public void setCanRename(int canRename) {
		this.canRename = canRename;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getDisbandConfrimDate() {
		return disbandConfrimDate;
	}

	public void setDisbandConfrimDate(long disbandConfrimDate) {
		this.disbandConfrimDate = disbandConfrimDate;
	}

//	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
//	public long getUpgradeConfrimDate() {
//		return upgradeConfrimDate;
//	}
//
//	public void setUpgradeConfrimDate(long upgradeConfrimDate) {
//		this.upgradeConfrimDate = upgradeConfrimDate;
//	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getDelinquentNum() {
		return delinquentNum;
	}

	public void setDelinquentNum(int delinquentNum) {
		this.delinquentNum = delinquentNum;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getWeekBossLevel() {
		return weekBossLevel;
	}

	public void setWeekBossLevel(int weekBossLevel) {
		this.weekBossLevel = weekBossLevel;
	}
	
	@Column(columnDefinition = " varchar(255) ", nullable = true)
	public String getWeekBossLevelReplay() {
		return weekBossLevelReplay;
	}

	public void setWeekBossLevelReplay(String weekBossLevelReplay) {
		this.weekBossLevelReplay = weekBossLevelReplay;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getWeekBossRound() {
		return weekBossRound;
	}

	public void setWeekBossRound(int weekBossRound) {
		this.weekBossRound = weekBossRound;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getWeekBossCount() {
		return weekBossCount;
	}

	public void setWeekBossCount(int weekBossCount) {
		this.weekBossCount = weekBossCount;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getWeekBossUpdateTime() {
		return weekBossUpdateTime;
	}

	public void setWeekBossUpdateTime(long weekBossUpdateTime) {
		this.weekBossUpdateTime = weekBossUpdateTime;
	}

	@Column(columnDefinition = "LONGTEXT")
	public String getBuildInfo() {
		return buildInfo;
	}

	public void setBuildInfo(String buildInfo) {
		this.buildInfo = buildInfo;
	}
	
}
