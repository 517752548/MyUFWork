package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 军团成员实体类
 * 
 * @author xiaowei.liu
 * 
 */
@Entity
@Table(name = "t_corps_member")
@Comment(content="数据库实体类：军团成员")
public class CorpsMemberEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	/** 主键 */
	@Comment(content="主键")
	private Long id;
	/** 玩家ID */
	@Comment(content=" 玩家ID")
	private Long roleId;
	/** 成员名称 */
	@Comment(content="成员名称")
	private String name;
	/** 成员级别 */
	@Comment(content="成员级别")
	private int level;
	/** 军团ID */
	@Comment(content="军团ID")
	private Long corpsId;
	/** 当天捐献 */
	@Comment(content="当天捐献")
	private Long todayDonate;
	/** 总捐献 */
	@Comment(content="总捐献")
	private Long totalDonate;
	/** 捐献时间 */
	@Comment(content="捐献时间 ")
	private Long donateDate;
	/** 经验 */
	@Comment(content="经验 ")
	private Long toCorpsExp;
	/** 加入时间 */
	@Comment(content="加入时间 ")
	private Long joinDate;
	/** 登出时间 */
	@Comment(content="登出时间  ")
	private Long logoutTime;

	/** 军团成员状态 */
	@Comment(content="军团成员状态")
	private int corpsMemState;
	
	/** 本周帮贡 */
	@Comment(content="本周帮贡")
	private int weekyContribution;
	/** 总捐献 */
	@Comment(content="总帮贡")
	private int totalContribution;
	/** 贡献时间 */
	@Comment(content="贡献时间 ")
	private Long contributeDate;
	/** 上周帮贡 */
	@Comment(content="上周帮贡")
	private int lastWeekContribution;
	/** 领取福利时间 */
	@Comment(content="领取福利时间 ")
	private Long benifitDate;
	/** 成员职业 */
	@Comment(content="成员职业")
	private int petJob;
	/** 成员职务 */
	@Comment(content="成员职务")
	private int memJob;
	/** 成员性别 */
	@Comment(content="成员性别")
	private int sex;
	
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
	public Long getRoleId() {
		return roleId;
	}

	public void setRoleId(Long roleId) {
		this.roleId = roleId;
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

	@Column
	public Long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(Long corpsId) {
		this.corpsId = corpsId;
	}

	@Column
	public Long getTodayDonate() {
		return todayDonate;
	}

	public void setTodayDonate(Long todayDonate) {
		this.todayDonate = todayDonate;
	}
	
	@Column
	public Long getTotalDonate() {
		return totalDonate;
	}

	public void setTotalDonate(Long totalDonate) {
		this.totalDonate = totalDonate;
	}
	
	@Column
	public Long getDonateDate() {
		return donateDate;
	}

	public void setDonateDate(Long donateDate) {
		this.donateDate = donateDate;
	}

	@Column
	public Long getToCorpsExp() {
		return toCorpsExp;
	}

	public void setToCorpsExp(Long toCorpsExp) {
		this.toCorpsExp = toCorpsExp;
	}

	@Column
	public Long getJoinDate() {
		return joinDate;
	}

	public void setJoinDate(Long joinDate) {
		this.joinDate = joinDate;
	}

	@Column
	public Long getLogoutTime() {
		return logoutTime;
	}

	public void setLogoutTime(Long logoutTime) {
		this.logoutTime = logoutTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getCorpsMemState() {
		return corpsMemState;
	}

	public void setCorpsMemState(int corpsMemState) {
		this.corpsMemState = corpsMemState;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getWeekyContribution() {
		return weekyContribution;
	}

	public void setWeekyContribution(int weekyContribution) {
		this.weekyContribution = weekyContribution;
	}

	@Column
	public int getTotalContribution() {
		return totalContribution;
	}

	public void setTotalContribution(int totalContribution) {
		this.totalContribution = totalContribution;
	}

	@Column
	public Long getContributeDate() {
		return contributeDate;
	}

	public void setContributeDate(Long contributeDate) {
		this.contributeDate = contributeDate;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLastWeekContribution() {
		return lastWeekContribution;
	}

	public void setLastWeekContribution(int lastWeekContribution) {
		this.lastWeekContribution = lastWeekContribution;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public Long getBenifitDate() {
		return benifitDate;
	}

	public void setBenifitDate(Long benifitDate) {
		this.benifitDate = benifitDate;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getPetJob() {
		return petJob;
	}

	public void setPetJob(int petJob) {
		this.petJob = petJob;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getMemJob() {
		return memJob;
	}

	public void setMemJob(int memJob) {
		this.memJob = memJob;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getSex() {
		return sex;
	}

	public void setSex(int sex) {
		this.sex = sex;
	}


}
