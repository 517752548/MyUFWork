package com.imop.lj.gm.model.log;

import java.util.List;

public class DayChongRewardLog extends BaseLog {

    private String rewardType;
    private String rewardId;
    private String createRewardTime;
    private String hasGet;
    private String getTime;
    private String templateId;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(this.rewardType);
		list.add(this.rewardId);
		list.add(this.createRewardTime);
		list.add(this.hasGet);
		list.add(this.getTime);
		list.add(this.templateId);
		return list;
	}

	public String getRewardType() {
		return rewardType;
	}

	public void setRewardType(String rewardType) {
		this.rewardType = rewardType;
	}

	public String getRewardId() {
		return rewardId;
	}

	public void setRewardId(String rewardId) {
		this.rewardId = rewardId;
	}

	public String getCreateRewardTime() {
		return createRewardTime;
	}

	public void setCreateRewardTime(String createRewardTime) {
		this.createRewardTime = createRewardTime;
	}

	public String getHasGet() {
		return hasGet;
	}

	public void setHasGet(String hasGet) {
		this.hasGet = hasGet;
	}

	public String getGetTime() {
		return getTime;
	}

	public void setGetTime(String getTime) {
		this.getTime = getTime;
	}

	public String getTemplateId() {
		return templateId;
	}

	public void setTemplateId(String templateId) {
		this.templateId = templateId;
	}

}
