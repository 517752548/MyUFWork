package com.imop.lj.common.model;


public class MissionEnemyInfo {
	
	/** 关卡Id */
	private int missionEnemyId;
	/** 关卡名称 */
	private String missionEnemyName;
	/** 索引 */
	private int index;
	/** 图片 */
	private int photo;
	/** boss头像 */
	private int bossPic;
	/** 描述 */
	private String desc;
	
	/** 评分 */
	private int evaluate;
	/** 关卡状态，即 MissionEnemyStatusEnum 对应的索引值 */
	private int status;
	/** 攻击限制等级，默认为0，需要显示时该值大于0 */
	private int limitLevel;
	
	public MissionEnemyInfo() {
		
	}
	

	public int getMissionEnemyId() {
		return missionEnemyId;
	}

	public void setMissionEnemyId(int missionEnemyId) {
		this.missionEnemyId = missionEnemyId;
	}

	public String getMissionEnemyName() {
		return missionEnemyName;
	}

	public void setMissionEnemyName(String missionEnemyName) {
		this.missionEnemyName = missionEnemyName;
	}

	public int getIndex() {
		return index;
	}

	public void setIndex(int index) {
		this.index = index;
	}

	public int getPhoto() {
		return photo;
	}

	public void setPhoto(int photo) {
		this.photo = photo;
	}

	public int getBossPic() {
		return bossPic;
	}

	public void setBossPic(int bossPic) {
		this.bossPic = bossPic;
	}

	public int getEvaluate() {
		return evaluate;
	}

	public void setEvaluate(int evaluate) {
		this.evaluate = evaluate;
	}

	public String getDesc() {
		return desc;
	}

	public void setDesc(String desc) {
		this.desc = desc;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}

	public int getLimitLevel() {
		return limitLevel;
	}

	public void setLimitLevel(int limitLevel) {
		this.limitLevel = limitLevel;
	}


	@Override
	public String toString() {
		return "MissionEnemyInfo [missionEnemyId=" + missionEnemyId
				+ ", missionEnemyName=" + missionEnemyName + ", index=" + index
				+ ", photo=" + photo + ", bossPic=" + bossPic + ", desc="
				+ desc + ", evaluate=" + evaluate + ", status=" + status
				+ ", limitLevel=" + limitLevel + "]";
	}

}
