package com.imop.lj.common.model.corps;

/**
 * 玩家申请信息
 * 
 * @author xiaowei.liu
 * 
 */
public class MemberApplyInfo {
	private long memId;
	private String name;
	private int level;
	private int sex;
	private int petJob;
	private CorpsMemberFuncInfo[] applyFuncInfoList;

	public MemberApplyInfo() {
		this.applyFuncInfoList = new CorpsMemberFuncInfo[0];
	}

	public long getMemId() {
		return memId;
	}

	public void setMemId(long memId) {
		this.memId = memId;
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

	public CorpsMemberFuncInfo[] getApplyFuncInfoList() {
		return applyFuncInfoList;
	}

	public void setApplyFuncInfoList(CorpsMemberFuncInfo[] applyFuncInfoList) {
		this.applyFuncInfoList = applyFuncInfoList;
	}

	public int getSex() {
		return sex;
	}

	public void setSex(int sex) {
		this.sex = sex;
	}

	public int getPetJob() {
		return petJob;
	}

	public void setPetJob(int petJob) {
		this.petJob = petJob;
	}

}
