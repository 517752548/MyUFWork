package com.imop.lj.gm.model;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.CDKeyEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月17日 下午3:29:35
 * @version 1.0
 */

public class CDKeyVO  extends BaseVO implements IExport {

	private String cdkey;
	/** 套餐名称 */
	private int plansId;
	/** 礼包id */
	private int giftId;
	/** 分组Id */
	private int groupId;
	/** gmId */
	private String gmId;
	/** 状态 0创建，1领取 */
	private int state;
	/** 创建时间 */
	private Date createTime;
	/** openId */
	private String openId;
	/** 角色id */
	private long charId;
	/** 角色id */
	private String charName;
	/** 角色服务器id */
	private String chartServerId = "";
	/** 领取时间 */
	private String takeTime;

	public CDKeyVO() {

	}

	public CDKeyVO(CDKeyEntity entity) {
		this.cdkey = entity.getId();
		this.plansId = entity.getPlansId();
		this.giftId = entity.getGiftId();
		this.groupId = entity.getGroupId();
		this.gmId = entity.getGmId();
		this.state = entity.getState();
		this.createTime = new Date(entity.getCreateTime());
		this.openId = entity.getOpenId();
		this.charId = entity.getCharId();
		this.charName = entity.getCharName();
		this.chartServerId = entity.getChartServerId();
		this.takeTime = "";
		if (entity.getTakeTime() > 0) {
			takeTime = TimeUtils.formatYMDHMSTime(entity.getTakeTime());
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

	public String getChartServerId() {
		return chartServerId;
	}

	public void setChartServerId(String chartServerId) {
		this.chartServerId = chartServerId;
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

	public String getOpenId() {
		return openId;
	}

	public void setOpenId(String openId) {
		this.openId = openId;
	}

	public long getCharId() {
		return charId;
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

	public Date getCreateTime() {
		return createTime;
	}

	public void setCreateTime(Date createTime) {
		this.createTime = createTime;
	}

	public String getTakeTime() {
		return takeTime;
	}

	public void setTakeTime(String takeTime) {
		this.takeTime = takeTime;
	}

	@Override
	public List<String> toList() {
		List<String> list = new ArrayList<String>();
		list.add(cdkey);
		list.add(plansId + "");
		list.add(giftId + "");
		list.add(groupId + "");
		list.add(gmId);
		list.add(state + "");
		list.add(TimeUtils.formatYMDHMSTime(createTime.getTime()));
		list.add(openId);
		list.add(charId + "");
		list.add(charName);
		list.add(chartServerId);
		list.add(takeTime);
		return list;
	}

	@Override
	public List<String> list() {
		return toList();
	}

}
