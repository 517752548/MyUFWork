package com.imop.lj.gameserver.cdkeygift.persistance;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.CDKeyEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.scene.CommonScene;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月13日 上午11:18:51
 * @version 1.0
 */

public class CDKeyPO implements PersistanceObject<String, CDKeyEntity> {

	/** cdkey */
	private String cdkey;
	/** 套餐id */
	private int plansId;
	/** 礼包id */
	private int giftId;
	/** gmId */
	private String gmId;
	/** 状态 0创建，1领取 */
	private int state;
	/** 分组id */
	private int groupId;
	/** 创建时间 */
	private long createTime;
	/** openId */
	private String openId;
	/** 领取角色id */
	private long charId;
	/** 领取角色名称 */
	private String charName;
	/** 领取时间 */
	private long takeTime;
	/** 角色服务器id */
	private String chartServerId = "";
	private int isDel;

	/** 是否已经在数据库中 */
	private boolean inDb = false;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	/** 公共场景 */
	private CommonScene commonScene;
	
	public CDKeyPO() {
		this.lifeCycle = new LifeCycleImpl(this);
		commonScene = Globals.getSceneService().getCommonScene();
	}

	@Override
	public void setDbId(String cdkey) {
		this.cdkey = cdkey;
	}

	@Override
	public String getDbId() {
		return cdkey;
	}

	@Override
	public String getGUID() {
		return "CDKeyEntity#" + this.cdkey;
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
		return charId;
	}

	@Override
	public CDKeyEntity toEntity() {
		CDKeyEntity entity = new CDKeyEntity();
		entity.setId(this.cdkey);
		entity.setPlansId(this.plansId);
		entity.setGiftId(this.giftId);
		entity.setGmId(this.gmId);
		entity.setState(this.state);
		entity.setCreateTime(this.createTime);
		entity.setOpenId(this.openId);
		entity.setCharId(this.charId);
		entity.setTakeTime(this.takeTime);
		entity.setGroupId(this.groupId);
		entity.setChartServerId(this.chartServerId);
		entity.setIsDel(isDel);
		return entity;
	}

	@Override
	public void fromEntity(CDKeyEntity entity) {
		this.cdkey = entity.getId();
		this.plansId = entity.getPlansId();
		this.giftId = entity.getGiftId();
		this.gmId = entity.getGmId();
		this.state = entity.getState();
		this.createTime = entity.getCreateTime();
		this.openId = entity.getOpenId();
		this.charId = entity.getCharId();
		this.takeTime = entity.getTakeTime();
		this.chartServerId = entity.getChartServerId();
		this.isDel = entity.getIsDel();
		this.setInDb(true);
		this.active();
	}

	/**
	 * 激活此对象，并初始化属性 此方法在玩家登录加载完数据
	 */
	public void active() {
		getLifeCycle().activate();
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			commonScene.getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}

	public String getCdkey() {
		return cdkey;
	}

	public void setCdkey(String cdkey) {
		this.cdkey = cdkey;
	}


	public int getPlansId() {
		return plansId;
	}

	public void setPlansId(int plansId) {
		this.plansId = plansId;
	}

	public int getGiftId() {
		return giftId;
	}

	public void setGiftId(int giftId) {
		this.giftId = giftId;
	}

	public String getGmId() {
		return gmId;
	}

	public void setGmId(String gmId) {
		this.gmId = gmId;
	}

	public int getState() {
		return state;
	}

	public void setState(int state) {
		this.state = state;
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	public String getOpenId() {
		return openId;
	}

	public void setOpenId(String openId) {
		this.openId = openId;
	}

	public long getTakeTime() {
		return takeTime;
	}

	public void setTakeTime(long takeTime) {
		this.takeTime = takeTime;
	}

	public CommonScene getCommonScene() {
		return commonScene;
	}

	public void setCommonScene(CommonScene commonScene) {
		this.commonScene = commonScene;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	public String getCharName() {
		return charName;
	}

	public void setCharName(String charName) {
		this.charName = charName;
	}

	
	public int getGroupId() {
		return groupId;
	}

	public void setGroupId(int groupId) {
		this.groupId = groupId;
	}

	public String getChartServerId() {
		return chartServerId;
	}

	public void setChartServerId(String chartServerId) {
		this.chartServerId = chartServerId;
	}

	public int getIsDel() {
		return isDel;
	}

	public void setIsDel(int isDel) {
		this.isDel = isDel;
	}

	@Override
	public String toString() {
		return "plansId=" + this.plansId
				+ ", giftId=" + this.giftId
				+ ", gmId=" + this.gmId
				+ ", groupId=" + this.groupId
				+ ", createTime=" + TimeUtils.formatYMDHMSTime(createTime)
				+ ", openid=" + this.openId
				+ ", charId=" + this.charId
				+ ", charName=" + this.charName
				+ ", state=" + this.state
				+ ", takeTime=" + TimeUtils.formatYMDHMSTime(takeTime)
				+ ", inDb=" + this.inDb
				+ ", isDel=" + this.isDel
				;
	}

}
