package com.imop.lj.gm.service.notice.data;

import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.gm.utils.DateUtil;

public class MobileActivityShowData {
	//id  活动id 
	private String id;
	//开始时间
	private String startDate;
	//开始时间
	private String startTime;
	//结束时间
	private String endDate;
	//结束时间
	private String endTime;
	//活动奖励组id
	private String mobilePrizeGrepsId;
	//活动奖励组名称
	private String mobilePrizeGrepsName;
	//是否可用
	private String useOrNot;
	//活动名称
	private String name;
	//活动描述
	private String descMobileActivity;
	//是否给奖
	private String givePrizeOrNot;
	//强制关闭
	private String forceEndOrNot;
	//活动子类型
	private String mobileActivitySubType;
	//活动子类型
	private String mobileActivityPrize;
	// 活动类型
	private String activityType;
	// 是否已关闭
	private String isClosed;
	// 关闭时间
	private String closeTime;
	private String closeData;
	
	// 名称图标
	private String nameIcon;
	// 标题图标
	private String titleIcon;
	
	/** 该活动所属服务器Ids */
	private String sIds;
	
	
	public MobileActivityShowData(){}
	
	public MobileActivityShowData(String id,String dateStart,String startTime,String dateEnd,String endTime,String prizeGroupsId,String activityName,
			String activityDesc,String activityUsable,String foreEnd, String nameIcon, String titleIcon){
		this.setId(id);
		this.setDescMobileActivity(activityDesc);
		this.setEndDate(dateEnd);
		this.setEndTime(endTime);
		this.setForceEndOrNot(foreEnd);
		this.setMobilePrizeGrepsId(prizeGroupsId);
		this.setName(activityName);
		this.setStartDate(dateStart);
		this.setStartTime(startTime);
		this.setUseOrNot(activityUsable);
		this.setNameIcon(nameIcon);
		this.setTitleIcon(titleIcon);
	}
	
	public MobileActivityShowData(GoodActivityEntity entity, String name, String desc){
		String nameCur = entity.getActivityName();
		String descCur = entity.getActivityDesc();
		if (nameCur == null || nameCur.equalsIgnoreCase("")) {
			nameCur = name;
		}
		if (descCur == null || descCur.equalsIgnoreCase("")) {
			descCur = desc;
		}
		this.setDescMobileActivity(descCur);
		this.setName("["+entity.getActivityTplId()+"]"+nameCur);
		
		// nameIcon
		this.setNameIcon(entity.getNameIcon()+"");
		// titleIcon
		this.setTitleIcon(entity.getTitleIcon()+"");
		
		this.setEndTime(DateUtil.formateTimeLong(entity.getEndTime()));
		this.setEndDate(DateUtil.formatDate(entity.getEndTime()));
		this.setForceEndOrNot(entity.getIsForceEnd()+"");
//		this.setGivePrizeOrNot(entity.getIsAvailable()+"");
		this.setId(entity.getId()+"");
		this.setMobilePrizeGrepsId(entity.getActivityTplId()+"");
		this.setStartTime(DateUtil.formateTimeLong(entity.getStartTime()));
		this.setStartDate(DateUtil.formatDate(entity.getStartTime()));
		this.setUseOrNot(entity.getIsAvailable()+"");
		
		this.setActivityType(entity.getActivityType()+"");
		this.setIsClosed(entity.getIsClosed()+"");
		// 如果已经强制关闭，则设为已关闭
		if (entity.getIsForceEnd() > 0) {
			this.setIsClosed("1");
		}
		this.setCloseTime(DateUtil.formateTimeLong(entity.getCloseTime()));
		this.setCloseDate(DateUtil.formatDate(entity.getCloseTime()));
		
		this.setMobilePrizeGrepsName(mobilePrizeGrepsName);
//		this.setMobileActivityPrize(prize);
		
		this.setsIds(entity.getServerIds());
	}

	public String getActivityType() {
		return activityType;
	}

	public void setActivityType(String activityType) {
		this.activityType = activityType;
	}

	public String getIsClosed() {
		return isClosed;
	}

	public void setIsClosed(String isClosed) {
		this.isClosed = isClosed;
	}

	public String getCloseTime() {
		return closeTime;
	}

	public void setCloseTime(String closeTime) {
		this.closeTime = closeTime;
	}
	
	public void setCloseDate(String closeData) {
		this.closeData = closeData;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getStartDate() {
		return startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	public String getStartTime() {
		return startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}

	public String getMobilePrizeGrepsId() {
		return mobilePrizeGrepsId;
	}

	public void setMobilePrizeGrepsId(String mobilePrizeGrepsId) {
		this.mobilePrizeGrepsId = mobilePrizeGrepsId;
	}

	public String getMobilePrizeGrepsName() {
		return mobilePrizeGrepsName;
	}

	public void setMobilePrizeGrepsName(String mobilePrizeGrepsName) {
		this.mobilePrizeGrepsName = mobilePrizeGrepsName;
	}

	public String getUseOrNot() {
		return useOrNot;
	}

	public void setUseOrNot(String useOrNot) {
		this.useOrNot = useOrNot;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getDescMobileActivity() {
		return descMobileActivity;
	}

	public void setDescMobileActivity(String descMobileActivity) {
		this.descMobileActivity = descMobileActivity;
	}

	public String getGivePrizeOrNot() {
		return givePrizeOrNot;
	}

	public void setGivePrizeOrNot(String givePrizeOrNot) {
		this.givePrizeOrNot = givePrizeOrNot;
	}

	public String getForceEndOrNot() {
		return forceEndOrNot;
	}

	public void setForceEndOrNot(String forceEndOrNot) {
		this.forceEndOrNot = forceEndOrNot;
	}

	public String getEndDate() {
		return endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	public String getEndTime() {
		return endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}

	public String getMobileActivitySubType() {
		return mobileActivitySubType;
	}

	public void setMobileActivitySubType(String mobileActivitySubType) {
		this.mobileActivitySubType = mobileActivitySubType;
	}

	public String getMobileActivityPrize() {
		return mobileActivityPrize;
	}

	public void setMobileActivityPrize(String mobileActivityPrize) {
		this.mobileActivityPrize = mobileActivityPrize;
	}

	public String getCloseData() {
		return closeData;
	}

	public void setCloseData(String closeData) {
		this.closeData = closeData;
	}

	public String getNameIcon() {
		return nameIcon;
	}

	public void setNameIcon(String nameIcon) {
		this.nameIcon = nameIcon;
	}

	public String getTitleIcon() {
		return titleIcon;
	}

	public void setTitleIcon(String titleIcon) {
		this.titleIcon = titleIcon;
	}

	public String getsIds() {
		return sIds;
	}

	public void setsIds(String sIds) {
		this.sIds = sIds;
	}
	
}
