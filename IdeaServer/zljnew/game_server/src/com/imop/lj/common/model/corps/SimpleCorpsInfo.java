package com.imop.lj.common.model.corps;

/**
 * 简单军团信息
 * 
 * @author xiaowei.liu
 * 
 */
public class SimpleCorpsInfo {
	/** 军团ID */
	private long corpsId;
	/** 军团名称 */
	private String name;
	/** 军团级别 */
	private int level;
	/** 团长名称 */
	private String presidentName;
	
	private long presidentId;
	private int presidentLevel;
	private int presidentTplId;
	
	/** 当前成员数量 */
	private int currMemNum;
	/** 最大成员数量 */
	private int maxMemNum;
	/** 所属国家 */
	private int country;
	/** 军团QQ */
	private String qq;
	/** 公告 */
	private String notice;
	/** 军团排名 */
	private int rank;
	/** 是否已经申请 */
	private int isApplied;
	/** 军团功能 列表 */
	private CorpsFuncInfo[] corpsFuncInfoList;

	public SimpleCorpsInfo() {
		this.corpsFuncInfoList = new CorpsFuncInfo[0];
	}

	public long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public String getPresidentName() {
		return presidentName;
	}

	public void setPresidentName(String presidentName) {
		this.presidentName = presidentName;
	}

	public int getCurrMemNum() {
		return currMemNum;
	}

	public void setCurrMemNum(int currMemNum) {
		this.currMemNum = currMemNum;
	}

	public int getMaxMemNum() {
		return maxMemNum;
	}

	public void setMaxMemNum(int maxMemNum) {
		this.maxMemNum = maxMemNum;
	}

	public int getCountry() {
		return country;
	}

	public void setCountry(int country) {
		this.country = country;
	}

	public String getNotice() {
		return notice;
	}

	public void setNotice(String notice) {
		this.notice = notice;
	}

	public CorpsFuncInfo[] getCorpsFuncInfoList() {
		return corpsFuncInfoList;
	}

	public void setCorpsFuncInfoList(CorpsFuncInfo[] corpsFuncInfoList) {
		this.corpsFuncInfoList = corpsFuncInfoList;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	public String getQq() {
		return qq;
	}

	public void setQq(String qq) {
		this.qq = qq;
	}

	public int getIsApplied() {
		return isApplied;
	}

	public void setIsApplied(int isApplied) {
		this.isApplied = isApplied;
	}

	public long getPresidentId() {
		return presidentId;
	}

	public void setPresidentId(long presidentId) {
		this.presidentId = presidentId;
	}

	public int getPresidentLevel() {
		return presidentLevel;
	}

	public void setPresidentLevel(int presidentLevel) {
		this.presidentLevel = presidentLevel;
	}

	public int getPresidentTplId() {
		return presidentTplId;
	}

	public void setPresidentTplId(int presidentTplId) {
		this.presidentTplId = presidentTplId;
	}

}
