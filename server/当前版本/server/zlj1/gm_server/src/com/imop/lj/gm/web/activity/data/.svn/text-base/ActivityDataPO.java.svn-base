package com.imop.lj.gm.web.activity.data;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.service.db.DBFactoryService;
//import com.imop.lj.gm.web.activity.data.prize.ActivityPrize;

public class ActivityDataPO{
	/** id */
	private long id;
	/*
	//开始时间
	private long starttime;
	//结束时间
	private long endtime;
	//服务器id
	private String serverIds;
	//活动类型
	private int activityType;
	//给奖标示
	private int giveOrNot;
	//活动名称
	private String activityName;
	//活动介绍
	private String activityDetaile;
	//活动奖励描述
	private String activityDesc;
	//修改时间
	private long updateTime;
	//礼包名称
	private String prizeName;
	//活动内容
	private String activityContent;
	//活动时间描述
	private String activitySelectName;
	//活动特效标示
	private int activityNamEffect;
	//参数1
	private int activityPromOne;
	//是否可用
	private int activityUsable;
	//强制关闭
	private int activityForceEndOrNot;
	//奖励
	private String prizes;
	//服务器集合
	private List<DBServer> list = new ArrayList<DBServer>();
//	//奖励类
//	private ActivityPrize activityPrize = new ActivityPrize();

	public ActivityDataEntity toEntity() {
		ActivityDataEntity entity = new ActivityDataEntity();
		entity.setActivityType(this.getActivityType());
		entity.setEndtime(new Timestamp(this.getEndtime()));
		entity.setStarttime(new Timestamp(this.getStarttime()));
		entity.setServerIds(this.getServerIds());
		//entity.setPrizes(this.getPrizes());
//		entity.setPrizes(activityPrize.toJsonProp());
		entity.setGiveOrNot(this.getGiveOrNot());
		entity.setActivityDetaile(this.getActivityDetaile());
		entity.setActivityName(this.getActivityName());
		entity.setActivityDesc(this.getActivityDesc());
		entity.setId(this.getId());
		entity.setUpdateTime(new Timestamp(this.getUpdateTime()));
		entity.setPrizeName(this.getPrizeName());
		entity.setActivityContent(this.getActivityContent());
		entity.setActivitySelectName(this.getActivitySelectName());
		entity.setActivityNamEffect(this.getActivityNamEffect());
		entity.setActivityPromOne(this.getActivityPromOne());
		entity.setActivityUsable(this.getActivityUsable());
		entity.setActivityForceEndOrNot(this.getActivityForceEndOrNot());
		return entity;
	}
	public void fromEntity(ActivityDataEntity entity) {
		this.setActivityType(entity.getActivityType());
		this.setEndtime(entity.getEndtime().getTime());
		this.setStarttime(entity.getStarttime().getTime());
		this.setServerIds(entity.getServerIds());
		this.setPrizes(entity.getPrizes());
//		activityPrize.loadJsonProp(entity.getPrizes());
		this.setActivityDetaile(entity.getActivityDetaile());
		this.setActivityName(entity.getActivityName());
		this.setActivityDesc(entity.getActivityDesc());
		this.setGiveOrNot(entity.getGiveOrNot());
		this.setId(entity.getId());
		this.setUpdateTime(entity.getUpdateTime().getTime());
		this.setPrizeName(entity.getPrizeName());
		this.setActivityContent(entity.getActivityContent());
		this.setActivitySelectName(entity.getActivitySelectName());
		this.setActivityNamEffect(entity.getActivityNamEffect());
		this.setActivityPromOne(entity.getActivityPromOne());
		this.setActivityUsable(entity.getActivityUsable());
		this.setActivityForceEndOrNot(entity.getActivityForceEndOrNot());
	}
	
	public long getStarttime() {
		return starttime;
	}
	public void setStarttime(long starttime) {
		this.starttime = starttime;
	}
	public long getEndtime() {
		return endtime;
	}
	public void setEndtime(long endtime) {
		this.endtime = endtime;
	}
	public String getServerIds() {
		return serverIds;
	}
	public void setServerIds(String serverIds) {
		this.serverIds = serverIds;
		list = DBFactoryService.getServers(serverIds);
	}
	public int getActivityType() {
		return activityType;
	}
	public void setActivityType(int activityType) {
		this.activityType = activityType;
	}
//	public ActivityPrize getActivityPrize() {
//		return activityPrize;
//	}
//	public void setActivityPrize(ActivityPrize activityPrize) {
//		this.activityPrize = activityPrize;
//	}
	public List<DBServer> getList() {
		return list;
	}

	public int getGiveOrNot() {
		return giveOrNot;
	}
	public void setGiveOrNot(int giveOrNot) {
		this.giveOrNot = giveOrNot;
	}
	public String getActivityName() {
		return activityName;
	}
	public void setActivityName(String activityName) {
		this.activityName = activityName;
	}
	public String getActivityDetaile() {
		return activityDetaile;
	}
	public void setActivityDetaile(String activityDetaile) {
		this.activityDetaile = activityDetaile;
	}
	public void setList(List<DBServer> list) {
		this.list = list;
	}
	public long getUpdateTime() {
		return updateTime;
	}
	public void setUpdateTime(long updateTime) {
		this.updateTime = updateTime;
	}
	public String getPrizeName() {
		return prizeName;
	}
	public void setPrizeName(String prizeName) {
		this.prizeName = prizeName;
	}
	public String getActivityContent() {
		return activityContent;
	}
	public void setActivityContent(String activityContent) {
		this.activityContent = activityContent;
	}
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	public int getActivityNamEffect() {
		return activityNamEffect;
	}
	public void setActivityNamEffect(int activityNamEffect) {
		this.activityNamEffect = activityNamEffect;
	}
	public int getActivityPromOne() {
		return activityPromOne;
	}
	public void setActivityPromOne(int activityPromOne) {
		this.activityPromOne = activityPromOne;
	}
	public int getActivityUsable() {
		return activityUsable;
	}
	public void setActivityUsable(int activityUsable) {
		this.activityUsable = activityUsable;
	}
	public String getActivityDesc() {
		return activityDesc;
	}
	public void setActivityDesc(String activityDesc) {
		this.activityDesc = activityDesc;
	}
	public String getActivitySelectName() {
		return activitySelectName;
	}
	public void setActivitySelectName(String activitySelectName) {
		this.activitySelectName = activitySelectName;
	}
	public String getPrizes() {
		return prizes;
	}
	public void setPrizes(String prizes) {
		this.prizes = prizes;
	}
	public int getActivityForceEndOrNot() {
		return activityForceEndOrNot;
	}
	public void setActivityForceEndOrNot(int activityForceEndOrNot) {
		this.activityForceEndOrNot = activityForceEndOrNot;
	}
*/	
}
